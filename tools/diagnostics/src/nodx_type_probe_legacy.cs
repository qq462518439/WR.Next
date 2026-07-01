using System;
using System.IO;
using System.Linq;
using System.Reflection;

class X
{
    static void Main()
    {
        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        var bin = Path.Combine(root, "Bin");

        AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            string[] dirs = { bin, root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") };
            foreach (var dir in dirs)
            {
                var path = Path.Combine(dir, name);
                if (File.Exists(path))
                    return Assembly.LoadFrom(path);
            }
            return null;
        };

        Assembly.LoadFrom(Path.Combine(bin, "MemoryRobot.dll"));
        Assembly.LoadFrom(Path.Combine(bin, "robotManager.dll"));
        var w = Assembly.LoadFrom(Path.Combine(bin, "wManager.dll"));

        Type[] types;
        try { types = w.GetTypes(); }
        catch (ReflectionTypeLoadException ex) { types = ex.Types.Where(t => t != null).ToArray(); }

        Console.WriteLine("TYPECOUNT " + types.Length);
        foreach (var t in types.OrderBy(t => t.FullName, StringComparer.Ordinal))
        {
            var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (fields.Length < 3)
                continue;

            var threadFields = fields.Where(f => f.FieldType.FullName == "System.Threading.Thread").ToArray();
            var uintFields = fields.Where(f => f.FieldType.FullName == "System.UInt32").ToArray();
            var objFields = fields.Where(f => f.FieldType.FullName == "System.Object").ToArray();
            var boolFields = fields.Where(f => f.FieldType.FullName == "System.Boolean").ToArray();

            if (threadFields.Length == 0 && uintFields.Length == 0 && objFields.Length == 0 && boolFields.Length == 0)
                continue;

            Console.WriteLine("TYPE " + Escape(t.FullName));
            Console.WriteLine("  STATICFIELDCOUNT " + fields.Length);
            Console.WriteLine("  THREADS " + string.Join(", ", threadFields.Select(f => Escape(f.Name)).ToArray()));
            Console.WriteLine("  UINTS   " + string.Join(", ", uintFields.Select(f => Escape(f.Name)).ToArray()));
            Console.WriteLine("  OBJS    " + string.Join(", ", objFields.Select(f => Escape(f.Name)).ToArray()));
            Console.WriteLine("  BOOLS   " + string.Join(", ", boolFields.Select(f => Escape(f.Name)).ToArray()));

            var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.DeclaringType == t)
                .OrderBy(m => m.Name, StringComparer.Ordinal)
                .ToArray();

            foreach (var m in methods.Take(20))
                Console.WriteLine("  METHOD  " + Escape(m.Name) + " :: " + m);
        }
    }

    static string Escape(string s)
    {
        if (s == null) return "null";
        return string.Concat(s.Select(ch => char.IsControl(ch) || ch > 127 ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
