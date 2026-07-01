using System;
using System.IO;
using System.Linq;
using System.Reflection;

class Probe
{
    static int Main()
    {
        const string root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        AppDomain.CurrentDomain.AssemblyResolve += ResolveFromRoot;

        try
        {
            var asm = Assembly.LoadFrom(Path.Combine(root, "robotManager.dll"));
            var bridgeType = asm.GetType("\u0005\u2009\u2005", false) ?? asm.GetType("\u0005  ", true);
            var engineFactory = bridgeType.GetMethod("\u0006  ", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                                ?? bridgeType.GetMethod("_0006_2001_2005", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var streamFactory = bridgeType.GetMethod("\u0002  ", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                                ?? bridgeType.GetMethod("_0002_2001_2005", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var token in new[] { "dX$1`Isuet", "_g6TQIsuf!" })
            {
                ProbeToken(asm, engineFactory, streamFactory, token);
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR=" + ex.GetType().FullName + ":" + ex.Message);
            return 1;
        }
    }

    static void ProbeToken(Assembly asm, MethodInfo engineFactory, MethodInfo streamFactory, string token)
    {
        var engine = engineFactory.Invoke(null, null);
        var stream = streamFactory.Invoke(null, null);
        var engineType = engine.GetType();

        Console.WriteLine("TOKEN=" + token);
        Console.WriteLine("ENGINE=" + Escape(engineType.FullName));

        var decodeMethod = engineType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(m => m.Name == "\u0002" &&
                                 m.ReturnType == typeof(long) &&
                                 m.GetParameters().Length == 1 &&
                                 m.GetParameters()[0].ParameterType == typeof(string));
        if (decodeMethod == null)
        {
            Console.WriteLine("DECODE_METHOD=null");
            return;
        }

        var index = (long)decodeMethod.Invoke(engine, new object[] { token });
        Console.WriteLine("INDEX=" + index);

        var initProgramMethod = engineType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(m =>
                m.Name == "\u0002" &&
                m.ReturnType == typeof(void) &&
                m.GetParameters().Length == 3 &&
                m.GetParameters()[0].ParameterType == typeof(Stream) &&
                m.GetParameters()[1].ParameterType == typeof(long) &&
                m.GetParameters()[2].ParameterType == typeof(string));
        if (initProgramMethod == null)
        {
            Console.WriteLine("PROGRAM_INIT=missing");
            return;
        }

        initProgramMethod.Invoke(engine, new object[] { stream, 0L, token });
        Console.WriteLine("PROGRAM_INIT=ok");

        var readerField = engineType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .FirstOrDefault(f => f.Name == "\u0006 ");
        if (readerField == null)
        {
            Console.WriteLine("READER_FIELD=missing");
            return;
        }

        var reader = readerField.GetValue(engine);
        var readerStateGetter = reader.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
            .FirstOrDefault(method => method.Name == "\u0002" && method.GetParameters().Length == 0 && method.ReturnType.FullName == "\u0005");

        DumpCall(reader, readerStateGetter, "\u0002", typeof(bool));
        DumpCall(reader, readerStateGetter, "\u0002", typeof(byte));
        DumpCall(reader, readerStateGetter, "\u0002", typeof(char));
        DumpCall(reader, readerStateGetter, "\u0002", typeof(string));
        DumpCall(reader, readerStateGetter, "\u0002", typeof(uint));
        DumpCall(reader, readerStateGetter, "\u0005", typeof(int));
        DumpCall(reader, readerStateGetter, "\u0006", typeof(int));
        DumpCall(reader, readerStateGetter, "\u0008", typeof(int));
        DumpCall(reader, readerStateGetter, "\u000F", typeof(int));

        if (token == "dX$1`Isuet")
        {
            Console.WriteLine("SEQUENCE=install-int");
            DumpSequence(reader, readerStateGetter, "\u0005", typeof(int), 6);
            Console.WriteLine("SEQUENCE=install-string");
            DumpSequence(reader, readerStateGetter, "\u0002", typeof(string), 4);
        }
    }

    static void DumpCall(object reader, MethodInfo readerStateGetter, string name, Type returnType)
    {
        var method = reader.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
            .FirstOrDefault(m => m.Name == name && m.GetParameters().Length == 0 && m.ReturnType == returnType);
        if (method == null)
        {
            Console.WriteLine("CALL " + Escape(name) + " RETURN=" + Escape(returnType.FullName) + " MISSING");
            return;
        }

        try
        {
            var before = CaptureReaderStreamPosition(reader, readerStateGetter);
            var value = method.Invoke(reader, null);
            var after = CaptureReaderStreamPosition(reader, readerStateGetter);
            Console.WriteLine("CALL " + Escape(name) + " RETURN=" + Escape(returnType.FullName) + " VALUE=" + DescribeValue(value) + " BEFORE=" + before + " AFTER=" + after);
        }
        catch (Exception ex)
        {
            var tie = ex as TargetInvocationException;
            var inner = tie != null && tie.InnerException != null ? tie.InnerException : ex;
            var after = CaptureReaderStreamPosition(reader, readerStateGetter);
            Console.WriteLine("CALL " + Escape(name) + " RETURN=" + Escape(returnType.FullName) + " ERROR=" + inner.GetType().Name + ":" + inner.Message + " AFTER=" + after);
        }
    }

    static void DumpSequence(object reader, MethodInfo readerStateGetter, string name, Type returnType, int count)
    {
        var method = reader.GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
            .FirstOrDefault(m => m.Name == name && m.GetParameters().Length == 0 && m.ReturnType == returnType);
        if (method == null)
        {
            Console.WriteLine("SEQ " + Escape(name) + " RETURN=" + Escape(returnType.FullName) + " MISSING");
            return;
        }

        for (var i = 0; i < count; i++)
        {
            try
            {
                var before = CaptureReaderStreamPosition(reader, readerStateGetter);
                var value = method.Invoke(reader, null);
                var after = CaptureReaderStreamPosition(reader, readerStateGetter);
                Console.WriteLine("SEQ " + Escape(name) + " RETURN=" + Escape(returnType.FullName) + " STEP=" + i + " VALUE=" + DescribeValue(value) + " BEFORE=" + before + " AFTER=" + after);
            }
            catch (Exception ex)
            {
                var tie = ex as TargetInvocationException;
                var inner = tie != null && tie.InnerException != null ? tie.InnerException : ex;
                var after = CaptureReaderStreamPosition(reader, readerStateGetter);
                Console.WriteLine("SEQ " + Escape(name) + " RETURN=" + Escape(returnType.FullName) + " STEP=" + i + " ERROR=" + inner.GetType().Name + ":" + inner.Message + " AFTER=" + after);
                break;
            }
        }
    }

    static string CaptureReaderStreamPosition(object reader, MethodInfo readerStateGetter)
    {
        try
        {
            if (readerStateGetter == null)
            {
                return "state-getter-null";
            }

            var state = readerStateGetter.Invoke(reader, null);
            if (state == null)
            {
                return "state-null";
            }

            var positionProp = state.GetType().GetProperty("Position", BindingFlags.Instance | BindingFlags.Public);
            var lengthProp = state.GetType().GetProperty("Length", BindingFlags.Instance | BindingFlags.Public);
            if (positionProp != null && lengthProp != null)
            {
                return "pos=" + positionProp.GetValue(state, null) + "/len=" + lengthProp.GetValue(state, null);
            }
        }
        catch (Exception ex)
        {
            return "state-error:" + ex.GetType().Name;
        }

        return "state-unknown";
    }

    static Assembly ResolveFromRoot(object sender, ResolveEventArgs args)
    {
        const string root = @"D:\666\work\WR.Next\src\WR.OriginalUiHost\bin\Debug\net48";
        var name = new AssemblyName(args.Name).Name + ".dll";
        var path = Path.Combine(root, name);
        return File.Exists(path) ? Assembly.LoadFrom(path) : null;
    }

    static string DescribeValue(object value)
    {
        if (value == null)
        {
            return "null";
        }

        var stringValue = value as string;
        if (stringValue != null)
        {
            return Escape(stringValue);
        }

        if (value is char)
        {
            return Escape(((char)value).ToString());
        }

        return value.ToString();
    }

    static string Escape(string value)
    {
        if (value == null)
        {
            return "null";
        }

        return string.Concat(value.Select(ch => char.IsControl(ch) ? "\\u" + ((int)ch).ToString("X4") : ch.ToString()));
    }
}
