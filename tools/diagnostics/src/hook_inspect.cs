using System;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in ProbePaths.AssemblyRoots()){ var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in ProbePaths.AssemblyFiles("MemoryRobot.dll","robotManager.dll","wManager.dll")) Assembly.LoadFrom(p);
  var hook=AppDomain.CurrentDomain.GetAssemblies().Select(a=>a.GetType("robotManager.MemoryClass.Hook",false)).First(t=>t!=null);
  Console.WriteLine("HOOK CTORS");
  foreach(var c in hook.GetConstructors(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance)){
   Console.WriteLine(c);
   foreach(var p in c.GetParameters()) Console.WriteLine("  P "+p.Position+" "+p.ParameterType.FullName+" "+p.Name+" default="+(p.IsOptional?p.DefaultValue:""));
  }
  Console.WriteLine("HOOK METHODS");
  foreach(var m in hook.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance).OrderBy(m=>m.Name)){
   if(m.DeclaringType==hook) Console.WriteLine((m.IsStatic?" S ":" I ")+m);
  }
  Console.WriteLine("HOOK FIELDS");
  foreach(var f in hook.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance)) Console.WriteLine((f.IsStatic?" S ":" I ")+f.FieldType.FullName+" "+Escape(f.Name));
  Console.WriteLine("TYPES WITH HOOK FIELD/PROP");
  foreach(var t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a=>SafeTypes(a))){
    bool hit=false;
    foreach(var f in t.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance)) if(f.FieldType==hook){ hit=true; Console.WriteLine("FIELD "+t.FullName+" "+(f.IsStatic?"static ":"")+Escape(f.Name)); }
    foreach(var p in t.GetProperties(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance)) if(p.PropertyType==hook){ hit=true; Console.WriteLine("PROP "+t.FullName+" "+Escape(p.Name)); }
  }
 }
 static Type[] SafeTypes(Assembly a){ try{return a.GetTypes();}catch(ReflectionTypeLoadException ex){return ex.Types.Where(t=>t!=null).ToArray();}}
 static string Escape(string s){ return string.Concat(s.Select(ch=>char.IsControl(ch)||ch>127?"\\u"+((int)ch).ToString("X4"):ch.ToString())); }
}
