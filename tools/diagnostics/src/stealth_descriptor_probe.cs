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
            var hookType = asm.GetType("robotManager.MemoryClass.Hook", true);
            var stealthType = asm.GetType("robotManager.MemoryClass.StealthProtection", true);

            Console.WriteLine("HOOK=" + hookType.FullName);
            Console.WriteLine("STEALTH=" + stealthType.FullName);

            foreach (var ctor in stealthType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine("CTOR=" + ctor);
            }

            foreach (var method in stealthType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                         .OrderBy(m => m.Name)
                         .ThenBy(m => m.GetParameters().Length))
            {
                Console.WriteLine("METHOD name=" + Escape(method.Name) + " return=" + SafeTypeName(method.ReturnType) + " params=" + method.GetParameters().Length);
                foreach (var p in method.GetParameters())
                {
                    Console.WriteLine("  PARAM " + SafeTypeName(p.ParameterType) + " " + p.Name);
                }
            }

            var bridgeTypes = asm.GetTypes()
                .Where(t =>
                {
                    try
                    {
                        var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                        return methods.Any(m => m.Name == "\u0006\u2001\u2005" || m.Name == "_0006_2001_2005")
                            || methods.Any(m => m.Name == "\u0002\u2001\u2005" || m.Name == "_0002_2001_2005");
                    }
                    catch
                    {
                        return false;
                    }
                })
                .OrderBy(t => t.FullName)
                .ToArray();

            foreach (var t in bridgeTypes)
            {
                Console.WriteLine("BRIDGE=" + Escape(t.FullName));
            }

            return 0;
        }
        catch (ReflectionTypeLoadException ex)
        {
            Console.WriteLine("TYPELOAD=" + ex.Message);
            foreach (var loader in ex.LoaderExceptions.Where(e => e != null))
            {
                Console.WriteLine("LOADER=" + loader.GetType().FullName + ":" + loader.Message);
            }
            return 2;
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

    static string SafeTypeName(Type type)
    {
        try
        {
            return type == null ? "null" : (type.FullName ?? type.Name ?? "unknown");
        }
        catch
        {
            return "type-error";
        }
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
