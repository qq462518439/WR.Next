using System;
using System.IO;

class X
{
    static void Main()
    {
        string[] files =
        {
            @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\WR.OriginalUiHost.exe",
            @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin\MemoryRobot.dll",
            @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin\robotManager.dll",
            @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin\wManager.dll",
            @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin\RDManaged.dll",
            @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin\fasmdll_managed.dll"
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
                var asmName = "<load-fail>";
                var procArch = "<unknown>";
                try
                {
                    var an = System.Reflection.AssemblyName.GetAssemblyName(file);
                    asmName = an.FullName;
                    procArch = an.ProcessorArchitecture.ToString();
                }
                catch (Exception ex)
                {
                    asmName = ex.GetType().Name + ":" + ex.Message;
                }

                var bytes = File.ReadAllBytes(file);
                int peOffset = BitConverter.ToInt32(bytes, 0x3C);
                ushort machine = BitConverter.ToUInt16(bytes, peOffset + 4);
                ushort sections = BitConverter.ToUInt16(bytes, peOffset + 6);
                ushort optSize = BitConverter.ToUInt16(bytes, peOffset + 20);
                ushort optMagic = BitConverter.ToUInt16(bytes, peOffset + 24);
                ushort chars = BitConverter.ToUInt16(bytes, peOffset + 22);

                int dataDirOffset = optMagic == 0x20b ? (peOffset + 24 + 112) : (peOffset + 24 + 96);
                int cliDirOffset = dataDirOffset + (14 * 8);
                uint cliRva = BitConverter.ToUInt32(bytes, cliDirOffset);
                uint cliSize = BitConverter.ToUInt32(bytes, cliDirOffset + 4);
                string corFlags = "<none>";

                if (cliRva != 0 && cliSize >= 20)
                {
                    int secBase = peOffset + 24 + optSize;
                    int cliFileOffset = -1;
                    for (int i = 0; i < sections; i++)
                    {
                        int off = secBase + (40 * i);
                        uint virtSize = BitConverter.ToUInt32(bytes, off + 8);
                        uint virtAddr = BitConverter.ToUInt32(bytes, off + 12);
                        uint rawSize = BitConverter.ToUInt32(bytes, off + 16);
                        uint rawPtr = BitConverter.ToUInt32(bytes, off + 20);
                        uint span = virtSize > rawSize ? virtSize : rawSize;
                        if (cliRva >= virtAddr && cliRva < virtAddr + span)
                        {
                            cliFileOffset = (int)(rawPtr + (cliRva - virtAddr));
                            break;
                        }
                    }

                    if (cliFileOffset >= 0 && cliFileOffset + 20 <= bytes.Length)
                    {
                        uint flags = BitConverter.ToUInt32(bytes, cliFileOffset + 16);
                        corFlags = "0x" + flags.ToString("X8");
                    }
                    else
                    {
                        corFlags = "<cli-map-fail>";
                    }
                }

                Console.WriteLine("  ASM " + asmName);
                Console.WriteLine("  PROC " + procArch);
                Console.WriteLine("  MACHINE 0x" + machine.ToString("X4"));
                Console.WriteLine("  OPTMAGIC 0x" + optMagic.ToString("X"));
                Console.WriteLine("  CHAR 0x" + chars.ToString("X4"));
                Console.WriteLine("  CLI_RVA 0x" + cliRva.ToString("X8"));
                Console.WriteLine("  CLI_SIZE " + cliSize);
                Console.WriteLine("  CORFLAGS " + corFlags);
            }
            catch (Exception ex)
            {
                Console.WriteLine("  ERROR " + ex.GetType().FullName + ":" + ex.Message);
            }
        }
    }
}
