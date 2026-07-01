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
        var memAsm = Assembly.LoadFrom(Path.Combine(root, "MemoryRobot.dll"));
        foreach (var type in memAsm.GetTypes().OrderBy(t => t.FullName))
        {
            if (type.FullName.IndexOf("asm", StringComparison.OrdinalIgnoreCase) >= 0 ||
                type.Name.IndexOf("asm", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine("TYPE " + type.FullName);
                foreach (var ctor in type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine("  CTOR " + ctor);
                }
            }
        }
        var memoryType = memAsm.GetTypes().FirstOrDefault(t => t.FullName == "MemoryRobot.Memory");
        Console.WriteLine("MEMORYTYPE=" + memoryType);
        foreach (var prop in memoryType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            if (prop.Name.IndexOf("Asm", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine("PROP " + prop.PropertyType.FullName + " " + prop.Name + " canWrite=" + prop.CanWrite);
            }
        }
        foreach (var field in memoryType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            if (field.Name.IndexOf("Asm", StringComparison.OrdinalIgnoreCase) >= 0 || (field.FieldType != null && field.FieldType.FullName.IndexOf("Asm", StringComparison.OrdinalIgnoreCase) >= 0))
            {
                Console.WriteLine("FIELD " + field.FieldType.FullName + " " + field.Name);
            }
        }
    }
}
