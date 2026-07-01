using System;
using System.IO;

class X
{
    static void Main()
    {
        string[] files =
        {
            @"C:\Windows\System32\MSVCR100.dll",
            @"C:\Windows\System32\MSVCP100.dll",
            @"C:\Windows\SysWOW64\MSVCR100.dll",
            @"C:\Windows\SysWOW64\MSVCP100.dll"
        };

        foreach (var file in files)
        {
            Console.WriteLine("FILE " + file);
            if (!File.Exists(file))
            {
                Console.WriteLine("  MISSING");
                continue;
            }

            try
            {
                var bytes = File.ReadAllBytes(file);
                int pe = BitConverter.ToInt32(bytes, 0x3C);
                ushort machine = BitConverter.ToUInt16(bytes, pe + 4);
                ushort optMagic = BitConverter.ToUInt16(bytes, pe + 24);
                var ver = FileVersionInfoShim(file);
                Console.WriteLine("  VERSION " + ver);
                Console.WriteLine("  MACHINE 0x" + machine.ToString("X4"));
                Console.WriteLine("  OPTMAGIC 0x" + optMagic.ToString("X"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("  ERROR " + ex.GetType().FullName + ":" + ex.Message);
            }
        }
    }

    static string FileVersionInfoShim(string path)
    {
        try
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(path).FileVersion;
        }
        catch (Exception ex)
        {
            return ex.GetType().Name + ":" + ex.Message;
        }
    }
}
