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
        var hookType = robotAsm.GetType("robotManager.MemoryClass.Hook", true);
        Console.WriteLine("TYPE=" + hookType.FullName);
        foreach (var method in hookType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly).OrderBy(m => m.Name).ThenBy(m => m.GetParameters().Length))
        {
            Console.WriteLine("METHOD name=" + Esc(method.Name) + " return=" + SafeTypeName(method.ReturnType) + " params=" + method.GetParameters().Length);
        }
    }
    static string SafeTypeName(Type type)
    {
        try
        {
            return type == null ? "null" : (type.FullName ?? type.Name ?? "unknown");
        }
        catch
        {
            return "type-error";
        }
    }
    static string Esc(string s)
    {
        if (s == null) return "null";
        return string.Concat(s.Select(ch => char.IsControl(ch) ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
