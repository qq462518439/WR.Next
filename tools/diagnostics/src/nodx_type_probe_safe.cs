using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

class X
{
    static int Main()
    {
        try
        {
            var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
            var bin = Path.Combine(root, "Bin");
            AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
            {
                try
                {
                    var name = new AssemblyName(e.Name).Name + ".dll";
                    string[] dirs = { bin, root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") };
                    foreach (var dir in dirs)
                    {
                        var path = Path.Combine(dir, name);
                        if (File.Exists(path))
                            return Assembly.LoadFrom(path);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RESOLVE_ERR " + ex.GetType().FullName + " :: " + ex.Message);
                }
                return null;
            };

            TryLoad(Path.Combine(bin, "MemoryRobot.dll"));
            TryLoad(Path.Combine(bin, "robotManager.dll"));
            var w = TryLoad(Path.Combine(bin, "wManager.dll"));
            if (w == null)
            {
                Console.WriteLine("LOAD_FAIL wManager");
                return 2;
            }

            Type[] types;
            try { types = w.GetTypes(); }
            catch (ReflectionTypeLoadException ex)
            {
                Console.WriteLine("RTL types=" + ex.Types.Count(t => t != null));
                foreach (var le in ex.LoaderExceptions.Where(e => e != null))
                    Console.WriteLine("LOADER " + le.GetType().FullName + " :: " + le.Message);
                types = ex.Types.Where(t => t != null).ToArray();
            }

            foreach (var t in types.OrderBy(t => t.FullName, StringComparer.Ordinal))
            {
                try
                {
                    var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    var threadFields = fields.Where(f => typeof(Thread).IsAssignableFrom(f.FieldType)).ToArray();
                    var uintFields = fields.Where(f => f.FieldType == typeof(uint)).ToArray();
                    var objectFields = fields.Where(f => f.FieldType == typeof(object)).ToArray();
                    if (threadFields.Length == 0 || uintFields.Length < 2 || objectFields.Length == 0)
                        continue;
                    Console.WriteLine("TYPE " + Escape(t.FullName));
                    Console.WriteLine(" THREADS " + string.Join(", ", threadFields.Select(f => Escape(f.Name)).ToArray()));
                    Console.WriteLine(" UINTS " + string.Join(", ", uintFields.Select(f => Escape(f.Name)).ToArray()));
                    Console.WriteLine(" OBJS " + string.Join(", ", objectFields.Select(f => Escape(f.Name)).ToArray()));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("TYPE_ERR " + Escape(t.FullName) + " :: " + ex.GetType().FullName + " :: " + ex.Message);
                }
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("FATAL " + ex.GetType().FullName + " :: " + ex.Message);
            var rtl = ex as ReflectionTypeLoadException;
            if (rtl != null && rtl.LoaderExceptions != null)
            {
                foreach (var le in rtl.LoaderExceptions.Where(e => e != null))
                    Console.WriteLine("FATAL_LOADER " + le.GetType().FullName + " :: " + le.Message);
            }
            return 1;
        }
    }

    static Assembly TryLoad(string path)
    {
        try
        {
            var asm = Assembly.LoadFrom(path);
            Console.WriteLine("LOAD " + asm.GetName().Name + " :: " + path);
            return asm;
        }
        catch (Exception ex)
        {
            Console.WriteLine("LOAD_ERR " + path + " :: " + ex.GetType().FullName + " :: " + ex.Message);
            return null;
        }
    }

    static string Escape(string s)
    {
        if (s == null) return "null";
        return string.Concat(s.Select(ch => char.IsControl(ch) || ch > 127 ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
