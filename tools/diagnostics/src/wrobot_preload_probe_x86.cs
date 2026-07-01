using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

class X
{
    static string F(Exception ex)
    {
        if (ex == null) return "null";
        var parts = new System.Collections.Generic.List<string>();
        var cur = ex;
        while (cur != null)
        {
            parts.Add(cur.GetType().FullName + ":" + cur.Message);
            cur = cur.InnerException;
        }
        return string.Join(" => ", parts.ToArray());
    }

    static void Main(string[] args)
    {
        int pid = 0;
        if (args.Length > 0) int.TryParse(args[0], out pid);
        bool preloadWRobot = args.Length > 1 && string.Equals(args[1], "preload-wrobot", StringComparison.OrdinalIgnoreCase);
        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        var bin = Path.Combine(root, "Bin");
        Console.WriteLine("PID " + pid);
        Console.WriteLine("PRELOAD_WROBOT " + preloadWRobot);

        AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
        {
            try
            {
                var name = new AssemblyName(e.Name).Name + ".dll";
                string[] dirs = { bin, root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") };
                foreach (var dir in dirs)
                {
                    var path = Path.Combine(dir, name);
                    if (File.Exists(path))
                        return Assembly.LoadFrom(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("RESOLVE_ERR " + F(ex));
            }
            return null;
        };

        TryLoad(Path.Combine(bin, "MemoryRobot.dll"), "MemoryRobot");
        TryLoad(Path.Combine(bin, "robotManager.dll"), "robotManager");
        TryLoad(Path.Combine(bin, "wManager.dll"), "wManager");
        if (preloadWRobot)
            TryLoad(Path.Combine(root, "WRobot.exe"), "WRobot");

        try
        {
            var argsType = FindType("robotManager.Helpful.ArgsParser");
            var getArgsField = argsType.GetField("GetArgs", BindingFlags.Public | BindingFlags.Static);
            var argsObj = getArgsField.GetValue(null);
            SetMember(argsObj, "ProcessId", pid);
            SetMember(argsObj, "Product", "WRotation");
            SetMember(argsObj, "NoDx", true);
            SetMember(argsObj, "Dx", false);
            SetMember(argsObj, "NoLockFrame", true);
            SetMember(argsObj, "LockFrame", false);
            SetMember(argsObj, "LogInject", true);
            SetMember(argsObj, "BPHOOK", true);
            Console.WriteLine("ARGS ok");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ARGS " + F(ex));
        }

        Snapshot("BEFORE", pid);
        try
        {
            var pulsator = FindType("wManager.Pulsator");
            var pulse = pulsator.GetMethod("Pulse", BindingFlags.Public | BindingFlags.Static);
            pulse.Invoke(null, new object[] { pid });
            Console.WriteLine("PULSE ok");
        }
        catch (Exception ex)
        {
            Console.WriteLine("PULSE " + F(ex));
        }
        Thread.Sleep(1500);
        Snapshot("AFTER", pid);
    }

    static void Snapshot(string label, int pid)
    {
        try
        {
            var memType = FindType("wManager.Wow.Memory");
            var detour = memType.GetMethod("DetourAddress", BindingFlags.Public | BindingFlags.Static);
            var op = memType.GetMethod("OriginalOpCode", BindingFlags.Public | BindingFlags.Static);
            var wowMemoryField = memType.GetField("WowMemory", BindingFlags.Public | BindingFlags.Static);
            var hook = wowMemoryField.GetValue(null);
            var hookT = hook.GetType();
            var threadHookedField = hookT.GetField("ThreadHooked", BindingFlags.Public | BindingFlags.Instance);
            var retnField = hookT.GetField("RetnToHookCode", BindingFlags.Public | BindingFlags.Instance);
            var detourInUse = hookT.GetMethod("DetourInUse", BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(label + " DETOUR 0x" + ((uint)detour.Invoke(null, new object[] { pid })).ToString("X"));
            var opBytes = (byte[])op.Invoke(null, new object[] { pid });
            Console.WriteLine(label + " OPCODE_LEN " + (opBytes == null ? -1 : opBytes.Length));
            Console.WriteLine(label + " THREAD_HOOKED " + threadHookedField.GetValue(hook));
            Console.WriteLine(label + " RETN " + retnField.GetValue(hook));
            Console.WriteLine(label + " DETOUR_IN_USE " + detourInUse.Invoke(hook, null));

            var wAsm = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => string.Equals(a.GetName().Name, "wManager", StringComparison.OrdinalIgnoreCase));
            Type[] types;
            try { types = wAsm.GetTypes(); }
            catch (ReflectionTypeLoadException ex) { types = ex.Types.Where(t => t != null).ToArray(); }
            var nodx = types.FirstOrDefault(t =>
            {
                try
                {
                    var fs = t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                    return fs.Any(f => typeof(Thread).IsAssignableFrom(f.FieldType)) && fs.Count(f => f.FieldType == typeof(uint)) >= 4 && fs.Any(f => f.FieldType == typeof(object));
                }
                catch { return false; }
            });
            if (nodx == null)
            {
                Console.WriteLine(label + " NODX null");
                return;
            }
            var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            var fs2 = nodx.GetFields(flags);
            var thread = fs2.FirstOrDefault(f => typeof(Thread).IsAssignableFrom(f.FieldType));
            var uints = fs2.Where(f => f.FieldType == typeof(uint)).ToArray();
            Console.WriteLine(label + " NODX_TYPE " + nodx.FullName);
            Console.WriteLine(label + " NODX_THREAD_NULL " + (thread.GetValue(null) == null));
            var th = thread.GetValue(null) as Thread;
            Console.WriteLine(label + " NODX_THREAD_ALIVE " + (th == null ? "null" : th.IsAlive.ToString()));
            Console.WriteLine(label + " NODX_UINTS " + string.Join(",", uints.Select(f => f.Name + "=0x" + Convert.ToUInt32(f.GetValue(null)).ToString("X")).ToArray()));
        }
        catch (Exception ex)
        {
            Console.WriteLine(label + " SNAPSHOT_ERR " + F(ex));
        }
    }

    static Assembly TryLoad(string path, string label)
    {
        try
        {
            var asm = Assembly.LoadFrom(path);
            Console.WriteLine("LOAD " + label + " ok :: " + asm.FullName);
            return asm;
        }
        catch (Exception ex)
        {
            Console.WriteLine("LOAD " + label + " " + F(ex));
            return null;
        }
    }

    static Type FindType(string fullName)
    {
        foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
        {
            var t = a.GetType(fullName, false);
            if (t != null) return t;
        }
        throw new InvalidOperationException("Type not found: " + fullName);
    }

    static void SetMember(object obj, string name, object value)
    {
        var t = obj.GetType();
        var p = t.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (p != null && p.CanWrite) { p.SetValue(obj, value, null); return; }
        var f = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (f != null) { f.SetValue(obj, value); return; }
        throw new InvalidOperationException("Member not found: " + name);
    }
}
