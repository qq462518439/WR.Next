using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal sealed class _0002_0010 : global::_0006
{
	private new enum _0002
	{
		Value
	}

	private new Enum m__0002;

	public _0002_0010()
	{
		_ = 3;
		if (8 == 0)
		{
		}
		base._002Ector(19);
	}

	public _0002_0010(Enum _0002)
		: this()
	{
		object obj = _0002 ?? ((object)global::_0002_0010._0002.Value);
		if (4u != 0)
		{
			this.m__0002 = (Enum)obj;
		}
	}

	public new Enum _0002()
	{
		_ = 7;
		if (false)
		{
		}
		return this.m__0002;
	}

	public void _0002(Enum _0002)
	{
		if (_0002 == null)
		{
			throw new ArgumentException();
		}
		if (5u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 8;
		if (4 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		Enum obj = (Enum)Enum.Parse(this._0002().GetType(), _0002.ToString());
		if (7u != 0)
		{
			this._0002(obj);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (true)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 19:
		{
			Type type2 = this.m__0002.GetType();
			Type type3 = default(Type);
			if (0 == 0)
			{
				type3 = type2;
			}
			Enum obj = ((global::_0002_0010)_0002)._0002();
			Enum obj2;
			if (3u != 0)
			{
				obj2 = obj;
			}
			if (obj2.GetType() == type3)
			{
				this._0002(obj2);
			}
			else
			{
				this._0002((Enum)Enum.ToObject(type3, obj2));
			}
			break;
		}
		case 26:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_000E_2009)_0002)._0002()));
			break;
		case 1:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_000F)_0002)._0002()));
			break;
		case 13:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_0003_2000)_0002)._0002()));
			break;
		case 16:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_0005_2007)_0002)._0002()));
			break;
		case 3:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_000F_2001)_0002)._0002()));
			break;
		case 14:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_000E_2006)_0002)._0002()));
			break;
		case 17:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_0003_2001)_0002)._0002()));
			break;
		case 12:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_0008_2004_2005)_0002)._0002()));
			break;
		case 7:
			this._0002((Enum)Enum.ToObject(this.m__0002.GetType(), ((global::_0005_2003)_0002)._0002()));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		_ = 0;
		if (7 == 0)
		{
		}
		global::_0002_0010 obj = new global::_0002_0010(this.m__0002);
		_ = -1;
		if (6 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}
}
internal abstract class _0002_200B : global::_0002_2004
{
	private new Type m__0002;

	public _0002_200B(int _0002)
	{
		_ = 0;
		if (6 == 0)
		{
		}
		_ = 3;
		if (1 == 0)
		{
		}
		base._002Ector(_0002);
	}

	public new Type _0002()
	{
		_ = 0;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public new void _0002(Type _0002)
	{
		if (uint.MaxValue != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public abstract object _0002_200B_2008_2009_0002();

	public abstract void _0002_200B_2008_2009_0002(object _0002);

	public abstract bool _0002_200B_2008_2009_0002(global::_0002_200B _0002);
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
[global::_0006_2006]
internal sealed class _0003_200B : Attribute
{
	public readonly byte _0002;

	public _0003_200B(byte _0002)
	{
		if (8u != 0)
		{
			this._0002 = _0002;
		}
	}
}
internal sealed class _0005_200B
{
	private object m__0002;

	private Dictionary<global::_0006_2004_2005, global::_000F_200A> _0008;

	public _0005_200B()
	{
		object obj = new object();
		if (0 == 0)
		{
			this.m__0002 = obj;
		}
		base._002Ector();
	}

	internal global::_000F_200A _0002(global::_0006_2004_2005 _0002)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		object obj = this.m__0002;
		object obj2 = default(object);
		if (0 == 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (6u != 0)
		{
			lockTaken = false;
		}
		try
		{
			object obj3 = obj2;
			if (8u != 0)
			{
				Monitor.Enter(obj3, ref lockTaken);
			}
			if (_0008 == null)
			{
				_0008 = new Dictionary<global::_0006_2004_2005, global::_000F_200A>();
			}
			if (!_0008.TryGetValue(_0002, out var value))
			{
				value = new global::_000F_200A(_0002);
				_0008[_0002] = value;
			}
			return value;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}
}
internal sealed class _0006_200B
{
	private readonly global::_0008_2006 m__0002;

	private readonly int _0008;

	private readonly int _0006;

	private global::_0008_2006 _000F;

	private global::_0008_2006 _0005;

	private readonly byte[] _0003;

	private readonly byte[] _000E;

	public _0006_200B()
	{
		global::_0008_2006 obj = new global::_0008_2006();
		if (6u != 0)
		{
			this.m__0002 = obj;
		}
		base._002Ector();
		int num = this.m__0002._0008();
		if (3u != 0)
		{
			_0008 = num;
		}
		int num2 = this.m__0002._0002();
		if (0 == 0)
		{
			_0006 = num2;
		}
		_0003 = new byte[_0006];
		_000E = new byte[_0006 + _0008];
	}

	public void _0002(byte[] _0002)
	{
		this.m__0002._0008();
		int num = _0002.Length;
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		if (num2 > _0006)
		{
			this.m__0002._0002(_0002, 0, num2);
			this.m__0002._0002(_0003, 0);
			int num3 = _0008;
			if (0 == 0)
			{
				num2 = num3;
			}
		}
		else
		{
			byte[] destinationArray = _0003;
			int length = num2;
			if (5u != 0)
			{
				Array.Copy(_0002, 0, destinationArray, 0, length);
			}
		}
		Array.Clear(_0003, num2, _0006 - num2);
		Array.Copy(_0003, 0, _000E, 0, _0006);
		global::_0006_200B._0002(_0003, _0006, (byte)54);
		global::_0006_200B._0002(_000E, _0006, (byte)92);
		_0005 = this.m__0002._0002();
		_0005._0002(_000E, 0, _0006);
		this.m__0002._0002(_0003, 0, _0003.Length);
		_000F = this.m__0002._0002();
	}

	public int _0002()
	{
		_ = 8;
		if (2 == 0)
		{
		}
		return _0008;
	}

	public void _0002(byte[] _0002, int _0008, int _0006)
	{
		_ = 2;
		if (-1 == 0)
		{
		}
		global::_0008_2006 obj = this.m__0002;
		_ = 7;
		if (8 == 0)
		{
		}
		_ = 3;
		if (4 == 0)
		{
		}
		obj._0002(_0002, _0008, _0006);
	}

	public int _0002(byte[] _0002, int _0008)
	{
		this.m__0002._0002(_000E, _0006);
		this.m__0002._0008(_0005);
		this.m__0002._0002(_000E, _0006, this.m__0002._0008());
		int result = this.m__0002._0002(_0002, _0008);
		byte[] array = _000E;
		int index = _0006;
		int length = this._0008;
		if (0 == 0)
		{
			Array.Clear(array, index, length);
		}
		this.m__0002._0008(_000F);
		return result;
	}

	private static void _0002(byte[] _0002, int _0008, byte _0006)
	{
		int num = default(int);
		if (0 == 0)
		{
			num = 0;
		}
		while (num < _0008)
		{
			_0002[num] ^= _0006;
			int num2 = num + 1;
			if (uint.MaxValue != 0)
			{
				num = num2;
			}
		}
	}
}
internal static class _0008_0010
{
	private enum _0002
	{

	}

	private sealed class _0008
	{
		private Stream m__0002;

		private byte[] m__0008;

		public _0008(Stream _0002)
		{
			if (4u != 0)
			{
				this.m__0002 = _0002;
			}
			byte[] array = new byte[4];
			if (4u != 0)
			{
				m__0008 = array;
			}
		}

		public Stream _0002()
		{
			_ = 7;
			if (7 == 0)
			{
			}
			return this.m__0002;
		}

		public short _0002()
		{
			if (2u != 0)
			{
				_0002(2);
			}
			return (short)(m__0008[0] | (m__0008[1] << 8));
		}

		public int _0002()
		{
			if (3u != 0)
			{
				_0002(4);
			}
			return m__0008[0] | (m__0008[1] << 8) | (m__0008[2] << 16) | (m__0008[3] << 24);
		}

		private static void _0002()
		{
			throw new EndOfStreamException();
		}

		private void _0002(int _0002)
		{
			int num = default(int);
			if (0 == 0)
			{
				num = 0;
			}
			if (4u != 0)
			{
				int num2 = 0;
			}
			if (_0002 == 1)
			{
				int num3 = this.m__0002.ReadByte();
				int num2;
				if (4u != 0)
				{
					num2 = num3;
				}
				if (num2 == -1)
				{
					global::_0008_0010._0008._0002();
				}
				m__0008[0] = (byte)num2;
				return;
			}
			do
			{
				int num2 = this.m__0002.Read(m__0008, num, _0002 - num);
				if (num2 == 0)
				{
					global::_0008_0010._0008._0002();
				}
				num += num2;
			}
			while (num < _0002);
		}

		public void _0002()
		{
			Stream stream = this.m__0002;
			Stream stream2;
			if (7u != 0)
			{
				stream2 = stream;
			}
			if (8u != 0)
			{
				this.m__0002 = null;
			}
			stream2?.Close();
			if (3u != 0)
			{
				m__0008 = null;
			}
		}

		public byte[] _0002(int _0002)
		{
			if (_0002 < 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			byte[] array = new byte[_0002];
			byte[] array2;
			if (7u != 0)
			{
				array2 = array;
			}
			int num;
			if (6u != 0)
			{
				num = 0;
			}
			do
			{
				int num2 = this.m__0002.Read(array2, num, _0002);
				int num3;
				if (uint.MaxValue != 0)
				{
					num3 = num2;
				}
				if (num3 == 0)
				{
					break;
				}
				num += num3;
				_0002 -= num3;
			}
			while (_0002 > 0);
			if (num != array2.Length)
			{
				byte[] array3 = new byte[num];
				Buffer.BlockCopy(array2, 0, array3, 0, num);
				array2 = array3;
			}
			return array2;
		}
	}

	private static short _000F;

	private static byte[] _0003;

	private static _0008 m__0008;

	private static ConcurrentDictionary<int, string> m__0002;

	private static int _0002_2004;

	private static _0002 _0008_2004;

	private static int _0005;

	private static int _000E;

	private static byte[] _0006;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static _0008_0010()
	{
		int num = default(int);
		if (0 == 0)
		{
			num = 501000133;
		}
		int num2 = 404838022 + num;
		int num3;
		if (7u != 0)
		{
			num3 = num2;
		}
		ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();
		if (2u != 0)
		{
			global::_0008_0010.m__0002 = concurrentDictionary;
		}
		int num4;
		if (true)
		{
			num4 = 2;
		}
		StackTrace stackTrace = new StackTrace(num4, fNeedFileInfo: false);
		StackTrace stackTrace2;
		if (3u != 0)
		{
			stackTrace2 = stackTrace;
		}
		int num5 = num4 - 2;
		if (4u != 0)
		{
			num4 = num5;
		}
		StackFrame frame = stackTrace2.GetFrame(num4);
		int num6 = num4;
		if (frame == null)
		{
			stackTrace2 = new StackTrace();
			num6 = 1;
			frame = stackTrace2.GetFrame(num6);
		}
		int num7 = -(~(-(~(~(-(-(~(~((-456963285 - num) ^ num3))))))))) ^ -(~(-(~(-(~(~(-(~(num + 90634403 - num3)))))))));
		MethodBase methodBase = frame?.GetMethod();
		if (frame != null)
		{
			num7 ^= -(~(~(-(-(~(-(~(-(~(~((-1433098638 ^ num) + num3)))))))))));
		}
		Type type = methodBase?.DeclaringType;
		if (type == typeof(RuntimeMethodHandle))
		{
			num7 ^= ((num + 404837799) ^ num3) + num4;
			_0008_2004 = (_0002)4 | _0008_2004;
		}
		else if (type == null)
		{
			if (_0002(stackTrace2, num6))
			{
				_0008_2004 |= (_0002)16;
				num7 ^= ~(-(~(-(~(-(-(~(~(-(~((num ^ 0x282107A6) - num3))))))))))) - num4;
			}
			else
			{
				_0008_2004 = (_0002)1 | _0008_2004;
				num7 ^= -(~(-(~(-(~(~(-(~(-404875067 - num + num3)))))))));
			}
		}
		else
		{
			_0008_2004 = (_0002)16 | _0008_2004;
			num7 ^= -(~(-(~(-(~(-(~(~(-(~((num ^ 0x282107AC) - num3))))))))))) - num4;
		}
		_0002_2004 += num7;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static string _0002(int _0002)
	{
		ConcurrentDictionary<int, string> concurrentDictionary = global::_0008_0010.m__0002;
		_ = -1;
		if (false)
		{
		}
		if (concurrentDictionary.TryGetValue(_0002, out var value))
		{
			string result = value;
			_ = 0;
			if (false)
			{
			}
			return result;
		}
		_ = 5;
		if (6 == 0)
		{
		}
		return global::_0008_0010._0002(_0002, _0008: true);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static string _0002(int _0002, bool _0008)
	{
		int num;
		if (true)
		{
			num = 516968607;
		}
		int num2 = 245414977 + num;
		int num3;
		if (2u != 0)
		{
			num3 = num2;
		}
		string value;
		if (6u != 0)
		{
			value = null;
		}
		byte[] array;
		int num21;
		int num22;
		int num23;
		int num24;
		byte[] array4;
		byte[] array3;
		int num25;
		while (true)
		{
			ConcurrentDictionary<int, string> concurrentDictionary = global::_0008_0010.m__0002;
			ConcurrentDictionary<int, string> obj;
			if (8u != 0)
			{
				obj = concurrentDictionary;
			}
			bool lockTaken;
			if (6u != 0)
			{
				lockTaken = false;
			}
			try
			{
				if (uint.MaxValue != 0)
				{
					Monitor.Enter(obj, ref lockTaken);
				}
				int num9;
				if (global::_0008_0010.m__0008 == null)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					Assembly assembly;
					if (6u != 0)
					{
						assembly = executingAssembly;
					}
					Assembly assembly2;
					try
					{
						Assembly callingAssembly = Assembly.GetCallingAssembly();
						if (3u != 0)
						{
							assembly2 = callingAssembly;
						}
					}
					catch (PlatformNotSupportedException)
					{
						if (5u != 0)
						{
							assembly2 = assembly;
						}
					}
					int num4 = _0005 | (1280962561 - num - num3);
					if (5u != 0)
					{
						_0005 = num4;
					}
					StringBuilder stringBuilder = new StringBuilder();
					int num5 = (num ^ -330939466) + num3;
					stringBuilder.Append((char)num5).Append((char)(num5 >> 16));
					num5 = (-291447739 + num) ^ num3;
					stringBuilder.Append((char)(num5 >> 16)).Append((char)num5);
					num5 = 1816296840 - num - num3;
					stringBuilder.Append((char)num5).Append((char)(num5 >> 16));
					num5 = num + -741948793 + num3;
					stringBuilder.Append((char)(num5 >> 16)).Append((char)num5);
					num5 = num ^ 0x13A87C7E ^ num3;
					stringBuilder.Append((char)num5).Append((char)(num5 >> 16));
					num5 = 1816296842 - num - num3;
					stringBuilder.Append((char)num5).Append((char)(num5 >> 16));
					Stream manifestResourceStream = assembly.GetManifestResourceStream(stringBuilder.ToString());
					int num6 = 2;
					StackTrace stackTrace = new StackTrace(num6, fNeedFileInfo: false);
					_0005 ^= (num + -1279345721 + num3) | num6;
					num6 -= 2;
					StackFrame frame = stackTrace.GetFrame(num6);
					int num7 = num6;
					if (frame == null)
					{
						stackTrace = new StackTrace();
						num7 = 1;
						frame = stackTrace.GetFrame(num7);
					}
					MethodBase methodBase = frame?.GetMethod();
					_0005 ^= num6 + (num ^ 0x33A15CFF ^ num3);
					Type type = methodBase?.DeclaringType;
					if (frame == null)
					{
						_0005 ^= 245634292 + num - num3;
					}
					bool flag = type == typeof(RuntimeMethodHandle);
					_0005 ^= (1279352031 - num) ^ num3;
					if (!flag)
					{
						flag = type == null;
						if (flag)
						{
							if (global::_0008_0010._0002(stackTrace, num7))
							{
								flag = false;
							}
							else
							{
								_0005 ^= num + -1279132908 + num3;
							}
						}
					}
					if (flag == (stackTrace != null))
					{
						_0005 = 0x20 ^ _0005;
					}
					_0005 ^= (0x33A14519 ^ num ^ num3) | (num6 + 1);
					global::_0008_0010.m__0008 = new _0008(manifestResourceStream);
					short num8 = (short)(global::_0008_0010.m__0008._0002() ^ (short)(-(~(-(~(~(-(-(~(~(1279375158 - num - num3)))))))))));
					if (num8 == 0)
					{
						_000F = (short)(global::_0008_0010.m__0008._0002() ^ (short)(-(~(~(-(-(~(-(~(-(~(~((num ^ -866193128) + num3)))))))))))));
					}
					else
					{
						_0006 = global::_0008_0010.m__0008._0002(num8);
					}
					assembly2 = assembly;
					AssemblyName assemblyName = global::_0008_0010._0002(assembly2);
					_0003 = global::_0008_0010._0002(assemblyName);
					num9 = _0002_2004;
					_0002_2004 = 0;
					long num10 = global::_0008_2001_2005._0002();
					num9 ^= (int)num10;
					num9 ^= 1491667653 - num - num3;
					num9 ^= num + 772872814 + num3;
					int num11 = 0;
					int num12 = 0;
					int num13 = num9;
					int num14 = 0;
					global::_0005_2003_2005<int> obj2 = null;
					int num15 = 0;
					num12 = num13;
					int num16 = 0;
					int num17 = 0;
					num16 = 0;
					num17 = (676526216 - num - num3) ^ num12;
					obj2 = null;
					num14 = num17;
					num16 = (num + 245414902) ^ num3;
					num15 = 0;
					obj2 = ((global::_0002_2003_2005<int>)new global::_0003_2003_2005._0006((num ^ -866212991) | num3)
					{
						_0005 = num14
					}).GetEnumerator();
					try
					{
						while (((global::_0008_2003_2005)obj2)._0008_2003_2005_2008_2009_0002())
						{
							num15 = obj2._0008_2003_2005_2008_2009_0002();
							num17 ^= num15 - num16;
							num16 -= num17 + 3 >> 8;
						}
					}
					finally
					{
						obj2?._0006_2003_2005_2008_2009_0002();
					}
					num11 = num17;
					num9 ^= -244699919 - num + num3 + -(~(~(-(~(-(~(-(~(num + 245414668 - num3)))))))));
					int num18 = num11 * (-245409684 - num + num3) % (num + 273156654 - num3);
					num9 ^= -(~(~(-(~(-(~(-(~(num ^ 0x345BB518 ^ num3)))))))));
					num9 = num18 + num9;
					_0005 = (_0005 & (23020337 - num + num3)) ^ (num + 245421765 - num3);
					_000E = num9;
					if (((uint)_0008_2004 & (uint)(-(~(~(-(-(~(~(-(~(-(~((-245414995 - num) | num3))))))))))))) == 0)
					{
						_0005 = -1279308229 + num + num3;
					}
				}
				else
				{
					num9 = _000E;
				}
				if (_0005 == (num ^ 0x33A1F7C5 ^ num3))
				{
					value = new string(new char[3]
					{
						(char)(245415065 + num - num3),
						'0',
						(char)(-245414889 - num + num3)
					});
					return value;
				}
				int num19 = _0002 ^ (num ^ -1161168478 ^ num3) ^ num9;
				num19 ^= -515426248 + num + num3;
				global::_0008_0010.m__0008._0002().Position = num19;
				if (_0006 != null)
				{
					array = _0006;
				}
				else
				{
					short num20 = ((_000F != -1) ? _000F : ((short)(global::_0008_0010.m__0008._0002() ^ (-866200794 ^ num ^ num3) ^ num19)));
					if (num20 == 0)
					{
						array = null;
					}
					else
					{
						array = global::_0008_0010.m__0008._0002(num20);
						for (int i = 0; i != array.Length; i++)
						{
							array[i] ^= (byte)(_000E >> ((i & 3) << 3));
						}
					}
				}
				num21 = global::_0008_0010.m__0008._0002() ^ num19 ^ -(~(~(-(~(-(~(-(~(-1211757768 - num + num3))))))))) ^ num9;
				if (num21 == ((num ^ -866212991) | num3))
				{
					byte[] array2 = global::_0008_0010.m__0008._0002(4);
					_0002 = (-166206523 + num) ^ num3 ^ num9;
					_0002 = (array2[2] | (array2[3] << 16) | (array2[0] << 8) | (array2[1] << 24)) ^ -_0002;
					goto IL_0025;
				}
				num22 = _0005;
				num23 = -243807163 - num + num3;
				num24 = num21;
				num25 = num22 - 12;
				num21 &= (num + 62825088) ^ num3;
				array3 = global::_0008_0010.m__0008._0002(num21);
				array4 = _0003;
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
			break;
			IL_0025:
			if (global::_0008_0010.m__0002.TryGetValue(_0002, out value))
			{
				return value;
			}
		}
		bool flag2 = (num24 & (291455935 - num + num3)) != 0;
		bool flag3 = (num24 & (num ^ 0x73A15C7F ^ num3)) != 0;
		bool flag4 = (num24 & (1902068671 - num + num3)) != 0;
		byte[] array5 = array;
		byte[] array6 = array3;
		byte[] array7 = array5;
		byte b = 0;
		int num26 = 0;
		uint num27 = 0u;
		byte b2 = 0;
		int num28 = 0;
		ushort num29 = 0;
		byte b3 = 0;
		byte b4 = 0;
		b4 = array7[1];
		num26 = array6.Length;
		b = (byte)((num26 + 11) ^ (b4 + 7));
		num27 = (uint)((array7[0] | (array7[2] << 8)) + (b << 3));
		num28 = 0;
		num29 = 0;
		for (; num28 < num26; num28++)
		{
			if ((1 & num28) == 0)
			{
				num27 = (uint)((int)num27 * ((245497470 + num) ^ num3) + ((num ^ 0x3347FB3C) - num3));
				num29 = (ushort)(num27 >> 16);
			}
			b2 = (byte)num29;
			num29 >>= 8;
			b3 = array6[num28];
			array6[num28] = (byte)(b3 ^ b4 ^ (b + 3) ^ b2);
			b = b3;
		}
		array3 = array6;
		if (array4 != null != (num22 != num23))
		{
			for (int j = 0; j < num21; j++)
			{
				byte b5 = array4[j & 7];
				b5 = (byte)((b5 << 3) | (b5 >> 5));
				array3[j] ^= b5;
			}
		}
		int num30;
		byte[] array8;
		if (!flag3)
		{
			num30 = num21;
			array8 = array3;
		}
		else
		{
			num30 = array3[2] | (array3[0] << 16) | (array3[3] << 8) | (array3[1] << 24);
			array8 = new byte[num30];
			global::_0008_0010._0002(array3, 4, array8);
		}
		if (flag2 && num25 == num23 - 12)
		{
			char[] array9 = new char[num30];
			for (int num31 = 0; num31 < num30; num31 = 1 + num31)
			{
				array9[num31] = (char)array8[num31];
			}
			value = new string(array9);
		}
		else
		{
			char[] array10 = new char[num30 / 2];
			int num32 = 0;
			for (int k = 0; k < num30; k += 2)
			{
				array10[num32++] = (char)(array8[k] | (array8[k + 1] << 8));
			}
			value = new string(array10);
		}
		num25 += ((num + 245414912) ^ num3) + (num25 & 3) << 5;
		if (num25 != num23 - 12 + (1279352318 - num - num3 + ((num23 - 12) & 3) << 5))
		{
			int num33 = (_0002 + num21) ^ (num + -1278415623 + num3) ^ (num25 & (1279353484 - num - num3));
			StringBuilder stringBuilder = new StringBuilder();
			int num5 = (-866212889 ^ num) + num3;
			stringBuilder.Append((char)(byte)num5);
			value = num33.ToString(stringBuilder.ToString());
		}
		if (!flag4 && _0008)
		{
			value = string.Intern(value);
			global::_0008_0010.m__0002[_0002] = value;
			if (global::_0008_0010.m__0002.Count == ((245415215 + num) ^ num3))
			{
				bool lockTaken2 = false;
				ConcurrentDictionary<int, string> obj3 = global::_0008_0010.m__0002;
				try
				{
					Monitor.Enter(obj3, ref lockTaken2);
					if (global::_0008_0010.m__0008 != null)
					{
						global::_0008_0010.m__0008._0002();
						global::_0008_0010.m__0008 = null;
						_0006 = null;
						_0003 = null;
					}
				}
				finally
				{
					if (lockTaken2)
					{
						Monitor.Exit(obj3);
					}
				}
			}
		}
		return value;
	}

	private static AssemblyName _0002(Assembly _0002)
	{
		try
		{
			AssemblyName name = _0002.GetName();
			if (4u != 0)
			{
				return name;
			}
		}
		catch
		{
			AssemblyName result = new AssemblyName(_0002.FullName);
			if (2u != 0)
			{
				return result;
			}
		}
		AssemblyName result2;
		return result2;
	}

	private static byte[] _0002(AssemblyName _0002)
	{
		byte[] publicKeyToken = _0002.GetPublicKeyToken();
		byte[] array;
		if (8u != 0)
		{
			array = publicKeyToken;
		}
		if (array != null && array.Length == 0)
		{
			if (6u != 0)
			{
				array = null;
			}
		}
		return array;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0002(StackTrace _0002, int _0008)
	{
		int num = _0008 + 1;
		if (2u != 0)
		{
			_0008 = num;
		}
		StackFrame frame = _0002.GetFrame(num);
		StackFrame stackFrame;
		if (4u != 0)
		{
			stackFrame = frame;
		}
		Assembly obj = stackFrame?.GetMethod()?.DeclaringType?.Assembly;
		Assembly assembly;
		if (8u != 0)
		{
			assembly = obj;
		}
		if (assembly != null)
		{
			AssemblyName assemblyName = global::_0008_0010._0002(assembly);
			byte[] array = global::_0008_0010._0002(assemblyName);
			if (array != null && array.Length == 8 && array[0] == 183 && array[7] == 137)
			{
				return true;
			}
		}
		while (true)
		{
			stackFrame = _0002.GetFrame(++_0008);
			if (stackFrame == null)
			{
				break;
			}
			assembly = stackFrame.GetMethod()?.DeclaringType?.Assembly;
			if (assembly != null && assembly == typeof(global::_0008_0010).Assembly)
			{
				return true;
			}
		}
		return false;
	}

	private static void _0002(byte[] _0002, int _0008, byte[] _0006)
	{
		int num;
		if (8u != 0)
		{
			num = 0;
		}
		int num2;
		if (true)
		{
			num2 = 0;
		}
		int num3;
		if (4u != 0)
		{
			num3 = 128;
		}
		int num4 = _0006.Length;
		while (num < num4)
		{
			if ((num3 <<= 1) == 256)
			{
				num3 = 1;
				num2 = _0002[_0008++];
			}
			if ((num2 & num3) != 0)
			{
				int num5 = (_0002[_0008] >> 2) + 3;
				int num6 = ((_0002[_0008] << 8) | _0002[_0008 + 1]) & 0x3FF;
				_0008 += 2;
				int num7 = num - num6;
				if (num7 < 0)
				{
					break;
				}
				while (--num5 >= 0 && num < num4)
				{
					_0006[num++] = _0006[num7++];
				}
			}
			else
			{
				_0006[num++] = _0002[_0008++];
			}
		}
	}
}
internal sealed class _0008_200B : global::_0002_200B
{
	private new Array m__0002;

	private int[] _0008;

	public _0008_200B()
	{
		_ = 2;
		if (8 == 0)
		{
		}
		base._002Ector(11);
	}

	public new Array _0002()
	{
		_ = 3;
		if (-1 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(Array _0002)
	{
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new int[] _0002()
	{
		_ = 7;
		if (8 == 0)
		{
		}
		return _0008;
	}

	public void _0002(int[] _0002)
	{
		if (4u != 0)
		{
			_0008 = _0002;
		}
	}

	[SpecialName]
	public override object _0002_200B_2008_2009_0002()
	{
		_ = 0;
		if (7 == 0)
		{
		}
		Array array = this._0002();
		_ = 4;
		if (2 == 0)
		{
		}
		return array.GetValue(this._0002());
	}

	[SpecialName]
	public override void _0002_200B_2008_2009_0002(object _0002)
	{
		_ = -1;
		if (6 == 0)
		{
		}
		Array array = this._0002();
		_ = 2;
		if (3 == 0)
		{
		}
		_ = 2;
		if (false)
		{
		}
		array.SetValue(_0002, this._0002());
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0008_200B obj = new global::_0008_200B();
		_ = 3;
		if (2 == 0)
		{
		}
		obj._0002(this._0002());
		_ = 4;
		if (-1 == 0)
		{
		}
		obj._0002(this._0002());
		_ = 1;
		if (6 == 0)
		{
		}
		obj._0002(base._0002());
		((global::_0006)obj)._0002(((global::_0006)this)._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (7u != 0)
		{
			((global::_0006)this)._0002(type);
		}
		if (_0002._0002() == 11)
		{
			global::_0008_200B obj = (global::_0008_200B)_0002;
			global::_0008_200B obj2;
			if (2u != 0)
			{
				obj2 = obj;
			}
			Array array = obj2._0002();
			if (true)
			{
				this._0002(array);
			}
			this._0002(obj2._0002());
			base._0002(((global::_0002_200B)obj2)._0002());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override bool _0002_200B_2008_2009_0002(global::_0002_200B _0002)
	{
		global::_0008_200B obj = (global::_0008_200B)_0002;
		global::_0008_200B obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		if (this._0002() == obj2._0002())
		{
			return global::_000F_2005._0002(this._0002(), obj2._0002());
		}
		return false;
	}
}
internal sealed class _000E_200B : global::_0002_2004
{
	private new object m__0002;

	private FieldInfo _0008;

	private global::_0002_2004 _0006;

	public _000E_200B(FieldInfo _0002, object _0008)
		: this()
	{
		if (4u != 0)
		{
			this._0002(_0002);
		}
		if (6u != 0)
		{
			this._0002(_0008);
		}
	}

	public _000E_200B(FieldInfo _0002, object _0008, global::_0002_2004 _0006)
		: this(_0002, _0008)
	{
		if (5u != 0)
		{
			this._0002(_0006);
		}
	}

	private _000E_200B()
	{
		_ = 7;
		if (8 == 0)
		{
		}
		base._002Ector(18);
	}

	public new object _0002()
	{
		_ = 2;
		if (8 == 0)
		{
		}
		return this.m__0002;
	}

	private void _0002(object _0002)
	{
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new FieldInfo _0002()
	{
		_ = 7;
		if (8 == 0)
		{
		}
		return _0008;
	}

	private void _0002(FieldInfo _0002)
	{
		if (uint.MaxValue != 0)
		{
			_0008 = _0002;
		}
	}

	public new global::_0002_2004 _0002()
	{
		_ = 4;
		if (5 == 0)
		{
		}
		return _0006;
	}

	private void _0002(global::_0002_2004 _0002)
	{
		if (5u != 0)
		{
			_0006 = _0002;
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (5u != 0)
		{
			base._0002(type);
		}
		if (_0002._0002() == 18)
		{
			global::_000E_200B obj = (global::_000E_200B)_0002;
			global::_000E_200B obj2;
			if (2u != 0)
			{
				obj2 = obj;
			}
			object obj3 = obj2._0002();
			if (2u != 0)
			{
				this._0002(obj3);
			}
			this._0002(obj2._0002());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000E_200B obj = new global::_000E_200B();
		_ = 6;
		if (2 == 0)
		{
		}
		obj._0002(this._0002());
		_ = 1;
		if (false)
		{
		}
		obj._0002(this._0002());
		_ = 0;
		if (3 == 0)
		{
		}
		obj._0002(this._0002());
		((global::_0006)obj)._0002(((global::_0006)this)._0002());
		return obj;
	}
}
internal sealed class _000F_200B : global::_0006
{
	private new float m__0002;

	public _000F_200B()
	{
		_ = -1;
		if (2 == 0)
		{
		}
		base._002Ector(22);
	}

	public new float _0002()
	{
		_ = 8;
		if (2 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(float _0002)
	{
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 4;
		if (false)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		float num = Convert.ToSingle(_0002);
		if (uint.MaxValue != 0)
		{
			this._0002(num);
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000F_200B obj = new global::_000F_200B();
		_ = 7;
		if (-1 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 5;
		if (4 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (true)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 22:
		{
			float num3 = ((global::_000F_200B)_0002)._0002();
			if (7u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 12:
			this._0002((int)((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002(((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002(((global::_000F)_0002)._0002());
			break;
		case 13:
			this._0002(((global::_0003_2000)_0002)._0002());
			break;
		case 17:
			this._0002(((global::_0003_2001)_0002)._0002());
			break;
		case 16:
			this._0002((int)((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002(((global::_000F_2001)_0002)._0002());
			break;
		case 14:
			this._0002(((global::_000E_2006)_0002)._0002());
			break;
		case 8:
			this._0002((float)((global::_0006_200A)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToSingle(((global::_0002_0010)_0002)._0002()));
			break;
		case 7:
			this._0002((float)((global::_0005_2003)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
