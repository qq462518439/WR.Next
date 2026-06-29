using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in new[]{@"D:\666\RZB\Bin",@"D:\666\RZB"}){var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in new[]{@"D:\666\RZB\Bin\MemoryRobot.dll",@"D:\666\RZB\Bin\robotManager.dll",@"D:\666\RZB\Bin\wManager.dll"}) Assembly.LoadFrom(p);
  var wow=Process.GetProcessesByName("Wow").OrderBy(p=>p.Id).FirstOrDefault(); if(wow==null){Console.WriteLine("NO_WOW");return;}
  var memType=Type.GetType("wManager.Wow.Memory, wManager");
  var wowMemory=memType.GetField("WowMemory",BindingFlags.Public|BindingFlags.Static).GetValue(null);
  var memory=wowMemory.GetType().GetProperty("Memory").GetValue(wowMemory,null);
  Console.WriteLine("OPEN="+memory.GetType().GetMethod("Open").Invoke(memory,new object[]{wow.Id}));
  Console.WriteLine("INGAME="+memType.GetMethod("IsInGame").Invoke(null,new object[]{wow.Id}));
  Console.WriteLine("PLAYER="+memType.GetMethod("PlayerName").Invoke(null,new object[]{wow.Id}));
  var pulsator=Type.GetType("wManager.Wow.ObjectManager.Pulsator, wManager");
  try { pulsator.GetMethod("Initialize", new[]{typeof(bool)}).Invoke(null,new object[]{false}); Console.WriteLine("PULSE_OK"); } catch(Exception ex){ Console.WriteLine("PULSE_ERR="+Flatten(ex)); }
  var om=Type.GetType("wManager.Wow.ObjectManager.ObjectManager, wManager");
  var list=om.GetProperty("ObjectList").GetValue(null,null) as System.Collections.ICollection;
  var dict=om.GetProperty("ObjectDictionary").GetValue(null,null) as System.Collections.ICollection;
  Console.WriteLine("LIST="+(list==null?-1:list.Count)+" DICT="+(dict==null?-1:dict.Count));
  var me=om.GetProperty("Me").GetValue(null,null);
  Console.WriteLine("ME_ADDR="+GetProp(me,"GetBaseAddress"));
  Console.WriteLine("ME_VALID="+GetProp(me,"IsValid"));
  Console.WriteLine("ME_NAME="+GetProp(me,"Name"));
  Console.WriteLine("ME_LEVEL="+GetProp(me,"Level"));
  Console.WriteLine("ME_HP="+GetProp(me,"HealthPercent"));
  Console.WriteLine("ME_POS="+GetProp(me,"Position"));
 }
 static string GetProp(object o,string n){ try{ if(o==null)return"null"; var p=o.GetType().GetProperty(n); if(p==null)return"missing"; var v=p.GetValue(o,null); return v==null?"null":v.ToString(); } catch(Exception ex){ return "ERR:"+Flatten(ex); } }
 static string Flatten(Exception ex){ var e=ex is TargetInvocationException && ex.InnerException!=null ? ex.InnerException:ex; return e.GetType().FullName+":"+e.Message; }
}
