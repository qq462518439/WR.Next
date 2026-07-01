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
            var bridgeType = asm.GetType("\u0005\u2009\u2005", false) ??
                             asm.GetType("\u0005  ", true);
            var engineFactory = bridgeType.GetMethod("\u0006  ", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ??
                                bridgeType.GetMethod("_0006_2001_2005", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var streamFactory = bridgeType.GetMethod("\u0002  ", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) ??
                                bridgeType.GetMethod("_0002_2001_2005", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            var engine = engineFactory.Invoke(null, null);
            var stream = streamFactory.Invoke(null, null);

            var engineType = engine.GetType();
            Console.WriteLine("ENGINE=" + Escape(engineType.FullName));

            var decodeMethod = engineType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(m =>
                    m.Name == "\u0002" &&
                    m.ReturnType == typeof(long) &&
                    m.GetParameters().Length == 1 &&
                    m.GetParameters()[0].ParameterType == typeof(string));
            if (decodeMethod == null)
            {
                Console.WriteLine("DECODE_METHOD=null");
                return 2;
            }

            const string token = "'7+qKIsufP";
            var index = (long)decodeMethod.Invoke(engine, new object[] { token });
            Console.WriteLine("TOKEN=" + token);
            Console.WriteLine("INDEX=" + index);

            var hookAsm = asm.GetType("robotManager.MemoryClass.Hook", true);
            var stealthType = asm.GetType("robotManager.MemoryClass.StealthProtection", true);
            Console.WriteLine("HOOK_TYPE=" + Escape(hookAsm.FullName));
            Console.WriteLine("STEALTH_TYPE=" + Escape(stealthType.FullName));

            foreach (var ctor in stealthType.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                Console.WriteLine(
                    "STEALTH_CTOR PARAMS=" +
                    string.Join(
                        "|",
                        ctor.GetParameters().Select(parameter => Escape(parameter.ParameterType.FullName))));
            }

            var initProgramMethod = engineType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(m =>
                    m.Name == "\u0002" &&
                    m.ReturnType == typeof(void) &&
                    m.GetParameters().Length == 3 &&
                    m.GetParameters()[0].ParameterType == typeof(Stream) &&
                    m.GetParameters()[1].ParameterType == typeof(long) &&
                    m.GetParameters()[2].ParameterType == typeof(string));
            if (initProgramMethod != null)
            {
                initProgramMethod.Invoke(engine, new object[] { stream, 0L, token });
                Console.WriteLine("PROGRAM_INIT=ok");
            }
            else
            {
                Console.WriteLine("PROGRAM_INIT=missing");
            }

            var streamReaderField = engineType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType.FullName != null && f.FieldType.FullName.Contains("_0002_2004_2005"));
            if (streamReaderField != null)
            {
                var streamReader = streamReaderField.GetValue(engine);
                var readerBase = streamReader.GetType().GetMethod("\u0002", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                var readerObject = readerBase.Invoke(streamReader, null);
                var readIntMethod = readerObject.GetType().GetMethod("\u0005", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                if (readIntMethod != null)
                {
                    var firstKey = (int)readIntMethod.Invoke(readerObject, null);
                    Console.WriteLine("FIRST_KEY=" + firstKey);
                }
                else
                {
                    Console.WriteLine("FIRST_KEY_METHOD=missing");
                }
            }
            else
            {
                Console.WriteLine("STREAM_READER_FIELD=missing");
                foreach (var field in engineType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    object fieldValue = null;
                    string valueType = "null";
                    try
                    {
                        fieldValue = field.GetValue(engine);
                        valueType = fieldValue == null ? "null" : Escape(fieldValue.GetType().FullName);
                    }
                    catch (Exception ex)
                    {
                        valueType = "<error:" + ex.GetType().Name + ">";
                    }

                    Console.WriteLine(
                        "INSTANCE_FIELD " + Escape(field.Name) +
                        " FIELD_TYPE=" + Escape(field.FieldType.FullName) +
                        " VALUE_TYPE=" + valueType);

                    if (fieldValue != null && (field.Name == "\u0006 " || field.Name == "\u0006 "))
                    {
                        if (field.Name == "\u0006 ")
                        {
                            var readerStateGetter = fieldValue.GetType()
                                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                                .FirstOrDefault(method =>
                                    method.Name == "\u0002" &&
                                    method.GetParameters().Length == 0 &&
                                    method.ReturnType.FullName == "\u0005");
                            var candidateMethods = fieldValue.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly)
                                .Where(m => m.GetParameters().Length == 0)
                                .Where(m =>
                                    m.ReturnType == typeof(int) ||
                                    m.ReturnType == typeof(uint) ||
                                    m.ReturnType == typeof(bool) ||
                                    m.ReturnType == typeof(byte) ||
                                    m.ReturnType == typeof(char) ||
                                    m.ReturnType == typeof(string) ||
                                    m.ReturnType == typeof(byte[]))
                                .OrderBy(m => m.Name, StringComparer.Ordinal)
                                .ThenBy(m => m.ReturnType.FullName, StringComparer.Ordinal)
                                .ToArray();

                            Console.WriteLine(
                                "  CANDIDATE_METHODS " +
                                string.Join(
                                    " | ",
                                    candidateMethods.Select(method =>
                                        Escape(method.Name) + ":" + Escape(method.ReturnType.FullName))));

                            foreach (var numericMethod in candidateMethods)
                            {
                                try
                                {
                                    var beforePosition = CaptureReaderStreamPosition(fieldValue, readerStateGetter);
                                    var result = numericMethod.Invoke(fieldValue, null);
                                    var afterPosition = CaptureReaderStreamPosition(fieldValue, readerStateGetter);
                                    Console.WriteLine(
                                        "  PROBE_CALL " + Escape(field.Name) + "." + Escape(numericMethod.Name) +
                                        " RETURN=" + Escape(numericMethod.ReturnType.FullName) +
                                        " VALUE=" + DescribeValue(result) +
                                        " BEFORE=" + beforePosition +
                                        " AFTER=" + afterPosition);

                                    if (field.Name == "\u0006 " && result != null && result.GetType().FullName != null)
                                    {
                                        Console.WriteLine("    STATE_OBJECT TYPE=" + Escape(result.GetType().FullName));
                                        foreach (var stateField in result.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                                        {
                                            object stateValue = null;
                                            string stateValueType = "null";
                                            try
                                            {
                                                stateValue = stateField.GetValue(result);
                                                stateValueType = stateValue == null ? "null" : Escape(stateValue.GetType().FullName);
                                            }
                                            catch (Exception sex)
                                            {
                                                stateValueType = "<error:" + sex.GetType().Name + ">";
                                            }

                                            Console.WriteLine(
                                                "    STATE_FIELD " + Escape(stateField.Name) +
                                                " FIELD_TYPE=" + Escape(stateField.FieldType.FullName) +
                                                " VALUE_TYPE=" + stateValueType);
                                        }

                                        foreach (var stateMethod in result.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly)
                                                     .Where(m => m.GetParameters().Length == 0))
                                        {
                                            try
                                            {
                                                var stateResult = stateMethod.Invoke(result, null);
                                                Console.WriteLine(
                                                    "    STATE_CALL " + Escape(stateMethod.Name) +
                                                    " RETURN=" + Escape(stateMethod.ReturnType.FullName) +
                                                    " VALUE=" + DescribeValue(stateResult));

                                                if (stateResult != null && stateMethod.ReturnType.FullName == "System.IO.Stream")
                                                {
                                                    Console.WriteLine("      STREAM_OBJECT TYPE=" + Escape(stateResult.GetType().FullName));
                                                    var streamType = stateResult.GetType();
                                                    var positionProp = streamType.GetProperty("Position", BindingFlags.Instance | BindingFlags.Public);
                                                    var lengthProp = streamType.GetProperty("Length", BindingFlags.Instance | BindingFlags.Public);
                                                    var canSeekProp = streamType.GetProperty("CanSeek", BindingFlags.Instance | BindingFlags.Public);
                                                    if (positionProp != null && lengthProp != null && canSeekProp != null)
                                                    {
                                                        try
                                                        {
                                                            var canSeek = (bool)canSeekProp.GetValue(stateResult, null);
                                                            var position = (long)positionProp.GetValue(stateResult, null);
                                                            var length = (long)lengthProp.GetValue(stateResult, null);
                                                            Console.WriteLine("      STREAM_SNAPSHOT canSeek=" + canSeek + " position=" + position + " length=" + length);
                                                            if (canSeek && position >= 0 && length > 0)
                                                            {
                                                                var readMethod = streamType.GetMethod("Read", new[] { typeof(byte[]), typeof(int), typeof(int) });
                                                                if (readMethod != null)
                                                                {
                                                                    var start = Math.Max(0L, position - 16);
                                                                    var count = (int)Math.Min(48L, length - start);
                                                                    var buffer = new byte[count];
                                                                    positionProp.SetValue(stateResult, start, null);
                                                                    var readCount = (int)readMethod.Invoke(stateResult, new object[] { buffer, 0, count });
                                                                    positionProp.SetValue(stateResult, position, null);
                                                                    Console.WriteLine("      STREAM_BYTES start=" + start + " read=" + readCount + " hex=" + BitConverter.ToString(buffer, 0, readCount));
                                                                    if (readCount >= 20)
                                                                    {
                                                                        for (var i = 0; i <= Math.Min(readCount - 4, 20); i += 4)
                                                                        {
                                                                            var candidate = BitConverter.ToInt32(buffer, i);
                                                                            Console.WriteLine("      STREAM_INT offset=" + (start + i) + " value=" + candidate);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        catch (Exception streamEx)
                                                        {
                                                            Console.WriteLine("      STREAM_SNAPSHOT_ERROR=" + streamEx.GetType().Name + ":" + streamEx.Message);
                                                        }
                                                    }

                                                    foreach (var streamField in stateResult.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                                                    {
                                                        object streamValue = null;
                                                        string streamValueType = "null";
                                                        try
                                                        {
                                                            streamValue = streamField.GetValue(stateResult);
                                                            streamValueType = streamValue == null ? "null" : Escape(streamValue.GetType().FullName);
                                                        }
                                                        catch (Exception fex)
                                                        {
                                                            streamValueType = "<error:" + fex.GetType().Name + ">";
                                                        }

                                                        Console.WriteLine(
                                                            "      STREAM_FIELD " + Escape(streamField.Name) +
                                                            " FIELD_TYPE=" + Escape(streamField.FieldType.FullName) +
                                                            " VALUE_TYPE=" + streamValueType +
                                                            " VALUE=" + DescribeValue(streamValue));

                                                        if (streamField.Name == "\u0008" && streamValue != null)
                                                        {
                                                            DumpFields("        INNER_STREAM ", streamValue);
                                                        }
                                                    }

                                                    foreach (var streamMethod in stateResult.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly)
                                                                 .Where(m => m.GetParameters().Length == 0))
                                                    {
                                                        try
                                                        {
                                                            var streamResult = streamMethod.Invoke(stateResult, null);
                                                            Console.WriteLine(
                                                                "      STREAM_CALL " + Escape(streamMethod.Name) +
                                                                " RETURN=" + Escape(streamMethod.ReturnType.FullName) +
                                                                " VALUE=" + DescribeValue(streamResult));
                                                        }
                                                        catch (Exception fex)
                                                        {
                                                            var ftie = fex as TargetInvocationException;
                                                            var finner = ftie != null && ftie.InnerException != null ? ftie.InnerException : fex;
                                                            Console.WriteLine(
                                                                "      STREAM_CALL " + Escape(streamMethod.Name) +
                                                                " RETURN=" + Escape(streamMethod.ReturnType.FullName) +
                                                                " ERROR=" + finner.GetType().Name + ":" + finner.Message);
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception sex)
                                            {
                                                var stie = sex as TargetInvocationException;
                                                var sinner = stie != null && stie.InnerException != null ? stie.InnerException : sex;
                                                Console.WriteLine(
                                                    "    STATE_CALL " + Escape(stateMethod.Name) +
                                                    " RETURN=" + Escape(stateMethod.ReturnType.FullName) +
                                                    " ERROR=" + sinner.GetType().Name + ":" + sinner.Message);
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    var tie = ex as TargetInvocationException;
                                    var inner = tie != null && tie.InnerException != null ? tie.InnerException : ex;
                                    var afterPosition = CaptureReaderStreamPosition(fieldValue, readerStateGetter);
                                    Console.WriteLine(
                                        "  PROBE_CALL " + Escape(field.Name) + "." + Escape(numericMethod.Name) +
                                        " RETURN=" + Escape(numericMethod.ReturnType.FullName) +
                                        " ERROR=" + inner.GetType().Name + ":" + inner.Message +
                                        " AFTER=" + afterPosition);
                                }
                            }
                        }

                        foreach (var innerField in fieldValue.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                        {
                            object innerValue = null;
                            string innerValueType = "null";
                            try
                            {
                                innerValue = innerField.GetValue(fieldValue);
                                innerValueType = innerValue == null ? "null" : Escape(innerValue.GetType().FullName);
                            }
                            catch (Exception ex)
                            {
                                innerValueType = "<error:" + ex.GetType().Name + ">";
                            }

                            Console.WriteLine(
                                "  INNER_FIELD " + Escape(field.Name) + "." + Escape(innerField.Name) +
                                " FIELD_TYPE=" + Escape(innerField.FieldType.FullName) +
                                " VALUE_TYPE=" + innerValueType);
                        }

                        foreach (var innerMethod in fieldValue.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly))
                        {
                            try
                            {
                                Console.WriteLine(
                                    "  INNER_METHOD " + Escape(field.Name) + "." + Escape(innerMethod.Name) +
                                    " RETURN=" + Escape(innerMethod.ReturnType.FullName) +
                                    " PARAMS=" + innerMethod.GetParameters().Length);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }

            var initMethod = engineType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(m =>
                    (m.Name == "\u0002\u2004" || m.Name == "\u0002 ") &&
                    m.ReturnType == typeof(void) &&
                    m.GetParameters().Length == 0);
            if (initMethod != null)
            {
                initMethod.Invoke(engine, null);
                Console.WriteLine("INIT_TABLE=ok");
            }
            else
            {
                Console.WriteLine("INIT_TABLE=missing");
            }

            var mapField = engineType.GetField("m__0002\u2003", BindingFlags.Static | BindingFlags.NonPublic) ??
                           engineType.GetField("m__0002 ", BindingFlags.Static | BindingFlags.NonPublic) ??
                           engineType.GetField("\u0002\u2003", BindingFlags.Static | BindingFlags.NonPublic) ??
                           engineType.GetField("\u0002 ", BindingFlags.Static | BindingFlags.NonPublic);
            if (mapField == null)
            {
                Console.WriteLine("MAP_FIELD=null");
                foreach (var field in engineType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    object fieldValue = null;
                    string valueType = "null";
                    try
                    {
                        fieldValue = field.GetValue(null);
                        valueType = fieldValue == null ? "null" : Escape(fieldValue.GetType().FullName);
                    }
                    catch (Exception ex)
                    {
                        valueType = "<error:" + ex.GetType().Name + ">";
                    }

                    Console.WriteLine(
                        "STATIC_FIELD " + Escape(field.Name) +
                        " FIELD_TYPE=" + Escape(field.FieldType.FullName) +
                        " VALUE_TYPE=" + valueType);
                }
                return 3;
            }

            var map = mapField.GetValue(null);
            if (map == null)
            {
                Console.WriteLine("MAP=null");
                return 4;
            }

            var tryGetValue = map.GetType().GetMethod("TryGetValue");
            var args = new object[] { (int)index, null };
            var found = (bool)tryGetValue.Invoke(map, args);
            Console.WriteLine("FOUND=" + found);
            if (!found || args[1] == null)
            {
                return found ? 0 : 5;
            }

            var entry = args[1];
            var entryType = entry.GetType();
            Console.WriteLine("ENTRY_TYPE=" + Escape(entryType.FullName));

            foreach (var field in entryType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                object value = null;
                try
                {
                    value = field.GetValue(entry);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("FIELD " + Escape(field.Name) + "=<error:" + ex.GetType().Name + ">");
                    continue;
                }

                Console.WriteLine(
                    "FIELD " + Escape(field.Name) +
                    " TYPE=" + Escape(field.FieldType.FullName) +
                    " VALUE=" + Escape(DescribeValue(value)));
            }

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR=" + ex.GetType().FullName + ":" + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("INNER=" + ex.InnerException.GetType().FullName + ":" + ex.InnerException.Message);
            }
            return 1;
        }
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

        var type = value.GetType();
        if (type.IsPrimitive || value is string || value is decimal)
        {
            return Convert.ToString(value);
        }

        return type.FullName;
    }

    static string CaptureReaderStreamPosition(object reader, MethodInfo readerStateGetter)
    {
        try
        {
            if (reader == null || readerStateGetter == null)
            {
                return "unavailable";
            }

            var state = readerStateGetter.Invoke(reader, null);
            if (state == null)
            {
                return "state-null";
            }

            var streamGetter = state.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                .FirstOrDefault(method =>
                    method.Name == "\u0002" &&
                    method.GetParameters().Length == 0 &&
                    typeof(Stream).IsAssignableFrom(method.ReturnType));
            var stream = streamGetter == null ? null : streamGetter.Invoke(state, null) as Stream;
            if (stream == null)
            {
                return "stream-null";
            }

            return "pos=" + stream.Position + "/len=" + stream.Length;
        }
        catch (Exception ex)
        {
            var tie = ex as TargetInvocationException;
            var inner = tie != null && tie.InnerException != null ? tie.InnerException : ex;
            return "error=" + inner.GetType().Name + ":" + inner.Message;
        }
    }

    static void DumpFields(string prefix, object target)
    {
        var type = target.GetType();
        Console.WriteLine(prefix + "TYPE=" + Escape(type.FullName));
        foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
        {
            object value = null;
            string valueType = "null";
            try
            {
                value = field.GetValue(target);
                valueType = value == null ? "null" : Escape(value.GetType().FullName);
            }
            catch (Exception ex)
            {
                valueType = "<error:" + ex.GetType().Name + ">";
            }

            Console.WriteLine(
                prefix + Escape(field.Name) +
                " FIELD_TYPE=" + Escape(field.FieldType.FullName) +
                " VALUE_TYPE=" + valueType +
                " VALUE=" + DescribeValue(value));
        }
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
