using System;
using System.IO;
using System.Linq;
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
        if (args.Length < 2)
        {
            Console.WriteLine("USAGE <pid> <mode> [root]");
            return;
        }

        int pid;
        if (!int.TryParse(args[0], out pid))
        {
            Console.WriteLine("BAD_PID");
            return;
        }

        var mode = args[1];
        var root = args.Length > 2 ? args[2] : @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        Console.WriteLine("PID " + pid);
        Console.WriteLine("MODE " + mode);
        Console.WriteLine("ROOT " + root);
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

        Assembly.LoadFrom(Path.Combine(bin, "MemoryRobot.dll"));
        Assembly.LoadFrom(Path.Combine(bin, "robotManager.dll"));
        Assembly.LoadFrom(Path.Combine(bin, "wManager.dll"));

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

        try
        {
            var memType = FindType("wManager.Wow.Memory");
            if (mode == "isingame")
            {
                var m = memType.GetMethod("IsInGame", BindingFlags.Public | BindingFlags.Static);
                Console.WriteLine("RESULT " + m.Invoke(null, new object[] { pid }));
                return;
            }

            if (mode == "playername")
            {
                var m = memType.GetMethod("PlayerName", BindingFlags.Public | BindingFlags.Static);
                Console.WriteLine("RESULT " + m.Invoke(null, new object[] { pid }));
                return;
            }

            if (mode == "detour")
            {
                var m = memType.GetMethod("DetourAddress", BindingFlags.Public | BindingFlags.Static);
                Console.WriteLine("RESULT 0x" + ((uint)m.Invoke(null, new object[] { pid })).ToString("X"));
                return;
            }

            if (mode == "opcode")
            {
                var m = memType.GetMethod("OriginalOpCode", BindingFlags.Public | BindingFlags.Static);
                var bytes = (byte[])m.Invoke(null, new object[] { pid });
                Console.WriteLine("RESULT_LEN " + (bytes == null ? -1 : bytes.Length));
                return;
            }

            if (mode == "pulse")
            {
                var pulsator = FindType("wManager.Pulsator");
                var m = pulsator.GetMethod("Pulse", BindingFlags.Public | BindingFlags.Static);
                m.Invoke(null, new object[] { pid });
                Console.WriteLine("RESULT pulse-ok");
                return;
            }

            Console.WriteLine("BAD_MODE");
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR " + F(ex));
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
