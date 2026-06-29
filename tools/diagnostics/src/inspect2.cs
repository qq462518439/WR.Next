using System;
using System.Linq;
using System.Reflection;
class X{
 static void Dump(Type t){ Console.WriteLine("TYPE "+t.FullName); foreach(var m in t.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance).Where(m=>m.Name.IndexOf("Process",StringComparison.OrdinalIgnoreCase)>=0||m.Name.IndexOf("Open",StringComparison.OrdinalIgnoreCase)>=0||m.Name.IndexOf("Attach",StringComparison.OrdinalIgnoreCase)>=0||m.Name.IndexOf("Memory",StringComparison.OrdinalIgnoreCase)>=0||m.Name.IndexOf("Initial",StringComparison.OrdinalIgnoreCase)>=0).Take(100)) Console.WriteLine(" M "+m); foreach(var p in t.GetProperties(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance).Take(100)) Console.WriteLine(" P "+p.PropertyType.FullName+" "+p.Name); foreach(var f in t.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance).Take(80)) Console.WriteLine(" F "+f.FieldType.FullName+" "+f.Name); }
 static void Main(){ AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in new[]{@"D:\666\RZB\Bin",@"D:\666\RZB"}){var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  Assembly.LoadFrom(@"D:\666\RZB\Bin\MemoryRobot.dll"); Assembly.LoadFrom(@"D:\666\RZB\Bin\wManager.dll"); Assembly.LoadFrom(@"D:\666\RZB\Bin\robotManager.dll");
  foreach(var name in new[]{"MemoryRobot.Memory","wManager.Wow.Memory","wManager.Wow.ObjectManager.ObjectManager","robotManager.MemoryClass.Hook","robotManager.MemoryClass.AllocManager"}){ var t=AppDomain.CurrentDomain.GetAssemblies().Select(a=>a.GetType(name,false)).FirstOrDefault(x=>x!=null); if(t!=null) Dump(t); else Console.WriteLine("MISS "+name); }
 }
}
