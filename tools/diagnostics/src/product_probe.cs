using System;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in new[]{@"D:\666\RZB\Bin",@"D:\666\RZB",@"D:\666\RZB\Products"}){var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in new[]{@"D:\666\RZB\Bin\robotManager.dll",@"D:\666\RZB\Products\WRotation.dll"}){ try{var a=Assembly.LoadFrom(p); Console.WriteLine("ASM="+a.FullName); foreach(var t in a.GetTypes()) Console.WriteLine("TYPE="+t.FullName+" IF="+string.Join(",", t.GetInterfaces().Select(i=>i.FullName).ToArray()));}catch(Exception ex){Console.WriteLine("ERR="+ex);} }
 }
}
