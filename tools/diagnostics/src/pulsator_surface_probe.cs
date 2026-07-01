using System;
using System.Linq;
using System.Reflection;
class X{
 static string E(string s){ return string.Concat(s.Select(ch => char.IsControl(ch)||ch>127 ? "\\u"+((int)ch).ToString("X4") : ch.ToString())); }
 static string F(Exception ex){
  if(ex==null) return "null";
  var parts=new System.Collections.Generic.List<string>();
  var cur=ex;
  while(cur!=null){ parts.Add(cur.GetType().FullName+":"+cur.Message); cur=cur.InnerException; }
  return string.Join(" => ", parts);
 }
 static void Dump(string fullName){
  var t=AppDomain.CurrentDomain.GetAssemblies().Select(a=>a.GetType(fullName,false)).FirstOrDefault(x=>x!=null);
  if(t==null){ Console.WriteLine("MISS="+fullName); return; }
  Console.WriteLine("TYPE="+t.FullName);
  Console.WriteLine("FIELDS");
  foreach(var f in t.GetFields(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance|BindingFlags.DeclaredOnly).OrderBy(f=>f.Name))
    Console.WriteLine(" "+(f.IsStatic?"S":"I")+" "+f.FieldType.FullName+" "+E(f.Name));
  Console.WriteLine("PROPS");
  foreach(var p in t.GetProperties(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance|BindingFlags.DeclaredOnly).OrderBy(p=>p.Name))
    Console.WriteLine(" "+p.PropertyType.FullName+" "+E(p.Name));
  Console.WriteLine("METHODS");
  MethodInfo[] methods;
  try{ methods=t.GetMethods(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Static|BindingFlags.Instance|BindingFlags.DeclaredOnly); }
  catch(Exception ex){ Console.WriteLine(" METHODS_ERR "+F(ex)); Console.WriteLine("----"); return; }
  foreach(var m in methods.OrderBy(m=>m.Name)){
    try{
      Console.WriteLine(" "+(m.IsStatic?"S":"I")+" "+m.ReturnType.FullName+" "+E(m.Name)+"("+string.Join(", ",m.GetParameters().Select(p=>p.ParameterType.FullName+" "+E(p.Name)))+")");
    }catch(Exception ex){
      Console.WriteLine(" METHOD_ERR "+E(m.Name)+" "+F(ex));
    }
  }
  Console.WriteLine("----");
 }
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ try{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in new[]{@"D:\\666\\RZB\\Bin",@"D:\\666\\RZB"}){ var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} } catch{} return null; };
  foreach(var p in new[]{@"D:\\666\\RZB\\Bin\\robotManager.dll",@"D:\\666\\RZB\\Bin\\wManager.dll"}) try{ Assembly.LoadFrom(p);}catch(Exception ex){ Console.WriteLine("LOADERR "+p+" "+ex.GetType().FullName+":"+ex.Message); }
  Dump("wManager.Wow.Memory");
  Dump("wManager.Pulsator");
  Dump("wManager.Wow.ObjectManager.Pulsator");
 }
}
