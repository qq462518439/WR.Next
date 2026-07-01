using System;
using System.IO;
using System.Linq;
using System.Reflection;
class Probe
{
    static void Main()
    {
        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        Environment.SetEnvironmentVariable("WR_RUNTIME_ROOT", root);
        AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, ResolveEventArgs e)
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            foreach (var dir in new[] { root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") })
            {
                var p = Path.Combine(dir, name);
                if (File.Exists(p)) return Assembly.LoadFrom(p);
            }
            return null;
        };
        var wManagerAsm = Assembly.LoadFrom(Path.Combine(root, "wManager.dll"));
        var nodxType = wManagerAsm.GetTypes().First(t => t.GetFields(BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public).Any(f => f.FieldType == typeof(System.Threading.Thread)));
        Console.WriteLine("TYPE=" + Esc(nodxType.FullName));
        foreach (var f in nodxType.GetFields(BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public).OrderBy(f => f.Name))
        {
            object v = null;
            try { v = f.GetValue(null); } catch (Exception ex) { v = "<err:" + ex.GetType().Name + ">"; }
            var s = v == null ? "null" : v.ToString();
            if (v is System.Threading.Thread) s = "thread";
            Console.WriteLine(Esc(f.Name) + "=" + Esc(s));
        }
    }
    static string Esc(string s)
    {
        if (s == null) return "null";
        return string.Concat(s.Select(ch => char.IsControl(ch) ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
