using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  System.IO.Directory.SetCurrentDirectory(ProbePaths.ResolveRoot());
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in ProbePaths.AssemblyRoots()){ var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in ProbePaths.AssemblyFiles("MemoryRobot.dll","robotManager.dll","wManager.dll")) Assembly.LoadFrom(p);
  var wow=Process.GetProcessesByName("Wow").OrderBy(p=>p.Id).FirstOrDefault(); if(wow==null){Console.WriteLine("NO_WOW");return;}
  var memType=Type.GetType("wManager.Wow.Memory, wManager");
  var wowMemory=memType.GetField("WowMemory",BindingFlags.Public|BindingFlags.Static).GetValue(null);
  var memory=wowMemory.GetType().GetProperty("Memory").GetValue(wowMemory,null);
  Console.WriteLine("OPEN="+memory.GetType().GetMethod("Open").Invoke(memory,new object[]{wow.Id}));
  Console.WriteLine("INGAME="+memType.GetMethod("IsInGame").Invoke(null,new object[]{wow.Id}));
  var products=Type.GetType("robotManager.Products.Products, robotManager");
  Dump(products,"before");
  try{ products.GetMethod("LoadProducts").Invoke(null,new object[]{"WRotation"}); Console.WriteLine("LOAD_OK"); }catch(Exception ex){Console.WriteLine("LOAD_ERR="+Flat(ex));}
  Dump(products,"afterLoad");
  try{ var r=products.GetMethod("ProductStart").Invoke(null,null); Console.WriteLine("START_RET="+r); }catch(Exception ex){Console.WriteLine("START_ERR="+Flat(ex));}
  Dump(products,"afterStart");
  try{ Type.GetType("wManager.Wow.ObjectManager.Pulsator, wManager").GetMethod("Initialize",new[]{typeof(bool)}).Invoke(null,new object[]{false}); Console.WriteLine("PULSE_OK"); }catch(Exception ex){Console.WriteLine("PULSE_ERR="+Flat(ex));}
  Dump(products,"afterPulse");
 }
 static void Dump(Type products,string label){
  Console.WriteLine("--"+label+"--");
  foreach(var p in new[]{"IsAliveProduct","IsStarted","InPause","ProductName"}){try{Console.WriteLine(p+"="+products.GetProperty(p).GetValue(null,null));}catch(Exception ex){Console.WriteLine(p+"ERR="+Flat(ex));}}
  try{var f=products.GetField("m__0002",BindingFlags.Static|BindingFlags.NonPublic); var v=f.GetValue(null); Console.WriteLine("productObj="+(v==null?"null":v.GetType().FullName));}catch(Exception ex){Console.WriteLine("productObjERR="+Flat(ex));}
 }
 static string Flat(Exception ex){ var e=ex is TargetInvocationException && ex.InnerException!=null?ex.InnerException:ex; return e.GetType().FullName+":"+e.Message; }
}
