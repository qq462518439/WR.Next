using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
class Probe
{
    static void Main()
    {
        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        Environment.SetEnvironmentVariable("WR_RUNTIME_ROOT", root);
        AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, ResolveEventArgs e)
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            string[] dirs = new string[] { root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") };
            foreach (var dir in dirs)
            {
                var p = Path.Combine(dir, name);
                if (File.Exists(p)) return Assembly.LoadFrom(p);
            }
            return null;
        };

        var wManagerAsm = Assembly.LoadFrom(Path.Combine(root, "wManager.dll"));
        var memStaticType = wManagerAsm.GetType("wManager.Wow.Memory", true);
        var wowMemoryField = memStaticType.GetField("WowMemory", BindingFlags.Static | BindingFlags.Public);
        var hook = wowMemoryField.GetValue(null);
        Dump("initial", hook);

        var memoryProp = hook.GetType().GetProperty("Memory", BindingFlags.Instance | BindingFlags.Public);
        var memObj = memoryProp.GetValue(hook, null);
        var wow = Process.GetProcessesByName("Wow").FirstOrDefault();
        if (wow == null)
        {
            Console.WriteLine("NO_WOW");
            return;
        }

        var open = memObj.GetType().GetMethod("Open", new Type[] { typeof(int) });
        var opened = (bool)open.Invoke(memObj, new object[] { wow.Id });
        Console.WriteLine("opened=" + opened + " pid=" + wow.Id);
        Dump("after-open", hook);

        var pulsatorType = wManagerAsm.GetType("wManager.Pulsator", true);
        pulsatorType.GetMethod("Pulse", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { wow.Id });
        Dump("after-pulse", hook);
    }

    static void Dump(string label, object hook)
    {
        var t = hook.GetType();
        var allocDataField = t.GetField("AllocData", BindingFlags.Instance | BindingFlags.Public);
        var allocTextField = t.GetField("AllocText", BindingFlags.Instance | BindingFlags.Public);
        var threadHookedField = t.GetField("ThreadHooked", BindingFlags.Instance | BindingFlags.Public);
        var allocData = allocDataField == null ? null : allocDataField.GetValue(hook);
        var allocText = allocTextField == null ? null : allocTextField.GetValue(hook);
        var memObj = t.GetProperty("Memory", BindingFlags.Instance | BindingFlags.Public).GetValue(hook, null);
        object asmObj = null;
        bool memoryOpen = false;
        if (memObj != null)
        {
            var isOpen = memObj.GetType().GetMethod("IsValidAndOpenProcess", Type.EmptyTypes);
            if (isOpen != null)
            {
                memoryOpen = (bool)isOpen.Invoke(memObj, null);
            }
            var asmProp = memObj.GetType().GetProperty("Asm", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (asmProp != null)
            {
                asmObj = asmProp.GetValue(memObj, null);
            }
        }

        var threadHooked = threadHookedField == null ? false : (bool)threadHookedField.GetValue(hook);
        Console.WriteLine(label
            + " allocData=" + (allocData == null ? "null" : allocData.GetType().FullName)
            + " allocText=" + (allocText == null ? "null" : allocText.GetType().FullName)
            + " asm=" + (asmObj == null ? "null" : asmObj.GetType().FullName)
            + " memOpen=" + memoryOpen
            + " threadHooked=" + threadHooked);
    }
}
