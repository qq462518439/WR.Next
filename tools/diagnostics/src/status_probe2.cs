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
  Console.WriteLine("PID="+wow.Id+" TITLE="+wow.MainWindowTitle);
  var memType=Type.GetType("wManager.Wow.Memory, wManager");
  var wowMemory=memType.GetField("WowMemory",BindingFlags.Public|BindingFlags.Static).GetValue(null);
  var memory=wowMemory.GetType().GetProperty("Memory").GetValue(wowMemory,null);
  Console.WriteLine("OPEN="+memory.GetType().GetMethod("Open").Invoke(memory,new object[]{wow.Id}));
  Console.WriteLine("VALID="+memory.GetType().GetMethod("IsValidAndOpenProcess").Invoke(memory,null));
  Console.WriteLine("INGAME="+memType.GetMethod("IsInGame").Invoke(null,new object[]{wow.Id}));
  Console.WriteLine("PLAYER="+memType.GetMethod("PlayerName").Invoke(null,new object[]{wow.Id}));
  var pulsator=Type.GetType("wManager.Wow.ObjectManager.Pulsator, wManager");
  for(int i=0;i<3;i++){ try{pulsator.GetMethod("Initialize",new[]{typeof(bool)}).Invoke(null,new object[]{false}); Console.WriteLine("PULSE"+i+"=OK");}catch(Exception ex){Console.WriteLine("PULSE"+i+"="+Flat(ex));} System.Threading.Thread.Sleep(200); }
  var om=Type.GetType("wManager.Wow.ObjectManager.ObjectManager, wManager");
  var list=om.GetProperty("ObjectList").GetValue(null,null) as System.Collections.ICollection;
  var dict=om.GetProperty("ObjectDictionary").GetValue(null,null) as System.Collections.ICollection;
  Console.WriteLine("LIST="+(list==null?-1:list.Count)+" DICT="+(dict==null?-1:dict.Count));
  var me=om.GetProperty("Me").GetValue(null,null);
  foreach(var p in new[]{"GetBaseAddress","IsValid","Name","Level","HealthPercent","Position","InCombat","GetMove","HasTarget"}) Console.WriteLine("ME_"+p+"="+GetProp(me,p));
 }
 static string GetProp(object o,string n){ try{ if(o==null)return"null"; var p=o.GetType().GetProperty(n); if(p==null)return"missing"; var v=p.GetValue(o,null); return v==null?"null":v.ToString(); } catch(Exception ex){ return "ERR:"+Flat(ex); } }
 static string Flat(Exception ex){ var e=ex is TargetInvocationException && ex.InnerException!=null?ex.InnerException:ex; return e.GetType().Name+":"+e.Message; }
}
