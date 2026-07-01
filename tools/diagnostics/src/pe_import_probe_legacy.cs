using System;
using System.Collections.Generic;
using System.IO;

class X
{
    static void Main()
    {
        var file = @"D:\666\work\WR.Next\artifacts\uihost-runtime-layout\Bin\MemoryRobot.dll";
        Console.WriteLine("FILE " + file);
        if (!File.Exists(file))
        {
            Console.WriteLine("MISSING");
            return;
        }

        var bytes = File.ReadAllBytes(file);
        int pe = BitConverter.ToInt32(bytes, 0x3C);
        ushort sections = BitConverter.ToUInt16(bytes, pe + 6);
        ushort optSize = BitConverter.ToUInt16(bytes, pe + 20);
        ushort optMagic = BitConverter.ToUInt16(bytes, pe + 24);
        int ddBase = optMagic == 0x20b ? (pe + 24 + 112) : (pe + 24 + 96);
        uint importRva = BitConverter.ToUInt32(bytes, ddBase + 8);
        uint importSize = BitConverter.ToUInt32(bytes, ddBase + 12);

        Console.WriteLine("IMPORT_RVA 0x" + importRva.ToString("X8"));
        Console.WriteLine("IMPORT_SIZE " + importSize);

        int importOff = RvaToOffset(bytes, pe, optSize, sections, importRva);
        Console.WriteLine("IMPORT_OFF " + importOff);
        if (importOff < 0)
            return;

        for (int i = 0; ; i++)
        {
            int desc = importOff + (20 * i);
            if (desc + 20 > bytes.Length)
                break;

            uint nameRva = BitConverter.ToUInt32(bytes, desc + 12);
            if (nameRva == 0)
                break;

            int nameOff = RvaToOffset(bytes, pe, optSize, sections, nameRva);
            string dllName = ReadAscii(bytes, nameOff);
            Console.WriteLine("IMPORT[" + i + "] " + dllName);
        }

        Console.WriteLine("ASCII_HINTS");
        foreach (var s in FindHints(bytes))
            Console.WriteLine("HINT " + s);
    }

    static int RvaToOffset(byte[] bytes, int pe, int optSize, int sections, uint rva)
    {
        int secBase = pe + 24 + optSize;
        for (int i = 0; i < sections; i++)
        {
            int off = secBase + (40 * i);
            uint virtSize = BitConverter.ToUInt32(bytes, off + 8);
            uint virtAddr = BitConverter.ToUInt32(bytes, off + 12);
            uint rawSize = BitConverter.ToUInt32(bytes, off + 16);
            uint rawPtr = BitConverter.ToUInt32(bytes, off + 20);
            uint span = virtSize > rawSize ? virtSize : rawSize;
            if (rva >= virtAddr && rva < virtAddr + span)
                return (int)(rawPtr + (rva - virtAddr));
        }
        return -1;
    }

    static string ReadAscii(byte[] bytes, int offset)
    {
        if (offset < 0 || offset >= bytes.Length)
            return "<bad-offset>";
        var chars = new List<char>();
        for (int i = offset; i < bytes.Length && bytes[i] != 0; i++)
            chars.Add((char)bytes[i]);
        return new string(chars.ToArray());
    }

    static IEnumerable<string> FindHints(byte[] bytes)
    {
        string ascii = "";
        for (int i = 0; i < bytes.Length; i++)
            ascii += (bytes[i] >= 32 && bytes[i] <= 126) ? (char)bytes[i] : '\0';

        string[] hints =
        {
            "Microsoft.VC",
            "MSVCR",
            "MSVCP",
            "KERNEL32",
            "USER32",
            "OLE32",
            "ucrtbase",
            "vcruntime",
            "api-ms-win"
        };

        foreach (var hint in hints)
        {
            if (ascii.IndexOf(hint, StringComparison.OrdinalIgnoreCase) >= 0)
                yield return hint;
        }
    }
}
