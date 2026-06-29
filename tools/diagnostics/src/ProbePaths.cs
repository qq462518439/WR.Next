using System;
using System.IO;

internal static class ProbePaths
{
    internal static string ResolveRoot()
    {
        var envRoot = Environment.GetEnvironmentVariable("WR_RUNTIME_ROOT");
        if (LooksLikeRoot(envRoot))
        {
            return envRoot;
        }

        var baseDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        if (LooksLikeRoot(baseDir))
        {
            return baseDir;
        }

        var parent = Directory.GetParent(baseDir)?.FullName;
        if (LooksLikeRoot(parent))
        {
            return parent;
        }

        var fallback = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "artifacts", "uihost-runtime-layout"));
        if (LooksLikeRoot(fallback))
        {
            return fallback;
        }

        return baseDir;
    }

    internal static string[] AssemblyRoots()
    {
        var root = ResolveRoot();
        return new[]
        {
            Path.Combine(root, "runtime"),
            Path.Combine(root, "Bin"),
            root,
            Path.Combine(root, "modules"),
            Path.Combine(root, "Products"),
            Path.Combine(root, "FightClass")
        };
    }

    internal static string[] AssemblyFiles(params string[] names)
    {
        var root = ResolveRoot();
        var runtime = Path.Combine(root, "runtime");
        var bin = Path.Combine(root, "Bin");
        var assemblies = new string[names.Length];
        for (var i = 0; i < names.Length; i++)
        {
            var name = names[i];
            assemblies[i] = File.Exists(Path.Combine(runtime, name)) ? Path.Combine(runtime, name)
                : File.Exists(Path.Combine(bin, name)) ? Path.Combine(bin, name)
                : Path.Combine(root, name);
        }

        return assemblies;
    }

    private static bool LooksLikeRoot(string root)
    {
        if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root))
        {
            return false;
        }

        return Directory.Exists(Path.Combine(root, "runtime")) ||
               Directory.Exists(Path.Combine(root, "Bin")) ||
               Directory.Exists(Path.Combine(root, "modules")) ||
               Directory.Exists(Path.Combine(root, "Data")) ||
               Directory.Exists(Path.Combine(root, "data", "Data"));
    }
}
