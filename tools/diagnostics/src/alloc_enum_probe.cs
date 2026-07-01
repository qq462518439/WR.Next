using System;
using System.IO;
using System.Linq;
using System.Reflection;
class Probe
{
    static void Main()
    {
        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, ResolveEventArgs e)
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            var p = Path.Combine(root, name);
            return File.Exists(p) ? Assembly.LoadFrom(p) : null;
        };
        var robotAsm = Assembly.LoadFrom(Path.Combine(root, "robotManager.dll"));
        var memoryAsm = Assembly.LoadFrom(Path.Combine(root, "MemoryRobot.dll"));
        var allocType = robotAsm.GetType("robotManager.MemoryClass.AllocManager", true);
        Console.WriteLine("ALLOC=" + allocType.FullName);
        foreach (var ctor in allocType.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine("CTOR " + ctor);
        }
        var memProtType = memoryAsm.GetType("MemoryRobot.MemoryProtection", true);
        Console.WriteLine("MEMPROT=" + memProtType.FullName + " isEnum=" + memProtType.IsEnum);
        foreach (var name in Enum.GetNames(memProtType))
        {
            Console.WriteLine("  " + name + "=" + Convert.ToUInt32(Enum.Parse(memProtType, name)));
        }
        var asmType = memoryAsm.GetType("MemoryRobot.Asm", true);
        Console.WriteLine("ASM=" + asmType.FullName);
        foreach (var method in asmType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).OrderBy(m => m.Name))
        {
            Console.WriteLine("METHOD " + method);
        }
    }
}
