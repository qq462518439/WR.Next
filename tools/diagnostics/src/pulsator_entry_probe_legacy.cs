using System;
using System.IO;
using System.Linq;
using System.Reflection;

class X
{
    static string F(Exception ex)
    {
        if (ex == null) return "null";
        var parts = new System.Collections.Generic.List<string>();
        var cur = ex;
        while (cur != null)
        {
            parts.Add(cur.GetType().FullName + ":" + cur.Message);
            cur = cur.InnerException;
        }
        return string.Join(" => ", parts.ToArray());
    }

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

        try { Assembly.LoadFrom(Path.Combine(bin, "MemoryRobot.dll")); Console.WriteLine("LOAD MemoryRobot ok"); } catch (Exception ex) { Console.WriteLine("LOAD MemoryRobot " + F(ex)); }
        try { Assembly.LoadFrom(Path.Combine(bin, "robotManager.dll")); Console.WriteLine("LOAD robotManager ok"); } catch (Exception ex) { Console.WriteLine("LOAD robotManager " + F(ex)); }
        Assembly w = null;
        try { w = Assembly.LoadFrom(Path.Combine(bin, "wManager.dll")); Console.WriteLine("LOAD wManager ok"); } catch (Exception ex) { Console.WriteLine("LOAD wManager " + F(ex)); }

        if (w == null) return;

        DumpType(w, "wManager.Pulsator");
        DumpType(w, "wManager.Wow.Memory");
        DumpType(w, "wManager.Wow.ObjectManager.Pulsator");
    }

    static void DumpType(Assembly asm, string name)
    {
        try
        {
            var t = asm.GetType(name, false);
            if (t == null)
            {
                Console.WriteLine("MISS " + name);
                return;
            }

            Console.WriteLine("TYPE " + t.FullName);
            foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(m => m.Name))
            {
                try
                {
                    Console.WriteLine(" METHOD " + (m.IsStatic ? "S " : "I ") + m.ReturnType.FullName + " " + m.Name + "(" + string.Join(", ", m.GetParameters().Select(p => p.ParameterType.FullName + " " + p.Name).ToArray()) + ")");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" METHODERR " + m.Name + " " + F(ex));
                }
            }
            foreach (var f in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(f => f.Name))
            {
                try
                {
                    Console.WriteLine(" FIELD " + (f.IsStatic ? "S " : "I ") + f.FieldType.FullName + " " + f.Name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" FIELDERR " + f.Name + " " + F(ex));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("TYPEERR " + name + " " + F(ex));
        }
    }
}
