using System;
using System.IO;
using System.Reflection;

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
        Console.WriteLine("PID " + pid);

        var root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        var bin = Path.Combine(root, "Bin");

        AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
        {
            var name = new AssemblyName(e.Name).Name + ".dll";
            string[] dirs = { bin, root, Path.Combine(root, "Products"), Path.Combine(root, "FightClass") };
            foreach (var dir in dirs)
            {
                var path = Path.Combine(dir, name);
                if (File.Exists(path))
                    return Assembly.LoadFrom(path);
            }
            return null;
        };

        try { Assembly.LoadFrom(Path.Combine(bin, "MemoryRobot.dll")); Console.WriteLine("LOAD MemoryRobot ok"); } catch (Exception ex) { Console.WriteLine("LOAD MemoryRobot " + F(ex)); }
        try { Assembly.LoadFrom(Path.Combine(bin, "robotManager.dll")); Console.WriteLine("LOAD robotManager ok"); } catch (Exception ex) { Console.WriteLine("LOAD robotManager " + F(ex)); }
        try { Assembly.LoadFrom(Path.Combine(bin, "wManager.dll")); Console.WriteLine("LOAD wManager ok"); } catch (Exception ex) { Console.WriteLine("LOAD wManager " + F(ex)); }

        try
        {
            var argsType = FindType("robotManager.Helpful.ArgsParser");
            var getArgs = argsType.GetProperty("GetArgs", BindingFlags.Public | BindingFlags.Static);
            var argsObj = getArgs.GetValue(null, null);
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

        try
        {
            var memType = FindType("wManager.Wow.Memory");
            var detour = memType.GetMethod("DetourAddress", BindingFlags.Public | BindingFlags.Static);
            var op = memType.GetMethod("OriginalOpCode", BindingFlags.Public | BindingFlags.Static);
            var inGame = memType.GetMethod("IsInGame", BindingFlags.Public | BindingFlags.Static);
            var player = memType.GetMethod("PlayerName", BindingFlags.Public | BindingFlags.Static);

            Console.WriteLine("STEP before IsInGame");
            Console.WriteLine("ISINGAME " + inGame.Invoke(null, new object[] { pid }));
            Console.WriteLine("STEP before PlayerName");
            Console.WriteLine("PLAYER " + player.Invoke(null, new object[] { pid }));
            Console.WriteLine("STEP before DetourAddress");
            Console.WriteLine("DETOUR_BEFORE 0x" + ((uint)detour.Invoke(null, new object[] { pid })).ToString("X"));
            Console.WriteLine("STEP before OriginalOpCode");
            var opBytes = (byte[])op.Invoke(null, new object[] { pid });
            Console.WriteLine("OP_BEFORE_LEN " + (opBytes == null ? -1 : opBytes.Length));
        }
        catch (Exception ex)
        {
            Console.WriteLine("MEM_BEFORE " + F(ex));
        }

        try
        {
            var pulsator = FindType("wManager.Pulsator");
            var pulse = pulsator.GetMethod("Pulse", BindingFlags.Public | BindingFlags.Static);
            Console.WriteLine("STEP before Pulse");
            pulse.Invoke(null, new object[] { pid });
            Console.WriteLine("PULSE ok");
        }
        catch (Exception ex)
        {
            Console.WriteLine("PULSE " + F(ex));
        }

        try
        {
            var memType = FindType("wManager.Wow.Memory");
            var detour = memType.GetMethod("DetourAddress", BindingFlags.Public | BindingFlags.Static);
            var op = memType.GetMethod("OriginalOpCode", BindingFlags.Public | BindingFlags.Static);
            Console.WriteLine("STEP after DetourAddress");
            Console.WriteLine("DETOUR_AFTER 0x" + ((uint)detour.Invoke(null, new object[] { pid })).ToString("X"));
            Console.WriteLine("STEP after OriginalOpCode");
            var opBytes = (byte[])op.Invoke(null, new object[] { pid });
            Console.WriteLine("OP_AFTER_LEN " + (opBytes == null ? -1 : opBytes.Length));

            var hookType = FindType("wManager.Wow.Memory");
            var wowMemoryField = hookType.GetField("WowMemory", BindingFlags.Public | BindingFlags.Static);
            var hook = wowMemoryField.GetValue(null);
            if (hook != null)
            {
                var hookT = hook.GetType();
                var th = hookT.GetProperty("ThreadHooked", BindingFlags.Public | BindingFlags.Instance);
                var rc = hookT.GetProperty("RetnToHookCode", BindingFlags.Public | BindingFlags.Instance);
                var di = hookT.GetMethod("DetourInUse", BindingFlags.Public | BindingFlags.Instance);
                Console.WriteLine("HOOK_THREAD " + th.GetValue(hook, null));
                Console.WriteLine("HOOK_RETN " + rc.GetValue(hook, null));
                Console.WriteLine("HOOK_DETOUR_IN_USE " + di.Invoke(hook, null));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("MEM_AFTER " + F(ex));
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
