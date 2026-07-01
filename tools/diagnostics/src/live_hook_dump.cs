using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
class Probe
{
    static void Main()
    {
        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        Environment.SetEnvironmentVariable("WR_RUNTIME_ROOT", root);
        AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, ResolveEventArgs e)
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            foreach (var dir in new[] { root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") })
            {
                var p = Path.Combine(dir, name);
                if (File.Exists(p)) return Assembly.LoadFrom(p);
            }
            return null;
        };

        var wow = Process.GetProcessesByName("Wow").FirstOrDefault();
        if (wow == null) { Console.WriteLine("NO_WOW"); return; }

        var hostAsm = Assembly.LoadFrom(Path.Combine(root, "WR.OriginalUiHost.exe"));
        var bootstrapType = hostAsm.GetType("WR.OriginalUiHost.OriginalRuntimeBootstrap", true);
        var bootstrap = Activator.CreateInstance(bootstrapType, new object[] { root });
        var attach = bootstrapType.GetMethod("AttachToWowProcess");
        var result = attach.Invoke(bootstrap, new object[] { wow.Id });
        Console.WriteLine("ATTACH=" + result.GetType().GetProperty("Ok").GetValue(result, null));
        Thread.Sleep(1000);

        var wManagerAsm = Assembly.LoadFrom(Path.Combine(root, "wManager.dll"));
        var memType = wManagerAsm.GetType("wManager.Wow.Memory", true);
        var hook = memType.GetField("WowMemory", BindingFlags.Static | BindingFlags.Public).GetValue(null);
        var nodxType = wManagerAsm.GetTypes().First(t => t.GetFields(BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public).Any(f => f.FieldType == typeof(Thread)));
        DumpHook(hook);
        DumpNoDx(nodxType);
    }

    static void DumpHook(object hook)
    {
        var t = hook.GetType();
        Console.WriteLine("HOOK threadHooked=" + t.GetField("ThreadHooked", BindingFlags.Instance|BindingFlags.Public).GetValue(hook));
        foreach (var f in t.GetFields(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public).OrderBy(f => f.Name))
        {
            if (f.FieldType == typeof(uint) || f.FieldType == typeof(bool) || f.FieldType == typeof(int))
            {
                object v = null;
                try { v = f.GetValue(hook); } catch (Exception ex) { v = "<err:" + ex.GetType().Name + ">"; }
                Console.WriteLine("HOOKFIELD " + Esc(f.Name) + " type=" + f.FieldType.Name + " value=" + Esc(v == null ? "null" : v.ToString()));
            }
        }
    }

    static void DumpNoDx(Type nodxType)
    {
        foreach (var f in nodxType.GetFields(BindingFlags.Static|BindingFlags.NonPublic|BindingFlags.Public).OrderBy(f => f.Name))
        {
            object v = null;
            try { v = f.GetValue(null); } catch (Exception ex) { v = "<err:" + ex.GetType().Name + ">"; }
            var shown = v == null ? "null" : v.ToString();
            if (v is Thread)
            {
                var th = (Thread)v;
                shown = "IsAlive=" + th.IsAlive + ",State=" + th.ThreadState;
            }
            Console.WriteLine("NODXFIELD " + Esc(f.Name) + " type=" + f.FieldType.Name + " value=" + Esc(shown));
        }
    }

    static string Esc(string s)
    {
        if (s == null) return "null";
        return string.Concat(s.Select(ch => char.IsControl(ch) ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
