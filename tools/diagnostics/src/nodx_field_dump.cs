using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
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
        var nodxType = wManagerAsm.GetTypes().FirstOrDefault(t => t.GetFields(BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public).Any(f => f.FieldType == typeof(System.Threading.Thread)));
        Console.WriteLine("TYPE=" + nodxType.FullName);
        foreach (var field in nodxType.GetFields(BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public).OrderBy(f => f.Name))
        {
            object value = null;
            try { value = field.GetValue(null); } catch (Exception ex) { value = "<err:" + ex.GetType().Name + ">"; }
            string shown;
            if (value == null) shown = "null";
            else if (value is string) shown = (string)value;
            else if (value is Array) shown = value.GetType().FullName;
            else shown = value + " (" + value.GetType().FullName + ")";
            Console.WriteLine("FIELD " + Escape(field.Name) + " type=" + field.FieldType.FullName + " value=" + Escape(shown));
        }
    }
    static string Escape(string s)
    {
        if (s == null) return "null";
        var chars = s.Select(ch => char.IsControl(ch) ? "\\u" + ((int)ch).ToString("X4") : ch.ToString());
        return string.Concat(chars);
    }
}
