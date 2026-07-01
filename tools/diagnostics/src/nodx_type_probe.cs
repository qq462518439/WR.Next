using System;
using System.Linq;
using System.Reflection;
using System.Threading;

class X
{
    static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
        {
            var n = new AssemblyName(e.Name).Name + ".dll";
            foreach (var d in ProbePaths.AssemblyRoots())
            {
                var p = System.IO.Path.Combine(d, n);
                if (System.IO.File.Exists(p))
                {
                    return Assembly.LoadFrom(p);
                }
            }

            return null;
        };

        foreach (var p in ProbePaths.AssemblyFiles("MemoryRobot.dll", "robotManager.dll", "wManager.dll"))
        {
            Assembly.LoadFrom(p);
        }

        var wmanager = AppDomain.CurrentDomain.GetAssemblies()
            .First(a => string.Equals(a.GetName().Name, "wManager", StringComparison.OrdinalIgnoreCase));

        foreach (var t in SafeTypes(wmanager).OrderBy(t => t.FullName, StringComparer.Ordinal))
        {
            var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var threadFields = fields.Where(f => typeof(Thread).IsAssignableFrom(f.FieldType)).ToArray();
            var uintFields = fields.Where(f => f.FieldType == typeof(uint)).ToArray();
            var objectFields = fields.Where(f => f.FieldType == typeof(object)).ToArray();
            var boolFields = fields.Where(f => f.FieldType == typeof(bool)).ToArray();

            if (threadFields.Length == 0 || uintFields.Length < 2)
            {
                continue;
            }

            Console.WriteLine("TYPE " + Escape(t.FullName));
            Console.WriteLine("  THREADS " + string.Join(", ", threadFields.Select(f => Escape(f.Name))));
            Console.WriteLine("  UINTS   " + string.Join(", ", uintFields.Select(f => Escape(f.Name))));
            Console.WriteLine("  OBJS    " + string.Join(", ", objectFields.Select(f => Escape(f.Name))));
            Console.WriteLine("  BOOLS   " + string.Join(", ", boolFields.Select(f => Escape(f.Name))));

            var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.DeclaringType == t)
                .OrderBy(m => m.Name, StringComparer.Ordinal)
                .Select(m => (m.IsPublic ? "public " : "nonpublic ") + Escape(m.Name) + " :: " + m)
                .ToArray();

            foreach (var m in methods.Take(20))
            {
                Console.WriteLine("  METHOD  " + m);
            }
        }
    }

    static Type[] SafeTypes(Assembly a)
    {
        try { return a.GetTypes(); }
        catch (ReflectionTypeLoadException ex) { return ex.Types.Where(t => t != null).ToArray(); }
    }

    static string Escape(string s)
    {
        return string.Concat(s.Select(ch => char.IsControl(ch) || ch > 127 ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
