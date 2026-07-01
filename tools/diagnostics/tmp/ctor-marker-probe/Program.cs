using System;
using System.IO;
using System.Linq;
using System.Reflection;

const string root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
AppDomain.CurrentDomain.AssemblyResolve += (_, args) =>
{
    var path = Path.Combine(root, new AssemblyName(args.Name).Name + ".dll");
    return File.Exists(path) ? Assembly.LoadFrom(path) : null;
};
var asm = Assembly.LoadFrom(Path.Combine(root, "robotManager.dll"));
foreach (var t in asm.GetTypes().Where(t => t.GetMethods(BindingFlags.Static|BindingFlags.Public|BindingFlags.NonPublic).Any(m => m.Name == "\u0002" && m.ReturnType == typeof(string) && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(int))))
{
    Console.WriteLine(t.FullName);
}
