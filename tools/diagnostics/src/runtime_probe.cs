using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
class X{
 static void Main(){
  AppDomain.CurrentDomain.AssemblyResolve += (s,e)=>{ var n=new AssemblyName(e.Name).Name+".dll"; foreach(var d in ProbePaths.AssemblyRoots()){ var p=System.IO.Path.Combine(d,n); if(System.IO.File.Exists(p)) return Assembly.LoadFrom(p);} return null; };
  foreach(var p in ProbePaths.AssemblyFiles("MemoryRobot.dll","robotManager.dll","wManager.dll")) Assembly.LoadFrom(p);
  var wow=Process.GetProcessesByName("Wow").OrderBy(p=>p.Id).FirstOrDefault();
  if(wow==null){ Console.WriteLine("NO_WOW"); return; }
  Console.WriteLine("PID="+wow.Id+" TITLE="+wow.MainWindowTitle);
  var memType=Type.GetType("wManager.Wow.Memory, wManager");
  var wowMemory=memType.GetField("WowMemory",BindingFlags.Public|BindingFlags.Static).GetValue(null);
  var memory=wowMemory.GetType().GetProperty("Memory").GetValue(wowMemory,null);
  Console.WriteLine("OPEN="+memory.GetType().GetMethod("Open").Invoke(memory,new object[]{wow.Id}));
  Console.WriteLine("VALID="+memory.GetType().GetMethod("IsValidAndOpenProcess").Invoke(memory,null));
  Console.WriteLine("PID2="+memory.GetType().GetField("ProcessId").GetValue(memory));
  Console.WriteLine("HWND="+memory.GetType().GetField("WindowHandleInt32").GetValue(memory));
  Console.WriteLine("MODULE=0x"+((uint)memory.GetType().GetField("MainModuleAddress").GetValue(memory)).ToString("X"));
  Console.WriteLine("INGAME="+memType.GetMethod("IsInGame").Invoke(null,new object[]{wow.Id}));
  Console.WriteLine("PLAYER="+memType.GetMethod("PlayerName").Invoke(null,new object[]{wow.Id}));
  var om=Type.GetType("wManager.Wow.ObjectManager.ObjectManager, wManager");
  var refresh=om.GetMethod("\u0002",BindingFlags.Static|BindingFlags.NonPublic);
  if(refresh!=null) refresh.Invoke(null,null);
  var me=om.GetProperty("Me",BindingFlags.Public|BindingFlags.Static).GetValue(null,null);
  Console.WriteLine("ME_TYPE="+(me==null?"null":me.GetType().FullName));
  if(me!=null){
   foreach(var prop in new[]{"IsValid","Name","Level","HealthPercent","Position"}){
    var pi=me.GetType().GetProperty(prop,BindingFlags.Public|BindingFlags.Instance);
    if(pi!=null) { try{ Console.WriteLine("ME_"+prop+"="+pi.GetValue(me,null)); } catch(Exception ex){ Console.WriteLine("ME_"+prop+"_ERR="+ex.GetType().Name+":"+ex.Message); } }
   }
  }
 }
}
