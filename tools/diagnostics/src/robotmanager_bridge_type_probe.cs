using System;
using System.IO;
using System.Linq;
using System.Reflection;

class Probe
{
    static int Main()
    {
        const string root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        AppDomain.CurrentDomain.AssemblyResolve += ResolveFromRoot;

        try
        {
            var asm = Assembly.LoadFrom(Path.Combine(root, "robotManager.dll"));
            Type[] types;
            try
            {
                types = asm.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                types = ex.Types.Where(t => t != null).ToArray();
                foreach (var loaderException in ex.LoaderExceptions.Where(e => e != null))
                {
                    Console.WriteLine("LOADER=" + loaderException.GetType().FullName + ":" + loaderException.Message);
                }
            }

            foreach (var type in types.OrderBy(t => t.FullName))
            {
                try
                {
                    var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    var hasEngineFactory = methods.Any(m => m.Name == "\u0006\u2001\u2005" || m.Name == "_0006_2001_2005");
                    var hasStreamFactory = methods.Any(m => m.Name == "\u0002\u2001\u2005" || m.Name == "_0002_2001_2005");
                    if (hasEngineFactory || hasStreamFactory)
                    {
                        Console.WriteLine("TYPE=" + Escape(type.FullName));
                        foreach (var method in methods.Where(m => m.Name.Contains("\u2001") || m.Name.Contains("\u2005") || m.Name.StartsWith("_000")))
                        {
                            Console.WriteLine("  METHOD " + Escape(method.Name) + " return=" + Escape(method.ReturnType.FullName) + " params=" + method.GetParameters().Length);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("TYPEERR=" + Escape(type.FullName) + " err=" + ex.GetType().Name);
                }
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR=" + ex.GetType().FullName + ":" + ex.Message);
            return 1;
        }
    }

    static Assembly ResolveFromRoot(object sender, ResolveEventArgs args)
    {
        const string root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        var name = new AssemblyName(args.Name).Name + ".dll";
        var path = Path.Combine(root, name);
        return File.Exists(path) ? Assembly.LoadFrom(path) : null;
    }

    static string Escape(string value)
    {
        if (value == null)
        {
            return "null";
        }

        return string.Concat(value.Select(ch => char.IsControl(ch) ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
