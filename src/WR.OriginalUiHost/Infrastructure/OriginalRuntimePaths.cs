using System;
using System.IO;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalRuntimePaths
    {
        private static readonly string LegacyRuntimeRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "artifacts", "uihost-runtime-layout"));
        private static readonly Lazy<OriginalRuntimePaths> LazyCurrent = new Lazy<OriginalRuntimePaths>(CreateDefault);

        private OriginalRuntimePaths(string root)
        {
            Root = root;
            RuntimeAssemblyRoot = ResolveFirstExisting(root, Path.Combine(root, "Bin"));
            DataRoot = ResolveFirstExisting(Path.Combine(root, "Data"), Path.Combine(root, "data", "Data"));
            LogsRoot = ResolveFirstExisting(Path.Combine(root, "logs"), Path.Combine(root, "Logs"));
            ModulesRoot = root;
            ProductsRoot = ResolveFirstExisting(Path.Combine(root, "Products"));
            PluginsRoot = ResolveFirstExisting(Path.Combine(root, "Plugins"));
            FightClassRoot = ResolveFirstExisting(Path.Combine(root, "FightClass"));
            ProfilesRoot = ResolveFirstExisting(Path.Combine(root, "Profiles"));
            SettingsRoot = ResolveFirstExisting(Path.Combine(root, "Settings"));
            ToolsRoot = ResolveFirstExisting(Path.Combine(root, "tools"), Path.Combine(root, "Tools"));
        }

        public static OriginalRuntimePaths Current => LazyCurrent.Value;

        public string Root { get; }
        public string RuntimeAssemblyRoot { get; }
        public string DataRoot { get; }
        public string LogsRoot { get; }
        public string ModulesRoot { get; }
        public string ProductsRoot { get; }
        public string PluginsRoot { get; }
        public string FightClassRoot { get; }
        public string ProfilesRoot { get; }
        public string SettingsRoot { get; }
        public string ToolsRoot { get; }
        public string MinimapsRoot => Path.Combine(DataRoot, "Minimaps");

        public static OriginalRuntimePaths CreateDefault()
        {
            var envRoot = Environment.GetEnvironmentVariable("WR_RUNTIME_ROOT");
            if (LooksLikeRuntimeRoot(envRoot))
            {
                return new OriginalRuntimePaths(envRoot);
            }

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            if (LooksLikeRuntimeRoot(baseDirectory))
            {
                return new OriginalRuntimePaths(baseDirectory);
            }

            var parent = Directory.GetParent(baseDirectory)?.FullName;
            if (LooksLikeRuntimeRoot(parent))
            {
                return new OriginalRuntimePaths(parent);
            }

            if (LooksLikeRuntimeRoot(LegacyRuntimeRoot))
            {
                return new OriginalRuntimePaths(LegacyRuntimeRoot);
            }

            return new OriginalRuntimePaths(AppDomain.CurrentDomain.BaseDirectory);
        }

        private static bool LooksLikeRuntimeRoot(string root)
        {
            if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root))
            {
                return false;
            }

            return Directory.Exists(Path.Combine(root, "Data")) ||
                   Directory.Exists(Path.Combine(root, "data", "Data")) ||
                   File.Exists(Path.Combine(root, "WR.OriginalUiHost.exe")) ||
                   Directory.Exists(Path.Combine(root, "Bin")) ||
                   Directory.Exists(Path.Combine(root, "runtime"));
        }

        private static string ResolveFirstExisting(params string[] candidates)
        {
            foreach (var candidate in candidates)
            {
                if (!string.IsNullOrWhiteSpace(candidate) && Directory.Exists(candidate))
                {
                    return candidate;
                }
            }

            return candidates.Length > 0 ? candidates[0] : string.Empty;
        }
    }
}
