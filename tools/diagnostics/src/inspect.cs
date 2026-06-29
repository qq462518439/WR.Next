using System;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in ProbePaths.AssemblyRoots()){ var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in ProbePaths.AssemblyFiles("MemoryRobot.dll","wManager.dll","robotManager.dll")) try{ Assembly.LoadFrom(p); Console.WriteLine("loaded "+p);}catch(Exception ex){Console.WriteLine("loadfail "+p+" "+ex.GetType()+" "+ex.Message);} 
  foreach(var asm in AppDomain.CurrentDomain.GetAssemblies().OrderBy(a=>a.GetName().Name)){
    foreach(var t in asm.GetTypes().Where(t=>t.FullName!=null && (t.FullName.Contains("WowMemory") || t.FullName.EndsWith("ObjectManager") || t.FullName.Contains("Memory"))).Take(80)) Console.WriteLine(t.FullName);
  }
 }
}
