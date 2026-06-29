using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in ProbePaths.AssemblyRoots()){ var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in ProbePaths.AssemblyFiles("MemoryRobot.dll","robotManager.dll","wManager.dll")) Assembly.LoadFrom(p);
  var wow=Process.GetProcessesByName("Wow").OrderBy(p=>p.Id).FirstOrDefault(); if(wow==null){Console.WriteLine("NO_WOW");return;}
  var memType=Type.GetType("wManager.Wow.Memory, wManager");
  var wowMemory=memType.GetField("WowMemory",BindingFlags.Public|BindingFlags.Static).GetValue(null);
  var memory=wowMemory.GetType().GetProperty("Memory").GetValue(wowMemory,null);
  memory.GetType().GetMethod("Open").Invoke(memory,new object[]{wow.Id});
  Type.GetType("wManager.Wow.ObjectManager.Pulsator, wManager").GetMethod("Initialize",new[]{typeof(bool)}).Invoke(null,new object[]{false});
  var om=Type.GetType("wManager.Wow.ObjectManager.ObjectManager, wManager");
  var me=om.GetProperty("Me").GetValue(null,null);
  Console.WriteLine("ME_NAME="+GetProp(me,"Name"));
  Console.WriteLine("ME_LEVEL="+GetProp(me,"Level"));
  Console.WriteLine("ME_HP="+GetProp(me,"HealthPercent"));
  Console.WriteLine("ME_POS="+GetProp(me,"Position"));
  Console.WriteLine("ME_COMBAT="+GetProp(me,"InCombat"));
  Console.WriteLine("ME_MOVE="+GetProp(me,"GetMove"));
  Console.WriteLine("ME_CAST="+GetProp(me,"IsCast"));
  Console.WriteLine("ME_MOUNT="+GetProp(me,"IsMounted"));
  Console.WriteLine("ME_FLY="+GetProp(me,"IsFlying"));
  Console.WriteLine("ME_SWIM="+GetProp(me,"IsSwimming"));
  Console.WriteLine("ME_HASTARGET="+GetProp(me,"HasTarget"));
  var target=GetPropObj(me,"TargetObject");
  Console.WriteLine("TARGET_VALID="+GetProp(target,"IsValid"));
  Console.WriteLine("TARGET_NAME="+GetProp(target,"Name"));
  Console.WriteLine("TARGET_LEVEL="+GetProp(target,"Level"));
  Console.WriteLine("TARGET_HP="+GetProp(target,"HealthPercent"));
 }
 static object GetPropObj(object o,string n){ try{ return o.GetType().GetProperty(n).GetValue(o,null); }catch{return null;} }
 static string GetProp(object o,string n){ try{ if(o==null)return"null"; var p=o.GetType().GetProperty(n); if(p==null)return"missing"; var v=p.GetValue(o,null); return v==null?"null":v.ToString(); } catch(Exception ex){ var e=ex is TargetInvocationException && ex.InnerException!=null?ex.InnerException:ex; return "ERR:"+e.GetType().Name+":"+e.Message; } }
}
