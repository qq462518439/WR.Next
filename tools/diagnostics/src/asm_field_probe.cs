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
        var memStaticType = wManagerAsm.GetType("wManager.Wow.Memory", true);
        var hook = memStaticType.GetField("WowMemory", BindingFlags.Static | BindingFlags.Public).GetValue(null);
        var memObj = hook.GetType().GetProperty("Memory", BindingFlags.Instance | BindingFlags.Public).GetValue(hook, null);
        var memType = memObj.GetType();
        Console.WriteLine("MEMTYPE=" + memType.FullName);
        foreach (var prop in memType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (prop.Name.IndexOf("Asm", StringComparison.OrdinalIgnoreCase) >= 0)
                Console.WriteLine("PROP " + prop.Name + " type=" + prop.PropertyType.FullName + " value=" + (prop.GetValue(memObj, null) == null ? "null" : prop.GetValue(memObj, null).GetType().FullName));
        }
        foreach (var field in memType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (field.Name.IndexOf("Asm", StringComparison.OrdinalIgnoreCase) >= 0)
                Console.WriteLine("FIELD " + field.Name + " type=" + field.FieldType.FullName + " value=" + (field.GetValue(memObj) == null ? "null" : field.GetValue(memObj).GetType().FullName));
        }
        var wow = Process.GetProcessesByName("Wow").FirstOrDefault();
        Console.WriteLine("WOW=" + (wow==null ? -1 : wow.Id));
    }
}
