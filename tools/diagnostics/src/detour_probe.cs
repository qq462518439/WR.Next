using System;
using System.Linq;
using System.Reflection;

class X
{
    static void Main()
    {
        try
        {
            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                try
                {
                    var n = new AssemblyName(e.Name).Name + ".dll";
                    foreach (var d in new[] { @"D:\666\RZB\Bin", @"D:\666\RZB" })
                    {
                        var p = System.IO.Path.Combine(d, n);
                        if (System.IO.File.Exists(p))
                        {
                            Console.WriteLine("RESOLVE " + p);
                            return Assembly.LoadFrom(p);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RESOLVE_ERR " + Flatten(ex));
                }

                return null;
            };

            foreach (var p in new[]
                     {
                         @"D:\666\RZB\Bin\MemoryRobot.dll",
                         @"D:\666\RZB\Bin\robotManager.dll",
                         @"D:\666\RZB\Bin\wManager.dll"
                     })
            {
                try
                {
                    var asm = Assembly.LoadFrom(p);
                    Console.WriteLine("LOAD " + asm.FullName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("LOAD_ERR " + p + " " + Flatten(ex));
                }
            }

            foreach (var fullName in new[]
                     {
                         "wManager.Wow.Memory",
                         "wManager.Pulsator",
                         "wManager.Wow.ObjectManager.Pulsator",
                         "robotManager.MemoryClass.Hook"
                     })
            {
                try
                {
                    var t = AppDomain.CurrentDomain.GetAssemblies()
                        .Select(a =>
                        {
                            try { return a.GetType(fullName, false); }
                            catch (Exception ex)
                            {
                                Console.WriteLine("GETTYPE_ERR " + a.FullName + " " + Flatten(ex));
                                return null;
                            }
                        })
                        .FirstOrDefault(x => x != null);

                    if (t == null)
                    {
                        Console.WriteLine("MISS=" + fullName);
                        continue;
                    }

                    Console.WriteLine("TYPE=" + t.FullName);

                    foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(m => m.Name))
                    {
                        var name = m.Name;
                        if (name.IndexOf("Detour", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("OpCode", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("Pulse", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("Hook", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("Thread", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("Inject", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("Search", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            name.IndexOf("Call", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.WriteLine(" M " + m);
                        }
                    }

                    foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(p => p.Name))
                    {
                        if (p.Name.IndexOf("Hook", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            p.Name.IndexOf("Thread", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            p.Name.IndexOf("Memory", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            Console.WriteLine(" P " + p.PropertyType.FullName + " " + p.Name);
                        }
                    }

                    Console.WriteLine("----");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("TYPE_ERR " + fullName + " " + Flatten(ex));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("FATAL " + Flatten(ex));
        }
    }

    static string Flatten(Exception ex)
    {
        if (ex == null)
        {
            return "null";
        }

        var current = ex;
        var rtl = current as ReflectionTypeLoadException;
        if (rtl != null)
        {
            return current.GetType().FullName + ":" + current.Message + " LOADER=" +
                   string.Join(" || ", rtl.LoaderExceptions.Where(e => e != null).Select(Flatten));
        }

        var parts = new System.Collections.Generic.List<string>();
        while (current != null)
        {
            parts.Add(current.GetType().FullName + ":" + current.Message);
            current = current.InnerException;
        }

        return string.Join(" => ", parts);
    }
}
