using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using _002D;
using MahApps.Metro.Controls;
using Microsoft.Win32.SafeHandles;
using authManager;
using robotManager.Helpful;
using robotManager.Helpful.Forms.UserControls;
using wManager;
using wManager.Wow;
using wManager.Wow.Enums;
using wManager.Wow.Forms;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

internal sealed class _0002
{
	private byte m__0002;

	private int _0008;

	private global::_0005_2004 _0006;

	public _0002()
	{
		_ = 3;
		if (5 == 0)
		{
		}
		base._002Ector();
	}

	public byte _0002()
	{
		_ = -1;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(byte _0002)
	{
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public int _0002()
	{
		_ = 3;
		if (2 == 0)
		{
		}
		return _0008;
	}

	public void _0002(int _0002)
	{
		if (6u != 0)
		{
			_0008 = _0002;
		}
	}

	public global::_0005_2004 _0002()
	{
		_ = 3;
		if (2 == 0)
		{
		}
		return _0006;
	}

	public void _0002(global::_0005_2004 _0002)
	{
		if (5u != 0)
		{
			_0006 = _0002;
		}
	}
}
internal sealed class _0002_2000 : global::_0002_2007, IDisposable
{
	private sealed class _0002
	{
		public bool _0002;

		public global::_0002_2007 _0008;

		public _0002()
		{
			_ = 7;
			if (false)
			{
			}
			base._002Ector();
		}
	}

	private readonly global::_0008_200A m__0002;

	private readonly bool m__0008;

	private readonly bool _0006;

	private readonly int _000F;

	private readonly int _0005;

	private _0002 _0003;

	private bool _000E;

	private readonly object _0002_2004;

	public _0002_2000(bool _0002, global::_0008_200A _0008, bool _0006 = false)
	{
		object obj = new object();
		if (3u != 0)
		{
			_0002_2004 = obj;
		}
		base._002Ector();
		if (2u != 0)
		{
			this.m__0008 = _0002;
		}
		if (4u != 0)
		{
			this.m__0002 = _0008;
		}
		this._0006 = _0006;
		this._0006 = true;
		int num = _0008._0002()._0002();
		_000F = global::_0002_2000._0002(num, _0002);
		_0005 = global::_0002_2000._0008(num, _0002);
	}

	public bool _0002()
	{
		_ = 7;
		if (3 == 0)
		{
		}
		return this.m__0008;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0002()
	{
		_ = -1;
		if (5 == 0)
		{
		}
		return _000F;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0008()
	{
		_ = 3;
		if (3 == 0)
		{
		}
		return _0005;
	}

	private static int _0002(int _0002, bool _0008)
	{
		_ = 7;
		if (3 == 0)
		{
		}
		if (!_0008)
		{
			_ = 2;
			if (6 == 0)
			{
			}
			return (_0002 + 7) / 8;
		}
		_ = 7;
		if (-1 == 0)
		{
		}
		return (_0002 - 1) / 8;
	}

	private static int _0008(int _0002, bool _0008)
	{
		_ = -1;
		if (4 == 0)
		{
		}
		if (!_0008)
		{
			_ = 0;
			if (5 == 0)
			{
			}
			return (_0002 - 1) / 8;
		}
		_ = 0;
		if (2 == 0)
		{
		}
		return (_0002 + 7) / 8;
	}

	public int _0002_2007_2008_2009_0002(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005, RandomNumberGenerator _0003)
	{
		if (7u != 0)
		{
			this._0008();
		}
		_0002 obj = this._0003;
		_0002 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		try
		{
			int result = obj2._0008._0002_2007_2008_2009_0002(_0002, _0008, _0006, _000F, _0005, _0003);
			if (2u != 0)
			{
				return result;
			}
		}
		catch when (obj2._0002)
		{
			this._0002();
			obj2 = this._0003;
			return obj2._0008._0002_2007_2008_2009_0002(_0002, _0008, _0006, _000F, _0005, _0003);
		}
		int result2;
		return result2;
	}

	private void _0002()
	{
		object obj = _0002_2004;
		object obj2;
		if (3u != 0)
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
			if (6u != 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			_0002 obj3 = _0003;
			if (!obj3._0002)
			{
				return;
			}
			try
			{
				if (obj3._0008 is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			catch
			{
			}
			global::_0002_2007 obj5 = _0002_2000_2008_2009_0002(this.m__0008, this.m__0002);
			if (obj5 == null)
			{
				throw new InvalidOperationException();
			}
			_0003 = new _0002
			{
				_0002 = false,
				_0008 = obj5
			};
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	private void _0008()
	{
		if (_000E)
		{
			return;
		}
		object obj = _0002_2004;
		object obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (uint.MaxValue != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (0 == 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			if (_000E)
			{
				return;
			}
			global::_0002_2007 obj3;
			if (!_0006 && (obj3 = _0002_2000_2008_2009_0008(this.m__0008, this.m__0002)) != null)
			{
				_0003 = new _0002
				{
					_0002 = true,
					_0008 = obj3
				};
			}
			else
			{
				obj3 = _0002_2000_2008_2009_0002(this.m__0008, this.m__0002);
				if (obj3 == null)
				{
					throw new InvalidOperationException();
				}
				_0003 = new _0002
				{
					_0002 = false,
					_0008 = obj3
				};
			}
			_000E = true;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	protected virtual global::_0002_2007 _0002_2000_2008_2009_0002(bool _0002, global::_0008_200A _0008)
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		_ = 4;
		if (8 == 0)
		{
		}
		return new global::_0008_2007(_0002, _0008);
	}

	protected virtual global::_0002_2007 _0002_2000_2008_2009_0008(bool _0002, global::_0008_200A _0008)
	{
		_ = 3;
		if (4 == 0)
		{
		}
		_ = 8;
		if (6 == 0)
		{
		}
		return global::_0005_2009._0002(_0002, _0008);
	}

	public void Dispose()
	{
		IDisposable obj = _0003?._0008 as IDisposable;
		IDisposable disposable;
		if (7u != 0)
		{
			disposable = obj;
		}
		if (disposable != null)
		{
			disposable.Dispose();
			if (0 == 0)
			{
				_0003 = null;
			}
		}
	}
}
internal sealed class _0002_2001
{
	public byte[] _0002;

	public int _0008;

	public int _0006;

	public DateTime _000F;

	public _0002_2001()
	{
		DateTime utcNow = DateTime.UtcNow;
		DateTime dateTime;
		if (3u != 0)
		{
			dateTime = utcNow;
		}
		DateTime dateTime2 = dateTime.AddTicks(1L);
		if (6u != 0)
		{
			_000F = dateTime2;
		}
		base._002Ector();
	}
}
internal static class _0002_2001_2005
{
}
internal sealed class _0002_2002 : global::_0002_2009, IDisposable
{
	private List<byte> m__0002;

	public _0002_2002()
	{
		List<byte> list = new List<byte>();
		if (8u != 0)
		{
			this.m__0002 = list;
		}
		base._002Ector();
	}

	[SpecialName]
	public int _0002_2009_2008_2009_0002()
	{
		_ = 2;
		if (-1 == 0)
		{
		}
		return this.m__0002.Count;
	}

	public void _0002_2009_2008_2009_0002()
	{
		_ = 2;
		if (3 == 0)
		{
		}
		this.m__0002.Clear();
	}

	public global::_0002_2009 _0002_2009_2008_2009_0002()
	{
		return new global::_0002_2002();
	}

	public void Dispose()
	{
		if (true)
		{
			this._0002_2009_2008_2009_0002();
		}
		if (8u != 0)
		{
			this.m__0002 = null;
		}
	}

	public void _0002_2009_2008_2009_0002(int _0002, out byte _0008)
	{
		_ = 5;
		if (2 == 0)
		{
		}
		_ = 6;
		if (4 == 0)
		{
		}
		_ = 5;
		if (3 == 0)
		{
		}
		_0008 = this._0002(this.m__0002[_0002], _0002);
	}

	public void _0002_2009_2008_2009_0008(int _0002, ref byte _0008)
	{
		int count = this.m__0002.Count;
		int num;
		if (2u != 0)
		{
			num = count;
		}
		while (true)
		{
			if (num > _0002)
			{
				this.m__0002[_0002] = this._0008(_0008, _0002);
				return;
			}
			if (num == _0002)
			{
				break;
			}
			this.m__0002.Add(this._0008(0, num));
			int num2 = num + 1;
			if (6u != 0)
			{
				num = num2;
			}
		}
		this.m__0002.Add(this._0008(_0008, num));
	}

	private byte _0002(byte _0002, int _0008)
	{
		throw new NotImplementedException();
	}

	private byte _0008(byte _0002, int _0008)
	{
		throw new NotImplementedException();
	}
}
internal sealed class _0002_2003 : global::_0006
{
	private new UIntPtr m__0002;

	public _0002_2003()
	{
		_ = 7;
		if (1 == 0)
		{
		}
		base._002Ector(20);
	}

	public new UIntPtr _0002()
	{
		_ = 5;
		if (7 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(UIntPtr _0002)
	{
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0002_2003 obj = new global::_0002_2003();
		_ = -1;
		if (6 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 5;
		if (3 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 6;
		if (3 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		UIntPtr intPtr = (UIntPtr)_0002;
		if (true)
		{
			this._0002(intPtr);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (3u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 20:
		{
			UIntPtr intPtr = ((global::_0002_2003)_0002)._0002();
			if (2u != 0)
			{
				this._0002(intPtr);
			}
			break;
		}
		case 12:
			this._0002((UIntPtr)((global::_0008_2004_2005)_0002)._0002());
			break;
		case 1:
			this._0002((UIntPtr)(ulong)((global::_000F)_0002)._0002());
			break;
		case 16:
			this._0002((UIntPtr)((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002((UIntPtr)((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002((UIntPtr)(ulong)((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002((UIntPtr)((global::_000E_2006)_0002)._0002());
			break;
		case 7:
			this._0002((UIntPtr)((global::_0005_2003)_0002)._0002());
			break;
		case 22:
			this._0002((UIntPtr)(ulong)((global::_000F_200B)_0002)._0002());
			break;
		case 19:
			this._0002(new UIntPtr(Convert.ToUInt64(((global::_0002_0010)_0002)._0002())));
			break;
		case 8:
			this._0002((UIntPtr)(ulong)((global::_0006_200A)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal interface _0002_2003_2005<_0002> : global::_000E_2007_2005
{
	global::_0005_2003_2005<_0002> GetEnumerator();
}
internal abstract class _0002_2004 : global::_0006
{
	public _0002_2004(int _0002)
	{
		_ = 3;
		if (1 == 0)
		{
		}
		_ = -1;
		if (-1 == 0)
		{
		}
		base._002Ector(_0002);
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		throw new InvalidOperationException();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		throw new InvalidOperationException();
	}
}
internal sealed class _0002_2004_2005 : IDisposable
{
	private global::_0005 m__0002;

	private byte[] m__0008;

	private Decoder m__0006;

	private byte[] m__000F;

	private char[] m__0005;

	private char[] _0003;

	private int _000E;

	private bool _0002_2004;

	private bool _0008_2004;

	private byte[] _0006_2004;

	private MemoryStream _000F_2004;

	private BinaryReader _0005_2004;

	public _0002_2004_2005(global::_0005 _0002)
	{
		_ = 0;
		if (3 == 0)
		{
		}
		_ = 1;
		if (1 == 0)
		{
		}
		this._002Ector(_0002, new UTF8Encoding());
	}

	private _0002_2004_2005(global::_0005 _0002, Encoding _0008)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (_0008 == null)
		{
			throw new ArgumentNullException();
		}
		if (!_0002._0005_2008_2009_0002())
		{
			throw new ArgumentException();
		}
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
		Decoder decoder = _0008.GetDecoder();
		if (5u != 0)
		{
			this.m__0006 = decoder;
		}
		int maxCharCount = _0008.GetMaxCharCount(128);
		if (6u != 0)
		{
			_000E = maxCharCount;
		}
		int num = _0008.GetMaxByteCount(1);
		if (num < 16)
		{
			num = 16;
		}
		this.m__0008 = new byte[num];
		_0003 = null;
		this.m__000F = null;
		_0002_2004 = _0008 is UnicodeEncoding;
		_0008_2004 = this.m__0002 is global::_0003;
	}

	public global::_0005 _0002()
	{
		_ = -1;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002()
	{
		if (5u != 0)
		{
			_0002(_0002: true);
		}
	}

	private void _0002(bool _0002)
	{
		if (_0002)
		{
			global::_0005 obj = this.m__0002;
			global::_0005 obj2;
			if (7u != 0)
			{
				obj2 = obj;
			}
			if (8u != 0)
			{
				this.m__0002 = null;
			}
			obj2?._0005_2008_2009_0002();
		}
		if (0 == 0)
		{
			this.m__0002 = null;
		}
		this.m__0008 = null;
		this.m__0006 = null;
		this.m__000F = null;
		this.m__0005 = null;
		_0003 = null;
	}

	private void _0002_2004_2005_2008_2009_0008()
	{
		if (6u != 0)
		{
			_0002(_0002: true);
		}
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in     
		this._0002_2004_2005_2008_2009_0008();
	}

	public int _0002()
	{
		if (4u != 0)
		{
			_0006();
		}
		if (!this.m__0002._0005_2008_2009_0006())
		{
			return -1;
		}
		long num = this.m__0002._0005_2008_2009_0008();
		long num2;
		if (4u != 0)
		{
			num2 = num;
		}
		int result = _0008();
		this.m__0002._0005_2008_2009_0002(num2);
		return result;
	}

	public int _0008()
	{
		if (8u != 0)
		{
			_0006();
		}
		return _0006();
	}

	public bool _0002()
	{
		if (3u != 0)
		{
			_0002(1);
		}
		return this.m__0008[0] != 0;
	}

	public byte _0002()
	{
		if (4u != 0)
		{
			_0006();
		}
		int num = this.m__0002._0005_2008_2009_0002();
		if (num == -1)
		{
			throw new Exception();
		}
		return (byte)num;
	}

	public sbyte _0002()
	{
		if (uint.MaxValue != 0)
		{
			_0002(1);
		}
		return (sbyte)this.m__0008[0];
	}

	public char _0002()
	{
		_ = 7;
		if (7 == 0)
		{
		}
		int num = _0008();
		if (num == -1)
		{
			throw new Exception();
		}
		return (char)num;
	}

	private static decimal _0002(int _0002, int _0008, int _0006, int _000F)
	{
		bool num = (_000F & int.MinValue) != 0;
		bool isNegative;
		if (5u != 0)
		{
			isNegative = num;
		}
		byte num2 = (byte)(_000F >> 16);
		byte scale;
		if (uint.MaxValue != 0)
		{
			scale = num2;
		}
		return new decimal(_0002, _0008, _0006, isNegative, scale);
	}

	internal static decimal _0002(byte[] _0002)
	{
		int num = _0002[0] | (_0002[1] << 8) | (_0002[2] << 16) | (_0002[3] << 24);
		int num2 = _0002[4] | (_0002[5] << 8) | (_0002[6] << 16) | (_0002[7] << 24);
		int num3;
		if (6u != 0)
		{
			num3 = num2;
		}
		int num4 = _0002[8] | (_0002[9] << 8) | (_0002[10] << 16) | (_0002[11] << 24);
		int num5;
		if (6u != 0)
		{
			num5 = num4;
		}
		int num6 = _0002[12] | (_0002[13] << 8) | (_0002[14] << 16) | (_0002[15] << 24);
		int num7 = default(int);
		if (0 == 0)
		{
			num7 = num6;
		}
		return global::_0002_2004_2005._0002(num, num3, num5, num7);
	}

	public string _0002()
	{
		int num;
		if (5u != 0)
		{
			num = 0;
		}
		if (true)
		{
			_0006();
		}
		int num2 = _000F();
		int num3;
		if (8u != 0)
		{
			num3 = num2;
		}
		if (num3 < 0)
		{
			throw new IOException();
		}
		if (num3 == 0)
		{
			return string.Empty;
		}
		if (this.m__000F == null)
		{
			this.m__000F = new byte[128];
		}
		if (_0003 == null)
		{
			_0003 = new char[_000E];
		}
		StringBuilder stringBuilder = null;
		do
		{
			int num4 = ((num3 - num > 128) ? 128 : (num3 - num));
			int num5 = this.m__0002._0005_2008_2009_0002(this.m__000F, 0, num4);
			if (num5 == 0)
			{
				throw new Exception();
			}
			int chars = this.m__0006.GetChars(this.m__000F, 0, num5, _0003, 0);
			if (num == 0 && num5 == num3)
			{
				return new string(_0003, 0, chars);
			}
			if (stringBuilder == null)
			{
				stringBuilder = new StringBuilder(num3);
			}
			stringBuilder.Append(_0003, 0, chars);
			num += num5;
		}
		while (num < num3);
		return stringBuilder.ToString();
	}

	public int _0002(char[] _0002, int _0008, int _0006)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463127134), global::_0008_0010._0002(-1463127121));
		}
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		if (8u != 0)
		{
			this._0006();
		}
		return this._0008(_0002, _0008, _0006);
	}

	private int _0008(char[] _0002, int _0008, int _0006)
	{
		if (8u != 0)
		{
			int num = 0;
		}
		if (uint.MaxValue != 0)
		{
			int num2 = 0;
		}
		int num3;
		if (8u != 0)
		{
			num3 = _0006;
		}
		if (this.m__000F == null)
		{
			this.m__000F = new byte[128];
		}
		while (num3 > 0)
		{
			int num2 = num3;
			if (_0002_2004)
			{
				num2 <<= 1;
			}
			if (num2 > 128)
			{
				num2 = 128;
			}
			int num;
			if (_0008_2004)
			{
				global::_0003 obj = (global::_0003)this.m__0002;
				int byteIndex = obj._0002();
				num2 = obj._0002(num2);
				if (num2 == 0)
				{
					return _0006 - num3;
				}
				num = this.m__0006.GetChars(obj._0002(), byteIndex, num2, _0002, _0008);
			}
			else
			{
				num2 = this.m__0002._0005_2008_2009_0002(this.m__000F, 0, num2);
				if (num2 == 0)
				{
					return _0006 - num3;
				}
				num = this.m__0006.GetChars(this.m__000F, 0, num2, _0002, _0008);
			}
			num3 -= num;
			_0008 += num;
		}
		return _0006;
	}

	private int _0006()
	{
		int num;
		if (3u != 0)
		{
			num = 0;
		}
		if (true)
		{
			int num2 = 0;
		}
		long num3 = 0L;
		long num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		num4 = num3;
		if (this.m__0002._0005_2008_2009_0006())
		{
			num4 = this.m__0002._0005_2008_2009_0008();
		}
		if (this.m__000F == null)
		{
			this.m__000F = new byte[128];
		}
		if (this.m__0005 == null)
		{
			this.m__0005 = new char[1];
		}
		while (num == 0)
		{
			int num2 = ((!_0002_2004) ? 1 : 2);
			int num5 = this.m__0002._0005_2008_2009_0002();
			this.m__000F[0] = (byte)num5;
			if (num5 == -1)
			{
				num2 = 0;
			}
			if (num2 == 2)
			{
				num5 = this.m__0002._0005_2008_2009_0002();
				this.m__000F[1] = (byte)num5;
				if (num5 == -1)
				{
					num2 = 1;
				}
			}
			if (num2 == 0)
			{
				return -1;
			}
			try
			{
				num = this.m__0006.GetChars(this.m__000F, 0, num2, this.m__0005, 0);
			}
			catch
			{
				if (this.m__0002._0005_2008_2009_0006())
				{
					this.m__0002._0005_2008_2009_0002(num4 - this.m__0002._0005_2008_2009_0008(), 1);
				}
				throw;
			}
		}
		if (num == 0)
		{
			return -1;
		}
		return this.m__0005[0];
	}

	public char[] _0002(int _0002)
	{
		if (4u != 0)
		{
			_0006();
		}
		if (_0002 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		char[] array = new char[_0002];
		char[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		int num = _0008(array2, 0, _0002);
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		if (num2 != _0002)
		{
			char[] array3 = new char[num2];
			Buffer.BlockCopy(array2, 0, array3, 0, 2 * num2);
			array2 = array3;
		}
		return array2;
	}

	public int _0002(byte[] _0002, int _0008, int _0006)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		if (4u != 0)
		{
			this._0006();
		}
		return this.m__0002._0005_2008_2009_0002(_0002, _0008, _0006);
	}

	private void _0006()
	{
		_ = 5;
		if (6 == 0)
		{
		}
		if (this.m__0002 == null)
		{
			throw new Exception();
		}
	}

	public byte[] _0002(int _0002)
	{
		if (_0002 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (2u != 0)
		{
			_0006();
		}
		byte[] array = new byte[_0002];
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		int num;
		if (3u != 0)
		{
			num = 0;
		}
		do
		{
			int num2 = this.m__0002._0005_2008_2009_0002(array2, num, _0002);
			if (num2 == 0)
			{
				break;
			}
			num += num2;
			_0002 -= num2;
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

	private void _0002(int _0002)
	{
		if (4u != 0)
		{
			_0006();
		}
		int num;
		if (6u != 0)
		{
			num = 0;
		}
		if (true)
		{
			int num2 = 0;
		}
		if (_0002 == 1)
		{
			int num2 = this.m__0002._0005_2008_2009_0002();
			if (num2 == -1)
			{
				throw new Exception();
			}
			this.m__0008[0] = (byte)num2;
			return;
		}
		do
		{
			int num2 = this.m__0002._0005_2008_2009_0002(this.m__0008, num, _0002 - num);
			if (num2 == 0)
			{
				throw new Exception();
			}
			num += num2;
		}
		while (num < _0002);
	}

	internal int _000F()
	{
		int num;
		if (5u != 0)
		{
			num = 0;
		}
		int num2;
		if (2u != 0)
		{
			num2 = 0;
		}
		byte b;
		do
		{
			if (num2 == 35)
			{
				throw new FormatException();
			}
			byte num3 = this._0002();
			if (2u != 0)
			{
				b = num3;
			}
			num |= (b & 0x7F) << num2;
			num2 += 7;
		}
		while ((b & 0x80) != 0);
		return num;
	}

	public int _0005()
	{
		if (_0008_2004)
		{
			return ((global::_0003)this.m__0002)._0006();
		}
		if (0 == 0)
		{
			_0002(4);
		}
		return this.m__0008[0] | (this.m__0008[3] << 24) | (this.m__0008[1] << 16) | (this.m__0008[2] << 8);
	}

	public uint _0002()
	{
		if (uint.MaxValue != 0)
		{
			_0002(4);
		}
		return (uint)((this.m__0008[3] << 16) | this.m__0008[1] | (this.m__0008[0] << 8) | (this.m__0008[2] << 24));
	}

	public long _0002()
	{
		if (3u != 0)
		{
			_0002(8);
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (5u != 0)
		{
			array2 = array;
		}
		return (uint)((array2[7] << 8) | (array2[2] << 24) | array2[0] | (array2[1] << 16)) | ((long)((array2[5] << 24) | (array2[6] << 16) | array2[4] | (array2[3] << 8)) << 32);
	}

	public ulong _0002()
	{
		if (5u != 0)
		{
			_0002(8);
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		return (ulong)((uint)((array2[2] << 16) | (array2[5] << 24) | (array2[4] << 8) | array2[6]) | ((long)((array2[1] << 16) | array2[0] | (array2[7] << 24) | (array2[3] << 8)) << 32));
	}

	public short _0002()
	{
		if (true)
		{
			_0002(2);
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		return (short)((array2[0] << 8) | array2[1]);
	}

	public ushort _0002()
	{
		if (true)
		{
			_0002(2);
		}
		byte[] array = this.m__0008;
		byte[] array2 = default(byte[]);
		if (0 == 0)
		{
			array2 = array;
		}
		return (ushort)(array2[1] | (array2[0] << 8));
	}

	private byte[] _0002()
	{
		byte[] array = _0006_2004;
		byte[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		if (array2 == null)
		{
			byte[] array3 = new byte[16];
			if (6u != 0)
			{
				array2 = array3;
			}
			if (6u != 0)
			{
				_0006_2004 = array3;
			}
		}
		return array2;
	}

	public float _0002()
	{
		if (6u != 0)
		{
			_0002(4);
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		byte[] array3 = _0002();
		byte[] array4;
		if (2u != 0)
		{
			array4 = array3;
		}
		array4[1] = array2[1];
		array4[3] = array2[0];
		array4[2] = array2[2];
		array4[0] = array2[3];
		return _0002(array4).ReadSingle();
	}

	public double _0002()
	{
		if (uint.MaxValue != 0)
		{
			_0002(8);
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		byte[] array3 = _0002();
		byte[] array4;
		if (4u != 0)
		{
			array4 = array3;
		}
		array4[5] = array2[1];
		array4[2] = array2[4];
		array4[0] = array2[2];
		array4[3] = array2[3];
		array4[7] = array2[0];
		array4[4] = array2[6];
		array4[1] = array2[5];
		array4[6] = array2[7];
		return _0002(array4).ReadDouble();
	}

	public decimal _0002()
	{
		if (8u != 0)
		{
			_0002(16);
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		byte[] array3 = _0002();
		array3[14] = array2[11];
		array3[5] = array2[12];
		array3[7] = array2[9];
		array3[6] = array2[1];
		array3[10] = array2[8];
		array3[11] = array2[10];
		array3[8] = array2[3];
		array3[0] = array2[14];
		array3[4] = array2[15];
		array3[3] = array2[13];
		array3[1] = array2[2];
		array3[2] = array2[6];
		array3[15] = array2[7];
		array3[9] = array2[4];
		array3[12] = array2[0];
		array3[13] = array2[5];
		return global::_0002_2004_2005._0002(array3);
	}

	private BinaryReader _0002(byte[] _0002)
	{
		MemoryStream memoryStream = _000F_2004;
		MemoryStream memoryStream2;
		if (2u != 0)
		{
			memoryStream2 = memoryStream;
		}
		BinaryReader binaryReader = _0005_2004;
		BinaryReader binaryReader2;
		if (4u != 0)
		{
			binaryReader2 = binaryReader;
		}
		if (memoryStream2 == null)
		{
			MemoryStream memoryStream3 = new MemoryStream(8);
			if (2u != 0)
			{
				memoryStream2 = memoryStream3;
			}
			_000F_2004 = memoryStream3;
			binaryReader2 = (_0005_2004 = new BinaryReader(memoryStream2));
		}
		else
		{
			binaryReader2.BaseStream.Position = 0L;
		}
		memoryStream2.Write(_0002, 0, _0002.Length);
		memoryStream2.Position = 0L;
		return binaryReader2;
	}
}
internal static class _0002_2005
{
	private static readonly global::_0006_2005 m__0002;

	private static readonly byte[] _0008;

	private static global::_0002_2000 _0006;

	private static readonly object _000F;

	private static bool _0005;

	static _0002_2005()
	{
		global::_0006_2005 obj = global::_0006_2005._0008(65537uL);
		if (7u != 0)
		{
			global::_0002_2005.m__0002 = obj;
		}
		byte[] array = _0002();
		if (2u != 0)
		{
			_0008 = array;
		}
		object obj2 = new object();
		if (3u != 0)
		{
			_000F = obj2;
		}
	}

	private static void _0002()
	{
		if (_0005)
		{
			return;
		}
		object obj = _000F;
		object obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (8u != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (7u != 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			if (!_0005)
			{
				global::_0006_2005 obj3 = new global::_0006_2005(1, _0008);
				global::_0008_200A obj4 = new global::_0008_200A(_0002: false, obj3, global::_0002_2005.m__0002);
				_0006 = new global::_0002_2000(_0002: true, obj4);
				_0005 = true;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	private static byte[] _0002()
	{
		return null;
	}

	public static bool _0002(object _0002, byte[] _0008, ulong _0006, int _000F)
	{
		if (_0008 == null)
		{
			return false;
		}
		if (global::_0002_2005._0002(_0002))
		{
			switch (_000F)
			{
			case 1:
				throw new ArgumentNullException(global::_0008_0010._0002(-1463127246));
			case 2:
				throw new NullReferenceException(global::_0008_0010._0002(-1463127246));
			case 0:
			{
				if (3u != 0)
				{
					return false;
				}
				bool result;
				return result;
			}
			default:
				throw new ArgumentOutOfRangeException(global::_0008_0010._0002(-1463127234));
			}
		}
		if (8u != 0)
		{
			global::_0002_2005._0002();
		}
		byte[] array = global::_0005_2000._0002(_0002, _0006, global::_0002_2005._0006, null);
		byte[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		return global::_0002_2005._0002(_0008, array2);
	}

	private static bool _0002(byte[] _0002, byte[] _0008)
	{
		if (_0002.Length != _0008.Length)
		{
			return false;
		}
		int num;
		if (3u != 0)
		{
			num = 0;
		}
		while (num < _0002.Length)
		{
			if (_0002[num] != _0008[num])
			{
				return false;
			}
			int num2 = num + 1;
			if (8u != 0)
			{
				num = num2;
			}
		}
		return true;
	}

	public static byte[] _0002(object[] _0002, byte[] _0008, ulong _0006)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463127081));
		}
		if (_0008 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463127104));
		}
		MemoryStream memoryStream = new MemoryStream();
		MemoryStream memoryStream2;
		if (8u != 0)
		{
			memoryStream2 = memoryStream;
		}
		byte[] array3;
		try
		{
			object[] array;
			if (true)
			{
				array = _0002;
			}
			int i;
			if (7u != 0)
			{
				i = 0;
			}
			for (; i < array.Length; i++)
			{
				byte[] array2 = global::_0005_2000._0002(array[i]);
				memoryStream2.Write(array2, 0, array2.Length);
			}
			array3 = memoryStream2.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream2)?.Dispose();
		}
		return new global::_000E_2003(array3, (long)_0006)._0002(_0008);
	}

	internal static bool _0002(object _0002)
	{
		if (_0002 == null)
		{
			return true;
		}
		if (!(_0002 is string))
		{
			IEnumerable obj = _0002 as IEnumerable;
			IEnumerable enumerable;
			if (uint.MaxValue != 0)
			{
				enumerable = obj;
			}
			if (enumerable != null)
			{
				IEnumerator enumerator = enumerable.GetEnumerator();
				IEnumerator enumerator2;
				if (4u != 0)
				{
					enumerator2 = enumerator;
				}
				try
				{
					while (enumerator2.MoveNext())
					{
						if (global::_0002_2005._0002(enumerator2.Current))
						{
							if (5u != 0)
							{
								return true;
							}
							bool result;
							return result;
						}
					}
				}
				finally
				{
					if (enumerator2 is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
			}
		}
		return false;
	}
}
internal sealed class _0002_2006
{
	private int m__0002;

	private bool _0008;

	public _0002_2006()
	{
		_ = 8;
		if (7 == 0)
		{
		}
		base._002Ector();
	}

	public int _0002()
	{
		_ = 6;
		if (7 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (uint.MaxValue != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public bool _0002()
	{
		_ = 1;
		if (7 == 0)
		{
		}
		return _0008;
	}

	public void _0002(bool _0002)
	{
		if (4u != 0)
		{
			_0008 = _0002;
		}
	}
}
internal interface _0002_2007
{
	int _0002_2007_2008_2009_0002();

	int _0002_2007_2008_2009_0008();

	int _0002_2007_2008_2009_0002(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005, RandomNumberGenerator _0003);
}
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
[global::_0006_2006]
internal sealed class _0002_2007_2005 : Attribute
{
	public readonly byte[] _0002;

	public _0002_2007_2005(byte _0002)
	{
		byte[] obj = new byte[1] { _0002 };
		if (true)
		{
			this._0002 = obj;
		}
	}

	public _0002_2007_2005(byte[] _0002)
	{
		if (uint.MaxValue != 0)
		{
			this._0002 = _0002;
		}
	}
}
internal static class _0002_2008
{
	private static class _0002
	{
		public static readonly Dictionary<Type, int> _0002;

		static _0002()
		{
			Dictionary<Type, int> obj = new Dictionary<Type, int>
			{
				{
					typeof(object),
					7
				},
				{
					typeof(byte),
					12
				},
				{
					typeof(sbyte),
					17
				},
				{
					typeof(short),
					26
				},
				{
					typeof(int),
					1
				},
				{
					typeof(long),
					13
				},
				{
					typeof(ushort),
					16
				},
				{
					typeof(uint),
					3
				},
				{
					typeof(ulong),
					14
				},
				{
					typeof(IntPtr),
					0
				},
				{
					typeof(UIntPtr),
					20
				},
				{
					typeof(float),
					22
				},
				{
					typeof(double),
					8
				},
				{
					typeof(bool),
					15
				},
				{
					typeof(char),
					6
				},
				{
					typeof(string),
					10
				}
			};
			if (2u != 0)
			{
				_0002 = obj;
			}
		}
	}

	public static readonly Type _0002;

	public static readonly Type _0008;

	public static readonly Type _0006;

	public static readonly Type _000F;

	public static readonly Type _0005;

	public static readonly Assembly _0003;

	static _0002_2008()
	{
		Type typeFromHandle = typeof(object);
		if (7u != 0)
		{
			global::_0002_2008._0002 = typeFromHandle;
		}
		Type typeFromHandle2 = typeof(ValueType);
		if (5u != 0)
		{
			global::_0002_2008._0008 = typeFromHandle2;
		}
		Type typeFromHandle3 = typeof(Enum);
		if (8u != 0)
		{
			_0006 = typeFromHandle3;
		}
		_000F = typeof(Nullable<>);
		_0005 = typeof(void);
		_0003 = typeof(global::_0002_2008).Assembly;
	}

	public static bool _0002(Type _0002)
	{
		_ = 3;
		if (-1 == 0)
		{
		}
		if (_0002.IsGenericType)
		{
			_ = 8;
			if (false)
			{
			}
			if (!_0002.IsGenericTypeDefinition)
			{
				_ = 4;
				if (5 == 0)
				{
				}
				return _0002.GetGenericTypeDefinition() == _000F;
			}
		}
		return false;
	}

	public static Type _0002(Type _0002)
	{
		while (_0002.HasElementType)
		{
			Type elementType = _0002.GetElementType();
			if (6u != 0)
			{
				_0002 = elementType;
			}
		}
		return _0002;
	}

	public static Type _0008(Type _0002)
	{
		if (_0002.HasElementType && !_0002.IsArray)
		{
			Type elementType = _0002.GetElementType();
			if (6u != 0)
			{
				_0002 = elementType;
			}
		}
		return _0002;
	}

	public static Stack<global::_000E_2002> _0002(Type _0002)
	{
		Stack<global::_000E_2002> stack = new Stack<global::_000E_2002>();
		Stack<global::_000E_2002> stack2;
		if (4u != 0)
		{
			stack2 = stack;
		}
		Type type = default(Type);
		if (0 == 0)
		{
			type = _0002;
		}
		while (true)
		{
			if (type.IsArray)
			{
				global::_000E_2002 item = default(global::_000E_2002);
				if (8u != 0)
				{
					item._0002 = 2;
				}
				item._0008 = type.GetArrayRank();
				stack2.Push(item);
			}
			else if (type.IsByRef)
			{
				stack2.Push(new global::_000E_2002
				{
					_0002 = 1
				});
			}
			else
			{
				if (!type.IsPointer)
				{
					break;
				}
				stack2.Push(new global::_000E_2002
				{
					_0002 = 0
				});
			}
			type = type.GetElementType();
		}
		return stack2;
	}

	public static Stack<global::_000E_2002> _0002(string _0002)
	{
		string text;
		if (2u != 0)
		{
			text = _0002;
		}
		Stack<global::_000E_2002> stack = new Stack<global::_000E_2002>();
		Stack<global::_000E_2002> stack2;
		if (8u != 0)
		{
			stack2 = stack;
		}
		while (true)
		{
			if (text.EndsWith(global::_0008_0010._0002(-1463127231), StringComparison.Ordinal))
			{
				global::_000E_2002 item = default(global::_000E_2002);
				if (7u != 0)
				{
					item._0002 = 1;
				}
				stack2.Push(item);
				string text2 = text.Substring(0, text.Length - 1);
				if (8u != 0)
				{
					text = text2;
				}
				continue;
			}
			if (text.EndsWith(global::_0008_0010._0002(-1463127223), StringComparison.Ordinal))
			{
				stack2.Push(new global::_000E_2002
				{
					_0002 = 0
				});
				text = text.Substring(0, text.Length - 1);
				continue;
			}
			if (text.EndsWith(global::_0008_0010._0002(-1463127183), StringComparison.Ordinal))
			{
				stack2.Push(new global::_000E_2002
				{
					_0002 = 2,
					_0008 = 1
				});
				text = text.Substring(0, text.Length - 2);
				continue;
			}
			if (!text.EndsWith(global::_0008_0010._0002(-1463127176), StringComparison.Ordinal))
			{
				break;
			}
			int num = 1;
			int num2 = -1;
			for (int num3 = text.Length - 2; num3 >= 0; num3--)
			{
				switch (text[num3])
				{
				case ',':
					num++;
					break;
				case '[':
					num2 = num3;
					num3 = -1;
					break;
				default:
					throw new InvalidOperationException(global::_0008_0010._0002(-1463127197));
				}
			}
			if (num2 < 0)
			{
				throw new InvalidOperationException(global::_0008_0010._0002(-1463127279));
			}
			text = text.Substring(0, num2);
			stack2.Push(new global::_000E_2002
			{
				_0002 = 2,
				_0008 = num
			});
		}
		return stack2;
	}

	public static Type _0002(Type _0002, Stack<global::_000E_2002> _0008)
	{
		Type type;
		if (6u != 0)
		{
			type = _0002;
		}
		while (_0008.Count > 0)
		{
			global::_000E_2002 obj = _0008.Pop();
			global::_000E_2002 obj2;
			if (5u != 0)
			{
				obj2 = obj;
			}
			int num = obj2._0002;
			int num2;
			if (5u != 0)
			{
				num2 = num;
			}
			switch (num2)
			{
			case 2:
				type = ((obj2._0008 != 1) ? type.MakeArrayType(obj2._0008) : type.MakeArrayType());
				break;
			case 1:
				type = type.MakeByRefType();
				break;
			case 0:
				type = type.MakePointerType();
				break;
			}
		}
		return type;
	}

	public static int _0002(Type _0002)
	{
		Dictionary<Type, int> dictionary = global::_0002_2008._0002._0002;
		_ = 3;
		if (5 == 0)
		{
		}
		if (dictionary.TryGetValue(_0002, out var value))
		{
			int result = value;
			_ = 6;
			if (3 == 0)
			{
			}
			return result;
		}
		_ = 5;
		if (5 == 0)
		{
		}
		if (_0002.IsArray)
		{
			return 9;
		}
		if (_0002.IsValueType)
		{
			if (_0002.IsSubclassOf(_0006))
			{
				return 19;
			}
			if (global::_0002_2008._0002(_0002))
			{
				return 5;
			}
			return 25;
		}
		return 4;
	}
}
internal interface _0002_2009 : IDisposable
{
	int _0002_2009_2008_2009_0002();

	void _0002_2009_2008_2009_0002(int _0002, out byte _0008);

	void _0002_2009_2008_2009_0008(int _0002, ref byte _0008);

	void _0002_2009_2008_2009_0002();

	global::_0002_2009 _0002_2009_2008_2009_0002();
}
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCode]
internal sealed class _0002_2009_2005
{
	private static ResourceManager m__0002;

	private static CultureInfo _0008;

	internal _0002_2009_2005()
	{
		_ = 8;
		if (false)
		{
		}
		base._002Ector();
	}

	internal static ResourceManager _0002()
	{
		if (global::_0002_2009_2005.m__0002 == null)
		{
			ResourceManager resourceManager = new ResourceManager(global::_0008_0010._0002(-1463126223), typeof(global::_0002_2009_2005).Assembly);
			if (6u != 0)
			{
				global::_0002_2009_2005.m__0002 = resourceManager;
			}
		}
		return global::_0002_2009_2005.m__0002;
	}

	internal static CultureInfo _0002()
	{
		return _0008;
	}

	internal static void _0002(CultureInfo _0002)
	{
		if (0 == 0)
		{
			_0008 = _0002;
		}
	}

	internal static string _0002()
	{
		return global::_0002_2009_2005._0002().GetString(global::_0008_0010._0002(-1463126214), _0008);
	}
}
internal sealed class _0002_200A : global::_0005_2004
{
	private int m__0002;

	private int m__0008;

	public _0002_200A()
	{
		_ = 5;
		if (5 == 0)
		{
		}
		base._002Ector();
	}

	public int _0002()
	{
		_ = 4;
		if (8 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public int _0008()
	{
		_ = 6;
		if (7 == 0)
		{
		}
		return this.m__0008;
	}

	public void _0008(int _0002)
	{
		if (true)
		{
			this.m__0008 = _0002;
		}
	}

	[SpecialName]
	public override byte _0005_2004_2008_2009_0002()
	{
		return 3;
	}
}
internal sealed class _0003 : global::_0005, IDisposable
{
	private byte[] m__0002;

	private int m__0008;

	private int m__0006;

	private int _000F;

	private int _0005;

	private bool m__0003;

	private bool _000E;

	private bool _0002_2004;

	private bool _0008_2004;

	public _0003()
	{
		_ = 4;
		if (2 == 0)
		{
		}
		this._002Ector(0);
	}

	public _0003(int _0002)
	{
		if (_0002 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		byte[] array = new byte[_0002];
		if (8u != 0)
		{
			this.m__0002 = array;
		}
		if (true)
		{
			_0005 = _0002;
		}
		if (0 == 0)
		{
			m__0003 = true;
		}
		_000E = true;
		this.m__0008 = 0;
		_0002_2004 = true;
	}

	public _0003(byte[] _0002)
	{
		_ = 7;
		if (5 == 0)
		{
		}
		_ = 7;
		if (1 == 0)
		{
		}
		this._002Ector(_0002, _0008: true);
	}

	public _0003(byte[] _0002, bool _0008)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
		int num = _0002.Length;
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		if (uint.MaxValue != 0)
		{
			_0005 = num;
		}
		_000F = num2;
		_000E = _0008;
		this.m__0008 = 0;
		_0002_2004 = true;
	}

	public _0003(byte[] _0002, int _0008, int _0006)
	{
		_ = 5;
		if (1 == 0)
		{
		}
		_ = 4;
		if (false)
		{
		}
		_ = 2;
		if (6 == 0)
		{
		}
		this._002Ector(_0002, _0008, _0006, _000F: true);
	}

	public _0003(byte[] _0002, int _0008, int _0006, bool _000F)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
		int num;
		if (6u != 0)
		{
			num = _0008;
		}
		if (2u != 0)
		{
			this.m__0006 = _0008;
		}
		this.m__0008 = num;
		this._000F = (_0005 = _0008 + _0006);
		_000E = _000F;
		m__0003 = false;
		_0002_2004 = true;
	}

	[SpecialName]
	public override bool _0005_2008_2009_0002()
	{
		_ = 3;
		if (5 == 0)
		{
		}
		return _0002_2004;
	}

	[SpecialName]
	public override bool _0005_2008_2009_0006()
	{
		_ = 5;
		if (3 == 0)
		{
		}
		return _0002_2004;
	}

	[SpecialName]
	public override bool _0005_2008_2009_0008()
	{
		_ = 1;
		if (2 == 0)
		{
		}
		return _000E;
	}

	protected override void _0005_2008_2009_0002(bool _0002)
	{
		if (_0008_2004)
		{
			return;
		}
		if (_0002)
		{
			if (7u != 0)
			{
				_0002_2004 = false;
			}
			if (2u != 0)
			{
				_000E = false;
			}
			if (8u != 0)
			{
				m__0003 = false;
			}
		}
		_0008_2004 = true;
	}

	private bool _0002(int _0002)
	{
		if (_0002 < 0)
		{
			throw new IOException();
		}
		if (_0002 > _0005)
		{
			int num;
			if (4u != 0)
			{
				num = _0002;
			}
			if (num < 256)
			{
				if (uint.MaxValue != 0)
				{
					num = 256;
				}
			}
			if (num < _0005 * 2)
			{
				int num2 = _0005 * 2;
				if (6u != 0)
				{
					num = num2;
				}
			}
			this._0002(num);
			return true;
		}
		return false;
	}

	public override void _0005_2008_2009_0008()
	{
	}

	internal byte[] _0002()
	{
		_ = -1;
		if (3 == 0)
		{
		}
		return this.m__0002;
	}

	internal void _0002(out int _0002, out int _0008)
	{
		_ = 7;
		if (1 == 0)
		{
		}
		if (!_0002_2004)
		{
			throw new Exception();
		}
		_ = 0;
		if (6 == 0)
		{
		}
		_ = 7;
		if (-1 == 0)
		{
		}
		_0002 = this.m__0008;
		_0008 = _000F;
	}

	internal int _0002()
	{
		_ = 3;
		if (3 == 0)
		{
		}
		if (!_0002_2004)
		{
			throw new Exception();
		}
		_ = 3;
		if (6 == 0)
		{
		}
		return this.m__0006;
	}

	public int _0002(int _0002)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		int num = _000F - this.m__0006;
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		if (num2 > _0002)
		{
			if (4u != 0)
			{
				num2 = _0002;
			}
		}
		if (num2 < 0)
		{
			if (3u != 0)
			{
				num2 = 0;
			}
		}
		this.m__0006 += num2;
		return num2;
	}

	public int _0008()
	{
		_ = 7;
		if (8 == 0)
		{
		}
		if (!_0002_2004)
		{
			throw new Exception();
		}
		_ = -1;
		if (7 == 0)
		{
		}
		int num = _0005;
		_ = 7;
		if (8 == 0)
		{
		}
		return num - this.m__0008;
	}

	public void _0002(int _0002)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (_0002 == _0005)
		{
			return;
		}
		if (!m__0003)
		{
			throw new Exception();
		}
		if (_0002 < _000F)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002 > 0)
		{
			byte[] array = new byte[_0002];
			byte[] array2;
			if (5u != 0)
			{
				array2 = array;
			}
			if (_000F > 0)
			{
				byte[] src = this.m__0002;
				int count = _000F;
				if (true)
				{
					Buffer.BlockCopy(src, 0, array2, 0, count);
				}
			}
			if (uint.MaxValue != 0)
			{
				this.m__0002 = array2;
			}
		}
		else
		{
			this.m__0002 = null;
		}
		_0005 = _0002;
	}

	[SpecialName]
	public override long _0005_2008_2009_0002()
	{
		_ = 5;
		if (3 == 0)
		{
		}
		if (!_0002_2004)
		{
			throw new Exception();
		}
		_ = 2;
		if (2 == 0)
		{
		}
		int num = _000F;
		_ = 4;
		if (2 == 0)
		{
		}
		return num - this.m__0008;
	}

	[SpecialName]
	public override long _0005_2008_2009_0008()
	{
		_ = 6;
		if (5 == 0)
		{
		}
		if (!_0002_2004)
		{
			throw new Exception();
		}
		_ = 1;
		if (6 == 0)
		{
		}
		int num = this.m__0006;
		_ = 7;
		if (4 == 0)
		{
		}
		return num - this.m__0008;
	}

	[SpecialName]
	public override void _0005_2008_2009_0002(long _0002)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (_0002 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002 > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = this.m__0008 + (int)_0002;
		if (3u != 0)
		{
			this.m__0006 = num;
		}
	}

	public override int _0005_2008_2009_0002(byte[] _0002, int _0008, int _0006)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		int num = _000F - this.m__0006;
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		if (num2 > _0006)
		{
			if (7u != 0)
			{
				num2 = _0006;
			}
		}
		if (num2 <= 0)
		{
			return 0;
		}
		if (num2 <= 8)
		{
			int num3 = num2;
			int num4;
			if (8u != 0)
			{
				num4 = num3;
			}
			while (--num4 >= 0)
			{
				_0002[_0008 + num4] = this.m__0002[this.m__0006 + num4];
			}
		}
		else
		{
			Buffer.BlockCopy(this.m__0002, this.m__0006, _0002, _0008, num2);
		}
		this.m__0006 += num2;
		return num2;
	}

	public override int _0005_2008_2009_0002()
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (this.m__0006 >= _000F)
		{
			return -1;
		}
		byte[] array = this.m__0002;
		int num = this.m__0006;
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		int num3 = num2 + 1;
		if (3u != 0)
		{
			this.m__0006 = num3;
		}
		return array[num2];
	}

	public override long _0005_2008_2009_0002(long _0002, int _0008)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (_0002 > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		switch (_0008)
		{
		case 0:
		{
			if (_0002 < 0)
			{
				throw new IOException();
			}
			int num2 = this.m__0008 + (int)_0002;
			if (4u != 0)
			{
				this.m__0006 = num2;
			}
			break;
		}
		case 1:
		{
			if (_0002 + this.m__0006 < this.m__0008)
			{
				throw new IOException();
			}
			int num3 = this.m__0006 + (int)_0002;
			if (true)
			{
				this.m__0006 = num3;
			}
			break;
		}
		case 2:
		{
			if (_000F + _0002 < this.m__0008)
			{
				throw new IOException();
			}
			int num = _000F + (int)_0002;
			if (5u != 0)
			{
				this.m__0006 = num;
			}
			break;
		}
		default:
			throw new ArgumentException();
		}
		return this.m__0006;
	}

	public override void _0005_2008_2009_0008(long _0002)
	{
		if (!_000E)
		{
			throw new Exception();
		}
		if (_0002 > int.MaxValue)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002 < 0 || _0002 > int.MaxValue - this.m__0008)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = this.m__0008 + (int)_0002;
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		if (!this._0002(num2) && num2 > _000F)
		{
			byte[] array = this.m__0002;
			int index = _000F;
			int length = num2 - _000F;
			if (3u != 0)
			{
				Array.Clear(array, index, length);
			}
		}
		if (2u != 0)
		{
			_000F = num2;
		}
		if (this.m__0006 > num2)
		{
			this.m__0006 = num2;
		}
	}

	public byte[] _0008()
	{
		byte[] array = new byte[_000F - this.m__0008];
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		byte[] src = this.m__0002;
		int srcOffset = this.m__0008;
		int count = _000F - this.m__0008;
		if (3u != 0)
		{
			Buffer.BlockCopy(src, srcOffset, array2, 0, count);
		}
		return array2;
	}

	public override void _0005_2008_2009_0002(byte[] _0002, int _0008, int _0006)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (!_000E)
		{
			throw new Exception();
		}
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		int num = this.m__0006 + _0006;
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		if (num2 < 0)
		{
			throw new IOException();
		}
		if (num2 > _000F)
		{
			bool num3 = this.m__0006 > _000F;
			bool flag;
			if (3u != 0)
			{
				flag = num3;
			}
			if (num2 > _0005 && this._0002(num2))
			{
				if (true)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Array.Clear(this.m__0002, _000F, num2 - _000F);
			}
			_000F = num2;
		}
		if (_0006 <= 8)
		{
			int num4 = _0006;
			while (--num4 >= 0)
			{
				this.m__0002[this.m__0006 + num4] = _0002[_0008 + num4];
			}
		}
		else
		{
			Buffer.BlockCopy(_0002, _0008, this.m__0002, this.m__0006, _0006);
		}
		this.m__0006 = num2;
	}

	public override void _0005_2008_2009_0002(byte _0002)
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		if (!_000E)
		{
			throw new Exception();
		}
		if (this.m__0006 >= _000F)
		{
			int num = this.m__0006 + 1;
			int num2;
			if (7u != 0)
			{
				num2 = num;
			}
			bool num3 = this.m__0006 > _000F;
			bool flag;
			if (2u != 0)
			{
				flag = num3;
			}
			if (num2 >= _0005 && this._0002(num2))
			{
				if (2u != 0)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Array.Clear(this.m__0002, _000F, this.m__0006 - _000F);
			}
			_000F = num2;
		}
		this.m__0002[this.m__0006++] = _0002;
	}

	public void _0002(Stream _0002)
	{
		_ = 8;
		if (6 == 0)
		{
		}
		if (!_0002_2004)
		{
			throw new Exception();
		}
		_ = 4;
		if (-1 == 0)
		{
		}
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		_ = 7;
		if (1 == 0)
		{
		}
		_0002.Write(this.m__0002, this.m__0008, _000F - this.m__0008);
	}

	internal int _0006()
	{
		if (!_0002_2004)
		{
			throw new Exception();
		}
		int num = this.m__0006 + 4;
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		if (8u != 0)
		{
			this.m__0006 = num;
		}
		int num3;
		if (3u != 0)
		{
			num3 = num2;
		}
		if (num3 > _000F)
		{
			this.m__0006 = _000F;
			throw new Exception();
		}
		return (this.m__0002[num3 - 1] << 24) | (this.m__0002[num3 - 2] << 8) | (this.m__0002[num3 - 3] << 16) | this.m__0002[num3 - 4];
	}
}
internal sealed class _0003_2000 : global::_0006
{
	private new long m__0002;

	public _0003_2000()
	{
		_ = 0;
		if (6 == 0)
		{
		}
		base._002Ector(13);
	}

	public _0003_2000(long _0002)
		: this()
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new long _0002()
	{
		_ = 0;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(long _0002)
	{
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 7;
		if (-1 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (_0002 is ulong)
		{
			ulong num = (ulong)_0002;
			if (3u != 0)
			{
				this._0002((long)num);
			}
		}
		else if (_0002 is float)
		{
			long num2 = (long)(float)_0002;
			if (3u != 0)
			{
				this._0002(num2);
			}
		}
		else if (_0002 is double)
		{
			long num3 = (long)(double)_0002;
			if (6u != 0)
			{
				this._0002(num3);
			}
		}
		else
		{
			this._0002(Convert.ToInt64(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0003_2000 obj = new global::_0003_2000();
		_ = 6;
		if (3 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = -1;
		if (1 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (6u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 15:
		{
			long num3 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (7u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 12:
			this._0002(((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002(((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002(((global::_000F)_0002)._0002());
			break;
		case 17:
			this._0002(((global::_0003_2001)_0002)._0002());
			break;
		case 16:
			this._0002(((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002(((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002(((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002((long)((global::_000E_2006)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToInt64(((global::_0002_0010)_0002)._0002()));
			break;
		case 7:
			this._0002(Convert.ToInt64(((global::_0005_2003)_0002)._0002()));
			break;
		case 0:
			this._0002((long)((global::_0006_2002)_0002)._0002());
			break;
		case 20:
			this._0002((long)(ulong)((global::_0002_2003)_0002)._0002());
			break;
		case 22:
			this._0002((long)((global::_000F_200B)_0002)._0002());
			break;
		case 8:
			this._0002((long)((global::_0006_200A)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal sealed class _0003_2001 : global::_0006
{
	private new sbyte m__0002;

	public _0003_2001()
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		base._002Ector(17);
	}

	public new sbyte _0002()
	{
		_ = 3;
		if (2 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(sbyte _0002)
	{
		if (8u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 1;
		if (2 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (_0002 is byte)
		{
			sbyte num = (sbyte)(byte)_0002;
			if (4u != 0)
			{
				this._0002(num);
			}
		}
		else if (_0002 is short)
		{
			sbyte num2 = (sbyte)(short)_0002;
			if (7u != 0)
			{
				this._0002(num2);
			}
		}
		else if (_0002 is int)
		{
			sbyte num3 = (sbyte)(int)_0002;
			if (0 == 0)
			{
				this._0002(num3);
			}
		}
		else if (_0002 is long)
		{
			this._0002((sbyte)(long)_0002);
		}
		else if (_0002 is ushort)
		{
			this._0002((sbyte)(ushort)_0002);
		}
		else if (_0002 is uint)
		{
			this._0002((sbyte)(uint)_0002);
		}
		else if (_0002 is ulong)
		{
			this._0002((sbyte)(ulong)_0002);
		}
		else if (_0002 is float)
		{
			this._0002((sbyte)(float)_0002);
		}
		else if (_0002 is double)
		{
			this._0002((sbyte)(double)_0002);
		}
		else
		{
			this._0002(Convert.ToSByte(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0003_2001 obj = new global::_0003_2001();
		_ = 7;
		if (false)
		{
		}
		obj._0002(this.m__0002);
		_ = 1;
		if (5 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (0 == 0)
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
		case 15:
		{
			sbyte num3 = Convert.ToSByte(((global::_0005_200A)_0002)._0002());
			if (true)
			{
				this._0002(num3);
			}
			break;
		}
		case 17:
			this._0002(((global::_0003_2001)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToSByte(((global::_0002_0010)_0002)._0002()));
			break;
		case 12:
			this._0002((sbyte)((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002((sbyte)((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((sbyte)((global::_000F)_0002)._0002());
			break;
		case 16:
			this._0002((sbyte)((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002((sbyte)((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002((sbyte)((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002((sbyte)((global::_000E_2006)_0002)._0002());
			break;
		case 7:
			this._0002(Convert.ToSByte(((global::_0005_2003)_0002)._0002()));
			break;
		case 0:
			this._0002((sbyte)(int)((global::_0006_2002)_0002)._0002());
			break;
		case 22:
			this._0002((sbyte)((global::_000F_200B)_0002)._0002());
			break;
		case 8:
			this._0002((sbyte)((global::_0006_200A)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal static class _0003_2002
{
	private static readonly bool m__0002;

	private static readonly bool m__0008;

	static _0003_2002()
	{
		OperatingSystem oSVersion = Environment.OSVersion;
		OperatingSystem operatingSystem = default(OperatingSystem);
		if (0 == 0)
		{
			operatingSystem = oSVersion;
		}
		bool num = operatingSystem.Platform == PlatformID.Win32NT && operatingSystem.Version >= new Version(6, 0);
		if (2u != 0)
		{
			global::_0003_2002.m__0002 = num;
		}
		if (!_0002())
		{
			return;
		}
		try
		{
			bool num2 = _0002(operatingSystem);
			if (true)
			{
				global::_0003_2002.m__0008 = num2;
			}
		}
		catch
		{
			global::_0003_2002.m__0008 = false;
		}
	}

	public static bool _0002()
	{
		return global::_0003_2002.m__0002;
	}

	public static bool _0008()
	{
		return global::_0003_2002.m__0008;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0002(OperatingSystem _0002)
	{
		_ = 5;
		if (false)
		{
		}
		if (_0002.Platform == PlatformID.Win32NT)
		{
			_ = 4;
			if (1 == 0)
			{
			}
			if (_0002.Version < new Version(6, 2, 9200) && Process.GetCurrentProcess().SessionId == 0)
			{
				return false;
			}
		}
		return true;
	}
}
internal abstract class _0003_2003
{
	private readonly SymmetricAlgorithm[] m__0002;

	public _0003_2003(byte[] _0002, long _0008)
	{
		_ = -1;
		if (1 == 0)
		{
		}
		_ = 7;
		if (2 == 0)
		{
		}
		_ = 7;
		if (7 == 0)
		{
		}
		this._002Ector(_0002, global::_0003_2003._0002(_0008));
	}

	public _0003_2003(byte[] _0002, byte[] _0008)
	{
		global::_000E_2004_2005 obj = new global::_000E_2004_2005(_0002, _0008, 1);
		global::_000E_2004_2005 obj2 = default(global::_000E_2004_2005);
		if (0 == 0)
		{
			obj2 = obj;
		}
		SymmetricAlgorithm[] array = new SymmetricAlgorithm[5];
		SymmetricAlgorithm[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = array;
		}
		int i;
		if (6u != 0)
		{
			i = 0;
		}
		for (; i < 5; i++)
		{
			global::_0008_2001 obj3 = new global::_0008_2001(new global::_0003_2009());
			obj3.Key = obj2.GetBytes(obj3.KeySize / 8);
			obj3.IV = obj2.GetBytes(obj3._0002() / 8);
			array2[i] = obj3;
		}
		this.m__0002 = array2;
	}

	protected static int _0002(int _0002)
	{
		_ = 7;
		if (false)
		{
		}
		return (_0002 + 3) / 4 * 4;
	}

	public static int _0008(int _0002)
	{
		_ = 2;
		if (6 == 0)
		{
		}
		return global::_0003_2003._0002(_0002 + 4);
	}

	protected static byte[] _0002(long _0002)
	{
		byte[] array = new byte[8];
		byte[] array2 = default(byte[]);
		if (0 == 0)
		{
			array2 = array;
		}
		byte[] array3 = array2;
		if (uint.MaxValue != 0)
		{
			global::_0003_2003._0002(_0002, array3, 0);
		}
		return array2;
	}

	protected static void _0002(long _0002, byte[] _0008, int _0006)
	{
		_ = 6;
		if (5 == 0)
		{
		}
		_ = 3;
		if (8 == 0)
		{
		}
		_ = 2;
		if (-1 == 0)
		{
		}
		_0008[_0006] = (byte)_0002;
		_0008[_0006 + 1] = (byte)(_0002 >> 8);
		_0008[_0006 + 2] = (byte)(_0002 >> 16);
		_0008[_0006 + 3] = (byte)(_0002 >> 24);
		_0008[_0006 + 4] = (byte)(_0002 >> 32);
		_0008[_0006 + 5] = (byte)(_0002 >> 40);
		_0008[_0006 + 6] = (byte)(_0002 >> 48);
		_0008[_0006 + 7] = (byte)(_0002 >> 56);
	}

	protected static int _0002(byte[] _0002, int _0008)
	{
		_ = 5;
		if (1 == 0)
		{
		}
		_ = 0;
		if (8 == 0)
		{
		}
		byte num = _0002[_0008];
		_ = 4;
		if (4 == 0)
		{
		}
		return num | (_0002[_0008 + 1] << 8) | (_0002[_0008 + 2] << 16) | (_0002[_0008 + 3] << 24);
	}

	protected static void _0002(int _0002, byte[] _0008, int _0006)
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		_ = -1;
		if (8 == 0)
		{
		}
		_ = 6;
		if (7 == 0)
		{
		}
		_0008[_0006] = (byte)_0002;
		_0008[_0006 + 1] = (byte)(_0002 >> 8);
		_0008[_0006 + 2] = (byte)(_0002 >> 16);
		_0008[_0006 + 3] = (byte)(_0002 >> 24);
	}

	protected byte[] _0002(byte[] _0002, bool _0008)
	{
		if (_0008)
		{
			SymmetricAlgorithm[] array = this.m__0002;
			SymmetricAlgorithm[] array2;
			if (7u != 0)
			{
				array2 = array;
			}
			int i;
			if (5u != 0)
			{
				i = 0;
			}
			SymmetricAlgorithm symmetricAlgorithm2 = default(SymmetricAlgorithm);
			for (; i < array2.Length; i++)
			{
				SymmetricAlgorithm symmetricAlgorithm = array2[i];
				if (0 == 0)
				{
					symmetricAlgorithm2 = symmetricAlgorithm;
				}
				if (_0008)
				{
					using ICryptoTransform cryptoTransform = symmetricAlgorithm2.CreateEncryptor();
					_0002 = cryptoTransform.TransformFinalBlock(_0002, 0, _0002.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform2 = symmetricAlgorithm2.CreateDecryptor();
					_0002 = cryptoTransform2.TransformFinalBlock(_0002, 0, _0002.Length);
				}
				_0008 = !_0008;
			}
		}
		else
		{
			for (int num = 4; num >= 0; num--)
			{
				SymmetricAlgorithm symmetricAlgorithm3 = this.m__0002[num];
				if (_0008)
				{
					using ICryptoTransform cryptoTransform3 = symmetricAlgorithm3.CreateEncryptor();
					_0002 = cryptoTransform3.TransformFinalBlock(_0002, 0, _0002.Length);
				}
				else
				{
					using ICryptoTransform cryptoTransform4 = symmetricAlgorithm3.CreateDecryptor();
					_0002 = cryptoTransform4.TransformFinalBlock(_0002, 0, _0002.Length);
				}
				_0008 = !_0008;
			}
		}
		return _0002;
	}
}
internal static class _0003_2003_2005
{
	internal sealed class _0002 : global::_0002_2003_2005<int>, global::_000E_2007_2005, global::_0005_2003_2005<int>, global::_0006_2003_2005, global::_0008_2003_2005
	{
		private int m__0002;

		private int m__0008;

		private int _0006;

		private int _000F;

		public int _0005;

		private int _0003;

		private int _000E;

		private global::_0005_2003_2005<int> _0002_2004;

		private int _0008_2004;

		[DebuggerHidden]
		public _0002(int _0002)
		{
			if (true)
			{
				this.m__0002 = _0002;
			}
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			if (uint.MaxValue != 0)
			{
				_0006 = managedThreadId;
			}
		}

		[DebuggerHidden]
		private void _0002_2008_2009_0002()
		{
			int num = m__0002;
			int num2;
			if (5u != 0)
			{
				num2 = num;
			}
			if (num2 == -3 || num2 == 1)
			{
				try
				{
				}
				finally
				{
					if (6u != 0)
					{
						_0008();
					}
				}
			}
			if (uint.MaxValue != 0)
			{
				_0002_2004 = null;
			}
			m__0002 = -2;
		}

		void global::_0006_2003_2005._0006_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			this._0002_2008_2009_0002();
		}

		private bool _0008_2003_2005_2008_2009_0002()
		{
			bool result;
			try
			{
				int num = m__0002;
				int num2;
				if (3u != 0)
				{
					num2 = num;
				}
				switch (num2)
				{
				default:
					if (3u != 0)
					{
						result = false;
					}
					goto end_IL_0000;
				case 0:
					if (7u != 0)
					{
						m__0002 = -1;
					}
					_0003 = 0;
					_000E = 1;
					_0002_2004 = ((global::_0002_2003_2005<int>)new _0008(-2)).GetEnumerator();
					m__0002 = -3;
					break;
				case 1:
					m__0002 = -3;
					_000F--;
					if (_000F != 0)
					{
						int num3 = _000E;
						_000E = (num3 + _0003 + _000F) ^ (-1358275320 + _0008_2004);
						_0003 = num3;
						break;
					}
					result = false;
					_0008();
					goto end_IL_0000;
				}
				if (((global::_0008_2003_2005)_0002_2004)._0008_2003_2005_2008_2009_0002())
				{
					_0008_2004 = _0002_2004._0008_2003_2005_2008_2009_0002();
					this.m__0008 = _000E;
					m__0002 = 1;
					result = true;
				}
				else
				{
					_0008();
					_0002_2004 = null;
					result = false;
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				_0002_2008_2009_0002();
				throw;
			}
			return result;
		}

		bool global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in     
			return this._0008_2003_2005_2008_2009_0002();
		}

		private void _0008()
		{
			if (uint.MaxValue != 0)
			{
				m__0002 = -1;
			}
			if (_0002_2004 != null)
			{
				_0002_2004._0006_2003_2005_2008_2009_0002();
			}
		}

		[DebuggerHidden]
		private int _0002_2008_2009_0002()
		{
			_ = -1;
			if (8 == 0)
			{
			}
			return this.m__0008;
		}

		int global::_0005_2003_2005<int>._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0002_2008_2009_0002();
		}

		[DebuggerHidden]
		private void _0002_2008_2009_0006()
		{
			throw new NotSupportedException();
		}

		void global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			this._0002_2008_2009_0006();
		}

		[DebuggerHidden]
		private object _0002_2008_2009_0002()
		{
			_ = -1;
			if (3 == 0)
			{
			}
			return this.m__0008;
		}

		object global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0002_2008_2009_0002();
		}

		[DebuggerHidden]
		private global::_0005_2003_2005<int> _0002_2008_2009_0002()
		{
			_0002 obj;
			if (m__0002 == -2 && _0006 == Thread.CurrentThread.ManagedThreadId)
			{
				if (4u != 0)
				{
					m__0002 = 0;
				}
				if (6u != 0)
				{
					obj = this;
				}
			}
			else
			{
				_0002 obj2 = new _0002(0);
				if (8u != 0)
				{
					obj = obj2;
				}
			}
			obj._000F = _0005;
			return obj;
		}

		global::_0005_2003_2005<int> global::_0002_2003_2005<int>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0002_2008_2009_0002();
		}

		[DebuggerHidden]
		private global::_0008_2003_2005 _0002_2008_2009_0002()
		{
			_ = 4;
			if (false)
			{
			}
			return _0002_2008_2009_0002();
		}

		global::_0008_2003_2005 global::_000E_2007_2005._000E_2007_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0002_2008_2009_0002();
		}
	}

	internal sealed class _0006 : global::_0002_2003_2005<int>, global::_000E_2007_2005, global::_0005_2003_2005<int>, global::_0006_2003_2005, global::_0008_2003_2005
	{
		private int _0002;

		private int m__0008;

		private int m__0006;

		private int _000F;

		public int _0005;

		private int _0003;

		private global::_0005_2003_2005<int> _000E;

		[DebuggerHidden]
		public _0006(int _0002)
		{
			if (4u != 0)
			{
				this._0002 = _0002;
			}
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			if (6u != 0)
			{
				m__0006 = managedThreadId;
			}
		}

		[DebuggerHidden]
		private void _0006_2008_2009_0002()
		{
			int num = _0002;
			int num2;
			if (uint.MaxValue != 0)
			{
				num2 = num;
			}
			if (num2 == -3 || num2 == 1)
			{
				try
				{
				}
				finally
				{
					if (3u != 0)
					{
						_0008();
					}
				}
			}
			if (5u != 0)
			{
				_000E = null;
			}
			_0002 = -2;
		}

		void global::_0006_2003_2005._0006_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			this._0006_2008_2009_0002();
		}

		private bool _0008_2003_2005_2008_2009_0002()
		{
			bool result;
			try
			{
				int num = _0002;
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				switch (num2)
				{
				default:
					if (2u != 0)
					{
						result = false;
					}
					goto end_IL_0000;
				case 0:
				{
					if (7u != 0)
					{
						_0002 = -1;
					}
					_0003 = 7;
					int num3 = _000F;
					_000E = ((global::_0002_2003_2005<int>)new _0002(-2)
					{
						_0005 = num3
					}).GetEnumerator();
					_0002 = -3;
					break;
				}
				case 1:
					_0002 = -3;
					if (_0003 != 0)
					{
						break;
					}
					result = false;
					_0008();
					goto end_IL_0000;
				}
				if (((global::_0008_2003_2005)_000E)._0008_2003_2005_2008_2009_0002())
				{
					int num4 = _000E._0008_2003_2005_2008_2009_0002() ^ _000F;
					if ((num4 & 3) == 0)
					{
						num4 ^= 0x778BF18C;
					}
					int num5 = _0003 - 1;
					_0003 = num5;
					if ((num4 & 0xF) == 0)
					{
						num4 ^= -1189707964;
					}
					this.m__0008 = num4;
					_0002 = 1;
					result = true;
				}
				else
				{
					_0008();
					_000E = null;
					result = false;
				}
				end_IL_0000:;
			}
			catch
			{
				//try-fault
				_0006_2008_2009_0002();
				throw;
			}
			return result;
		}

		bool global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in     
			return this._0008_2003_2005_2008_2009_0002();
		}

		private void _0008()
		{
			if (8u != 0)
			{
				_0002 = -1;
			}
			if (_000E != null)
			{
				_000E._0006_2003_2005_2008_2009_0002();
			}
		}

		[DebuggerHidden]
		private int _0006_2008_2009_0002()
		{
			_ = 2;
			if (6 == 0)
			{
			}
			return this.m__0008;
		}

		int global::_0005_2003_2005<int>._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0006_2008_2009_0002();
		}

		[DebuggerHidden]
		private void _0006_2008_2009_0006()
		{
			throw new NotSupportedException();
		}

		void global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			this._0006_2008_2009_0006();
		}

		[DebuggerHidden]
		private object _0006_2008_2009_0002()
		{
			_ = 3;
			if (2 == 0)
			{
			}
			return this.m__0008;
		}

		object global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0006_2008_2009_0002();
		}

		[DebuggerHidden]
		private global::_0005_2003_2005<int> _0006_2008_2009_0002()
		{
			_0006 obj;
			if (_0002 == -2 && m__0006 == Thread.CurrentThread.ManagedThreadId)
			{
				if (2u != 0)
				{
					_0002 = 0;
				}
				if (5u != 0)
				{
					obj = this;
				}
			}
			else
			{
				_0006 obj2 = new _0006(0);
				if (true)
				{
					obj = obj2;
				}
			}
			obj._000F = _0005;
			return obj;
		}

		global::_0005_2003_2005<int> global::_0002_2003_2005<int>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0006_2008_2009_0002();
		}

		[DebuggerHidden]
		private global::_0008_2003_2005 _0006_2008_2009_0002()
		{
			_ = 2;
			if (2 == 0)
			{
			}
			return _0006_2008_2009_0002();
		}

		global::_0008_2003_2005 global::_000E_2007_2005._000E_2007_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0006_2008_2009_0002();
		}
	}

	internal sealed class _0008 : global::_0002_2003_2005<int>, global::_000E_2007_2005, global::_0005_2003_2005<int>, global::_0006_2003_2005, global::_0008_2003_2005
	{
		private int _0002;

		private int m__0008;

		private int _0006;

		private int _000F;

		[DebuggerHidden]
		public _0008(int _0002)
		{
			if (true)
			{
				this._0002 = _0002;
			}
			int managedThreadId = Thread.CurrentThread.ManagedThreadId;
			if (4u != 0)
			{
				_0006 = managedThreadId;
			}
		}

		[DebuggerHidden]
		private void _0008_2008_2009_0002()
		{
			if (7u != 0)
			{
				_0002 = -2;
			}
		}

		void global::_0006_2003_2005._0006_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			this._0008_2008_2009_0002();
		}

		private bool _0008_2003_2005_2008_2009_0002()
		{
			int num = _0002;
			int num2;
			if (true)
			{
				num2 = num;
			}
			if (num2 != 0)
			{
				if (num2 != 1)
				{
					return false;
				}
				_0002 = -1;
				_000F += _000F;
				if (_000F == 64)
				{
					_000F = 5;
				}
			}
			else
			{
				if (0 == 0)
				{
					_0002 = -1;
				}
				if (6u != 0)
				{
					_000F = 1;
				}
			}
			m__0008 = _000F;
			_0002 = 1;
			return true;
		}

		bool global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in     
			return this._0008_2003_2005_2008_2009_0002();
		}

		[DebuggerHidden]
		private int _0008_2008_2009_0002()
		{
			_ = 0;
			if (-1 == 0)
			{
			}
			return m__0008;
		}

		int global::_0005_2003_2005<int>._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0008_2008_2009_0002();
		}

		[DebuggerHidden]
		private void _0008_2008_2009_0008()
		{
			throw new NotSupportedException();
		}

		void global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			this._0008_2008_2009_0008();
		}

		[DebuggerHidden]
		private object _0008_2008_2009_0002()
		{
			_ = -1;
			if (7 == 0)
			{
			}
			return m__0008;
		}

		object global::_0008_2003_2005._0008_2003_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0008_2008_2009_0002();
		}

		[DebuggerHidden]
		private global::_0005_2003_2005<int> _0008_2008_2009_0002()
		{
			if (_0002 == -2 && _0006 == Thread.CurrentThread.ManagedThreadId)
			{
				if (5u != 0)
				{
					_0002 = 0;
				}
				if (uint.MaxValue != 0)
				{
					return this;
				}
			}
			else
			{
				_0008 result = new _0008(0);
				if (3u != 0)
				{
					return result;
				}
			}
			_0008 result2;
			return result2;
		}

		global::_0005_2003_2005<int> global::_0002_2003_2005<int>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0008_2008_2009_0002();
		}

		[DebuggerHidden]
		private global::_0008_2003_2005 _0008_2008_2009_0002()
		{
			_ = 2;
			if (7 == 0)
			{
			}
			return _0008_2008_2009_0002();
		}

		global::_0008_2003_2005 global::_000E_2007_2005._000E_2007_2005_2008_2009_0002()
		{
			//ILSpy generated this explicit interface implementation from .override directive in   
			return this._0008_2008_2009_0002();
		}
	}
}
internal sealed class _0003_2004 : global::_0005_2004
{
	private global::_0002 m__0002;

	private string _0008;

	private bool _0006;

	public _0003_2004()
	{
		_ = 6;
		if (false)
		{
		}
		base._002Ector();
	}

	public global::_0002 _0002()
	{
		_ = 8;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(global::_0002 _0002)
	{
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public string _0002()
	{
		_ = 3;
		if (4 == 0)
		{
		}
		return _0008;
	}

	public void _0002(string _0002)
	{
		if (true)
		{
			_0008 = _0002;
		}
	}

	public bool _0002()
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		return _0006;
	}

	public void _0002(bool _0002)
	{
		if (8u != 0)
		{
			_0006 = _0002;
		}
	}

	[SpecialName]
	public override byte _0005_2004_2008_2009_0002()
	{
		return 1;
	}
}
internal sealed class _0003_2004_2005
{
	private string m__0002;

	private int m__0008;

	private global::_0005_2008[] m__0006;

	private global::_0002_2006[] _000F;

	private byte _0005;

	private int _0003;

	public _0003_2004_2005()
	{
		_ = 0;
		if (-1 == 0)
		{
		}
		base._002Ector();
	}

	public global::_0005_2008[] _0002()
	{
		_ = 8;
		if (false)
		{
		}
		return this.m__0006;
	}

	public void _0002(global::_0005_2008[] _0002)
	{
		if (2u != 0)
		{
			this.m__0006 = _0002;
		}
	}

	public global::_0002_2006[] _0002()
	{
		_ = 8;
		if (3 == 0)
		{
		}
		return _000F;
	}

	public void _0002(global::_0002_2006[] _0002)
	{
		if (5u != 0)
		{
			_000F = _0002;
		}
	}

	public string _0002()
	{
		_ = 7;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(string _0002)
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public int _0002()
	{
		_ = 4;
		if (6 == 0)
		{
		}
		return this.m__0008;
	}

	public void _0002(int _0002)
	{
		if (true)
		{
			this.m__0008 = _0002;
		}
	}

	public int _0008()
	{
		_ = 0;
		if (7 == 0)
		{
		}
		return _0003;
	}

	public void _0008(int _0002)
	{
		if (uint.MaxValue != 0)
		{
			_0003 = _0002;
		}
	}

	public byte _0002()
	{
		_ = 1;
		if (6 == 0)
		{
		}
		return _0005;
	}

	public void _0002(byte _0002)
	{
		if (true)
		{
			_0005 = _0002;
		}
	}

	public bool _0002()
	{
		_ = 4;
		if (2 == 0)
		{
		}
		return (this._0002() & 2) != 0;
	}

	public bool _0008()
	{
		_ = -1;
		if (6 == 0)
		{
		}
		return (this._0002() & 1) != 0;
	}

	public bool _0006()
	{
		_ = 4;
		if (3 == 0)
		{
		}
		return (this._0002() & 4) != 0;
	}
}
internal sealed class _0003_2005
{
	private int m__0002;

	private int m__0008;

	private uint m__0006;

	private uint m__000F;

	private uint _0005;

	private uint _0003;

	public _0003_2005()
	{
		_ = -1;
		if (8 == 0)
		{
		}
		base._002Ector();
	}

	public int _0002()
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (true)
		{
			this.m__0002 = _0002;
		}
	}

	public int _0008()
	{
		_ = 6;
		if (2 == 0)
		{
		}
		return this.m__0008;
	}

	public void _0008(int _0002)
	{
		if (8u != 0)
		{
			this.m__0008 = _0002;
		}
	}

	public uint _0002()
	{
		_ = 4;
		if (8 == 0)
		{
		}
		return this.m__0006;
	}

	public void _0002(uint _0002)
	{
		if (7u != 0)
		{
			this.m__0006 = _0002;
		}
	}

	public uint _0008()
	{
		_ = 0;
		if (2 == 0)
		{
		}
		return this.m__000F;
	}

	public void _0008(uint _0002)
	{
		if (8u != 0)
		{
			this.m__000F = _0002;
		}
	}

	public uint _0006()
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		return _0005;
	}

	public void _0006(uint _0002)
	{
		if (2u != 0)
		{
			_0005 = _0002;
		}
	}

	public uint _000F()
	{
		_ = 4;
		if (5 == 0)
		{
		}
		return _0003;
	}

	public void _000F(uint _0002)
	{
		if (true)
		{
			_0003 = _0002;
		}
	}
}
internal static class _0003_2006<_0002>
{
	public static readonly _0002[] _0002;

	static _0003_2006()
	{
		_0002[] array = new _0002[0];
		if (uint.MaxValue != 0)
		{
			global::_0003_2006<_0002>._0002 = array;
		}
	}
}
internal static class _0003_2007
{
	private static readonly bool m__0002;

	static _0003_2007()
	{
		try
		{
			bool num = Type.GetType(global::_0008_0010._0002(-1463125484)) != null;
			if (5u != 0)
			{
				global::_0003_2007.m__0002 = num;
			}
		}
		catch
		{
			if (2u != 0)
			{
				global::_0003_2007.m__0002 = false;
			}
		}
	}

	public static bool _0002()
	{
		return global::_0003_2007.m__0002;
	}
}
internal sealed class _0003_2008
{
	private global::_0008_200A m__0002;

	private int m__0008;

	private int _0006;

	private int _000F;

	public _0003_2008()
	{
		_ = 4;
		if (-1 == 0)
		{
		}
		base._002Ector();
	}

	public void _0002(bool _0002, global::_0008_200A _0008)
	{
		if (7u != 0)
		{
			this.m__0002 = _0008;
		}
		int num = this.m__0002._0002()._0002();
		if (0 == 0)
		{
			this.m__0008 = num;
		}
		int num2 = global::_0003_2008._0002(this.m__0008, _0002);
		if (true)
		{
			this._0002(num2);
		}
		this._0008(global::_0003_2008._0008(this.m__0008, _0002));
	}

	public int _0002()
	{
		_ = 5;
		if (false)
		{
		}
		return _0006;
	}

	private void _0002(int _0002)
	{
		if (6u != 0)
		{
			_0006 = _0002;
		}
	}

	public int _0008()
	{
		_ = 5;
		if (5 == 0)
		{
		}
		return _000F;
	}

	private void _0008(int _0002)
	{
		if (5u != 0)
		{
			_000F = _0002;
		}
	}

	private static int _0002(int _0002, bool _0008)
	{
		_ = -1;
		if (8 == 0)
		{
		}
		if (!_0008)
		{
			_ = 4;
			if (5 == 0)
			{
			}
			return (_0002 + 7) / 8;
		}
		_ = 0;
		if (1 == 0)
		{
		}
		return (_0002 - 1) / 8;
	}

	private static int _0008(int _0002, bool _0008)
	{
		_ = 6;
		if (3 == 0)
		{
		}
		if (!_0008)
		{
			_ = 4;
			if (5 == 0)
			{
			}
			return (_0002 - 1) / 8;
		}
		_ = 7;
		if (false)
		{
		}
		return (_0002 + 7) / 8;
	}

	public global::_0006_2005 _0002(byte[] _0002, int _0008, int _0006)
	{
		_ = 4;
		if (1 == 0)
		{
		}
		_ = 3;
		if (8 == 0)
		{
		}
		_ = 1;
		if (-1 == 0)
		{
		}
		return new global::_0006_2005(1, _0002, _0008, _0006);
	}

	public int _0002(global::_0006_2005 _0002, byte[] _0008, int _0006)
	{
		int num = this._0008() - _0002._000F();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		int index = _0006;
		if (0 == 0)
		{
			Array.Clear(_0008, index, num2);
		}
		int num3 = _0006 + num2;
		if (7u != 0)
		{
			_0006 = num3;
		}
		_0002._0002(_0008, _0006);
		return this._0008();
	}

	public global::_0006_2005 _0002(global::_0006_2005 _0002)
	{
		_ = -1;
		if (7 == 0)
		{
		}
		_ = 6;
		if (4 == 0)
		{
		}
		global::_0006_2005 obj = this.m__0002._0008();
		_ = 8;
		if (5 == 0)
		{
		}
		return _0002._0002(obj, this.m__0002._0002());
	}
}
internal sealed class _0003_2009 : SymmetricAlgorithm
{
	private sealed class _0002 : ICryptoTransform, IDisposable
	{
		private byte[] m__0002;

		private bool _0008;

		public int InputBlockSize => 4;

		public int OutputBlockSize => 4;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public _0002(byte[] _0002, bool _0008)
		{
			if (6u != 0)
			{
				this.m__0002 = _0002;
			}
			if (5u != 0)
			{
				this._0008 = _0008;
			}
		}

		public void Dispose()
		{
		}

		public int TransformBlock(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005)
		{
			if (_0006 % 4 != 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			int num;
			if (4u != 0)
			{
				num = 0;
			}
			while (num < _0006)
			{
				byte[] array = this.m__0002;
				int num2 = _0008 + num;
				int num3 = _0005 + num;
				bool num4 = this._0008;
				if (uint.MaxValue != 0)
				{
					global::_0003_2009._0002(array, _0002, num2, _000F, num3, num4);
				}
				int num5 = num + 4;
				if (5u != 0)
				{
					num = num5;
				}
			}
			return _0006;
		}

		public byte[] TransformFinalBlock(byte[] _0002, int _0008, int _0006)
		{
			byte[] array = new byte[_0006];
			byte[] array2;
			if (uint.MaxValue != 0)
			{
				array2 = array;
			}
			TransformBlock(_0002, _0008, _0006, array2, 0);
			return array2;
		}
	}

	private static byte[] m__0002;

	public _0003_2009()
	{
		KeySizes[] legalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(32, 32, 0)
		};
		if (6u != 0)
		{
			LegalBlockSizesValue = legalBlockSizesValue;
		}
		KeySizes[] legalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(80, 80, 0)
		};
		if (7u != 0)
		{
			LegalKeySizesValue = legalKeySizesValue;
		}
		if (true)
		{
			BlockSizeValue = 32;
		}
		KeySizeValue = 80;
		ModeValue = CipherMode.ECB;
		PaddingValue = PaddingMode.None;
	}

	public _0003_2009(byte[] _0002)
	{
		_ = 6;
		if (5 == 0)
		{
		}
		this._002Ector();
		_ = 6;
		if (2 == 0)
		{
		}
		_ = 6;
		if (6 == 0)
		{
		}
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		Key = _0002;
	}

	static _0003_2009()
	{
		byte[] array = new byte[256];
		if (8u != 0)
		{
			RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		}
		if (0 == 0)
		{
			global::_0003_2009.m__0002 = array;
		}
	}

	public override ICryptoTransform CreateDecryptor(byte[] _0002, byte[] _0008)
	{
		_ = 7;
		if (1 == 0)
		{
		}
		return new _0002(_0002, _0008: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] _0002, byte[] _0008)
	{
		_ = 3;
		if (1 == 0)
		{
		}
		return new _0002(_0002, _0008: true);
	}

	public override void GenerateIV()
	{
		throw new NotImplementedException();
	}

	public override void GenerateKey()
	{
		throw new NotImplementedException();
	}

	private static ushort _0002(byte[] _0002, int _0008, ushort _0006)
	{
		byte num = (byte)(_0006 >> 8);
		byte b = default(byte);
		if (0 == 0)
		{
			b = num;
		}
		byte num2 = (byte)_0006;
		byte b2;
		if (4u != 0)
		{
			b2 = num2;
		}
		byte num3 = (byte)(global::_0003_2009.m__0002[b2 ^ _0002[4 * _0008 % 10]] ^ b);
		byte b3;
		if (4u != 0)
		{
			b3 = num3;
		}
		byte b4 = (byte)(global::_0003_2009.m__0002[b3 ^ _0002[(4 * _0008 + 1) % 10]] ^ b2);
		byte b5 = (byte)(global::_0003_2009.m__0002[b4 ^ _0002[(4 * _0008 + 2) % 10]] ^ b3);
		byte b6 = (byte)(global::_0003_2009.m__0002[b5 ^ _0002[(4 * _0008 + 3) % 10]] ^ b4);
		return (ushort)((b5 << 8) + b6);
	}

	private static void _0002(byte[] _0002, byte[] _0008, int _0006, byte[] _000F, int _0005, bool _0003)
	{
		int num = default(int);
		int num2;
		if (_0003)
		{
			if (7u != 0)
			{
				num = 1;
			}
			if (true)
			{
				num2 = 0;
			}
		}
		else
		{
			if (0 == 0)
			{
				num = -1;
			}
			num2 = 23;
		}
		ushort num3 = (ushort)((_0008[_0006] << 8) + _0008[_0006 + 1]);
		ushort num4 = (ushort)((_0008[_0006 + 2] << 8) + _0008[_0006 + 3]);
		for (int i = 0; i < 12; i++)
		{
			num4 ^= (ushort)(global::_0003_2009._0002(_0002, num2, num3) ^ num2);
			num2 += num;
			num3 ^= (ushort)(global::_0003_2009._0002(_0002, num2, num4) ^ num2);
			num2 += num;
		}
		_000F[_0005] = (byte)(num4 >> 8);
		_000F[_0005 + 1] = (byte)num4;
		_000F[_0005 + 2] = (byte)(num3 >> 8);
		_000F[_0005 + 3] = (byte)num3;
	}
}
internal static class _0003_2009_2005
{
	[STAThread]
	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	private static void _0002()
	{
		if (4u != 0)
		{
			iI11I1IlllIi._0002();
		}
	}
}
internal static class _0003_200A
{
	private static readonly uint[] m__0002;

	static _0003_200A()
	{
		uint[] array = new uint[5];
		if (0 == 0)
		{
			RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		}
		if (true)
		{
			global::_0003_200A.m__0002 = array;
		}
	}

	public static byte[] _0002(string _0002)
	{
		if (_0002 == null)
		{
			throw new Exception();
		}
		MemoryStream memoryStream = new MemoryStream(_0002.Length * 4 / 5);
		MemoryStream memoryStream2;
		if (7u != 0)
		{
			memoryStream2 = memoryStream;
		}
		try
		{
			int num;
			if (6u != 0)
			{
				num = 0;
			}
			uint num2;
			if (5u != 0)
			{
				num2 = 0u;
			}
			foreach (char c in _0002)
			{
				if (c == 'z' && num == 0)
				{
					global::_0003_200A._0002(memoryStream2, num2, 0);
					continue;
				}
				if (c < '!' || c > 'u')
				{
					throw new Exception();
				}
				num2 = checked(num2 + (uint)(global::_0003_200A.m__0002[num] * (c - 33)));
				num++;
				if (num == 5)
				{
					global::_0003_200A._0002(memoryStream2, num2, 0);
					num = 0;
					num2 = 0u;
				}
			}
			if (num == 1)
			{
				throw new Exception();
			}
			if (num > 1)
			{
				for (int j = num; j < 5; j++)
				{
					num2 = checked(num2 + 84 * global::_0003_200A.m__0002[j]);
				}
				global::_0003_200A._0002(memoryStream2, num2, 5 - num);
			}
			return memoryStream2.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream2).Dispose();
		}
	}

	private static void _0002(Stream _0002, uint _0008, int _0006)
	{
		_ = -1;
		if (-1 == 0)
		{
		}
		_ = 4;
		if (5 == 0)
		{
		}
		_0002.WriteByte((byte)(_0008 >> 24));
		_ = 1;
		if (false)
		{
		}
		if (_0006 == 3)
		{
			return;
		}
		_0002.WriteByte((byte)(_0008 >> 16));
		if (_0006 != 2)
		{
			_0002.WriteByte((byte)(_0008 >> 8));
			if (_0006 != 1)
			{
				_0002.WriteByte((byte)_0008);
			}
		}
	}
}
internal abstract class _0005 : IDisposable
{
	protected _0005()
	{
		_ = 8;
		if (1 == 0)
		{
		}
		base._002Ector();
	}

	public abstract bool _0005_2008_2009_0002();

	public abstract bool _0005_2008_2009_0008();

	public abstract bool _0005_2008_2009_0006();

	public abstract long _0005_2008_2009_0002();

	public abstract long _0005_2008_2009_0008();

	public abstract void _0005_2008_2009_0002(long _0002);

	public virtual void _0005_2008_2009_0002()
	{
		_0005_2008_2009_0002(_0002: true);
		if (7u != 0)
		{
			GC.SuppressFinalize(this);
		}
	}

	public void Dispose()
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		this._0005_2008_2009_0002();
	}

	protected virtual void _0005_2008_2009_0002(bool _0002)
	{
	}

	public abstract void _0005_2008_2009_0008();

	public abstract long _0005_2008_2009_0002(long _0002, int _0008);

	public abstract void _0005_2008_2009_0008(long _0002);

	public abstract int _0005_2008_2009_0002(byte[] _0002, int _0008, int _0006);

	public virtual int _0005_2008_2009_0002()
	{
		byte[] array = new byte[1];
		byte[] array2 = default(byte[]);
		if (0 == 0)
		{
			array2 = array;
		}
		if (this._0005_2008_2009_0002(array2, 0, 1) == 0)
		{
			return -1;
		}
		return array2[0];
	}

	public abstract void _0005_2008_2009_0002(byte[] _0002, int _0008, int _0006);

	public virtual void _0005_2008_2009_0002(byte _0002)
	{
		byte[] array = new byte[1];
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		array2[0] = _0002;
		this._0005_2008_2009_0002(array2, 0, 1);
	}
}
internal static class _0005_2000
{
	public static byte[] _0002(object _0002, ulong _0008, global::_0002_2007 _0006, RandomNumberGenerator _000F)
	{
		_ = 4;
		if (1 == 0)
		{
		}
		byte[] array = global::_0005_2000._0002(_0002);
		_ = 1;
		if (1 == 0)
		{
		}
		byte[] array2 = global::_0005_2000._0002(_0008);
		_ = 3;
		if (3 == 0)
		{
		}
		return global::_0005_2000._0002(array, array2, _0006, _000F);
	}

	public static byte[] _0002(byte[] _0002, byte[] _0008, global::_0002_2007 _0006, RandomNumberGenerator _000F)
	{
		int num = _0002.Length;
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		if (num2 == 0)
		{
			throw new ArgumentException();
		}
		int num3 = _0006._0002_2007_2008_2009_0002();
		int num4;
		if (8u != 0)
		{
			num4 = num3;
		}
		int num5 = _0006._0002_2007_2008_2009_0008();
		int num6;
		if (8u != 0)
		{
			num6 = num5;
		}
		int num7 = num2 % num4;
		int num8 = (num2 + (num4 - 1)) / num4;
		byte[] array;
		if (num7 == 0)
		{
			array = new byte[num2];
			Buffer.BlockCopy(_0002, 0, array, 0, num2);
		}
		else
		{
			int num9 = global::_0005_2000._0002(num7);
			byte[] bytes = new global::_000E_2004_2005(_0002, _0008, num9).GetBytes(num4);
			if (num8 == 1)
			{
				array = bytes;
			}
			else
			{
				array = new byte[num4 * num8];
				Buffer.BlockCopy(bytes, 0, array, num4 * (num8 - 1), num4);
			}
			Buffer.BlockCopy(_0002, 0, array, 0, _0002.Length);
		}
		global::_000F_2004._0002(array, 0, array.Length / 4 * 4, _0008);
		byte[] array2 = new byte[_0006._0002_2007_2008_2009_0008() * num8];
		for (int i = 0; i < num8; i++)
		{
			_0006._0002_2007_2008_2009_0002(array, num4 * i, num4, array2, num6 * i, _000F);
		}
		return array2;
	}

	private static int _0002(int _0002)
	{
		_ = 0;
		if (2 == 0)
		{
		}
		if (_0002 < 8)
		{
			return 200;
		}
		return 1;
	}

	public static byte[] _0002(object _0002)
	{
		if (_0002 is int num)
		{
			sbyte b;
			if (8u != 0)
			{
				b = (sbyte)num;
			}
			return new byte[1] { (byte)b };
		}
		if (_0002 is int num2)
		{
			byte b2;
			if (true)
			{
				b2 = (byte)num2;
			}
			return new byte[1] { b2 };
		}
		if (_0002 is int num3)
		{
			short num4;
			if (7u != 0)
			{
				num4 = (short)num3;
			}
			return global::_0005_2000._0002(num4);
		}
		if (_0002 is int num5)
		{
			ushort num6 = default(ushort);
			if (0 == 0)
			{
				num6 = (ushort)num5;
			}
			return global::_0005_2000._0002(num6);
		}
		if (!(_0002 is int num7))
		{
			if (!(_0002 is uint num8))
			{
				if (!(_0002 is long num9))
				{
					if (!(_0002 is ulong num10))
					{
						if (!(_0002 is byte[] result))
						{
							if (!(_0002 is string s))
							{
								if (_0002 is IEnumerable enumerable)
								{
									MemoryStream memoryStream = new MemoryStream();
									foreach (object item in enumerable)
									{
										byte[] array = global::_0005_2000._0002(item);
										memoryStream.Write(array, 0, array.Length);
									}
									return memoryStream.ToArray();
								}
								throw new ArgumentOutOfRangeException(global::_0008_0010._0002(-1463127142));
							}
							return Encoding.Unicode.GetBytes(s);
						}
						return result;
					}
					return global::_0005_2000._0002(num10);
				}
				return global::_0005_2000._0002(num9);
			}
			return global::_0005_2000._0002(num8);
		}
		return global::_0005_2000._0002(num7);
	}

	private static byte[] _0002(short _0002)
	{
		_ = 0;
		if (3 == 0)
		{
		}
		return global::_0005_2000._0002((ushort)_0002);
	}

	private static byte[] _0002(ushort _0002)
	{
		byte[] array = new byte[2];
		_ = 0;
		if (1 == 0)
		{
		}
		array[1] = (byte)_0002;
		_ = 4;
		if (-1 == 0)
		{
		}
		array[0] = (byte)(_0002 >> 8);
		return array;
	}

	private static byte[] _0002(int _0002)
	{
		_ = 6;
		if (5 == 0)
		{
		}
		return global::_0005_2000._0002((uint)_0002);
	}

	private static byte[] _0002(uint _0002)
	{
		byte[] array = new byte[4];
		_ = 3;
		if (false)
		{
		}
		array[3] = (byte)_0002;
		_ = 4;
		if (3 == 0)
		{
		}
		array[2] = (byte)(_0002 >> 8);
		_ = 7;
		if (7 == 0)
		{
		}
		array[1] = (byte)(_0002 >> 16);
		array[0] = (byte)(_0002 >> 24);
		return array;
	}

	private static byte[] _0002(long _0002)
	{
		_ = 3;
		if (4 == 0)
		{
		}
		return global::_0005_2000._0002((ulong)_0002);
	}

	private static byte[] _0002(ulong _0002)
	{
		byte[] array = new byte[8];
		_ = 2;
		if (-1 == 0)
		{
		}
		array[7] = (byte)_0002;
		_ = 3;
		if (false)
		{
		}
		array[6] = (byte)(_0002 >> 8);
		_ = 5;
		if (4 == 0)
		{
		}
		array[5] = (byte)(_0002 >> 16);
		array[4] = (byte)(_0002 >> 24);
		array[3] = (byte)(_0002 >> 32);
		array[2] = (byte)(_0002 >> 40);
		array[1] = (byte)(_0002 >> 48);
		array[0] = (byte)(_0002 >> 56);
		return array;
	}
}
internal static class _0005_2001
{
	private static readonly bool m__0002;

	static _0005_2001()
	{
		bool num = _0002();
		if (0 == 0)
		{
			global::_0005_2001.m__0002 = num;
		}
	}

	private static bool _0002()
	{
		try
		{
			if (Environment.Version.Major >= 4)
			{
				Assembly assembly = typeof(global::_0006_2009).Assembly;
				Assembly assembly2 = typeof(SecurityCriticalAttribute).Assembly;
				Assembly assembly3;
				if (3u != 0)
				{
					assembly3 = assembly2;
				}
				bool result;
				if (4u != 0)
				{
					result = false;
				}
				object[] customAttributes = assembly.GetCustomAttributes(inherit: false);
				foreach (object obj in customAttributes)
				{
					if (obj is AllowPartiallyTrustedCallersAttribute)
					{
						result = true;
						continue;
					}
					Type type = obj.GetType();
					if (type.Assembly == assembly3 && global::_0008_0010._0002(-1463127437).Equals(type.FullName, StringComparison.Ordinal) && (byte)type.GetProperty(global::_0008_0010._0002(-1463127522)).GetValue(obj, null) != 2)
					{
						return false;
					}
				}
				return result;
			}
			if (7u != 0)
			{
				return false;
			}
		}
		catch
		{
			return false;
		}
		bool result2;
		return result2;
	}

	public static bool _0008()
	{
		return global::_0005_2001.m__0002;
	}
}
internal sealed class _0005_2002 : global::_0005_2004
{
	private string m__0002;

	private bool m__0008;

	private bool _0006;

	private global::_0002[] _000F;

	private int _0005;

	private int _0003;

	public _0005_2002()
	{
		global::_0002[] array = new global::_0002[0];
		if (4u != 0)
		{
			_000F = array;
		}
		if (true)
		{
			_0005 = -1;
		}
		if (2u != 0)
		{
			_0003 = -1;
		}
		base._002Ector();
	}

	public string _0002()
	{
		_ = 6;
		if (3 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(string _0002)
	{
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	public bool _0002()
	{
		_ = 5;
		if (2 == 0)
		{
		}
		return this.m__0008;
	}

	public void _0002(bool _0002)
	{
		if (0 == 0)
		{
			this.m__0008 = _0002;
		}
	}

	public bool _0008()
	{
		_ = 6;
		if (1 == 0)
		{
		}
		return _0006;
	}

	public void _0008(bool _0002)
	{
		if (3u != 0)
		{
			_0006 = _0002;
		}
	}

	public global::_0002[] _0002()
	{
		_ = 1;
		if (5 == 0)
		{
		}
		return _000F;
	}

	public void _0002(global::_0002[] _0002)
	{
		if (3u != 0)
		{
			_000F = _0002;
		}
	}

	public int _0002()
	{
		_ = 6;
		if (4 == 0)
		{
		}
		return _0005;
	}

	public void _0002(int _0002)
	{
		if (0 == 0)
		{
			_0005 = _0002;
		}
	}

	public int _0008()
	{
		_ = 2;
		if (8 == 0)
		{
		}
		return _0003;
	}

	public void _0008(int _0002)
	{
		if (2u != 0)
		{
			_0003 = _0002;
		}
	}

	[SpecialName]
	public override byte _0005_2004_2008_2009_0002()
	{
		return 2;
	}
}
internal sealed class _0005_2003 : global::_0006
{
	private new object m__0002;

	public _0005_2003()
	{
		_ = 5;
		if (false)
		{
		}
		base._002Ector(7);
	}

	public new object _0002()
	{
		_ = 3;
		if (8 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(object _0002)
	{
		if (8u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 4;
		if (8 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (0 == 0)
		{
			this._0002(_0002);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (3u != 0)
		{
			base._0002(type);
		}
		object obj = _0002._0006_2008_2009_0002();
		if (6u != 0)
		{
			this._0002(obj);
		}
		return this;
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0005_2003 obj = new global::_0005_2003();
		_ = 8;
		if (1 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = -1;
		if (5 == 0)
		{
		}
		((global::_0006)obj)._0002(base._0002());
		return obj;
	}
}
internal interface _0005_2003_2005<_0002> : global::_0008_2003_2005, global::_0006_2003_2005
{
	[SpecialName]
	new _0002 _0008_2003_2005_2008_2009_0002();
}
internal abstract class _0005_2004
{
	protected _0005_2004()
	{
		_ = 7;
		if (1 == 0)
		{
		}
		base._002Ector();
	}

	public abstract byte _0005_2004_2008_2009_0002();
}
internal sealed class _0005_2004_2005 : Stream
{
	private int m__0002;

	private int m__0008;

	private int m__0006;

	private Stream m__000F;

	private global::_0002_2007 _0005;

	private int _0003;

	private bool _000E;

	private bool _0002_2004;

	private bool _0008_2004;

	private byte[] _0006_2004;

	private int _000F_2004;

	private byte[] _0005_2004;

	private int _0003_2004;

	private int _000E_2004;

	private int _0002_2007;

	private bool _0008_2007;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			if (5u != 0)
			{
				_000F();
			}
			return this.m__0002;
		}
	}

	public override long Position
	{
		get
		{
			_ = 4;
			if (5 == 0)
			{
			}
			int num = _0003;
			_ = 3;
			if (1 == 0)
			{
			}
			int num2 = num * _0002_2007;
			_ = 0;
			if (7 == 0)
			{
			}
			return num2 + _000E_2004;
		}
		set
		{
			int num = (int)value / _0002_2007;
			int num2;
			if (7u != 0)
			{
				num2 = num;
			}
			int num3 = (int)value % _0002_2007;
			if (5u != 0)
			{
				_000E_2004 = num3;
			}
			if (_0003 != num2)
			{
				if (2u != 0)
				{
					_0003 = num2;
				}
				_0008_2004 = true;
				_000E = false;
			}
		}
	}

	public _0005_2004_2005(Stream _0002, global::_0002_2007 _0008)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463125448));
		}
		if (_0008 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463127991));
		}
		if (2u != 0)
		{
			this.m__000F = _0002;
		}
		if (6u != 0)
		{
			_0005 = _0008;
		}
		if (this.m__000F.Length < 4)
		{
			throw new InvalidOperationException();
		}
		if (8u != 0)
		{
			this._0002();
		}
	}

	private void _0002()
	{
		int num = _0005._0002_2007_2008_2009_0002();
		if (true)
		{
			_000F_2004 = num;
		}
		byte[] array = new byte[_000F_2004];
		if (0 == 0)
		{
			_0006_2004 = array;
		}
		int num2 = _0005._0002_2007_2008_2009_0008();
		if (0 == 0)
		{
			_0002_2007 = num2;
		}
		_0005_2004 = new byte[_0002_2007];
	}

	public override long Seek(long _0002, SeekOrigin _0008)
	{
		_ = 0;
		if (8 == 0)
		{
		}
		switch (_0008)
		{
		case SeekOrigin.Begin:
			_ = 3;
			if (-1 == 0)
			{
			}
			_ = 6;
			if (1 == 0)
			{
			}
			Position = _0002;
			break;
		case SeekOrigin.Current:
			Position += _0002;
			break;
		case SeekOrigin.End:
			Position = Length + _0002;
			break;
		}
		return Position;
	}

	public override void SetLength(long _0002)
	{
		throw new NotSupportedException();
	}

	public override int Read(byte[] _0002, int _0008, int _0006)
	{
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException(global::_0008_0010._0002(-1463127943));
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException(global::_0008_0010._0002(-1463127966));
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		if (_0006 == 0)
		{
			return 0;
		}
		int num;
		if (6u != 0)
		{
			num = _0006;
		}
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = _0008;
		}
		if (_000E_2004 < _0002_2007)
		{
			if (7u != 0)
			{
				this._0008();
			}
			int num3 = _0003_2004 - _000E_2004;
			int num4;
			if (2u != 0)
			{
				num4 = num3;
			}
			if (num4 > _0006)
			{
				Buffer.BlockCopy(_0005_2004, _000E_2004, _0002, _0008, _0006);
				_000E_2004 += _0006;
				return _0006;
			}
			Buffer.BlockCopy(_0005_2004, _000E_2004, _0002, _0008, num4);
			_000E_2004 = _0003_2004;
			if (_0002_2004)
			{
				return num4;
			}
			num -= num4;
			num2 += num4;
		}
		if (_0002_2004)
		{
			return _0006 - num;
		}
		while (num > 0)
		{
			this._0006();
			if (_0002_2004)
			{
				return _0006 - num;
			}
			int num5 = _0003_2004;
			if (num >= num5)
			{
				Buffer.BlockCopy(_0005_2004, 0, _0002, num2, num5);
				num2 += num5;
				num -= num5;
				_000E_2004 = num5;
				continue;
			}
			Buffer.BlockCopy(_0005_2004, 0, _0002, num2, num);
			_000E_2004 = num;
			return _0006;
		}
		return _0006;
	}

	private void _0008()
	{
		if (8u != 0)
		{
			_000F();
		}
		if (!_000E)
		{
			if (4u != 0)
			{
				_000E = true;
			}
			if (true)
			{
				_0002_2004 = false;
			}
			int num = _0003;
			if (_0008_2004)
			{
				this.m__000F.Position = 4 + num * _000F_2004;
				_0008_2004 = false;
			}
			_0002(num);
		}
	}

	private void _0006()
	{
		int num = _0003 + 1;
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		if (_0002(num2))
		{
			if (5u != 0)
			{
				_0003 = num2;
			}
			if (6u != 0)
			{
				_000E_2004 = 0;
			}
		}
		_000E = true;
	}

	private bool _0002(int _0002)
	{
		int i;
		if (5u != 0)
		{
			i = 0;
		}
		int num2;
		for (; i < _000F_2004; i += num2)
		{
			int num = this.m__000F.Read(_0006_2004, i, _000F_2004 - i);
			if (true)
			{
				num2 = num;
			}
			if (num2 == 0)
			{
				if (i != 0)
				{
					throw new InvalidOperationException();
				}
				if (2u != 0)
				{
					_0002_2004 = true;
				}
				return false;
			}
		}
		_0003_2004 = _0005._0002_2007_2008_2009_0002(_0006_2004, 0, _000F_2004, _0005_2004, 0, null);
		if (_0002 == this.m__0008)
		{
			_0003_2004 = this.m__0006;
		}
		return true;
	}

	private void _000F()
	{
		if (_0008_2007)
		{
			return;
		}
		if (this.m__000F.Position != 0L)
		{
			this.m__000F.Position = 0L;
			if (0 == 0)
			{
				_0008_2004 = true;
			}
		}
		global::_000F_2007 obj = _0002(this.m__000F);
		global::_000F_2007 obj2;
		if (true)
		{
			obj2 = obj;
		}
		int num = obj2._0002;
		if (uint.MaxValue != 0)
		{
			this.m__0002 = num;
		}
		this.m__0008 = this.m__0002 / _0002_2007;
		this.m__0006 = this.m__0002 % _0002_2007;
		_0008_2007 = true;
	}

	private static global::_000F_2007 _0002(Stream _0002)
	{
		global::_0006_2000 obj = new global::_0006_2000(_0002, 0);
		global::_0006_2000 obj2 = default(global::_0006_2000);
		if (0 == 0)
		{
			obj2 = obj;
		}
		try
		{
			global::_0002_2004_2005 obj3 = new global::_0002_2004_2005(obj2);
			global::_0002_2004_2005 obj4;
			if (uint.MaxValue != 0)
			{
				obj4 = obj3;
			}
			try
			{
				global::_000F_2007 result = new global::_000F_2007(obj4._0005());
				if (4u != 0)
				{
					return result;
				}
			}
			finally
			{
				((IDisposable)obj4).Dispose();
			}
		}
		finally
		{
			((IDisposable)obj2).Dispose();
		}
		global::_000F_2007 result2;
		return result2;
	}

	public override void Flush()
	{
	}

	public override void Write(byte[] _0002, int _0008, int _0006)
	{
		throw new NotSupportedException();
	}
}
internal sealed class _0005_2005 : global::_0006
{
	private new string m__0002;

	public _0005_2005()
	{
		_ = 8;
		if (-1 == 0)
		{
		}
		base._002Ector(10);
	}

	public new string _0002()
	{
		_ = 2;
		if (7 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(string _0002)
	{
		if (7u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 3;
		if (4 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		string obj = (string)_0002;
		if (8u != 0)
		{
			this._0002(obj);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (7u != 0)
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
		case 10:
		{
			string text = ((global::_0005_2005)_0002)._0002();
			if (true)
			{
				this._0002(text);
			}
			break;
		}
		case 7:
			this._0002((string)((global::_0005_2003)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0005_2005 obj = new global::_0005_2005();
		_ = 1;
		if (3 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 7;
		if (8 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}
}
internal sealed class _0005_2006 : global::_0005_2004
{
	private byte m__0002;

	private global::_0002 m__0008;

	private string _0006;

	private global::_0002[] _000F;

	private global::_0002[] _0005;

	private global::_0002 _0003;

	public _0005_2006()
	{
		global::_0002[] array = new global::_0002[0];
		if (4u != 0)
		{
			_000F = array;
		}
		global::_0002[] array2 = new global::_0002[0];
		if (8u != 0)
		{
			_0005 = array2;
		}
		base._002Ector();
	}

	public byte _0002()
	{
		_ = 5;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(byte _0002)
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public bool _0002()
	{
		_ = 4;
		if (4 == 0)
		{
		}
		return (this._0002() & 1) != 0;
	}

	public bool _0008()
	{
		_ = -1;
		if (8 == 0)
		{
		}
		return (this._0002() & 2) != 0;
	}

	public global::_0002 _0002()
	{
		_ = 0;
		if (8 == 0)
		{
		}
		return this.m__0008;
	}

	public void _0002(global::_0002 _0002)
	{
		if (3u != 0)
		{
			this.m__0008 = _0002;
		}
	}

	public string _0002()
	{
		_ = 4;
		if (-1 == 0)
		{
		}
		return _0006;
	}

	public void _0002(string _0002)
	{
		if (4u != 0)
		{
			_0006 = _0002;
		}
	}

	public global::_0002[] _0002()
	{
		_ = 7;
		if (4 == 0)
		{
		}
		return _000F;
	}

	public void _0002(global::_0002[] _0002)
	{
		if (7u != 0)
		{
			_000F = _0002;
		}
	}

	public global::_0002[] _0008()
	{
		_ = 6;
		if (1 == 0)
		{
		}
		return _0005;
	}

	public void _0008(global::_0002[] _0002)
	{
		if (6u != 0)
		{
			_0005 = _0002;
		}
	}

	public global::_0002 _0008()
	{
		_ = 1;
		if (5 == 0)
		{
		}
		return _0003;
	}

	public void _0008(global::_0002 _0002)
	{
		if (5u != 0)
		{
			_0003 = _0002;
		}
	}

	[SpecialName]
	public override byte _0005_2004_2008_2009_0002()
	{
		return 0;
	}
}
internal sealed class _0005_2007 : global::_0006
{
	private new ushort m__0002;

	public _0005_2007()
	{
		_ = 4;
		if (2 == 0)
		{
		}
		base._002Ector(16);
	}

	public new ushort _0002()
	{
		_ = 4;
		if (7 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(ushort _0002)
	{
		if (4u != 0)
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
		if (_0002 is short)
		{
			ushort num = (ushort)(short)_0002;
			if (4u != 0)
			{
				this._0002(num);
			}
		}
		else if (_0002 is int)
		{
			ushort num2 = (ushort)(int)_0002;
			if (6u != 0)
			{
				this._0002(num2);
			}
		}
		else if (_0002 is long)
		{
			ushort num3 = (ushort)(long)_0002;
			if (3u != 0)
			{
				this._0002(num3);
			}
		}
		else if (_0002 is uint)
		{
			this._0002((ushort)(uint)_0002);
		}
		else if (_0002 is ulong)
		{
			this._0002((ushort)(ulong)_0002);
		}
		else if (_0002 is float)
		{
			this._0002((ushort)(float)_0002);
		}
		else if (_0002 is double)
		{
			this._0002((ushort)(double)_0002);
		}
		else
		{
			this._0002(Convert.ToUInt16(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0005_2007 obj = new global::_0005_2007();
		_ = 2;
		if (8 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 6;
		if (4 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (6u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 15:
		{
			byte num3 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (5u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 12:
			this._0002(((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002((ushort)((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((ushort)((global::_000F)_0002)._0002());
			break;
		case 17:
			this._0002((ushort)((global::_0003_2001)_0002)._0002());
			break;
		case 16:
			this._0002(((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002((ushort)((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002((ushort)((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002((ushort)((global::_000E_2006)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToUInt16(((global::_0002_0010)_0002)._0002()));
			break;
		case 7:
			this._0002(Convert.ToUInt16(((global::_0005_2003)_0002)._0002()));
			break;
		case 0:
			this._0002((ushort)(int)((global::_0006_2002)_0002)._0002());
			break;
		case 20:
			this._0002((ushort)(uint)((global::_0002_2003)_0002)._0002());
			break;
		case 22:
			this._0002((ushort)((global::_000F_200B)_0002)._0002());
			break;
		case 8:
			this._0002((ushort)((global::_0006_200A)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
[global::_0006_2007_2005]
internal sealed class _0005_2007_2005 : Attribute
{
	public readonly int _0002;

	public _0005_2007_2005(int _0002)
	{
		if (uint.MaxValue != 0)
		{
			this._0002 = _0002;
		}
	}
}
internal sealed class _0005_2008
{
	private int m__0002;

	public _0005_2008()
	{
		_ = 1;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	public int _0002()
	{
		_ = 0;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (5u != 0)
		{
			this.m__0002 = _0002;
		}
	}
}
internal sealed class _0005_2009 : global::_0002_2007, IDisposable
{
	private static bool m__0002;

	protected global::_000F_2008._0002 _0008;

	protected global::_000F_2008._0006 _0006;

	protected int _000F;

	private int _0005;

	private int _0003;

	private byte[] _000E;

	private byte[] _0002_2004;

	private bool _0008_2004;

	protected _0005_2009(bool _0002, global::_0008_200A _0008)
	{
		if (_0008 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463125495));
		}
		int num = _0008._0002()._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		int num3 = global::_0005_2009._0002(num2);
		if (6u != 0)
		{
			_000F = num3;
		}
		int num4 = global::_0005_2009._0002(num2, _0002);
		if (true)
		{
			this._0002(num4);
		}
		this._0008(global::_0005_2009._0008(num2, _0002));
		global::_000F_2008._0002(global::_000F_2008._0002(out this._0008, global::_0008_0010._0002(-1463124519), 0u));
		string text;
		byte[] array = _0005_2009_2008_2009_0002(_0008, out text);
		global::_000F_2008._0002(global::_000F_2008._0002(this._0008, IntPtr.Zero, text, IntPtr.Zero, out _0006, array, array.Length, 64u));
	}

	static _0005_2009()
	{
		if (6u != 0)
		{
			global::_0005_2009.m__0002 = true;
		}
	}

	public static global::_0005_2009 _0002(bool _0002, global::_0008_200A _0008)
	{
		if (!global::_0005_2009.m__0002)
		{
			return null;
		}
		if (!global::_0003_2002._0008())
		{
			if (6u != 0)
			{
				global::_0005_2009.m__0002 = false;
			}
			return null;
		}
		global::_0005_2009 obj;
		if (6u != 0)
		{
			obj = null;
		}
		try
		{
			global::_0005_2009 obj2 = new global::_0005_2009(_0002, _0008);
			if (2u != 0)
			{
				obj = obj2;
			}
		}
		catch
		{
			obj?.Dispose();
			global::_0005_2009.m__0002 = false;
			return null;
		}
		return obj;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0002()
	{
		_ = -1;
		if (4 == 0)
		{
		}
		return _0005;
	}

	private void _0002(int _0002)
	{
		if (4u != 0)
		{
			_0005 = _0002;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0008()
	{
		_ = 4;
		if (2 == 0)
		{
		}
		return _0003;
	}

	private void _0008(int _0002)
	{
		if (3u != 0)
		{
			_0003 = _0002;
		}
	}

	private static int _0002(int _0002, bool _0008)
	{
		_ = 0;
		if (-1 == 0)
		{
		}
		if (!_0008)
		{
			_ = 0;
			if (7 == 0)
			{
			}
			return (_0002 + 7) / 8;
		}
		_ = 2;
		if (-1 == 0)
		{
		}
		return (_0002 - 1) / 8;
	}

	private static int _0008(int _0002, bool _0008)
	{
		_ = 0;
		if (false)
		{
		}
		if (!_0008)
		{
			_ = 8;
			if (8 == 0)
			{
			}
			return (_0002 - 1) / 8;
		}
		_ = 5;
		if (7 == 0)
		{
		}
		return (_0002 + 7) / 8;
	}

	private static int _0002(int _0002)
	{
		_ = 5;
		if (-1 == 0)
		{
		}
		return (_0002 + 7) / 8;
	}

	private void _0002()
	{
		if (!_0008_2004)
		{
			byte[] array = new byte[_000F];
			if (4u != 0)
			{
				_000E = array;
			}
			byte[] array2 = new byte[_000F];
			if (8u != 0)
			{
				_0002_2004 = array2;
			}
			if (2u != 0)
			{
				_0008_2004 = true;
			}
		}
	}

	public virtual int _0002_2007_2008_2009_0002(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005, RandomNumberGenerator _0003)
	{
		if (0 == 0)
		{
			this._0002();
		}
		byte[] array = _000E;
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		int num = array2.Length - _0006;
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		if (num2 > 0)
		{
			Array.Clear(array2, 0, num2);
		}
		Buffer.BlockCopy(_0002, _0008, array2, num2, _0006);
		global::_000F_2008._0002(global::_000F_2008._0002(this._0006, array2, array2.Length, IntPtr.Zero, _0002_2004, this._000F, out var num3, 1));
		int num4 = _0002_2007_2008_2009_0008();
		int srcOffset = num3 - num4;
		Buffer.BlockCopy(_0002_2004, srcOffset, _000F, _0005, num4);
		return num4;
	}

	protected virtual byte[] _0005_2009_2008_2009_0002(global::_0008_200A _0002, out string _0008)
	{
		_ = 8;
		if (-1 == 0)
		{
		}
		_0008 = global::_0008_0010._0002(-1463124505);
		_ = 8;
		if (1 == 0)
		{
		}
		return global::_0005_2009._0002(_0002);
	}

	protected static byte[] _0002(global::_0008_200A _0002)
	{
		int num = Marshal.SizeOf(typeof(global::_000F_2008._0008));
		byte[] array = new byte[num + _0002._0008()._000F() + _0002._0002()._000F()];
		byte[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		global::_000F_2008._0008 obj = default(global::_000F_2008._0008);
		if (5u != 0)
		{
			obj._0002 = 826364754u;
		}
		int num2 = _0002._0002()._0002();
		if (0 == 0)
		{
			obj._0008 = num2;
		}
		obj._0006 = _0002._0008()._000F();
		obj._000F = _0002._0002()._000F();
		global::_0005_2009._0002(obj, array2, 0);
		int num3 = num;
		num3 += _0002._0008()._0002(array2, num3);
		num3 += _0002._0002()._0002(array2, num3);
		return array2;
	}

	protected static void _0002(global::_000F_2008._0008 _0002, byte[] _0008, int _0006)
	{
		int num = Marshal.SizeOf((object)_0002);
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		if (_0006 + num2 > _0008.Length)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463124581));
		}
		try
		{
		}
		finally
		{
			IntPtr intPtr = Marshal.AllocHGlobal(num2);
			IntPtr intPtr2;
			if (8u != 0)
			{
				intPtr2 = intPtr;
			}
			object structure = _0002;
			if (uint.MaxValue != 0)
			{
				Marshal.StructureToPtr(structure, intPtr2, fDeleteOld: false);
			}
			Marshal.Copy(intPtr2, _0008, _0006, num2);
			Marshal.DestroyStructure(intPtr2, typeof(global::_000F_2008._0008));
			Marshal.FreeHGlobal(intPtr2);
		}
	}

	public void Dispose()
	{
		if (this._0008 != null)
		{
			this._0008.Dispose();
			if (3u != 0)
			{
				this._0008 = null;
			}
		}
		if (_0006 != null)
		{
			_0006.Dispose();
			if (7u != 0)
			{
				_0006 = null;
			}
		}
	}
}
internal static class _0005_2009_2005
{
	private sealed class _0002
	{
		private readonly string m__0002;

		private volatile Assembly _0008;

		internal _0002(string _0002)
		{
			if (2u != 0)
			{
				this.m__0002 = _0002;
			}
		}

		internal Assembly _0002()
		{
			if ((object)_0008 == null)
			{
				_0002 obj;
				if (3u != 0)
				{
					obj = this;
				}
				if (6u != 0)
				{
					Monitor.Enter(obj);
				}
				try
				{
					if ((object)_0008 == null)
					{
						_0008 = _0002(this.m__0002);
					}
				}
				finally
				{
					if (6u != 0)
					{
						Monitor.Exit(obj);
					}
				}
			}
			return _0008;
		}

		private static Assembly _0002(string _0002)
		{
			_ = 5;
			if (1 == 0)
			{
			}
			Assembly assembly = global::_000E_2009_2005._0002(_0002);
			if ((object)assembly == null)
			{
				if (7 == 0)
				{
				}
				_ = 7;
				if (6 == 0)
				{
				}
				assembly = Assembly.Load(_0002);
			}
			return assembly;
		}
	}

	private static readonly Assembly m__0002;

	private static volatile Dictionary<string, _0002> m__0008;

	[ThreadStatic]
	private static bool _0006;

	static _0005_2009_2005()
	{
		Assembly assembly = typeof(global::_0005_2009_2005).Assembly;
		if (3u != 0)
		{
			global::_0005_2009_2005.m__0002 = assembly;
		}
	}

	internal static void _0002()
	{
		AppDomain.CurrentDomain.ResourceResolve += _0002;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0002(object _0002, ResolveEventArgs _0008)
	{
		_ = -1;
		if (false)
		{
		}
		if ((object)_0008.RequestingAssembly != global::_0005_2009_2005.m__0002)
		{
			return null;
		}
		if (_0006)
		{
			return null;
		}
		_ = -1;
		if (6 == 0)
		{
		}
		return global::_0005_2009_2005._0002(_0008.Name);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0002(string _0002)
	{
		if (true)
		{
			_0006 = true;
		}
		try
		{
			if (0 == 0)
			{
				_0008();
			}
			if (global::_0005_2009_2005.m__0008.TryGetValue(_0002, out var value))
			{
				return value._0002();
			}
			if (7u != 0)
			{
				return null;
			}
		}
		finally
		{
			_0006 = false;
		}
		Assembly result;
		return result;
	}

	private static void _0008()
	{
		if (global::_0005_2009_2005.m__0008 != null)
		{
			return;
		}
		Assembly assembly = global::_0005_2009_2005.m__0002;
		Assembly obj;
		if (6u != 0)
		{
			obj = assembly;
		}
		if (4u != 0)
		{
			Monitor.Enter(obj);
		}
		try
		{
			if (global::_0005_2009_2005.m__0008 != null)
			{
				return;
			}
			string text = global::_0008_0010._0002(-1463133877);
			string text2;
			if (true)
			{
				text2 = text;
			}
			string[] array = text2.Split(':');
			int num = array.Length;
			Dictionary<string, _0002> dictionary = new Dictionary<string, _0002>(3, StringComparer.Ordinal);
			for (int i = 0; i != num; i++)
			{
				string text3 = array[i];
				string[] array2 = text3.Split('|');
				_0002 value = new _0002(array2[0]);
				int num2 = array2.Length;
				for (int j = 1; j != num2; j++)
				{
					string key = array2[j];
					dictionary.Add(key, value);
				}
			}
			global::_0005_2009_2005.m__0008 = dictionary;
		}
		finally
		{
			Monitor.Exit(obj);
		}
	}
}
internal sealed class _0005_200A : global::_0006
{
	private new bool m__0002;

	public _0005_200A()
	{
		_ = -1;
		if (2 == 0)
		{
		}
		base._002Ector(15);
	}

	public new bool _0002()
	{
		_ = 7;
		if (2 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(bool _0002)
	{
		if (5u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = -1;
		if (5 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		bool num = Convert.ToBoolean(_0002);
		if (8u != 0)
		{
			this._0002(num);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (uint.MaxValue != 0)
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
		case 15:
		{
			bool num3 = ((global::_0005_200A)_0002)._0002();
			if (7u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 1:
			this._0002(Convert.ToBoolean(((global::_000F)_0002)._0002()));
			break;
		case 13:
			this._0002(Convert.ToBoolean(((global::_0003_2000)_0002)._0002()));
			break;
		case 26:
			this._0002(Convert.ToBoolean(((global::_000E_2009)_0002)._0002()));
			break;
		case 3:
			this._0002(Convert.ToBoolean(((global::_000F_2001)_0002)._0002()));
			break;
		case 14:
			this._0002(Convert.ToBoolean(((global::_000E_2006)_0002)._0002()));
			break;
		case 16:
			this._0002(Convert.ToBoolean(((global::_0005_2007)_0002)._0002()));
			break;
		case 0:
			this._0002(Convert.ToBoolean(((global::_0006_2002)_0002)._0002()));
			break;
		case 20:
			this._0002(Convert.ToBoolean(((global::_0002_2003)_0002)._0002()));
			break;
		case 7:
			this._0002(Convert.ToBoolean(((global::_0005_2003)_0002)._0002()));
			break;
		case 17:
			this._0002(Convert.ToBoolean(((global::_0003_2001)_0002)._0002()));
			break;
		case 12:
			this._0002(Convert.ToBoolean(((global::_0008_2004_2005)_0002)._0002()));
			break;
		case 19:
			this._0002(Convert.ToBoolean(((global::_0002_0010)_0002)._0002()));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0005_200A obj = new global::_0005_200A();
		_ = 4;
		if (7 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 3;
		if (2 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}
}
internal abstract class _0006
{
	private readonly int m__0002;

	private Type _0008;

	protected _0006(int _0002)
	{
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public abstract object _0006_2008_2009_0002();

	public abstract void _0006_2008_2009_0002(object _0002);

	public int _0002()
	{
		_ = 2;
		if (4 == 0)
		{
		}
		return this.m__0002;
	}

	public abstract global::_0006 _0006_2008_2009_0002(global::_0006 _0002);

	public abstract global::_0006 _0006_2008_2009_0002();

	public Type _0002()
	{
		_ = -1;
		if (6 == 0)
		{
		}
		return _0008;
	}

	public void _0002(Type _0002)
	{
		if (0 == 0)
		{
			_0008 = _0002;
		}
	}

	public static global::_0006 _0002(object _0002, Type _0008)
	{
		global::_0006 obj = _0002 as global::_0006;
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		if (obj2 != null)
		{
			return obj2;
		}
		if (_0008 == null)
		{
			if (_0002 == null)
			{
				return new global::_0005_2003();
			}
			Type type = _0002.GetType();
			if (4u != 0)
			{
				_0008 = type;
			}
		}
		Type type2 = global::_0002_2008._0008(_0008);
		if (8u != 0)
		{
			_0008 = type2;
		}
		int num = global::_0002_2008._0002(_0008);
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 10:
		{
			global::_0005_2005 obj6 = new global::_0005_2005();
			if (uint.MaxValue != 0)
			{
				obj2 = obj6;
			}
			break;
		}
		case 8:
			obj2 = new global::_0006_200A();
			break;
		case 22:
			obj2 = new global::_000F_200B();
			break;
		case 15:
			obj2 = new global::_0005_200A();
			break;
		case 6:
			obj2 = new global::_000E_200A();
			break;
		case 14:
			obj2 = new global::_000E_2006();
			break;
		case 3:
			obj2 = new global::_000F_2001();
			break;
		case 16:
			obj2 = new global::_0005_2007();
			break;
		case 13:
			obj2 = new global::_0003_2000();
			break;
		case 1:
			obj2 = new global::_000F();
			break;
		case 26:
			obj2 = new global::_000E_2009();
			break;
		case 12:
			obj2 = new global::_0008_2004_2005();
			break;
		case 17:
			obj2 = new global::_0003_2001();
			break;
		case 0:
			obj2 = new global::_0006_2002();
			break;
		case 20:
			obj2 = new global::_0002_2003();
			break;
		case 7:
			obj2 = new global::_0005_2003();
			if (_0002 != null && _0002.GetType() != global::_0002_2008._0002)
			{
				obj2._0002(_0002.GetType());
			}
			break;
		case 9:
			obj2 = new global::_0006_2004();
			break;
		case 19:
		{
			Enum obj5 = ((_0002 != null) ? ((Enum)Enum.ToObject(_0008, _0002)) : ((!_0008.IsNested || !_0008.DeclaringType.ContainsGenericParameters) ? ((Enum)Activator.CreateInstance(_0008)) : ((Enum)Enum.Parse(_0008, global::_0008_0010._0002(-1463124604)))));
			return new global::_0002_0010(obj5);
		}
		case 5:
		{
			global::_0005_2003 obj4 = new global::_0005_2003();
			((global::_0006)obj4)._0002(_0008);
			obj2 = obj4;
			break;
		}
		case 25:
			if (_0002 == null)
			{
				if (_0008 != global::_0002_2008._0005)
				{
					_0002 = Activator.CreateInstance(_0008);
				}
			}
			else if (_0002.GetType() != _0008)
			{
				try
				{
					_0002 = Convert.ChangeType(_0002, _0008);
				}
				catch
				{
				}
			}
			return new global::_000E_2005(_0002);
		default:
			obj2 = new global::_0005_2003();
			break;
		}
		if (_0002 != null)
		{
			obj2._0006_2008_2009_0002(_0002);
		}
		return obj2;
	}
}
internal sealed class _0006_2000 : global::_0005
{
	private readonly int m__0002;

	private readonly Stream _0008;

	public _0006_2000(Stream _0002, int _0008)
	{
		if (2u != 0)
		{
			this._0008 = _0002;
		}
		int num = _0008 ^ -559030707;
		if (6u != 0)
		{
			this.m__0002 = num;
		}
	}

	public Stream _0002()
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		return _0008;
	}

	[SpecialName]
	public override bool _0005_2008_2009_0002()
	{
		_ = 0;
		if (1 == 0)
		{
		}
		return _0002().CanRead;
	}

	[SpecialName]
	public override bool _0005_2008_2009_0006()
	{
		_ = 5;
		if (1 == 0)
		{
		}
		return _0002().CanSeek;
	}

	[SpecialName]
	public override bool _0005_2008_2009_0008()
	{
		_ = 0;
		if (false)
		{
		}
		return _0002().CanWrite;
	}

	public override void _0005_2008_2009_0008()
	{
		_ = 3;
		if (4 == 0)
		{
		}
		_0002().Flush();
	}

	[SpecialName]
	public override long _0005_2008_2009_0002()
	{
		_ = 6;
		if (4 == 0)
		{
		}
		return _0002().Length;
	}

	[SpecialName]
	public override long _0005_2008_2009_0008()
	{
		_ = 0;
		if (7 == 0)
		{
		}
		return _0002().Position;
	}

	[SpecialName]
	public override void _0005_2008_2009_0002(long _0002)
	{
		_ = 1;
		if (6 == 0)
		{
		}
		Stream stream = this._0002();
		_ = 8;
		if (4 == 0)
		{
		}
		stream.Position = _0002;
	}

	private byte _0002(byte _0002, uint _0008)
	{
		byte num = (byte)(this.m__0002 ^ (int)_0008);
		byte b;
		if (5u != 0)
		{
			b = num;
		}
		return (byte)(_0002 ^ b);
	}

	public override void _0005_2008_2009_0002(byte[] _0002, int _0008, int _0006)
	{
		int num = (int)((global::_0005)this)._0005_2008_2009_0008();
		uint num2;
		if (4u != 0)
		{
			num2 = (uint)num;
		}
		byte[] array = new byte[_0006];
		byte[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		uint num3 = default(uint);
		if (0 == 0)
		{
			num3 = 0u;
		}
		for (; num3 < _0006; num3++)
		{
			array2[num3] = this._0002(_0002[num3 + _0008], num2 + num3);
		}
		this._0002().Write(array2, 0, _0006);
	}

	public override int _0005_2008_2009_0002(byte[] _0002, int _0008, int _0006)
	{
		int num = (int)((global::_0005)this)._0005_2008_2009_0008();
		uint num2;
		if (true)
		{
			num2 = (uint)num;
		}
		int num3 = this._0002().Read(_0002, _0008, _0006);
		int num4;
		if (true)
		{
			num4 = num3;
		}
		int num5 = _0008 + num4;
		int num6 = default(int);
		if (0 == 0)
		{
			num6 = num5;
		}
		for (int i = _0008; i < num6; i++)
		{
			_0002[i] = this._0002(_0002[i], num2++);
		}
		return num4;
	}

	public override long _0005_2008_2009_0002(long _0002, int _0008)
	{
		SeekOrigin origin = default(SeekOrigin);
		switch (_0008)
		{
		case 0:
			if (0 == 0)
			{
				origin = SeekOrigin.Begin;
			}
			break;
		case 1:
			if (3u != 0)
			{
				origin = SeekOrigin.Current;
			}
			break;
		case 2:
			if (4u != 0)
			{
				origin = SeekOrigin.End;
			}
			break;
		default:
			throw new ArgumentException();
		}
		return this._0002().Seek(_0002, origin);
	}

	public override void _0005_2008_2009_0008(long _0002)
	{
		_ = 5;
		if (false)
		{
		}
		Stream stream = this._0002();
		_ = 4;
		if (8 == 0)
		{
		}
		stream.SetLength(_0002);
	}
}
internal sealed class _0006_2001
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 20)]
	internal struct _0002
	{
	}

	internal static readonly _0002 _0002/* Not supported: data(B1 84 1C 03 ED 5E 09 00 39 1C 00 00 55 00 00 00 01 00 00 00) */;
}
internal static class _0006_2001_2005
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 128)]
	private struct a1
	{
	}

	private static global::_0008_2005 _000F_2001_2005;

	[ThreadStatic]
	private static Stream _0005_2001_2005;

	internal static a1 a1/* Not supported: data(D0 B9 9A FB 5F F1 3D 73 10 03 EA 3F BE 36 09 6E 6F 69 7A 2C 1B 29 C8 01 36 95 01 EC 67 09 18 17 17 C6 1A 2E 73 B8 96 29 32 D4 80 1D 88 3C E7 C2 F8 00 E3 1F B0 E1 95 9C 14 33 BB BF 0B E4 B1 9E 11 69 95 13 7A 52 ED 94 D6 F8 64 50 8B D0 12 C3 69 E5 8C E1 0E 59 89 8C 41 CE 3C 92 F1 24 A8 62 78 E3 87 E1 AD F5 E7 D6 EC 88 0A 16 72 28 4A 1A B7 D3 E3 35 6D 27 FF 18 E2 19 B0 FC 65 43 E8 58) */;

	public static string _0002()
	{
		return global::_0008_0010._0002(-1463127540);
	}

	public static Stream _0003_2001_2005()
	{
		if (_0005_2001_2005 == null)
		{
			_0005_2001_2005 = global::_000F_2002._0002(typeof(global::_0006_2001_2005).Assembly.GetManifestResourceStream("b5ef76d72d1f4a87ddd70f240766e16b"), new byte[128]
			{
				208, 185, 154, 251, 95, 241, 61, 115, 16, 3,
				234, 63, 190, 54, 9, 110, 111, 105, 122, 44,
				27, 41, 200, 1, 54, 149, 1, 236, 103, 9,
				24, 23, 23, 198, 26, 46, 115, 184, 150, 41,
				50, 212, 128, 29, 136, 60, 231, 194, 248, 0,
				227, 31, 176, 225, 149, 156, 20, 51, 187, 191,
				11, 228, 177, 158, 17, 105, 149, 19, 122, 82,
				237, 148, 214, 248, 100, 80, 139, 208, 18, 195,
				105, 229, 140, 225, 14, 89, 137, 140, 65, 206,
				60, 146, 241, 36, 168, 98, 120, 227, 135, 225,
				173, 245, 231, 214, 236, 136, 10, 22, 114, 40,
				74, 26, 183, 211, 227, 53, 109, 39, 255, 24,
				226, 25, 176, 252, 101, 67, 232, 88
			}, _0002());
		}
		return _0005_2001_2005;
	}

	internal static void _000E_2001_2005(global::_0006_2009 P_0)
	{
		object[] array = new object[1] { P_0 };
		_0002_2002_2005()._0002(_0003_2001_2005(), "E-ceSIsufo", array);
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	public static global::_0006_2009 _0002_2002_2005()
	{
		bool flag = default(bool);
		if (_000F_2001_2005 == null)
		{
			_000F_2001_2005 = new global::_0008_2005();
			flag = true;
		}
		global::_0006_2009 obj = new global::_0006_2009(_000F_2001_2005);
		if (flag)
		{
			_000E_2001_2005(obj);
		}
		return obj;
	}
}
internal sealed class _0006_2002 : global::_0006
{
	private new IntPtr m__0002;

	public _0006_2002()
	{
		_ = -1;
		if (false)
		{
		}
		base._002Ector(0);
	}

	public new IntPtr _0002()
	{
		_ = 4;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(IntPtr _0002)
	{
		if (true)
		{
			this.m__0002 = _0002;
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0006_2002 obj = new global::_0006_2002();
		_ = -1;
		if (-1 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 6;
		if (6 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 8;
		if (2 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		IntPtr intPtr = (IntPtr)_0002;
		if (0 == 0)
		{
			this._0002(intPtr);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (5u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 0:
		{
			IntPtr intPtr = ((global::_0006_2002)_0002)._0002();
			if (5u != 0)
			{
				this._0002(intPtr);
			}
			break;
		}
		case 12:
			this._0002((IntPtr)((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002((IntPtr)((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((IntPtr)((global::_000F)_0002)._0002());
			break;
		case 17:
			this._0002((IntPtr)((global::_0003_2001)_0002)._0002());
			break;
		case 16:
			this._0002((IntPtr)((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002((IntPtr)((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002((IntPtr)((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002((IntPtr)(long)((global::_000E_2006)_0002)._0002());
			break;
		case 7:
			this._0002((IntPtr)((global::_0005_2003)_0002)._0002());
			break;
		case 22:
			this._0002((IntPtr)(long)((global::_000F_200B)_0002)._0002());
			break;
		case 19:
			this._0002(new IntPtr(Convert.ToInt64(((global::_0002_0010)_0002)._0002())));
			break;
		case 8:
			this._0002((IntPtr)(long)((global::_0006_200A)_0002)._0002());
			break;
		case 21:
		{
			global::_000F_2004_2005 obj = (global::_000F_2004_2005)_0002;
			this._0002(obj._0002());
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal sealed class _0006_2003 : Stream
{
	private bool m__0002;

	private Stream _0008;

	private global::_0002_2001[] _0006;

	private global::_0006_2004_2005 _000F;

	private global::_0005_200B _0005;

	private global::_000F_200A _0003;

	private bool _000E;

	private byte[] _0002_2004;

	private int _0008_2004;

	private int _0006_2004;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => false;

	public override long Length
	{
		get
		{
			_ = 4;
			if (3 == 0)
			{
			}
			return _0008.Length;
		}
	}

	public override long Position
	{
		get
		{
			_ = 1;
			if (6 == 0)
			{
			}
			long position = _0008.Position;
			_ = 3;
			if (6 == 0)
			{
			}
			int num = _0008_2004;
			_ = 6;
			if (-1 == 0)
			{
			}
			return position + (num - _0006_2004);
		}
		set
		{
			_ = 8;
			if (4 == 0)
			{
			}
			_ = 0;
			if (false)
			{
			}
			Seek(value, SeekOrigin.Begin);
			if (true)
			{
			}
		}
	}

	public _0006_2003(Stream _0002, global::_0006_2004_2005 _0008 = null, global::_0005_200B _0006 = null, bool _000F = false)
	{
		if (8u != 0)
		{
			this._0008 = _0002;
		}
		if (true)
		{
			this.m__0002 = _000F;
		}
		if (8u != 0)
		{
			_0005 = _0006;
		}
		this._000F = _0008;
		if (this._000F == null)
		{
			this._000F = global::_0006_2004_2005._0002();
		}
		if (this._000F._0008() == 0)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463125495));
		}
		if (this._000F._0006() == 0)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463125495));
		}
		if (!this._0008.CanRead)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463125448));
		}
		if (!this._0008.CanSeek)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463125448));
		}
	}

	private void _0002()
	{
		if (_000E)
		{
			return;
		}
		global::_0002_2001[] array = new global::_0002_2001[_000F._0008()];
		if (2u != 0)
		{
			_0006 = array;
		}
		int num = default(int);
		if (0 == 0)
		{
			num = 0;
		}
		while (num < _000F._0008())
		{
			_0006[num] = new global::_0002_2001();
			int num2 = num + 1;
			if (4u != 0)
			{
				num = num2;
			}
		}
		if (_0005 != null)
		{
			_0003 = _0005._0002(_000F);
		}
		_000E = true;
	}

	protected override void Dispose(bool _0002)
	{
		try
		{
			if (_0002 && !this.m__0002)
			{
				_0008.Close();
			}
		}
		finally
		{
			if (8u != 0)
			{
				base.Dispose(_0002);
			}
		}
	}

	public override void SetLength(long _0002)
	{
		throw new NotSupportedException();
	}

	public override void Write(byte[] _0002, int _0008, int _0006)
	{
		throw new NotSupportedException();
	}

	public override void Flush()
	{
	}

	private int _0002(byte[] _0002, int _0008, int _0006)
	{
		int num = _0006_2004 - _0008_2004;
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		if (num2 <= 0)
		{
			return 0;
		}
		if (num2 > _0006)
		{
			if (8u != 0)
			{
				num2 = _0006;
			}
		}
		byte[] src = _0002_2004;
		int srcOffset = _0008_2004;
		int count = num2;
		if (2u != 0)
		{
			Buffer.BlockCopy(src, srcOffset, _0002, _0008, count);
		}
		_0008_2004 += num2;
		return num2;
	}

	private void _0002(int _0002)
	{
		int num = (int)_0008.Position;
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		if (num2 >= _0008.Length)
		{
			return;
		}
		int num3 = num2 + _0002;
		int num4;
		if (7u != 0)
		{
			num4 = num3;
		}
		global::_0002_2001[] array = _0006;
		global::_0002_2001[] array2 = default(global::_0002_2001[]);
		if (0 == 0)
		{
			array2 = array;
		}
		int i;
		if (6u != 0)
		{
			i = 0;
		}
		for (; i < array2.Length; i++)
		{
			global::_0002_2001 obj = array2[i];
			global::_0002_2001 obj2;
			if (7u != 0)
			{
				obj2 = obj;
			}
			if (obj2._0008 <= num2 && obj2._0006 >= num4)
			{
				byte[] array3 = obj2._0002;
				if (true)
				{
					_0002_2004 = array3;
				}
				_0006_2004 = obj2._0006 - obj2._0008;
				_0008_2004 = num2 - obj2._0008;
				_0008.Position = obj2._0006;
				obj2._000F = DateTime.UtcNow;
				return;
			}
		}
		int num5 = 0;
		DateTime dateTime = _0006[0]._000F;
		for (int j = 1; j < _0006.Length; j++)
		{
			if (_0006[j]._000F < dateTime)
			{
				num5 = j;
			}
		}
		global::_0002_2001 obj3 = _0006[num5];
		if (obj3._0002 == null)
		{
			obj3._0002 = new byte[_000F._0002()];
		}
		int num6 = num2;
		num2 = this._0002(num2);
		if (num2 < 0)
		{
			num2 = 0;
		}
		num4 = num2 + _000F._0002();
		if (_0003 == null || !_0003._0002(num2, ref obj3))
		{
			obj3._0008 = num2;
			obj3._000F = DateTime.UtcNow;
			_0002_2004 = obj3._0002;
			_0008.Position = num2;
			_0006_2004 = _0008.Read(_0002_2004, 0, num4 - num2);
			_0008_2004 = num6 - num2;
			obj3._0006 = num2 + _0006_2004;
			if (_0003 != null)
			{
				_0003._0002(obj3);
			}
		}
		else
		{
			_0002_2004 = obj3._0002;
			_0006_2004 = obj3._0006 - num2;
			_0008.Position = obj3._0006;
			_0008_2004 = num6 - num2;
		}
	}

	private int _0002(int _0002)
	{
		_ = -1;
		if (1 == 0)
		{
		}
		_ = 5;
		if (false)
		{
		}
		_ = 6;
		if (5 == 0)
		{
		}
		return _0002 - _0002 % _000F._0002();
	}

	public override int Read(byte[] _0002, int _0008, int _0006)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463125465));
		}
		if (_0008 < 0)
		{
			throw new ArgumentOutOfRangeException(global::_0008_0010._0002(-1463125296));
		}
		if (_0006 < 0)
		{
			throw new ArgumentOutOfRangeException(global::_0008_0010._0002(-1463125283));
		}
		if (_0002.Length - _0008 < _0006)
		{
			throw new ArgumentException();
		}
		int num = _0008;
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		int num3 = this._0002(_0002, _0008, _0006);
		int num4;
		if (5u != 0)
		{
			num4 = num3;
		}
		if (num4 == _0006)
		{
			return num4;
		}
		int num5 = num4;
		int num6;
		if (2u != 0)
		{
			num6 = num5;
		}
		if (num4 > 0)
		{
			int num7 = _0006 - num4;
			if (4u != 0)
			{
				_0006 = num7;
			}
			_0008 += num4;
		}
		_0008_2004 = (_0006_2004 = 0);
		this._0002();
		if (_0006 >= _000F._0002())
		{
			if (_0003 == null)
			{
				return this._0008.Read(_0002, _0008, _0006) + num6;
			}
			int num8 = (int)this._0008.Position - num6;
			if (_0003._0002(num8, _0002, num2, _0006 + num6, out var num9))
			{
				this._0008.Seek(num9 - num6, SeekOrigin.Current);
				return num9;
			}
			num9 = this._0008.Read(_0002, _0008, _0006);
			if (num9 != 0)
			{
				_0003._0002(num8, _0002, num2, num9 + num6, num9 < _0006);
			}
			return num9 + num6;
		}
		this._0002(_0006);
		num4 = this._0002(_0002, _0008, _0006);
		return num4 + num6;
	}

	public override long Seek(long _0002, SeekOrigin _0008)
	{
		if (_0006_2004 - _0008_2004 > 0 && _0008 == SeekOrigin.Current)
		{
			long num = _0002 - (_0006_2004 - _0008_2004);
			if (uint.MaxValue != 0)
			{
				_0002 = num;
			}
		}
		long position = Position;
		long num2;
		if (8u != 0)
		{
			num2 = position;
		}
		long num3 = this._0008.Seek(_0002, _0008);
		long num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		_0008_2004 = (int)(num4 - (num2 - _0008_2004));
		if (0 <= _0008_2004 && _0008_2004 < _0006_2004)
		{
			this._0008.Seek(_0006_2004 - _0008_2004, SeekOrigin.Current);
		}
		else
		{
			_0008_2004 = (_0006_2004 = 0);
		}
		return num4;
	}
}
internal interface _0006_2003_2005
{
	void _0006_2003_2005_2008_2009_0002();
}
internal sealed class _0006_2004 : global::_0006
{
	private new Array m__0002;

	public _0006_2004()
	{
		_ = 0;
		if (7 == 0)
		{
		}
		base._002Ector(9);
	}

	public new Array _0002()
	{
		_ = 2;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(Array _0002)
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 0;
		if (8 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		Array obj = (Array)_0002;
		if (true)
		{
			this._0002(obj);
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0006_2004 obj = new global::_0006_2004();
		_ = 2;
		if (4 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 0;
		if (1 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (2u != 0)
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
		case 9:
		{
			Array array = ((global::_0006_2004)_0002)._0002();
			if (7u != 0)
			{
				this._0002(array);
			}
			break;
		}
		case 7:
			this._0002((Array)((global::_0005_2003)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal sealed class _0006_2004_2005 : IEquatable<global::_0006_2004_2005>
{
	private int m__0002;

	private int m__0008;

	private int m__0006;

	private int m__000F;

	private int m__0005;

	private static readonly global::_0006_2004_2005 _0003;

	public _0006_2004_2005()
	{
		if (uint.MaxValue != 0)
		{
			this.m__0002 = 255;
		}
		if (0 == 0)
		{
			this.m__0008 = 12;
		}
		if (3u != 0)
		{
			this.m__0006 = 96;
		}
		this.m__000F = 10;
		this.m__0005 = 4;
		base._002Ector();
	}

	static _0006_2004_2005()
	{
		global::_0006_2004_2005 obj = new global::_0006_2004_2005();
		if (7u != 0)
		{
			_0003 = obj;
		}
	}

	public int _0002()
	{
		_ = 0;
		if (4 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (2u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public int _0008()
	{
		_ = 8;
		if (false)
		{
		}
		return this.m__0008;
	}

	public void _0008(int _0002)
	{
		if (3u != 0)
		{
			this.m__0008 = _0002;
		}
	}

	public int _0006()
	{
		_ = 7;
		if (2 == 0)
		{
		}
		return this.m__0006;
	}

	public void _0006(int _0002)
	{
		if (8u != 0)
		{
			this.m__0006 = _0002;
		}
	}

	public int _000F()
	{
		_ = -1;
		if (6 == 0)
		{
		}
		return this.m__000F;
	}

	public void _000F(int _0002)
	{
		if (4u != 0)
		{
			this.m__000F = _0002;
		}
	}

	public int _0005()
	{
		_ = -1;
		if (3 == 0)
		{
		}
		return this.m__0005;
	}

	public void _0005(int _0002)
	{
		if (3u != 0)
		{
			this.m__0005 = _0002;
		}
	}

	public static global::_0006_2004_2005 _0002()
	{
		return _0003;
	}

	public override bool Equals(object _0002)
	{
		_ = 7;
		if (false)
		{
		}
		_ = 6;
		if (false)
		{
		}
		return global::_0006_2004_2005._0002(this, _0002 as global::_0006_2004_2005);
	}

	public bool Equals(global::_0006_2004_2005 _0002)
	{
		_ = 8;
		if (3 == 0)
		{
		}
		_ = 4;
		if (1 == 0)
		{
		}
		return global::_0006_2004_2005._0002(this, _0002);
	}

	public static bool _0002(global::_0006_2004_2005 _0002, global::_0006_2004_2005 _0008)
	{
		_ = 3;
		if (7 == 0)
		{
		}
		_ = 4;
		if (6 == 0)
		{
		}
		if (_0002 == _0008)
		{
			return true;
		}
		_ = 6;
		if (5 == 0)
		{
		}
		if (_0002 == null || _0008 == null)
		{
			return false;
		}
		if (_0002._0002() == _0008._0002() && _0002._0008() == _0008._0008() && _0002._0006() == _0008._0006() && _0002._000F() == _0008._000F())
		{
			return _0002._0005() == _0008._0005();
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = this._0002();
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		int num3 = (-8832819 + num2.GetHashCode()) * -1521134295;
		int num4 = _0008();
		if (5u != 0)
		{
			num2 = num4;
		}
		int num5 = (num3 + num2.GetHashCode()) * -1521134295;
		int num6 = _0006();
		if (4u != 0)
		{
			num2 = num6;
		}
		return ((num5 + num2.GetHashCode()) * -1521134295 + _000F().GetHashCode()) * -1521134295 + _0005().GetHashCode();
	}
}
internal sealed class _0006_2005
{
	private static readonly int[] m__0002;

	public static readonly global::_0006_2005 _0008;

	public static readonly global::_0006_2005 _0006;

	private static readonly byte[] m__000F;

	private int[] _0005;

	private int _0003;

	private int _000E;

	private int _0002_2004;

	static _0006_2005()
	{
		int[] array = new int[0];
		if (3u != 0)
		{
			global::_0006_2005.m__0002 = array;
		}
		byte[] array2 = new byte[256];
		if (2u != 0)
		{
			RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		}
		if (6u != 0)
		{
			global::_0006_2005.m__000F = array2;
		}
		global::_0006_2005._0008 = new global::_0006_2005(0, global::_0006_2005.m__0002, _0006: false);
		global::_0006_2005._0008._000E = 0;
		global::_0006_2005._0006 = _0002(1uL);
	}

	public _0006_2005(int _0002, int[] _0008, bool _0006)
	{
		if (6u != 0)
		{
			_000E = -1;
		}
		base._002Ector();
		if (_0006)
		{
			int num;
			if (uint.MaxValue != 0)
			{
				num = 0;
			}
			while (num < _0008.Length && _0008[num] == 0)
			{
				int num2 = num + 1;
				if (2u != 0)
				{
					num = num2;
				}
			}
			if (num == _0008.Length)
			{
				_0003 = 0;
				_0005 = global::_0006_2005.m__0002;
				return;
			}
			_0003 = _0002;
			if (num == 0)
			{
				_0005 = _0008;
				return;
			}
			_0005 = new int[_0008.Length - num];
			Array.Copy(_0008, num, _0005, 0, _0005.Length);
		}
		else
		{
			_0003 = _0002;
			_0005 = _0008;
		}
	}

	public _0006_2005(int _0002, byte[] _0008)
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		_ = 8;
		if (8 == 0)
		{
		}
		_ = 3;
		if (5 == 0)
		{
		}
		this._002Ector(_0002, _0008, 0, _0008.Length);
	}

	public _0006_2005(int _0002, byte[] _0008, int _0006, int _000F)
	{
		if (3u != 0)
		{
			_000E = -1;
		}
		base._002Ector();
		if (_0002 == 0)
		{
			if (uint.MaxValue != 0)
			{
				_0003 = 0;
			}
			int[] array = global::_0006_2005.m__0002;
			if (true)
			{
				_0005 = array;
			}
		}
		else
		{
			_0005 = global::_0006_2005._0002(_0008, _0006, _000F);
			_0003 = ((_0005.Length >= 1) ? _0002 : 0);
		}
	}

	public int[] _0002()
	{
		_ = 1;
		if (5 == 0)
		{
		}
		return _0005;
	}

	private static int _0002(int _0002)
	{
		_ = -1;
		if (false)
		{
		}
		return (_0002 + 8 - 1) / 8;
	}

	private static int[] _0002(byte[] _0002, int _0008, int _0006)
	{
		int num = _0008 + _0006;
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		int num3;
		if (8u != 0)
		{
			num3 = _0008;
		}
		while (num3 < num2 && _0002[num3] == 0)
		{
			int num4 = num3 + 1;
			if (6u != 0)
			{
				num3 = num4;
			}
		}
		if (num3 >= num2)
		{
			return global::_0006_2005.m__0002;
		}
		int num5 = (num2 - num3 + 3) / 4;
		int num6 = (num2 - num3) % 4;
		if (num6 == 0)
		{
			num6 = 4;
		}
		if (num5 < 1)
		{
			return global::_0006_2005.m__0002;
		}
		int[] array = new int[num5];
		int num7 = 0;
		int num8 = 0;
		for (int i = num3; i < num2; i++)
		{
			num7 <<= 8;
			num7 |= _0002[i] & 0xFF;
			num6--;
			if (num6 <= 0)
			{
				array[num8] = num7;
				num8++;
				num6 = 4;
				num7 = 0;
			}
		}
		if (num8 < array.Length)
		{
			array[num8] = num7;
		}
		return array;
	}

	private static int _0002(int _0002, int _0008, int[] _0006)
	{
		while (true)
		{
			if (_0008 >= _0006.Length)
			{
				return 0;
			}
			if (_0006[_0008] != 0)
			{
				break;
			}
			int num = _0008 + 1;
			if (7u != 0)
			{
				_0008 = num;
			}
		}
		int num2 = 32 * (_0006.Length - _0008 - 1);
		int num3 = _0006[_0008];
		int num4;
		if (7u != 0)
		{
			num4 = num3;
		}
		return num2 + global::_0006_2005._0008(num4);
	}

	public int _0002()
	{
		_ = 8;
		if (-1 == 0)
		{
		}
		if (_000E == -1)
		{
			_ = 7;
			if (false)
			{
			}
			_ = 1;
			if (1 == 0)
			{
			}
			_000E = ((_0003 != 0) ? _0002(_0003, 0, _0005) : 0);
		}
		return _000E;
	}

	private static int _0008(int _0002)
	{
		uint num;
		if (true)
		{
			num = (uint)_0002;
		}
		uint num2 = num >> 24;
		uint num3;
		if (7u != 0)
		{
			num3 = num2;
		}
		if (num3 != 0)
		{
			return 24 + global::_0006_2005.m__000F[num3];
		}
		uint num4 = num >> 16;
		if (6u != 0)
		{
			num3 = num4;
		}
		if (num3 != 0)
		{
			return 16 + global::_0006_2005.m__000F[num3];
		}
		num3 = num >> 8;
		if (num3 != 0)
		{
			return 8 + global::_0006_2005.m__000F[num3];
		}
		return global::_0006_2005.m__000F[num];
	}

	public int _0002(object _0002)
	{
		_ = 7;
		if (2 == 0)
		{
		}
		_ = 1;
		if (2 == 0)
		{
		}
		return this._0002((global::_0006_2005)_0002);
	}

	private static int _0002(int _0002, int[] _0008, int _0006, int[] _000F)
	{
		while (_0002 != _0008.Length && _0008[_0002] == 0)
		{
			int num = _0002 + 1;
			if (8u != 0)
			{
				_0002 = num;
			}
		}
		while (_0006 != _000F.Length && _000F[_0006] == 0)
		{
			int num2 = _0006 + 1;
			if (true)
			{
				_0006 = num2;
			}
		}
		return global::_0006_2005._0008(_0002, _0008, _0006, _000F);
	}

	private static int _0008(int _0002, int[] _0008, int _0006, int[] _000F)
	{
		int num = _0008.Length - _000F.Length - (_0002 - _0006);
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		if (num2 != 0)
		{
			if (num2 >= 0)
			{
				return 1;
			}
			return -1;
		}
		while (_0002 < _0008.Length)
		{
			int num3 = _0002;
			int num4 = num3 + 1;
			if (6u != 0)
			{
				_0002 = num4;
			}
			int num5 = _0008[num3];
			uint num6;
			if (3u != 0)
			{
				num6 = (uint)num5;
			}
			uint num7 = (uint)_000F[_0006++];
			if (num6 != num7)
			{
				if (num6 >= num7)
				{
					return 1;
				}
				return -1;
			}
		}
		return 0;
	}

	public int _0002(global::_0006_2005 _0002)
	{
		_ = -1;
		if (5 == 0)
		{
		}
		int num = _0003;
		_ = 8;
		if (7 == 0)
		{
		}
		if (num >= _0002._0003)
		{
			_ = 1;
			if (-1 == 0)
			{
			}
			if (_0003 <= _0002._0003)
			{
				if (_0003 != 0)
				{
					return _0003 * _0008(0, _0005, 0, _0002._0005);
				}
				return 0;
			}
			return 1;
		}
		return -1;
	}

	public override bool Equals(object _0002)
	{
		if (_0002 == this)
		{
			return true;
		}
		global::_0006_2005 obj = _0002 as global::_0006_2005;
		global::_0006_2005 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		if (obj2 == null)
		{
			return false;
		}
		if (_0003 == obj2._0003)
		{
			return this._0002(obj2);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = _0005.Length;
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		if (_0005.Length != 0)
		{
			int num3 = num2 ^ _0005[0];
			if (7u != 0)
			{
				num2 = num3;
			}
			if (_0005.Length > 1)
			{
				int num4 = num2 ^ _0005[_0005.Length - 1];
				if (4u != 0)
				{
					num2 = num4;
				}
			}
		}
		return num2;
	}

	private bool _0002(global::_0006_2005 _0002)
	{
		_ = _0002._0005;
		if (_0005.Length != _0002._0005.Length)
		{
			return false;
		}
		int num;
		if (uint.MaxValue != 0)
		{
			num = 0;
		}
		while (num < _0005.Length)
		{
			if (_0005[num] != _0002._0005[num])
			{
				return false;
			}
			int num2 = num + 1;
			if (2u != 0)
			{
				num = num2;
			}
		}
		return true;
	}

	public global::_0006_2005 _0002(global::_0006_2005 _0002, global::_0006_2005 _0008)
	{
		if (_0008.Equals(global::_0006_2005._0006))
		{
			return global::_0006_2005._0008;
		}
		if (_0002._0003 == 0)
		{
			return global::_0006_2005._0006;
		}
		if (_0003 == 0)
		{
			return global::_0006_2005._0008;
		}
		global::_0006_2005 obj = default(global::_0006_2005);
		if (0 == 0)
		{
			obj = this;
		}
		if (!_0002.Equals(global::_0006_2005._0006))
		{
			global::_0006_2005 obj2 = global::_0006_2005._0002(obj, _0002._0005[0], _0008);
			if (7u != 0)
			{
				obj = obj2;
			}
		}
		return obj;
	}

	private static global::_0006_2005 _0002(global::_0006_2005 _0002, int _0008, global::_0006_2005 _0006)
	{
		int num = _0006._0005.Length;
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		int num3 = 32 * num2;
		int num4;
		if (5u != 0)
		{
			num4 = num3;
		}
		bool num5 = _0006._0002() + 2 <= num4;
		bool flag;
		if (4u != 0)
		{
			flag = num5;
		}
		int num6 = _0006._0008();
		uint num7;
		if (3u != 0)
		{
			num7 = (uint)num6;
		}
		_0002 = _0002._0002(num4)._0002(_0006);
		int[] array = new int[num2 + 1];
		int[] array2 = _0002._0005;
		if (array2.Length < num2)
		{
			int[] array3 = new int[num2];
			Buffer.BlockCopy(array2, 0, array3, num2 - array2.Length, array2.Length * 4);
			array2 = array3;
		}
		int[] array4 = global::_0006_2005._0002(array2);
		global::_0006_2005._0002(array, array4, _0006._0005, num7, flag);
		int[] array5 = global::_0006_2005._0002(_0008);
		int num8 = array5[0];
		int num9 = num8 >> 8;
		num9--;
		int num10 = 1;
		while ((num8 = array5[num10++]) != -1)
		{
			int num11 = num9 + 1;
			for (int i = 0; i < num11; i++)
			{
				global::_0006_2005._0002(array, array4, _0006._0005, num7, flag);
			}
			global::_0006_2005._0002(array, array4, array2, _0006._0005, num7, flag);
			num9 = num8 >> 8;
		}
		for (int j = 0; j < num9; j++)
		{
			global::_0006_2005._0002(array, array4, _0006._0005, num7, flag);
		}
		global::_0006_2005._0002(array4, _0006._0005, num7);
		return new global::_0006_2005(1, array4, _0006: true);
	}

	private static int _0006(int _0002)
	{
		int num = _0002 + (((_0002 + 1) & 4) << 1);
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		int num3 = num2 * (2 - _0002 * num2);
		if (0 == 0)
		{
			num2 = num3;
		}
		int num4 = num2 * (2 - _0002 * num2);
		if (uint.MaxValue != 0)
		{
			num2 = num4;
		}
		return num2 * (2 - _0002 * num2);
	}

	private int _0008()
	{
		if (_0002_2004 != 0)
		{
			return _0002_2004;
		}
		int num = -_0005[_0005.Length - 1];
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		int num3 = _0006(num2);
		int result;
		if (7u != 0)
		{
			result = num3;
		}
		if (uint.MaxValue != 0)
		{
			_0002_2004 = num3;
		}
		return result;
	}

	private static void _0002(int[] _0002, int[] _0008, uint _0006)
	{
		int num = _0008.Length;
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		int num3 = num2 - 1;
		int num4;
		if (4u != 0)
		{
			num4 = num3;
		}
		while (num4 >= 0)
		{
			int num5 = _0002[num2 - 1];
			uint num6;
			if (true)
			{
				num6 = (uint)num5;
			}
			ulong num7 = num6 * _0006;
			ulong num8 = num7 * (uint)_0008[num2 - 1] + num6;
			num8 >>= 32;
			for (int num9 = num2 - 2; num9 >= 0; num9--)
			{
				num8 += num7 * (uint)_0008[num9] + (uint)_0002[num9];
				_0002[num9 + 1] = (int)num8;
				num8 >>= 32;
			}
			_0002[0] = (int)num8;
			num4--;
		}
		if (global::_0006_2005._0002(0, _0002, 0, _0008) >= 0)
		{
			global::_0006_2005._0002(0, _0002, 0, _0008);
		}
	}

	private static void _0002(int[] _0002, int[] _0008, int[] _0006, int[] _000F, uint _0005, bool _0003)
	{
		int num = _000F.Length;
		int num2;
		if (true)
		{
			num2 = num;
		}
		if (num2 == 1)
		{
			_0008[0] = (int)global::_0006_2005._0002((uint)_0008[0], (uint)_0006[0], (uint)_000F[0], _0005);
			return;
		}
		int num3 = _0006[num2 - 1];
		uint num4;
		if (6u != 0)
		{
			num4 = (uint)num3;
		}
		long num5 = (uint)_0008[num2 - 1];
		ulong num6;
		if (2u != 0)
		{
			num6 = (ulong)num5;
		}
		ulong num7 = num6 * num4;
		ulong num8;
		if (7u != 0)
		{
			num8 = num7;
		}
		long num9 = (uint)((int)num8 * (int)_0005);
		ulong num10;
		if (7u != 0)
		{
			num10 = (ulong)num9;
		}
		ulong num11 = num10 * (uint)_000F[num2 - 1];
		ulong num12;
		if (5u != 0)
		{
			num12 = num11;
		}
		ulong num13 = num8 + (uint)num12;
		if (uint.MaxValue != 0)
		{
			num8 = num13;
		}
		ulong num14 = (num8 >> 32) + (num12 >> 32);
		if (2u != 0)
		{
			num8 = num14;
		}
		int num15 = num2 - 2;
		int num16;
		if (6u != 0)
		{
			num16 = num15;
		}
		while (num16 >= 0)
		{
			ulong num17 = num6 * (uint)_0006[num16];
			num12 = num10 * (uint)_000F[num16];
			num8 += (num17 & 0xFFFFFFFFu) + (uint)num12;
			_0002[num16 + 2] = (int)num8;
			num8 = (num8 >> 32) + (num17 >> 32) + (num12 >> 32);
			num16--;
		}
		_0002[1] = (int)num8;
		int num18 = (int)(num8 >> 32);
		for (int num19 = num2 - 2; num19 >= 0; num19--)
		{
			uint num20 = (uint)_0002[num2];
			ulong num21 = (uint)_0008[num19];
			ulong num22 = num21 * num4;
			ulong num23 = (num22 & 0xFFFFFFFFu) + num20;
			ulong num24 = (uint)(int)num23 * _0005;
			ulong num25 = num24 * (uint)_000F[num2 - 1];
			num23 += (uint)num25;
			num23 = (num23 >> 32) + (num22 >> 32) + (num25 >> 32);
			for (int num26 = num2 - 2; num26 >= 0; num26--)
			{
				num22 = num21 * (uint)_0006[num26];
				num25 = num24 * (uint)_000F[num26];
				num23 += (num22 & 0xFFFFFFFFu) + (uint)num25 + (uint)_0002[num26 + 1];
				_0002[num26 + 2] = (int)num23;
				num23 = (num23 >> 32) + (num22 >> 32) + (num25 >> 32);
			}
			num23 += (uint)num18;
			_0002[1] = (int)num23;
			num18 = (int)(num23 >> 32);
		}
		_0002[0] = num18;
		if (!_0003 && global::_0006_2005._0002(0, _0002, 0, _000F) >= 0)
		{
			global::_0006_2005._0002(0, _0002, 0, _000F);
		}
		Array.Copy(_0002, 1, _0008, 0, num2);
	}

	private static void _0002(int[] _0002, int[] _0008, int[] _0006, uint _000F, bool _0005)
	{
		int num = _0006.Length;
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		if (num2 == 1)
		{
			int num3 = _0008[0];
			uint num4;
			if (5u != 0)
			{
				num4 = (uint)num3;
			}
			_0008[0] = (int)global::_0006_2005._0002(num4, num4, (uint)_0006[0], _000F);
			return;
		}
		long num5 = (uint)_0008[num2 - 1];
		ulong num6;
		if (6u != 0)
		{
			num6 = (ulong)num5;
		}
		ulong num7 = num6 * num6;
		ulong num8;
		if (4u != 0)
		{
			num8 = num7;
		}
		long num9 = (uint)((int)num8 * (int)_000F);
		ulong num10;
		if (3u != 0)
		{
			num10 = (ulong)num9;
		}
		ulong num11 = num10 * (uint)_0006[num2 - 1];
		ulong num12;
		if (uint.MaxValue != 0)
		{
			num12 = num11;
		}
		ulong num13 = num8 + (uint)num12;
		if (uint.MaxValue != 0)
		{
			num8 = num13;
		}
		ulong num14 = (num8 >> 32) + (num12 >> 32);
		if (0 == 0)
		{
			num8 = num14;
		}
		int num15 = num2 - 2;
		int num16;
		if (7u != 0)
		{
			num16 = num15;
		}
		while (num16 >= 0)
		{
			ulong num17 = num6 * (uint)_0008[num16];
			ulong num18;
			if (uint.MaxValue != 0)
			{
				num18 = num17;
			}
			num12 = num10 * (uint)_0006[num16];
			num8 += (num12 & 0xFFFFFFFFu) + (uint)((int)num18 << 1);
			_0002[num16 + 2] = (int)num8;
			num8 = (num8 >> 32) + (num18 >> 31) + (num12 >> 32);
			num16--;
		}
		_0002[1] = (int)num8;
		int num19 = (int)(num8 >> 32);
		for (int num20 = num2 - 2; num20 >= 0; num20--)
		{
			uint num21 = (uint)_0002[num2];
			ulong num22 = num21 * _000F;
			ulong num23 = num22 * (uint)_0006[num2 - 1] + num21;
			num23 >>= 32;
			for (int num24 = num2 - 2; num24 > num20; num24--)
			{
				num23 += num22 * (uint)_0006[num24] + (uint)_0002[num24 + 1];
				_0002[num24 + 2] = (int)num23;
				num23 >>= 32;
			}
			ulong num25 = (uint)_0008[num20];
			ulong num26 = num25 * num25;
			ulong num27 = num22 * (uint)_0006[num20];
			num23 += (num26 & 0xFFFFFFFFu) + (uint)num27 + (uint)_0002[num20 + 1];
			_0002[num20 + 2] = (int)num23;
			num23 = (num23 >> 32) + (num26 >> 32) + (num27 >> 32);
			for (int num28 = num20 - 1; num28 >= 0; num28--)
			{
				ulong num29 = num25 * (uint)_0008[num28];
				ulong num30 = num22 * (uint)_0006[num28];
				num23 += (num30 & 0xFFFFFFFFu) + (uint)((int)num29 << 1) + (uint)_0002[num28 + 1];
				_0002[num28 + 2] = (int)num23;
				num23 = (num23 >> 32) + (num29 >> 31) + (num30 >> 32);
			}
			num23 += (uint)num19;
			_0002[1] = (int)num23;
			num19 = (int)(num23 >> 32);
		}
		_0002[0] = num19;
		if (!_0005 && global::_0006_2005._0002(0, _0002, 0, _0006) >= 0)
		{
			global::_0006_2005._0002(0, _0002, 0, _0006);
		}
		Array.Copy(_0002, 1, _0008, 0, num2);
	}

	private static uint _0002(uint _0002, uint _0008, uint _0006, uint _000F)
	{
		long num = (long)_0002 * (long)_0008;
		ulong num2;
		if (uint.MaxValue != 0)
		{
			num2 = (ulong)num;
		}
		int num3 = (int)num2 * (int)_000F;
		uint num4;
		if (3u != 0)
		{
			num4 = (uint)num3;
		}
		long num5 = _0006;
		ulong num6;
		if (6u != 0)
		{
			num6 = (ulong)num5;
		}
		ulong num7 = num6 * num4;
		num2 += (uint)num7;
		num2 = (num2 >> 32) + (num7 >> 32);
		if (num2 > num6)
		{
			num2 -= num6;
		}
		return (uint)num2;
	}

	private static int[] _0002(int _0002)
	{
		int num = _0008(_0002);
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		int[] array = new int[num2 + 2];
		int[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		int num3;
		if (6u != 0)
		{
			num3 = 0;
		}
		int i = 33 - num2;
		_0002 <<= i;
		int num4 = 0;
		for (; i < 32; i++)
		{
			if (_0002 < 0)
			{
				array2[num3++] = 1 | (num4 << 8);
				num4 = 0;
			}
			else
			{
				num4++;
			}
			_0002 <<= 1;
		}
		array2[num3++] = 1 | (num4 << 8);
		array2[num3] = -1;
		return array2;
	}

	private static int[] _0002(int[] _0002, int _0008)
	{
		int num = _0008 >>> 5;
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		int num3 = _0008 & 0x1F;
		int num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		int num5 = _0002.Length;
		int num6;
		if (6u != 0)
		{
			num6 = num5;
		}
		int[] array;
		if (num4 == 0)
		{
			array = new int[num6 + num2];
			_0002.CopyTo(array, 0);
		}
		else
		{
			int num7 = 0;
			int num8 = 32 - num4;
			int num9 = _0002[0] >>> num8;
			if (num9 != 0)
			{
				array = new int[num6 + num2 + 1];
				array[num7++] = num9;
			}
			else
			{
				array = new int[num6 + num2];
			}
			int num10 = _0002[0];
			for (int i = 0; i < num6 - 1; i++)
			{
				int num11 = _0002[i + 1];
				array[num7++] = (num10 << num4) | (num11 >>> num8);
				num10 = num11;
			}
			array[num7] = _0002[num6 - 1] << num4;
		}
		return array;
	}

	private global::_0006_2005 _0002(int _0002)
	{
		if (_0003 == 0 || _0005.Length == 0)
		{
			return global::_0006_2005._0008;
		}
		if (_0002 == 0)
		{
			return this;
		}
		global::_0006_2005 obj = new global::_0006_2005(_0003, global::_0006_2005._0002(_0005, _0002), _0006: true);
		global::_0006_2005 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		if (_000E != -1)
		{
			int num = _000E + _0002;
			if (0 == 0)
			{
				obj2._000E = num;
			}
		}
		return obj2;
	}

	private static void _0002(int _0002, int[] _0008, int _0006)
	{
		int num = (_0006 >>> 5) + _0002;
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		int num3 = _0006 & 0x1F;
		int num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		int num5 = _0008.Length - 1;
		int num6;
		if (3u != 0)
		{
			num6 = num5;
		}
		if (num2 != _0002)
		{
			int num7 = num2 - _0002;
			for (int num8 = num6; num8 >= num2; num8--)
			{
				_0008[num8] = _0008[num8 - num7];
			}
			for (int num9 = num2 - 1; num9 >= _0002; num9--)
			{
				_0008[num9] = 0;
			}
		}
		if (num4 != 0)
		{
			int num10 = 32 - num4;
			int num11 = _0008[num6];
			for (int num12 = num6; num12 > num2; num12--)
			{
				int num13 = _0008[num12 - 1];
				_0008[num12] = (num11 >>> num4) | (num13 << num10);
				num11 = num13;
			}
			_0008[num2] >>>= num4;
		}
	}

	private static void _0002(int _0002, int[] _0008)
	{
		int num = _0008.Length;
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		int num3 = _0008[num2 - 1];
		int num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		while (--num2 > _0002)
		{
			int num5 = _0008[num2 - 1];
			int num6;
			if (uint.MaxValue != 0)
			{
				num6 = num5;
			}
			_0008[num2] = (num4 >>> 1) | (num6 << 31);
			num4 = num6;
		}
		_0008[_0002] >>>= 1;
	}

	public int _0006()
	{
		_ = -1;
		if (6 == 0)
		{
		}
		return _0003;
	}

	private static int[] _0002(int _0002, int[] _0008, int _0006, int[] _000F)
	{
		int num = _0008.Length;
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		int num3 = _000F.Length;
		int num4;
		if (true)
		{
			num4 = num3;
		}
		int num5;
		if (true)
		{
			num5 = 0;
		}
		do
		{
			long num6 = (_0008[--num2] & 0xFFFFFFFFu) - (_000F[--num4] & 0xFFFFFFFFu) + num5;
			_0008[num2] = (int)num6;
			num5 = (int)(num6 >> 63);
		}
		while (num4 > _0006);
		if (num5 != 0)
		{
			while (--_0008[--num2] == -1)
			{
			}
		}
		return _0008;
	}

	public byte[] _0002()
	{
		if (_0003 == 0)
		{
			return new byte[0];
		}
		byte[] array = new byte[_0002(this._0002())];
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		_0002(array2, 0);
		return array2;
	}

	public int _000F()
	{
		_ = 8;
		if (1 == 0)
		{
		}
		return _0002((byte[])null, 0);
	}

	public int _0002(byte[] _0002, int _0008)
	{
		if (_0003 == 0)
		{
			return 0;
		}
		int num = global::_0006_2005._0002(this._0002());
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		if (_0002 == null)
		{
			return num2;
		}
		int num3 = _0005.Length;
		int num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		int num5 = _0008 + num2;
		int num6;
		if (8u != 0)
		{
			num6 = num5;
		}
		if (num6 > _0002.Length)
		{
			throw new IndexOutOfRangeException();
		}
		while (num4 > 1)
		{
			uint num7 = (uint)_0005[--num4];
			_0002[--num6] = (byte)num7;
			_0002[--num6] = (byte)(num7 >> 8);
			_0002[--num6] = (byte)(num7 >> 16);
			_0002[--num6] = (byte)(num7 >> 24);
		}
		uint num8;
		for (num8 = (uint)_0005[0]; num8 > 255; num8 >>= 8)
		{
			_0002[--num6] = (byte)num8;
		}
		_0002[--num6] = (byte)num8;
		return num2;
	}

	private static global::_0006_2005 _0002(ulong _0002)
	{
		int num = (int)(_0002 >> 32);
		int num2;
		if (true)
		{
			num2 = num;
		}
		int num3 = (int)_0002;
		int num4;
		if (8u != 0)
		{
			num4 = num3;
		}
		if (num2 != 0)
		{
			return new global::_0006_2005(1, new int[2] { num2, num4 }, _0006: false);
		}
		if (num4 != 0)
		{
			return new global::_0006_2005(1, new int[1] { num4 }, _0006: false);
		}
		return global::_0006_2005._0008;
	}

	public static global::_0006_2005 _0008(ulong _0002)
	{
		_ = 5;
		if (2 == 0)
		{
		}
		return global::_0006_2005._0002(_0002);
	}

	private static int[] _0002(int[] _0002, int[] _0008)
	{
		int num;
		if (3u != 0)
		{
			num = 0;
		}
		while (num < _0002.Length && _0002[num] == 0)
		{
			int num2 = num + 1;
			if (8u != 0)
			{
				num = num2;
			}
		}
		int num3;
		if (3u != 0)
		{
			num3 = 0;
		}
		while (num3 < _0008.Length && _0008[num3] == 0)
		{
			int num4 = num3 + 1;
			if (8u != 0)
			{
				num3 = num4;
			}
		}
		int num5 = global::_0006_2005._0008(num, _0002, num3, _0008);
		int num6;
		if (2u != 0)
		{
			num6 = num5;
		}
		if (num6 > 0)
		{
			int num7 = global::_0006_2005._0002(1, num3, _0008);
			int num8;
			if (4u != 0)
			{
				num8 = num7;
			}
			int num9 = global::_0006_2005._0002(1, num, _0002);
			int num10 = num9 - num8;
			int i = 0;
			int num11 = num8;
			int[] array;
			if (num10 > 0)
			{
				array = global::_0006_2005._0002(_0008, num10);
				num11 += num10;
			}
			else
			{
				int num12 = _0008.Length - num3;
				array = new int[num12];
				Array.Copy(_0008, num3, array, 0, num12);
			}
			while (true)
			{
				if (num11 < num9 || global::_0006_2005._0008(num, _0002, i, array) >= 0)
				{
					global::_0006_2005._0002(num, _0002, i, array);
					while (_0002[num] == 0)
					{
						if (++num == _0002.Length)
						{
							return _0002;
						}
					}
					num9 = 32 * (_0002.Length - num - 1) + global::_0006_2005._0008(_0002[num]);
					if (num9 <= num8)
					{
						if (num9 < num8)
						{
							return _0002;
						}
						num6 = global::_0006_2005._0008(num, _0002, num3, _0008);
						if (num6 <= 0)
						{
							break;
						}
					}
				}
				num10 = num11 - num9;
				if (num10 == 1)
				{
					int num13 = array[i] >>> 1;
					uint num14 = (uint)_0002[num];
					if ((uint)num13 > num14)
					{
						num10++;
					}
				}
				if (num10 < 2)
				{
					global::_0006_2005._0002(i, array);
					num11--;
				}
				else
				{
					global::_0006_2005._0002(i, array, num10);
					num11 -= num10;
				}
				for (; array[i] == 0; i++)
				{
				}
			}
		}
		if (num6 == 0)
		{
			Array.Clear(_0002, num, _0002.Length - num);
		}
		return _0002;
	}

	private global::_0006_2005 _0002(global::_0006_2005 _0002)
	{
		if (_0003 == 0)
		{
			return global::_0006_2005._0008;
		}
		if (_0008(0, _0005, 0, _0002._0005) < 0)
		{
			return this;
		}
		int[] obj = (int[])_0005.Clone();
		int[] array;
		if (8u != 0)
		{
			array = obj;
		}
		int[] array2 = global::_0006_2005._0002(array, _0002._0005);
		if (2u != 0)
		{
			array = array2;
		}
		return new global::_0006_2005(_0003, array, _0006: true);
	}

	private static int[] _0002(int[] _0002)
	{
		int[] array = new int[_0002.Length];
		int[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		int count = _0002.Length * 4;
		if (4u != 0)
		{
			Buffer.BlockCopy(_0002, 0, array2, 0, count);
		}
		return array2;
	}
}
[global::_0006_2006]
internal sealed class _0006_2006 : Attribute
{
	public _0006_2006()
	{
		_ = 5;
		if (1 == 0)
		{
		}
		base._002Ector();
	}
}
internal sealed class _0006_2007
{
	public _0006_2007()
	{
		_ = 7;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	[Conditional("DEBUG")]
	public static void _0002(string _0002)
	{
	}
}
[global::_0006_2007_2005]
internal sealed class _0006_2007_2005 : Attribute
{
	public _0006_2007_2005()
	{
		_ = 0;
		if (-1 == 0)
		{
		}
		base._002Ector();
	}
}
internal sealed class _0006_2008 : global::_0005_2004
{
	private string m__0002;

	public _0006_2008()
	{
		_ = 2;
		if (3 == 0)
		{
		}
		base._002Ector();
	}

	public string _0002()
	{
		_ = -1;
		if (7 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(string _0002)
	{
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override byte _0005_2004_2008_2009_0002()
	{
		return 4;
	}
}
internal sealed class _0006_2009
{
	private struct _0002 : IEquatable<_0002>
	{
		private readonly MethodBase m__0002;

		private readonly bool _0008;

		public _0002(MethodBase _0002, bool _0008)
		{
			if (uint.MaxValue != 0)
			{
				this.m__0002 = _0002;
			}
			if (2u != 0)
			{
				this._0008 = _0008;
			}
		}

		[global::_0008_2000]
		public MethodBase _0002()
		{
			_ = 2;
			if (4 == 0)
			{
			}
			return this.m__0002;
		}

		[global::_0008_2000]
		public bool _0002()
		{
			_ = 8;
			if (8 == 0)
			{
			}
			return _0008;
		}

		public override int GetHashCode()
		{
			int hashCode = this._0002().GetHashCode();
			bool num = this._0002();
			bool flag;
			if (uint.MaxValue != 0)
			{
				flag = num;
			}
			return hashCode ^ flag.GetHashCode();
		}

		public override bool Equals(object _0002)
		{
			if (_0002 is object obj)
			{
				_0002 obj2;
				if (4u != 0)
				{
					obj2 = (_0002)obj;
				}
				return Equals(obj2);
			}
			return false;
		}

		public bool Equals(_0002 _0002)
		{
			_ = 0;
			if (false)
			{
			}
			if (this._0002() == _0002._0002())
			{
				_ = 4;
				if (1 == 0)
				{
				}
				return this._0002() == _0002._0002();
			}
			return false;
		}
	}

	private static class _0002_2004
	{
		private static readonly Dictionary<MethodBase, MethodInfo> m__0002;

		static _0002_2004()
		{
			Dictionary<MethodBase, MethodInfo> dictionary = new Dictionary<MethodBase, MethodInfo>();
			if (8u != 0)
			{
				global::_0006_2009._0002_2004.m__0002 = dictionary;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase _0002(global::_0006_2009 _0002, global::_0003_2004_2005 _0008, MethodBase _0006, bool _000F)
		{
			Dictionary<MethodBase, MethodInfo> dictionary = global::_0006_2009._0002_2004.m__0002;
			Dictionary<MethodBase, MethodInfo> dictionary2 = default(Dictionary<MethodBase, MethodInfo>);
			if (0 == 0)
			{
				dictionary2 = dictionary;
			}
			bool lockTaken;
			if (4u != 0)
			{
				lockTaken = false;
			}
			try
			{
				Dictionary<MethodBase, MethodInfo> obj = dictionary2;
				if (0 == 0)
				{
					Monitor.Enter(obj, ref lockTaken);
				}
				if (!global::_0006_2009._0002_2004.m__0002.TryGetValue(_0006, out var value))
				{
					MethodInfo obj2 = _0006 as MethodInfo;
					MethodInfo methodInfo = default(MethodInfo);
					if (0 == 0)
					{
						methodInfo = obj2;
					}
					Type returnType = (((object)methodInfo == null) ? global::_0006_2009.m__0003_2009 : methodInfo.ReturnType);
					ParameterInfo[] parameters = _0006.GetParameters();
					Type[] array;
					if (_0006.IsStatic)
					{
						array = new Type[parameters.Length];
						for (int i = 0; i < parameters.Length; i++)
						{
							array[i] = parameters[i].ParameterType;
						}
					}
					else
					{
						array = new Type[parameters.Length + 1];
						Type type = _0006.DeclaringType;
						if (type.IsValueType)
						{
							type = type.MakeByRefType();
							_000F = false;
						}
						array[0] = type;
						for (int j = 0; j < parameters.Length; j++)
						{
							array[j + 1] = parameters[j].ParameterType;
						}
					}
					string empty = string.Empty;
					if (value == null)
					{
						value = new DynamicMethod(empty, returnType, array, _0002._0002(_0008._0002(), _0008: true), skipVisibility: true);
					}
					ILGenerator iLGenerator = ((DynamicMethod)value).GetILGenerator();
					for (int k = 0; k < array.Length; k++)
					{
						iLGenerator.Emit(OpCodes.Ldarg, k);
					}
					if (_0006 is ConstructorInfo con)
					{
						iLGenerator.Emit(_000F ? OpCodes.Callvirt : OpCodes.Call, con);
					}
					else
					{
						iLGenerator.Emit(_000F ? OpCodes.Callvirt : OpCodes.Call, (MethodInfo)_0006);
					}
					iLGenerator.Emit(OpCodes.Ret);
					global::_0006_2009._0002_2004.m__0002.Add(_0006, value);
					return value;
				}
				MethodInfo result = value;
				if (8u != 0)
				{
					return result;
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(dictionary2);
				}
			}
			MethodBase result2;
			return result2;
		}
	}

	private static class _0002_2007
	{
		private delegate _0006_2004 _0002<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, in _000E, in _0002_2004, in _0008_2004, out _0006_2004>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003, _000E _000E, _0002_2004 _0002_2004, _0008_2004 _0008_2004);

		private delegate _000E _0002_2004<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, out _000E>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003);

		private delegate _000F _0002_2007<in _0002, in _0008, in _0006, out _000F>(_0002 _0002, _0008 _0008, _0006 _0006);

		private delegate void _0003<in _0002, in _0008, in _0006>(_0002 _0002, _0008 _0008, _0006 _0006);

		private delegate _0008_2004 _0003_2004<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, in _000E, in _0002_2004, out _0008_2004>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003, _000E _000E, _0002_2004 _0002_2004);

		private delegate void _0003_2007<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, in _000E, in _0002_2004, in _0008_2004>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003, _000E _000E, _0002_2004 _0002_2004, _0008_2004 _0008_2004);

		private delegate void _0005();

		private delegate void _0005_2004<in _0002>(_0002 _0002);

		private delegate void _0005_2007<in _0002, in _0008>(_0002 _0002, _0008 _0008);

		private delegate void _0006<in _0002, in _0008, in _0006, in _000F, in _0005>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005);

		private delegate _0002 _0006_2004<out _0002>();

		private delegate void _0006_2007<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, in _000E, in _0002_2004>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003, _000E _000E, _0002_2004 _0002_2004);

		private delegate void _0008<in _0002, in _0008, in _0006, in _000F>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F);

		private delegate _0008 _0008_2004<in _0002, out _0008>(_0002 _0002);

		private delegate _0003 _0008_2007<in _0002, in _0008, in _0006, in _000F, in _0005, out _0003>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005);

		private delegate _0005 _000E<in _0002, in _0008, in _0006, in _000F, out _0005>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F);

		private delegate _0006 _000E_2004<in _0002, in _0008, out _0006>(_0002 _0002, _0008 _0008);

		private delegate void _000F<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003);

		private delegate void _000F_2004<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, in _000E>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003, _000E _000E);

		private delegate _0002_2004 _000F_2007<in _0002, in _0008, in _0006, in _000F, in _0005, in _0003, in _000E, out _0002_2004>(_0002 _0002, _0008 _0008, _0006 _0006, _000F _000F, _0005 _0005, _0003 _0003, _000E _000E);

		private static readonly Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> m__0002;

		static _0002_2007()
		{
			Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> dictionary = new Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>>();
			if (5u != 0)
			{
				global::_0006_2009._0002_2007.m__0002 = dictionary;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public static object _0002(object _0002, MethodBase _0008, out MethodInfo _0006)
		{
			KeyValuePair<Type, MethodInfo> keyValuePair = global::_0006_2009._0002_2007._0002(_0008);
			KeyValuePair<Type, MethodInfo> keyValuePair2;
			if (5u != 0)
			{
				keyValuePair2 = keyValuePair;
			}
			Type key = keyValuePair2.Key;
			object[] obj = new object[2] { _0002, null };
			RuntimeMethodHandle methodHandle = _0008.MethodHandle;
			RuntimeMethodHandle runtimeMethodHandle;
			if (5u != 0)
			{
				runtimeMethodHandle = methodHandle;
			}
			obj[1] = runtimeMethodHandle.GetFunctionPointer();
			Delegate result = (Delegate)Activator.CreateInstance(key, obj);
			_0006 = keyValuePair2.Value;
			return result;
		}

		private static KeyValuePair<Type, MethodInfo> _0002(MethodBase _0002)
		{
			Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> dictionary = global::_0006_2009._0002_2007.m__0002;
			Dictionary<MethodBase, KeyValuePair<Type, MethodInfo>> obj;
			if (8u != 0)
			{
				obj = dictionary;
			}
			bool lockTaken;
			if (uint.MaxValue != 0)
			{
				lockTaken = false;
			}
			try
			{
				if (0 == 0)
				{
					Monitor.Enter(obj, ref lockTaken);
				}
				if (!global::_0006_2009._0002_2007.m__0002.TryGetValue(_0002, out var value))
				{
					Type type = (_0002 as MethodInfo)?.ReturnType ?? global::_0006_2009.m__0003_2009;
					bool flag = type != global::_0006_2009.m__0003_2009;
					ParameterInfo[] parameters = _0002.GetParameters();
					if (parameters.Length > 9)
					{
						throw new Exception(string.Format(global::_0008_0010._0002(-1463125306), parameters.Length));
					}
					Type[] array = new Type[parameters.Length + (flag ? 1 : 0)];
					for (int i = 0; i < parameters.Length; i++)
					{
						Type parameterType = parameters[i].ParameterType;
						if (parameterType.IsByRef || parameterType.IsPointer)
						{
							throw new Exception(global::_0008_0010._0002(-1463125320));
						}
						array[i] = parameterType;
					}
					if (flag)
					{
						array[array.Length - 1] = type;
					}
					Type type2 = (flag ? global::_0006_2009._0002_2007._0002(array) : _0008(array));
					MethodInfo method = type2.GetMethod(global::_0008_0010._0002(-1463125143));
					value = new KeyValuePair<Type, MethodInfo>(type2, method);
					global::_0006_2009._0002_2007.m__0002.Add(_0002, value);
					return value;
				}
				KeyValuePair<Type, MethodInfo> result = value;
				if (7u != 0)
				{
					return result;
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
			KeyValuePair<Type, MethodInfo> result2;
			return result2;
		}

		private static Type _0002(Type[] _0002)
		{
			int num = _0002.Length;
			int num2;
			if (2u != 0)
			{
				num2 = num;
			}
			return num2 switch
			{
				1 => typeof(_0006_2004<>).MakeGenericType(_0002), 
				2 => typeof(_0008_2004<, >).MakeGenericType(_0002), 
				3 => typeof(_000E_2004<, , >).MakeGenericType(_0002), 
				4 => typeof(_0002_2007<, , , >).MakeGenericType(_0002), 
				5 => typeof(_000E<, , , , >).MakeGenericType(_0002), 
				6 => typeof(_0008_2007<, , , , , >).MakeGenericType(_0002), 
				7 => typeof(_0002_2004<, , , , , , >).MakeGenericType(_0002), 
				8 => typeof(_000F_2007<, , , , , , , >).MakeGenericType(_0002), 
				9 => typeof(_0003_2004<, , , , , , , , >).MakeGenericType(_0002), 
				10 => typeof(_0002<, , , , , , , , , >).MakeGenericType(_0002), 
				_ => null, 
			};
		}

		private static Type _0008(Type[] _0002)
		{
			int num = _0002.Length;
			int num2;
			if (7u != 0)
			{
				num2 = num;
			}
			return num2 switch
			{
				0 => typeof(_0005), 
				1 => typeof(_0005_2004<>).MakeGenericType(_0002), 
				2 => typeof(_0005_2007<, >).MakeGenericType(_0002), 
				3 => typeof(_0003<, , >).MakeGenericType(_0002), 
				4 => typeof(_0008<, , , >).MakeGenericType(_0002), 
				5 => typeof(_0006<, , , , >).MakeGenericType(_0002), 
				6 => typeof(_000F<, , , , , >).MakeGenericType(_0002), 
				7 => typeof(_000F_2004<, , , , , , >).MakeGenericType(_0002), 
				8 => typeof(_0006_2007<, , , , , , , >).MakeGenericType(_0002), 
				9 => typeof(_0003_2007<, , , , , , , , >).MakeGenericType(_0002), 
				_ => null, 
			};
		}
	}

	private static class _0003
	{
		public static readonly bool _0002;

		static _0003()
		{
			try
			{
				bool num = _0002();
				if (0 == 0)
				{
					global::_0006_2009._0003._0002 = num;
				}
			}
			catch
			{
				if (3u != 0)
				{
					global::_0006_2009._0003._0002 = false;
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool _0002()
		{
			if (typeof(DynamicMethod).IsAbstract)
			{
				return false;
			}
			try
			{
				new DynamicMethod(string.Empty, typeof(void), Type.EmptyTypes);
			}
			catch (PlatformNotSupportedException)
			{
				if (8u != 0)
				{
					return false;
				}
				bool result;
				return result;
			}
			return true;
		}
	}

	private struct _0003_2004
	{
		public readonly byte _0002;

		public readonly _0008_2004 _0008;

		public _0003_2004(global::_000F_2000 _0002, _0008_2004 _0008)
		{
			byte num = _0002._0002();
			if (2u != 0)
			{
				this._0002 = num;
			}
			if (3u != 0)
			{
				this._0008 = _0008;
			}
		}
	}

	private static class _0005
	{
		public static _0008_2004 _0002;

		public static _0008_2004 _0008;

		public static _0008_2004 _0006;

		public static _0008_2004 _000F;

		public static _0008_2004 _0005;

		public static _0008_2004 _0003;

		public static _0008_2004 _000E;

		public static _0008_2004 _0002_2004;

		public static _0008_2004 _0008_2004;

		public static _0008_2004 _0006_2004;

		public static _0008_2004 _000F_2004;

		public static _0008_2004 _0005_2004;

		public static _0008_2004 _0003_2004;

		public static _0008_2004 _000E_2004;

		public static _0008_2004 _0002_2007;

		public static _0008_2004 _0008_2007;

		public static _0008_2004 _0006_2007;

		public static _0008_2004 _000F_2007;

		public static _0008_2004 _0005_2007;

		public static _0008_2004 _0003_2007;

		public static _0008_2004 _000E_2007;

		public static _0008_2004 _0002_2003;

		public static _0008_2004 _0008_2003;

		public static _0008_2004 _0006_2003;

		public static _0008_2004 _000F_2003;

		public static _0008_2004 _0005_2003;

		public static _0008_2004 _0003_2003;

		public static _0008_2004 _000E_2003;

		public static _0008_2004 _0002_2009;

		public static _0008_2004 _0008_2009;

		public static _0008_2004 _0006_2009;

		public static _0008_2004 _000F_2009;

		public static _0008_2004 _0005_2009;

		public static _0008_2004 _0003_2009;

		public static _0008_2004 _000E_2009;

		public static _0008_2004 _0002_2001;

		public static _0008_2004 _0008_2001;

		public static _0008_2004 _0006_2001;

		public static _0008_2004 _000F_2001;

		public static _0008_2004 _0005_2001;

		public static _0008_2004 _0003_2001;

		public static _0008_2004 _000E_2001;

		public static _0008_2004 _0002_2002;

		public static _0008_2004 _0008_2002;

		public static _0008_2004 _0006_2002;

		public static _0008_2004 _000F_2002;

		public static _0008_2004 _0005_2002;

		public static _0008_2004 _0003_2002;

		public static _0008_2004 _000E_2002;

		public static _0008_2004 _0002_2008;

		public static _0008_2004 _0008_2008;

		public static _0008_2004 _0006_2008;

		public static _0008_2004 _000F_2008;

		public static _0008_2004 _0005_2008;

		public static _0008_2004 _0003_2008;

		public static _0008_2004 _000E_2008;

		public static _0008_2004 _0002_200B;

		public static _0008_2004 _0008_200B;

		public static _0008_2004 _0006_200B;

		public static _0008_2004 _000F_200B;

		public static _0008_2004 _0005_200B;

		public static _0008_2004 _0003_200B;

		public static _0008_2004 _000E_200B;

		public static _0008_2004 _0002_2006;

		public static _0008_2004 _0008_2006;

		public static _0008_2004 _0006_2006;

		public static _0008_2004 _000F_2006;

		public static _0008_2004 _0005_2006;

		public static _0008_2004 _0003_2006;

		public static _0008_2004 _000E_2006;

		public static _0008_2004 _0002_2005;

		public static _0008_2004 _0008_2005;

		public static _0008_2004 _0006_2005;

		public static _0008_2004 _000F_2005;

		public static _0008_2004 _0005_2005;

		public static _0008_2004 _0003_2005;

		public static _0008_2004 _000E_2005;

		public static _0008_2004 _0002_2000;

		public static _0008_2004 _0008_2000;

		public static _0008_2004 _0006_2000;

		public static _0008_2004 _000F_2000;

		public static _0008_2004 _0005_2000;

		public static _0008_2004 _0003_2000;

		public static _0008_2004 _000E_2000;

		public static _0008_2004 _0002_200A;

		public static _0008_2004 _0008_200A;

		public static _0008_2004 _0006_200A;

		public static _0008_2004 _000F_200A;

		public static _0008_2004 _0005_200A;

		public static _0008_2004 _0003_200A;

		public static _0008_2004 _000E_200A;

		public static _0008_2004 _0002_2004_2005;

		public static _0008_2004 _0008_2004_2005;

		public static _0008_2004 _0006_2004_2005;

		public static _0008_2004 _000F_2004_2005;

		public static _0008_2004 _0005_2004_2005;

		public static _0008_2004 _0003_2004_2005;

		public static _0008_2004 _000E_2004_2005;

		public static _0008_2004 _0002_2007_2005;

		public static _0008_2004 _0008_2007_2005;

		public static _0008_2004 _0006_2007_2005;

		public static _0008_2004 _000F_2007_2005;

		public static _0008_2004 _0005_2007_2005;

		public static _0008_2004 _0003_2007_2005;

		public static _0008_2004 _000E_2007_2005;

		public static _0008_2004 _0002_2003_2005;

		public static _0008_2004 _0008_2003_2005;

		public static _0008_2004 _0006_2003_2005;

		public static _0008_2004 _000F_2003_2005;

		public static _0008_2004 _0005_2003_2005;

		public static _0008_2004 _0003_2003_2005;

		public static _0008_2004 _000E_2003_2005;

		public static _0008_2004 _0002_2009_2005;

		public static _0008_2004 _0008_2009_2005;

		public static _0008_2004 _0006_2009_2005;

		public static _0008_2004 _000F_2009_2005;

		public static _0008_2004 _0005_2009_2005;

		public static _0008_2004 _0003_2009_2005;

		public static _0008_2004 _000E_2009_2005;

		public static _0008_2004 _0002_2001_2005;

		public static _0008_2004 _0008_2001_2005;

		public static _0008_2004 _0006_2001_2005;

		public static _0008_2004 _000F_2001_2005;

		public static _0008_2004 _0005_2001_2005;

		public static _0008_2004 _0003_2001_2005;

		public static _0008_2004 _000E_2001_2005;

		public static _0008_2004 _0002_2002_2005;

		public static _0008_2004 _0008_2002_2005;

		public static _0008_2004 _0006_2002_2005;

		public static _0008_2004 _000F_2002_2005;

		public static _0008_2004 _0005_2002_2005;

		public static _0008_2004 _0003_2002_2005;

		public static _0008_2004 _000E_2002_2005;

		public static _0008_2004 _0002_2008_2005;

		public static _0008_2004 _0008_2008_2005;

		public static _0008_2004 _0006_2008_2005;

		public static _0008_2004 _000F_2008_2005;

		public static _0008_2004 _0005_2008_2005;

		public static _0008_2004 _0003_2008_2005;

		public static _0008_2004 _000E_2008_2005;

		public static _0008_2004 _0002_200B_2005;

		public static _0008_2004 _0008_200B_2005;

		public static _0008_2004 _0006_200B_2005;

		public static _0008_2004 _000F_200B_2005;

		public static _0008_2004 _0005_200B_2005;

		public static _0008_2004 _0003_200B_2005;

		public static _0008_2004 _000E_200B_2005;

		public static _0008_2004 _0002_2006_2005;

		public static _0008_2004 _0008_2006_2005;

		public static _0008_2004 _0006_2006_2005;

		public static _0008_2004 _000F_2006_2005;

		public static _0008_2004 _0005_2006_2005;

		public static _0008_2004 _0003_2006_2005;

		public static _0008_2004 _000E_2006_2005;

		public static _0008_2004 _0002_2005_2005;

		public static _0008_2004 _0008_2005_2005;

		public static _0008_2004 _0006_2005_2005;

		public static _0008_2004 _000F_2005_2005;

		public static _0008_2004 _0005_2005_2005;

		public static _0008_2004 _0003_2005_2005;

		public static _0008_2004 _000E_2005_2005;

		public static _0008_2004 _0002_2000_2005;

		public static _0008_2004 _0008_2000_2005;

		public static _0008_2004 _0006_2000_2005;

		public static _0008_2004 _000F_2000_2005;

		public static _0008_2004 _0005_2000_2005;

		public static _0008_2004 _0003_2000_2005;

		public static _0008_2004 _000E_2000_2005;

		public static _0008_2004 _0002_200A_2005;

		public static _0008_2004 _0008_200A_2005;

		public static _0008_2004 _0006_200A_2005;

		public static _0008_2004 _000F_200A_2005;

		public static _0008_2004 _0005_200A_2005;

		public static _0008_2004 _0003_200A_2005;

		public static _0008_2004 _000E_200A_2005;

		public static _0008_2004 _0002_2004_2000;

		public static _0008_2004 _0008_2004_2000;

		public static _0008_2004 _0006_2004_2000;

		public static _0008_2004 _000F_2004_2000;

		public static _0008_2004 _0005_2004_2000;

		public static _0008_2004 _0003_2004_2000;

		public static _0008_2004 _000E_2004_2000;

		public static _0008_2004 _0002_2007_2000;

		public static _0008_2004 _0008_2007_2000;

		public static _0008_2004 _0006_2007_2000;

		public static _0008_2004 _000F_2007_2000;

		public static _0008_2004 _0005_2007_2000;

		public static _0008_2004 _0003_2007_2000;

		public static _0008_2004 _000E_2007_2000;

		public static _0008_2004 _0002_2003_2000;

		public static _0008_2004 _0008_2003_2000;

		public static _0008_2004 _0006_2003_2000;

		public static _0008_2004 _000F_2003_2000;

		public static _0008_2004 _0005_2003_2000;

		public static _0008_2004 _0003_2003_2000;

		public static _0008_2004 _000E_2003_2000;

		public static _0008_2004 _0002_2009_2000;

		public static _0008_2004 _0008_2009_2000;

		public static _0008_2004 _0006_2009_2000;

		public static _0008_2004 _000F_2009_2000;

		public static _0008_2004 _0005_2009_2000;

		public static _0008_2004 _0003_2009_2000;

		public static _0008_2004 _000E_2009_2000;

		public static _0008_2004 _0002_2001_2000;

		public static _0008_2004 _0008_2001_2000;
	}

	private sealed class _0005_2004<_0002> : IComparer<KeyValuePair<int, _0002>>
	{
		private readonly Comparison<_0002> _0002;

		public _0005_2004(Comparison<_0002> _0002)
		{
			if (8u != 0)
			{
				this._0002 = _0002;
			}
		}

		public int Compare(KeyValuePair<int, _0002> _0002, KeyValuePair<int, _0002> _0008)
		{
			int num = this._0002(_0002.Value, _0008.Value);
			int num2 = default(int);
			if (0 == 0)
			{
				num2 = num;
			}
			if (num2 == 0)
			{
				int key = _0008.Key;
				int num3;
				if (8u != 0)
				{
					num3 = key;
				}
				return num3.CompareTo(_0002.Key);
			}
			return num2;
		}
	}

	private delegate object _0006(object _0002, object[] _0008);

	[Serializable]
	private sealed class _0006_2004
	{
		public static readonly _0006_2004 _0002;

		public static Comparison<global::_0003_2005> _0008;

		static _0006_2004()
		{
			_0006_2004 obj = new _0006_2004();
			if (8u != 0)
			{
				global::_0006_2009._0006_2004._0002 = obj;
			}
		}

		public _0006_2004()
		{
			_ = 6;
			if (false)
			{
			}
			base._002Ector();
		}

		internal int _0002(global::_0003_2005 _0002, global::_0003_2005 _0008)
		{
			uint num2;
			if (_0002._0008() == _0008._0008())
			{
				uint num = _0008._0006();
				if (uint.MaxValue != 0)
				{
					num2 = num;
				}
				return num2.CompareTo(_0002._0006());
			}
			uint num3 = _0002._0008();
			if (3u != 0)
			{
				num2 = num3;
			}
			return num2.CompareTo(_0008._0008());
		}
	}

	private struct _0008
	{
		private readonly uint m__0002;

		private readonly object m__0008;

		public _0008(uint _0002)
		{
			if (7u != 0)
			{
				this.m__0002 = _0002;
			}
			if (5u != 0)
			{
				m__0008 = null;
			}
		}

		public _0008(uint _0002, object _0008)
		{
			if (uint.MaxValue != 0)
			{
				this.m__0002 = _0002;
			}
			if (true)
			{
				this.m__0008 = _0008;
			}
		}

		[global::_0008_2000]
		public uint _0002()
		{
			_ = 0;
			if (-1 == 0)
			{
			}
			return this.m__0002;
		}

		[global::_0008_2000]
		public object _0002()
		{
			_ = -1;
			if (6 == 0)
			{
			}
			return m__0008;
		}
	}

	private delegate void _0008_2004(global::_0006_2009 _0002, global::_0006 _0008);

	private sealed class _000E
	{
		public _000E()
		{
			_ = -1;
			if (-1 == 0)
			{
			}
			base._002Ector();
		}
	}

	private struct _000E_2004
	{
		public bool _0002;
	}

	private sealed class _000F
	{
		private string m__0002;

		private Type _0008;

		public _000F()
		{
			_ = 3;
			if (7 == 0)
			{
			}
			base._002Ector();
		}

		public string _0002()
		{
			_ = -1;
			if (5 == 0)
			{
			}
			return this.m__0002;
		}

		public void _0002(string _0002)
		{
			if (6u != 0)
			{
				this.m__0002 = _0002;
			}
		}

		public Type _0002()
		{
			_ = 3;
			if (7 == 0)
			{
			}
			return _0008;
		}

		public void _0002(Type _0002)
		{
			if (5u != 0)
			{
				_0008 = _0002;
			}
		}
	}

	private sealed class _000F_2004 : IDisposable
	{
		public global::_0008_2003 _0002;

		public global::_0002_2004_2005 _0008;

		public global::_0005 _0006;

		public long _000F;

		public _000F_2004()
		{
			_ = 4;
			if (6 == 0)
			{
			}
			base._002Ector();
		}

		public void Dispose()
		{
			global::_0002_2004_2005 obj = _0008;
			IDisposable disposable = default(IDisposable);
			if (0 == 0)
			{
				disposable = obj;
			}
			if (disposable != null)
			{
				disposable.Dispose();
				if (4u != 0)
				{
					disposable = null;
				}
			}
			if (_0006 != null)
			{
				_0006.Dispose();
				if (4u != 0)
				{
					_0006 = null;
				}
			}
		}
	}

	private object m__0008_2007;

	private Type[] m__000F_2003;

	private static Dictionary<int, _0003_2004> m__0002_2003;

	private global::_0002_2004_2005 m__0006_2004;

	private readonly global::_0008_2005 m__0006_2009;

	private Stack<_000F_2004> m__0002_2001;

	private static object m__0006_2003;

	private readonly Module m__000E_2007;

	private bool m__0003_2004;

	private static Type m__0003_2003;

	private global::_0003_2004_2005 m__0003;

	private global::_0006[] m__0008_2003;

	private Stream m__000F_2004;

	private global::_0006[] m__0008_2009;

	private bool m__0005_2009;

	private static Type m__0005;

	private static readonly Dictionary<int, object> m__0005_2001;

	private Type m__0005_2007;

	private global::_0002_2004_2005 m__000F_2007;

	private object[] m__0006_2001;

	private static Type m__000E_2003;

	private uint m__0008_2004;

	private static readonly Dictionary<_0002, _0006> m__0006;

	private static Type m__0003_2009;

	private global::_0003_2005[] m__000E_2004;

	private uint m__0006_2007;

	private static Type m__0005_2004;

	private readonly Stack<global::_0006> m__0002_2009;

	private byte[] m__0008;

	private long m__0002_2004;

	private static Type m__0002_2007;

	private global::_0006 m__000E;

	private uint? m__0003_2007;

	private uint m__000F_2001;

	private global::_0006 m__0002;

	private static Type m__000F_2009;

	private Type[] m__0005_2003;

	private readonly Stack<_0008> m__000F;

	private static readonly Dictionary<MethodBase, object> m__0008_2001;

	private static readonly Dictionary<MethodBase, int> m__000E_2009;

	public _0006_2009(global::_0008_2005 _0002, Module _0008)
	{
		Stack<_0008> stack = new Stack<_0008>();
		if (4u != 0)
		{
			this.m__000F = stack;
		}
		Stack<global::_0006> stack2 = new Stack<global::_0006>(16);
		if (0 == 0)
		{
			this.m__0002_2009 = stack2;
		}
		base._002Ector();
		if (6u != 0)
		{
			this.m__0006_2009 = _0002;
		}
		this.m__000E_2007 = _0008;
		_0002_2004();
	}

	public _0006_2009(global::_0008_2005 _0002)
	{
		_ = -1;
		if (1 == 0)
		{
		}
		_ = 3;
		if (false)
		{
		}
		this._002Ector(_0002, typeof(global::_0006_2009).Module);
	}

	static _0006_2009()
	{
		object obj = new object();
		if (uint.MaxValue != 0)
		{
			global::_0006_2009.m__0006_2003 = obj;
		}
		Dictionary<_0002, _0006> dictionary = new Dictionary<_0002, _0006>(256);
		if (2u != 0)
		{
			global::_0006_2009.m__0006 = dictionary;
		}
		Dictionary<MethodBase, int> dictionary2 = new Dictionary<MethodBase, int>(256);
		if (3u != 0)
		{
			global::_0006_2009.m__000E_2009 = dictionary2;
		}
		global::_0006_2009.m__0008_2001 = new Dictionary<MethodBase, object>();
		global::_0006_2009.m__0005_2001 = new Dictionary<int, object>();
		global::_0006_2009.m__000F_2009 = typeof(_000E);
		global::_0006_2009.m__0003_2009 = typeof(void);
		global::_0006_2009.m__000E_2003 = typeof(object[]);
		global::_0006_2009.m__0005 = typeof(IntPtr);
		global::_0006_2009.m__0002_2007 = typeof(Assembly);
		global::_0006_2009.m__0003_2003 = typeof(MethodBase);
		global::_0006_2009.m__0005_2004 = typeof(RuntimeHelpers);
	}

	private static void _000E(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (7 == 0)
		{
		}
		_0002._0005();
	}

	private static void _0006_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		FieldInfo fieldInfo = _0002._0002(num2);
		FieldInfo fieldInfo2;
		if (true)
		{
			fieldInfo2 = fieldInfo;
		}
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = _0002._0002();
		global::_0006 obj3;
		if (2u != 0)
		{
			obj3 = obj2;
		}
		global::_0002_2004 obj4 = obj3 as global::_0002_2004;
		object obj5 = ((obj4 == null) ? obj3._0006_2008_2009_0002() : _0002._0002(obj4)._0006_2008_2009_0002());
		if (obj5 == null)
		{
			throw new NullReferenceException();
		}
		global::_0006 obj6 = global::_0006._0002(obj._0006_2008_2009_0002(), fieldInfo2.FieldType);
		fieldInfo2.SetValue(obj5, obj6._0006_2008_2009_0002());
		if (obj4 != null && obj5 != null && obj5.GetType().IsValueType)
		{
			_0002._0002(obj4, global::_0006._0002(obj5, null));
		}
	}

	private static void _0008_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0005_2007 obj = (global::_0005_2007)_0008;
		global::_0005_2007 obj2 = default(global::_0005_2007);
		if (0 == 0)
		{
			obj2 = obj;
		}
		_0002._0005(obj2._0002());
	}

	private static void _0005_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (2 == 0)
		{
		}
		_0002._0008_2004(_0002: false);
	}

	private MethodBase _0002(global::_0005_2006 _0002)
	{
		Type type = this._0002(_0002._0002()._0002(), _0008: false);
		Type type2;
		if (true)
		{
			type2 = type;
		}
		BindingFlags num = global::_0006_2009._0002(_0002._0002());
		BindingFlags bindingAttr;
		if (2u != 0)
		{
			bindingAttr = num;
		}
		Type[] array = default(Type[]);
		if (0 == 0)
		{
			array = null;
		}
		global::_0002[] array2 = _0002._0008();
		if (array2 != null)
		{
			array = new Type[array2.Length];
			for (int i = 0; i < array.Length; i++)
			{
				global::_0002 obj = array2[i];
				if (obj != null)
				{
					array[i] = this._0002(obj._0002(), _0008: true);
				}
			}
		}
		MemberInfo[] member = type2.GetMember(_0002._0002(), MemberTypes.Method, bindingAttr);
		MethodInfo methodInfo = null;
		int num2 = -1;
		MemberInfo[] array3 = member;
		for (int j = 0; j < array3.Length; j++)
		{
			MethodInfo methodInfo2 = (MethodInfo)array3[j];
			if (this._0002(methodInfo2, _0002, array, out var num3) && num3 > num2)
			{
				methodInfo = methodInfo2;
				num2 = num3;
			}
		}
		if (methodInfo == null)
		{
			throw new Exception(string.Format(global::_0008_0010._0002(-1463125115), type2.Name, _0002._0002()));
		}
		return methodInfo.MakeGenericMethod(array);
	}

	private static void _0006_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (true)
		{
			num2 = num;
		}
		uint num3;
		switch (num2)
		{
		case 1:
		{
			int num4 = ((global::_000F)obj2)._0002();
			if (8u != 0)
			{
				num3 = (uint)num4;
			}
			break;
		}
		case 13:
			num3 = (uint)((global::_0003_2000)obj2)._0002();
			break;
		case 19:
			num3 = (uint)Convert.ToInt64(obj2._0006_2008_2009_0002());
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_000F[] array = (global::_000F[])((global::_0006_2004)_0008)._0002();
		if (num3 < array.Length)
		{
			uint num5 = (uint)array[num3]._0002();
			_0002._0002(num5);
		}
	}

	private static void _0002_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (5 == 0)
		{
		}
		_0002._000F();
	}

	private static global::_0006 _0006(global::_0006 _0002, global::_0006 _0008, bool _0006, bool _000F)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				if (!_000F)
				{
					int num = ((global::_000F)_0002)._0002();
					int num2;
					if (3u != 0)
					{
						num2 = num;
					}
					int num3 = ((global::_000F)_0008)._0002();
					int num4;
					if (2u != 0)
					{
						num4 = num3;
					}
					int num6;
					if (_0006)
					{
						int num5 = checked(num2 - num4);
						if (true)
						{
							num6 = num5;
						}
					}
					else
					{
						int num7 = num2 - num4;
						if (8u != 0)
						{
							num6 = num7;
						}
					}
					return new global::_000F(num6);
				}
				int num8 = ((global::_000F)_0002)._0002();
				uint num9;
				if (true)
				{
					num9 = (uint)num8;
				}
				int num10 = ((global::_000F)_0008)._0002();
				uint num11;
				if (3u != 0)
				{
					num11 = (uint)num10;
				}
				uint num13;
				if (_0006)
				{
					uint num12 = checked(num9 - num11);
					if (6u != 0)
					{
						num13 = num12;
					}
				}
				else
				{
					num13 = num9 - num11;
				}
				return new global::_000F((int)num13);
			}
			if (_0008._0002() == 13)
			{
				return _0005(new global::_0003_2000(((global::_000F)_0002)._0002()), _0008, _0006, _000F);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return _0005(new global::_0003_2000(((global::_000F)_0002)._0002()), new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006, _000F);
				}
				return global::_0006_2009._0006(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006, _000F);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				return _0005(_0002, _0008, _0006, _000F);
			}
			if (_0008._0002() == 1)
			{
				return _0005(_0002, new global::_0003_2000(((global::_000F)_0008)._0002()), _0006, _000F);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return _0005(_0002, new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006, _000F);
				}
				return _0005(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006, _000F);
			}
		}
		if (_0002._0002() == 8 && _0008._0002() == 8)
		{
			global::_0006_200A obj = new global::_0006_200A();
			obj._0002(((global::_0006_200A)_0002)._0002() - ((global::_0006_200A)_0008)._0002());
			return obj;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return global::_0006_2009._0006(new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008, _0006, _000F);
			}
			return global::_0006_2009._0006(new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008, _0006, _000F);
		}
		throw new InvalidOperationException();
	}

	private static void _0003_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (2 == 0)
		{
		}
		_ = 8;
		if (false)
		{
		}
		_0002._0002(_0008);
	}

	private static void _0005_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (6 == 0)
		{
		}
		_0002._0002(1);
	}

	private global::_0005_2004 _0002(global::_0002_2004_2005 _0002)
	{
		byte num = _0002._0002();
		byte b;
		if (true)
		{
			b = num;
		}
		switch (b)
		{
		case 2:
		{
			global::_0005_2002 obj7 = new global::_0005_2002();
			obj7._0002(_0002._0002());
			obj7._0008(_0002._0002());
			obj7._0002(_0002._0002());
			obj7._0008(_0002._0005());
			obj7._0002(_0002._0005());
			global::_0005_2002 obj8;
			if (2u != 0)
			{
				obj8 = obj7;
			}
			int num6 = _0002._000F();
			int num7;
			if (true)
			{
				num7 = num6;
			}
			global::_0002[] array3 = new global::_0002[num7];
			global::_0002[] array4;
			if (7u != 0)
			{
				array4 = array3;
			}
			int k = default(int);
			if (0 == 0)
			{
				k = 0;
			}
			for (; k < num7; k++)
			{
				int num8 = k;
				global::_0002 obj9 = new global::_0002();
				obj9._0002((byte)1);
				obj9._0002(_0002._0005());
				array4[num8] = obj9;
			}
			obj8._0002(array4);
			return obj8;
		}
		case 1:
		{
			global::_0003_2004 obj11 = new global::_0003_2004();
			global::_0002 obj12 = new global::_0002();
			obj12._0002((byte)1);
			obj12._0002(_0002._0005());
			obj11._0002(obj12);
			obj11._0002(_0002._0002());
			obj11._0002(_0002._0002());
			return obj11;
		}
		case 3:
		{
			global::_0002_200A obj10 = new global::_0002_200A();
			obj10._0002(_0002._0005());
			obj10._0008(_0002._0005());
			return obj10;
		}
		case 0:
		{
			global::_0005_2006 obj2 = new global::_0005_2006();
			global::_0002 obj3 = new global::_0002();
			obj3._0002((byte)1);
			obj3._0002(_0002._0005());
			obj2._0002(obj3);
			obj2._0002(_0002._0002());
			obj2._0002(_0002._0002());
			global::_0002 obj4 = new global::_0002();
			obj4._0002((byte)1);
			obj4._0002(_0002._0005());
			obj2._0008(obj4);
			int num2 = _0002._000F();
			global::_0002[] array = new global::_0002[num2];
			for (int i = 0; i < num2; i++)
			{
				int num3 = i;
				global::_0002 obj5 = new global::_0002();
				obj5._0002((byte)1);
				obj5._0002(_0002._0005());
				array[num3] = obj5;
			}
			obj2._0002(array);
			int num4 = _0002._000F();
			global::_0002[] array2 = new global::_0002[num4];
			for (int j = 0; j < num4; j++)
			{
				int num5 = j;
				global::_0002 obj6 = new global::_0002();
				obj6._0002((byte)1);
				obj6._0002(_0002._0005());
				array2[num5] = obj6;
			}
			obj2._0008(array2);
			return obj2;
		}
		case 4:
		{
			global::_0006_2008 obj = new global::_0006_2008();
			obj._0002(_0002._0002());
			return obj;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _000E_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (6 == 0)
		{
		}
		_0002._000F(_0002: false);
	}

	private void _000E(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (true)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		int num3;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				int num4 = ((global::_000F)obj2)._0002();
				if (5u != 0)
				{
					num3 = num4;
				}
			}
			else
			{
				num3 = ((global::_000F)obj2)._0002();
			}
			break;
		case 13:
			num3 = (int)((!_0002) ? ((global::_0003_2000)obj2)._0002() : checked((int)((global::_0003_2000)obj2)._0002()));
			break;
		case 19:
			num3 = ((!_0002) ? ((int)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : checked((int)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			num3 = ((!_0002) ? ((int)((global::_0006_200A)obj2)._0002()) : checked((int)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			num3 = (int)((IntPtr.Size != 4) ? ((!_0002) ? ((long)((global::_0006_2002)obj2)._0002()) : checked((int)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((int)((global::_0006_2002)obj2)._0002()) : ((int)((global::_0006_2002)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_000F obj3 = new global::_000F();
		obj3._0002(num3);
		_0008((global::_0006)obj3);
	}

	private void _0002(global::_0002_200A _0002)
	{
		global::_0002 obj = this._0002(_0002._0008());
		global::_0002 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = this._0002(_0002._0008(), obj2);
		MethodBase methodBase2;
		if (3u != 0)
		{
			methodBase2 = methodBase;
		}
		int num = _0002._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		bool flag = (num2 & 0x40000000) != 0;
		num2 &= -1073741825;
		Type[] array = this.m__0005_2003;
		Type[] array2 = this.m__000F_2003;
		try
		{
			this.m__0005_2003 = ((methodBase2 is ConstructorInfo) ? null : methodBase2.GetGenericArguments());
			this.m__000F_2003 = methodBase2.DeclaringType.GetGenericArguments();
			this._0002(num2, this.m__0005_2003, this.m__000F_2003, flag);
		}
		finally
		{
			this.m__0005_2003 = array;
			this.m__000F_2003 = array2;
		}
	}

	private static void _000F_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (2u != 0)
		{
			type2 = type;
		}
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		if (_0002._0002(obj2, type2))
		{
			_0002._0008(obj2);
		}
		else
		{
			_0002._0008((global::_0006)new global::_0005_2003());
		}
	}

	private static void _0005_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
	}

	[Conditional("DEBUG")]
	public static void _0002(string _0002)
	{
	}

	private static void _0006_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (1 == 0)
		{
		}
		_0002._0005(_0002: true);
	}

	private static void _0008_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		checked
		{
			byte b;
			switch (num2)
			{
			case 1:
			{
				byte num3 = (byte)(uint)((global::_000F)obj2)._0002();
				if (7u != 0)
				{
					b = num3;
				}
				break;
			}
			case 13:
				b = (byte)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				b = (byte)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				b = (byte)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				b = ((IntPtr.Size != 4) ? ((byte)(ulong)(long)((global::_0006_2002)obj2)._0002()) : ((byte)(uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0002._0008((global::_0006)new global::_000F(b));
		}
	}

	private void _0002(global::_0002_2004_2005 _0002)
	{
	}

	private Type _0002(int _0002, bool _0008)
	{
		Dictionary<int, object> dictionary = global::_0006_2009.m__0005_2001;
		Dictionary<int, object> obj;
		if (true)
		{
			obj = dictionary;
		}
		bool lockTaken;
		if (3u != 0)
		{
			lockTaken = false;
		}
		Type type;
		try
		{
			if (3u != 0)
			{
				Monitor.Enter(obj, ref lockTaken);
			}
			bool flag = true;
			if (flag && global::_0006_2009.m__0005_2001.TryGetValue(_0002, out var value))
			{
				type = (Type)value;
			}
			else
			{
				global::_0002 obj2 = this._0002(_0002);
				type = this._0002(_0002, obj2, ref flag, _0008);
				if (flag)
				{
					global::_0006_2009.m__0005_2001.Add(_0002, type);
				}
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
		if (_0008)
		{
			this._0002((MemberInfo)type);
		}
		return type;
	}

	private static void _0003_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (1 == 0)
		{
		}
		_0002._0008(global::_0006_2009.m__0005);
	}

	private static void _0006_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (4 == 0)
		{
		}
		_0002._000F(1);
	}

	private int _0002()
	{
		return -1948615370;
	}

	private static void _0005_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (5 == 0)
		{
		}
		_0002._0002(2);
	}

	private void _0008(bool _0002, bool _0008)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = this._0002();
		global::_0006 obj4;
		if (uint.MaxValue != 0)
		{
			obj4 = obj3;
		}
		global::_0006 obj5 = _000F(obj4, obj2, _0002, _0008);
		if (uint.MaxValue != 0)
		{
			this._0008(obj5);
		}
	}

	private void _0002(object _0002, uint _0008)
	{
		bool num = _0002 != null;
		bool flag;
		if (6u != 0)
		{
			flag = num;
		}
		if (true)
		{
			this.m__0008_2007 = _0002;
		}
		if (flag)
		{
			this.m__000F.Clear();
		}
		if (8u != 0)
		{
			this.m__0005_2009 = flag;
		}
		if (!flag)
		{
			this.m__000F.Push(new _0008(_0008));
		}
		global::_0003_2005[] array = this.m__000E_2004;
		foreach (global::_0003_2005 obj in array)
		{
			if (!global::_0006_2009._0002(this.m__000F_2001, obj._0008(), obj._0006()))
			{
				continue;
			}
			switch (obj._0008())
			{
			case 2:
				if (flag || !global::_0006_2009._0002(_0008, obj._0008(), obj._0006()))
				{
					this.m__000F.Push(new _0008(obj._0002()));
				}
				break;
			case 1:
				if (flag)
				{
					this.m__000F.Push(new _0008(obj._0002()));
				}
				break;
			case 4:
				if (flag)
				{
					this.m__000F.Push(new _0008(obj._000F(), _0002));
				}
				break;
			case 0:
				if (flag)
				{
					Type type = _0002.GetType();
					Type type2 = this._0002(obj._0002(), _0008: true);
					if (type == type2 || type.IsSubclassOf(type2))
					{
						this.m__000F.Push(new _0008(obj._0002(), _0002));
						this.m__0005_2009 = false;
					}
				}
				break;
			}
		}
		_0003();
	}

	private static void _0002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (5 == 0)
		{
		}
		_0002._0005(_0002: false);
	}

	private global::_0005_2008[] _0002(global::_0002_2004_2005 _0002)
	{
		global::_0005_2008[] array = new global::_0005_2008[_0002._0002()];
		global::_0005_2008[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		int num = default(int);
		if (0 == 0)
		{
			num = 0;
		}
		while (num < array2.Length)
		{
			array2[num] = this._0002(_0002);
			int num2 = num + 1;
			if (2u != 0)
			{
				num = num2;
			}
		}
		return array2;
	}

	private static void _0006_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (8 == 0)
		{
		}
		_0002._000F(0);
	}

	private static Exception _0002(string _0002, string _0008)
	{
		string text = global::_0008_0010._0002(-1463125880);
		_ = 5;
		if (5 == 0)
		{
		}
		string text2 = text + _0002 + global::_0008_0010._0002(-1463125844);
		string text3 = global::_0008_0010._0002(-1463125676);
		_ = 6;
		if (2 == 0)
		{
		}
		return new TypeLoadException(global::_0006_2009._0002(text2, text3 + _0008 + global::_0008_0010._0002(-1463125844)));
	}

	private bool _0002(global::_000E_200B _0002)
	{
		if (!_0002._0002().IsInitOnly)
		{
			return true;
		}
		if (_0002._0002().IsStatic != this.m__0003._0002())
		{
			return false;
		}
		if (this.m__0003._0002() && this.m__0003._0002() != global::_0008_0010._0002(-1463124670))
		{
			return false;
		}
		Type declaringType = _0002._0002().DeclaringType;
		Type type;
		if (5u != 0)
		{
			type = declaringType;
		}
		if (type.IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (3u != 0)
			{
				type = genericTypeDefinition;
			}
		}
		return this._0002(this.m__0003._0002(), _0008: true) == type;
	}

	private static void _0005_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (8 == 0)
		{
		}
		_0002._0003();
	}

	private static void _000E_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (4 == 0)
		{
		}
		_0002._0005(0);
	}

	private void _0002(MemberInfo _0002)
	{
		if (!global::_0006_2009._0002() || this.m__0003._0008())
		{
			return;
		}
		bool flag;
		if (3u != 0)
		{
			flag = false;
		}
		Assembly assembly = typeof(SecurityCriticalAttribute).Assembly;
		Assembly assembly2;
		if (8u != 0)
		{
			assembly2 = assembly;
		}
		MemberInfo memberInfo;
		if (8u != 0)
		{
			memberInfo = _0002;
		}
		while (memberInfo != null)
		{
			object[] customAttributes = memberInfo.GetCustomAttributes(inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type = customAttributes[i].GetType();
				if (type.Assembly == assembly2)
				{
					string fullName = type.FullName;
					if (global::_0008_0010._0002(-1463125904).Equals(fullName, StringComparison.Ordinal))
					{
						flag = true;
						goto end_IL_00af;
					}
					if (global::_0008_0010._0002(-1463126016).Equals(fullName, StringComparison.Ordinal))
					{
						goto end_IL_00af;
					}
				}
			}
			memberInfo = memberInfo.DeclaringType;
			continue;
			end_IL_00af:
			break;
		}
		if (flag)
		{
			if (_0002 is MethodBase)
			{
				string text = global::_0006_2009._0002((MethodBase)_0002);
				throw _0008(this._0002(this.m__0003), text);
			}
			if (_0002 is FieldInfo)
			{
				string text2 = _0002.DeclaringType.FullName + global::_0008_0010._0002(-1463125804) + _0002.Name;
				throw _0006(this._0002(this.m__0003), text2);
			}
			if (_0002 is Type)
			{
				string fullName2 = ((Type)_0002).FullName;
				throw global::_0006_2009._0002(this._0002(this.m__0003), fullName2);
			}
			throw new SecurityException(global::_0008_0010._0002(-1463125796));
		}
	}

	private void _0008_2004(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		ushort num3;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				ushort num4 = checked((ushort)(uint)((global::_000F)obj2)._0002());
				if (5u != 0)
				{
					num3 = num4;
				}
			}
			else
			{
				ushort num5 = (ushort)((global::_000F)obj2)._0002();
				if (2u != 0)
				{
					num3 = num5;
				}
			}
			break;
		case 13:
			if (_0002)
			{
				ushort num6 = checked((ushort)(ulong)((global::_0003_2000)obj2)._0002());
				if (6u != 0)
				{
					num3 = num6;
				}
			}
			else
			{
				num3 = (ushort)((global::_0003_2000)obj2)._0002();
			}
			break;
		case 19:
			num3 = ((!_0002) ? ((ushort)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : checked((ushort)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			num3 = ((!_0002) ? ((ushort)((global::_0006_200A)obj2)._0002()) : checked((ushort)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			num3 = ((IntPtr.Size != 4) ? ((!_0002) ? ((ushort)(long)((global::_0006_2002)obj2)._0002()) : checked((ushort)(ulong)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((ushort)(int)((global::_0006_2002)obj2)._0002()) : checked((ushort)(int)((global::_0006_2002)obj2)._0002())));
			break;
		case 20:
			num3 = ((UIntPtr.Size != 4) ? ((!_0002) ? ((ushort)(ulong)((global::_0002_2003)obj2)._0002()) : checked((ushort)(ulong)((global::_0002_2003)obj2)._0002())) : ((!_0002) ? ((ushort)(uint)((global::_0002_2003)obj2)._0002()) : checked((ushort)(uint)((global::_0002_2003)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0008((global::_0006)new global::_000F(num3));
	}

	private static void _0003_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (8 == 0)
		{
		}
		_0002._0005();
	}

	private static void _0002_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (-1 == 0)
		{
		}
		_0002._0003(6);
	}

	private global::_0006 _000F(global::_0006 _0002, global::_0006 _0008)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				int num = ((global::_000F)_0002)._0002();
				int num2 = ((global::_000F)_0008)._0002();
				int num3;
				if (7u != 0)
				{
					num3 = num2;
				}
				return new global::_000F(num << num3);
			}
			if (_0008._0002() == 19)
			{
				return _000F(_0002, (global::_0006)new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())));
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 1)
			{
				long num4 = ((global::_0003_2000)_0002)._0002();
				int num5 = ((global::_000F)_0008)._0002();
				int num6;
				if (4u != 0)
				{
					num6 = num5;
				}
				return new global::_0003_2000(num4 << num6);
			}
			if (_0008._0002() == 19)
			{
				return _000F(_0002, (global::_0006)new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())));
			}
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			Type type;
			if (7u != 0)
			{
				type = underlyingType;
			}
			if (type == typeof(long) || type == typeof(ulong))
			{
				return _000F((global::_0006)new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008);
			}
			return _000F((global::_0006)new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008);
		}
		throw new InvalidOperationException();
	}

	public static void _0002<T>(T[] _0002, Comparison<T> _0008)
	{
		KeyValuePair<int, T>[] array = new KeyValuePair<int, T>[_0002.Length];
		KeyValuePair<int, T>[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		int num;
		if (7u != 0)
		{
			num = 0;
		}
		while (num < _0002.Length)
		{
			array2[num] = new KeyValuePair<int, T>(num, _0002[num]);
			int num2 = num + 1;
			if (3u != 0)
			{
				num = num2;
			}
		}
		Array.Sort(array2, _0002, new _0005_2004<T>(_0008));
	}

	private object _0002(object[] _0002, Type[] _0008, Type[] _0006, object[] _000F)
	{
		if (true)
		{
			this._0008();
		}
		if (_0002 == null)
		{
			object[] array = global::_0003_2006<object>._0002;
			if (3u != 0)
			{
				_0002 = array;
			}
		}
		if (7u != 0)
		{
			this.m__0006_2001 = _000F;
		}
		if (3u != 0)
		{
			this.m__0005_2003 = _0008;
		}
		this.m__000F_2003 = _0006;
		this.m__0008_2003 = this._0002(_0002);
		this.m__0008_2009 = this._0002();
		try
		{
			global::_0003 obj = new global::_0003(this.m__0008);
			try
			{
				using (this.m__000F_2007 = new global::_0002_2004_2005(obj))
				{
					this.m__0006_2007 = (uint)((global::_0005)obj)._0005_2008_2009_0002();
					this.m__0003_2004 = false;
					this.m__0003_2007 = null;
					this.m__000F_2001 = 0u;
					this.m__0008_2004 = 0u;
					_0008_2004();
					this._0006();
				}
			}
			finally
			{
				((IDisposable)obj).Dispose();
			}
			Type type = this._0002(this.m__0003._0008(), _0008: false);
			if (type != global::_0006_2009.m__0003_2009 && this._0002())
			{
				return global::_0006._0002(null, type)._0006_2008_2009_0002(this._0002())._0006_2008_2009_0002();
			}
			return null;
		}
		finally
		{
			for (int i = 0; i < this.m__0003._0002().Length; i++)
			{
				global::_0002_2006 obj2 = this.m__0003._0002()[i];
				if (obj2._0002())
				{
					global::_000F_2006 obj3 = (global::_000F_2006)this.m__0008_2003[i];
					Type type2 = this._0002(obj2._0002(), _0008: false);
					_0002[i] = global::_0006._0002(null, type2.GetElementType())._0006_2008_2009_0002(obj3._0002())._0006_2008_2009_0002();
				}
			}
			this.m__0006_2001 = null;
			this.m__0008_2003 = null;
			this.m__0008_2009 = null;
		}
	}

	private void _0002(int _0002)
	{
		global::_0006 obj = this.m__0008_2009[_0002]._0006_2008_2009_0002();
		if (5u != 0)
		{
			_0008(obj);
		}
	}

	private static void _0003_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463124273));
	}

	private static void _0008_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0008_2004_2005 obj = (global::_0008_2004_2005)_0008;
		global::_0008_2004_2005 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		_0002._0005(obj2._0002());
	}

	private static void _000E_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (8 == 0)
		{
		}
		_0002._0003(_0002: false);
	}

	private static void _0003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		if (3u != 0)
		{
			Thread.MemoryBarrier();
		}
	}

	private static void _0008_2001_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (8 == 0)
		{
		}
		_0002._0006_2004(_0002: true);
	}

	private static void _0003_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (5u != 0)
		{
			obj4 = obj3;
		}
		global::_000F obj5 = new global::_000F();
		obj5._0002(_000F(obj4, obj2) ? 1 : 0);
		_0002._0008((global::_0006)obj5);
	}

	private void _0002(ref _000E_2004 _0002)
	{
		if (_0002._0002)
		{
			object obj = global::_0006_2009.m__0006_2003;
			if (3u != 0)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private static void _0005_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (5 == 0)
		{
		}
		_0002._0005();
	}

	private static void _000E_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (true)
		{
			num2 = num;
		}
		checked
		{
			int num3;
			switch (num2)
			{
			case 1:
			{
				int num4 = (int)(uint)((global::_000F)obj2)._0002();
				if (4u != 0)
				{
					num3 = num4;
				}
				break;
			}
			case 13:
				num3 = (int)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				num3 = (int)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				num3 = (int)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				num3 = ((IntPtr.Size != 4) ? ((int)(ulong)(long)((global::_0006_2002)obj2)._0002()) : ((int)(uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0002._0008((global::_0006)new global::_000F(num3));
		}
	}

	[global::_0003_200B(2)]
	private bool _0002([global::_0002_2007_2005(1)] MethodBase _0002, object _0008, ref object _0006, [global::_0002_2007_2005(new byte[] { 1, 2 })] object[] _000F)
	{
		Type declaringType = _0002.DeclaringType;
		Type type;
		if (3u != 0)
		{
			type = declaringType;
		}
		if (type == null)
		{
			return false;
		}
		if (global::_0002_2008._0002(type))
		{
			string name = _0002.Name;
			string text;
			if (4u != 0)
			{
				text = name;
			}
			if (text.Equals(global::_0008_0010._0002(-1463124081), StringComparison.Ordinal))
			{
				_0006 = _0008 != null;
			}
			else if (text.Equals(global::_0008_0010._0002(-1463124064), StringComparison.Ordinal))
			{
				if (_0008 == null)
				{
					return ((bool?)null).Value;
				}
				_0006 = _0008;
			}
			else if (text.Equals(global::_0008_0010._0002(-1463124912), StringComparison.Ordinal))
			{
				int num = _000F.Length;
				int num2;
				if (5u != 0)
				{
					num2 = num;
				}
				switch (num2)
				{
				case 0:
					_0006 = _0008;
					break;
				case 1:
					if (_0008 != null)
					{
						_0006 = _0008;
					}
					else
					{
						_0006 = _000F[0];
					}
					break;
				default:
					return false;
				}
			}
			else
			{
				if (_0008 != null || _0002.IsStatic)
				{
					return false;
				}
				_0006 = null;
			}
			return true;
		}
		if (type == global::_0006_2009.m__0002_2007)
		{
			string name2 = _0002.Name;
			string text2;
			if (5u != 0)
			{
				text2 = name2;
			}
			if (text2.Equals(global::_0008_0010._0002(-1463124920), StringComparison.Ordinal))
			{
				_0006 = global::_0002_2008._0003;
				return true;
			}
			if (this.m__0006_2001 != null && text2.Equals(global::_0008_0010._0002(-1463124891), StringComparison.Ordinal))
			{
				object[] array = this.m__0006_2001;
				object[] array2;
				if (5u != 0)
				{
					array2 = array;
				}
				int i;
				if (7u != 0)
				{
					i = 0;
				}
				for (; i < array2.Length; i++)
				{
					if (array2[i] is Assembly assembly)
					{
						_0006 = assembly;
						return true;
					}
				}
			}
		}
		else if (type == global::_0006_2009.m__0003_2003)
		{
			if (_0002.Name.Equals(global::_0008_0010._0002(-1463124964), StringComparison.Ordinal))
			{
				if (this.m__0006_2001 != null)
				{
					object[] array2 = this.m__0006_2001;
					for (int i = 0; i < array2.Length; i++)
					{
						if (array2[i] is MethodBase methodBase)
						{
							_0006 = methodBase;
							return true;
						}
					}
				}
				_0006 = MethodBase.GetCurrentMethod();
				return true;
			}
		}
		else if (type.IsArray && type.GetArrayRank() >= 2)
		{
			return this._0008(_0002, _0008, ref _0006, _000F);
		}
		return false;
	}

	private static void _0005_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_000F obj = (global::_000F)_0008;
		global::_000F obj2 = default(global::_000F);
		if (0 == 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = _0002._0002(obj2._0002());
		MethodBase methodBase2;
		if (2u != 0)
		{
			methodBase2 = methodBase;
		}
		global::_000F_2004_2005 obj3 = new global::_000F_2004_2005();
		obj3._0002(methodBase2);
		_0002._0008((global::_0006)obj3);
	}

	public static object _0002(Type _0002)
	{
		_ = 4;
		if (1 == 0)
		{
		}
		if (_0002.IsValueType)
		{
			_ = 8;
			if (4 == 0)
			{
			}
			return Activator.CreateInstance(_0002);
		}
		return null;
	}

	private static void _0005_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		if (_0005(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2 = default(uint);
			if (0 == 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static void _0008_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (uint.MaxValue != 0)
		{
			obj4 = obj3;
		}
		_0002._0008(_0002._0006(obj4, obj2));
	}

	[global::_0003_200B(2)]
	private bool _0008([global::_0002_2007_2005(1)] MethodBase _0002, object _0008, ref object _0006, [global::_0002_2007_2005(new byte[] { 1, 2 })] object[] _000F)
	{
		if (!_0002.IsStatic && _0008 != null && _0002.Name.Equals(global::_0008_0010._0002(-1463124693), StringComparison.Ordinal))
		{
			MethodInfo obj = _0002 as MethodInfo;
			MethodInfo methodInfo;
			if (true)
			{
				methodInfo = obj;
			}
			if ((object)methodInfo != null)
			{
				Type returnType = methodInfo.ReturnType;
				Type type;
				if (3u != 0)
				{
					type = returnType;
				}
				if (type.IsByRef)
				{
					Type elementType = type.GetElementType();
					if (5u != 0)
					{
						type = elementType;
					}
					int num = _000F.Length;
					if (num >= 1 && _000F[0] is int)
					{
						int[] array = new int[num];
						for (int i = 0; i < num; i++)
						{
							array[i] = (int)_000F[i];
						}
						global::_0008_200B obj2 = new global::_0008_200B();
						obj2._0002((Array)_0008);
						obj2._0002(array);
						obj2._0002(type);
						_0006 = obj2;
						return true;
					}
				}
			}
		}
		return false;
	}

	private static void _0003_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (false)
		{
		}
		_0002._0006(_0002: true);
	}

	private void _0003(int _0002)
	{
		global::_000F obj = new global::_000F(_0002);
		if (5u != 0)
		{
			_0008((global::_0006)obj);
		}
	}

	private void _0002(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		long num3;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				long num4 = ((global::_000F)obj2)._0002();
				if (3u != 0)
				{
					num3 = num4;
				}
			}
			else
			{
				num3 = ((global::_000F)obj2)._0002();
			}
			break;
		case 13:
			num3 = ((!_0002) ? ((global::_0003_2000)obj2)._0002() : ((global::_0003_2000)obj2)._0002());
			break;
		case 19:
			num3 = ((!_0002) ? ((long)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : checked((long)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			num3 = ((!_0002) ? ((long)((global::_0006_200A)obj2)._0002()) : checked((long)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			num3 = ((!_0002) ? ((long)((global::_0006_2002)obj2)._0002()) : ((long)((global::_0006_2002)obj2)._0002()));
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_0003_2000 obj3 = new global::_0003_2000();
		obj3._0002(num3);
		_0008((global::_0006)obj3);
	}

	private void _000E()
	{
		global::_0003_2005[] array = this.m__000E_2004;
		Comparison<global::_0003_2005> comparison = global::_0006_2009._0006_2004._0008;
		if (comparison == null)
		{
			comparison = global::_0006_2009._0006_2004._0002._0002;
			Comparison<global::_0003_2005> obj = comparison;
			if (3u != 0)
			{
				global::_0006_2009._0006_2004._0008 = obj;
			}
		}
		if (uint.MaxValue != 0)
		{
			_0002(array, comparison);
		}
	}

	private static void _0008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		_0002._0002(false);
	}

	private static void _0005_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (2 == 0)
		{
		}
		_0002._0002_2004(_0002: true);
	}

	private void _0002(ref _000E_2004 _0002, MethodBase _0008, bool _0006)
	{
		bool flag;
		if (8u != 0)
		{
			flag = false;
		}
		if (_0008.DeclaringType == typeof(Interlocked) && _0008.IsStatic)
		{
			string name = _0008.Name;
			string text;
			if (7u != 0)
			{
				text = name;
			}
			if (text == global::_0008_0010._0002(-1463124208) || text == global::_0008_0010._0002(-1463124198) || text == global::_0008_0010._0002(-1463124176) || text == global::_0008_0010._0002(-1463124192) || text == global::_0008_0010._0002(-1463124015) || text == global::_0008_0010._0002(-1463124031))
			{
				if (6u != 0)
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			try
			{
			}
			finally
			{
				Monitor.Enter(global::_0006_2009.m__0006_2003);
				_0002._0002 = true;
			}
		}
	}

	[Conditional("DEBUG")]
	private void _0008(object _0002)
	{
	}

	private void _0002(global::_0002_2004 _0002, global::_0006 _0008)
	{
		int num = ((global::_0006)_0002)._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 2:
			((global::_000F_2006)_0002)._0002()._0006_2008_2009_0002(_0008);
			break;
		case 23:
			this.m__0008_2009[((global::_0008_2004)_0002)._0002()]._0006_2008_2009_0002(_0008);
			break;
		case 18:
		{
			global::_000E_200B obj3 = (global::_000E_200B)_0002;
			global::_000E_200B obj4;
			if (4u != 0)
			{
				obj4 = obj3;
			}
			FieldInfo fieldInfo = obj4._0002();
			FieldInfo fieldInfo2;
			if (5u != 0)
			{
				fieldInfo2 = fieldInfo;
			}
			global::_0006 obj5 = global::_0006._0002(_0008._0006_2008_2009_0002(), fieldInfo2.FieldType);
			fieldInfo2.SetValue(obj4._0002(), obj5._0006_2008_2009_0002());
			global::_0002_2004 obj6 = obj4._0002();
			if (obj6 != null && fieldInfo2.DeclaringType.IsValueType)
			{
				this._0002(obj6, global::_0006._0002(obj4._0002(), null));
			}
			break;
		}
		case 11:
		case 24:
		{
			global::_0002_200B obj = (global::_0002_200B)_0002;
			global::_0006 obj2 = global::_0006._0002(_0008._0006_2008_2009_0002(), obj._0002());
			obj._0002_200B_2008_2009_0002(obj2._0006_2008_2009_0002());
			break;
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private static void _0006_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (6 == 0)
		{
		}
		_0002._0005(3);
	}

	private static void _000F(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (1 == 0)
		{
		}
		_0002._0006(typeof(int));
	}

	private static void _0005_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (4 == 0)
		{
		}
		_0002._0005();
	}

	private static void _0002_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (1 == 0)
		{
		}
		_0002._0006(typeof(double));
	}

	private static void _0008_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (5 == 0)
		{
		}
		if (_0002.m__0008_2007 == null)
		{
			throw new InvalidOperationException();
		}
		_ = 5;
		if (-1 == 0)
		{
		}
		_ = -1;
		if (1 == 0)
		{
		}
		_0002._0002(_0002.m__0008_2007);
	}

	private static void _0005_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		if (global::_0006_2009._0002(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2;
			if (3u != 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static void _0008(ILGenerator _0002, Type _0008)
	{
		if (_0008.IsValueType || global::_0002_2008._0002(_0008).IsGenericParameter)
		{
			_0002.Emit(OpCodes.Unbox_Any, _0008);
		}
		else if (0 == 0)
		{
			global::_0006_2009._0002(_0002, _0008);
		}
	}

	private static void _000F_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		global::_0002 obj = _0002._0002(num2);
		global::_0002 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		object obj3;
		if (obj2._0002() != 0)
		{
			obj3 = obj2._0002()._0005_2004_2008_2009_0002() switch
			{
				2 => _0002._0002(num2, _0008: true).TypeHandle, 
				0 => _0002._0002(num2).MethodHandle, 
				1 => _0002._0002(num2).FieldHandle, 
				_ => throw new InvalidOperationException(), 
			};
		}
		else
		{
			object obj4 = _0002._0002(obj2._0002());
			if (true)
			{
				obj3 = obj4;
			}
		}
		global::_0005_2003 obj5 = new global::_0005_2003();
		obj5._0002(obj3);
		_0002._0008((global::_0006)obj5);
	}

	private static void _0008_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006_200A obj = (global::_0006_200A)_0002._0002();
		global::_0006_200A obj2 = default(global::_0006_200A);
		if (0 == 0)
		{
			obj2 = obj;
		}
		if (double.IsNaN(obj2._0002()) || double.IsInfinity(obj2._0002()))
		{
			throw new OverflowException(global::_0008_0010._0002(-1463125081));
		}
		_0002._0008((global::_0006)obj2);
	}

	private static void _000E_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		object obj = _0002._0002()._0006_2008_2009_0002();
		object obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		long num = _0002._0002();
		long num2;
		if (3u != 0)
		{
			num2 = num;
		}
		Array obj3 = (Array)_0002._0002()._0006_2008_2009_0002();
		Array array;
		if (4u != 0)
		{
			array = obj3;
		}
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(short))
		{
			global::_0006 obj4 = global::_0006._0002(obj2, typeof(short));
			((short[])array)[num2] = (short)obj4._0006_2008_2009_0002();
		}
		else if (elementType == typeof(ushort))
		{
			global::_0006 obj5 = global::_0006._0002(obj2, typeof(ushort));
			((ushort[])array)[num2] = (ushort)obj5._0006_2008_2009_0002();
		}
		else if (elementType == typeof(char))
		{
			global::_0006 obj6 = global::_0006._0002(obj2, typeof(char));
			((char[])array)[num2] = (char)obj6._0006_2008_2009_0002();
		}
		else if (elementType.IsEnum)
		{
			_0002._0002(elementType, obj2, num2, array);
		}
		else
		{
			_0002._0002(typeof(short), obj2, num2, array);
		}
	}

	private void _0002()
	{
		uint num = this.m__0008_2004;
		if (6u != 0)
		{
			this.m__000F_2001 = num;
		}
		int num2 = this.m__000F_2007._0005();
		int key;
		if (3u != 0)
		{
			key = num2;
		}
		uint num3 = this.m__0008_2004 + 4;
		if (7u != 0)
		{
			this.m__0008_2004 = num3;
		}
		global::_0006_2009.m__0002_2003.TryGetValue(key, out var value);
		value._0008(this, _0002(this.m__000F_2007, value._0002));
	}

	private static void _0002(ILGenerator _0002, Type _0008)
	{
		_ = 5;
		if (7 == 0)
		{
		}
		if (!(_0008 == global::_0002_2008._0002))
		{
			_ = 5;
			if (7 == 0)
			{
			}
			OpCode castclass = OpCodes.Castclass;
			_ = 7;
			if (1 == 0)
			{
			}
			_0002.Emit(castclass, _0008);
		}
	}

	private static void _000E_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		if (!_0006(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2;
			if (3u != 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static void _0002_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (1 == 0)
		{
		}
		_ = -1;
		if (4 == 0)
		{
		}
		_0002._0002((int)((global::_0008_2004_2005)_0008)._0002());
	}

	private static void _000F_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (-1 == 0)
		{
		}
		_0002._0005();
	}

	private static void _0002_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		FieldInfo fieldInfo = _0002._0002(num2);
		FieldInfo fieldInfo2;
		if (6u != 0)
		{
			fieldInfo2 = fieldInfo;
		}
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		if (obj2 is global::_0002_2004 obj3)
		{
			obj2 = _0002._0002(obj3);
		}
		object obj4 = obj2._0006_2008_2009_0002();
		if (obj4 == null)
		{
			throw new NullReferenceException();
		}
		_0002._0008(global::_0006._0002(fieldInfo2.GetValue(obj4), fieldInfo2.FieldType));
	}

	private static void _000E_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (2 == 0)
		{
		}
		_0002._0003(5);
	}

	private static void _0006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2 = default(Type);
		if (0 == 0)
		{
			type2 = type;
		}
		global::_0002_2004 obj = (global::_0002_2004)_0002._0002();
		global::_0002_2004 obj2 = default(global::_0002_2004);
		if (0 == 0)
		{
			obj2 = obj;
		}
		if (type2.IsValueType)
		{
			object obj3 = _0002._0002(obj2)._0006_2008_2009_0002();
			if (global::_0002_2008._0002(type2))
			{
				global::_0002_2004 obj4 = obj2;
				global::_0005_2003 obj5 = new global::_0005_2003();
				((global::_0006)obj5)._0002(type2);
				_0002._0002(obj4, obj5);
				return;
			}
			FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				fieldInfo.SetValue(obj3, global::_0006_2009._0002(fieldInfo.FieldType));
			}
		}
		else
		{
			_0002._0002(obj2, new global::_0005_2003());
		}
	}

	private static void _0005_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (false)
		{
		}
		_ = 8;
		if (8 == 0)
		{
		}
		_0002._000F(_0008);
	}

	private void _0005(int _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		if (obj2 is global::_0002_2004)
		{
			this.m__0008_2009[_0002] = obj2;
		}
		else
		{
			this.m__0008_2009[_0002]._0006_2008_2009_0002(obj2);
		}
	}

	private void _0002(global::_0006 _0002)
	{
		if (((global::_000F)this._0002())._0002() != 0)
		{
			this.m__000F.Push(new _0008(this.m__0008_2004, this.m__0008_2007));
			if (5u != 0)
			{
				this.m__0005_2009 = false;
			}
		}
		if (2u != 0)
		{
			_0003();
		}
	}

	private global::_0006 _0002(global::_0002_2004 _0002)
	{
		int num = ((global::_0006)_0002)._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 2:
			return ((global::_000F_2006)_0002)._0002();
		case 23:
			return this.m__0008_2009[((global::_0008_2004)_0002)._0002()];
		case 18:
		{
			global::_000E_200B obj3 = (global::_000E_200B)_0002;
			global::_000E_200B obj4 = default(global::_000E_200B);
			if (0 == 0)
			{
				obj4 = obj3;
			}
			return global::_0006._0002(obj4._0002().GetValue(obj4._0002()), null);
		}
		case 11:
		case 24:
		{
			global::_0002_200B obj = (global::_0002_200B)_0002;
			global::_0002_200B obj2;
			if (7u != 0)
			{
				obj2 = obj;
			}
			return global::_0006._0002(obj2._0002_200B_2008_2009_0002(), obj2._0002());
		}
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void _000F()
	{
		if (5u != 0)
		{
			this.m__0003_2004 = true;
		}
	}

	private static global::_0003_2005 _0002(global::_0002_2004_2005 _0002)
	{
		global::_0003_2005 obj = new global::_0003_2005();
		_ = 4;
		if (6 == 0)
		{
		}
		obj._0008(_0002._0002());
		_ = 7;
		if (8 == 0)
		{
		}
		obj._0002(_0002._0005());
		_ = 3;
		if (3 == 0)
		{
		}
		obj._0002(_0002._0002());
		obj._0008(_0002._0002());
		obj._0006(_0002._0002());
		obj._000F(_0002._0002());
		return obj;
	}

	private static void _0008_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (8u != 0)
		{
			obj4 = obj3;
		}
		_0002._0008((global::_0006)new global::_000F(global::_0006_2009._0008(obj4, obj2) ? 1 : 0));
	}

	private static Exception _0006(string _0002, string _0008)
	{
		string text = global::_0008_0010._0002(-1463125880);
		_ = 8;
		if (3 == 0)
		{
		}
		string text2 = text + _0002 + global::_0008_0010._0002(-1463125844);
		string text3 = global::_0008_0010._0002(-1463123985);
		_ = 6;
		if (-1 == 0)
		{
		}
		return new FieldAccessException(global::_0006_2009._0002(text2, text3 + _0008 + global::_0008_0010._0002(-1463125844)));
	}

	private static void _000E_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (1 == 0)
		{
		}
		_ = 6;
		if (2 == 0)
		{
		}
		_0002._0002((int)((global::_0005_2007)_0008)._0002());
	}

	private static _0006 _0008(_0002 _0002)
	{
		Dictionary<_0002, _0006> dictionary = global::_0006_2009.m__0006;
		Dictionary<_0002, _0006> dictionary2;
		if (7u != 0)
		{
			dictionary2 = dictionary;
		}
		bool lockTaken;
		if (3u != 0)
		{
			lockTaken = false;
		}
		_0006 value;
		try
		{
			Dictionary<_0002, _0006> obj = dictionary2;
			if (8u != 0)
			{
				Monitor.Enter(obj, ref lockTaken);
			}
			global::_0006_2009.m__0006.TryGetValue(_0002, out value);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(dictionary2);
			}
		}
		if (value != null)
		{
			return value;
		}
		MethodBase methodBase = _0002._0002();
		lock (global::_0006_2009.m__0008_2001)
		{
			while (global::_0006_2009.m__0008_2001.ContainsKey(methodBase))
			{
				Monitor.Wait(global::_0006_2009.m__0008_2001);
			}
			global::_0006_2009.m__0008_2001[methodBase] = null;
		}
		try
		{
			lock (global::_0006_2009.m__0006)
			{
				global::_0006_2009.m__0006.TryGetValue(_0002, out value);
			}
			if (value == null)
			{
				value = global::_0006_2009._0002(methodBase, _0002._0002());
				lock (global::_0006_2009.m__0006)
				{
					global::_0006_2009.m__0006[_0002] = value;
				}
			}
			return value;
		}
		finally
		{
			lock (global::_0006_2009.m__0008_2001)
			{
				global::_0006_2009.m__0008_2001.Remove(methodBase);
				Monitor.PulseAll(global::_0006_2009.m__0008_2001);
			}
		}
	}

	private void _0006_2004(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		short num3;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				short num4 = checked((short)((global::_000F)obj2)._0002());
				if (2u != 0)
				{
					num3 = num4;
				}
			}
			else
			{
				short num5 = (short)((global::_000F)obj2)._0002();
				if (6u != 0)
				{
					num3 = num5;
				}
			}
			break;
		case 13:
			num3 = ((!_0002) ? ((short)((global::_0003_2000)obj2)._0002()) : checked((short)((global::_0003_2000)obj2)._0002()));
			break;
		case 19:
			num3 = ((!_0002) ? ((short)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : checked((short)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			num3 = ((!_0002) ? ((short)((global::_0006_200A)obj2)._0002()) : checked((short)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			num3 = ((IntPtr.Size != 4) ? ((!_0002) ? ((short)(long)((global::_0006_2002)obj2)._0002()) : checked((short)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((short)(int)((global::_0006_2002)obj2)._0002()) : checked((short)(int)((global::_0006_2002)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_000F obj3 = new global::_000F();
		obj3._0002(num3);
		_0008((global::_0006)obj3);
	}

	private static void _000E_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (7 == 0)
		{
		}
		_0002._0005(1);
	}

	private static void _0005_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		float num3;
		switch (num2)
		{
		case 1:
		{
			float num4 = ((global::_000F)obj2)._0002();
			if (7u != 0)
			{
				num3 = num4;
			}
			break;
		}
		case 13:
			num3 = ((global::_0003_2000)obj2)._0002();
			break;
		case 19:
			num3 = Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
			break;
		case 8:
			num3 = (float)((global::_0006_200A)obj2)._0002();
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_0006_200A obj3 = new global::_0006_200A();
		obj3._0002(num3);
		_0002._0008((global::_0006)obj3);
	}

	private static void _0003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (7 == 0)
		{
		}
		_0002._0002(3);
	}

	private static void _0003_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (8 == 0)
		{
		}
		_0002._0002(typeof(double));
	}

	private static byte[] _0002(global::_0002_2004_2005 _0002)
	{
		int num = _0002._0005();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		byte[] array = new byte[num2];
		byte[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		_0002._0002(array2, 0, num2);
		return array2;
	}

	private static void _0006_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		uint num = ((global::_000F_2001)_0008)._0002();
		uint num2;
		if (8u != 0)
		{
			num2 = num;
		}
		_0002._0002(num2);
	}

	private FieldInfo _0002(int _0002, global::_0002 _0008, ref bool _0006)
	{
		if (_0008._0002() == 0)
		{
			_0006 = false;
			return this.m__000E_2007.ResolveField(_0008._0002());
		}
		global::_0003_2004 obj = (global::_0003_2004)_0008._0002();
		global::_0003_2004 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		Type type = this._0002(obj2._0002()._0002(), _0008: false);
		if (type.IsGenericType)
		{
			_0006 = false;
		}
		BindingFlags num = global::_0006_2009._0002(obj2._0002());
		BindingFlags bindingAttr;
		if (true)
		{
			bindingAttr = num;
		}
		return type.GetField(obj2._0002(), bindingAttr);
	}

	private static void _0005_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (2 == 0)
		{
		}
		_ = 6;
		if (-1 == 0)
		{
		}
		_0002._0006(((global::_0008_2004_2005)_0008)._0002());
	}

	private static void _0002_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (3 == 0)
		{
		}
		_0002._000F(3);
	}

	private static void _000F_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (2 == 0)
		{
		}
		_0002._0003(2);
	}

	private static global::_0006 _0006(global::_0006 _0002, global::_0006 _0008, bool _0006)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				if (!_0006)
				{
					int num = ((global::_000F)_0002)._0002();
					int num2 = ((global::_000F)_0008)._0002();
					int num3;
					if (uint.MaxValue != 0)
					{
						num3 = num2;
					}
					return new global::_000F(num % num3);
				}
				int num4 = ((global::_000F)_0002)._0002();
				int num5 = ((global::_000F)_0008)._0002();
				uint num6;
				if (4u != 0)
				{
					num6 = (uint)num5;
				}
				return new global::_000F((int)((uint)num4 % num6));
			}
			if (_0008._0002() == 13)
			{
				return global::_0006_2009._0002((global::_0006)new global::_0003_2000(((global::_000F)_0002)._0002()), _0008, _0006);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type;
				if (uint.MaxValue != 0)
				{
					type = underlyingType;
				}
				if (type == typeof(long) || type == typeof(ulong))
				{
					return global::_0006_2009._0002((global::_0006)new global::_0003_2000(((global::_000F)_0002)._0002()), (global::_0006)new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006);
				}
				return global::_0006_2009._0006(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				return global::_0006_2009._0002(_0002, _0008, _0006);
			}
			if (_0008._0002() == 1)
			{
				return global::_0006_2009._0002(_0002, (global::_0006)new global::_0003_2000(((global::_000F)_0008)._0002()), _0006);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type2;
				if (5u != 0)
				{
					type2 = underlyingType2;
				}
				if (type2 == typeof(long) || type2 == typeof(ulong))
				{
					return global::_0006_2009._0002(_0002, (global::_0006)new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006);
				}
				return global::_0006_2009._0002(_0002, (global::_0006)new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006);
			}
		}
		if (_0002._0002() == 8 && _0008._0002() == 8)
		{
			global::_0006_200A obj = new global::_0006_200A();
			obj._0002(((global::_0006_200A)_0002)._0002() % ((global::_0006_200A)_0008)._0002());
			return obj;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			Type type3;
			if (7u != 0)
			{
				type3 = underlyingType3;
			}
			if (type3 == typeof(long) || type3 == typeof(ulong))
			{
				return global::_0006_2009._0006(new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008, _0006);
			}
			return global::_0006_2009._0006(new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008, _0006);
		}
		throw new InvalidOperationException();
	}

	private static bool _0008(global::_0006 _0002, global::_0006 _0008)
	{
		bool result;
		if (4u != 0)
		{
			result = false;
		}
		int num = _0002._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 1:
		{
			if (_0008._0002() == 19)
			{
				return global::_0006_2009._0008(_0002, (global::_0006)new global::_000F(Convert.ToInt32(((global::_0002_0010)_0008)._0002())));
			}
			bool num5 = ((global::_000F)_0002)._0002() > ((global::_000F)_0008)._0002();
			if (3u != 0)
			{
				result = num5;
			}
			break;
		}
		case 13:
			if (_0008._0002() == 19)
			{
				return global::_0006_2009._0008(_0002, (global::_0006)new global::_0003_2000(Convert.ToInt64(((global::_0002_0010)_0008)._0002())));
			}
			if (_0008._0002() == 1)
			{
				return global::_0006_2009._0008(_0002, (global::_0006)new global::_0003_2000(((global::_000F)_0008)._0002()));
			}
			result = ((global::_0003_2000)_0002)._0002() > ((global::_0003_2000)_0008)._0002();
			break;
		case 19:
			return global::_0006_2009._0008((global::_0006)new global::_0003_2000(Convert.ToInt64(((global::_0002_0010)_0002)._0002())), _0008);
		case 8:
		{
			double num3 = ((global::_0006_200A)_0002)._0002();
			double num4 = ((global::_0006_200A)_0008)._0002();
			result = !double.IsNaN(num3) && !double.IsNaN(num4) && num3 > num4;
			break;
		}
		}
		return result;
	}

	private global::_0006[] _0002()
	{
		global::_0005_2008[] array = this.m__0003._0002();
		global::_0005_2008[] array2;
		if (true)
		{
			array2 = array;
		}
		int num = array2.Length;
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		global::_0006[] array3 = new global::_0006[num2];
		global::_0006[] array4;
		if (3u != 0)
		{
			array4 = array3;
		}
		for (int i = 0; i < num2; i++)
		{
			array4[i] = global::_0006._0002(null, _0002(array2[i]._0002(), _0008: false));
		}
		return array4;
	}

	private static void _0008_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		object obj = _0002._0002()._0006_2008_2009_0002();
		object obj2 = default(object);
		if (0 == 0)
		{
			obj2 = obj;
		}
		long num = _0002._0002();
		long num2;
		if (5u != 0)
		{
			num2 = num;
		}
		Array obj3 = (Array)_0002._0002()._0006_2008_2009_0002();
		Array array;
		if (4u != 0)
		{
			array = obj3;
		}
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(sbyte))
		{
			global::_0006 obj4 = global::_0006._0002(obj2, typeof(sbyte));
			((sbyte[])array)[num2] = (sbyte)obj4._0006_2008_2009_0002();
		}
		else if (elementType == typeof(byte))
		{
			global::_0006 obj5 = global::_0006._0002(obj2, typeof(byte));
			((byte[])array)[num2] = (byte)obj5._0006_2008_2009_0002();
		}
		else if (elementType == typeof(bool))
		{
			global::_0006 obj6 = global::_0006._0002(obj2, typeof(bool));
			((bool[])array)[num2] = (bool)obj6._0006_2008_2009_0002();
		}
		else if (elementType.IsEnum)
		{
			_0002._0002(elementType, obj2, num2, array);
		}
		else
		{
			_0002._0002(typeof(sbyte), obj2, num2, array);
		}
	}

	private object _0002(Stream _0002, int _0008, object[] _0006, Type[] _000F, Type[] _0005, object[] _0003)
	{
		if (8u != 0)
		{
			this.m__000F_2004 = _0002;
		}
		long num = _0008;
		if (6u != 0)
		{
			this._0002(_0002, num, null);
		}
		return this._0002(_0006, _000F, _0005, _0003);
	}

	private static void _0006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		_0002._0008(_0002._0002(obj2));
	}

	private static void _0002_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (-1 == 0)
		{
		}
		_0002._0003(8);
	}

	private void _0002(bool _0002, bool _0008)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = this._0002();
		global::_0006 obj4;
		if (2u != 0)
		{
			obj4 = obj3;
		}
		global::_0006 obj5 = _0003(obj4, obj2, _0002, _0008);
		if (2u != 0)
		{
			this._0008(obj5);
		}
	}

	private static void _0003_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (6u != 0)
		{
			obj4 = obj3;
		}
		_0002._0008((global::_0006)new global::_000F(global::_0006_2009._0002(obj4, obj2) ? 1 : 0));
	}

	private bool _0002(MethodBase _0002, object _0008, global::_0006[] _0006, object[] _000F, bool _0005, ref object _0003)
	{
		Type declaringType = _0002.DeclaringType;
		Type type;
		if (2u != 0)
		{
			type = declaringType;
		}
		if (type == null)
		{
			return false;
		}
		if (type == global::_0006_2009.m__0005_2004 && _0002.Name == global::_0008_0010._0002(-1463124623) && _000F.Length == 2 && _0002.ToString() == global::_0008_0010._0002(-1463124633))
		{
			Array obj = (Array)_000F[0];
			RuntimeFieldHandle obj2 = (RuntimeFieldHandle)_000F[1];
			if (8u != 0)
			{
				global::_000E_2000._0002(obj, obj2);
			}
			return true;
		}
		return false;
	}

	private static void _0003_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (6 == 0)
		{
		}
		_0002._0005_2004(_0002: true);
	}

	private static void _0002(Exception _0002)
	{
		_ = 4;
		if (7 == 0)
		{
		}
		ExceptionDispatchInfo.Capture(_0002).Throw();
	}

	private void _000F(global::_0006 _0002)
	{
		int num = ((global::_000F)_0002)._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		MethodBase methodBase = this._0002(num2);
		MethodBase methodBase2;
		if (2u != 0)
		{
			methodBase2 = methodBase;
		}
		Type declaringType = methodBase2.DeclaringType;
		Type type;
		if (4u != 0)
		{
			type = declaringType;
		}
		ParameterInfo[] parameters = methodBase2.GetParameters();
		int num3 = parameters.Length;
		object[] array = new object[num3];
		Dictionary<int, global::_0002_2004> dictionary = new Dictionary<int, global::_0002_2004>();
		for (int num4 = num3 - 1; num4 >= 0; num4--)
		{
			global::_0006 obj = this._0002();
			if (obj is global::_0002_2004 obj2)
			{
				dictionary.Add(num4, obj2);
				obj = this._0002(obj2);
			}
			if (obj._0002() != null)
			{
				obj = global::_0006._0002(null, obj._0002())._0006_2008_2009_0002(obj);
			}
			global::_0006 obj3 = global::_0006._0002(null, parameters[num4].ParameterType)._0006_2008_2009_0002(obj);
			array[num4] = obj3._0006_2008_2009_0002();
		}
		object obj4;
		try
		{
			obj4 = _0008(methodBase2, null, array, _000F: false);
		}
		catch (TargetInvocationException ex)
		{
			Exception ex2 = ex.InnerException ?? ex;
			this._0002((object)ex2);
			return;
		}
		foreach (KeyValuePair<int, global::_0002_2004> item in dictionary)
		{
			this._0002(item.Value, global::_0006._0002(array[item.Key], null));
		}
		_0008(global::_0006._0002(obj4, type));
	}

	private static void _0003_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (2 == 0)
		{
		}
		_0002._0005(2);
	}

	private static void _000E_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (4u != 0)
		{
			obj4 = obj3;
		}
		bool flag;
		if (obj4._0002() == 8)
		{
			bool num = !global::_0006_2009._0008(obj4, obj2);
			if (true)
			{
				flag = num;
			}
		}
		else
		{
			flag = !_0005(obj4, obj2);
		}
		if (flag)
		{
			uint num2 = ((global::_000F_2001)_0008)._0002();
			_0002._0002(num2);
		}
	}

	private void _0002(object _0002)
	{
		Exception obj = _0002 as Exception;
		Exception ex;
		if (4u != 0)
		{
			ex = obj;
		}
		if (ex != null)
		{
			if (7u != 0)
			{
				global::_0006_2009._0002(ex);
			}
		}
		if (0 == 0)
		{
			global::_0006_2009._0002(_0002);
		}
	}

	private static bool _000F(global::_0006 _0002, global::_0006 _0008)
	{
		bool result;
		if (5u != 0)
		{
			result = false;
		}
		int num = _0002._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 1:
			if (_0008._0002() == 19)
			{
				bool num8 = ((global::_000F)_0002)._0002() == Convert.ToInt64(((global::_0002_0010)_0008)._0002());
				if (7u != 0)
				{
					result = num8;
				}
			}
			else if (_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null)
			{
				bool num9 = ((global::_000F)_0002)._0002() == 0;
				if (0 == 0)
				{
					result = num9;
				}
			}
			else
			{
				bool num10 = ((global::_000F)_0002)._0002() == ((global::_000F)_0008)._0002();
				if (5u != 0)
				{
					result = num10;
				}
			}
			break;
		case 13:
			if (_0008._0002() == 19)
			{
				bool num3 = ((global::_0003_2000)_0002)._0002() == Convert.ToInt64(((global::_0002_0010)_0008)._0002());
				if (true)
				{
					result = num3;
				}
			}
			else if (_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null)
			{
				bool num4 = ((global::_0003_2000)_0002)._0002() == 0;
				if (uint.MaxValue != 0)
				{
					result = num4;
				}
			}
			else
			{
				bool num5 = ((global::_0003_2000)_0002)._0002() == ((global::_0003_2000)_0008)._0002();
				if (5u != 0)
				{
					result = num5;
				}
			}
			break;
		case 0:
			if (_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null)
			{
				bool num6 = ((global::_0006_2002)_0002)._0002() == IntPtr.Zero;
				if (2u != 0)
				{
					result = num6;
				}
			}
			else if (_0008._0002() == 1)
			{
				bool num7 = ((global::_0006_2002)_0002)._0002() == new IntPtr(((global::_000F)_0008)._0002());
				if (true)
				{
					result = num7;
				}
			}
			else
			{
				result = ((_0008._0002() != 13) ? (((global::_0006_2002)_0002)._0002() == ((global::_0006_2002)_0008)._0002()) : (((global::_0006_2002)_0002)._0002() == new IntPtr(((global::_0003_2000)_0008)._0002())));
			}
			break;
		case 20:
			result = ((_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null) ? (((global::_0002_2003)_0002)._0002() == UIntPtr.Zero) : ((_0008._0002() != 1) ? ((_0008._0002() != 13) ? (((global::_0002_2003)_0002)._0002() == ((global::_0002_2003)_0008)._0002()) : (((global::_0002_2003)_0002)._0002() == new UIntPtr((ulong)((global::_0003_2000)_0008)._0002()))) : (((global::_0002_2003)_0002)._0002() == new UIntPtr((uint)((global::_000F)_0008)._0002()))));
			break;
		case 7:
			result = _0002._0006_2008_2009_0002() == _0008._0006_2008_2009_0002();
			break;
		case 25:
			result = (_0008._0002() != 7 || _0008._0006_2008_2009_0002() != null) && ((global::_000E_2005)_0002)._0002() == ((global::_000E_2005)_0008)._0002();
			break;
		case 19:
		{
			global::_0002_0010 obj8 = (global::_0002_0010)_0002;
			if (_0008._0002() == 19)
			{
				result = Convert.ToInt64(obj8._0002()) == Convert.ToInt64(((global::_0002_0010)_0008)._0002());
			}
			else if (obj8._0002() == null)
			{
				result = _0008._0006_2008_2009_0002() == null;
			}
			else if (_0008._0006_2008_2009_0002() != null)
			{
				result = Convert.ToInt64(obj8._0002()) == Convert.ToInt64(_0008._0006_2008_2009_0002());
			}
			break;
		}
		case 8:
		{
			double d = ((global::_0006_200A)_0002)._0002();
			double num11 = ((global::_0006_200A)_0008)._0002();
			result = !double.IsNaN(d) && !double.IsNaN(num11) && d.Equals(num11);
			break;
		}
		case 11:
		case 24:
		{
			global::_0002_200B obj6 = (global::_0002_200B)_0002;
			global::_0002_200B obj7 = (global::_0002_200B)_0008;
			result = obj6._0002_200B_2008_2009_0002(obj7);
			break;
		}
		case 18:
		{
			global::_000E_200B obj4 = (global::_000E_200B)_0002;
			global::_000E_200B obj5 = (global::_000E_200B)_0008;
			result = obj4._0002() == obj5._0002() && obj4._0002() == obj5._0002();
			break;
		}
		case 23:
		{
			global::_0008_2004 obj2 = (global::_0008_2004)_0002;
			global::_0008_2004 obj3 = (global::_0008_2004)_0008;
			result = obj2._0002() == obj3._0002();
			break;
		}
		case 2:
		{
			global::_000F_2006 obj = (global::_000F_2006)_0002;
			result = _000F(((global::_000F_2006)_0008)._0002(), obj._0002());
			break;
		}
		default:
			result = _0002._0006_2008_2009_0002() == _0008._0006_2008_2009_0002();
			break;
		}
		return result;
	}

	private static void _0002_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (8 == 0)
		{
		}
		_0002._0002(true);
	}

	private static object _0008(MethodBase _0002, object _0008, object[] _0006, bool _000F)
	{
		if (!global::_0006_2009._0003._0002)
		{
			_ = -1;
			if (-1 == 0)
			{
			}
			_ = 2;
			if (3 == 0)
			{
			}
			_ = 3;
			if (8 == 0)
			{
			}
			return global::_0006_2009._0002(_0002, _0008, _0006);
		}
		return global::_0006_2009._0002(_0002, _0008, _0006, _000F);
	}

	private static void _0002_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (2 == 0)
		{
		}
		_ = 0;
		if (false)
		{
		}
		_0002._0008(_0008);
	}

	private static void _000E_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_000F obj = (global::_000F)_0008;
		global::_000F obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = _0002._0002(obj2._0002());
		MethodBase methodBase2;
		if (8u != 0)
		{
			methodBase2 = methodBase;
		}
		_0002._0002(methodBase2, false);
	}

	private void _0002(int _0002, Type[] _0008, Type[] _0006, bool _000F)
	{
		this.m__0006_2004._0002()._0005_2008_2009_0002(_0002, 0);
		global::_0002_2004_2005 obj = this.m__0006_2004;
		if (8u != 0)
		{
			this._0002(obj);
		}
		global::_0003_2004_2005 obj2 = this._0002(this.m__0006_2004);
		global::_0003_2004_2005 obj3;
		if (7u != 0)
		{
			obj3 = obj2;
		}
		if (4u != 0)
		{
			this._0002(obj3);
		}
		int num = obj3._0002().Length;
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		object[] array = new object[num2];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		global::_0006[] array3 = new global::_0006[num2];
		global::_0006[] array4;
		if (2u != 0)
		{
			array4 = array3;
		}
		if (this.m__0005_2007 != null && _000F)
		{
			bool num3 = !obj3._0002();
			int num4;
			if (uint.MaxValue != 0)
			{
				num4 = (num3 ? 1 : 0);
			}
			Type[] array5 = new Type[num2 - num4];
			for (int num5 = num2 - 1; num5 >= num4; num5--)
			{
				array5[num5] = this._0002(obj3._0002()[num5]._0002(), _0008: true);
			}
			MethodInfo method = this.m__0005_2007.GetMethod(obj3._0002(), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array5, null);
			this.m__0005_2007 = null;
			if (method != null)
			{
				this._0002((MethodBase)method, true);
				return;
			}
		}
		for (int num6 = num2 - 1; num6 >= 0; num6--)
		{
			global::_0006 obj4 = (array4[num6] = this._0002());
			if (obj4 is global::_0002_2004 obj5)
			{
				obj4 = this._0002(obj5);
			}
			if (obj4._0002() != null)
			{
				obj4 = global::_0006._0002(null, obj4._0002())._0006_2008_2009_0002(obj4);
			}
			global::_0006 obj6 = global::_0006._0002(null, this._0002(obj3._0002()[num6]._0002(), _0008: true))._0006_2008_2009_0002(obj4);
			array2[num6] = obj6._0006_2008_2009_0002();
			if (num6 == 0 && _000F && !obj3._0002() && array2[num6] == null)
			{
				throw new NullReferenceException();
			}
		}
		global::_0006_2009 obj7 = new global::_0006_2009(this.m__0006_2009);
		object[] array6 = new object[1] { this.m__000E_2007.Assembly };
		object obj8;
		try
		{
			obj8 = obj7._0002(this.m__000F_2004, _0002, array2, _0008, _0006, array6);
		}
		finally
		{
			bool flag = !obj3._0002();
			for (int i = 0; i < num2; i++)
			{
				int num7;
				if (flag)
				{
					num7 = i + 1;
					if (num7 == num2)
					{
						num7 = 0;
					}
				}
				else
				{
					num7 = i;
				}
				if (array4[num7] is global::_0002_2004 obj9)
				{
					this._0002(obj9, global::_0006._0002(array2[num7], null));
				}
			}
		}
		Type type = obj7._0002(obj7.m__0003._0008(), _0008: true);
		if (type != global::_0006_2009.m__0003_2009)
		{
			this._0008(global::_0006._0002(obj8, type));
		}
	}

	private static void _0002_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		bool num3 = (num2 & int.MinValue) != 0;
		bool num4 = (num2 & 0x40000000) != 0;
		bool flag;
		if (true)
		{
			flag = num4;
		}
		int num5 = num2 & 0x3FFFFFFF;
		if (2u != 0)
		{
			num2 = num5;
		}
		if (num3)
		{
			_0002._0002(num2, null, null, flag);
			return;
		}
		global::_0002_200A obj = (global::_0002_200A)_0002._0002(num2)._0002();
		_0002._0002(obj);
	}

	private static void _0006(ILGenerator _0002, Type _0008)
	{
		_ = 8;
		if (7 == 0)
		{
		}
		if (!_0008.IsValueType)
		{
			_ = 3;
			if (4 == 0)
			{
			}
			if (!global::_0002_2008._0002(_0008).IsGenericParameter)
			{
				return;
			}
		}
		_ = 0;
		if (8 == 0)
		{
		}
		_0002.Emit(OpCodes.Box, _0008);
	}

	private static void _0006_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (7 == 0)
		{
		}
		_0002._0005();
	}

	private bool _0002(global::_0006 _0002, Type _0008)
	{
		object obj = _0002._0006_2008_2009_0002();
		object obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		if (obj2 == null)
		{
			return true;
		}
		Type obj3 = _0002._0002() ?? obj2.GetType();
		Type type = default(Type);
		if (0 == 0)
		{
			type = obj3;
		}
		if (type == _0008 || _0008.IsAssignableFrom(type))
		{
			return true;
		}
		if (!type.IsValueType && !_0008.IsValueType)
		{
			if (Marshal.IsComObject(obj2))
			{
				IntPtr zero = IntPtr.Zero;
				IntPtr intPtr;
				if (true)
				{
					intPtr = zero;
				}
				try
				{
					intPtr = Marshal.GetComInterfaceForObject(obj2, _0008);
				}
				catch (ArgumentException)
				{
				}
				catch (InvalidCastException)
				{
				}
				if (intPtr != IntPtr.Zero)
				{
					try
					{
						Marshal.Release(intPtr);
					}
					catch
					{
					}
					return true;
				}
			}
			else if (global::_0006_2009._0002(obj2))
			{
				return true;
			}
		}
		return false;
	}

	private static bool _0008()
	{
		return false;
	}

	private void _0002(_000F_2004 _0002)
	{
		global::_0002_2004_2005 obj = _0002._0008;
		if (8u != 0)
		{
			this.m__000F_2007 = obj;
		}
		long num = _0002._000F;
		if (uint.MaxValue != 0)
		{
			this.m__0002_2004 = num;
		}
	}

	private string _0002(global::_0003_2004_2005 _0002)
	{
		Type type = this._0002(_0002._0002(), _0008: false);
		Type type2;
		if (5u != 0)
		{
			type2 = type;
		}
		global::_0002_2006[] array = _0002._0002();
		global::_0002_2006[] array2;
		if (5u != 0)
		{
			array2 = array;
		}
		string[] array3 = new string[array2.Length];
		string[] array4;
		if (7u != 0)
		{
			array4 = array3;
		}
		for (int i = 0; i < array2.Length; i++)
		{
			array4[i] = this._0002(array2[i]._0002(), _0008: false)?.FullName;
		}
		string text = string.Join(global::_0008_0010._0002(-1463125730), array4);
		return type2.FullName + global::_0008_0010._0002(-1463125804) + _0002._0002() + global::_0008_0010._0002(-1463125751) + text + global::_0008_0010._0002(-1463125711);
	}

	private static void _0003_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (false)
		{
		}
		_ = 1;
		if (3 == 0)
		{
		}
		_0002._000F(((global::_0005_2007)_0008)._0002());
	}

	private static bool _0005(global::_0006 _0002, global::_0006 _0008)
	{
		bool flag;
		if (8u != 0)
		{
			flag = false;
		}
		int num = _0002._0002();
		int num2;
		if (true)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 1:
		{
			bool result2 = (uint)((global::_000F)_0002)._0002() > (uint)((global::_000F)_0008)._0002();
			if (8 == 0)
			{
				break;
			}
			return result2;
		}
		case 13:
		{
			bool result = (ulong)((global::_0003_2000)_0002)._0002() > (ulong)((global::_0003_2000)_0008)._0002();
			if (3 == 0)
			{
				break;
			}
			return result;
		}
		case 8:
		{
			double num5 = ((global::_0006_200A)_0002)._0002();
			double num6;
			if (8u != 0)
			{
				num6 = num5;
			}
			double num7 = ((global::_0006_200A)_0008)._0002();
			return num6 > num7 || double.IsNaN(num6) || double.IsNaN(num7);
		}
		case 0:
			if (_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null)
			{
				return ((global::_0006_2002)_0002)._0002() != IntPtr.Zero;
			}
			return ((global::_0006_2002)_0002)._0002() != ((global::_0006_2002)_0008)._0002();
		case 20:
			if (_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null)
			{
				return ((global::_0002_2003)_0002)._0002() != UIntPtr.Zero;
			}
			return ((global::_0002_2003)_0002)._0002() != ((global::_0002_2003)_0008)._0002();
		case 7:
			return ((global::_0005_2003)_0002)._0002() != ((global::_0005_2003)_0008)._0002();
		case 25:
			if (_0008._0002() == 7 && _0008._0006_2008_2009_0002() == null)
			{
				return true;
			}
			return ((global::_000E_2005)_0002)._0002() != ((global::_000E_2005)_0008)._0002();
		case 19:
		{
			long num3 = Convert.ToInt64(((global::_0002_0010)_0002)._0002());
			long num4 = ((_0008._0002() != 1) ? Convert.ToInt64(((global::_0002_0010)_0008)._0002()) : ((global::_000F)_0008)._0002());
			return num3 > num4;
		}
		default:
			return _0002._0006_2008_2009_0002() != _0008._0006_2008_2009_0002();
		}
		return flag;
	}

	public object _0002(Stream _0002, string _0008, object[] _0006)
	{
		_ = 8;
		if (3 == 0)
		{
		}
		_ = 6;
		if (4 == 0)
		{
		}
		_ = -1;
		if (5 == 0)
		{
		}
		return this._0002(_0002, _0008, _0006, null, null, null);
	}

	private static void _0008_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (6u != 0)
		{
			type2 = type;
		}
		global::_0006 obj = global::_0006._0002(_0002._0002()._0006_2008_2009_0002(), type2);
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		obj2._0002(type2);
		_0002._0008(obj2);
	}

	private static void _0003_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		object obj = _0002._0002()._0006_2008_2009_0002();
		object obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		long num = _0002._0002();
		long num2;
		if (8u != 0)
		{
			num2 = num;
		}
		Array obj3 = (Array)_0002._0002()._0006_2008_2009_0002();
		Array array;
		if (3u != 0)
		{
			array = obj3;
		}
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(long))
		{
			global::_0006 obj4 = global::_0006._0002(obj2, typeof(long));
			((long[])array)[num2] = (long)obj4._0006_2008_2009_0002();
		}
		else if (elementType == typeof(ulong))
		{
			global::_0006 obj5 = global::_0006._0002(obj2, typeof(ulong));
			((ulong[])array)[num2] = (ulong)obj5._0006_2008_2009_0002();
		}
		else if (elementType.IsEnum)
		{
			_0002._0002(elementType, obj2, num2, array);
		}
		else
		{
			_0002._0002(typeof(long), obj2, num2, array);
		}
	}

	private static bool _0006(global::_0006 _0002, global::_0006 _0008)
	{
		bool result;
		if (2u != 0)
		{
			result = false;
		}
		int num = _0002._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 1:
		{
			if (_0008._0002() == 19)
			{
				return _0006(_0002, (global::_0006)new global::_000F(Convert.ToInt32(((global::_0002_0010)_0008)._0002())));
			}
			bool num3 = ((global::_000F)_0002)._0002() < ((global::_000F)_0008)._0002();
			if (8u != 0)
			{
				result = num3;
			}
			break;
		}
		case 13:
			if (_0008._0002() == 19)
			{
				return _0006(_0002, (global::_0006)new global::_0003_2000(Convert.ToInt64(((global::_0002_0010)_0008)._0002())));
			}
			if (_0008._0002() == 1)
			{
				return _0006(_0002, (global::_0006)new global::_0003_2000(((global::_000F)_0008)._0002()));
			}
			result = ((global::_0003_2000)_0002)._0002() < ((global::_0003_2000)_0008)._0002();
			break;
		case 19:
			return _0006((global::_0006)new global::_0003_2000(Convert.ToInt64(((global::_0002_0010)_0002)._0002())), _0008);
		case 8:
			result = ((global::_0006_200A)_0002)._0002() < ((global::_0006_200A)_0008)._0002();
			break;
		}
		return result;
	}

	private static void _0008_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		_0002._0008(_0002._0008(obj2));
	}

	private void _0008(int _0002)
	{
		global::_0008_2004 obj = new global::_0008_2004();
		obj._0002(_0002);
		if (4u != 0)
		{
			_0008((global::_0006)obj);
		}
	}

	private static void _0002_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		_0002._0006(global::_0006_2009.m__0005);
	}

	private static void _0005_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (3 == 0)
		{
		}
		_0002._0008(_0002: true, _0008: true);
	}

	private bool _0002()
	{
		_ = 0;
		if (6 == 0)
		{
		}
		if (this.m__000E == null)
		{
			_ = -1;
			if (7 == 0)
			{
			}
			return this.m__0002_2009.Count != 0;
		}
		return true;
	}

	private void _0005_2004(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (true)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		byte b;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				byte num3 = checked((byte)(uint)((global::_000F)obj2)._0002());
				if (7u != 0)
				{
					b = num3;
				}
			}
			else
			{
				byte num4 = (byte)((global::_000F)obj2)._0002();
				if (4u != 0)
				{
					b = num4;
				}
			}
			break;
		case 13:
			if (_0002)
			{
				byte num5 = checked((byte)(ulong)((global::_0003_2000)obj2)._0002());
				if (4u != 0)
				{
					b = num5;
				}
			}
			else
			{
				b = (byte)((global::_0003_2000)obj2)._0002();
			}
			break;
		case 19:
			b = ((!_0002) ? ((byte)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : checked((byte)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			b = ((!_0002) ? ((byte)((global::_0006_200A)obj2)._0002()) : checked((byte)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			b = ((IntPtr.Size != 4) ? ((!_0002) ? ((byte)(long)((global::_0006_2002)obj2)._0002()) : checked((byte)(ulong)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((byte)(int)((global::_0006_2002)obj2)._0002()) : checked((byte)(int)((global::_0006_2002)obj2)._0002())));
			break;
		case 20:
			b = ((UIntPtr.Size != 4) ? ((!_0002) ? ((byte)(ulong)((global::_0002_2003)obj2)._0002()) : checked((byte)(ulong)((global::_0002_2003)obj2)._0002())) : ((!_0002) ? ((byte)(uint)((global::_0002_2003)obj2)._0002()) : checked((byte)(uint)((global::_0002_2003)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0008((global::_0006)new global::_000F(b));
	}

	private global::_0003_2004_2005 _0002(global::_0002_2004_2005 _0002)
	{
		global::_0003_2004_2005 obj = new global::_0003_2004_2005();
		_ = 2;
		if (8 == 0)
		{
		}
		_ = 3;
		if (false)
		{
		}
		obj._0002(this._0002(_0002));
		_ = 6;
		if (5 == 0)
		{
		}
		obj._0002(this._0002(_0002));
		obj._0008(_0002._0005());
		obj._0002(_0002._0002());
		obj._0002(_0002._0005());
		obj._0002(_0002._0002());
		return obj;
	}

	private static _0006 _0002(MethodBase _0002, bool _0008)
	{
		DynamicMethod dynamicMethod;
		if (7u != 0)
		{
			dynamicMethod = null;
		}
		if (dynamicMethod == null)
		{
			DynamicMethod dynamicMethod2 = new DynamicMethod(string.Empty, global::_0002_2008._0002, new Type[2]
			{
				global::_0002_2008._0002,
				global::_0006_2009.m__000E_2003
			}, typeof(global::_0006_2009).Module, skipVisibility: true);
			if (4u != 0)
			{
				dynamicMethod = dynamicMethod2;
			}
		}
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		ILGenerator iLGenerator2;
		if (6u != 0)
		{
			iLGenerator2 = iLGenerator;
		}
		ParameterInfo[] parameters = _0002.GetParameters();
		ParameterInfo[] array;
		if (2u != 0)
		{
			array = parameters;
		}
		Type[] array2 = new Type[array.Length];
		Type[] array3;
		if (6u != 0)
		{
			array3 = array2;
		}
		bool flag;
		if (7u != 0)
		{
			flag = false;
		}
		int i;
		if (8u != 0)
		{
			i = 0;
		}
		for (; i < array.Length; i++)
		{
			Type parameterType = array[i].ParameterType;
			Type type;
			if (8u != 0)
			{
				type = parameterType;
			}
			if (type.IsByRef)
			{
				if (6u != 0)
				{
					flag = true;
				}
				type = type.GetElementType();
			}
			array3[i] = type;
		}
		LocalBuilder[] array4 = new LocalBuilder[array3.Length];
		if (array4.Length != 0)
		{
			dynamicMethod.InitLocals = true;
		}
		for (int j = 0; j < array3.Length; j++)
		{
			array4[j] = iLGenerator2.DeclareLocal(array3[j]);
		}
		for (int k = 0; k < array3.Length; k++)
		{
			iLGenerator2.Emit(OpCodes.Ldarg_1);
			global::_0006_2009._0002(iLGenerator2, k);
			iLGenerator2.Emit(OpCodes.Ldelem_Ref);
			global::_0006_2009._0008(iLGenerator2, array3[k]);
			iLGenerator2.Emit(OpCodes.Stloc, array4[k]);
		}
		if (flag)
		{
			iLGenerator2.BeginExceptionBlock();
		}
		if (!_0002.IsStatic && !_0002.IsConstructor)
		{
			iLGenerator2.Emit(OpCodes.Ldarg_0);
			Type declaringType = _0002.DeclaringType;
			if (declaringType.IsValueType)
			{
				iLGenerator2.Emit(OpCodes.Unbox, declaringType);
				_0008 = false;
			}
			else
			{
				global::_0006_2009._0002(iLGenerator2, declaringType);
			}
		}
		for (int l = 0; l < array3.Length; l++)
		{
			if (array[l].ParameterType.IsByRef)
			{
				iLGenerator2.Emit(OpCodes.Ldloca_S, array4[l]);
			}
			else
			{
				iLGenerator2.Emit(OpCodes.Ldloc, array4[l]);
			}
		}
		if (_0002.IsConstructor)
		{
			iLGenerator2.Emit(OpCodes.Newobj, (ConstructorInfo)_0002);
			_0006(iLGenerator2, _0002.DeclaringType);
		}
		else
		{
			MethodInfo methodInfo = (MethodInfo)_0002;
			if (!_0008 || _0002.IsStatic)
			{
				iLGenerator2.EmitCall(OpCodes.Call, methodInfo, null);
			}
			else
			{
				iLGenerator2.EmitCall(OpCodes.Callvirt, methodInfo, null);
			}
			if (methodInfo.ReturnType == global::_0006_2009.m__0003_2009)
			{
				iLGenerator2.Emit(OpCodes.Ldnull);
			}
			else
			{
				_0006(iLGenerator2, methodInfo.ReturnType);
			}
		}
		if (flag)
		{
			LocalBuilder local = iLGenerator2.DeclareLocal(global::_0002_2008._0002);
			iLGenerator2.Emit(OpCodes.Stloc, local);
			iLGenerator2.BeginFinallyBlock();
			for (int m = 0; m < array3.Length; m++)
			{
				if (array[m].ParameterType.IsByRef)
				{
					iLGenerator2.Emit(OpCodes.Ldarg_1);
					global::_0006_2009._0002(iLGenerator2, m);
					iLGenerator2.Emit(OpCodes.Ldloc, array4[m]);
					if (array4[m].LocalType.IsValueType || global::_0002_2008._0002(array4[m].LocalType).IsGenericParameter)
					{
						iLGenerator2.Emit(OpCodes.Box, array4[m].LocalType);
					}
					iLGenerator2.Emit(OpCodes.Stelem_Ref);
				}
			}
			iLGenerator2.EndExceptionBlock();
			iLGenerator2.Emit(OpCodes.Ldloc, local);
		}
		iLGenerator2.Emit(OpCodes.Ret);
		return (_0006)dynamicMethod.CreateDelegate(typeof(_0006));
	}

	private global::_0002_2006[] _0002(global::_0002_2004_2005 _0002)
	{
		global::_0002_2006[] array = new global::_0002_2006[_0002._0002()];
		global::_0002_2006[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		int num;
		if (6u != 0)
		{
			num = 0;
		}
		while (num < array2.Length)
		{
			array2[num] = this._0002(_0002);
			int num2 = num + 1;
			if (6u != 0)
			{
				num = num2;
			}
		}
		return array2;
	}

	private static object _0002(MethodBase _0002, object _0008, object[] _0006)
	{
		if (_0002.IsConstructor)
		{
			try
			{
				object result = Activator.CreateInstance(_0002.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0006, null);
				if (uint.MaxValue != 0)
				{
					return result;
				}
			}
			catch (AmbiguousMatchException)
			{
				object result2 = ((ConstructorInfo)_0002).Invoke(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, _0006, null);
				if (8u != 0)
				{
					return result2;
				}
			}
			object result3;
			return result3;
		}
		return _0002.Invoke(_0008, _0006);
	}

	private static void _000F_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (2 == 0)
		{
		}
		_0002._0008(_0002: true);
	}

	private static void _0008_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (3 == 0)
		{
		}
		_0002._0006(typeof(uint));
	}

	private static void _000F_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (true)
		{
			type2 = type;
		}
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (true)
		{
			obj2 = obj;
		}
		if (_0002._0002(obj2, type2))
		{
			_0002._0008(obj2);
			return;
		}
		throw new InvalidCastException();
	}

	private static void _0008_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (-1 == 0)
		{
		}
		_ = 0;
		if (false)
		{
		}
		_0002._0008(_0008);
	}

	private void _0005(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		sbyte b;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				sbyte num3 = checked((sbyte)((global::_000F)obj2)._0002());
				if (4u != 0)
				{
					b = num3;
				}
			}
			else
			{
				sbyte num4 = (sbyte)((global::_000F)obj2)._0002();
				if (2u != 0)
				{
					b = num4;
				}
			}
			break;
		case 13:
			b = ((!_0002) ? ((sbyte)((global::_0003_2000)obj2)._0002()) : checked((sbyte)((global::_0003_2000)obj2)._0002()));
			break;
		case 19:
			b = ((!_0002) ? ((sbyte)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : checked((sbyte)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			b = ((!_0002) ? ((sbyte)((global::_0006_200A)obj2)._0002()) : checked((sbyte)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			b = ((IntPtr.Size != 4) ? ((!_0002) ? ((sbyte)(long)((global::_0006_2002)obj2)._0002()) : checked((sbyte)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((sbyte)(int)((global::_0006_2002)obj2)._0002()) : checked((sbyte)(int)((global::_0006_2002)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_000F obj3 = new global::_000F();
		obj3._0002(b);
		_0008((global::_0006)obj3);
	}

	private static void _0008_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (6u != 0)
		{
			type2 = type;
		}
		_0002._0008(type2);
	}

	private static void _0008_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		Type elementType = _0002._0002(num2, _0008: true);
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		global::_000F obj3 = obj2 as global::_000F;
		global::_000F obj4;
		if (7u != 0)
		{
			obj4 = obj3;
		}
		int length;
		if (obj4 != null)
		{
			length = obj4._0002();
		}
		else if (obj2 is global::_0006_2002 obj5)
		{
			length = obj5._0002().ToInt32();
		}
		else
		{
			if (!(obj2 is global::_0002_2003 obj6))
			{
				throw new Exception();
			}
			length = (int)obj6._0002().ToUInt32();
		}
		Array array = Array.CreateInstance(elementType, length);
		global::_0006_2004 obj7 = new global::_0006_2004();
		obj7._0002(array);
		_0002._0008((global::_0006)obj7);
	}

	private static void _0003_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (1 == 0)
		{
		}
		_ = 4;
		if (6 == 0)
		{
		}
		_0002._0008(_0008);
	}

	private static void _000F_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (4 == 0)
		{
		}
		_0002._0006(typeof(short));
	}

	private static void _0003_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type t;
		if (6u != 0)
		{
			t = type;
		}
		_0002._0008((global::_0006)new global::_000F(Marshal.SizeOf(t)));
	}

	private static void _0002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (8 == 0)
		{
		}
		_0002._0006_2004(_0002: false);
	}

	private static void _0005_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		object obj = _0002._0002()._0006_2008_2009_0002();
		object obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		long num = _0002._0002();
		long num2 = default(long);
		if (0 == 0)
		{
			num2 = num;
		}
		Array obj3 = (Array)_0002._0002()._0006_2008_2009_0002();
		Array array;
		if (4u != 0)
		{
			array = obj3;
		}
		Type elementType = array.GetType().GetElementType();
		if (elementType == typeof(int))
		{
			global::_0006 obj4 = global::_0006._0002(obj2, typeof(int));
			((int[])array)[num2] = (int)obj4._0006_2008_2009_0002();
		}
		else if (elementType == typeof(uint))
		{
			global::_0006 obj5 = global::_0006._0002(obj2, typeof(uint));
			((uint[])array)[num2] = (uint)obj5._0006_2008_2009_0002();
		}
		else if (elementType.IsEnum)
		{
			_0002._0002(elementType, obj2, num2, array);
		}
		else
		{
			_0002._0002(typeof(int), obj2, num2, array);
		}
	}

	private static void _0002_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		if (6u != 0)
		{
			bool flag = false;
		}
		int num = obj2._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		if (num2 switch
		{
			1 => ((global::_000F)obj2)._0002() == 0, 
			13 => ((global::_0003_2000)obj2)._0002() == 0, 
			0 => ((global::_0006_2002)obj2)._0002() == IntPtr.Zero, 
			20 => ((global::_0002_2003)obj2)._0002() == UIntPtr.Zero, 
			7 => ((global::_0005_2003)obj2)._0002() == null, 
			19 => !Convert.ToBoolean(((global::_0002_0010)obj2)._0002()), 
			_ => obj2._0006_2008_2009_0002() == null, 
		})
		{
			uint num3 = ((global::_000F_2001)_0008)._0002();
			_0002._0002(num3);
		}
	}

	public void _0002(Stream _0002, string _0008, object[] _0006)
	{
		_ = 6;
		if (7 == 0)
		{
		}
		_ = 2;
		if (4 == 0)
		{
		}
		_ = 2;
		if (2 == 0)
		{
		}
		this._0002(_0002, _0008, _0006);
	}

	private static void _0005_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (6 == 0)
		{
		}
		_0002._0006(typeof(sbyte));
	}

	private static void _0006_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		if (obj._0002() != 1)
		{
			throw new InvalidOperationException();
		}
		int num = ((global::_000F)obj)._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		Stack<_000F_2004> stack = _0002._0002();
		Stack<_000F_2004> stack2;
		if (7u != 0)
		{
			stack2 = stack;
		}
		if (stack2.Count < 2)
		{
			throw new InvalidOperationException();
		}
		_000F_2004 obj2 = stack2.Pop();
		_000F_2004 obj3;
		if (4u != 0)
		{
			obj3 = obj2;
		}
		try
		{
			if (obj3 == null || obj3._0002._000E_2004_2008_2009_0002() != num2)
			{
				throw new InvalidOperationException();
			}
			_000F_2004 obj4 = stack2.Peek();
			_0002._0002(obj4);
			_0002.m__0008_2004 += (uint)obj3._0002._0002();
			_0002._0002((long)_0002.m__0008_2004);
		}
		finally
		{
			((IDisposable)obj3)?.Dispose();
		}
	}

	private Type _0002(int _0002, global::_0002 _0008, ref bool _0006, bool _000F)
	{
		if (_0008._0002() == 0)
		{
			return this.m__000E_2007.ResolveType(_0008._0002());
		}
		global::_0005_2002 obj = (global::_0005_2002)_0008._0002();
		global::_0005_2002 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		Type type;
		if (5u != 0)
		{
			type = null;
		}
		if (obj2._0002())
		{
			if (obj2._0008() != -1)
			{
				if (this.m__0005_2003 == null)
				{
					throw new InvalidOperationException(global::_0008_0010._0002(-1463124785));
				}
				Type type2 = this.m__0005_2003[obj2._0008()];
				if (true)
				{
					type = type2;
				}
			}
			else
			{
				if (obj2._0002() == -1)
				{
					throw new Exception();
				}
				if (this.m__000F_2003 == null)
				{
					throw new InvalidOperationException(global::_0008_0010._0002(-1463124738));
				}
				Type type3 = this.m__000F_2003[obj2._0002()];
				if (8u != 0)
				{
					type = type3;
				}
			}
			Stack<global::_000E_2002> stack = global::_0002_2008._0002(obj2._0002());
			Stack<global::_000E_2002> stack2;
			if (8u != 0)
			{
				stack2 = stack;
			}
			Type type4 = global::_0002_2008._0002(type, stack2);
			if (2u != 0)
			{
				type = type4;
			}
			_0006 = false;
			return type;
		}
		string text = obj2._0002();
		string text2;
		if (true)
		{
			text2 = text;
		}
		try
		{
			Type type5 = Type.GetType(text2);
			if (0 == 0)
			{
				type = type5;
			}
		}
		catch (BadImageFormatException)
		{
		}
		if (type == null)
		{
			int num = text2.IndexOf(',');
			string text3 = text2.Substring(0, num);
			string text4 = text2.Substring(num + 1).Trim();
			Assembly assembly = global::_0002_2008._0003;
			if (text4.Equals(assembly.FullName, StringComparison.OrdinalIgnoreCase))
			{
				type = ((!text3.Equals(global::_0008_0010._0002(-1463124847), StringComparison.Ordinal)) ? assembly.GetType(text3) : global::_0006_2009.m__000F_2009);
			}
			else
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly2 in assemblies)
				{
					string value = null;
					try
					{
						value = assembly2.Location;
					}
					catch (NotSupportedException)
					{
					}
					if (string.IsNullOrEmpty(value) && assembly2.FullName.Equals(text4, StringComparison.OrdinalIgnoreCase))
					{
						type = assembly2.GetType(text3);
						if (type != null)
						{
							break;
						}
					}
				}
			}
			if (type == null && text3.StartsWith(global::_0008_0010._0002(-1463124834), StringComparison.Ordinal) && text3.Contains(global::_0008_0010._0002(-1463125804)))
			{
				try
				{
					Type[] types = Assembly.Load(text4).GetTypes();
					foreach (Type type6 in types)
					{
						if (type6.FullName == text3)
						{
							type = type6;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if (type == null)
		{
			throw new TypeLoadException(string.Format(global::_0008_0010._0002(-1463124828), text2));
		}
		if (obj2._0008())
		{
			if (obj2._0002().Length != 0)
			{
				Type[] array = new Type[obj2._0002().Length];
				for (int j = 0; j < obj2._0002().Length; j++)
				{
					array[j] = this._0002(obj2._0002()[j]._0002(), _000F);
				}
				Type genericTypeDefinition = global::_0002_2008._0002(type).GetGenericTypeDefinition();
				Stack<global::_000E_2002> stack3 = global::_0002_2008._0002(type);
				type = genericTypeDefinition.MakeGenericType(array);
				type = global::_0002_2008._0002(type, stack3);
			}
			_0006 = false;
		}
		return type;
	}

	private void _0008_2004()
	{
		if (8u != 0)
		{
			this.m__000E = null;
		}
		if (2u != 0)
		{
			this.m__0002 = null;
		}
		this.m__0002_2009.Clear();
	}

	private static void _000F_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
	}

	private static void _0005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		MethodBase methodBase = ((global::_000F_2004_2005)_0002._0002())._0002();
		MethodBase methodBase2;
		if (7u != 0)
		{
			methodBase2 = methodBase;
		}
		_0002._0002(methodBase2, false);
	}

	private global::_0006 _0008(global::_0006 _0002)
	{
		if (_0002._0002() == 1)
		{
			int num = ((global::_000F)_0002)._0002();
			int num2;
			if (8u != 0)
			{
				num2 = num;
			}
			global::_000F obj = new global::_000F();
			obj._0002(~num2);
			return obj;
		}
		if (_0002._0002() == 13)
		{
			long num3 = ((global::_0003_2000)_0002)._0002();
			long num4;
			if (2u != 0)
			{
				num4 = num3;
			}
			global::_0003_2000 obj2 = new global::_0003_2000();
			obj2._0002(~num4);
			return obj2;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			Type type = default(Type);
			if (0 == 0)
			{
				type = underlyingType;
			}
			if (type == typeof(long) || type == typeof(ulong))
			{
				return new global::_0003_2000(~Convert.ToInt64(_0002._0006_2008_2009_0002()));
			}
			return new global::_000F(~Convert.ToInt32(_0002._0006_2008_2009_0002()));
		}
		throw new InvalidOperationException();
	}

	private void _000F(int _0002)
	{
		global::_0006 obj = this.m__0008_2003[_0002]._0006_2008_2009_0002();
		if (0 == 0)
		{
			_0008(obj);
		}
	}

	private static void _0005_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (8 == 0)
		{
		}
		_ = 5;
		if (-1 == 0)
		{
		}
		_0002._0008(((global::_0005_2007)_0008)._0002());
	}

	private static void _0006_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (true)
		{
			num2 = num;
		}
		uint num3;
		checked
		{
			switch (num2)
			{
			case 1:
			{
				int num4 = ((global::_000F)obj2)._0002();
				if (7u != 0)
				{
					num3 = unchecked((uint)num4);
				}
				break;
			}
			case 13:
				num3 = (uint)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				num3 = (uint)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				num3 = (uint)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				num3 = ((IntPtr.Size != 4) ? ((uint)(ulong)(long)((global::_0006_2002)obj2)._0002()) : unchecked((uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
		}
		_0002._0008((global::_0006)new global::_000F((int)num3));
	}

	private static void _0008_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_000F obj = (global::_000F)_0008;
		global::_000F obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = _0002._0002(obj2._0002());
		MethodBase methodBase2;
		if (4u != 0)
		{
			methodBase2 = methodBase;
		}
		global::_0006[] array = _0002.m__0008_2003;
		global::_0006[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		foreach (global::_0006 obj3 in array2)
		{
			_0002._0008(obj3);
		}
		_0002._0002(methodBase2, false);
	}

	private static void _000F_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (8 == 0)
		{
		}
		_0002._0003(1);
	}

	private static void _000E_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (6 == 0)
		{
		}
		_ = 7;
		if (4 == 0)
		{
		}
		_0002._0008(_0008);
	}

	private static void _0006_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (1 == 0)
		{
		}
		_0002._0002(typeof(uint));
	}

	private static void _000F_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (5 == 0)
		{
		}
		_ = 3;
		if (6 == 0)
		{
		}
		_0002._0006(_0008);
	}

	private global::_0002 _0002(int _0002)
	{
		if (this.m__0006_2004 == null)
		{
			throw new InvalidOperationException();
		}
		global::_0005 obj = this.m__0006_2004._0002();
		global::_0005 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (uint.MaxValue != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (2u != 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			this.m__0006_2004._0002()._0005_2008_2009_0002(_0002, 0);
			global::_0002 obj3 = new global::_0002();
			obj3._0002(this.m__0006_2004._0002());
			if (obj3._0002() == 0)
			{
				obj3._0002(this.m__0006_2004._0005());
			}
			else
			{
				obj3._0002(this._0002(this.m__0006_2004));
			}
			return obj3;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	private void _0003_2004(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = this._0002();
		global::_0006 obj4;
		if (3u != 0)
		{
			obj4 = obj3;
		}
		global::_0006 obj5 = _0008(obj4, obj2, _0002);
		if (5u != 0)
		{
			_0008(obj5);
		}
	}

	private static void _000F_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		uint num = ((global::_000F_2001)_0008)._0002();
		uint num2;
		if (4u != 0)
		{
			num2 = num;
		}
		_0002._0002(null, num2);
	}

	private static void _0008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0005_2007 obj = (global::_0005_2007)_0008;
		global::_0005_2007 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		global::_000F_2006 obj3 = new global::_000F_2006();
		obj3._0002(_0002.m__0008_2003[obj2._0002()]);
		_0002._0008((global::_0006)obj3);
	}

	private static void _0003_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (1 == 0)
		{
		}
		_0002._0002(typeof(byte));
	}

	private void _0002_2004()
	{
		if (!this.m__0006_2009._0002())
		{
			global::_0008_2005 obj = this.m__0006_2009;
			global::_0008_2005 obj2;
			if (5u != 0)
			{
				obj2 = obj;
			}
			bool lockTaken;
			if (true)
			{
				lockTaken = false;
			}
			try
			{
				if (8u != 0)
				{
					Monitor.Enter(obj2, ref lockTaken);
				}
				if (!this.m__0006_2009._0002())
				{
					global::_0006_2009.m__0002_2003 = _0002(this.m__0006_2009);
					_0006_2004();
					this.m__0006_2009._0002(_0002: true);
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj2);
				}
			}
		}
		if (global::_0006_2009.m__0002_2003 == null)
		{
			global::_0006_2009.m__0002_2003 = _0002(this.m__0006_2009);
		}
	}

	private void _000F(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		ulong num3;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				long num4 = checked((uint)((global::_000F)obj2)._0002());
				if (3u != 0)
				{
					num3 = (ulong)num4;
				}
			}
			else
			{
				long num5 = (uint)((global::_000F)obj2)._0002();
				if (2u != 0)
				{
					num3 = (ulong)num5;
				}
			}
			break;
		case 13:
			num3 = ((!_0002) ? ((ulong)((global::_0003_2000)obj2)._0002()) : checked((ulong)((global::_0003_2000)obj2)._0002()));
			break;
		case 19:
			num3 = ((!_0002) ? Convert.ToUInt64(((global::_0002_0010)obj2)._0002()) : Convert.ToUInt64(((global::_0002_0010)obj2)._0002()));
			break;
		case 8:
			num3 = ((!_0002) ? ((ulong)((global::_0006_200A)obj2)._0002()) : checked((ulong)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			num3 = ((IntPtr.Size != 4) ? ((!_0002) ? ((ulong)(long)((global::_0006_2002)obj2)._0002()) : checked((ulong)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((uint)(int)((global::_0006_2002)obj2)._0002()) : checked((uint)(int)((global::_0006_2002)obj2)._0002())));
			break;
		case 20:
			num3 = ((UIntPtr.Size != 4) ? ((!_0002) ? ((ulong)((global::_0002_2003)obj2)._0002()) : ((ulong)((global::_0002_2003)obj2)._0002())) : ((!_0002) ? ((uint)((global::_0002_2003)obj2)._0002()) : ((uint)((global::_0002_2003)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0008((global::_0006)new global::_0003_2000((long)num3));
	}

	private static void _0002_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (true)
		{
			num2 = num;
		}
		checked
		{
			long num3;
			switch (num2)
			{
			case 1:
			{
				long num4 = unchecked((uint)((global::_000F)obj2)._0002());
				if (8u != 0)
				{
					num3 = num4;
				}
				break;
			}
			case 13:
				num3 = (long)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				num3 = (long)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				num3 = (long)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				num3 = ((IntPtr.Size != 4) ? ((long)(ulong)(long)((global::_0006_2002)obj2)._0002()) : unchecked((uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0002._0008((global::_0006)new global::_0003_2000(num3));
		}
	}

	private static global::_0008_2003 _0002(global::_0006_2009 _0002)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = _0002._0002();
		global::_0006 obj3;
		if (3u != 0)
		{
			obj3 = obj2;
		}
		global::_0006 obj4 = _0002._0002();
		global::_0006 obj5;
		if (4u != 0)
		{
			obj5 = obj4;
		}
		if (obj._0002() != 13)
		{
			throw new InvalidOperationException();
		}
		long num = ((global::_0003_2000)obj)._0002();
		long num2;
		if (8u != 0)
		{
			num2 = num;
		}
		int num3 = obj3._0002();
		if (num3 != 7 && num3 != 9)
		{
			throw new InvalidOperationException();
		}
		byte[] array = global::_0005_2000._0002(obj3._0006_2008_2009_0002());
		if (obj5._0002() != 1)
		{
			throw new InvalidOperationException();
		}
		int num4 = ((global::_000F)obj5)._0002();
		global::_0008_2003 obj6 = new global::_0008_2003();
		obj6._0002(num4);
		obj6._0002(array);
		obj6._0002(num2);
		return obj6;
	}

	private static _0006 _0002(_0002 _0002)
	{
		Dictionary<_0002, _0006> dictionary = global::_0006_2009.m__0006;
		Dictionary<_0002, _0006> obj;
		if (6u != 0)
		{
			obj = dictionary;
		}
		bool lockTaken = default(bool);
		if (0 == 0)
		{
			lockTaken = false;
		}
		try
		{
			if (true)
			{
				Monitor.Enter(obj, ref lockTaken);
			}
			global::_0006_2009.m__0006.TryGetValue(_0002, out var value);
			return value;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private global::_0006 _0002(global::_0006 _0002, global::_0006 _0008, bool _0006)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				if (!_0006)
				{
					int num = ((global::_000F)_0002)._0002();
					int num2 = ((global::_000F)_0008)._0002();
					int num3 = default(int);
					if (0 == 0)
					{
						num3 = num2;
					}
					return new global::_000F(num / num3);
				}
				int num4 = ((global::_000F)_0002)._0002();
				int num5 = ((global::_000F)_0008)._0002();
				uint num6;
				if (5u != 0)
				{
					num6 = (uint)num5;
				}
				return new global::_000F((int)((uint)num4 / num6));
			}
			if (_0008._0002() == 13)
			{
				return _000F(new global::_0003_2000(((global::_000F)_0002)._0002()), _0008, _0006);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type;
				if (6u != 0)
				{
					type = underlyingType;
				}
				if (type == typeof(long) || type == typeof(ulong))
				{
					return _000F(new global::_0003_2000(((global::_000F)_0002)._0002()), new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006);
				}
				return this._0002(_0002, (global::_0006)new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				return _000F(_0002, _0008, _0006);
			}
			if (_0008._0002() == 1)
			{
				return _000F(_0002, new global::_0003_2000(((global::_000F)_0008)._0002()), _0006);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type2;
				if (8u != 0)
				{
					type2 = underlyingType2;
				}
				if (type2 == typeof(long) || type2 == typeof(ulong))
				{
					return _000F(_0002, new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006);
				}
				return _000F(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006);
			}
		}
		if (_0002._0002() == 8 && _0008._0002() == 8)
		{
			global::_0006_200A obj = new global::_0006_200A();
			obj._0002(((global::_0006_200A)_0002)._0002() / ((global::_0006_200A)_0008)._0002());
			return obj;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			Type type3;
			if (3u != 0)
			{
				type3 = underlyingType3;
			}
			if (type3 == typeof(long) || type3 == typeof(ulong))
			{
				return this._0002((global::_0006)new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008, _0006);
			}
			return this._0002((global::_0006)new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008, _0006);
		}
		throw new InvalidOperationException();
	}

	private static global::_0006 _0002(global::_0006 _0002, global::_0006 _0008, bool _0006)
	{
		if (!_0006)
		{
			long num = ((global::_0003_2000)_0002)._0002();
			long num2 = ((global::_0003_2000)_0008)._0002();
			long num3;
			if (2u != 0)
			{
				num3 = num2;
			}
			return new global::_0003_2000(num % num3);
		}
		long num4 = ((global::_0003_2000)_0002)._0002();
		long num5 = ((global::_0003_2000)_0008)._0002();
		ulong num6;
		if (3u != 0)
		{
			num6 = (ulong)num5;
		}
		return new global::_0003_2000((long)((ulong)num4 % num6));
	}

	private static void _0006_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0008();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		_0002._0008(obj2._0006_2008_2009_0002());
	}

	private static void _000E_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (6 == 0)
		{
		}
		_0002._0006(_0002: true, _0008: true);
	}

	private static void _0005_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		string text = _0002._0002(num2);
		string text2;
		if (7u != 0)
		{
			text2 = text;
		}
		global::_0005_2005 obj = new global::_0005_2005();
		obj._0002(text2);
		_0002._0008((global::_0006)obj);
	}

	private static void _0002_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (-1 == 0)
		{
		}
		_0002._0006(typeof(byte));
	}

	private global::_0006 _0006(global::_0006 _0002, global::_0006 _0008)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				int num = ((global::_000F)_0002)._0002();
				int num2 = ((global::_000F)_0008)._0002();
				int num3;
				if (2u != 0)
				{
					num3 = num2;
				}
				return new global::_000F(num ^ num3);
			}
			if (_0008._0002() == 19)
			{
				int num4 = ((global::_000F)_0002)._0002();
				int num5;
				if (2u != 0)
				{
					num5 = num4;
				}
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type;
				if (3u != 0)
				{
					type = underlyingType;
				}
				if (type == typeof(long) || type == typeof(ulong))
				{
					long num6 = Convert.ToInt64(_0008._0006_2008_2009_0002());
					long num7;
					if (7u != 0)
					{
						num7 = num6;
					}
					return new global::_0003_2000(num5 ^ num7);
				}
				int num8 = Convert.ToInt32(_0008._0006_2008_2009_0002());
				int num9;
				if (6u != 0)
				{
					num9 = num8;
				}
				return new global::_000F(num5 ^ num9);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				long num10 = ((global::_0003_2000)_0002)._0002();
				long num11 = ((global::_0003_2000)_0008)._0002();
				long num12;
				if (6u != 0)
				{
					num12 = num11;
				}
				return new global::_0003_2000(num10 ^ num12);
			}
			if (_0008._0002() == 19)
			{
				int num13 = ((global::_000F)_0002)._0002();
				long num14 = Convert.ToInt64(_0008._0006_2008_2009_0002());
				return new global::_0003_2000(num13 ^ num14);
			}
		}
		if (_0002._0002() == 19)
		{
			if (_0008._0002() == 1)
			{
				int num15 = ((global::_000F)_0008)._0002();
				Type underlyingType2 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002()) ^ num15);
				}
				return new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002()) ^ num15);
			}
			if (_0008._0002() == 13)
			{
				long num16 = Convert.ToInt64(_0002._0006_2008_2009_0002());
				long num17 = ((global::_0003_2000)_0008)._0002();
				return new global::_0003_2000(num16 ^ num17);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num18 = Convert.ToInt64(_0002._0006_2008_2009_0002());
					long num19 = Convert.ToInt64(_0008._0006_2008_2009_0002());
					return new global::_0003_2000(num18 ^ num19);
				}
				int num20 = Convert.ToInt32(_0002._0006_2008_2009_0002());
				int num21 = Convert.ToInt32(_0008._0006_2008_2009_0002());
				return new global::_000F(num20 ^ num21);
			}
		}
		throw new InvalidOperationException();
	}

	private void _0008(Type _0002)
	{
		object obj = this._0002()._0006_2008_2009_0002();
		object obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		long num = this._0002();
		long num2;
		if (4u != 0)
		{
			num2 = num;
		}
		Array obj3 = (Array)this._0002()._0006_2008_2009_0002();
		Array array;
		if (uint.MaxValue != 0)
		{
			array = obj3;
		}
		this._0002(_0002, obj2, num2, array);
	}

	private static void _0002_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463124022));
	}

	private static global::_0006 _000F(global::_0006 _0002, global::_0006 _0008, bool _0006)
	{
		if (!_0006)
		{
			long num = ((global::_0003_2000)_0002)._0002();
			long num2 = ((global::_0003_2000)_0008)._0002();
			long num3;
			if (6u != 0)
			{
				num3 = num2;
			}
			return new global::_0003_2000(num / num3);
		}
		long num4 = ((global::_0003_2000)_0002)._0002();
		long num5 = ((global::_0003_2000)_0008)._0002();
		ulong num6;
		if (true)
		{
			num6 = (ulong)num5;
		}
		return new global::_0003_2000((long)((ulong)num4 / num6));
	}

	private static void _0003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		checked
		{
			ushort num3;
			switch (num2)
			{
			case 1:
			{
				ushort num4 = (ushort)(uint)((global::_000F)obj2)._0002();
				if (3u != 0)
				{
					num3 = num4;
				}
				break;
			}
			case 13:
				num3 = (ushort)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				num3 = (ushort)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				num3 = (ushort)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				num3 = ((IntPtr.Size != 4) ? ((ushort)(ulong)(long)((global::_0006_2002)obj2)._0002()) : ((ushort)(uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0002._0008((global::_0006)new global::_000F(num3));
		}
	}

	private static void _0002(object _0002)
	{
		_ = 5;
		if (2 == 0)
		{
		}
		throw _0002;
	}

	private static void _000F_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0008_2003 obj = global::_0006_2009._0002(_0002);
		global::_0008_2003 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		global::_0005 obj3 = _0002.m__000F_2007._0002();
		global::_0005 obj4;
		if (4u != 0)
		{
			obj4 = obj3;
		}
		long num = _0002._0008();
		long num2;
		if (7u != 0)
		{
			num2 = num;
		}
		byte[] array = new global::_000E_2003(obj2._000E_2004_2008_2009_0002(), obj2._000E_2004_2008_2009_0002())._0002(obj4, obj2);
		_000F_2004 obj5 = new _000F_2004
		{
			_0002 = obj2,
			_000F = num2
		};
		obj2._0008(global::_0003_2003._0008(array.Length) - array.Length);
		obj5._0008 = new global::_0002_2004_2005(obj5._0006 = new global::_0003(array, 0, array.Length, _000F: false));
		_0002._0002().Push(obj5);
		_0002._0002(obj5);
	}

	[DebuggerNonUserCode]
	private MethodBase _0002(int _0002)
	{
		global::_0002 obj = this._0002(_0002);
		global::_0002 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = this._0002(_0002, obj2);
		MethodBase methodBase2;
		if (2u != 0)
		{
			methodBase2 = methodBase;
		}
		if (7u != 0)
		{
			this._0002((MemberInfo)methodBase2);
		}
		return methodBase2;
	}

	private static void _000E_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (5 == 0)
		{
		}
		_0002._0005();
	}

	private static void _0008_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463125228));
	}

	private static void _000E_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (4u != 0)
		{
			obj4 = obj3;
		}
		_0002._0008(_0002._0002(obj4, obj2));
	}

	private void _0002(Stream _0002, long _0008, string _0006)
	{
		int num = this._0008();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		global::_0006_2000 obj = new global::_0006_2000(_0002, num2);
		global::_0006_2000 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		global::_0002_2004_2005 obj3 = new global::_0002_2004_2005(obj2);
		if (8u != 0)
		{
			this.m__0006_2004 = obj3;
		}
		if (_0006 != null)
		{
			_0008 = this._0002(_0006);
		}
		global::_0005 obj4 = this.m__0006_2004._0002();
		lock (obj4)
		{
			obj4._0005_2008_2009_0002(_0008, 0);
			this._0002(this.m__0006_2004);
			this.m__0003 = this._0002(this.m__0006_2004);
			this.m__000E_2004 = global::_0006_2009._0002(this.m__0006_2004);
			this.m__0008 = global::_0006_2009._0002(this.m__0006_2004);
		}
		_000E();
	}

	private static void _0006_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (-1 == 0)
		{
		}
		_0002._0008(global::_0002_2008._0002);
	}

	private void _0006(int _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		this.m__0008_2003[_0002]._0006_2008_2009_0002(obj2);
	}

	private static void _0003_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (8 == 0)
		{
		}
		_0002._0002(_0002: true, _0008: false);
	}

	private global::_0006 _0008()
	{
		_ = 0;
		if (false)
		{
		}
		global::_0006 obj = this.m__000E;
		if (obj == null)
		{
			if (2 == 0)
			{
			}
			_ = 6;
			if (6 == 0)
			{
			}
			obj = this.m__0002_2009.Peek();
		}
		return obj;
	}

	private static void _0005_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (7 == 0)
		{
		}
		_0002._0003(4);
	}

	private void _0002(Type _0002, object _0008, long _0006, Array _000F)
	{
		global::_0006 obj = global::_0006._0002(_0008, _0002);
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		_000F.SetValue(obj2._0006_2008_2009_0002(), _0006);
	}

	private static void _0005_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (2u != 0)
		{
			obj4 = obj3;
		}
		_0002._0008(_0002._0008(obj4, obj2));
	}

	private bool _0002(Type _0002, global::_0002 _0008, out int _0006)
	{
		_0006 = 0;
		global::_0005_2002 obj = (global::_0005_2002)_0008._0002();
		global::_0005_2002 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		if (global::_0002_2008._0002(_0002).IsGenericParameter)
		{
			if (obj2 != null && !obj2._0002())
			{
				return false;
			}
			return true;
		}
		Type type = this._0002(_0008._0002(), _0008: false);
		Type type2;
		if (8u != 0)
		{
			type2 = type;
		}
		if (!global::_000E_2001._0002(_0002, type2, out _0006))
		{
			return false;
		}
		return true;
	}

	private static bool _0002(global::_0006 _0002, global::_0006 _0008)
	{
		bool result;
		if (uint.MaxValue != 0)
		{
			result = false;
		}
		int num = _0002._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 1:
		{
			if (_0008._0002() == 19)
			{
				return global::_0006_2009._0002(_0002, (global::_0006)new global::_000F(Convert.ToInt32(((global::_0002_0010)_0008)._0002())));
			}
			bool num5 = (uint)((global::_000F)_0002)._0002() < (uint)((global::_000F)_0008)._0002();
			if (0 == 0)
			{
				result = num5;
			}
			break;
		}
		case 13:
			if (_0008._0002() == 19)
			{
				return global::_0006_2009._0002(_0002, (global::_0006)new global::_0003_2000(Convert.ToInt64(((global::_0002_0010)_0008)._0002())));
			}
			if (_0008._0002() == 1)
			{
				return global::_0006_2009._0002(_0002, (global::_0006)new global::_0003_2000(((global::_000F)_0008)._0002()));
			}
			result = (ulong)((global::_0003_2000)_0002)._0002() < (ulong)((global::_0003_2000)_0008)._0002();
			break;
		case 19:
			return global::_0006_2009._0002((global::_0006)new global::_0003_2000(Convert.ToInt64(((global::_0002_0010)_0002)._0002())), _0008);
		case 8:
		{
			double num3 = ((global::_0006_200A)_0002)._0002();
			double num4 = ((global::_0006_200A)_0008)._0002();
			result = num3 < num4 || double.IsNaN(num3) || double.IsNaN(num4);
			break;
		}
		}
		return result;
	}

	private static void _0008_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (5 == 0)
		{
		}
		_ = 4;
		if (-1 == 0)
		{
		}
		_0002._000F(((global::_0008_2004_2005)_0008)._0002());
	}

	private void _0006(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		bool num = IntPtr.Size == 4;
		bool flag;
		if (6u != 0)
		{
			flag = num;
		}
		int num2 = obj2._0002();
		int num3;
		if (uint.MaxValue != 0)
		{
			num3 = num2;
		}
		IntPtr intPtr;
		switch (num3)
		{
		case 1:
		{
			int value = ((global::_000F)obj2)._0002();
			intPtr = ((!_0002) ? new IntPtr(value) : new IntPtr(value));
			break;
		}
		case 13:
		{
			long num4 = ((global::_0003_2000)obj2)._0002();
			intPtr = ((!flag) ? ((!_0002) ? new IntPtr(num4) : new IntPtr(num4)) : ((!_0002) ? new IntPtr((int)num4) : new IntPtr(checked((int)num4))));
			break;
		}
		case 8:
		{
			double num5 = ((global::_0006_200A)obj2)._0002();
			intPtr = ((!flag) ? ((!_0002) ? new IntPtr((long)num5) : new IntPtr(checked((long)num5))) : ((!_0002) ? new IntPtr((int)num5) : new IntPtr(checked((int)num5))));
			break;
		}
		case 19:
			intPtr = ((!_0002) ? new IntPtr((long)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())) : new IntPtr(checked((long)Convert.ToUInt64(((global::_0002_0010)obj2)._0002()))));
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_0006_2002 obj3 = new global::_0006_2002();
		obj3._0002(intPtr);
		_0008((global::_0006)obj3);
	}

	private static void _000E_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		FieldInfo fieldInfo = _0002._0002(num2);
		FieldInfo fieldInfo2;
		if (8u != 0)
		{
			fieldInfo2 = fieldInfo;
		}
		_0002._0008(global::_0006._0002(fieldInfo2.GetValue(null), fieldInfo2.FieldType));
	}

	private static void _0006_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463124241));
	}

	private static void _0003_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (false)
		{
		}
		_0002._000F_2004(_0002: true);
	}

	private static void _000F_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (1 == 0)
		{
		}
		_0002._0002(typeof(short));
	}

	private static void _0002_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (6 == 0)
		{
		}
		_0002._0003_2004(_0002: false);
	}

	private static void _000E_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (false)
		{
		}
		_0002._0002(0);
	}

	private void _0006_2004()
	{
	}

	private static void _000E_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (-1 == 0)
		{
		}
		_0002._0006(global::_0002_2008._0002);
	}

	private static BindingFlags _0002(bool _0002)
	{
		BindingFlags bindingFlags;
		if (4u != 0)
		{
			bindingFlags = BindingFlags.Public | BindingFlags.NonPublic;
		}
		if (_0002)
		{
			BindingFlags result = bindingFlags | BindingFlags.Static;
			if (uint.MaxValue != 0)
			{
				return result;
			}
		}
		else
		{
			BindingFlags result2 = bindingFlags | BindingFlags.Instance;
			if (uint.MaxValue != 0)
			{
				return result2;
			}
		}
		return bindingFlags;
	}

	private static void _0002_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (8 == 0)
		{
		}
		_0002._0002(typeof(sbyte));
	}

	private static void _000E_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (2 == 0)
		{
		}
		_0002._0003(3);
	}

	private static global::_0006 _0008(global::_0006 _0002, global::_0006 _0008, bool _0006, bool _000F)
	{
		if (!_000F)
		{
			long num = ((global::_0003_2000)_0002)._0002();
			long num2;
			if (true)
			{
				num2 = num;
			}
			long num3 = ((global::_0003_2000)_0008)._0002();
			long num4;
			if (8u != 0)
			{
				num4 = num3;
			}
			long num6;
			if (_0006)
			{
				long num5 = checked(num2 + num4);
				if (7u != 0)
				{
					num6 = num5;
				}
			}
			else
			{
				num6 = num2 + num4;
			}
			return new global::_0003_2000(num6);
		}
		ulong num7 = (ulong)((global::_0003_2000)_0002)._0002();
		ulong num8 = (ulong)((global::_0003_2000)_0008)._0002();
		ulong num9 = ((!_0006) ? (num7 + num8) : checked(num7 + num8));
		return new global::_0003_2000((long)num9);
	}

	private static void _0002(ILGenerator _0002, int _0008)
	{
		_ = 8;
		if (false)
		{
		}
		switch (_0008)
		{
		case -1:
			_ = 7;
			if (8 == 0)
			{
			}
			_0002.Emit(OpCodes.Ldc_I4_M1);
			break;
		case 0:
			_ = -1;
			if (-1 == 0)
			{
			}
			_0002.Emit(OpCodes.Ldc_I4_0);
			break;
		case 1:
			_0002.Emit(OpCodes.Ldc_I4_1);
			break;
		case 2:
			_0002.Emit(OpCodes.Ldc_I4_2);
			break;
		case 3:
			_0002.Emit(OpCodes.Ldc_I4_3);
			break;
		case 4:
			_0002.Emit(OpCodes.Ldc_I4_4);
			break;
		case 5:
			_0002.Emit(OpCodes.Ldc_I4_5);
			break;
		case 6:
			_0002.Emit(OpCodes.Ldc_I4_6);
			break;
		case 7:
			_0002.Emit(OpCodes.Ldc_I4_7);
			break;
		case 8:
			_0002.Emit(OpCodes.Ldc_I4_8);
			break;
		default:
			if (_0008 > -129 && _0008 < 128)
			{
				_0002.Emit(OpCodes.Ldc_I4_S, (sbyte)_0008);
			}
			else
			{
				_0002.Emit(OpCodes.Ldc_I4, _0008);
			}
			break;
		}
	}

	private static void _0006_2005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		double num3;
		switch (num2)
		{
		case 1:
		{
			double num4 = (uint)((global::_000F)obj2)._0002();
			if (uint.MaxValue != 0)
			{
				num3 = num4;
			}
			break;
		}
		case 13:
			num3 = (ulong)((global::_0003_2000)obj2)._0002();
			break;
		case 19:
			num3 = Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_0006_200A obj3 = new global::_0006_200A();
		obj3._0002(num3);
		_0002._0008((global::_0006)obj3);
	}

	private global::_0006 _0002(global::_0006 _0002, global::_0006 _0008)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				int num = ((global::_000F)_0002)._0002();
				int num2;
				if (2u != 0)
				{
					num2 = num;
				}
				int num3 = ((global::_000F)_0008)._0002();
				int num4;
				if (true)
				{
					num4 = num3;
				}
				global::_000F obj = new global::_000F();
				obj._0002(num2 & num4);
				return obj;
			}
			if (_0008._0002() == 19)
			{
				int num5 = ((global::_000F)_0002)._0002();
				int num6;
				if (uint.MaxValue != 0)
				{
					num6 = num5;
				}
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type;
				if (2u != 0)
				{
					type = underlyingType;
				}
				if (type == typeof(long) || type == typeof(ulong))
				{
					long num7 = Convert.ToInt64(_0008._0006_2008_2009_0002());
					long num8;
					if (5u != 0)
					{
						num8 = num7;
					}
					return new global::_0003_2000(num6 & num8);
				}
				int num9 = Convert.ToInt32(_0008._0006_2008_2009_0002());
				int num10;
				if (7u != 0)
				{
					num10 = num9;
				}
				global::_000F obj2 = new global::_000F();
				obj2._0002(num6 & num10);
				return obj2;
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				long num11 = ((global::_0003_2000)_0002)._0002();
				long num12;
				if (5u != 0)
				{
					num12 = num11;
				}
				long num13 = ((global::_0003_2000)_0008)._0002();
				global::_0003_2000 obj3 = new global::_0003_2000();
				obj3._0002(num12 & num13);
				return obj3;
			}
			if (_0008._0002() == 19)
			{
				int num14 = ((global::_000F)_0002)._0002();
				long num15 = Convert.ToInt64(_0008._0006_2008_2009_0002());
				return new global::_0003_2000(num14 & num15);
			}
		}
		if (_0002._0002() == 19)
		{
			if (_0008._0002() == 1)
			{
				int num16 = ((global::_000F)_0008)._0002();
				Type underlyingType2 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002()) & num16);
				}
				int num17 = Convert.ToInt32(_0002._0006_2008_2009_0002());
				global::_000F obj4 = new global::_000F();
				obj4._0002(num17 & num16);
				return obj4;
			}
			if (_0008._0002() == 13)
			{
				long num18 = Convert.ToInt64(_0002._0006_2008_2009_0002());
				long num19 = ((global::_0003_2000)_0008)._0002();
				global::_0003_2000 obj5 = new global::_0003_2000();
				obj5._0002(num18 & num19);
				return obj5;
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num20 = Convert.ToInt64(_0002._0006_2008_2009_0002());
					long num21 = Convert.ToInt64(_0008._0006_2008_2009_0002());
					return new global::_0003_2000(num20 & num21);
				}
				int num22 = Convert.ToInt32(_0002._0006_2008_2009_0002());
				int num23 = Convert.ToInt32(_0008._0006_2008_2009_0002());
				return new global::_000F(num22 & num23);
			}
		}
		throw new InvalidOperationException();
	}

	private static void _0003_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (3 == 0)
		{
		}
		_0002._000E(_0002: false);
	}

	private static void _000E_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (7u != 0)
		{
			type2 = type;
		}
		_0002._0006(type2);
	}

	private static void _000F_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (6 == 0)
		{
		}
		_ = 7;
		if (2 == 0)
		{
		}
		_0002._0008(_0008);
	}

	private static void _0002_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (7 == 0)
		{
		}
		_0002._0003(7);
	}

	private static void _000E_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (8 == 0)
		{
		}
		_0002._0002(global::_0006_2009.m__0005);
	}

	private void _0002(Type _0002)
	{
		global::_0002_2004 obj = (global::_0002_2004)this._0002();
		global::_0002_2004 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = global::_0006._0002(this._0002(obj2)._0006_2008_2009_0002(), _0002);
		if (uint.MaxValue != 0)
		{
			_0008(obj3);
		}
	}

	private void _0005()
	{
		global::_0006 obj = _0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		global::_0002_2004 obj3 = (global::_0002_2004)_0002();
		global::_0002_2004 obj4;
		if (true)
		{
			obj4 = obj3;
		}
		if (5u != 0)
		{
			_0002(obj4, obj2);
		}
	}

	public object _0002(Stream _0002, string _0008, object[] _0006, Type[] _000F, Type[] _0005, object[] _0003)
	{
		if (7u != 0)
		{
			this.m__000F_2004 = _0002;
		}
		if (true)
		{
			this._0002(_0002, _0008);
		}
		return this._0002(_0006, _000F, _0005, _0003);
	}

	private static void _0008_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (4 == 0)
		{
		}
		_0002._0005();
	}

	private static void _000F_2004_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (4 == 0)
		{
		}
		_ = 0;
		if (-1 == 0)
		{
		}
		_0002._0008(((global::_0008_2004_2005)_0008)._0002());
	}

	private static Exception _0008(string _0002, string _0008)
	{
		string text = global::_0008_0010._0002(-1463125880);
		_ = 0;
		if (3 == 0)
		{
		}
		string text2 = text + _0002 + global::_0008_0010._0002(-1463125844);
		string text3 = global::_0008_0010._0002(-1463125633);
		_ = 0;
		if (3 == 0)
		{
		}
		return new MethodAccessException(global::_0006_2009._0002(text2, text3 + _0008 + global::_0008_0010._0002(-1463125844)));
	}

	private static void _000F_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 8;
		if (false)
		{
		}
		_0002._0002(typeof(ushort));
	}

	private static void _0005_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (8 == 0)
		{
		}
		_0002._0002(global::_0002_2008._0002);
	}

	private static global::_0006 _0003(global::_0006 _0002, global::_0006 _0008, bool _0006, bool _000F)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				if (!_000F)
				{
					int num = ((global::_000F)_0002)._0002();
					int num2;
					if (6u != 0)
					{
						num2 = num;
					}
					int num3 = ((global::_000F)_0008)._0002();
					int num4;
					if (uint.MaxValue != 0)
					{
						num4 = num3;
					}
					int num6;
					if (_0006)
					{
						int num5 = checked(num2 + num4);
						if (true)
						{
							num6 = num5;
						}
					}
					else
					{
						int num7 = num2 + num4;
						if (uint.MaxValue != 0)
						{
							num6 = num7;
						}
					}
					return new global::_000F(num6);
				}
				int num8 = ((global::_000F)_0002)._0002();
				uint num9;
				if (6u != 0)
				{
					num9 = (uint)num8;
				}
				int num10 = ((global::_000F)_0008)._0002();
				uint num11;
				if (6u != 0)
				{
					num11 = (uint)num10;
				}
				uint num13;
				if (_0006)
				{
					uint num12 = checked(num9 + num11);
					if (6u != 0)
					{
						num13 = num12;
					}
				}
				else
				{
					num13 = num9 + num11;
				}
				return new global::_000F((int)num13);
			}
			if (_0008._0002() == 13)
			{
				return global::_0006_2009._0008(new global::_0003_2000(((global::_000F)_0002)._0002()), _0008, _0006, _000F);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return global::_0006_2009._0008(new global::_0003_2000(((global::_000F)_0002)._0002()), new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006, _000F);
				}
				return _0003(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006, _000F);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				return global::_0006_2009._0008(_0002, _0008, _0006, _000F);
			}
			if (_0008._0002() == 1)
			{
				return global::_0006_2009._0008(_0002, new global::_0003_2000(((global::_000F)_0008)._0002()), _0006, _000F);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return global::_0006_2009._0008(_0002, new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006, _000F);
				}
				return global::_0006_2009._0008(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006, _000F);
			}
		}
		if (_0002._0002() == 8 && _0008._0002() == 8)
		{
			global::_0006_200A obj = new global::_0006_200A();
			obj._0002(((global::_0006_200A)_0002)._0002() + ((global::_0006_200A)_0008)._0002());
			return obj;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return _0003(new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008, _0006, _000F);
			}
			return _0003(new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008, _0006, _000F);
		}
		throw new InvalidOperationException();
	}

	private static void _0003_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (7 == 0)
		{
		}
		_0002._0008(_0002: false);
	}

	private static void _0008_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (false)
		{
		}
		_0002._0006(typeof(ushort));
	}

	private static void _000E_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		if (global::_0006_2009._0008(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2 = default(uint);
			if (0 == 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static void _000E_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (2 == 0)
		{
		}
		_0002._0003_2004(_0002: true);
	}

	private static void _0008_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (4 == 0)
		{
		}
		_0002._0002(typeof(float));
	}

	private global::_0006 _0002(global::_0002_2004_2005 _0002, byte _0008)
	{
		switch (_0008)
		{
		case 11:
			return null;
		case 0:
		{
			uint num3 = this.m__0008_2004 + 1;
			if (7u != 0)
			{
				this.m__0008_2004 = num3;
			}
			global::_0003_2001 obj2 = new global::_0003_2001();
			obj2._0002(_0002._0002());
			return obj2;
		}
		case 2:
		case 6:
		{
			uint num5 = this.m__0008_2004 + 4;
			if (uint.MaxValue != 0)
			{
				this.m__0008_2004 = num5;
			}
			return new global::_000F(_0002._0005());
		}
		case 10:
		{
			uint num2 = this.m__0008_2004 + 8;
			if (4u != 0)
			{
				this.m__0008_2004 = num2;
			}
			return new global::_0003_2000(_0002._0002());
		}
		case 3:
		case 7:
		{
			uint num4 = this.m__0008_2004 + 1;
			if (4u != 0)
			{
				this.m__0008_2004 = num4;
			}
			global::_0008_2004_2005 obj7 = new global::_0008_2004_2005();
			obj7._0002(_0002._0002());
			return obj7;
		}
		case 5:
		case 12:
		{
			this.m__0008_2004 += 2u;
			global::_0005_2007 obj6 = new global::_0005_2007();
			obj6._0002(_0002._0002());
			return obj6;
		}
		case 4:
		{
			this.m__0008_2004 += 4u;
			global::_000F_200B obj5 = new global::_000F_200B();
			obj5._0002(_0002._0002());
			return obj5;
		}
		case 8:
		{
			this.m__0008_2004 += 8u;
			global::_0006_200A obj4 = new global::_0006_200A();
			obj4._0002(_0002._0002());
			return obj4;
		}
		case 1:
		{
			this.m__0008_2004 += 4u;
			global::_000F_2001 obj3 = new global::_000F_2001();
			obj3._0002(_0002._0002());
			return obj3;
		}
		case 9:
		{
			int num = _0002._0005();
			global::_000F[] array = new global::_000F[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = new global::_000F(_0002._0005());
			}
			this.m__0008_2004 += (uint)((num + 1) * 4);
			global::_0006_2004 obj = new global::_0006_2004();
			obj._0002(array);
			return obj;
		}
		default:
			throw new Exception(global::_0008_0010._0002(-1463124154));
		}
	}

	private static void _000F_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		if (4u != 0)
		{
			bool flag = false;
		}
		int num = obj2._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		if (num2 switch
		{
			1 => ((global::_000F)obj2)._0002() != 0, 
			13 => ((global::_0003_2000)obj2)._0002() != 0, 
			0 => ((global::_0006_2002)obj2)._0002() != IntPtr.Zero, 
			20 => ((global::_0002_2003)obj2)._0002() != UIntPtr.Zero, 
			19 => Convert.ToBoolean(((global::_0002_0010)obj2)._0002()), 
			7 => ((global::_0005_2003)obj2)._0002() != null, 
			_ => obj2._0006_2008_2009_0002() != null, 
		})
		{
			uint num3 = ((global::_000F_2001)_0008)._0002();
			_0002._0002(num3);
		}
	}

	private void _000E_2004(bool _0002)
	{
		uint num = this.m__0006_2007;
		uint num2;
		if (8u != 0)
		{
			num2 = num;
		}
		while (true)
		{
			try
			{
				while (!this.m__0003_2004)
				{
					if (this.m__0003_2007.HasValue)
					{
						uint value = this.m__0003_2007.Value;
						if (7u != 0)
						{
							this.m__0008_2004 = value;
						}
						long num3 = this.m__0008_2004;
						if (6u != 0)
						{
							this._0002(num3);
						}
						this.m__0003_2007 = null;
					}
					else if (this.m__0008_2004 >= num2)
					{
						break;
					}
					this._0002();
				}
				break;
			}
			catch (object obj)
			{
				this._0002(obj, 0u);
				if (!_0002)
				{
					_000E_2004(_0002: true);
					break;
				}
			}
		}
	}

	private static void _0006_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (8u != 0)
		{
			type2 = type;
		}
		_0002._0002(type2);
	}

	private void _0003(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = this._0002();
		global::_0006 obj4 = default(global::_0006);
		if (0 == 0)
		{
			obj4 = obj3;
		}
		global::_0006 obj5 = this._0002(obj4, obj2, _0002);
		if (uint.MaxValue != 0)
		{
			_0008(obj5);
		}
	}

	private static void _0006_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (5 == 0)
		{
		}
		_0002._000F(_0002: true);
	}

	private static void _000F_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		double num3;
		switch (num2)
		{
		case 1:
		{
			double num4 = ((global::_000F)obj2)._0002();
			if (3u != 0)
			{
				num3 = num4;
			}
			break;
		}
		case 13:
			num3 = ((global::_0003_2000)obj2)._0002();
			break;
		case 19:
			num3 = Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
			break;
		case 8:
			num3 = ((global::_0006_200A)obj2)._0002();
			break;
		default:
			throw new InvalidOperationException();
		}
		global::_0006_200A obj3 = new global::_0006_200A();
		obj3._0002(num3);
		_0002._0008((global::_0006)obj3);
	}

	private void _0006(bool _0002, bool _0008)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = this._0002();
		global::_0006 obj4;
		if (2u != 0)
		{
			obj4 = obj3;
		}
		global::_0006 obj5 = _0006(obj4, obj2, _0002, _0008);
		if (2u != 0)
		{
			this._0008(obj5);
		}
	}

	private global::_0006[] _0002(object[] _0002)
	{
		global::_0002_2006[] array = this.m__0003._0002();
		global::_0002_2006[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		int num = array2.Length;
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		global::_0006[] array3 = new global::_0006[num2];
		global::_0006[] array4;
		if (2u != 0)
		{
			array4 = array3;
		}
		int i;
		if (6u != 0)
		{
			i = 0;
		}
		for (; i < num2; i++)
		{
			object obj = _0002[i];
			Type type = this._0002(array2[i]._0002(), _0008: false);
			Type type2 = null;
			Type type3 = global::_0002_2008._0008(type);
			type2 = ((!(type3 == global::_0002_2008._0002) && !global::_0002_2008._0002(type3)) ? ((obj != null) ? obj.GetType() : type) : type);
			if (obj != null && !type.IsAssignableFrom(type2) && type.IsByRef && !type.GetElementType().IsAssignableFrom(type2))
			{
				throw new ArgumentException(string.Format(global::_0008_0010._0002(-1463124939), type2, type));
			}
			array4[i] = global::_0006._0002(obj, type2);
		}
		if (!this.m__0003._0002() && this._0002(this.m__0003._0002(), _0008: false).IsValueType)
		{
			global::_000F_2006 obj2 = new global::_000F_2006();
			obj2._0002(array4[0]);
			array4[0] = obj2;
		}
		for (int j = 0; j < num2; j++)
		{
			if (array2[j]._0002())
			{
				int num3 = j;
				global::_000F_2006 obj3 = new global::_000F_2006();
				obj3._0002(array4[j]);
				array4[num3] = obj3;
			}
		}
		return array4;
	}

	private void _0006(Type _0002)
	{
		long num = this._0002();
		long index;
		if (4u != 0)
		{
			index = num;
		}
		Array obj = (Array)this._0002()._0006_2008_2009_0002();
		Array array;
		if (3u != 0)
		{
			array = obj;
		}
		global::_0006 obj2 = global::_0006._0002(array.GetValue(index), _0002);
		if (3u != 0)
		{
			_0008(obj2);
		}
	}

	private static void _0003_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		if (3u != 0)
		{
			_0002.m__0005_2007 = type;
		}
	}

	private static void _000F_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (3u != 0)
		{
			obj4 = obj3;
		}
		bool flag;
		if (obj4._0002() == 8)
		{
			bool num = !_0005(obj4, obj2);
			if (2u != 0)
			{
				flag = num;
			}
		}
		else
		{
			flag = !global::_0006_2009._0008(obj4, obj2);
		}
		if (flag)
		{
			uint num2 = ((global::_000F_2001)_0008)._0002();
			_0002._0002(num2);
		}
	}

	private static void _0005_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (8 == 0)
		{
		}
		_0002._0008_2004(_0002: true);
	}

	private static void _0006_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (1 == 0)
		{
		}
		_0002._0008(_0002: false, _0008: false);
	}

	private static void _000F_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
	}

	private static object _0002(MethodBase _0002, object _0008, object[] _0006, bool _000F)
	{
		_0002 obj = new _0002(_0002, _000F);
		_0006 obj2 = global::_0006_2009._0002(obj);
		_0006 obj3;
		if (8u != 0)
		{
			obj3 = obj2;
		}
		if (obj3 == null)
		{
			Dictionary<MethodBase, int> dictionary = global::_0006_2009.m__000E_2009;
			Dictionary<MethodBase, int> obj4;
			if (7u != 0)
			{
				obj4 = dictionary;
			}
			bool lockTaken;
			if (2u != 0)
			{
				lockTaken = false;
			}
			bool flag;
			try
			{
				Monitor.Enter(obj4, ref lockTaken);
				global::_0006_2009.m__000E_2009.TryGetValue(_0002, out var value);
				flag = value >= 50;
				if (!flag)
				{
					global::_0006_2009.m__000E_2009[_0002] = value + 1;
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj4);
				}
			}
			if (!flag && (_000F || _0008 != null || _0002.IsStatic || _0002.IsConstructor) && !global::_0006_2009._0002(_0002) && (_0002.CallingConvention & CallingConventions.Any) != CallingConventions.VarArgs)
			{
				return global::_0006_2009._0002(_0002, _0008, _0006);
			}
			obj3 = global::_0006_2009._0008(obj);
			lock (global::_0006_2009.m__000E_2009)
			{
				global::_0006_2009.m__000E_2009.Remove(_0002);
			}
		}
		return obj3(_0008, _0006);
	}

	private static void _000F_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (7 == 0)
		{
		}
		_0002._0005_2004(_0002: false);
	}

	private global::_0006 _0002(global::_0006 _0002)
	{
		if (_0002._0002() == 1)
		{
			return new global::_000F(-((global::_000F)_0002)._0002());
		}
		if (_0002._0002() == 13)
		{
			return new global::_0003_2000(-((global::_0003_2000)_0002)._0002());
		}
		if (_0002._0002() == 8)
		{
			global::_0006_200A obj = new global::_0006_200A();
			obj._0002(0.0 - ((global::_0006_200A)_0002)._0002());
			return obj;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			Type type;
			if (4u != 0)
			{
				type = underlyingType;
			}
			if (type == typeof(long) || type == typeof(ulong))
			{
				return this._0002((global::_0006)new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())));
			}
			return this._0002((global::_0006)new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())));
		}
		throw new InvalidOperationException();
	}

	private static void _0002_200A(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0008_2004_2005 obj = (global::_0008_2004_2005)_0008;
		global::_0008_2004_2005 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		global::_000F_2006 obj3 = new global::_000F_2006();
		obj3._0002(_0002.m__0008_2003[obj2._0002()]);
		_0002._0008((global::_0006)obj3);
	}

	private static void _0002_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (6 == 0)
		{
		}
		_0002._0002(_0002: true, _0008: true);
	}

	private global::_0002_2006 _0002(global::_0002_2004_2005 _0002)
	{
		global::_0002_2006 obj = new global::_0002_2006();
		_ = 2;
		if (5 == 0)
		{
		}
		obj._0002(_0002._0005());
		_ = 7;
		if (6 == 0)
		{
		}
		obj._0002(_0002._0002());
		return obj;
	}

	private static void _000E_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (1 == 0)
		{
		}
		_ = 4;
		if (4 == 0)
		{
		}
		_0002._0006(((global::_0005_2007)_0008)._0002());
	}

	private static void _0006_2007_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (7u != 0)
		{
			obj2 = obj;
		}
		if (_0006(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2;
			if (6u != 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static void _000E_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (4u != 0)
		{
			type2 = type;
		}
		global::_0006 obj = global::_0006._0002(_0002._0002()._0006_2008_2009_0002(), type2);
		global::_0006 obj2;
		if (true)
		{
			obj2 = obj;
		}
		_0002._0008(obj2);
	}

	private static string _0002(string _0002, string _0008)
	{
		string fullName = typeof(global::_0006_2009).Assembly.FullName;
		string text;
		if (8u != 0)
		{
			text = fullName;
		}
		return global::_0008_0010._0002(-1463125703) + _0002 + global::_0008_0010._0002(-1463125717) + _0008 + global::_0008_0010._0002(-1463125539) + Environment.NewLine + Environment.NewLine + global::_0008_0010._0002(-1463125558) + text + global::_0008_0010._0002(-1463125507);
	}

	private static void _000F_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (4 == 0)
		{
		}
		_0002._0008((global::_0006)new global::_0005_2003());
	}

	private static void _000F_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 7;
		if (6 == 0)
		{
		}
		_0002._0005();
	}

	private static void _000E_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (1 == 0)
		{
		}
		_0002._0003(-1);
	}

	private string _0002(int _0002)
	{
		Dictionary<int, object> dictionary = global::_0006_2009.m__0005_2001;
		Dictionary<int, object> obj;
		if (3u != 0)
		{
			obj = dictionary;
		}
		bool lockTaken = default(bool);
		if (0 == 0)
		{
			lockTaken = false;
		}
		try
		{
			if (8u != 0)
			{
				Monitor.Enter(obj, ref lockTaken);
			}
			bool flag = true;
			if (flag && global::_0006_2009.m__0005_2001.TryGetValue(_0002, out var value))
			{
				return (string)value;
			}
			global::_0002 obj2 = this._0002(_0002);
			if (obj2._0002() == 0)
			{
				return this.m__000E_2007.ResolveString(obj2._0002());
			}
			string text = ((global::_0006_2008)obj2._0002())._0002();
			if (flag)
			{
				global::_0006_2009.m__0005_2001.Add(_0002, text);
			}
			return text;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private static global::_0006 _000F(global::_0006 _0002, global::_0006 _0008, bool _0006, bool _000F)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				if (!_000F)
				{
					int num = ((global::_000F)_0002)._0002();
					int num2;
					if (7u != 0)
					{
						num2 = num;
					}
					int num3 = ((global::_000F)_0008)._0002();
					int num4;
					if (2u != 0)
					{
						num4 = num3;
					}
					int num6;
					if (_0006)
					{
						int num5 = checked(num2 * num4);
						if (4u != 0)
						{
							num6 = num5;
						}
					}
					else
					{
						int num7 = num2 * num4;
						if (5u != 0)
						{
							num6 = num7;
						}
					}
					return new global::_000F(num6);
				}
				int num8 = ((global::_000F)_0002)._0002();
				uint num9;
				if (8u != 0)
				{
					num9 = (uint)num8;
				}
				int num10 = ((global::_000F)_0008)._0002();
				uint num11 = default(uint);
				if (0 == 0)
				{
					num11 = (uint)num10;
				}
				uint num13;
				if (_0006)
				{
					uint num12 = checked(num9 * num11);
					if (7u != 0)
					{
						num13 = num12;
					}
				}
				else
				{
					num13 = num9 * num11;
				}
				return new global::_000F((int)num13);
			}
			if (_0008._0002() == 13)
			{
				return global::_0006_2009._0002(new global::_0003_2000(((global::_000F)_0002)._0002()), _0008, _0006, _000F);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
				{
					return global::_0006_2009._0002(new global::_0003_2000(((global::_000F)_0002)._0002()), new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006, _000F);
				}
				return global::_0006_2009._000F(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006, _000F);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				return global::_0006_2009._0002(_0002, _0008, _0006, _000F);
			}
			if (_0008._0002() == 1)
			{
				return global::_0006_2009._0002(_0002, new global::_0003_2000(((global::_000F)_0008)._0002()), _0006, _000F);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType2 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return global::_0006_2009._0002(_0002, new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002())), _0006, _000F);
				}
				return global::_0006_2009._0002(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006, _000F);
			}
		}
		if (_0002._0002() == 8 && _0008._0002() == 8)
		{
			global::_0006_200A obj = new global::_0006_200A();
			obj._0002(((global::_0006_200A)_0002)._0002() * ((global::_0006_200A)_0008)._0002());
			return obj;
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong))
			{
				return global::_0006_2009._000F(new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008, _0006, _000F);
			}
			return global::_0006_2009._000F(new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008, _0006, _000F);
		}
		throw new InvalidOperationException();
	}

	private static global::_0006 _0005(global::_0006 _0002, global::_0006 _0008, bool _0006, bool _000F)
	{
		if (!_000F)
		{
			long num = ((global::_0003_2000)_0002)._0002();
			long num2;
			if (8u != 0)
			{
				num2 = num;
			}
			long num3 = ((global::_0003_2000)_0008)._0002();
			long num4;
			if (4u != 0)
			{
				num4 = num3;
			}
			long num6;
			if (_0006)
			{
				long num5 = checked(num2 - num4);
				if (6u != 0)
				{
					num6 = num5;
				}
			}
			else
			{
				num6 = num2 - num4;
			}
			return new global::_0003_2000(num6);
		}
		ulong num7 = (ulong)((global::_0003_2000)_0002)._0002();
		ulong num8 = (ulong)((global::_0003_2000)_0008)._0002();
		ulong num9 = ((!_0006) ? (num7 - num8) : checked(num7 - num8));
		return new global::_0003_2000((long)num9);
	}

	private static void _0002_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 1;
		if (7 == 0)
		{
		}
		_0002._000E(_0002: true);
	}

	private static void _0003_2003_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (6 == 0)
		{
		}
		_0002._0006(typeof(long));
	}

	private FieldInfo _0002(int _0002)
	{
		Dictionary<int, object> dictionary = global::_0006_2009.m__0005_2001;
		Dictionary<int, object> obj;
		if (true)
		{
			obj = dictionary;
		}
		bool lockTaken;
		if (7u != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (0 == 0)
			{
				Monitor.Enter(obj, ref lockTaken);
			}
			bool flag = true;
			FieldInfo fieldInfo;
			if (flag && global::_0006_2009.m__0005_2001.TryGetValue(_0002, out var value))
			{
				fieldInfo = (FieldInfo)value;
			}
			else
			{
				global::_0002 obj2 = this._0002(_0002);
				fieldInfo = this._0002(_0002, obj2, ref flag);
				if (flag)
				{
					global::_0006_2009.m__0005_2001.Add(_0002, fieldInfo);
				}
			}
			this._0002(fieldInfo);
			return fieldInfo;
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
	}

	private static void _000F_200B(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		if (_000F(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2;
			if (2u != 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static void _0005_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (uint.MaxValue != 0)
		{
			obj4 = obj3;
		}
		_0002._0008((global::_0006)new global::_000F(_0006(obj4, obj2) ? 1 : 0));
	}

	private long _0008()
	{
		_ = 8;
		if (1 == 0)
		{
		}
		long num = this.m__000F_2007._0002()._0005_2008_2009_0008();
		_ = 1;
		if (3 == 0)
		{
		}
		return num + this.m__0002_2004;
	}

	private static bool _0002(MethodBase _0002)
	{
		ParameterInfo[] parameters = _0002.GetParameters();
		ParameterInfo[] array;
		if (5u != 0)
		{
			array = parameters;
		}
		int num;
		if (uint.MaxValue != 0)
		{
			num = 0;
		}
		while (num < array.Length)
		{
			if (array[num].ParameterType.IsByRef)
			{
				return true;
			}
			int num2 = num + 1;
			if (7u != 0)
			{
				num = num2;
			}
		}
		return false;
	}

	private Stack<_000F_2004> _0002()
	{
		Stack<_000F_2004> stack = this.m__0002_2001;
		Stack<_000F_2004> stack2;
		if (3u != 0)
		{
			stack2 = stack;
		}
		if (stack2 == null)
		{
			Stack<_000F_2004> stack3 = new Stack<_000F_2004>();
			if (true)
			{
				stack2 = stack3;
			}
			if (4u != 0)
			{
				this.m__0002_2001 = stack3;
			}
			stack2.Push(new _000F_2004
			{
				_0008 = this.m__000F_2007,
				_0006 = this.m__000F_2007._0002(),
				_000F = this.m__0002_2004
			});
		}
		return stack2;
	}

	private static void _0005_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (-1 == 0)
		{
		}
		_0002._000F(2);
	}

	private static void _0008_2007_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (4 == 0)
		{
		}
		_0002._0006(typeof(float));
	}

	private static void _0006_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (8 == 0)
		{
		}
		_0002._0006(_0002: true, _0008: false);
	}

	private static string _0002(MethodBase _0002)
	{
		Type declaringType = _0002.DeclaringType;
		Type type;
		if (5u != 0)
		{
			type = declaringType;
		}
		ParameterInfo[] parameters = _0002.GetParameters();
		ParameterInfo[] array;
		if (uint.MaxValue != 0)
		{
			array = parameters;
		}
		string[] array2 = new string[array.Length];
		string[] array3;
		if (7u != 0)
		{
			array3 = array2;
		}
		for (int i = 0; i < array.Length; i++)
		{
			ParameterInfo parameterInfo = array[i];
			array3[i] = string.Format(global::_0008_0010._0002(-1463124126), parameterInfo.ParameterType, parameterInfo.Name);
		}
		string text = string.Join(global::_0008_0010._0002(-1463125730), array3);
		return type.FullName + global::_0008_0010._0002(-1463125804) + _0002.Name + global::_0008_0010._0002(-1463125751) + text + global::_0008_0010._0002(-1463125711);
	}

	private static void _0002_2004(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (2 == 0)
		{
		}
		_0002._0002(_0002: false, _0008: false);
	}

	private void _000F_2004(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		bool num = IntPtr.Size == 4;
		bool flag;
		if (2u != 0)
		{
			flag = num;
		}
		int num2 = obj2._0002();
		int num3;
		if (uint.MaxValue != 0)
		{
			num3 = num2;
		}
		checked
		{
			IntPtr intPtr;
			switch (num3)
			{
			case 1:
			{
				int num4 = ((global::_000F)obj2)._0002();
				int num5;
				if (8u != 0)
				{
					num5 = num4;
				}
				intPtr = ((!flag) ? ((!_0002) ? new IntPtr(unchecked((uint)num5)) : new IntPtr((uint)num5)) : ((!_0002) ? new IntPtr(num5) : new IntPtr((int)(uint)num5)));
				break;
			}
			case 13:
			{
				long num6 = ((global::_0003_2000)obj2)._0002();
				intPtr = ((!flag) ? ((!_0002) ? new IntPtr(num6) : new IntPtr((long)(ulong)num6)) : ((!_0002) ? new IntPtr(unchecked((int)num6)) : new IntPtr((int)(ulong)num6)));
				break;
			}
			case 8:
			{
				double num7 = ((global::_0006_200A)obj2)._0002();
				intPtr = ((!flag) ? ((!_0002) ? new IntPtr(unchecked((long)num7)) : new IntPtr((long)(ulong)num7)) : ((!_0002) ? new IntPtr(unchecked((int)(ulong)num7)) : new IntPtr((int)(ulong)num7)));
				break;
			}
			case 19:
				intPtr = ((!_0002) ? new IntPtr(Convert.ToInt64(((global::_0002_0010)obj2)._0002())) : new IntPtr(Convert.ToInt64(((global::_0002_0010)obj2)._0002())));
				break;
			default:
				throw new InvalidOperationException();
			}
			global::_0006_2002 obj3 = new global::_0006_2002();
			obj3._0002(intPtr);
			_0008((global::_0006)obj3);
		}
	}

	private static void _0008_2001(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (-1 == 0)
		{
		}
		_0002._0002(typeof(long));
	}

	private static void _0008_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		Array obj = (Array)_0002._0002()._0006_2008_2009_0002();
		Array array;
		if (2u != 0)
		{
			array = obj;
		}
		_0002._0008((global::_0006)new global::_000F(array.Length));
	}

	private static void _0008_2001_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (3 == 0)
		{
		}
		_0002._0008(typeof(float));
	}

	private long _0002()
	{
		global::_0006 obj = _0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 1:
		{
			long result = ((global::_000F)obj2)._0002();
			if (uint.MaxValue != 0)
			{
				return result;
			}
			long result2;
			return result2;
		}
		case 0:
			return ((global::_0006_2002)obj2)._0002().ToInt64();
		case 20:
			return (long)((global::_0002_2003)obj2)._0002().ToUInt64();
		case 19:
			return Convert.ToInt64(((global::_0002_0010)obj2)._0002());
		default:
			throw new Exception(global::_0008_0010._0002(-1463125036));
		}
	}

	private void _0008()
	{
		if (!this.m__0003._0002())
		{
			return;
		}
		Type type = _0002(this.m__0003._0002(), _0008: false);
		Type type2;
		if (true)
		{
			type2 = type;
		}
		if (type2 != null)
		{
			RuntimeTypeHandle typeHandle = type2.TypeHandle;
			if (8u != 0)
			{
				RuntimeHelpers.RunClassConstructor(typeHandle);
			}
		}
	}

	private static void _000E_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 2;
		if (1 == 0)
		{
		}
		_0002._0002_2004(_0002: false);
	}

	private static void _0003_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463124997));
	}

	private static void _000F_2008_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463124342));
	}

	private static global::_0006 _0008(global::_0006 _0002, global::_0006 _0008, bool _0006)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				if (!_0006)
				{
					int num = ((global::_000F)_0002)._0002();
					int num2 = ((global::_000F)_0008)._0002();
					int num3;
					if (6u != 0)
					{
						num3 = num2;
					}
					return new global::_000F(num >> num3);
				}
				int num4 = ((global::_000F)_0002)._0002();
				int num5 = ((global::_000F)_0008)._0002();
				int num6;
				if (8u != 0)
				{
					num6 = num5;
				}
				return new global::_000F(num4 >>> num6);
			}
			if (_0008._0002() == 19)
			{
				return global::_0006_2009._0008(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 1)
			{
				if (!_0006)
				{
					long num7 = ((global::_0003_2000)_0002)._0002();
					int num8 = ((global::_000F)_0008)._0002();
					int num9;
					if (8u != 0)
					{
						num9 = num8;
					}
					return new global::_0003_2000(num7 >> num9);
				}
				long num10 = ((global::_0003_2000)_0002)._0002();
				int num11 = ((global::_000F)_0008)._0002();
				int num12;
				if (7u != 0)
				{
					num12 = num11;
				}
				return new global::_0003_2000(num10 >>> num12);
			}
			if (_0008._0002() == 19)
			{
				return global::_0006_2009._0008(_0002, new global::_000F(Convert.ToInt32(_0008._0006_2008_2009_0002())), _0006);
			}
		}
		if (_0002._0002() == 19)
		{
			Type underlyingType = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
			if (underlyingType == typeof(long) || underlyingType == typeof(ulong))
			{
				return global::_0006_2009._0008(new global::_0003_2000(Convert.ToInt64(_0002._0006_2008_2009_0002())), _0008, _0006);
			}
			return global::_0006_2009._0008(new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002())), _0008, _0006);
		}
		throw new InvalidOperationException();
	}

	private static void _0008_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_000F obj = (global::_000F)_0008;
		global::_000F obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = _0002._0002(obj2._0002());
		MethodBase methodBase2 = default(MethodBase);
		if (0 == 0)
		{
			methodBase2 = methodBase;
		}
		Type declaringType = methodBase2.DeclaringType;
		Type type = default(Type);
		if (0 == 0)
		{
			type = declaringType;
		}
		Type type2 = _0002._0002()._0006_2008_2009_0002().GetType();
		ParameterInfo[] parameters = methodBase2.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		MethodBase methodBase3 = null;
		Type type3 = type2;
		while (type3 != null && type3 != type)
		{
			MethodInfo method = type3.GetMethod(methodBase2.Name, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.ExactBinding, null, CallingConventions.Any, array, null);
			if (method != null && method.GetBaseDefinition() == methodBase2)
			{
				methodBase3 = method;
				break;
			}
			type3 = type3.BaseType;
		}
		if (methodBase3 == null)
		{
			methodBase3 = methodBase2;
		}
		global::_000F_2004_2005 obj3 = new global::_000F_2004_2005();
		obj3._0002(methodBase3);
		_0002._0008((global::_0006)obj3);
	}

	private static void _0005_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		checked
		{
			sbyte b;
			switch (num2)
			{
			case 1:
			{
				sbyte num3 = (sbyte)(uint)((global::_000F)obj2)._0002();
				if (uint.MaxValue != 0)
				{
					b = num3;
				}
				break;
			}
			case 13:
				b = (sbyte)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				b = (sbyte)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				b = (sbyte)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				b = ((IntPtr.Size != 4) ? ((sbyte)(ulong)(long)((global::_0006_2002)obj2)._0002()) : ((sbyte)(uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0002._0008((global::_0006)new global::_000F(b));
		}
	}

	private static void _0002_2002_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2 = default(global::_0006);
		if (0 == 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (true)
		{
			num2 = num;
		}
		checked
		{
			short num3;
			switch (num2)
			{
			case 1:
			{
				short num4 = (short)(uint)((global::_000F)obj2)._0002();
				if (uint.MaxValue != 0)
				{
					num3 = num4;
				}
				break;
			}
			case 13:
				num3 = (short)(ulong)((global::_0003_2000)obj2)._0002();
				break;
			case 19:
				num3 = (short)Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
				break;
			case 8:
				num3 = (short)((global::_0006_200A)obj2)._0002();
				break;
			case 0:
				num3 = ((IntPtr.Size != 4) ? ((short)(ulong)(long)((global::_0006_2002)obj2)._0002()) : ((short)(uint)(int)((global::_0006_2002)obj2)._0002()));
				break;
			default:
				throw new InvalidOperationException();
			}
			_0002._0008((global::_0006)new global::_000F(num3));
		}
	}

	private void _0002_2004(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = this._0002();
		global::_0006 obj4;
		if (8u != 0)
		{
			obj4 = obj3;
		}
		global::_0006 obj5 = _0006(obj4, obj2, _0002);
		if (3u != 0)
		{
			_0008(obj5);
		}
	}

	private global::_0006 _0002()
	{
		global::_0006 obj = this.m__000E;
		global::_0006 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		if (obj2 != null)
		{
			global::_0006 obj3 = this.m__0002;
			if (6u != 0)
			{
				this.m__000E = obj3;
			}
			if (true)
			{
				this.m__0002 = null;
			}
			return obj2;
		}
		return this.m__0002_2009.Pop();
	}

	private global::_0006 _0008(global::_0006 _0002, global::_0006 _0008)
	{
		if (_0002._0002() == 1)
		{
			if (_0008._0002() == 1)
			{
				int num = ((global::_000F)_0002)._0002();
				int num2 = ((global::_000F)_0008)._0002();
				int num3;
				if (true)
				{
					num3 = num2;
				}
				return new global::_000F(num | num3);
			}
			if (_0008._0002() == 19)
			{
				int num4 = ((global::_000F)_0002)._0002();
				int num5;
				if (6u != 0)
				{
					num5 = num4;
				}
				Type underlyingType = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				Type type;
				if (4u != 0)
				{
					type = underlyingType;
				}
				if (type == typeof(long) || type == typeof(ulong))
				{
					long num6 = Convert.ToInt64(_0008._0006_2008_2009_0002());
					long num7;
					if (6u != 0)
					{
						num7 = num6;
					}
					return new global::_0003_2000(num5 | num7);
				}
				int num8 = Convert.ToInt32(_0008._0006_2008_2009_0002());
				int num9;
				if (2u != 0)
				{
					num9 = num8;
				}
				return new global::_000F(num5 | num9);
			}
		}
		if (_0002._0002() == 13)
		{
			if (_0008._0002() == 13)
			{
				long num10 = ((global::_0003_2000)_0002)._0002();
				long num11 = ((global::_0003_2000)_0008)._0002();
				long num12 = default(long);
				if (0 == 0)
				{
					num12 = num11;
				}
				return new global::_0003_2000(num10 | num12);
			}
			if (_0008._0002() == 19)
			{
				int num13 = ((global::_000F)_0002)._0002();
				long num14 = Convert.ToInt64(_0008._0006_2008_2009_0002());
				return new global::_0003_2000(num13 | num14);
			}
		}
		if (_0002._0002() == 19)
		{
			if (_0008._0002() == 1)
			{
				int num15 = ((global::_000F)_0008)._0002();
				Type underlyingType2 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
				if (underlyingType2 == typeof(long) || underlyingType2 == typeof(ulong))
				{
					return new global::_0003_2000(Convert.ToInt64(_0008._0006_2008_2009_0002()) | num15);
				}
				return new global::_000F(Convert.ToInt32(_0002._0006_2008_2009_0002()) | num15);
			}
			if (_0008._0002() == 13)
			{
				long num16 = Convert.ToInt64(_0002._0006_2008_2009_0002());
				long num17 = ((global::_0003_2000)_0008)._0002();
				return new global::_0003_2000(num16 | num17);
			}
			if (_0008._0002() == 19)
			{
				Type underlyingType3 = Enum.GetUnderlyingType(_0002._0006_2008_2009_0002().GetType());
				Type underlyingType4 = Enum.GetUnderlyingType(_0008._0006_2008_2009_0002().GetType());
				if (underlyingType3 == typeof(long) || underlyingType3 == typeof(ulong) || underlyingType4 == typeof(long) || underlyingType4 == typeof(ulong))
				{
					long num18 = Convert.ToInt64(_0002._0006_2008_2009_0002());
					long num19 = Convert.ToInt64(_0008._0006_2008_2009_0002());
					return new global::_0003_2000(num18 | num19);
				}
				int num20 = Convert.ToInt32(_0002._0006_2008_2009_0002());
				int num21 = Convert.ToInt32(_0008._0006_2008_2009_0002());
				return new global::_000F(num20 | num21);
			}
		}
		throw new InvalidOperationException();
	}

	private static void _0002_2001_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (5 == 0)
		{
		}
		_0002._0003(_0002: true);
	}

	private void _0002(MethodBase _0002, bool _0008)
	{
		bool num = !_0008 && this._0002(_0002);
		bool flag;
		if (3u != 0)
		{
			flag = num;
		}
		if (flag && global::_0006_2009._0003._0002)
		{
			MethodBase methodBase = global::_0006_2009._0002_2004._0002(this, this.m__0003, _0002, _0008);
			if (true)
			{
				_0002 = methodBase;
			}
		}
		ParameterInfo[] parameters = _0002.GetParameters();
		ParameterInfo[] array;
		if (true)
		{
			array = parameters;
		}
		int num2 = array.Length;
		int num3;
		if (2u != 0)
		{
			num3 = num2;
		}
		global::_0006[] array2 = new global::_0006[num3];
		global::_0006[] array3;
		if (3u != 0)
		{
			array3 = array2;
		}
		object[] array4 = new object[num3];
		object[] array5;
		if (3u != 0)
		{
			array5 = array4;
		}
		_000E_2004 obj = default(_000E_2004);
		try
		{
			MethodBase methodBase2 = _0002;
			if (uint.MaxValue != 0)
			{
				this._0002(ref obj, methodBase2, _0008);
			}
			int num4 = num3 - 1;
			int num5;
			if (7u != 0)
			{
				num5 = num4;
			}
			while (num5 >= 0)
			{
				global::_0006 obj2 = this._0002();
				global::_0006 obj3;
				if (4u != 0)
				{
					obj3 = obj2;
				}
				array3[num5] = obj3;
				if (obj3 is global::_0002_2004 obj4)
				{
					obj3 = this._0002(obj4);
				}
				if (obj3._0002() != null)
				{
					obj3 = global::_0006._0002(null, obj3._0002())._0006_2008_2009_0002(obj3);
				}
				global::_0006 obj5 = global::_0006._0002(null, array[num5].ParameterType)._0006_2008_2009_0002(obj3);
				array5[num5] = obj5._0006_2008_2009_0002();
				num5--;
			}
			global::_0006 obj6 = null;
			if (!_0002.IsStatic)
			{
				obj6 = this._0002();
				if (obj6 != null && obj6._0002() != null)
				{
					obj6 = global::_0006._0002(null, obj6._0002())._0006_2008_2009_0002(obj6);
				}
			}
			object obj7 = null;
			object obj8 = null;
			try
			{
				if (_0002.IsConstructor)
				{
					obj7 = Activator.CreateInstance(_0002.DeclaringType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array5, null);
					if (!(obj6 is global::_0002_2004))
					{
						throw new InvalidOperationException();
					}
					obj8 = obj7;
				}
				else
				{
					if (obj6 != null)
					{
						global::_0006 obj9 = obj6;
						if (obj6 is global::_0002_2004 obj10)
						{
							obj9 = this._0002(obj10);
						}
						obj8 = obj9._0006_2008_2009_0002();
					}
					try
					{
						if (!this._0002(_0002, obj8, ref obj7, array5))
						{
							if (_0008 && !_0002.IsStatic && obj8 == null)
							{
								throw new NullReferenceException();
							}
							if (!this._0002(_0002, obj8, array3, array5, _0008, ref obj7))
							{
								MethodBase methodBase3 = _0002;
								object obj11 = obj8;
								if (flag && !global::_0006_2009._0003._0002)
								{
									obj11 = global::_0006_2009._0002_2007._0002(obj8, _0002, out var methodInfo);
									methodBase3 = methodInfo;
								}
								obj7 = global::_0006_2009._0008(methodBase3, obj11, array5, _0008);
							}
						}
					}
					catch (TargetInvocationException ex)
					{
						Exception ex2 = ex.InnerException ?? ex;
						this._0002((object)ex2);
					}
				}
			}
			finally
			{
				for (int i = 0; i < array3.Length; i++)
				{
					if (array3[i] is global::_0002_2004 obj12)
					{
						object obj13 = array5[i];
						this._0002(obj12, global::_0006._0002(obj13, null));
					}
				}
				if (obj8 != null && obj6 is global::_0002_2004 obj14)
				{
					bool flag2 = true;
					if (obj14 is global::_000E_200B obj15)
					{
						flag2 = this._0002(obj15);
					}
					if (flag2)
					{
						this._0002(obj14, global::_0006._0002(obj8, _0002.DeclaringType));
					}
				}
			}
			MethodInfo methodInfo2 = _0002 as MethodInfo;
			if (methodInfo2 != null)
			{
				Type returnType = methodInfo2.ReturnType;
				if (returnType != global::_0006_2009.m__0003_2009)
				{
					this._0008(global::_0006._0002(obj7, returnType));
				}
			}
		}
		finally
		{
			this._0002(ref obj);
		}
	}

	private static void _0008_2007(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		FieldInfo fieldInfo = _0002._0002(num2);
		FieldInfo fieldInfo2 = default(FieldInfo);
		if (0 == 0)
		{
			fieldInfo2 = fieldInfo;
		}
		global::_0006 obj = global::_0006._0002(_0002._0002()._0006_2008_2009_0002(), fieldInfo2.FieldType);
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		fieldInfo2.SetValue(null, obj2._0006_2008_2009_0002());
	}

	private object _0002(int _0002)
	{
		int num = global::_000F_2009._0002(_0002);
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 16777216:
		case 33554432:
		case 452984832:
		{
			ModuleHandle moduleHandle = this.m__000E_2007.ModuleHandle;
			ModuleHandle moduleHandle2;
			if (2u != 0)
			{
				moduleHandle2 = moduleHandle;
			}
			object result = moduleHandle2.ResolveTypeHandle(_0002);
			if (4u != 0)
			{
				return result;
			}
			object result2;
			return result2;
		}
		case 67108864:
			return this.m__000E_2007.ModuleHandle.ResolveFieldHandle(_0002);
		case 100663296:
		case 721420288:
			return this.m__000E_2007.ModuleHandle.ResolveMethodHandle(_0002);
		case 167772160:
			try
			{
				return this.m__000E_2007.ModuleHandle.ResolveFieldHandle(_0002);
			}
			catch
			{
				try
				{
					return this.m__000E_2007.ModuleHandle.ResolveMethodHandle(_0002);
				}
				catch
				{
					throw new InvalidOperationException();
				}
			}
		default:
			throw new InvalidOperationException();
		}
	}

	private void _0002(Stream _0002, string _0008)
	{
		long num = 0L;
		if (7u != 0)
		{
			this._0002(_0002, num, _0008);
		}
	}

	private static global::_0006 _0002(global::_0006 _0002, global::_0006 _0008, bool _0006, bool _000F)
	{
		if (!_000F)
		{
			long num = ((global::_0003_2000)_0002)._0002();
			long num2;
			if (4u != 0)
			{
				num2 = num;
			}
			long num3 = ((global::_0003_2000)_0008)._0002();
			long num4 = default(long);
			if (0 == 0)
			{
				num4 = num3;
			}
			long num6;
			if (_0006)
			{
				long num5 = checked(num2 * num4);
				if (3u != 0)
				{
					num6 = num5;
				}
			}
			else
			{
				num6 = num2 * num4;
			}
			return new global::_0003_2000(num6);
		}
		ulong num7 = (ulong)((global::_0003_2000)_0002)._0002();
		ulong num8 = (ulong)((global::_0003_2000)_0008)._0002();
		ulong num9 = ((!_0006) ? (num7 * num8) : checked(num7 * num8));
		return new global::_0003_2000((long)num9);
	}

	private void _0002(global::_0003_2004_2005 _0002)
	{
		if (global::_0006_2009._0002() && !this.m__0003._0008() && _0002._0008() && !_0002._0006())
		{
			string text = this._0002(_0002);
			string text2;
			if (8u != 0)
			{
				text2 = text;
			}
			throw _0008(this._0002(this.m__0003), text2);
		}
	}

	private static void _000F_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (8 == 0)
		{
		}
		_0002._0002(typeof(int));
	}

	private long _0002(string _0002)
	{
		MemoryStream memoryStream = new MemoryStream(global::_0003_200A._0002(_0002));
		MemoryStream memoryStream2;
		if (3u != 0)
		{
			memoryStream2 = memoryStream;
		}
		long result = new global::_0002_2004_2005(new global::_0006_2000(memoryStream2, this._0002()))._0002();
		memoryStream2.Dispose();
		return result;
	}

	private static void _0006_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = -1;
		if (-1 == 0)
		{
		}
		_0002._000F_2004(_0002: false);
	}

	private void _0002(long _0002)
	{
		_ = -1;
		if (false)
		{
		}
		global::_0005 obj = this.m__000F_2007._0002();
		_ = 2;
		if (false)
		{
		}
		_ = 3;
		if (3 == 0)
		{
		}
		obj._0005_2008_2009_0002(_0002 - this.m__0002_2004);
	}

	private void _0003()
	{
		if (this.m__000F.Count == 0)
		{
			if (this.m__0005_2009)
			{
				object obj = this.m__0008_2007;
				if (uint.MaxValue != 0)
				{
					_0002(obj);
				}
			}
			return;
		}
		_0008 obj2 = this.m__000F.Pop();
		_0008 obj3;
		if (5u != 0)
		{
			obj3 = obj2;
		}
		if (obj3._0002() != null)
		{
			global::_0005_2003 obj4 = new global::_0005_2003();
			obj4._0006_2008_2009_0002(obj3._0002());
			if (5u != 0)
			{
				_0008((global::_0006)obj4);
			}
		}
		else
		{
			_0008_2004();
		}
		_0002(obj3._0002());
	}

	private static void _0006_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		if (!global::_0006_2009._0002(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2 = default(uint);
			if (0 == 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private int _0008()
	{
		return 1772446022;
	}

	private void _0008(bool _0002)
	{
		global::_0006 obj = this._0002();
		global::_0006 obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		uint num3;
		switch (num2)
		{
		case 1:
			if (_0002)
			{
				uint num4 = checked((uint)((global::_000F)obj2)._0002());
				if (3u != 0)
				{
					num3 = num4;
				}
			}
			else
			{
				ushort num5 = (ushort)((global::_000F)obj2)._0002();
				if (7u != 0)
				{
					num3 = num5;
				}
			}
			break;
		case 13:
			if (_0002)
			{
				uint num6 = checked((uint)((global::_0003_2000)obj2)._0002());
				if (true)
				{
					num3 = num6;
				}
			}
			else
			{
				num3 = (uint)((global::_0003_2000)obj2)._0002();
			}
			break;
		case 19:
			num3 = (uint)((!_0002) ? Convert.ToUInt64(((global::_0002_0010)obj2)._0002()) : checked((uint)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())));
			break;
		case 8:
			num3 = ((!_0002) ? ((uint)((global::_0006_200A)obj2)._0002()) : checked((uint)((global::_0006_200A)obj2)._0002()));
			break;
		case 0:
			num3 = (uint)((IntPtr.Size != 4) ? ((!_0002) ? ((long)((global::_0006_2002)obj2)._0002()) : checked((uint)(ulong)(long)((global::_0006_2002)obj2)._0002())) : ((!_0002) ? ((uint)(int)((global::_0006_2002)obj2)._0002()) : checked((uint)(int)((global::_0006_2002)obj2)._0002())));
			break;
		case 20:
			num3 = (uint)((UIntPtr.Size != 4) ? ((!_0002) ? ((ulong)((global::_0002_2003)obj2)._0002()) : checked((uint)(ulong)((global::_0002_2003)obj2)._0002())) : ((!_0002) ? ((uint)((global::_0002_2003)obj2)._0002()) : ((uint)((global::_0002_2003)obj2)._0002())));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0008((global::_0006)new global::_000F((int)num3));
	}

	[DebuggerNonUserCode]
	private MethodBase _0002(int _0002, global::_0002 _0008)
	{
		Dictionary<int, object> dictionary = global::_0006_2009.m__0005_2001;
		Dictionary<int, object> obj;
		if (6u != 0)
		{
			obj = dictionary;
		}
		bool lockTaken;
		if (6u != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (6u != 0)
			{
				Monitor.Enter(obj, ref lockTaken);
			}
			bool flag;
			if (5u != 0)
			{
				flag = true;
			}
			if (flag && global::_0006_2009.m__0005_2001.TryGetValue(_0002, out var value))
			{
				MethodBase result = (MethodBase)value;
				if (2u != 0)
				{
					return result;
				}
			}
			else
			{
				if (_0008._0002() != 0)
				{
					global::_0005_2006 obj2 = (global::_0005_2006)_0008._0002();
					if (obj2._0008())
					{
						return this._0002(obj2);
					}
					Type type = this._0002(obj2._0002()._0002(), _0008: false);
					Type type2 = this._0002(obj2._0008()._0002(), _0008: true);
					Type[] array = new Type[obj2._0002().Length];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = this._0002(obj2._0002()[i]._0002(), _0008: true);
					}
					if (type.IsGenericType)
					{
						flag = false;
					}
					if (obj2._0002() == global::_0008_0010._0002(-1463125095))
					{
						ConstructorInfo constructorInfo = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, CallingConventions.Any, array, null) ?? throw new Exception();
						if (flag)
						{
							global::_0006_2009.m__0005_2001.Add(_0002, constructorInfo);
						}
						return constructorInfo;
					}
					BindingFlags bindingAttr = global::_0006_2009._0002(obj2._0002());
					MethodBase methodBase = null;
					try
					{
						methodBase = type.GetMethod(obj2._0002(), bindingAttr, null, CallingConventions.Any, array, null);
					}
					catch (AmbiguousMatchException)
					{
						MethodInfo[] methods = type.GetMethods(bindingAttr);
						foreach (MethodInfo methodInfo in methods)
						{
							if (methodInfo.Name != obj2._0002() || methodInfo.ReturnType != type2)
							{
								continue;
							}
							ParameterInfo[] parameters = methodInfo.GetParameters();
							if (parameters.Length != array.Length)
							{
								continue;
							}
							bool flag2 = false;
							for (int k = 0; k < array.Length; k++)
							{
								if (parameters[k].ParameterType != array[k])
								{
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								methodBase = methodInfo;
								break;
							}
						}
					}
					if (methodBase == null)
					{
						throw new Exception(string.Format(global::_0008_0010._0002(-1463125115), type.Name, obj2._0002()));
					}
					if (flag)
					{
						global::_0006_2009.m__0005_2001.Add(_0002, methodBase);
					}
					return methodBase;
				}
				MethodBase methodBase2 = this.m__000E_2007.ResolveMethod(_0008._0002());
				MethodBase methodBase3;
				if (uint.MaxValue != 0)
				{
					methodBase3 = methodBase2;
				}
				if (flag)
				{
					global::_0006_2009.m__0005_2001.Add(_0002, methodBase3);
				}
				if (4u != 0)
				{
					return methodBase3;
				}
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj);
			}
		}
		MethodBase result2;
		return result2;
	}

	private static bool _0002(object _0002)
	{
		_ = 4;
		if (6 == 0)
		{
		}
		return RemotingServices.IsTransparentProxy(_0002);
	}

	private static void _0005_2008(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 0;
		if (4 == 0)
		{
		}
		_0002._0006(_0002: false, _0008: false);
	}

	private bool _0002(MethodBase _0002)
	{
		_ = 6;
		if (1 == 0)
		{
		}
		if (!_0002.IsVirtual)
		{
			return false;
		}
		_ = -1;
		if (3 == 0)
		{
		}
		_ = 6;
		if (-1 == 0)
		{
		}
		if (this._0002(this.m__0003._0002(), _0008: true).IsSubclassOf(_0002.DeclaringType))
		{
			return true;
		}
		return false;
	}

	private bool _0002(MethodInfo _0002, global::_0005_2006 _0008, Type[] _0006, out int _000F)
	{
		_000F = 0;
		if (!_0002.IsGenericMethodDefinition)
		{
			return false;
		}
		ParameterInfo[] parameters = _0002.GetParameters();
		ParameterInfo[] array;
		if (6u != 0)
		{
			array = parameters;
		}
		if (array.Length != _0008._0002().Length)
		{
			return false;
		}
		if (_0002.GetGenericArguments().Length != _0008._0008().Length)
		{
			return false;
		}
		int i;
		if (4u != 0)
		{
			i = -1;
		}
		for (; i < array.Length; i++)
		{
			Type obj = ((i == -1) ? _0002.ReturnType : array[i].ParameterType);
			Type type;
			if (6u != 0)
			{
				type = obj;
			}
			if (_0006 != null && type.IsGenericParameter && type.DeclaringMethod != null)
			{
				type = _0006[type.GenericParameterPosition] ?? type;
			}
			global::_0002 obj2 = ((i == -1) ? _0008._0008() : _0008._0002()[i]);
			if (obj2 != null)
			{
				if (!this._0002(type, obj2, out var num))
				{
					return false;
				}
				if (i >= 0)
				{
					_000F += num;
				}
			}
		}
		return true;
	}

	private static void _0003_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 5;
		if (2 == 0)
		{
		}
		_0002._0008(_0002: true, _0008: false);
	}

	private global::_0005_2008 _0002(global::_0002_2004_2005 _0002)
	{
		global::_0005_2008 obj = new global::_0005_2008();
		_ = 4;
		if (8 == 0)
		{
		}
		obj._0002(_0002._0005());
		return obj;
	}

	private static void _000E_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		ulong num3;
		switch (num2)
		{
		case 1:
		{
			long num4 = (uint)((global::_000F)obj2)._0002();
			if (2u != 0)
			{
				num3 = (ulong)num4;
			}
			break;
		}
		case 13:
			num3 = (ulong)((global::_0003_2000)obj2)._0002();
			break;
		case 19:
			num3 = Convert.ToUInt64(((global::_0002_0010)obj2)._0002());
			break;
		case 8:
			num3 = checked((ulong)((global::_0006_200A)obj2)._0002());
			break;
		case 0:
			num3 = (ulong)((IntPtr.Size != 4) ? ((long)((global::_0006_2002)obj2)._0002()) : ((uint)(int)((global::_0006_2002)obj2)._0002()));
			break;
		default:
			throw new InvalidOperationException();
		}
		_0002._0008((global::_0006)new global::_0003_2000((long)num3));
	}

	private static void _0005_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		UIntPtr uIntPtr = num2 switch
		{
			1 => new UIntPtr((uint)((global::_000F)obj2)._0002()), 
			13 => new UIntPtr((ulong)((global::_0003_2000)obj2)._0002()), 
			19 => new UIntPtr(Convert.ToUInt64(((global::_0002_0010)obj2)._0002())), 
			8 => new UIntPtr((ulong)((global::_0006_200A)obj2)._0002()), 
			_ => throw new InvalidOperationException(), 
		};
		global::_0002_2003 obj3 = new global::_0002_2003();
		obj3._0002(uIntPtr);
		_0002._0008((global::_0006)obj3);
	}

	private static void _0006_2003_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		if (!_000F(_0002._0002(), obj2))
		{
			uint num = ((global::_000F_2001)_0008)._0002();
			uint num2;
			if (8u != 0)
			{
				num2 = num;
			}
			_0002._0002(num2);
		}
	}

	private static bool _0002(uint _0002, uint _0008, uint _0006)
	{
		_ = 3;
		if (4 == 0)
		{
		}
		_ = 6;
		if (1 == 0)
		{
		}
		if (_0002 >= _0008)
		{
			_ = 6;
			if (6 == 0)
			{
			}
			return _0002 <= _0008 + _0006;
		}
		return false;
	}

	private void _0008(global::_0006 _0002)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463125643));
		}
		global::_0006 obj;
		if (_0002._0002() != null)
		{
			if (uint.MaxValue != 0)
			{
				obj = _0002;
			}
		}
		else
		{
			int num = _0002._0002();
			int num2;
			if (true)
			{
				num2 = num;
			}
			switch (num2)
			{
			case 22:
			{
				global::_0006_200A obj9 = new global::_0006_200A();
				obj9._0002(((global::_000F_200B)_0002)._0002());
				obj9._0002(_0002._0002());
				if (true)
				{
					obj = obj9;
				}
				break;
			}
			case 12:
			{
				global::_000F obj10 = new global::_000F(((global::_0008_2004_2005)_0002)._0002());
				obj10._0002(_0002._0002());
				if (8u != 0)
				{
					obj = obj10;
				}
				break;
			}
			case 26:
			{
				global::_000F obj8 = new global::_000F(((global::_000E_2009)_0002)._0002());
				obj8._0002(_0002._0002());
				if (2u != 0)
				{
					obj = obj8;
				}
				break;
			}
			case 17:
			{
				global::_000F obj11 = new global::_000F(((global::_0003_2001)_0002)._0002());
				obj11._0002(_0002._0002());
				obj = obj11;
				break;
			}
			case 16:
			{
				global::_000F obj6 = new global::_000F(((global::_0005_2007)_0002)._0002());
				obj6._0002(_0002._0002());
				obj = obj6;
				break;
			}
			case 3:
			{
				global::_000F obj5 = new global::_000F((int)((global::_000F_2001)_0002)._0002());
				obj5._0002(_0002._0002());
				obj = obj5;
				break;
			}
			case 14:
			{
				global::_0003_2000 obj7 = new global::_0003_2000((long)((global::_000E_2006)_0002)._0002());
				obj7._0002(_0002._0002());
				obj = obj7;
				break;
			}
			case 15:
			{
				global::_000F obj4 = new global::_000F(((global::_0005_200A)_0002)._0002() ? 1 : 0);
				obj4._0002(_0002._0002());
				obj = obj4;
				break;
			}
			case 6:
			{
				global::_000F obj3 = new global::_000F(((global::_000E_200A)_0002)._0002());
				obj3._0002(_0002._0002());
				obj = obj3;
				break;
			}
			case 7:
			{
				object obj2 = _0002._0006_2008_2009_0002();
				if (obj2 == null)
				{
					obj = _0002;
					break;
				}
				Type type = obj2.GetType();
				if (type.HasElementType && !type.IsArray)
				{
					type = type.GetElementType();
				}
				obj = ((!(type != null) || type.IsValueType || type.IsEnum) ? global::_0006._0002(obj2, type) : _0002);
				break;
			}
			default:
				obj = _0002;
				break;
			}
		}
		if (this.m__000E != null)
		{
			if (this.m__0002 != null)
			{
				this.m__0002_2009.Push(this.m__0002);
			}
			this.m__0002 = this.m__000E;
		}
		this.m__000E = obj;
	}

	private static void _0003_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		Type type = _0002._0002(num2, _0008: true);
		Type type2;
		if (6u != 0)
		{
			type2 = type;
		}
		long num3 = _0002._0002();
		long num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		Array array = (Array)_0002._0002()._0006_2008_2009_0002();
		global::_0008_2007_2005 obj = new global::_0008_2007_2005();
		obj._0002(array);
		obj._0002(type2);
		obj._0002(num4);
		_0002._0008((global::_0006)obj);
	}

	private static void _0003_2003(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (uint.MaxValue != 0)
		{
			obj4 = obj3;
		}
		_0002._0008(_0002._000F(obj4, obj2));
	}

	private static void _000F_200B_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463124313));
	}

	private static void _0002_2009_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (6 == 0)
		{
		}
		_0002._0006(_0002: false);
	}

	private static Dictionary<int, _0003_2004> _0002(global::_0008_2005 _0002)
	{
		Dictionary<int, _0003_2004> dictionary = new Dictionary<int, _0003_2004>(256);
		global::_000F_2000 obj = _0002._0003_2006_2005;
		global::_000F_2000 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		int key = obj2._0002();
		global::_000F_2000 obj3 = _0002._0003_2006_2005;
		_0008_2004 obj4 = global::_0006_2009._0005._000F_2002_2005;
		if (obj4 == null)
		{
			obj4 = _000F_200A;
			_0008_2004 obj5 = obj4;
			if (uint.MaxValue != 0)
			{
				global::_0006_2009._0005._000F_2002_2005 = obj5;
			}
		}
		dictionary.Add(key, new _0003_2004(obj3, obj4));
		global::_000F_2000 obj6 = _0002._0008_2004;
		if (uint.MaxValue != 0)
		{
			obj2 = obj6;
		}
		int key2 = obj2._0002();
		global::_000F_2000 obj7 = _0002._0008_2004;
		_0008_2004 obj8 = global::_0006_2009._0005._0008_2003;
		if (obj8 == null)
		{
			obj8 = _0003_200B_2005;
			_0008_2004 obj9 = obj8;
			if (5u != 0)
			{
				global::_0006_2009._0005._0008_2003 = obj9;
			}
		}
		dictionary.Add(key2, new _0003_2004(obj7, obj8));
		global::_000F_2000 obj10 = _0002._000F_2006;
		if (0 == 0)
		{
			obj2 = obj10;
		}
		int key3 = obj2._0002();
		global::_000F_2000 obj11 = _0002._000F_2006;
		_0008_2004 obj12 = global::_0006_2009._0005._000E_2001;
		if (obj12 == null)
		{
			obj12 = _000E_2003_2000;
			_0008_2004 obj13 = obj12;
			if (0 == 0)
			{
				global::_0006_2009._0005._000E_2001 = obj13;
			}
		}
		dictionary.Add(key3, new _0003_2004(obj11, obj12));
		global::_000F_2000 obj14 = _0002._000F_2007;
		if (4u != 0)
		{
			obj2 = obj14;
		}
		int key4 = obj2._0002();
		global::_000F_2000 obj15 = _0002._000F_2007;
		_0008_2004 obj16 = global::_0006_2009._0005._0008_2004_2005;
		if (obj16 == null)
		{
			obj16 = _0005_2004;
			_0008_2004 obj17 = obj16;
			if (5u != 0)
			{
				global::_0006_2009._0005._0008_2004_2005 = obj17;
			}
		}
		dictionary.Add(key4, new _0003_2004(obj15, obj16));
		global::_000F_2000 obj18 = _0002._0003_2009_2005;
		if (4u != 0)
		{
			obj2 = obj18;
		}
		int key5 = obj2._0002();
		global::_000F_2000 obj19 = _0002._0003_2009_2005;
		_0008_2004 obj20 = global::_0006_2009._0005._000E_2003_2000;
		if (obj20 == null)
		{
			obj20 = _0006_2006_2005;
			_0008_2004 obj21 = obj20;
			if (true)
			{
				global::_0006_2009._0005._000E_2003_2000 = obj21;
			}
		}
		dictionary.Add(key5, new _0003_2004(obj19, obj20));
		dictionary.Add(_0002._0008_2008._0002(), new _0003_2004(_0002._0008_2008, _0006_2002));
		dictionary.Add(_0002._0005_200A._0002(), new _0003_2004(_0002._0005_200A, _0006_2004));
		dictionary.Add(_0002._000F_2003_2000._0002(), new _0003_2004(_0002._000F_2003_2000, _0008_2007_2000));
		dictionary.Add(_0002._0002_2006._0002(), new _0003_2004(_0002._0002_2006, _0008_2004));
		dictionary.Add(_0002._0003_200B._0002(), new _0003_2004(_0002._0003_200B, _0006_2009));
		dictionary.Add(_0002._0005_200B_2005._0002(), new _0003_2004(_0002._0005_200B_2005, _0005_2009));
		dictionary.Add(_0002._0006_2000._0002(), new _0003_2004(_0002._0006_2000, _0005_2006));
		dictionary.Add(_0002._0003_2009._0002(), new _0003_2004(_0002._0003_2009, _000E_2003_2005));
		dictionary.Add(_0002._0003_2009_2000._0002(), new _0003_2004(_0002._0003_2009_2000, _0003_2003_2000));
		dictionary.Add(_0002._0002_200A_2005._0002(), new _0003_2004(_0002._0002_200A_2005, _0005_2001_2005));
		dictionary.Add(_0002._0002_2007._0002(), new _0003_2004(_0002._0002_2007, _0005_2009_2005));
		dictionary.Add(_0002._0006_2008_2005._0002(), new _0003_2004(_0002._0006_2008_2005, _000F_2003));
		dictionary.Add(_0002._0005_200B._0002(), new _0003_2004(_0002._0005_200B, _000F_2001_2005));
		dictionary.Add(_0002._0002_2001_2000._0002(), new _0003_2004(_0002._0002_2001_2000, _0002_2001));
		dictionary.Add(_0002._0005_2007_2000._0002(), new _0003_2004(_0002._0005_2007_2000, _0006_2003_2000));
		dictionary.Add(_0002._0008_2002._0002(), new _0003_2004(_0002._0008_2002, _0008_2003_2000));
		dictionary.Add(_0002._0006_2006._0002(), new _0003_2004(_0002._0006_2006, _0008_200B_2005));
		dictionary.Add(_0002._000F_2000._0002(), new _0003_2004(_0002._000F_2000, _0008_2008_2005));
		dictionary.Add(_0002._0002_2002_2005._0002(), new _0003_2004(_0002._0002_2002_2005, _0003_200B));
		dictionary.Add(_0002._000F_2008_2005._0002(), new _0003_2004(_0002._000F_2008_2005, _0006_2008_2005));
		dictionary.Add(_0002._0006_2000_2005._0002(), new _0003_2004(_0002._0006_2000_2005, _000E_2009_2000));
		dictionary.Add(_0002._000F_200A._0002(), new _0003_2004(_0002._000F_200A, _0003_2002_2005));
		dictionary.Add(_0002._0002_2005_2005._0002(), new _0003_2004(_0002._0003_2007_2005, _0003_2000));
		dictionary.Add(_0002._0005_2000_2005._0002(), new _0003_2004(_0002._0005_2000_2005, _0008_200B));
		dictionary.Add(_0002._0003_2005._0002(), new _0003_2004(_0002._0003_2005, _0008_2008));
		dictionary.Add(_0002._000E_200A_2005._0002(), new _0003_2004(_0002._000E_200A_2005, _0008_2009));
		dictionary.Add(_0002._0008_2000._0002(), new _0003_2004(_0002._0008_2000, _0003_200A_2005));
		dictionary.Add(_0002._0003_200A_2005._0002(), new _0003_2004(_0002._0003_200A_2005, _000E_2007));
		dictionary.Add(_0002._0008_2009_2005._0002(), new _0003_2004(_0002._0008_2009_2005, _0005_2004_2005));
		dictionary.Add(_0002._000F_2007_2005._0002(), new _0003_2004(_0002._000F_2007_2005, _0002_2004_2000));
		dictionary.Add(_0002._0003_2004_2000._0002(), new _0003_2004(_0002._0003_2004_2000, _0002_200B));
		dictionary.Add(_0002._000F_2002_2005._0002(), new _0003_2004(_0002._000F_2002_2005, _0003_200A));
		dictionary.Add(_0002._0008_2009._0002(), new _0003_2004(_0002._0008_2009, _0005_2008));
		dictionary.Add(_0002._0002_2003._0002(), new _0003_2004(_0002._0002_2003, _0003_2007_2000));
		dictionary.Add(_0002._000F_2005_2005._0002(), new _0003_2004(_0002._000F_2005_2005, _0002_200A));
		dictionary.Add(_0002._0005_2004._0002(), new _0003_2004(_0002._0005_2004, _0005_2003_2000));
		dictionary.Add(_0002._0006_200B._0002(), new _0003_2004(_0002._0006_200B, _000F_2001));
		dictionary.Add(_0002._0006_2001._0002(), new _0003_2004(_0002._0006_2001, _000F_2004_2005));
		dictionary.Add(_0002._000F_2009_2000._0002(), new _0003_2004(_0002._000F_2009_2000, _0002_2005_2005));
		dictionary.Add(_0002._0002_2002._0002(), new _0003_2004(_0002._0002_2002, _000E_2006));
		dictionary.Add(_0002._000E_200A._0002(), new _0003_2004(_0002._000E_200A, _0003_2004_2005));
		dictionary.Add(_0002._000E_200B._0002(), new _0003_2004(_0002._000E_200B, _0006));
		dictionary.Add(_0002._0005_2004_2000._0002(), new _0003_2004(_0002._0005_2004_2000, _000E_2002_2005));
		dictionary.Add(_0002._0005_2005._0002(), new _0003_2004(_0002._0005_2005, _000F_2002));
		dictionary.Add(_0002._0006_2007_2005._0002(), new _0003_2004(_0002._0006_2007_2005, _0002_2000));
		dictionary.Add(_0002._0008_2003_2000._0002(), new _0003_2004(_0002._0008_2003_2000, _0006_200B_2005));
		dictionary.Add(_0002._0006_200A_2005._0002(), new _0003_2004(_0002._0006_200A_2005, _0005_2008_2005));
		dictionary.Add(_0002._000E_2007_2005._0002(), new _0003_2004(_0002._000E_2007_2005, _000F_2006_2005));
		dictionary.Add(_0002._000E_2005_2005._0002(), new _0003_2004(_0002._000E_2005_2005, _0008_200A_2005));
		dictionary.Add(_0002._000E_2004_2005._0002(), new _0003_2004(_0002._000E_2004_2005, _000E));
		dictionary.Add(_0002._0006_2003_2000._0002(), new _0003_2004(_0002._0006_2003_2000, _0006_2007_2005));
		dictionary.Add(_0002._000E_2003_2000._0002(), new _0003_2004(_0002._000E_2003_2000, _000F_2009_2000));
		dictionary.Add(_0002._0002_2008_2005._0002(), new _0003_2004(_0002._0002_2008_2005, _0008_2009_2005));
		dictionary.Add(_0002._0002_2004._0002(), new _0003_2004(_0002._0002_2004, _0002_2005));
		dictionary.Add(_0002._0003_2006._0002(), new _0003_2004(_0002._0003_2006, _000F_2000));
		dictionary.Add(_0002._000E_2006_2005._0002(), new _0003_2004(_0002._000E_2006_2005, _0005_2007_2000));
		dictionary.Add(_0002._000F_2002_2000._0002(), new _0003_2004(_0002._000F_2002_2000, _0005_2003_2005));
		dictionary.Add(_0002._0002_200B._0002(), new _0003_2004(_0002._0002_200B, _0003_2002));
		dictionary.Add(_0002._0003_2005_2005._0002(), new _0003_2004(_0002._0003_2005_2005, _0003_2004));
		dictionary.Add(_0002._0002_2001_2005._0002(), new _0003_2004(_0002._0002_2001_2005, _000E_2009));
		dictionary.Add(_0002._000F_2003_2005._0002(), new _0003_2004(_0002._000F_2003_2005, _0006_2005));
		dictionary.Add(_0002._0005._0002(), new _0003_2004(_0002._0005, _000F_200B));
		dictionary.Add(_0002._0006_2002_2000._0002(), new _0003_2004(_0002._0006_2002_2000, _0008_2001_2000));
		dictionary.Add(_0002._0002_2005._0002(), new _0003_2004(_0002._0002_2005, _0006_2007));
		dictionary.Add(_0002._0002_2006_2005._0002(), new _0003_2004(_0002._0002_2006_2005, _0005_2000_2005));
		dictionary.Add(_0002._0006_2002_2005._0002(), new _0003_2004(_0002._0006_2002_2005, _0002_2007_2005));
		dictionary.Add(_0002._000E_2008_2005._0002(), new _0003_2004(_0002._000E_2008_2005, _000E_2002));
		dictionary.Add(_0002._0008_2004_2000._0002(), new _0003_2004(_0002._0008_2004_2000, _0005_2007_2005));
		dictionary.Add(_0002._000F_2004_2005._0002(), new _0003_2004(_0002._000F_2004_2005, _0002_2002_2005));
		dictionary.Add(_0002._0006_200B_2005._0002(), new _0003_2004(_0002._0006_200B_2005, _0005_2006_2005));
		dictionary.Add(_0002._0008_2001_2005._0002(), new _0003_2004(_0002._0008_2001_2005, _000E_2007_2000));
		dictionary.Add(_0002._0006_2005._0002(), new _0003_2004(_0002._0006_2005, _0002_2009_2005));
		dictionary.Add(_0002._0005_2001_2000._0002(), new _0003_2004(_0002._0005_2001_2000, _000E_2004));
		dictionary.Add(_0002._0006_2002._0002(), new _0003_2004(_0002._0006_2002, global::_0006_2009._0002));
		dictionary.Add(_0002._0008_2001_2000._0002(), new _0003_2004(_0002._0008_2001_2000, _0006_2005_2005));
		dictionary.Add(_0002._0006_2004._0002(), new _0003_2004(_0002._0006_2004, _0005_2007));
		dictionary.Add(_0002._0003_2001_2000._0002(), new _0003_2004(_0002._0003_2001_2000, _000F_2007));
		dictionary.Add(_0002._0002._0002(), new _0003_2004(_0002._0002, _0003_2008));
		dictionary.Add(_0002._0005_2001._0002(), new _0003_2004(_0002._0005_2001, _0002_2009_2000));
		dictionary.Add(_0002._0006_2003._0002(), new _0003_2004(_0002._0006_2003, _0006_2009_2005));
		dictionary.Add(_0002._0005_2000._0002(), new _0003_2004(_0002._0005_2000, _0006_2002_2005));
		dictionary.Add(_0002._0005_2002_2000._0002(), new _0003_2004(_0002._0005_2002_2000, _0008_2009_2000));
		dictionary.Add(_0002._0005_2009_2000._0002(), new _0003_2004(_0002._0005_2009_2000, _000E_2004_2005));
		dictionary.Add(_0002._000F_2001_2005._0002(), new _0003_2004(_0002._000F_2001_2005, _0003_2000_2005));
		dictionary.Add(_0002._0003_2002._0002(), new _0003_2004(_0002._0003_2002, _0002_2008));
		dictionary.Add(_0002._000E_2001_2005._0002(), new _0003_2004(_0002._000E_2001_2005, _0002_2004));
		dictionary.Add(_0002._000E_2007._0002(), new _0003_2004(_0002._000E_2007, _000E_2008));
		dictionary.Add(_0002._000F_2001._0002(), new _0003_2004(_0002._000F_2001, _0003_2003_2005));
		dictionary.Add(_0002._0006_2007._0002(), new _0003_2004(_0002._0006_2007, _000F_2007_2005));
		dictionary.Add(_0002._0003_2003._0002(), new _0003_2004(_0002._0003_2003, _0008_2006_2005));
		dictionary.Add(_0002._0003_2008_2005._0002(), new _0003_2004(_0002._0003_2008_2005, _0006_200B));
		dictionary.Add(_0002._000E_2009_2000._0002(), new _0003_2004(_0002._000E_2009_2000, _000E_2009_2005));
		dictionary.Add(_0002._0006_2006_2005._0002(), new _0003_2004(_0002._0006_2006_2005, _0003_2009_2005));
		dictionary.Add(_0002._0003_2004_2005._0002(), new _0003_2004(_0002._0003_2004_2005, _0005_2005_2005));
		dictionary.Add(_0002._000E_2003_2005._0002(), new _0003_2004(_0002._000E_2003_2005, _0005_2002_2005));
		dictionary.Add(_0002._0002_2002_2000._0002(), new _0003_2004(_0002._0002_2002_2000, _000E_2005));
		dictionary.Add(_0002._0008_2002_2000._0002(), new _0003_2004(_0002._0008_2002_2000, _0003_2001_2005));
		dictionary.Add(_0002._0003_2007_2005._0002(), new _0003_2004(_0002._0003_2007_2005, _0005_2004_2000));
		dictionary.Add(_0002._0002_2009._0002(), new _0003_2004(_0002._0002_2009, _0002_2006_2005));
		dictionary.Add(_0002._0008_200B_2005._0002(), new _0003_2004(_0002._0008_200B_2005, _0006_2009_2000));
		dictionary.Add(_0002._000F_2007_2000._0002(), new _0003_2004(_0002._000F_2007_2000, _000F_2000_2005));
		dictionary.Add(_0002._0008_200B._0002(), new _0003_2004(_0002._0008_200B, _0008_2007_2005));
		dictionary.Add(_0002._0008_2009_2000._0002(), new _0003_2004(_0002._0008_2009_2000, _0002_200B_2005));
		dictionary.Add(_0002._000E_2002_2005._0002(), new _0003_2004(_0002._000E_2002_2005, _0008_2006));
		dictionary.Add(_0002._000E_2007_2000._0002(), new _0003_2004(_0002._000E_2007_2000, _000E_2000_2005));
		dictionary.Add(_0002._000F_200B._0002(), new _0003_2004(_0002._000F_200B, _0008_2001_2005));
		dictionary.Add(_0002._0002_2008._0002(), new _0003_2004(_0002._0002_2008, _0006_2007_2000));
		dictionary.Add(_0002._000E_200B_2005._0002(), new _0003_2004(_0002._000E_200B_2005, _0005_2000));
		dictionary.Add(_0002._000E_2004_2000._0002(), new _0003_2004(_0002._000E_2004_2000, _0003_2007_2005));
		dictionary.Add(_0002._0002_2003_2005._0002(), new _0003_2004(_0002._0002_2003_2005, _0003_2008_2005));
		dictionary.Add(_0002._0005_2007._0002(), new _0003_2004(_0002._0005_2007, _0002_2003_2005));
		dictionary.Add(_0002._0003_200A._0002(), new _0003_2004(_0002._0003_200A, _000E_2005_2005));
		dictionary.Add(_0002._0002_2000._0002(), new _0003_2004(_0002._0002_2000, _000E_2008_2005));
		dictionary.Add(_0002._000E_2003._0002(), new _0003_2004(_0002._000E_2003, _0005_2009_2000));
		dictionary.Add(_0002._0003_2007._0002(), new _0003_2004(_0002._0003_2007, _0008_2003));
		dictionary.Add(_0002._000F_2002._0002(), new _0003_2004(_0002._000F_2002, _000E_2001));
		dictionary.Add(_0002._000F_2004._0002(), new _0003_2004(_0002._000F_2004, _000F_2007_2000));
		dictionary.Add(_0002._0008_2004_2005._0002(), new _0003_2004(_0002._0008_2004_2005, _0005_200A));
		dictionary.Add(_0002._0008_2003_2005._0002(), new _0003_2004(_0002._0008_2003_2005, _0006_2000));
		dictionary.Add(_0002._0005_2003_2000._0002(), new _0003_2004(_0002._0005_2003_2000, _0002_2006));
		dictionary.Add(_0002._0008_200A._0002(), new _0003_2004(_0002._0008_200A, _0008_2005_2005));
		dictionary.Add(_0002._0005_2005_2005._0002(), new _0003_2004(_0002._0005_2005_2005, _000F_2005_2005));
		dictionary.Add(_0002._0002_2007_2005._0002(), new _0003_2004(_0002._0002_2007_2005, _0005_2002));
		dictionary.Add(_0002._000F_200A_2005._0002(), new _0003_2004(_0002._000F_200A_2005, _0002_2003_2000));
		dictionary.Add(_0002._0002_2001._0002(), new _0003_2004(_0002._0002_2001, _000F_2005));
		dictionary.Add(_0002._000E_2000_2005._0002(), new _0003_2004(_0002._000E_2000_2005, _0003_2006_2005));
		dictionary.Add(_0002._0002_2009_2005._0002(), new _0003_2004(_0002._0002_2009_2005, _000F));
		dictionary.Add(_0002._0003_2002_2005._0002(), new _0003_2004(_0002._0003_2002_2005, _0008_2005));
		dictionary.Add(_0002._000E_2002._0002(), new _0003_2004(_0002._000E_2002, _0005_2003));
		dictionary.Add(_0002._0008_2007_2000._0002(), new _0003_2004(_0002._0008_2007_2000, _000F_2009_2005));
		dictionary.Add(_0002._000F_2005._0002(), new _0003_2004(_0002._000F_2005, _000E_2001_2005));
		dictionary.Add(_0002._0005_2002._0002(), new _0003_2004(_0002._0005_2002, _0002_2007));
		dictionary.Add(_0002._0008_2003._0002(), new _0003_2004(_0002._0008_2003, _0008_2003_2005));
		dictionary.Add(_0002._000E_2009._0002(), new _0003_2004(_0002._000E_2009, _0008_200A));
		dictionary.Add(_0002._000E_2008._0002(), new _0003_2004(_0002._000E_2008, _0006_2000_2005));
		dictionary.Add(_0002._0006_2001_2005._0002(), new _0003_2004(_0002._0006_2001_2005, _000F_200B_2005));
		dictionary.Add(_0002._000E_2004._0002(), new _0003_2004(_0002._000E_2004, _0008_2000_2005));
		dictionary.Add(_0002._000E_2001_2000._0002(), new _0003_2004(_0002._000E_2001_2000, _0008_2002));
		dictionary.Add(_0002._0003._0002(), new _0003_2004(_0002._0003, _000E_200B));
		dictionary.Add(_0002._0008_2005._0002(), new _0003_2004(_0002._0008_2005, _0002_2009));
		dictionary.Add(_0002._0008_2002_2005._0002(), new _0003_2004(_0002._0008_2002_2005, _000E_200B_2005));
		dictionary.Add(_0002._000F_2009._0002(), new _0003_2004(_0002._000F_2009, _0005));
		dictionary.Add(_0002._0003_2001._0002(), new _0003_2004(_0002._0003_2001, _0003_2001));
		dictionary.Add(_0002._0003_2003_2005._0002(), new _0003_2004(_0002._0003_2003_2005, _0006_2001));
		dictionary.Add(_0002._0003_200B_2005._0002(), new _0003_2004(_0002._0003_200B_2005, _0006_2004_2005));
		dictionary.Add(_0002._000F_2003._0002(), new _0003_2004(_0002._000F_2003, _000E_2000));
		dictionary.Add(_0002._0006_200A._0002(), new _0003_2004(_0002._0006_200A, _0008_2007));
		dictionary.Add(_0002._0005_2006_2005._0002(), new _0003_2004(_0002._0005_2006_2005, _0006_2001_2005));
		dictionary.Add(_0002._0005_2003_2005._0002(), new _0003_2004(_0002._0005_2003_2005, _0002_2002));
		dictionary.Add(_0002._0002_2004_2005._0002(), new _0003_2004(_0002._0002_2004_2005, _0002_2003));
		dictionary.Add(_0002._000E_2001._0002(), new _0003_2004(_0002._000E_2001, _0005_200B));
		dictionary.Add(_0002._0005_2001_2005._0002(), new _0003_2004(_0002._0005_2001_2005, _000E_2003));
		dictionary.Add(_0002._0005_2003._0002(), new _0003_2004(_0002._0005_2003, _000E_2004_2000));
		dictionary.Add(_0002._0003_2007_2000._0002(), new _0003_2004(_0002._0003_2007_2000, _000F_2004));
		dictionary.Add(_0002._0006_2003_2005._0002(), new _0003_2004(_0002._0006_2003_2005, _0008_2001));
		dictionary.Add(_0002._0006_2008._0002(), new _0003_2004(_0002._0006_2008, _0006_2003));
		dictionary.Add(_0002._0005_2009_2005._0002(), new _0003_2004(_0002._0005_2009_2005, _000F_2008));
		dictionary.Add(_0002._0006_2009_2000._0002(), new _0003_2004(_0002._0006_2009_2000, _0005_200B_2005));
		dictionary.Add(_0002._0008_2005_2005._0002(), new _0003_2004(_0002._0008_2005_2005, _0002_2004_2005));
		dictionary.Add(_0002._000E_2006._0002(), new _0003_2004(_0002._000E_2006, _000F_2003_2005));
		dictionary.Add(_0002._000F._0002(), new _0003_2004(_0002._000F, _000E_2006_2005));
		dictionary.Add(_0002._0005_2002_2005._0002(), new _0003_2004(_0002._0005_2002_2005, _0008_2002_2005));
		dictionary.Add(_0002._0005_200A_2005._0002(), new _0003_2004(_0002._0005_200A_2005, _0006_2003_2005));
		dictionary.Add(_0002._000F_2009_2005._0002(), new _0003_2004(_0002._000F_2009_2005, _0002_2001_2000));
		dictionary.Add(_0002._000F_2006_2005._0002(), new _0003_2004(_0002._000F_2006_2005, _0006_2004_2000));
		dictionary.Add(_0002._0003_2000._0002(), new _0003_2004(_0002._0003_2000, _0003_2003));
		dictionary.Add(_0002._000F_2004_2000._0002(), new _0003_2004(_0002._000F_2004_2000, _000F_2004_2000));
		dictionary.Add(_0002._0002_2004_2000._0002(), new _0003_2004(_0002._0002_2004_2000, _0006_200A));
		dictionary.Add(_0002._0006_2004_2000._0002(), new _0003_2004(_0002._0006_2004_2000, _000E_200A_2005));
		dictionary.Add(_0002._0003_2004._0002(), new _0003_2004(_0002._0003_2004, _0003_2006));
		dictionary.Add(_0002._0005_2008_2005._0002(), new _0003_2004(_0002._0005_2008_2005, _0005_200A_2005));
		dictionary.Add(_0002._000F_2001_2000._0002(), new _0003_2004(_0002._000F_2001_2000, _0002_2000_2005));
		dictionary.Add(_0002._0006_2004_2005._0002(), new _0003_2004(_0002._0006_2004_2005, _0002_2007_2000));
		dictionary.Add(_0002._0005_2009._0002(), new _0003_2004(_0002._0005_2009, _0002_2001_2005));
		dictionary.Add(_0002._000E_2005._0002(), new _0003_2004(_0002._000E_2005, _0008));
		dictionary.Add(_0002._0002_2003_2000._0002(), new _0003_2004(_0002._0002_2003_2000, _0003_2009_2000));
		dictionary.Add(_0002._0006_2007_2000._0002(), new _0003_2004(_0002._0006_2007_2000, _0003_2005_2005));
		dictionary.Add(_0002._0005_2007_2005._0002(), new _0003_2004(_0002._0005_2007_2005, _0005_2001));
		dictionary.Add(_0002._0005_2004_2005._0002(), new _0003_2004(_0002._0005_2004_2005, _000E_2007_2005));
		dictionary.Add(_0002._0008_2006_2005._0002(), new _0003_2004(_0002._0008_2006_2005, _000F_2006));
		dictionary.Add(_0002._0005_2008._0002(), new _0003_2004(_0002._0005_2008, _000E_200A));
		dictionary.Add(_0002._0002_200B_2005._0002(), new _0003_2004(_0002._0002_200B_2005, _0003_2007));
		dictionary.Add(_0002._0006_2009_2005._0002(), new _0003_2004(_0002._0006_2009_2005, _000F_2003_2000));
		dictionary.Add(_0002._0002_200A._0002(), new _0003_2004(_0002._0002_200A, _0006_2008));
		dictionary.Add(_0002._0008_2006._0002(), new _0003_2004(_0002._0008_2006, _0005_2005));
		dictionary.Add(_0002._000E_2009_2005._0002(), new _0003_2004(_0002._000E_2009_2005, _0008_2000));
		dictionary.Add(_0002._0006._0002(), new _0003_2004(_0002._0006, _0003_2004_2000));
		dictionary.Add(_0002._0003_2002_2000._0002(), new _0003_2004(_0002._0003_2002_2000, _0003_2005));
		dictionary.Add(_0002._000E._0002(), new _0003_2004(_0002._000E, _0002_200A_2005));
		dictionary.Add(_0002._0006_2001_2000._0002(), new _0003_2004(_0002._0006_2001_2000, _0008_2004_2005));
		dictionary.Add(_0002._0008_2001._0002(), new _0003_2004(_0002._0008_2001, _000F_2009));
		dictionary.Add(_0002._0008_200A_2005._0002(), new _0003_2004(_0002._0008_200A_2005, _000F_2008_2005));
		dictionary.Add(_0002._0008._0002(), new _0003_2004(_0002._0008, _0002_2008_2005));
		dictionary.Add(_0002._0008_2000_2005._0002(), new _0003_2004(_0002._0008_2000_2005, _0008_2004_2000));
		dictionary.Add(_0002._0003_2000_2005._0002(), new _0003_2004(_0002._0003_2000_2005, _0003_2009));
		dictionary.Add(_0002._0005_2006._0002(), new _0003_2004(_0002._0005_2006, _0006_2006));
		dictionary.Add(_0002._0008_2007_2005._0002(), new _0003_2004(_0002._0008_2007_2005, _000F_200A_2005));
		dictionary.Add(_0002._0002_2000_2005._0002(), new _0003_2004(_0002._0002_2000_2005, _0003));
		dictionary.Add(_0002._0002_2009_2000._0002(), new _0003_2004(_0002._0002_2009_2000, _000F_2002_2005));
		dictionary.Add(_0002._000F_2008._0002(), new _0003_2004(_0002._000F_2008, _0006_200A_2005));
		return dictionary;
	}

	private static void _0006_2000_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 6;
		if (6 == 0)
		{
		}
		_0002._0008(typeof(double));
	}

	private static void _0002_2004_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		int num = obj2._0002();
		int num2;
		if (4u != 0)
		{
			num2 = num;
		}
		IntPtr intPtr = checked(num2 switch
		{
			1 => new IntPtr((uint)((global::_000F)obj2)._0002()), 
			13 => new IntPtr((long)(ulong)((global::_0003_2000)obj2)._0002()), 
			19 => new IntPtr((long)Convert.ToUInt64(((global::_0002_0010)obj2)._0002())), 
			8 => new IntPtr((long)((global::_0006_200A)obj2)._0002()), 
			_ => throw new InvalidOperationException(), 
		});
		global::_0006_2002 obj3 = new global::_0006_2002();
		obj3._0002(intPtr);
		_0002._0008((global::_0006)obj3);
	}

	private void _0006()
	{
		if (uint.MaxValue != 0)
		{
			_000E_2004(_0002: false);
		}
	}

	private static void _0002_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		_0002._0002(obj2._0006_2008_2009_0002());
	}

	private void _0006(global::_0006 _0002)
	{
		global::_000F obj = (global::_000F)_0002;
		global::_000F obj2;
		if (8u != 0)
		{
			obj2 = obj;
		}
		MethodBase methodBase = this._0002(obj2._0002());
		MethodBase methodBase2;
		if (3u != 0)
		{
			methodBase2 = methodBase;
		}
		if (this.m__0005_2007 != null)
		{
			ParameterInfo[] parameters = methodBase2.GetParameters();
			Type[] array = new Type[parameters.Length];
			Type[] array2;
			if (2u != 0)
			{
				array2 = array;
			}
			int num = 0;
			ParameterInfo[] array3 = parameters;
			foreach (ParameterInfo parameterInfo in array3)
			{
				array2[num++] = parameterInfo.ParameterType;
			}
			MethodInfo method = this.m__0005_2007.GetMethod(methodBase2.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty, null, array2, null);
			if (method != null)
			{
				methodBase2 = method;
			}
			this.m__0005_2007 = null;
		}
		this._0002(methodBase2, true);
	}

	private static void _0006_2009(global::_0006_2009 _0002, global::_0006 _0008)
	{
		throw new NotSupportedException(global::_0008_0010._0002(-1463125194));
	}

	private static void _0006_2006(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		FieldInfo fieldInfo = _0002._0002(num2);
		FieldInfo fieldInfo2;
		if (5u != 0)
		{
			fieldInfo2 = fieldInfo;
		}
		_0002._0008((global::_0006)new global::_000E_200B(fieldInfo2, null));
	}

	private static void _0008_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		int num = ((global::_000F)_0008)._0002();
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		FieldInfo fieldInfo = _0002._0002(num2);
		FieldInfo fieldInfo2;
		if (8u != 0)
		{
			fieldInfo2 = fieldInfo;
		}
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		global::_0002_2004 obj3 = obj2 as global::_0002_2004;
		object obj4 = ((obj3 == null) ? obj2._0006_2008_2009_0002() : _0002._0002(obj3)._0006_2008_2009_0002());
		_0002._0008((global::_0006)new global::_000E_200B(fieldInfo2, obj4, obj3));
	}

	private void _0002(uint _0002)
	{
		uint? num = _0002;
		if (8u != 0)
		{
			this.m__0003_2007 = num;
		}
	}

	private static global::_0003_2005[] _0002(global::_0002_2004_2005 _0002)
	{
		short num = _0002._0002();
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		global::_0003_2005[] array = new global::_0003_2005[num2];
		global::_0003_2005[] array2;
		if (5u != 0)
		{
			array2 = array;
		}
		int i;
		if (uint.MaxValue != 0)
		{
			i = 0;
		}
		for (; i < num2; i++)
		{
			array2[i] = global::_0006_2009._0002(_0002);
		}
		return array2;
	}

	private static void _0003_2006_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		global::_0006 obj = _0002._0002();
		global::_0006 obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		global::_0006 obj3 = _0002._0002();
		global::_0006 obj4;
		if (6u != 0)
		{
			obj4 = obj3;
		}
		_0002._0008((global::_0006)new global::_000F(_0005(obj4, obj2) ? 1 : 0));
	}

	private static void _0002_200A_2005(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 4;
		if (-1 == 0)
		{
		}
		_0002._0003(0);
	}

	private static void _0006_2002(global::_0006_2009 _0002, global::_0006 _0008)
	{
		if (uint.MaxValue != 0)
		{
			Debugger.Break();
		}
	}

	private static bool _0002()
	{
		return false;
	}

	private static void _000F_2009_2000(global::_0006_2009 _0002, global::_0006 _0008)
	{
		_ = 3;
		if (7 == 0)
		{
		}
		_0002._0002();
		if (7u != 0)
		{
		}
	}
}
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[DebuggerNonUserCode]
public sealed class _0006_2009_2005
{
	private static ResourceManager m__0002;

	private static CultureInfo _0008;

	internal _0006_2009_2005()
	{
		_ = 2;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	public static ResourceManager _0002()
	{
		if (_0006_2009_2005.m__0002 == null)
		{
			ResourceManager resourceManager = new ResourceManager(global::_0008_0010._0002(-1463133293), typeof(_0006_2009_2005).Assembly);
			if (6u != 0)
			{
				_0006_2009_2005.m__0002 = resourceManager;
			}
		}
		return _0006_2009_2005.m__0002;
	}

	public static CultureInfo _0002()
	{
		return _0008;
	}

	public static void _0002(CultureInfo _0002)
	{
		if (6u != 0)
		{
			_0008 = _0002;
		}
	}
}
internal sealed class _0006_200A : global::_0006
{
	private new double m__0002;

	public _0006_200A()
	{
		_ = 4;
		if (2 == 0)
		{
		}
		base._002Ector(8);
	}

	public new double _0002()
	{
		_ = 6;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(double _0002)
	{
		if (5u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 8;
		if (2 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		double num = Convert.ToDouble(_0002);
		if (uint.MaxValue != 0)
		{
			this._0002(num);
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0006_200A obj = new global::_0006_200A();
		_ = 3;
		if (6 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 1;
		if (false)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (8u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 8:
		{
			double num3 = ((global::_0006_200A)_0002)._0002();
			if (true)
			{
				this._0002(num3);
			}
			break;
		}
		case 22:
			this._0002(((global::_000F_200B)_0002)._0002());
			break;
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
		case 7:
			this._0002((double)((global::_0005_2003)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal sealed class _0008 : DeriveBytes
{
	private byte[] m__0002;

	private byte[] m__0008;

	private int _0006;

	private readonly global::_0006_200B _000F;

	private readonly byte[] _0005;

	public _0008(byte[] _0002, byte[] _0008, int _0006)
	{
		global::_0006_200B obj = new global::_0006_200B();
		if (8u != 0)
		{
			_000F = obj;
		}
		base._002Ector();
		if (_0002 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463125419));
		}
		if (_0008 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463125410));
		}
		if (_0006 < 1)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463125429));
		}
		byte[] obj2 = (byte[])_0002.Clone();
		if (0 == 0)
		{
			this.m__0002 = obj2;
		}
		byte[] obj3 = (byte[])_0008.Clone();
		if (4u != 0)
		{
			this.m__0008 = obj3;
		}
		this._0006 = _0006;
		_0005 = new byte[_000F._0002()];
	}

	private void _0002(byte[] _0002, int _0008, byte[] _0006, byte[] _000F, int _0005)
	{
		if (_0002 != null)
		{
			this._000F._0002(_0002, 0, _0002.Length);
		}
		this._000F._0002(_0006, 0, _0006.Length);
		this._000F._0002(this._0005, 0);
		byte[] src = this._0005;
		int count = this._0005.Length;
		if (8u != 0)
		{
			Buffer.BlockCopy(src, 0, _000F, _0005, count);
		}
		int i;
		if (true)
		{
			i = 1;
		}
		for (; i < _0008; i++)
		{
			this._000F._0002(this._0005, 0, this._0005.Length);
			this._000F._0002(this._0005, 0);
			int j;
			if (2u != 0)
			{
				j = 0;
			}
			for (; j < this._0005.Length; j++)
			{
				_000F[_0005 + j] ^= this._0005[j];
			}
		}
	}

	public override byte[] GetBytes(int _0002)
	{
		int num = _000F._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		int num3 = (_0002 + num2 - 1) / num2;
		int num4;
		if (3u != 0)
		{
			num4 = num3;
		}
		byte[] array = new byte[4];
		byte[] array2;
		if (true)
		{
			array2 = array;
		}
		byte[] array3 = new byte[num4 * num2];
		int num5 = 0;
		_000F._0002(this.m__0002);
		for (int i = 1; i <= num4; i++)
		{
			int num6 = 3;
			while (++array2[num6] == 0)
			{
				num6--;
			}
			this._0002(m__0008, _0006, array2, array3, num5);
			num5 += num2;
		}
		if (_0002 < array3.Length)
		{
			byte[] array4 = new byte[_0002];
			Buffer.BlockCopy(array3, 0, array4, 0, _0002);
			array3 = array4;
		}
		return array3;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
[global::_0006_2006]
internal sealed class _0008_2000 : Attribute
{
	public _0008_2000()
	{
		_ = 0;
		if (3 == 0)
		{
		}
		base._002Ector();
	}
}
internal sealed class _0008_2001 : SymmetricAlgorithm
{
	[Serializable]
	private sealed class _0002
	{
		public static readonly _0002 _0002;

		public static Comparison<SymmetricAlgorithm> _0008;

		static _0002()
		{
			_0002 obj = new _0002();
			if (6u != 0)
			{
				global::_0008_2001._0002._0002 = obj;
			}
		}

		public _0002()
		{
			_ = 8;
			if (5 == 0)
			{
			}
			base._002Ector();
		}

		internal int _0002(SymmetricAlgorithm _0002, SymmetricAlgorithm _0008)
		{
			int blockSize = _0008.BlockSize;
			int num;
			if (2u != 0)
			{
				num = blockSize;
			}
			return num.CompareTo(_0002.BlockSize);
		}
	}

	private sealed class _0008 : ICryptoTransform, IDisposable
	{
		private readonly byte[] m__0002;

		private readonly byte[] m__0008;

		private readonly SymmetricAlgorithm[] _0006;

		private ICryptoTransform[] _000F;

		private readonly bool _0005;

		private readonly int _0003;

		public int InputBlockSize
		{
			get
			{
				_ = 6;
				if (8 == 0)
				{
				}
				return _0003;
			}
		}

		public int OutputBlockSize
		{
			get
			{
				_ = 4;
				if (5 == 0)
				{
				}
				return _0003;
			}
		}

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public _0008(SymmetricAlgorithm[] _0002, byte[] _0008, byte[] _0006, bool _000F)
		{
			if (8u != 0)
			{
				this.m__0002 = _0008;
			}
			if (2u != 0)
			{
				this.m__0008 = _0006;
			}
			if (uint.MaxValue != 0)
			{
				this._0006 = _0002;
			}
			_0005 = _000F;
			_0003 = _0002[_0002.Length - 1].BlockSize / 8;
		}

		public void Dispose()
		{
			if (_000F == null)
			{
				return;
			}
			ICryptoTransform[] array = _000F;
			ICryptoTransform[] array2;
			if (5u != 0)
			{
				array2 = array;
			}
			int i;
			if (8u != 0)
			{
				i = 0;
			}
			for (; i < array2.Length; i++)
			{
				ICryptoTransform cryptoTransform = array2[i];
				ICryptoTransform cryptoTransform2;
				if (2u != 0)
				{
					cryptoTransform2 = cryptoTransform;
				}
				cryptoTransform2?.Dispose();
			}
			_000F = null;
		}

		private void _0002()
		{
			SymmetricAlgorithm[] array = _0006;
			SymmetricAlgorithm[] array2;
			if (uint.MaxValue != 0)
			{
				array2 = array;
			}
			int num = array2.Length;
			int num2;
			if (7u != 0)
			{
				num2 = num;
			}
			if (_000F == null)
			{
				ICryptoTransform[] array3 = new ICryptoTransform[num2];
				ICryptoTransform[] array4 = default(ICryptoTransform[]);
				if (0 == 0)
				{
					array4 = array3;
				}
				int num3 = 0;
				for (int i = 0; i < num2; i++)
				{
					SymmetricAlgorithm symmetricAlgorithm = array2[i];
					int num4 = symmetricAlgorithm.KeySize / 8;
					byte[] array5 = new byte[num4];
					Buffer.BlockCopy(this.m__0002, num3, array5, 0, num4);
					num3 += num4;
					byte[] rgbIV = new byte[symmetricAlgorithm.BlockSize / 8];
					ICryptoTransform cryptoTransform = (_0005 ? symmetricAlgorithm.CreateEncryptor(array5, rgbIV) : symmetricAlgorithm.CreateDecryptor(array5, rgbIV));
					array4[i] = cryptoTransform;
				}
				_000F = array4;
			}
		}

		public byte[] TransformFinalBlock(byte[] _0002, int _0008, int _0006)
		{
			byte[] array = new byte[_0006];
			byte[] array2;
			if (6u != 0)
			{
				array2 = array;
			}
			TransformBlock(_0002, _0008, _0006, array2, 0);
			return array2;
		}

		public int TransformBlock(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005)
		{
			if (0 == 0)
			{
				Buffer.BlockCopy(_0002, _0008, _000F, _0005, _0006);
			}
			if (4u != 0)
			{
				this._0002();
			}
			if (this._0005)
			{
				if (7u != 0)
				{
					this._0002(_000F, _0005, _0006);
				}
			}
			else
			{
				this._0008(_000F, _0005, _0006);
			}
			return _0006;
		}

		private void _0002(byte[] _0002, int _0008, int _0006)
		{
			byte[] array = new byte[this.m__0008.Length];
			byte[] array2;
			if (7u != 0)
			{
				array2 = array;
			}
			byte[] src = this.m__0008;
			int count = array2.Length;
			if (3u != 0)
			{
				Buffer.BlockCopy(src, 0, array2, 0, count);
			}
			int num;
			if (4u != 0)
			{
				num = 0;
			}
			ICryptoTransform[] array3 = _000F;
			foreach (ICryptoTransform cryptoTransform in array3)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0006 - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0008;
					global::_0008_2001._0008._0002(_0002, num4, array2, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0002, num4, inputBlockSize, _0002, num4);
					Buffer.BlockCopy(_0002, num4, array2, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0006)
				{
					break;
				}
			}
		}

		private void _0008(byte[] _0002, int _0008, int _0006)
		{
			byte[] array = new byte[this.m__0008.Length];
			byte[] array2;
			if (5u != 0)
			{
				array2 = array;
			}
			byte[] src = this.m__0008;
			int count = array2.Length;
			if (5u != 0)
			{
				Buffer.BlockCopy(src, 0, array2, 0, count);
			}
			byte[] array3 = new byte[array2.Length];
			byte[] array4;
			if (true)
			{
				array4 = array3;
			}
			int num = 0;
			ICryptoTransform[] array5 = _000F;
			foreach (ICryptoTransform cryptoTransform in array5)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0006 - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0008;
					Buffer.BlockCopy(_0002, num4, array4, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0002, num4, inputBlockSize, _0002, num4);
					global::_0008_2001._0008._0002(_0002, num4, array2, 0, inputBlockSize);
					Buffer.BlockCopy(array4, 0, array2, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0006)
				{
					break;
				}
			}
		}

		private static void _0002(byte[] _0002, int _0008, byte[] _0006, int _000F, int _0005)
		{
			int num = default(int);
			if (0 == 0)
			{
				num = 0;
			}
			while (num < _0005)
			{
				_0002[_0008 + num] ^= _0006[_000F + num];
				int num2 = num + 1;
				if (3u != 0)
				{
					num = num2;
				}
			}
		}
	}

	private readonly SymmetricAlgorithm[] m__0002;

	private readonly int m__0008;

	public override byte[] IV
	{
		get
		{
			_ = 2;
			if (-1 == 0)
			{
			}
			return base.IV;
		}
		set
		{
			byte[] iVValue = (byte[])value.Clone();
			if (6u != 0)
			{
				IVValue = iVValue;
			}
		}
	}

	public _0008_2001(params SymmetricAlgorithm[] _0002)
	{
		SymmetricAlgorithm[] obj = (SymmetricAlgorithm[])_0002.Clone();
		if (4u != 0)
		{
			_0002 = obj;
		}
		SymmetricAlgorithm[] array = _0002;
		Comparison<SymmetricAlgorithm> comparison = global::_0008_2001._0002._0008;
		if (comparison == null)
		{
			comparison = global::_0008_2001._0002._0002._0002;
			Comparison<SymmetricAlgorithm> obj2 = comparison;
			if (4u != 0)
			{
				global::_0008_2001._0002._0008 = obj2;
			}
		}
		if (2u != 0)
		{
			Array.Sort(array, comparison);
		}
		this.m__0002 = _0002;
		int num = 0;
		SymmetricAlgorithm[] array2 = _0002;
		foreach (SymmetricAlgorithm symmetricAlgorithm in array2)
		{
			num += symmetricAlgorithm.KeySize;
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.None;
		}
		BlockSizeValue = _0002[_0002.Length - 1].BlockSize;
		LegalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(BlockSizeValue, BlockSizeValue, 0)
		};
		KeySizeValue = num;
		LegalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(num, num, 0)
		};
		this.m__0008 = _0002[0].BlockSize;
		Mode = CipherMode.ECB;
		Padding = PaddingMode.None;
	}

	public int _0002()
	{
		_ = 3;
		if (2 == 0)
		{
		}
		return this.m__0008;
	}

	public override ICryptoTransform CreateDecryptor(byte[] _0002, byte[] _0008)
	{
		_ = 0;
		if (5 == 0)
		{
		}
		_ = 3;
		if (8 == 0)
		{
		}
		_ = 2;
		if (4 == 0)
		{
		}
		return this._0002(_0002, _0008, _0006: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] _0002, byte[] _0008)
	{
		_ = 8;
		if (5 == 0)
		{
		}
		_ = 8;
		if (1 == 0)
		{
		}
		_ = 5;
		if (6 == 0)
		{
		}
		return this._0002(_0002, _0008, _0006: true);
	}

	private ICryptoTransform _0002(byte[] _0002, byte[] _0008, bool _0006)
	{
		_ = 8;
		if (8 == 0)
		{
		}
		int num = _0002.Length * 8;
		_ = 8;
		if (-1 == 0)
		{
		}
		if (num != KeySize)
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463124596), global::_0008_0010._0002(-1463124572));
		}
		_ = 7;
		if (7 == 0)
		{
		}
		if (_0008.Length * 8 != this._0002())
		{
			throw new ArgumentException(global::_0008_0010._0002(-1463127471), global::_0008_0010._0002(-1463127482));
		}
		return new _0008(this.m__0002, _0002, _0008, _0006);
	}

	public override void GenerateIV()
	{
		throw new NotSupportedException();
	}

	public override void GenerateKey()
	{
		throw new NotSupportedException();
	}
}
internal static class _0008_2001_2005
{
	private sealed class _0002
	{
		private int m__0002;

		private int _0008;

		internal _0002()
		{
			long num = 0L;
			if (2u != 0)
			{
				_0002(num);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal long _0002()
		{
			if ((object)Assembly.GetCallingAssembly() != typeof(_0002).Assembly)
			{
				return 2918384L;
			}
			if (!global::_0008_2001_2005._0002())
			{
				return 2918384L;
			}
			int[] array = new int[4];
			int[] array2;
			if (8u != 0)
			{
				array2 = array;
			}
			array2[3] = ~(-(-(~(~(-(~(-(~832953961))))))));
			array2[1] = -(~(~(-(~(-(~(-(~1282571210))))))));
			array2[2] = -(~(-(~(-(~(~(-(~604258549))))))));
			array2[0] = ~(-(-(~(~(-(~(-(-(~(~-629955329))))))))));
			int num = this.m__0002;
			int num2 = default(int);
			if (0 == 0)
			{
				num2 = num;
			}
			int num3 = _0008;
			int num4;
			if (6u != 0)
			{
				num4 = num3;
			}
			int num5 = -(~(-(~(~(-(-(~(-(~(~1640531529))))))))));
			int num6 = default(int);
			if (0 == 0)
			{
				num6 = num5;
			}
			int num7 = -(~(-(~(~(-(-(~(~957401313))))))));
			int num8;
			if (7u != 0)
			{
				num8 = num7;
			}
			for (int i = 0; i != 32; i++)
			{
				num4 -= (((num2 << 4) ^ (num2 >> 5)) + num2) ^ (num8 + array2[(num8 >> 11) & 3]);
				num8 -= num6;
				num2 -= (((num4 << 4) ^ (num4 >> 5)) + num4) ^ (num8 + array2[num8 & 3]);
			}
			for (int j = 0; j != 4; j++)
			{
				array2[j] = 0;
			}
			ulong num9 = (ulong)((long)num4 << 32);
			return (long)(num9 | (uint)num2);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal void _0002(long _0002)
		{
			if ((object)Assembly.GetCallingAssembly() == typeof(_0002).Assembly && global::_0008_2001_2005._0002())
			{
				int[] array = new int[4];
				int[] array2;
				if (uint.MaxValue != 0)
				{
					array2 = array;
				}
				array2[1] = ~(-(~(-(-(~(~(-(~1282571210))))))));
				array2[0] = ~(-(~(-(-(~(-(~(~(-(~-629955329))))))))));
				array2[2] = ~(-(-(~(~(-(~(-(~604258545))))))));
				array2[3] = -(~(~(-(~(-(~(-(~832953961))))))));
				int num = ~(-(~(-(-(~(~(-(~1640531524))))))));
				int num2;
				if (true)
				{
					num2 = num;
				}
				int num3 = (int)_0002;
				int num4;
				if (5u != 0)
				{
					num4 = num3;
				}
				int num5 = (int)(_0002 >> 32);
				int num6;
				if (3u != 0)
				{
					num6 = num5;
				}
				int num7;
				if (4u != 0)
				{
					num7 = 0;
				}
				for (int i = 0; i != 32; i++)
				{
					num4 += (((num6 << 4) ^ (num6 >> 5)) + num6) ^ (num7 + array2[num7 & 3]);
					num7 += num2;
					num6 += (((num4 << 4) ^ (num4 >> 5)) + num4) ^ (num7 + array2[(num7 >> 11) & 3]);
				}
				for (int j = 0; j != 4; j++)
				{
					array2[j] = 0;
				}
				this.m__0002 = num4;
				_0008 = num6;
			}
		}
	}

	private sealed class _0002_2004
	{
		public _0002_2004()
		{
			_ = 4;
			if (6 == 0)
			{
			}
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return global::_0008_2001_2005._0008._0002(global::_0008_2001_2005._0002(typeof(_0002_2004)), global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0008._0008(global::_0008_2001_2005._0002(typeof(_000E)), global::_0008_2001_2005._0002(typeof(_0006))), global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0002(typeof(_000F)) ^ -(~(~(-(-(~(~(-(-(~(~-1935978639)))))))))), _000E._0002())));
		}
	}

	private sealed class _0003
	{
		public _0003()
		{
			_ = 5;
			if (-1 == 0)
			{
			}
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0002(typeof(_0003)), global::_0008_2001_2005._0008._0002(global::_0008_2001_2005._0002(typeof(_0006)), global::_0008_2001_2005._0008._0008(global::_0008_2001_2005._0002(typeof(_0005)), global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0002(typeof(_000F)), global::_0008_2001_2005._0008._0002(global::_0008_2001_2005._0002(typeof(_000E)), global::_0008_2001_2005._0002(typeof(_0002_2004)))))));
		}
	}

	private sealed class _0005
	{
		public _0005()
		{
			_ = 4;
			if (-1 == 0)
			{
			}
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return global::_0008_2001_2005._0008._0002(global::_0008_2001_2005._0002(typeof(_000F)), global::_0008_2001_2005._0002(typeof(_0003)) ^ global::_0008_2001_2005._0008._0008(global::_0008_2001_2005._0002(typeof(_0005)), global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0002(typeof(_0002_2004)), _0003._0002())));
		}
	}

	private sealed class _0006
	{
		public _0006()
		{
			_ = 3;
			if (5 == 0)
			{
			}
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0008._0008(global::_0008_2001_2005._0002(typeof(_0005)), global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0002(typeof(_0006)), global::_0008_2001_2005._0002(typeof(_000E)))), _0002_2004._0002());
		}
	}

	private static class _0008
	{
		internal static int _0002(int _0002, int _0008)
		{
			_ = 4;
			if (7 == 0)
			{
			}
			_ = 5;
			if (false)
			{
			}
			return _0002 ^ (_0008 - -(~(-(~(~(-(-(~(~-760476153)))))))));
		}

		internal static int _0008(int _0002, int _0008)
		{
			_ = 6;
			if (7 == 0)
			{
			}
			int num = _0002 - -(~(~(-(~(-(~(-(~-1893938491))))))));
			_ = 6;
			if (6 == 0)
			{
			}
			return num ^ (_0008 + ~(-(~(-(-(~(~(-(~(-(~2138715561)))))))))));
		}

		internal static int _0006(int _0002, int _0008)
		{
			_ = 3;
			if (6 == 0)
			{
			}
			_ = 5;
			if (2 == 0)
			{
			}
			int num = _0008 - ~(-(~(-(-(~(~(-(~2065148754))))))));
			_ = 0;
			if (1 == 0)
			{
			}
			return _0002 ^ (num ^ (_0002 - _0008));
		}
	}

	private sealed class _000E
	{
		public _000E()
		{
			_ = 7;
			if (8 == 0)
			{
			}
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return global::_0008_2001_2005._0008._0008(global::_0008_2001_2005._0008._0008(_000F._0002(), global::_0008_2001_2005._0008._0002(global::_0008_2001_2005._0002(typeof(_000E)), _0005._0002())), global::_0008_2001_2005._0002(typeof(_0002_2004)));
		}
	}

	private sealed class _000F
	{
		public _000F()
		{
			_ = 0;
			if (7 == 0)
			{
			}
			base._002Ector();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int _0002()
		{
			return global::_0008_2001_2005._0008._0006(global::_0008_2001_2005._0008._0002(_0005._0002() ^ ~(-(-(~(~(-(~(-(~-527758449)))))))), global::_0008_2001_2005._0002(typeof(_0003))), global::_0008_2001_2005._0008._0008(global::_0008_2001_2005._0002(typeof(_0006)) ^ global::_0008_2001_2005._0002(typeof(_0002_2004)), -(~(-(~(~(-(~(-(~(-(~1368479293))))))))))));
		}
	}

	private static _0002 m__0002;

	static _0008_2001_2005()
	{
		_0002 obj = new _0002();
		if (uint.MaxValue != 0)
		{
			global::_0008_2001_2005.m__0002 = obj;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static long _0002()
	{
		if ((object)Assembly.GetCallingAssembly() != typeof(global::_0008_2001_2005).Assembly || !_0002())
		{
			return 0L;
		}
		_0002 obj = global::_0008_2001_2005.m__0002;
		_0002 obj2;
		if (uint.MaxValue != 0)
		{
			obj2 = obj;
		}
		if (6u != 0)
		{
			Monitor.Enter(obj);
		}
		try
		{
			long num = global::_0008_2001_2005.m__0002._0002();
			long num2 = default(long);
			if (0 == 0)
			{
				num2 = num;
			}
			if (num2 == 0)
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				Assembly assembly;
				if (5u != 0)
				{
					assembly = executingAssembly;
				}
				List<byte> list = new List<byte>();
				List<byte> list2;
				if (3u != 0)
				{
					list2 = list;
				}
				AssemblyName assemblyName;
				try
				{
					assemblyName = assembly.GetName();
				}
				catch
				{
					assemblyName = new AssemblyName(assembly.FullName);
				}
				byte[] array = assemblyName.GetPublicKeyToken();
				if (array != null && array.Length == 0)
				{
					array = null;
				}
				if (array != null)
				{
					list2.AddRange(array);
				}
				list2.AddRange(Encoding.Unicode.GetBytes(assemblyName.Name));
				int num3 = _0002(typeof(global::_0008_2001_2005));
				int num4 = _0006._0002();
				list2.Add((byte)num3);
				list2.Add((byte)(num4 >> 24));
				list2.Add((byte)(num3 >> 24));
				list2.Add((byte)(num4 >> 8));
				list2.Add((byte)(num3 >> 16));
				list2.Add((byte)num4);
				list2.Add((byte)(num3 >> 8));
				list2.Add((byte)(num4 >> 16));
				int count = list2.Count;
				ulong num5 = 0uL;
				for (int i = 0; i != count; i++)
				{
					num5 += list2[i];
					num5 += num5 << 20;
					num5 ^= num5 >> 12;
					list2[i] = 0;
				}
				num5 += num5 << 6;
				num5 ^= num5 >> 22;
				num5 += num5 << 30;
				num2 = (long)num5;
				num2 ^= 0x1F1D22844111CFF8L;
				global::_0008_2001_2005.m__0002._0002(num2);
			}
			return num2;
		}
		finally
		{
			Monitor.Exit(obj2);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void _0002(byte[] _0002)
	{
		if ((object)Assembly.GetCallingAssembly() == typeof(global::_0008_2001_2005).Assembly && global::_0008_2001_2005._0002())
		{
			long num = global::_0008_2001_2005._0002();
			long num2;
			if (uint.MaxValue != 0)
			{
				num2 = num;
			}
			byte[] array = new byte[8];
			byte[] array2;
			if (7u != 0)
			{
				array2 = array;
			}
			array2[0] = (byte)num2;
			array2[1] = (byte)(num2 >> 40);
			array2[2] = (byte)(num2 >> 56);
			array2[3] = (byte)(num2 >> 48);
			array2[4] = (byte)(num2 >> 32);
			array2[5] = (byte)(num2 >> 24);
			array2[6] = (byte)(num2 >> 16);
			array2[7] = (byte)(num2 >> 8);
			int num3 = _0002.Length;
			int num4;
			if (8u != 0)
			{
				num4 = num3;
			}
			for (int i = 0; i != num4; i++)
			{
				_0002[i] ^= (byte)(array2[i & 7] + i);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0002()
	{
		if (!_0008())
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0008()
	{
		StackTrace stackTrace = new StackTrace();
		StackTrace stackTrace2;
		if (7u != 0)
		{
			stackTrace2 = stackTrace;
		}
		StackFrame frame = stackTrace2.GetFrame(3);
		StackFrame stackFrame;
		if (7u != 0)
		{
			stackFrame = frame;
		}
		MethodBase obj = stackFrame?.GetMethod();
		MethodBase methodBase;
		if (8u != 0)
		{
			methodBase = obj;
		}
		Type type = methodBase?.DeclaringType;
		if ((object)type == typeof(RuntimeMethodHandle))
		{
			return false;
		}
		if ((object)type == null)
		{
			return false;
		}
		if ((object)type.Assembly != typeof(global::_0008_2001_2005).Assembly)
		{
			return false;
		}
		return true;
	}

	private static int _0002(Type _0002)
	{
		_ = 7;
		if (3 == 0)
		{
		}
		return _0002.MetadataToken;
	}
}
internal sealed class _0008_2003 : global::_000E_2004
{
	private int m__0002;

	private byte[] m__0008;

	private long _0006;

	private int _000F;

	public _0008_2003()
	{
		_ = 1;
		if (2 == 0)
		{
		}
		base._002Ector();
	}

	[SpecialName]
	[CompilerGenerated]
	public int _000E_2004_2008_2009_0002()
	{
		_ = 2;
		if (4 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (true)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public byte[] _000E_2004_2008_2009_0002()
	{
		_ = 5;
		if (1 == 0)
		{
		}
		return this.m__0008;
	}

	public void _0002(byte[] _0002)
	{
		if (7u != 0)
		{
			this.m__0008 = _0002;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public long _000E_2004_2008_2009_0002()
	{
		_ = 8;
		if (2 == 0)
		{
		}
		return _0006;
	}

	public void _0002(long _0002)
	{
		if (4u != 0)
		{
			_0006 = _0002;
		}
	}

	public int _0002()
	{
		_ = 5;
		if (7 == 0)
		{
		}
		return _000F;
	}

	public void _0008(int _0002)
	{
		if (6u != 0)
		{
			_000F = _0002;
		}
	}
}
internal interface _0008_2003_2005
{
	bool _0008_2003_2005_2008_2009_0002();

	object _0008_2003_2005_2008_2009_0002();

	void _0008_2003_2005_2008_2009_0002();
}
internal sealed class _0008_2004 : global::_0002_2004
{
	private new int m__0002;

	public _0008_2004()
	{
		_ = 0;
		if (1 == 0)
		{
		}
		base._002Ector(23);
	}

	public new int _0002()
	{
		_ = 3;
		if (8 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (true)
		{
			this.m__0002 = _0002;
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (true)
		{
			base._0002(type);
		}
		if (_0002._0002() == 23)
		{
			int num = ((global::_0008_2004)_0002)._0002();
			if (uint.MaxValue != 0)
			{
				this._0002(num);
			}
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0008_2004 obj = new global::_0008_2004();
		_ = 6;
		if (1 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 0;
		if (false)
		{
		}
		obj._0002(((global::_0006)this)._0002());
		return obj;
	}
}
internal sealed class _0008_2004_2005 : global::_0006
{
	private new byte m__0002;

	public _0008_2004_2005()
	{
		_ = 8;
		if (false)
		{
		}
		base._002Ector(12);
	}

	public new byte _0002()
	{
		_ = 0;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(byte _0002)
	{
		if (6u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0008_2004_2005 obj = new global::_0008_2004_2005();
		_ = 1;
		if (1 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 1;
		if (3 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 2;
		if (-1 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (_0002 is short)
		{
			byte num = (byte)(short)_0002;
			if (uint.MaxValue != 0)
			{
				this._0002(num);
			}
		}
		else if (_0002 is int)
		{
			byte num2 = (byte)(int)_0002;
			if (5u != 0)
			{
				this._0002(num2);
			}
		}
		else if (_0002 is long)
		{
			byte num3 = (byte)(long)_0002;
			if (0 == 0)
			{
				this._0002(num3);
			}
		}
		else if (_0002 is ushort)
		{
			this._0002((byte)(ushort)_0002);
		}
		else if (_0002 is uint)
		{
			this._0002((byte)(uint)_0002);
		}
		else if (_0002 is ulong)
		{
			this._0002((byte)(ulong)_0002);
		}
		else if (_0002 is float)
		{
			this._0002((byte)(float)_0002);
		}
		else if (_0002 is double)
		{
			this._0002((byte)(double)_0002);
		}
		else
		{
			this._0002(Convert.ToByte(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (5u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 15:
		{
			byte num3 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (3u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 12:
			this._0002(((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002((byte)((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((byte)((global::_000F)_0002)._0002());
			break;
		case 13:
			this._0002((byte)((global::_0003_2000)_0002)._0002());
			break;
		case 17:
			this._0002((byte)((global::_0003_2001)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToByte(((global::_0002_0010)_0002)._0002()));
			break;
		case 8:
			this._0002((byte)((global::_0006_200A)_0002)._0002());
			break;
		case 22:
			this._0002((byte)((global::_000F_200B)_0002)._0002());
			break;
		case 0:
			this._0002((byte)(int)((global::_0006_2002)_0002)._0002());
			break;
		case 20:
			this._0002((byte)(uint)((global::_0002_2003)_0002)._0002());
			break;
		case 16:
			this._0002((byte)((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002((byte)((global::_000F_2001)_0002)._0002());
			break;
		case 14:
			this._0002((byte)((global::_000E_2006)_0002)._0002());
			break;
		case 7:
			this._0002(Convert.ToByte(((global::_0005_2003)_0002)._0002()));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal sealed class _0008_2005
{
	public readonly global::_000F_2000 _0005_2009_2000;

	public readonly global::_000F_2000 _0002_2005;

	public readonly global::_000F_2000 _0003_2007_2000;

	public readonly global::_000F_2000 _000F_2002_2000;

	public readonly global::_000F_2000 _000F_200A_2005;

	public readonly global::_000F_2000 _0006_2004_2005;

	public readonly global::_000F_2000 _000F_2005;

	public readonly global::_000F_2000 _000E_2000;

	public readonly global::_000F_2000 _0002_200A_2005;

	public readonly global::_000F_2000 _0008_2000_2005;

	public readonly global::_000F_2000 _000F_2000;

	public readonly global::_000F_2000 _0006_2005_2005;

	public readonly global::_000F_2000 _0003_2003;

	public readonly global::_000F_2000 _0002_2007_2005;

	public readonly global::_000F_2000 _0005_2008;

	public readonly global::_000F_2000 _0002_2000_2005;

	public readonly global::_000F_2000 _000F_2003_2005;

	public readonly global::_000F_2000 _0006_200B_2005;

	public readonly global::_000F_2000 _0005_200B;

	public readonly global::_000F_2000 _0003_2000;

	public readonly global::_000F_2000 _0003_2009_2005;

	public readonly global::_000F_2000 _0003_2002_2000;

	public readonly global::_000F_2000 _0005_2001_2000;

	public readonly global::_000F_2000 _000E_2004;

	public readonly global::_000F_2000 _000E_2009;

	public readonly global::_000F_2000 _0006_2002;

	public readonly global::_000F_2000 _0005_2001;

	public readonly global::_000F_2000 _0005_2008_2005;

	public readonly global::_000F_2000 _0006_2007;

	public readonly global::_000F_2000 _0005_2006_2005;

	public readonly global::_000F_2000 _0003_2005;

	public readonly global::_000F_2000 _0006_2001_2000;

	public readonly global::_000F_2000 _000E_2001_2000;

	public readonly global::_000F_2000 _000F_2002_2005;

	public readonly global::_000F_2000 _0002_2009_2005;

	public readonly global::_000F_2000 _0003_2000_2005;

	public readonly global::_000F_2000 _0005_200A;

	public readonly global::_000F_2000 _0002_2007_2000;

	public readonly global::_000F_2000 _0006_2006_2005;

	public readonly global::_000F_2000 _000E_2005_2005;

	public readonly global::_000F_2000 _0006;

	public readonly global::_000F_2000 _0005_2000;

	public readonly global::_000F_2000 _0006_2004;

	public readonly global::_000F_2000 _0003;

	public readonly global::_000F_2000 _0002_2006;

	public readonly global::_000F_2000 _000F_2007_2005;

	public readonly global::_000F_2000 _0008_2001_2005;

	public readonly global::_000F_2000 _000F_2006;

	public readonly global::_000F_2000 _000E_2003_2005;

	public readonly global::_000F_2000 _0005_2006;

	public readonly global::_000F_2000 _000F_2001;

	public readonly global::_000F_2000 _0005_2005;

	public readonly global::_000F_2000 _0002_2006_2005;

	public readonly global::_000F_2000 _0008_2008;

	public readonly global::_000F_2000 _000E_2003;

	public readonly global::_000F_2000 _0008_2007_2000;

	public readonly global::_000F_2000 _000E;

	public readonly global::_000F_2000 _000F_2009;

	public readonly global::_000F_2000 _0006_2003_2005;

	public readonly global::_000F_2000 _0002_2009;

	public readonly global::_000F_2000 _0006_2005;

	public readonly global::_000F_2000 _0008;

	public readonly global::_000F_2000 _000E_2009_2000;

	public readonly global::_000F_2000 _0003_2007_2005;

	public readonly global::_000F_2000 _0006_2002_2000;

	public readonly global::_000F_2000 _0008_2004_2005;

	public readonly global::_000F_2000 _000F_2000_2005;

	public readonly global::_000F_2000 _0006_2008;

	public readonly global::_000F_2000 _0008_2008_2005;

	public readonly global::_000F_2000 _0002_2002;

	public readonly global::_000F_2000 _0003_2009;

	public readonly global::_000F_2000 _000E_2001_2005;

	public readonly global::_000F_2000 _0005_2004_2000;

	public readonly global::_000F_2000 _000F_2002;

	public readonly global::_000F_2000 _0003_2001_2005;

	public readonly global::_000F_2000 _0003_2001;

	public readonly global::_000F_2000 _000F_2007_2000;

	public readonly global::_000F_2000 _0008_2003_2000;

	public readonly global::_000F_2000 _0003_2003_2000;

	public readonly global::_000F_2000 _000F;

	public readonly global::_000F_2000 _0006_2009;

	public readonly global::_000F_2000 _0006_2009_2000;

	public readonly global::_000F_2000 _0008_2007_2005;

	public readonly global::_000F_2000 _0002_200B;

	public readonly global::_000F_2000 _0003_2008_2005;

	public readonly global::_000F_2000 _000E_200B;

	public readonly global::_000F_2000 _000E_2006_2005;

	public readonly global::_000F_2000 _000F_2009_2005;

	public readonly global::_000F_2000 _0006_2008_2005;

	public readonly global::_000F_2000 _0005_2002;

	public readonly global::_000F_2000 _0008_2006_2005;

	public readonly global::_000F_2000 _0006_2001;

	public readonly global::_000F_2000 _000E_2003_2000;

	public readonly global::_000F_2000 _000F_200B;

	public readonly global::_000F_2000 _0006_2003;

	public readonly global::_000F_2000 _000F_2007;

	public readonly global::_000F_2000 _0002_2004_2000;

	public readonly global::_000F_2000 _0002_2008_2005;

	public readonly global::_000F_2000 _000E_200B_2005;

	public readonly global::_000F_2000 _0008_2009;

	public readonly global::_000F_2000 _0003_2009_2000;

	public readonly global::_000F_2000 _0002_2003_2000;

	public readonly global::_000F_2000 _0006_200A_2005;

	public readonly global::_000F_2000 _0008_200A;

	public readonly global::_000F_2000 _0003_2004_2000;

	public readonly global::_000F_2000 _0008_2004;

	public readonly global::_000F_2000 _000F_2001_2000;

	public readonly global::_000F_2000 _0008_200B;

	public readonly global::_000F_2000 _000F_2001_2005;

	public readonly global::_000F_2000 _0002_2009_2000;

	public readonly global::_000F_2000 _0006_2003_2000;

	public readonly global::_000F_2000 _000E_200A;

	public readonly global::_000F_2000 _0003_2006;

	public readonly global::_000F_2000 _0006_2007_2000;

	public readonly global::_000F_2000 _0002_2002_2005;

	public readonly global::_000F_2000 _0008_2009_2005;

	public readonly global::_000F_2000 _0006_2000_2005;

	public readonly global::_000F_2000 _0005_2007_2000;

	public readonly global::_000F_2000 _0002_2005_2005;

	public readonly global::_000F_2000 _0002;

	public readonly global::_000F_2000 _0002_2000;

	public readonly global::_000F_2000 _0002_200A;

	public readonly global::_000F_2000 _0002_200B_2005;

	public readonly global::_000F_2000 _0002_2003;

	public readonly global::_000F_2000 _000E_2007;

	public readonly global::_000F_2000 _000F_2004_2005;

	public readonly global::_000F_2000 _000F_200B_2005;

	public readonly global::_000F_2000 _0005_2003;

	public readonly global::_000F_2000 _0003_2002;

	public readonly global::_000F_2000 _0002_2007;

	public readonly global::_000F_2000 _000E_2009_2005;

	public readonly global::_000F_2000 _0002_2004;

	public readonly global::_000F_2000 _000E_200A_2005;

	public readonly global::_000F_2000 _000E_2005;

	public readonly global::_000F_2000 _0008_2002_2000;

	public readonly global::_000F_2000 _0005_200B_2005;

	public readonly global::_000F_2000 _000E_2004_2000;

	public readonly global::_000F_2000 _0003_2004_2005;

	public readonly global::_000F_2000 _0006_2004_2000;

	public readonly global::_000F_2000 _000F_2004_2000;

	public readonly global::_000F_2000 _0006_2000;

	public readonly global::_000F_2000 _0002_2002_2000;

	public readonly global::_000F_2000 _000E_2002;

	public readonly global::_000F_2000 _000E_2000_2005;

	public readonly global::_000F_2000 _0002_2003_2005;

	public readonly global::_000F_2000 _000F_200A;

	public readonly global::_000F_2000 _0003_2007;

	public readonly global::_000F_2000 _0008_2001_2000;

	public readonly global::_000F_2000 _000E_2008_2005;

	public readonly global::_000F_2000 _0008_2005;

	public readonly global::_000F_2000 _0003_2006_2005;

	private bool _0003_2008;

	public readonly global::_000F_2000 _0008_200B_2005;

	public readonly global::_000F_2000 _0003_2004;

	public readonly global::_000F_2000 _0008_2004_2000;

	public readonly global::_000F_2000 _0008_2006;

	public readonly global::_000F_2000 _0003_2002_2005;

	public readonly global::_000F_2000 _0008_2009_2000;

	public readonly global::_000F_2000 _000E_2001;

	public readonly global::_000F_2000 _0006_200B;

	public readonly global::_000F_2000 _0006_2001_2005;

	public readonly global::_000F_2000 _0002_2001;

	public readonly global::_000F_2000 _0005_200A_2005;

	public readonly global::_000F_2000 _0002_2001_2005;

	public readonly global::_000F_2000 _0005_2002_2005;

	public readonly global::_000F_2000 _0005;

	public readonly global::_000F_2000 _0006_2006;

	public readonly global::_000F_2000 _000F_2006_2005;

	public readonly global::_000F_2000 _0005_2007;

	public readonly global::_000F_2000 _0008_2000;

	public readonly global::_000F_2000 _0008_2002;

	public readonly global::_000F_2000 _0006_2009_2005;

	public readonly global::_000F_2000 _000E_2007_2005;

	public readonly global::_000F_2000 _0005_2002_2000;

	public readonly global::_000F_2000 _0005_2003_2005;

	public readonly global::_000F_2000 _0003_2005_2005;

	public readonly global::_000F_2000 _000F_2008_2005;

	public readonly global::_000F_2000 _000E_2008;

	public readonly global::_000F_2000 _0003_2003_2005;

	public readonly global::_000F_2000 _0003_200A;

	public readonly global::_000F_2000 _0003_200A_2005;

	public readonly global::_000F_2000 _0005_2004;

	public readonly global::_000F_2000 _000F_2005_2005;

	public readonly global::_000F_2000 _000E_2002_2005;

	public readonly global::_000F_2000 _0005_2009;

	public readonly global::_000F_2000 _000F_2009_2000;

	public readonly global::_000F_2000 _0008_2007;

	public readonly global::_000F_2000 _0003_200B_2005;

	public readonly global::_000F_2000 _0005_2007_2005;

	public readonly global::_000F_2000 _000F_2003;

	public readonly global::_000F_2000 _0005_2000_2005;

	public readonly global::_000F_2000 _0008_2005_2005;

	public readonly global::_000F_2000 _0008_2003;

	public readonly global::_000F_2000 _0002_2008;

	public readonly global::_000F_2000 _0008_2003_2005;

	public readonly global::_000F_2000 _0008_2001;

	public readonly global::_000F_2000 _0005_2009_2005;

	public readonly global::_000F_2000 _0003_2001_2000;

	public readonly global::_000F_2000 _0005_2005_2005;

	public readonly global::_000F_2000 _0005_2004_2005;

	public readonly global::_000F_2000 _000F_2004;

	public readonly global::_000F_2000 _000E_2006;

	public readonly global::_000F_2000 _0006_2007_2005;

	public readonly global::_000F_2000 _0003_200B;

	public readonly global::_000F_2000 _0002_2004_2005;

	public readonly global::_000F_2000 _0005_2003_2000;

	public readonly global::_000F_2000 _000E_2007_2000;

	public readonly global::_000F_2000 _0002_2001_2000;

	public readonly global::_000F_2000 _0005_2001_2005;

	public readonly global::_000F_2000 _0006_200A;

	public readonly global::_000F_2000 _000F_2008;

	public readonly global::_000F_2000 _0006_2002_2005;

	public readonly global::_000F_2000 _0008_200A_2005;

	public readonly global::_000F_2000 _000F_2003_2000;

	public readonly global::_000F_2000 _0008_2002_2005;

	public readonly global::_000F_2000 _000E_2004_2005;

	public _0008_2005()
	{
		global::_000F_2000 obj = new global::_000F_2000(613446310, 11);
		if (uint.MaxValue != 0)
		{
			_0006_200B_2005 = obj;
		}
		global::_000F_2000 obj2 = new global::_000F_2000(-2130522749, 2);
		if (3u != 0)
		{
			_0003_2004 = obj2;
		}
		global::_000F_2000 obj3 = new global::_000F_2000(-1141809015, 11);
		if (3u != 0)
		{
			_0005_2005_2005 = obj3;
		}
		global::_000F_2000 obj4 = new global::_000F_2000(-612488651, 1);
		if (4u != 0)
		{
			_0008_2006_2005 = obj4;
		}
		global::_000F_2000 obj5 = new global::_000F_2000(-916932671, 11);
		if (7u != 0)
		{
			_0003_2008_2005 = obj5;
		}
		global::_000F_2000 obj6 = new global::_000F_2000(1433075630, 2);
		if (uint.MaxValue != 0)
		{
			_0005_2006 = obj6;
		}
		global::_000F_2000 obj7 = new global::_000F_2000(-2048326813, 11);
		if (2u != 0)
		{
			_0006_2002_2005 = obj7;
		}
		global::_000F_2000 obj8 = new global::_000F_2000(1496551833, 11);
		if (2u != 0)
		{
			_0005_2007_2000 = obj8;
		}
		global::_000F_2000 obj9 = new global::_000F_2000(1421490248, 11);
		if (4u != 0)
		{
			_0002_2001 = obj9;
		}
		global::_000F_2000 obj10 = new global::_000F_2000(107135113, 0);
		if (2u != 0)
		{
			_0006_2009_2005 = obj10;
		}
		_0003_2006 = new global::_000F_2000(950965520, 1);
		_000F_2006 = new global::_000F_2000(-49009516, 11);
		_0006_2002_2000 = new global::_000F_2000(236195827, 11);
		_0006_2005 = new global::_000F_2000(1792389720, 11);
		_0008_2003 = new global::_000F_2000(-622097164, 2);
		_0006_2007 = new global::_000F_2000(-465076030, 11);
		_0005_2004 = new global::_000F_2000(-638913934, 11);
		_000E_200A = new global::_000F_2000(-1134321514, 11);
		_0008_2005 = new global::_000F_2000(549277292, 11);
		_000F_2004_2000 = new global::_000F_2000(1887599133, 11);
		_000F_2004_2005 = new global::_000F_2000(-204915459, 11);
		_0003_200B_2005 = new global::_000F_2000(-115292843, 11);
		_000E_2004_2005 = new global::_000F_2000(1827520327, 11);
		_000E_2003 = new global::_000F_2000(280740050, 11);
		_0003_200A_2005 = new global::_000F_2000(-822643630, 11);
		_0006_2008 = new global::_000F_2000(1303336308, 11);
		_000E_2009 = new global::_000F_2000(-1851906861, 11);
		_000F = new global::_000F_2000(490291398, 11);
		_000E_2007_2005 = new global::_000F_2000(-53699846, 11);
		_0006_2001_2000 = new global::_000F_2000(-1060528005, 2);
		_000E = new global::_000F_2000(385681979, 11);
		_000E_2000 = new global::_000F_2000(-837858297, 11);
		_0008_2001_2005 = new global::_000F_2000(-579535459, 1);
		_0005_2009 = new global::_000F_2000(-1564474085, 6);
		_000F_2001_2000 = new global::_000F_2000(1631287465, 11);
		_0008_2007_2005 = new global::_000F_2000(-829027397, 2);
		_0003_2000 = new global::_000F_2000(717569924, 11);
		_0006_2003_2000 = new global::_000F_2000(2110302218, 1);
		_0002_2008 = new global::_000F_2000(-305417248, 11);
		_0008_2008_2005 = new global::_000F_2000(-1367789536, 11);
		_0003_2001 = new global::_000F_2000(493532257, 2);
		_0008_2003_2005 = new global::_000F_2000(-94394784, 11);
		_0008 = new global::_000F_2000(-1823170615, 11);
		_000F_200B_2005 = new global::_000F_2000(919812192, 11);
		_0003_2002_2000 = new global::_000F_2000(-1836565664, 11);
		_0002_2002_2000 = new global::_000F_2000(657526240, 11);
		_0002_2005 = new global::_000F_2000(126425333, 11);
		_0006_2009 = new global::_000F_2000(408408037, 0);
		_000F_2003 = new global::_000F_2000(-2010854162, 12);
		_0003_2003_2000 = new global::_000F_2000(-282082342, 11);
		_0003 = new global::_000F_2000(1815698617, 11);
		_000F_2008 = new global::_000F_2000(-1518475257, 1);
		_000E_2004_2000 = new global::_000F_2000(-1339008729, 11);
		_0006_2004_2005 = new global::_000F_2000(-1580620226, 8);
		_000F_2007_2005 = new global::_000F_2000(-1054447675, 11);
		_0006_2000 = new global::_000F_2000(2033640141, 11);
		_0005_200A = new global::_000F_2000(-536160518, 2);
		_0008_2001_2000 = new global::_000F_2000(-453741572, 11);
		_000E_2007 = new global::_000F_2000(1603969379, 11);
		_0008_2009_2000 = new global::_000F_2000(-64695267, 11);
		_0005_2009_2005 = new global::_000F_2000(-846440950, 2);
		_0005_2003 = new global::_000F_2000(-252105856, 11);
		_0006 = new global::_000F_2000(-199317807, 11);
		_000F_2005 = new global::_000F_2000(1060249040, 12);
		_000F_2003_2005 = new global::_000F_2000(1698897048, 2);
		_000F_2001_2005 = new global::_000F_2000(-1868683560, 11);
		_0002_2000_2005 = new global::_000F_2000(1774502604, 11);
		_0008_2007_2000 = new global::_000F_2000(-1282138947, 11);
		_0002_200A_2005 = new global::_000F_2000(-75627345, 11);
		_0008_2007 = new global::_000F_2000(-1866991619, 11);
		_000F_2004 = new global::_000F_2000(1727379895, 11);
		_000E_2006_2005 = new global::_000F_2000(-188628299, 11);
		_0002_2005_2005 = new global::_000F_2000(548649364, 11);
		_0005_2002 = new global::_000F_2000(-1891355286, 11);
		_0003_2005 = new global::_000F_2000(-987466428, 11);
		_000E_200B = new global::_000F_2000(1018905123, 11);
		_0003_200B = new global::_000F_2000(1149299790, 2);
		_0008_2004_2000 = new global::_000F_2000(258152203, 2);
		_0008_2001 = new global::_000F_2000(1569416938, 11);
		_0005_2001 = new global::_000F_2000(-313416003, 11);
		_0002_200A = new global::_000F_2000(1440575169, 11);
		_0002_2004_2000 = new global::_000F_2000(-2074784322, 11);
		_0002_2006 = new global::_000F_2000(-1189054698, 11);
		_0005_2004_2005 = new global::_000F_2000(2058489982, 2);
		_0008_2002_2005 = new global::_000F_2000(1128485632, 11);
		_000F_2005_2005 = new global::_000F_2000(89719556, 3);
		_0008_200B_2005 = new global::_000F_2000(1945116552, 11);
		_0002_2001_2005 = new global::_000F_2000(-1092481360, 11);
		_0005_2003_2005 = new global::_000F_2000(214283674, 11);
		_0005_200A_2005 = new global::_000F_2000(-772329335, 1);
		_0002_2004 = new global::_000F_2000(-511818012, 11);
		_0005_2005 = new global::_000F_2000(-1831125898, 11);
		_0006_2004_2000 = new global::_000F_2000(1466057127, 2);
		_0008_2006 = new global::_000F_2000(1801334322, 11);
		_0003_2003 = new global::_000F_2000(835707921, 2);
		_000F_2009_2005 = new global::_000F_2000(-1266643943, 11);
		_0003_2006_2005 = new global::_000F_2000(-160901594, 2);
		_0002_2009_2005 = new global::_000F_2000(-460429399, 11);
		_0006_2007_2005 = new global::_000F_2000(-1445505853, 3);
		_0008_2004 = new global::_000F_2000(1888274448, 11);
		_0006_2007_2000 = new global::_000F_2000(-61568142, 11);
		_000E_2001_2005 = new global::_000F_2000(580183686, 11);
		_0005_2001_2000 = new global::_000F_2000(588784019, 4);
		_0003_2007_2000 = new global::_000F_2000(731944387, 11);
		_000F_2000_2005 = new global::_000F_2000(-981940920, 11);
		_0006_2003 = new global::_000F_2000(1113631856, 11);
		_000E_2006 = new global::_000F_2000(996432009, 11);
		_000E_2002_2005 = new global::_000F_2000(-2078319842, 11);
		_000F_200B = new global::_000F_2000(-1911646209, 11);
		_0002_2009 = new global::_000F_2000(1493953632, 11);
		_0005 = new global::_000F_2000(-1788504728, 1);
		_0008_2000_2005 = new global::_000F_2000(-645776769, 11);
		_0008_200A = new global::_000F_2000(2058763071, 11);
		_0003_2009_2000 = new global::_000F_2000(717276995, 11);
		_0003_2004_2005 = new global::_000F_2000(-1801468982, 11);
		_0003_2007 = new global::_000F_2000(1201678911, 2);
		_0006_2005_2005 = new global::_000F_2000(1731028115, 11);
		_0006_200A_2005 = new global::_000F_2000(-1308255768, 11);
		_000E_2009_2000 = new global::_000F_2000(-758540423, 1);
		_0006_2006 = new global::_000F_2000(-1916280349, 11);
		_000F_2009_2000 = new global::_000F_2000(-306609481, 2);
		_0005_2008_2005 = new global::_000F_2000(-1590204829, 11);
		_0003_2009 = new global::_000F_2000(-1804513952, 1);
		_0005_200B = new global::_000F_2000(1736011173, 11);
		_000E_2005_2005 = new global::_000F_2000(1680035407, 2);
		_0003_2007_2005 = new global::_000F_2000(-590628435, 11);
		_0002_2004_2005 = new global::_000F_2000(270163448, 11);
		_0002_2007_2005 = new global::_000F_2000(-1253619997, 11);
		_0002_200B = new global::_000F_2000(1154173204, 10);
		_0003_2001_2000 = new global::_000F_2000(-1701667456, 2);
		_0006_2008_2005 = new global::_000F_2000(-2047651073, 2);
		_0005_2007 = new global::_000F_2000(-341276629, 11);
		_0002_200B_2005 = new global::_000F_2000(-82493285, 12);
		_000E_2008 = new global::_000F_2000(2045789426, 11);
		_000E_2001 = new global::_000F_2000(-1833214037, 11);
		_0008_2005_2005 = new global::_000F_2000(344989833, 11);
		_0006_2001_2005 = new global::_000F_2000(1220672300, 2);
		_0003_2005_2005 = new global::_000F_2000(121824405, 11);
		_0005_2002_2005 = new global::_000F_2000(-765531952, 11);
		_000F_2007 = new global::_000F_2000(566134755, 1);
		_0003_2002_2005 = new global::_000F_2000(-815418237, 11);
		_0002_2009_2000 = new global::_000F_2000(-1649265242, 1);
		_0005_2006_2005 = new global::_000F_2000(-696817450, 11);
		this._0002 = new global::_000F_2000(-1501203820, 11);
		_0002_2002 = new global::_000F_2000(-2124690578, 11);
		_0008_2004_2005 = new global::_000F_2000(1877038706, 3);
		_0002_2003_2005 = new global::_000F_2000(990403014, 11);
		_000E_2008_2005 = new global::_000F_2000(1941791556, 11);
		_000F_2008_2005 = new global::_000F_2000(378876979, 11);
		_0008_200B = new global::_000F_2000(408714632, 11);
		_000F_2003_2000 = new global::_000F_2000(-942898028, 11);
		_0006_200A = new global::_000F_2000(-562967701, 2);
		_000E_2003_2000 = new global::_000F_2000(-1276058416, 11);
		_0005_2008 = new global::_000F_2000(-490536081, 11);
		_000F_200A_2005 = new global::_000F_2000(1926832396, 11);
		_0008_2002_2000 = new global::_000F_2000(141738937, 11);
		_0008_2002 = new global::_000F_2000(431036087, 3);
		_0005_2001_2005 = new global::_000F_2000(1956727892, 2);
		_0003_200A = new global::_000F_2000(-1663306705, 11);
		_0006_2006_2005 = new global::_000F_2000(-1224190779, 11);
		_0003_2000_2005 = new global::_000F_2000(-1361246107, 11);
		_000E_2009_2005 = new global::_000F_2000(-582542590, 12);
		_0005_2009_2000 = new global::_000F_2000(1255030323, 11);
		_0005_2002_2000 = new global::_000F_2000(1436802788, 3);
		_0006_2002 = new global::_000F_2000(-2049440945, 11);
		_000E_200B_2005 = new global::_000F_2000(-1744819430, 12);
		_000F_2009 = new global::_000F_2000(-941272517, 2);
		_0006_2001 = new global::_000F_2000(-451827676, 3);
		_0006_2003_2005 = new global::_000F_2000(19912249, 11);
		_0002_2003_2000 = new global::_000F_2000(-1376869358, 11);
		_0008_2003_2000 = new global::_000F_2000(-979607047, 11);
		_000E_200A_2005 = new global::_000F_2000(-60371099, 6);
		_000F_2002 = new global::_000F_2000(-465275762, 2);
		_0002_2008_2005 = new global::_000F_2000(1048370564, 11);
		_000F_2000 = new global::_000F_2000(-1769169231, 2);
		_0003_2001_2005 = new global::_000F_2000(76499606, 11);
		_0002_2000 = new global::_000F_2000(59719869, 11);
		_0002_2007 = new global::_000F_2000(-376404128, 2);
		_0006_200B = new global::_000F_2000(870682828, 2);
		_0002_2007_2000 = new global::_000F_2000(378964815, 11);
		_0003_2009_2005 = new global::_000F_2000(1942122911, 2);
		_0005_2000 = new global::_000F_2000(1025982787, 11);
		_0003_2002 = new global::_000F_2000(-2106182995, 11);
		_0005_2000_2005 = new global::_000F_2000(850084556, 11);
		_0002_2001_2000 = new global::_000F_2000(977827572, 11);
		_0005_2007_2005 = new global::_000F_2000(-259612091, 11);
		_0008_2009 = new global::_000F_2000(892497550, 11);
		_000F_2007_2000 = new global::_000F_2000(-1678112293, 11);
		_0003_2004_2000 = new global::_000F_2000(-1078812531, 11);
		_000F_2001 = new global::_000F_2000(265061594, 11);
		_0008_2008 = new global::_000F_2000(-657567106, 11);
		_0006_2009_2000 = new global::_000F_2000(-1758937543, 11);
		_0008_200A_2005 = new global::_000F_2000(544618790, 11);
		_0006_2000_2005 = new global::_000F_2000(1841985120, 11);
		_0005_2004_2000 = new global::_000F_2000(195810761, 11);
		_000E_2007_2000 = new global::_000F_2000(1823995728, 11);
		_000F_2002_2005 = new global::_000F_2000(-688436806, 2);
		_0002_2002_2005 = new global::_000F_2000(-2054364040, 11);
		_000E_2001_2000 = new global::_000F_2000(187695706, 2);
		_0002_2003 = new global::_000F_2000(-1719566883, 11);
		_0002_2006_2005 = new global::_000F_2000(-308201813, 11);
		_000F_2002_2000 = new global::_000F_2000(1966841514, 1);
		_000F_200A = new global::_000F_2000(-510095007, 11);
		_000E_2000_2005 = new global::_000F_2000(779300813, 11);
		_000E_2003_2005 = new global::_000F_2000(-2022406491, 11);
		_0008_2009_2005 = new global::_000F_2000(-1287682159, 2);
		_0003_2003_2005 = new global::_000F_2000(915123251, 9);
		_0005_2003_2000 = new global::_000F_2000(-1807146911, 1);
		_0005_200B_2005 = new global::_000F_2000(-304312483, 11);
		_000E_2002 = new global::_000F_2000(1137378022, 11);
		_0006_2004 = new global::_000F_2000(-1427318383, 11);
		_000F_2006_2005 = new global::_000F_2000(-1088671186, 1);
		_000E_2004 = new global::_000F_2000(1739918084, 11);
		_0008_2000 = new global::_000F_2000(706004215, 11);
		_000E_2005 = new global::_000F_2000(1541885135, 12);
		base._002Ector();
	}

	public bool _0002()
	{
		_ = 6;
		if (3 == 0)
		{
		}
		return _0003_2008;
	}

	public void _0002(bool _0002)
	{
		if (8u != 0)
		{
			_0003_2008 = _0002;
		}
	}
}
internal sealed class _0008_2006
{
	private byte[] m__0002;

	private int m__0008;

	private long m__0006;

	private uint _000F;

	private uint _0005;

	private uint _0003;

	private uint _000E;

	private uint _0002_2004;

	private uint[] _0008_2004;

	private int _0006_2004;

	public _0008_2006()
	{
		uint[] array = new uint[80];
		if (3u != 0)
		{
			_0008_2004 = array;
		}
		base._002Ector();
		byte[] array2 = new byte[4];
		if (0 == 0)
		{
			this.m__0002 = array2;
		}
		if (2u != 0)
		{
			this._0008();
		}
	}

	public _0008_2006(global::_0008_2006 _0002)
	{
		uint[] array = new uint[80];
		if (7u != 0)
		{
			_0008_2004 = array;
		}
		base._002Ector();
		if (6u != 0)
		{
			this._0002(_0002);
		}
	}

	public void _0002(byte _0002)
	{
		byte[] array = this.m__0002;
		int num = this.m__0008;
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		int num3 = num2 + 1;
		if (uint.MaxValue != 0)
		{
			this.m__0008 = num3;
		}
		array[num2] = _0002;
		if (this.m__0008 == this.m__0002.Length)
		{
			byte[] array2 = this.m__0002;
			if (true)
			{
				this._0002(array2, 0);
			}
			this.m__0008 = 0;
		}
		this.m__0006++;
	}

	public void _0002(byte[] _0002, int _0008, int _0006)
	{
		int num = System.Math.Max(0, _0006);
		if (uint.MaxValue != 0)
		{
			_0006 = num;
		}
		int i = default(int);
		if (0 == 0)
		{
			i = 0;
		}
		if (this.m__0008 != 0)
		{
			int num3 = default(int);
			while (i < _0006)
			{
				byte[] array = this.m__0002;
				int num2 = this.m__0008;
				if (0 == 0)
				{
					num3 = num2;
				}
				this.m__0008 = num3 + 1;
				array[num3] = _0002[_0008 + i++];
				if (this.m__0008 == 4)
				{
					this._0002(this.m__0002, 0);
					this.m__0008 = 0;
					break;
				}
			}
		}
		for (int num4 = ((_0006 - i) & -4) + i; i < num4; i += 4)
		{
			this._0002(_0002, _0008 + i);
		}
		while (i < _0006)
		{
			this.m__0002[this.m__0008++] = _0002[_0008 + i++];
		}
		this.m__0006 += _0006;
	}

	public void _0002()
	{
		long num = this.m__0006 << 3;
		long num2;
		if (4u != 0)
		{
			num2 = num;
		}
		if (7u != 0)
		{
			_0002(128);
		}
		while (this.m__0008 != 0)
		{
			if (7u != 0)
			{
				_0002(0);
			}
		}
		_0002(num2);
		_0006();
	}

	public int _0002()
	{
		return 64;
	}

	private void _0002(global::_0008_2006 _0002)
	{
		byte[] array = new byte[_0002.m__0002.Length];
		if (true)
		{
			this.m__0002 = array;
		}
		byte[] src = _0002.m__0002;
		byte[] dst = this.m__0002;
		int count = _0002.m__0002.Length;
		if (3u != 0)
		{
			Buffer.BlockCopy(src, 0, dst, 0, count);
		}
		int num = _0002.m__0008;
		if (true)
		{
			this.m__0008 = num;
		}
		this.m__0006 = _0002.m__0006;
		_000F = _0002._000F;
		_0005 = _0002._0005;
		_0003 = _0002._0003;
		_000E = _0002._000E;
		_0002_2004 = _0002._0002_2004;
		Array.Copy(_0002._0008_2004, 0, _0008_2004, 0, _0002._0008_2004.Length);
		_0006_2004 = _0002._0006_2004;
	}

	public int _0008()
	{
		return 20;
	}

	public void _0002(byte[] _0002, int _0008)
	{
		_0008_2004[_0006_2004] = global::_0008_2006._0002(_0002, _0008);
		int num = _0006_2004 + 1;
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		if (3u != 0)
		{
			_0006_2004 = num2;
		}
		if (num2 == 16)
		{
			if (6u != 0)
			{
				_0006();
			}
		}
	}

	public void _0002(long _0002)
	{
		if (_0006_2004 > 14)
		{
			if (2u != 0)
			{
				_0006();
			}
		}
		_0008_2004[14] = (uint)((ulong)_0002 >> 32);
		_0008_2004[15] = (uint)_0002;
	}

	public int _0002(byte[] _0002, int _0008)
	{
		if (5u != 0)
		{
			this._0002();
		}
		uint num = _000F;
		if (7u != 0)
		{
			global::_0008_2006._0002(num, _0002, _0008);
		}
		uint num2 = _0005;
		int num3 = _0008 + 4;
		if (7u != 0)
		{
			global::_0008_2006._0002(num2, _0002, num3);
		}
		global::_0008_2006._0002(_0003, _0002, _0008 + 8);
		global::_0008_2006._0002(_000E, _0002, _0008 + 12);
		global::_0008_2006._0002(_0002_2004, _0002, _0008 + 16);
		this._0008();
		return 20;
	}

	public void _0008()
	{
		long num = 0L;
		if (6u != 0)
		{
			this.m__0006 = num;
		}
		if (uint.MaxValue != 0)
		{
			this.m__0008 = 0;
		}
		byte[] array = this.m__0002;
		int length = this.m__0002.Length;
		if (true)
		{
			Array.Clear(array, 0, length);
		}
		_000F = 1732584193u;
		_0005 = 4023233417u;
		_0003 = 2562383102u;
		_000E = 271733878u;
		_0002_2004 = 3285377520u;
		_0006_2004 = 0;
		Array.Clear(_0008_2004, 0, _0008_2004.Length);
	}

	private static uint _0002(uint _0002, uint _0008, uint _0006)
	{
		_ = 6;
		if (1 == 0)
		{
		}
		_ = 8;
		if (3 == 0)
		{
		}
		uint num = _0002 & _0008;
		_ = 7;
		if (2 == 0)
		{
		}
		return num | (~_0002 & _0006);
	}

	private static uint _0008(uint _0002, uint _0008, uint _0006)
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		_ = 4;
		if (7 == 0)
		{
		}
		uint num = _0002 ^ _0008;
		_ = 4;
		if (6 == 0)
		{
		}
		return num ^ _0006;
	}

	private static uint _0006(uint _0002, uint _0008, uint _0006)
	{
		_ = 3;
		if (5 == 0)
		{
		}
		_ = 0;
		if (4 == 0)
		{
		}
		uint num = _0002 & _0008;
		_ = 4;
		if (false)
		{
		}
		return num | (_0002 & _0006) | (_0008 & _0006);
	}

	private void _0006()
	{
		int num;
		if (5u != 0)
		{
			num = 16;
		}
		while (num < 80)
		{
			uint num2 = _0008_2004[num - 3] ^ _0008_2004[num - 8] ^ _0008_2004[num - 14] ^ _0008_2004[num - 16];
			uint num3;
			if (3u != 0)
			{
				num3 = num2;
			}
			_0008_2004[num] = (num3 << 1) | (num3 >> 31);
			int num4 = num + 1;
			if (3u != 0)
			{
				num = num4;
			}
		}
		uint num5 = _000F;
		uint num6;
		if (6u != 0)
		{
			num6 = num5;
		}
		uint num7 = _0005;
		uint num8;
		if (3u != 0)
		{
			num8 = num7;
		}
		uint num9 = _0003;
		uint num10;
		if (7u != 0)
		{
			num10 = num9;
		}
		uint num11 = _000E;
		uint num12;
		if (6u != 0)
		{
			num12 = num11;
		}
		uint num13 = _0002_2004;
		uint num14 = default(uint);
		if (0 == 0)
		{
			num14 = num13;
		}
		int num15;
		if (4u != 0)
		{
			num15 = 0;
		}
		int i;
		if (3u != 0)
		{
			i = 0;
		}
		for (; i < 4; i++)
		{
			num14 += ((num6 << 5) | (num6 >> 27)) + _0002(num8, num10, num12) + _0008_2004[num15++] + 1518500249;
			num8 = (num8 << 30) | (num8 >> 2);
			num12 += ((num14 << 5) | (num14 >> 27)) + _0002(num6, num8, num10) + _0008_2004[num15++] + 1518500249;
			num6 = (num6 << 30) | (num6 >> 2);
			num10 += ((num12 << 5) | (num12 >> 27)) + _0002(num14, num6, num8) + _0008_2004[num15++] + 1518500249;
			num14 = (num14 << 30) | (num14 >> 2);
			num8 += ((num10 << 5) | (num10 >> 27)) + _0002(num12, num14, num6) + _0008_2004[num15++] + 1518500249;
			num12 = (num12 << 30) | (num12 >> 2);
			num6 += ((num8 << 5) | (num8 >> 27)) + _0002(num10, num12, num14) + _0008_2004[num15++] + 1518500249;
			num10 = (num10 << 30) | (num10 >> 2);
		}
		for (int j = 0; j < 4; j++)
		{
			num14 += ((num6 << 5) | (num6 >> 27)) + _0008(num8, num10, num12) + _0008_2004[num15++] + 1859775393;
			num8 = (num8 << 30) | (num8 >> 2);
			num12 += ((num14 << 5) | (num14 >> 27)) + _0008(num6, num8, num10) + _0008_2004[num15++] + 1859775393;
			num6 = (num6 << 30) | (num6 >> 2);
			num10 += ((num12 << 5) | (num12 >> 27)) + _0008(num14, num6, num8) + _0008_2004[num15++] + 1859775393;
			num14 = (num14 << 30) | (num14 >> 2);
			num8 += ((num10 << 5) | (num10 >> 27)) + _0008(num12, num14, num6) + _0008_2004[num15++] + 1859775393;
			num12 = (num12 << 30) | (num12 >> 2);
			num6 += ((num8 << 5) | (num8 >> 27)) + _0008(num10, num12, num14) + _0008_2004[num15++] + 1859775393;
			num10 = (num10 << 30) | (num10 >> 2);
		}
		for (int k = 0; k < 4; k++)
		{
			num14 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0006(num8, num10, num12) + _0008_2004[num15++]) + -1894007588);
			num8 = (num8 << 30) | (num8 >> 2);
			num12 += (uint)((int)(((num14 << 5) | (num14 >> 27)) + _0006(num6, num8, num10) + _0008_2004[num15++]) + -1894007588);
			num6 = (num6 << 30) | (num6 >> 2);
			num10 += (uint)((int)(((num12 << 5) | (num12 >> 27)) + _0006(num14, num6, num8) + _0008_2004[num15++]) + -1894007588);
			num14 = (num14 << 30) | (num14 >> 2);
			num8 += (uint)((int)(((num10 << 5) | (num10 >> 27)) + _0006(num12, num14, num6) + _0008_2004[num15++]) + -1894007588);
			num12 = (num12 << 30) | (num12 >> 2);
			num6 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + _0006(num10, num12, num14) + _0008_2004[num15++]) + -1894007588);
			num10 = (num10 << 30) | (num10 >> 2);
		}
		for (int l = 0; l < 4; l++)
		{
			num14 += (uint)((int)(((num6 << 5) | (num6 >> 27)) + _0008(num8, num10, num12) + _0008_2004[num15++]) + -899497514);
			num8 = (num8 << 30) | (num8 >> 2);
			num12 += (uint)((int)(((num14 << 5) | (num14 >> 27)) + _0008(num6, num8, num10) + _0008_2004[num15++]) + -899497514);
			num6 = (num6 << 30) | (num6 >> 2);
			num10 += (uint)((int)(((num12 << 5) | (num12 >> 27)) + _0008(num14, num6, num8) + _0008_2004[num15++]) + -899497514);
			num14 = (num14 << 30) | (num14 >> 2);
			num8 += (uint)((int)(((num10 << 5) | (num10 >> 27)) + _0008(num12, num14, num6) + _0008_2004[num15++]) + -899497514);
			num12 = (num12 << 30) | (num12 >> 2);
			num6 += (uint)((int)(((num8 << 5) | (num8 >> 27)) + _0008(num10, num12, num14) + _0008_2004[num15++]) + -899497514);
			num10 = (num10 << 30) | (num10 >> 2);
		}
		_000F += num6;
		_0005 += num8;
		_0003 += num10;
		_000E += num12;
		_0002_2004 += num14;
		_0006_2004 = 0;
		Array.Clear(_0008_2004, 0, 16);
	}

	private static void _0002(uint _0002, byte[] _0008, int _0006)
	{
		_ = 1;
		if (8 == 0)
		{
		}
		_ = 0;
		if (2 == 0)
		{
		}
		_ = 0;
		if (7 == 0)
		{
		}
		_0008[_0006] = (byte)(_0002 >> 24);
		_0008[_0006 + 1] = (byte)(_0002 >> 16);
		_0008[_0006 + 2] = (byte)(_0002 >> 8);
		_0008[_0006 + 3] = (byte)_0002;
	}

	private static uint _0002(byte[] _0002, int _0008)
	{
		_ = 3;
		if (7 == 0)
		{
		}
		_ = 5;
		if (2 == 0)
		{
		}
		int num = _0002[_0008] << 24;
		_ = 3;
		if (-1 == 0)
		{
		}
		return (uint)(num | (_0002[_0008 + 1] << 16) | (_0002[_0008 + 2] << 8) | _0002[_0008 + 3]);
	}

	public global::_0008_2006 _0002()
	{
		_ = 7;
		if (false)
		{
		}
		return new global::_0008_2006(this);
	}

	public void _0008(global::_0008_2006 _0002)
	{
		if (6u != 0)
		{
			this._0002(_0002);
		}
	}
}
internal sealed class _0008_2007 : global::_0002_2007
{
	private global::_0003_2008 _0002;

	private readonly int _0008;

	private readonly int _0006;

	public _0008_2007(bool _0002, global::_0008_200A _0008)
	{
		global::_0003_2008 obj = new global::_0003_2008();
		if (6u != 0)
		{
			this._0002 = obj;
		}
		this._0002._0002(_0002, _0008);
		int num = this._0002._0002();
		if (0 == 0)
		{
			this._0008 = num;
		}
		int num2 = this._0002._0008();
		if (7u != 0)
		{
			_0006 = num2;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0002()
	{
		_ = 4;
		if (2 == 0)
		{
		}
		return _0008;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0008()
	{
		_ = 3;
		if (1 == 0)
		{
		}
		return _0006;
	}

	public int _0002_2007_2008_2009_0002(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005, RandomNumberGenerator _0003)
	{
		global::_0006_2005 obj = this._0002._0002(_0002, _0008, _0006);
		global::_0006_2005 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		global::_0006_2005 obj3 = this._0002._0002(obj2);
		global::_0006_2005 obj4;
		if (8u != 0)
		{
			obj4 = obj3;
		}
		return this._0002._0002(obj4, _000F, _0005);
	}
}
internal sealed class _0008_2007_2005 : global::_0002_200B
{
	private new Array m__0002;

	private long _0008;

	public _0008_2007_2005()
	{
		_ = 5;
		if (false)
		{
		}
		base._002Ector(24);
	}

	public new Array _0002()
	{
		_ = 5;
		if (false)
		{
		}
		return this.m__0002;
	}

	public void _0002(Array _0002)
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new long _0002()
	{
		_ = -1;
		if (false)
		{
		}
		return _0008;
	}

	public void _0002(long _0002)
	{
		if (2u != 0)
		{
			_0008 = _0002;
		}
	}

	[SpecialName]
	public override object _0002_200B_2008_2009_0002()
	{
		_ = 3;
		if (2 == 0)
		{
		}
		Array array = this.m__0002;
		_ = 8;
		if (1 == 0)
		{
		}
		return array.GetValue(_0008);
	}

	[SpecialName]
	public override void _0002_200B_2008_2009_0002(object _0002)
	{
		_ = -1;
		if (5 == 0)
		{
		}
		Array array = this.m__0002;
		_ = 5;
		if (false)
		{
		}
		_ = 1;
		if (false)
		{
		}
		array.SetValue(_0002, _0008);
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (2u != 0)
		{
			((global::_0006)this)._0002(type);
		}
		if (_0002._0002() == 24)
		{
			global::_0008_2007_2005 obj = (global::_0008_2007_2005)_0002;
			global::_0008_2007_2005 obj2;
			if (2u != 0)
			{
				obj2 = obj;
			}
			Array array = obj2._0002();
			if (0 == 0)
			{
				this._0002(array);
			}
			this._0002(obj2._0002());
			base._0002(((global::_0002_200B)obj2)._0002());
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_0008_2007_2005 obj = new global::_0008_2007_2005();
		_ = 8;
		if (7 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = -1;
		if (6 == 0)
		{
		}
		obj._0002(_0008);
		_ = 8;
		if (false)
		{
		}
		obj._0002(base._0002());
		((global::_0006)obj)._0002(((global::_0006)this)._0002());
		return obj;
	}

	public override bool _0002_200B_2008_2009_0002(global::_0002_200B _0002)
	{
		global::_0008_2007_2005 obj = (global::_0008_2007_2005)_0002;
		global::_0008_2007_2005 obj2;
		if (4u != 0)
		{
			obj2 = obj;
		}
		if (this._0002() == obj2._0002())
		{
			return this._0002() == obj2._0002();
		}
		return false;
	}
}
internal sealed class _0008_2008 : global::_0002_2007, IDisposable
{
	private global::_0002_2000 m__0002;

	private byte[] m__0008;

	private readonly int _0006;

	private readonly int _000F;

	public _0008_2008(global::_0002_2000 _0002)
	{
		if (_0002 == null)
		{
			throw new ArgumentNullException();
		}
		if (_0002._0002())
		{
			throw new NotSupportedException();
		}
		if (uint.MaxValue != 0)
		{
			this.m__0002 = _0002;
		}
		byte[] array = new byte[_0002._0002_2007_2008_2009_0008()];
		if (true)
		{
			this.m__0008 = array;
		}
		int num = this._0002();
		if (4u != 0)
		{
			_0006 = num;
		}
		_000F = _0008();
	}

	private int _0002()
	{
		_ = 8;
		if (8 == 0)
		{
		}
		return this.m__0002._0002_2007_2008_2009_0002();
	}

	private int _0008()
	{
		_ = -1;
		if (3 == 0)
		{
		}
		return this.m__0002._0002_2007_2008_2009_0008() - 10;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0002()
	{
		_ = 1;
		if (2 == 0)
		{
		}
		return _0006;
	}

	[SpecialName]
	[CompilerGenerated]
	public int _0002_2007_2008_2009_0008()
	{
		_ = 2;
		if (2 == 0)
		{
		}
		return _000F;
	}

	public int _0002_2007_2008_2009_0002(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005, RandomNumberGenerator _0003)
	{
		_ = 8;
		if (1 == 0)
		{
		}
		_ = 0;
		if (false)
		{
		}
		_ = 1;
		if (-1 == 0)
		{
		}
		return this._0002(_0002, _0008, _0006, _000F, _0005, _0003);
	}

	private int _0002(byte[] _0002, int _0008, int _0006, byte[] _000F, int _0005, RandomNumberGenerator _0003)
	{
		int num = this.m__0002._0002_2007_2008_2009_0008();
		int num2;
		if (7u != 0)
		{
			num2 = num;
		}
		byte[] array = this.m__0008;
		byte[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		this.m__0002._0002_2007_2008_2009_0002(_0002, _0008, _0006, array2, 0, _0003);
		byte num3 = array2[0];
		bool num4 = num3 != 2;
		bool flag;
		if (true)
		{
			flag = num4;
		}
		int num5 = global::_0008_2008._0002(num3, array2, 0, num2);
		num5++;
		if (flag || num5 < 10)
		{
			throw new InvalidOperationException(global::_0008_0010._0002(-1463127265));
		}
		int num6 = num2 - num5;
		Buffer.BlockCopy(array2, num5, _000F, _0005, num6);
		return num6;
	}

	private static int _0002(byte _0002, byte[] _0008, int _0006, int _000F)
	{
		int num = _0006 + 1;
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		while (num2 != _0006 + _000F)
		{
			if (_0008[num2] == 0)
			{
				return num2;
			}
			int num3 = num2 + 1;
			if (4u != 0)
			{
				num2 = num3;
			}
		}
		return -1;
	}

	public void Dispose()
	{
		if (this.m__0002 != null)
		{
			this.m__0002.Dispose();
			if (true)
			{
				this.m__0002 = null;
			}
		}
	}
}
internal sealed class _0008_2009 : global::_0002_2009, IDisposable
{
	private SecureString m__0002;

	public _0008_2009()
	{
		SecureString secureString = new SecureString();
		if (8u != 0)
		{
			this.m__0002 = secureString;
		}
		base._002Ector();
	}

	[SpecialName]
	public int _0002_2009_2008_2009_0002()
	{
		_ = 7;
		if (4 == 0)
		{
		}
		return this.m__0002.Length;
	}

	public global::_0002_2009 _0002_2009_2008_2009_0002()
	{
		return new global::_0008_2009();
	}

	public void _0002_2009_2008_2009_0002(int _0002, out byte _0008)
	{
		if (_0002 < 0 || _0002 >= this._0002_2009_2008_2009_0002())
		{
			throw new ArgumentOutOfRangeException();
		}
		IntPtr zero = IntPtr.Zero;
		IntPtr intPtr;
		if (4u != 0)
		{
			intPtr = zero;
		}
		char c;
		if (6u != 0)
		{
			c = '\0';
		}
		try
		{
			IntPtr intPtr2 = Marshal.SecureStringToGlobalAllocUnicode(this.m__0002);
			if (2u != 0)
			{
				intPtr = intPtr2;
			}
			c = (char)Marshal.ReadInt16(intPtr, _0002 * 2);
			_0008 = global::_0008_2009._0002(c, _0002);
		}
		finally
		{
			global::_000F_2003._0002(ref c);
			if (intPtr != IntPtr.Zero)
			{
				Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
			}
		}
	}

	public void _0002_2009_2008_2009_0008(int _0002, ref byte _0008)
	{
		int length = this.m__0002.Length;
		int num;
		if (5u != 0)
		{
			num = length;
		}
		while (true)
		{
			if (num > _0002)
			{
				this.m__0002.SetAt(_0002, global::_0008_2009._0002(_0008, _0002));
				return;
			}
			if (num == _0002)
			{
				break;
			}
			this.m__0002.AppendChar(global::_0008_2009._0002(0, num));
			int num2 = num + 1;
			if (true)
			{
				num = num2;
			}
		}
		this.m__0002.AppendChar(global::_0008_2009._0002(_0008, num));
	}

	private static char _0002(byte _0002, int _0008)
	{
		_ = -1;
		if (4 == 0)
		{
		}
		return (char)(_0002 + 1);
	}

	private static byte _0002(char _0002, int _0008)
	{
		_ = 0;
		if (false)
		{
		}
		return (byte)(_0002 - 1);
	}

	public void _0002_2009_2008_2009_0002()
	{
		_ = 8;
		if (7 == 0)
		{
		}
		this.m__0002.Clear();
	}

	public void Dispose()
	{
		this.m__0002.Dispose();
		if (0 == 0)
		{
			this.m__0002 = null;
		}
	}
}
public sealed class _0008_2009_2005 : INotifyPropertyChanged
{
	public UserControlTabMain _0002;

	public UserControlTabInGame _0008;

	public UserControlTabGeneralSettings _0006;

	public PluginsUserControl _000F;

	public LoggingUserControl _0005;

	public ChatUserControler _0003;

	public UserControlTabTools _000E;

	public UserControlMiniMap _0002_2004;

	private HamburgerMenuItemCollection _0008_2004;

	private HamburgerMenuItemCollection _0006_2004;

	private PropertyChangedEventHandler _000F_2004;

	public Grid ProductSettingsGridTab
	{
		get
		{
			_ = 2;
			if (false)
			{
			}
			UserControlTabMain userControlTabMain = this._0002;
			if (userControlTabMain == null)
			{
				if (2 == 0)
				{
				}
				return null;
			}
			return userControlTabMain.ProductSettingsGrid;
		}
	}

	public HamburgerMenuItemCollection MenuItems
	{
		get
		{
			_ = 4;
			if (8 == 0)
			{
			}
			return _0008_2004;
		}
		set
		{
			if (!object.Equals(value, _0008_2004))
			{
				if (4u != 0)
				{
					_0008_2004 = value;
				}
				_0008_2009_2005_2008_2009_0002(global::_0008_0010._0002(-1463130354));
			}
		}
	}

	public HamburgerMenuItemCollection MenuOptionItems
	{
		get
		{
			_ = 2;
			if (2 == 0)
			{
			}
			return _0006_2004;
		}
		set
		{
			if (!object.Equals(value, _0006_2004))
			{
				if (0 == 0)
				{
					_0006_2004 = value;
				}
				_0008_2009_2005_2008_2009_0002(global::_0008_0010._0002(-1463130306));
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _000F_2004;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			if (2u != 0)
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
			}
			PropertyChangedEventHandler propertyChangedEventHandler4;
			do
			{
				PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
				if (2u != 0)
				{
					propertyChangedEventHandler4 = propertyChangedEventHandler3;
				}
				PropertyChangedEventHandler obj = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler4, value);
				PropertyChangedEventHandler value2;
				if (uint.MaxValue != 0)
				{
					value2 = obj;
				}
				propertyChangedEventHandler2 = Interlocked.CompareExchange(ref _000F_2004, value2, propertyChangedEventHandler4);
			}
			while ((object)propertyChangedEventHandler2 != propertyChangedEventHandler4);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = _000F_2004;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			if (6u != 0)
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
			}
			PropertyChangedEventHandler propertyChangedEventHandler4 = default(PropertyChangedEventHandler);
			do
			{
				PropertyChangedEventHandler propertyChangedEventHandler3 = propertyChangedEventHandler2;
				if (0 == 0)
				{
					propertyChangedEventHandler4 = propertyChangedEventHandler3;
				}
				PropertyChangedEventHandler obj = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler4, value);
				PropertyChangedEventHandler value2;
				if (2u != 0)
				{
					value2 = obj;
				}
				propertyChangedEventHandler2 = Interlocked.CompareExchange(ref _000F_2004, value2, propertyChangedEventHandler4);
			}
			while ((object)propertyChangedEventHandler2 != propertyChangedEventHandler4);
		}
	}

	public _0008_2009_2005()
	{
		_ = 7;
		if (3 == 0)
		{
		}
		base._002Ector();
	}

	public void _0002()
	{
		object[] array = new object[1];
		object[] array2;
		if (5u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (6u != 0)
		{
			obj._0002(stream, "N-]boIsufV", array2);
		}
	}

	protected virtual void _0008_2009_2005_2008_2009_0002([CallerMemberName] string _0002)
	{
		object[] array = new object[2];
		object[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (3u != 0)
		{
			obj._0002(stream, ">C(R>Isuh9", array2);
		}
	}
}
internal sealed class _0008_200A
{
	private readonly bool m__0002;

	private readonly global::_0006_2005 m__0008;

	private readonly global::_0006_2005 _0006;

	public _0008_200A(bool _0002, global::_0006_2005 _0008, global::_0006_2005 _0006)
	{
		if (_0008 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463127161));
		}
		if (_0006 == null)
		{
			throw new ArgumentNullException(global::_0008_0010._0002(-1463127115));
		}
		if (5u != 0)
		{
			this.m__0002 = _0002;
		}
		if (8u != 0)
		{
			this.m__0008 = _0008;
		}
		if (6u != 0)
		{
			this._0006 = _0006;
		}
	}

	public bool _0002()
	{
		_ = -1;
		if (5 == 0)
		{
		}
		return this.m__0002;
	}

	public global::_0006_2005 _0002()
	{
		_ = 1;
		if (8 == 0)
		{
		}
		return this.m__0008;
	}

	public global::_0006_2005 _0008()
	{
		_ = 1;
		if (-1 == 0)
		{
		}
		return _0006;
	}
}
[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
[global::_0006_2006]
internal sealed class _000E : Attribute
{
	public readonly int _0002;

	public _000E(int _0002)
	{
		if (0 == 0)
		{
			this._0002 = _0002;
		}
	}
}
internal static class _000E_2000
{
	private delegate void _0002(Array _0002, RuntimeFieldHandle _0008);

	private static readonly _0002 m__0002;

	static _000E_2000()
	{
		_0002 obj = RuntimeHelpers.InitializeArray;
		if (true)
		{
			global::_000E_2000.m__0002 = obj;
		}
	}

	public static void _0002(Array _0002, RuntimeFieldHandle _0008)
	{
		if (global::_0003_2007._0002())
		{
			_ = 0;
			if (false)
			{
			}
			_ = FieldInfo.GetFieldFromHandle(_0008).MetadataToken;
			if (5u != 0)
			{
			}
		}
		_0002 obj = global::_000E_2000.m__0002;
		_ = 4;
		if (1 == 0)
		{
		}
		obj(_0002, _0008);
	}
}
internal static class _000E_2001
{
	public static bool _0002(Type _0002, Type _0008, out int _0006)
	{
		_0006 = 0;
		if (_0002 == _0008)
		{
			_0006 = 1;
			return true;
		}
		if (_0002 == null || _0008 == null)
		{
			return false;
		}
		if (_0002.IsByRef)
		{
			if (!_0008.IsByRef)
			{
				return false;
			}
			return global::_000E_2001._0002(_0002.GetElementType(), _0008.GetElementType(), out _0006);
		}
		if (_0008.IsByRef)
		{
			return false;
		}
		if (_0002.IsPointer)
		{
			if (!_0008.IsPointer)
			{
				return false;
			}
			return global::_000E_2001._0002(_0002.GetElementType(), _0008.GetElementType(), out _0006);
		}
		if (_0008.IsPointer)
		{
			return false;
		}
		if (_0002.IsArray)
		{
			if (!_0008.IsArray)
			{
				return false;
			}
			if (_0002.GetArrayRank() != _0008.GetArrayRank())
			{
				return false;
			}
			return global::_000E_2001._0002(_0002.GetElementType(), _0008.GetElementType(), out _0006);
		}
		if (_0008.IsArray)
		{
			return false;
		}
		if (_0002.IsGenericType != _0008.IsGenericType)
		{
			return false;
		}
		if (_0002.IsGenericType)
		{
			Type obj = (_0002.IsGenericTypeDefinition ? _0002 : _0002.GetGenericTypeDefinition());
			Type obj2 = (_0008.IsGenericTypeDefinition ? _0008 : _0008.GetGenericTypeDefinition());
			Type type;
			if (7u != 0)
			{
				type = obj2;
			}
			if (obj != type)
			{
				return false;
			}
			Type[] genericArguments = _0002.GetGenericArguments();
			Type[] array = default(Type[]);
			if (0 == 0)
			{
				array = genericArguments;
			}
			Type[] genericArguments2 = _0008.GetGenericArguments();
			Type[] array2;
			if (5u != 0)
			{
				array2 = genericArguments2;
			}
			if (array.Length != array2.Length)
			{
				return false;
			}
			int num;
			if (8u != 0)
			{
				num = 0;
			}
			while (num < array.Length)
			{
				if (global::_000E_2001._0002(array[num], array2[num], out var num2))
				{
					_0006 += num2;
				}
				int num3 = num + 1;
				if (5u != 0)
				{
					num = num3;
				}
			}
		}
		else if (_0002 != _0008)
		{
			return false;
		}
		_0006++;
		return true;
	}
}
internal struct _000E_2002
{
	public int _0002;

	public int _0008;
}
internal sealed class _000E_2003 : global::_0003_2003
{
	public _000E_2003(byte[] _0002, long _0008)
	{
		_ = 8;
		if (1 == 0)
		{
		}
		_ = 8;
		if (1 == 0)
		{
		}
		_ = 7;
		if (5 == 0)
		{
		}
		base._002Ector(_0002, _0008);
	}

	public byte[] _0002(global::_0005 _0002, global::_000E_2004 _0008)
	{
		byte[] array = new byte[4];
		byte[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		int? num = array2.Length;
		if (4u != 0)
		{
			global::_000E_2003._0002(_0002, array2, 0, num);
		}
		int num2 = global::_0003_2003._0002(base._0002(array2, _0008: false), 0);
		int num3;
		if (5u != 0)
		{
			num3 = num2;
		}
		int num4 = global::_0003_2003._0008(num3);
		int value = num4 - 4;
		byte[] array3 = new byte[num4];
		global::_000E_2003._0002(_0002, array3, 4, value);
		Buffer.BlockCopy(array2, 0, array3, 0, 4);
		byte[] src = base._0002(array3, _0008: false);
		byte[] array4 = new byte[num3];
		Buffer.BlockCopy(src, 4, array4, 0, num3);
		return array4;
	}

	public byte[] _0002(byte[] _0002)
	{
		byte[] array = base._0002(_0002, _0008: false);
		int num = global::_0003_2003._0002(array, 0);
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		byte[] array2 = new byte[num2];
		byte[] array3;
		if (uint.MaxValue != 0)
		{
			array3 = array2;
		}
		if (7u != 0)
		{
			Buffer.BlockCopy(array, 4, array3, 0, num2);
		}
		return array3;
	}

	private static void _0002(global::_0005 _0002, byte[] _0008, int _0006, int? _000F)
	{
		int? num;
		if (4u != 0)
		{
			num = _000F;
		}
		int num2 = num ?? (_0008.Length - _0006);
		int num3;
		if (6u != 0)
		{
			num3 = num2;
		}
		int num4;
		while ((num4 = _0002._0005_2008_2009_0002(_0008, _0006, num3)) > 0)
		{
			int num5 = _0006 + num4;
			if (0 == 0)
			{
				_0006 = num5;
			}
			num3 -= num4;
		}
	}
}
internal sealed class _000E_2003_2005
{
	public _000E_2003_2005()
	{
		_ = 6;
		if (7 == 0)
		{
		}
		base._002Ector();
	}
}
internal interface _000E_2004
{
	int _000E_2004_2008_2009_0002();

	byte[] _000E_2004_2008_2009_0002();

	long _000E_2004_2008_2009_0002();
}
internal sealed class _000E_2004_2005 : DeriveBytes
{
	private static volatile bool _0002;

	private DeriveBytes _0008;

	private readonly byte[] _0006;

	private readonly byte[] _000F;

	private readonly int _0005;

	public _000E_2004_2005(byte[] _0002, byte[] _0008, int _0006)
	{
		if (uint.MaxValue != 0)
		{
			this._0006 = _0002;
		}
		if (7u != 0)
		{
			_000F = _0008;
		}
		if (true)
		{
			_0005 = _0006;
		}
		if (!global::_000E_2004_2005._0002)
		{
			try
			{
				this._0008 = new Rfc2898DeriveBytes(_0002, _0008, _0006);
			}
			catch
			{
				global::_000E_2004_2005._0002 = true;
			}
		}
		if (this._0008 == null)
		{
			this._0008 = new global::_0008(_0002, _0008, _0006);
		}
	}

	public override byte[] GetBytes(int _0002)
	{
		byte[] array;
		if (8u != 0)
		{
			array = null;
		}
		if (!global::_000E_2004_2005._0002)
		{
			try
			{
				byte[] bytes = _0008.GetBytes(_0002);
				if (uint.MaxValue != 0)
				{
					array = bytes;
				}
			}
			catch
			{
				global::_000E_2004_2005._0002 = true;
			}
		}
		if (array == null)
		{
			global::_0008 obj2 = new global::_0008(_0006, _000F, _0005);
			if (2u != 0)
			{
				_0008 = obj2;
			}
			array = _0008.GetBytes(_0002);
		}
		return array;
	}

	public override void Reset()
	{
		throw new NotSupportedException();
	}
}
internal sealed class _000E_2005 : global::_0006
{
	private new object m__0002;

	public _000E_2005(object _0002)
		: base(25)
	{
		if (_0002 != null && !(_0002 is ValueType))
		{
			throw new ArgumentException();
		}
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new object _0002()
	{
		_ = 0;
		if (4 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(object _0002)
	{
		if (_0002 != null && !(_0002 is ValueType))
		{
			throw new ArgumentException();
		}
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 5;
		if (4 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (3u != 0)
		{
			this._0002(_0002);
		}
	}

	private new static bool _0002(Type _0002)
	{
		if (_0002.IsGenericType && _0002.Namespace == global::_0008_0010._0002(-1463127091))
		{
			string name = _0002.Name;
			string text;
			if (6u != 0)
			{
				text = name;
			}
			if (text == global::_0008_0010._0002(-1463127048) || text == global::_0008_0010._0002(-1463127065))
			{
				return false;
			}
		}
		return true;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (5u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 25:
		{
			object obj = ((global::_000E_2005)_0002)._0002();
			object obj2;
			if (true)
			{
				obj2 = obj;
			}
			object obj3 = this._0002();
			if (obj3 != null && obj2 != null)
			{
				Type type2 = obj3.GetType();
				if (!type2.IsPrimitive && !type2.IsEnum && type2 == obj2.GetType() && global::_000E_2005._0002(type2))
				{
					FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						fieldInfo.SetValue(obj3, fieldInfo.GetValue(obj2));
					}
					break;
				}
			}
			this._0002(obj2);
			break;
		}
		case 7:
			this._0002(((global::_0005_2003)_0002)._0002());
			break;
		default:
			this._0002(_0002._0006_2008_2009_0002());
			break;
		}
		return this;
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		_ = 2;
		if (3 == 0)
		{
		}
		global::_000E_2005 obj = new global::_000E_2005(this.m__0002);
		_ = 7;
		if (4 == 0)
		{
		}
		((global::_0006)obj)._0002(base._0002());
		return obj;
	}
}
internal sealed class _000E_2006 : global::_0006
{
	private new ulong m__0002;

	public _000E_2006()
	{
		_ = 2;
		if (4 == 0)
		{
		}
		base._002Ector(14);
	}

	public new ulong _0002()
	{
		_ = 3;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(ulong _0002)
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
		if (_0002 is short)
		{
			long num = (short)_0002;
			if (7u != 0)
			{
				this._0002((ulong)num);
			}
		}
		else if (_0002 is int)
		{
			long num2 = (int)_0002;
			if (4u != 0)
			{
				this._0002((ulong)num2);
			}
		}
		else if (_0002 is long)
		{
			long num3 = (long)_0002;
			if (uint.MaxValue != 0)
			{
				this._0002((ulong)num3);
			}
		}
		else if (_0002 is float)
		{
			this._0002((ulong)(float)_0002);
		}
		else if (_0002 is double)
		{
			this._0002((ulong)(double)_0002);
		}
		else
		{
			this._0002(Convert.ToUInt64(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000E_2006 obj = new global::_000E_2006();
		_ = 2;
		if (7 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 5;
		if (8 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (4u != 0)
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
		case 15:
		{
			long num3 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (5u != 0)
			{
				this._0002((ulong)num3);
			}
			break;
		}
		case 12:
			this._0002(((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002((ulong)((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((ulong)((global::_000F)_0002)._0002());
			break;
		case 17:
			this._0002((ulong)((global::_0003_2001)_0002)._0002());
			break;
		case 16:
			this._0002(((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002(((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002((ulong)((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002(((global::_000E_2006)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToUInt64(((global::_0002_0010)_0002)._0002()));
			break;
		case 7:
			this._0002(Convert.ToUInt64(((global::_0005_2003)_0002)._0002()));
			break;
		case 0:
			this._0002((ulong)(long)((global::_0006_2002)_0002)._0002());
			break;
		case 20:
			this._0002((ulong)((global::_0002_2003)_0002)._0002());
			break;
		case 22:
			this._0002((ulong)((global::_000F_200B)_0002)._0002());
			break;
		case 8:
			this._0002((ulong)((global::_0006_200A)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal static class _000E_2007
{
	public static global::_0002_2009 _0002()
	{
		object obj = _0008();
		if (obj == null)
		{
			if (2 == 0)
			{
			}
			obj = new global::_0002_2002();
		}
		return (global::_0002_2009)obj;
	}

	private static global::_0002_2009 _0008()
	{
		try
		{
			global::_0008_2009 obj = new global::_0008_2009();
			global::_0008_2009 obj2;
			if (3u != 0)
			{
				obj2 = obj;
			}
			if (!_0002(obj2))
			{
				obj2.Dispose();
				if (2u != 0)
				{
					return null;
				}
			}
			else if (4u != 0)
			{
				return obj2;
			}
		}
		catch (Exception ex) when (!_0002(ex))
		{
			return null;
		}
		global::_0002_2009 result;
		return result;
	}

	private static bool _0002(Exception _0002)
	{
		_ = 6;
		if (4 == 0)
		{
		}
		if (!(_0002 is ThreadAbortException))
		{
			_ = 5;
			if (-1 == 0)
			{
			}
			return _0002 is ThreadInterruptedException;
		}
		return true;
	}

	private static bool _0002(global::_0002_2009 _0002)
	{
		byte[] obj = new byte[3] { 0, 130, 255 };
		byte[] array;
		if (5u != 0)
		{
			array = obj;
		}
		int i;
		if (8u != 0)
		{
			i = 0;
		}
		for (; i < array.Length; i++)
		{
			byte num = array[i];
			byte b;
			if (6u != 0)
			{
				b = num;
			}
			_0002._0002_2009_2008_2009_0008(i, ref b);
		}
		if (_0002._0002_2009_2008_2009_0002() != array.Length)
		{
			return false;
		}
		for (int j = 0; j < array.Length; j++)
		{
			_0002._0002_2009_2008_2009_0002(j, out var b2);
			if (b2 != array[j])
			{
				return false;
			}
		}
		_0002._0002_2009_2008_2009_0002();
		if (_0002._0002_2009_2008_2009_0002() != 0)
		{
			return false;
		}
		return true;
	}
}
internal interface _000E_2007_2005
{
	global::_0008_2003_2005 _000E_2007_2005_2008_2009_0002();
}
internal sealed class _000E_2008
{
	[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 256)]
	internal struct _0002
	{
	}

	internal static readonly _0002 _0002/* Not supported: data(00 01 02 02 03 03 03 03 04 04 04 04 04 04 04 04 05 05 05 05 05 05 05 05 05 05 05 05 05 05 05 05 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 06 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 07 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08 08) */;

	internal static readonly _0002 _0008/* Not supported: data(A3 D7 09 83 F8 48 F6 F4 B3 21 15 78 99 B1 AF F9 E7 2D 4D 8A CE 4C CA 2E 52 95 D9 1E 4E 38 44 28 0A DF 02 A0 17 F1 60 68 12 B7 7A C3 E9 FA 3D 53 96 84 6B BA F2 63 9A 19 7C AE E5 F5 F7 16 6A A2 39 B6 7B 0F C1 93 81 1B EE B4 1A EA D0 91 2F B8 55 B9 DA 85 3F 41 BF E0 5A 58 80 5F 66 0B D8 90 35 D5 C0 A7 33 06 65 69 45 00 94 56 6D 98 9B 76 97 FC B2 C2 B0 FE DB 20 E1 EB D6 E4 DD 47 4A 1D 42 ED 9E 6E 49 3C CD 43 27 D2 07 D4 DE C7 67 18 89 CB 30 1F 8D C6 8F AA C8 74 DC C9 5D 5C 31 A4 70 88 61 2C 9F 0D 2B 87 50 82 54 64 26 7D 03 40 34 4B 1C 73 D1 C4 FD 3B CC FB 7F AB E6 3E 5B A5 AD 04 23 9C 14 51 22 F0 29 79 71 7E FF 8C 0E E2 0C EF BC 72 75 6F 37 A1 EC D3 8E 62 8B 86 10 E8 08 77 11 BE 92 4F 24 C5 32 36 9D CF F3 A6 BB AC 5E 6C A9 13 57 25 B5 E3 BD A8 3A 01 05 59 2A 46) */;
}
internal sealed class _000E_2009 : global::_0006
{
	private new short m__0002;

	public _000E_2009()
	{
		_ = 5;
		if (4 == 0)
		{
		}
		base._002Ector(26);
	}

	public new short _0002()
	{
		_ = 5;
		if (false)
		{
		}
		return this.m__0002;
	}

	public void _0002(short _0002)
	{
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 8;
		if (false)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (_0002 is int)
		{
			short num = (short)(int)_0002;
			if (7u != 0)
			{
				this._0002(num);
			}
		}
		else if (_0002 is long)
		{
			short num2 = (short)(long)_0002;
			if (6u != 0)
			{
				this._0002(num2);
			}
		}
		else if (_0002 is ushort)
		{
			short num3 = (short)(ushort)_0002;
			if (5u != 0)
			{
				this._0002(num3);
			}
		}
		else if (_0002 is uint)
		{
			this._0002((short)(uint)_0002);
		}
		else if (_0002 is ulong)
		{
			this._0002((short)(ulong)_0002);
		}
		else if (_0002 is float)
		{
			this._0002((short)(float)_0002);
		}
		else if (_0002 is double)
		{
			this._0002((short)(double)_0002);
		}
		else
		{
			this._0002(Convert.ToInt16(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000E_2009 obj = new global::_000E_2009();
		_ = 7;
		if (3 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 6;
		if (6 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (5u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2 = default(int);
		if (0 == 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 15:
		{
			byte num3 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (6u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 12:
			this._0002(((global::_0008_2004_2005)_0002)._0002());
			break;
		case 17:
			this._0002(((global::_0003_2001)_0002)._0002());
			break;
		case 26:
			this._0002(((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((short)((global::_000F)_0002)._0002());
			break;
		case 13:
			this._0002((short)((global::_0003_2000)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToInt16(((global::_0002_0010)_0002)._0002()));
			break;
		case 16:
			this._0002((short)((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002((short)((global::_000F_2001)_0002)._0002());
			break;
		case 14:
			this._0002((short)((global::_000E_2006)_0002)._0002());
			break;
		case 8:
			this._0002((short)((global::_0006_200A)_0002)._0002());
			break;
		case 22:
			this._0002((short)((global::_000F_200B)_0002)._0002());
			break;
		case 0:
			this._0002((short)(int)((global::_0006_2002)_0002)._0002());
			break;
		case 7:
			this._0002(Convert.ToInt16(((global::_0005_2003)_0002)._0002()));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal static class _000E_2009_2005
{
	private struct _0002
	{
		public Version _0002;

		public bool _0008;

		public string _0006;

		public string _000F;

		public bool _0005;

		public string _0003;

		public bool _000E;

		public _0002(string _0002)
		{
			this = default(_0002);
			Version version = new Version();
			if (3u != 0)
			{
				this._0002 = version;
			}
			string empty = string.Empty;
			if (4u != 0)
			{
				_0006 = empty;
			}
			string[] array = _0002.Split(',');
			string[] array2;
			if (3u != 0)
			{
				array2 = array;
			}
			foreach (string text in array2)
			{
				string text2 = text.Trim();
				if (text2.StartsWith(global::_0008_0010._0002(-1463133836), StringComparison.OrdinalIgnoreCase))
				{
					this._0002 = new Version(text2.Substring(global::_0008_0010._0002(-1463133836).Length));
					_0008 = true;
				}
				else if (text2.StartsWith(global::_0008_0010._0002(-1463133851), StringComparison.OrdinalIgnoreCase))
				{
					_000F = text2.Substring(global::_0008_0010._0002(-1463133851).Length);
					if (_000F.Equals(global::_0008_0010._0002(-1463133934), StringComparison.OrdinalIgnoreCase))
					{
						_000F = null;
					}
					_0005 = true;
				}
				else if (text2.StartsWith(global::_0008_0010._0002(-1463133952), StringComparison.OrdinalIgnoreCase))
				{
					_0003 = text2.Substring(global::_0008_0010._0002(-1463133952).Length);
					if (_0003.Equals(global::_0008_0010._0002(-1463133898), StringComparison.OrdinalIgnoreCase))
					{
						_0003 = null;
					}
					_000E = true;
				}
				else
				{
					_0006 = text2;
				}
			}
		}

		public string _0002(bool _0002)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2;
			if (6u != 0)
			{
				stringBuilder2 = stringBuilder;
			}
			stringBuilder2.Append(_0006);
			if (_0002)
			{
				stringBuilder2.Append(global::_0008_0010._0002(-1463133917)).Append(this._0002);
			}
			stringBuilder2.Append(global::_0008_0010._0002(-1463133742)).Append(_000F ?? global::_0008_0010._0002(-1463133755)).Append(global::_0008_0010._0002(-1463133709))
				.Append(_0003 ?? global::_0008_0010._0002(-1463133717));
			return stringBuilder2.ToString();
		}
	}

	private sealed class _0006
	{
		private byte[] m__0002;

		private int _0008;

		private int m__0006;

		public _0006(byte[] _0002)
		{
			byte[] array = new byte[256];
			if (8u != 0)
			{
				this.m__0002 = array;
			}
			base._002Ector();
			int num = _0002.Length;
			int num2;
			if (3u != 0)
			{
				num2 = num;
			}
			if (7u != 0)
			{
				_0008 = 0;
			}
			while (_0008 < 256)
			{
				this.m__0002[_0008] = (byte)_0008;
				_0008++;
			}
			for (_0008 = (m__0006 = 0); _0008 < 256; _0008++)
			{
				m__0006 = (m__0006 + _0002[_0008 % num2] + this.m__0002[_0008]) & 0xFF;
				this._0002(_0008, m__0006);
			}
		}

		private void _0002(int _0002, int _0008)
		{
			byte num = this.m__0002[_0002];
			byte b;
			if (5u != 0)
			{
				b = num;
			}
			this.m__0002[_0002] = this.m__0002[_0008];
			this.m__0002[_0008] = b;
		}

		public byte _0002()
		{
			int num = (_0008 + 1) & 0xFF;
			if (6u != 0)
			{
				_0008 = num;
			}
			int num2 = (m__0006 + this.m__0002[_0008]) & 0xFF;
			if (7u != 0)
			{
				m__0006 = num2;
			}
			int num3 = _0008;
			int num4 = m__0006;
			if (8u != 0)
			{
				_0002(num3, num4);
			}
			return this.m__0002[(byte)(this.m__0002[_0008] + this.m__0002[m__0006])];
		}
	}

	private static class _0008
	{
		internal static readonly Dictionary<string, Assembly> _0002;

		static _0008()
		{
			Dictionary<string, Assembly> dictionary = new Dictionary<string, Assembly>(StringComparer.Ordinal);
			if (5u != 0)
			{
				_0002 = dictionary;
			}
		}
	}

	private static class _000F
	{
		internal sealed class _0002
		{
			public string _0002;

			private string m__0008;

			public string _0006;

			public string _000F;

			public bool _0005;

			public bool _0003;

			public bool _000E;

			public bool _0002_2004;

			public bool _0008_2004;

			public bool _0006_2004;

			public string _000F_2004;

			private string _0005_2004;

			public _0002()
			{
				_ = 7;
				if (-1 == 0)
				{
				}
				base._002Ector();
			}

			public string _0002()
			{
				if (this.m__0008 == null)
				{
					byte[] array = Convert.FromBase64String(this._0002);
					byte[] array2;
					if (5u != 0)
					{
						array2 = array;
					}
					string text = Encoding.UTF8.GetString(array2, 0, array2.Length);
					if (6u != 0)
					{
						this.m__0008 = text;
					}
				}
				return this.m__0008;
			}

			public string _0008()
			{
				if (_0005_2004 == null)
				{
					byte[] array = Convert.FromBase64String(_000F_2004);
					byte[] array2;
					if (5u != 0)
					{
						array2 = array;
					}
					string text = Encoding.UTF8.GetString(array2, 0, array2.Length);
					if (6u != 0)
					{
						_0005_2004 = text;
					}
				}
				return _0005_2004;
			}
		}

		private sealed class _0006 : IEnumerable<_0002>, IEnumerable, IEnumerator<_0002>, IDisposable, IEnumerator
		{
			private int _0002;

			private _0002 _0008;

			private int m__0006;

			private string _000F;

			public string _0005;

			private string[] _0003;

			private string _000E;

			private int _0002_2004;

			[DebuggerHidden]
			public _0006(int _0002)
			{
				if (7u != 0)
				{
					this._0002 = _0002;
				}
				int managedThreadId = Thread.CurrentThread.ManagedThreadId;
				if (0 == 0)
				{
					m__0006 = managedThreadId;
				}
			}

			[DebuggerHidden]
			private void _0006_2008_2009_0002()
			{
				if (0 == 0)
				{
					_0003 = null;
				}
				if (5u != 0)
				{
					_000E = null;
				}
				if (5u != 0)
				{
					_0002 = -2;
				}
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				this._0006_2008_2009_0002();
			}

			private bool _0006_2008_2009_0002()
			{
				int num = _0002;
				int num2;
				if (7u != 0)
				{
					num2 = num;
				}
				if (num2 != 0)
				{
					if (num2 != 1)
					{
						return false;
					}
					_0002 = -1;
					goto IL_0188;
				}
				if (uint.MaxValue != 0)
				{
					_0002 = -1;
				}
				string text = global::_0008_0010._0002(-1463133787);
				string text2;
				if (uint.MaxValue != 0)
				{
					text2 = text;
				}
				string[] array = text2.Split(',');
				if (4u != 0)
				{
					_0003 = array;
				}
				if (_000F == null && !global::_000E_2009_2005._0002())
				{
					return false;
				}
				string obj = _0003[0];
				if (uint.MaxValue != 0)
				{
					_000E = obj;
				}
				_0002_2004 = 1;
				goto IL_0196;
				IL_0188:
				_0002_2004 += 4;
				goto IL_0196;
				IL_0196:
				if (_0002_2004 < _0003.Length)
				{
					string text3 = _0003[_0002_2004];
					if (_000F == null || text3.Equals(_000F, StringComparison.Ordinal))
					{
						_0002 obj2 = new _0002();
						obj2._0006 = _000E;
						obj2._0002 = text3;
						string text4 = _0003[_0002_2004 + 1];
						int num3 = text4.IndexOf('|');
						if (num3 >= 0)
						{
							string text5 = text4.Substring(0, num3);
							text4 = text4.Substring(num3 + 1);
							obj2._0005 = text5.IndexOf('a') != -1;
							obj2._0003 = text5.IndexOf('b') != -1;
							obj2._000E = text5.IndexOf('c') != -1;
							obj2._0006_2004 = text5.IndexOf('f') != -1;
						}
						obj2._000F = text4;
						obj2._000F_2004 = _0003[_0002_2004 + 2];
						_0008 = obj2;
						_0002 = 1;
						return true;
					}
					goto IL_0188;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				return this._0006_2008_2009_0002();
			}

			[DebuggerHidden]
			private _0002 _0006_2008_2009_0002()
			{
				_ = 4;
				if (false)
				{
				}
				return _0008;
			}

			_0002 IEnumerator<_0002>.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				return this._0006_2008_2009_0002();
			}

			[DebuggerHidden]
			private void _0006_2008_2009_0008()
			{
				throw new NotSupportedException();
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				this._0006_2008_2009_0008();
			}

			[DebuggerHidden]
			private object _0006_2008_2009_0002()
			{
				_ = 0;
				if (8 == 0)
				{
				}
				return _0008;
			}

			object IEnumerator.get_Current()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				return this._0006_2008_2009_0002();
			}

			[DebuggerHidden]
			private IEnumerator<_0002> _0006_2008_2009_0002()
			{
				_0006 obj;
				if (_0002 == -2 && m__0006 == Thread.CurrentThread.ManagedThreadId)
				{
					if (true)
					{
						_0002 = 0;
					}
					if (5u != 0)
					{
						obj = this;
					}
				}
				else
				{
					_0006 obj2 = new _0006(0);
					if (8u != 0)
					{
						obj = obj2;
					}
				}
				obj._000F = _0005;
				return obj;
			}

			IEnumerator<_0002> IEnumerable<_0002>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				return this._0006_2008_2009_0002();
			}

			[DebuggerHidden]
			private IEnumerator _0006_2008_2009_0002()
			{
				_ = 1;
				if (3 == 0)
				{
				}
				return _0006_2008_2009_0002();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in   
				return this._0006_2008_2009_0002();
			}
		}

		private struct _0008
		{
			private readonly string m__0002;

			private FileStream m__0008;

			public _0008(string _0002)
			{
				this = default(_0008);
				if (5u != 0)
				{
					this.m__0002 = _0002;
				}
			}

			public bool _0002()
			{
				try
				{
					if (this.m__0008 != null)
					{
						if (8 == 0)
						{
							goto IL_0046;
						}
						return false;
					}
					FileStream fileStream = new FileStream(this.m__0002, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, 128, FileOptions.DeleteOnClose);
					if (0 == 0)
					{
						this.m__0008 = fileStream;
					}
				}
				catch
				{
					if (-1 == 0)
					{
						goto IL_0046;
					}
					return false;
				}
				return true;
				IL_0046:
				bool result;
				return result;
			}

			public void _0002()
			{
				Stopwatch stopwatch;
				if (6u != 0)
				{
					stopwatch = null;
				}
				int num;
				if (2u != 0)
				{
					num = 25;
				}
				int num2 = default(int);
				if (0 == 0)
				{
					num2 = 250;
				}
				while (!this._0002())
				{
					if (stopwatch == null)
					{
						stopwatch = Stopwatch.StartNew();
					}
					else
					{
						if (stopwatch.Elapsed.TotalSeconds > 300.0)
						{
							throw new TimeoutException(string.Format(global::_0008_0010._0002(-1463133804), this.m__0002));
						}
						if (num < num2)
						{
							num = System.Math.Min(num * 2, num2);
						}
					}
					Thread.Sleep(num);
				}
			}

			public void _0008()
			{
				if (this.m__0008 != null)
				{
					this.m__0008.Dispose();
					if (7u != 0)
					{
						this.m__0008 = null;
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IEnumerable<_0002> _0002(string _0002)
		{
			_0006 obj = new _0006(-2);
			if (4u != 0)
			{
				obj._0005 = _0002;
			}
			return obj;
		}

		internal static byte[] _0002(_0002 _0002)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(_0002._000F);
			Stream stream;
			if (3u != 0)
			{
				stream = manifestResourceStream;
			}
			if (stream == null)
			{
				return null;
			}
			int num = (int)stream.Length;
			int num2;
			if (3u != 0)
			{
				num2 = num;
			}
			byte[] array = new byte[num2];
			byte[] array2 = default(byte[]);
			if (0 == 0)
			{
				array2 = array;
			}
			stream.Read(array2, 0, num2);
			stream.Dispose();
			if (_0002._0005)
			{
				array2 = _0008(array2);
			}
			if (_0002._0003)
			{
				array2 = global::_000E_2009_2005._0002(array2);
			}
			return array2;
		}

		internal static string _0002(_0002 _0002, bool _0008, byte[] _0006)
		{
			string obj = (_0002._0006_2004 ? _0002._000F : _0002._0006);
			string path;
			if (true)
			{
				path = obj;
			}
			string text = Path.Combine(Path.GetTempPath(), path);
			string text2;
			if (uint.MaxValue != 0)
			{
				text2 = text;
			}
			try
			{
				Directory.CreateDirectory(text2);
			}
			catch
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				if (0 == 0)
				{
					text2 = folderPath;
				}
				text2 = Path.Combine(text2, global::_0008_0010._0002(-1463132533));
				text2 = Path.Combine(text2, path);
				Directory.CreateDirectory(text2);
				if (text2 == null)
				{
					throw;
				}
			}
			string text3 = Path.Combine(text2, _0002._0008());
			_0008 obj3 = new _0008(text3 + global::_0008_0010._0002(-1463132490));
			obj3._0002();
			try
			{
				if (!File.Exists(text3))
				{
					if (_0006 == null)
					{
						_0006 = _000F._0002(_0002);
					}
					File.WriteAllBytes(text3, _0006);
					if (_0008)
					{
						try
						{
							global::_000E_2009_2005._0002(text3, null, 4);
							global::_000E_2009_2005._0002(text2, null, 4);
						}
						catch
						{
						}
					}
				}
			}
			finally
			{
				obj3._0008();
			}
			return text3;
		}

		internal static void _0002(string _0002, bool _0008)
		{
			bool flag;
			if (5u != 0)
			{
				flag = false;
			}
			try
			{
				if (true)
				{
					File.Delete(_0002);
				}
				if (7u != 0)
				{
					flag = true;
				}
			}
			catch
			{
			}
			string directoryName = Path.GetDirectoryName(_0002);
			bool flag2 = false;
			try
			{
				Directory.Delete(directoryName);
				flag = true;
			}
			catch
			{
			}
			if (!_0008)
			{
				return;
			}
			if (!flag)
			{
				try
				{
					global::_000E_2009_2005._0002(_0002, null, 4);
				}
				catch
				{
				}
			}
			if (!flag2)
			{
				try
				{
					global::_000E_2009_2005._0002(directoryName, null, 4);
				}
				catch
				{
				}
			}
		}
	}

	private static int m__0002;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0002()
	{
		if (!_0008())
		{
			return false;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool _0008()
	{
		StackTrace stackTrace = new StackTrace();
		StackTrace stackTrace2;
		if (8u != 0)
		{
			stackTrace2 = stackTrace;
		}
		StackFrame frame = stackTrace2.GetFrame(3);
		StackFrame stackFrame;
		if (7u != 0)
		{
			stackFrame = frame;
		}
		MethodBase obj = stackFrame?.GetMethod();
		MethodBase methodBase;
		if (4u != 0)
		{
			methodBase = obj;
		}
		Type type = methodBase?.DeclaringType;
		if ((object)type == typeof(RuntimeMethodHandle))
		{
			return false;
		}
		if ((object)type == null)
		{
			return false;
		}
		if ((object)type.Assembly != typeof(global::_000E_2009_2005).Assembly)
		{
			return false;
		}
		return true;
	}

	internal static Assembly _0002(string _0002)
	{
		Assembly result = _0008(_0002);
		Assembly result2;
		if (2 == 0)
		{
			return result2;
		}
		return result;
	}

	private static Assembly _0002(object _0002, ResolveEventArgs _0008)
	{
		Assembly result = global::_000E_2009_2005._0008(_0008.Name);
		Assembly result2;
		if (4 == 0)
		{
			return result2;
		}
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Assembly _0008(string _0002)
	{
		_0002 obj = new _0002(_0002.ToUpperInvariant());
		_000F._0002 obj2;
		if (true)
		{
			obj2 = null;
		}
		bool flag;
		if (4u != 0)
		{
			flag = false;
		}
		if (obj2 == null && !flag)
		{
			string text = obj._0002(_0002: false);
			string s;
			if (true)
			{
				s = text;
			}
			string text2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			using IEnumerator<_000F._0002> enumerator = _000F._0002(text2).GetEnumerator();
			if (enumerator.MoveNext())
			{
				_000F._0002 current = enumerator.Current;
				obj2 = current;
			}
		}
		if (obj2 == null)
		{
			return null;
		}
		Dictionary<string, Assembly> dictionary = global::_000E_2009_2005._0008._0002;
		Assembly value;
		lock (dictionary)
		{
			if (!dictionary.TryGetValue(obj2._000F, out value))
			{
				byte[] array = _000F._0002(obj2);
				if (array == null)
				{
					return null;
				}
				bool flag2 = obj2._000E;
				if (!flag2)
				{
					try
					{
						value = Assembly.Load(array);
					}
					catch (FileLoadException)
					{
						flag2 = true;
					}
					catch (BadImageFormatException)
					{
						flag2 = true;
					}
				}
				if (flag2)
				{
					try
					{
						string assemblyFile = _000F._0002(obj2, _0008: true, array);
						value = Assembly.LoadFrom(assemblyFile);
					}
					catch
					{
					}
				}
				dictionary.Add(obj2._000F, value);
			}
		}
		return value;
	}

	private static int _0002()
	{
		return 1;
	}

	internal static void _0002()
	{
		AppDomain.CurrentDomain.AssemblyResolve += _0002;
	}

	private static int _0002(byte[] _0002, int _0008)
	{
		_ = 1;
		if (1 == 0)
		{
		}
		_ = 4;
		if (6 == 0)
		{
		}
		byte num = _0002[_0008];
		_ = 0;
		if (7 == 0)
		{
		}
		return num | (_0002[_0008 + 1] << 24) | (_0002[_0008 + 2] << 8) | (_0002[_0008 + 3] << 16);
	}

	private static int _0008(byte[] _0002, int _0008)
	{
		_ = 5;
		if (1 == 0)
		{
		}
		_ = 1;
		if (false)
		{
		}
		int num = _0002[_0008] << 16;
		_ = 4;
		if (4 == 0)
		{
		}
		return num | _0002[_0008 + 1] | (_0002[_0008 + 2] << 24) | (_0002[_0008 + 3] << 8);
	}

	private static byte[] _0002(byte[] _0002)
	{
		int num = global::_000E_2009_2005._0002(_0002, 0);
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		if (num2 != -1686991929)
		{
			throw new Exception();
		}
		int num3 = _0008(_0002, 4);
		int num4;
		if (6u != 0)
		{
			num4 = num3;
		}
		MemoryStream memoryStream = new MemoryStream(_0002, writable: false);
		Stream stream;
		if (uint.MaxValue != 0)
		{
			stream = memoryStream;
		}
		stream.Position = 8L;
		stream = new DeflateStream(stream, CompressionMode.Decompress);
		BinaryReader binaryReader = new BinaryReader(stream);
		_0002 = binaryReader.ReadBytes(num4);
		binaryReader.Close();
		int num5 = _0002.Length;
		if (num5 != num4)
		{
			throw new Exception();
		}
		return _0002;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static byte[] _0008(byte[] _0002)
	{
		string text = global::_0008_0010._0002(-1463132510);
		string s;
		if (2u != 0)
		{
			s = text;
		}
		byte[] array = Convert.FromBase64String(s);
		byte[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		if (0 == 0)
		{
			global::_0008_2001_2005._0002(array2);
		}
		_0006 obj = new _0006(array2);
		int num = _0002.Length;
		byte b = 0;
		byte b2 = 121;
		byte[] array3 = new byte[8] { 148, 68, 208, 52, 241, 93, 195, 220 };
		for (int i = 0; i != num; i++)
		{
			if (b == 0)
			{
				b2 = obj._0002();
			}
			b++;
			if (b == 32)
			{
				b = 0;
			}
			_0002[i] ^= (byte)(b2 ^ array3[(i >> 2) & 3] ^ array3[b & 3]);
		}
		return _0002;
	}

	[DllImport("kernel32.dll", EntryPoint = "MoveFileEx")]
	private static extern bool _0002(string _0002, string _0008, int _0006);
}
internal sealed class _000E_200A : global::_0006
{
	private new char m__0002;

	public _000E_200A()
	{
		_ = 6;
		if (false)
		{
		}
		base._002Ector(6);
	}

	public new char _0002()
	{
		_ = 8;
		if (3 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(char _0002)
	{
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 1;
		if (3 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		char num = Convert.ToChar(_0002);
		if (5u != 0)
		{
			this._0002(num);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (8u != 0)
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
		case 15:
		{
			char num3 = Convert.ToChar(((global::_0005_200A)_0002)._0002());
			if (uint.MaxValue != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 1:
			this._0002((char)((global::_000F)_0002)._0002());
			break;
		case 13:
			this._0002((char)((global::_0003_2000)_0002)._0002());
			break;
		case 26:
			this._0002((char)((global::_000E_2009)_0002)._0002());
			break;
		case 3:
			this._0002((char)((global::_000F_2001)_0002)._0002());
			break;
		case 14:
			this._0002((char)((global::_000E_2006)_0002)._0002());
			break;
		case 16:
			this._0002((char)((global::_0005_2007)_0002)._0002());
			break;
		case 0:
			this._0002((char)(int)((global::_0006_2002)_0002)._0002());
			break;
		case 20:
			this._0002((char)(uint)((global::_0002_2003)_0002)._0002());
			break;
		case 7:
			this._0002(Convert.ToChar(((global::_0005_2003)_0002)._0002()));
			break;
		case 17:
			this._0002((char)((global::_0003_2001)_0002)._0002());
			break;
		case 12:
			this._0002((char)((global::_0008_2004_2005)_0002)._0002());
			break;
		case 6:
			this._0002(((global::_000E_200A)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToChar(((global::_0002_0010)_0002)._0002()));
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000E_200A obj = new global::_000E_200A();
		_ = 6;
		if (1 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 7;
		if (1 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}
}
internal sealed class _000F : global::_0006
{
	private new int m__0002;

	public _000F()
	{
		_ = 3;
		if (1 == 0)
		{
		}
		base._002Ector(1);
	}

	public _000F(int _0002)
		: this()
	{
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new int _0002()
	{
		_ = 0;
		if (3 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 2;
		if (6 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		int num3;
		if (_0002 is int num)
		{
			ushort num2;
			if (3u != 0)
			{
				num2 = (ushort)num;
			}
			num3 = num2;
		}
		else if (_0002 is int num4)
		{
			uint num5;
			if (8u != 0)
			{
				num5 = (uint)num4;
			}
			num3 = (int)num5;
		}
		else if (_0002 is long num6)
		{
			long num7;
			if (2u != 0)
			{
				num7 = num6;
			}
			num3 = (int)num7;
		}
		else
		{
			num3 = ((_0002 is ulong num8) ? ((int)num8) : ((_0002 is float num9) ? ((int)num9) : ((!(_0002 is double num10)) ? Convert.ToInt32(_0002) : ((int)num10))));
		}
		this._0002(num3);
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000F obj = new global::_000F();
		_ = 8;
		if (3 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 4;
		if (4 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (8u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (uint.MaxValue != 0)
		{
			num2 = num;
		}
		int num3 = default(int);
		switch (num2)
		{
		case 15:
		{
			byte num4 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (0 == 0)
			{
				num3 = num4;
			}
			break;
		}
		case 12:
			num3 = ((global::_0008_2004_2005)_0002)._0002();
			break;
		case 26:
			num3 = ((global::_000E_2009)_0002)._0002();
			break;
		case 1:
			num3 = ((global::_000F)_0002)._0002();
			break;
		case 17:
			num3 = ((global::_0003_2001)_0002)._0002();
			break;
		case 16:
			num3 = ((global::_0005_2007)_0002)._0002();
			break;
		case 13:
			num3 = Convert.ToInt32(((global::_0003_2000)_0002)._0002());
			break;
		case 19:
			num3 = Convert.ToInt32(((global::_0002_0010)_0002)._0002());
			break;
		case 7:
			num3 = Convert.ToInt32(((global::_0005_2003)_0002)._0002());
			break;
		case 0:
			num3 = (int)((global::_0006_2002)_0002)._0002();
			break;
		case 20:
			num3 = (int)(uint)((global::_0002_2003)_0002)._0002();
			break;
		case 22:
			num3 = (int)((global::_000F_200B)_0002)._0002();
			break;
		case 8:
			num3 = (int)((global::_0006_200A)_0002)._0002();
			break;
		case 14:
			num3 = (int)((global::_000E_2006)_0002)._0002();
			break;
		case 3:
			num3 = (int)((global::_000F_2001)_0002)._0002();
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		this._0002(num3);
		return this;
	}
}
internal struct _000F_2000
{
	private int m__0002;

	private readonly byte _0008;

	public _000F_2000(int _0002, byte _0008)
	{
		if (0 == 0)
		{
			this._0002(_0002);
		}
		if (8u != 0)
		{
			this._0008 = _0008;
		}
	}

	[global::_0008_2000]
	public int _0002()
	{
		_ = 8;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(int _0002)
	{
		if (0 == 0)
		{
			this.m__0002 = _0002;
		}
	}

	[global::_0008_2000]
	public byte _0002()
	{
		_ = 5;
		if (5 == 0)
		{
		}
		return _0008;
	}

	public override bool Equals(object _0002)
	{
		if (_0002 is object obj)
		{
			global::_000F_2000 obj2;
			if (uint.MaxValue != 0)
			{
				obj2 = (global::_000F_2000)obj;
			}
			return this._0002(obj2);
		}
		return false;
	}

	public bool _0002(global::_000F_2000 _0002)
	{
		int num = _0002._0002();
		_ = 2;
		if (4 == 0)
		{
		}
		return num == this._0002();
	}

	public static bool operator ==(global::_000F_2000 _0002, global::_000F_2000 _0008)
	{
		_ = 4;
		if (2 == 0)
		{
		}
		return _0002._0002(_0008);
	}

	public static bool operator !=(global::_000F_2000 _0002, global::_000F_2000 _0008)
	{
		_ = 0;
		if (-1 == 0)
		{
		}
		_ = 0;
		if (-1 == 0)
		{
		}
		return !(_0002 == _0008);
	}

	public override int GetHashCode()
	{
		int num = this._0002();
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		return num2.GetHashCode();
	}

	public override string ToString()
	{
		int num = this._0002();
		int num2;
		if (3u != 0)
		{
			num2 = num;
		}
		return num2.ToString();
	}
}
internal sealed class _000F_2001 : global::_0006
{
	private new uint m__0002;

	public _000F_2001()
	{
		_ = 5;
		if (6 == 0)
		{
		}
		base._002Ector(3);
	}

	public new uint _0002()
	{
		_ = 8;
		if (2 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(uint _0002)
	{
		if (4u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 1;
		if (5 == 0)
		{
		}
		return _0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		if (_0002 is short)
		{
			short num = (short)_0002;
			if (true)
			{
				this._0002((uint)num);
			}
		}
		else if (_0002 is int)
		{
			int num2 = (int)_0002;
			if (8u != 0)
			{
				this._0002((uint)num2);
			}
		}
		else if (_0002 is long)
		{
			int num3 = (int)(long)_0002;
			if (6u != 0)
			{
				this._0002((uint)num3);
			}
		}
		else if (_0002 is ulong)
		{
			this._0002((uint)(ulong)_0002);
		}
		else if (_0002 is float)
		{
			this._0002((uint)(float)_0002);
		}
		else if (_0002 is double)
		{
			this._0002((uint)(double)_0002);
		}
		else
		{
			this._0002(Convert.ToUInt32(_0002));
		}
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000F_2001 obj = new global::_000F_2001();
		_ = 3;
		if (5 == 0)
		{
		}
		obj._0002(this.m__0002);
		_ = 3;
		if (8 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (8u != 0)
		{
			base._0002(type);
		}
		int num = _0002._0002();
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		switch (num2)
		{
		case 15:
		{
			byte num3 = Convert.ToByte(((global::_0005_200A)_0002)._0002());
			if (6u != 0)
			{
				this._0002(num3);
			}
			break;
		}
		case 12:
			this._0002(((global::_0008_2004_2005)_0002)._0002());
			break;
		case 26:
			this._0002((uint)((global::_000E_2009)_0002)._0002());
			break;
		case 1:
			this._0002((uint)((global::_000F)_0002)._0002());
			break;
		case 17:
			this._0002((uint)((global::_0003_2001)_0002)._0002());
			break;
		case 16:
			this._0002(((global::_0005_2007)_0002)._0002());
			break;
		case 3:
			this._0002(((global::_000F_2001)_0002)._0002());
			break;
		case 13:
			this._0002((uint)((global::_0003_2000)_0002)._0002());
			break;
		case 14:
			this._0002((uint)((global::_000E_2006)_0002)._0002());
			break;
		case 19:
			this._0002(Convert.ToUInt32(((global::_0002_0010)_0002)._0002()));
			break;
		case 7:
			this._0002(Convert.ToUInt32(((global::_0005_2003)_0002)._0002()));
			break;
		case 0:
			this._0002((uint)(int)((global::_0006_2002)_0002)._0002());
			break;
		case 20:
			this._0002((uint)((global::_0002_2003)_0002)._0002());
			break;
		case 22:
			this._0002((uint)((global::_000F_200B)_0002)._0002());
			break;
		case 8:
			this._0002((uint)((global::_0006_200A)_0002)._0002());
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		return this;
	}
}
internal static class _000F_2002
{
	private static readonly global::_0006_2005 m__0002;

	private static readonly global::_0005_200B _0008;

	static _000F_2002()
	{
		global::_0006_2005 obj = global::_0006_2005._0008(65537uL);
		if (2u != 0)
		{
			global::_000F_2002.m__0002 = obj;
		}
		global::_0005_200B obj2 = new global::_0005_200B();
		if (0 == 0)
		{
			_0008 = obj2;
		}
	}

	public static Stream _0002(Stream _0002, byte[] _0008, string _0006)
	{
		byte[] array = Convert.FromBase64String(_0006);
		byte[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		byte[] array3 = new byte[_0008.Length + array2.Length];
		byte[] array4;
		if (7u != 0)
		{
			array4 = array3;
		}
		int count = _0008.Length;
		if (6u != 0)
		{
			Buffer.BlockCopy(_0008, 0, array4, 0, count);
		}
		Buffer.BlockCopy(array2, 0, array4, _0008.Length, array2.Length);
		global::_0006_2005 obj = new global::_0006_2005(1, array4);
		global::_0008_200A obj2 = new global::_0008_200A(_0002: false, obj, global::_000F_2002.m__0002);
		global::_0008_2008 obj3 = new global::_0008_2008(new global::_0002_2000(_0002: false, obj2));
		global::_0006_2004_2005 obj4 = new global::_0006_2004_2005();
		obj4._0002(obj3._0002_2007_2008_2009_0008());
		global::_0006_2004_2005 obj5 = obj4;
		return new global::_0006_2003(new global::_0005_2004_2005(_0002, obj3), obj5, global::_000F_2002._0008);
	}
}
internal static class _000F_2003
{
	private static volatile int m__0002;

	private static volatile int _0008;

	public static void _0002(ref byte _0002)
	{
		_ = 0;
		if (-1 == 0)
		{
		}
		_0002 = (byte)global::_000F_2003.m__0002;
		_ = 5;
		if (false)
		{
		}
		_0008 = _0002;
	}

	public static void _0002(ref int _0002)
	{
		_ = 4;
		if (3 == 0)
		{
		}
		_0002 = global::_000F_2003.m__0002;
		_ = 5;
		if (5 == 0)
		{
		}
		_0008 = _0002;
	}

	public static void _0002(ref long _0002)
	{
		_ = 3;
		if (3 == 0)
		{
		}
		_0002 = global::_000F_2003.m__0002;
		_ = 5;
		if (false)
		{
		}
		_0008 = (int)_0002;
	}

	public static void _0002(ref char _0002)
	{
		_ = -1;
		if (6 == 0)
		{
		}
		_0002 = (char)global::_000F_2003.m__0002;
		_ = 7;
		if (-1 == 0)
		{
		}
		_0008 = _0002;
	}

	public static void _0002(Array _0002, int _0008, int _0006)
	{
		if (true)
		{
			Array.Clear(_0002, _0008, _0006);
		}
	}

	public static void _0002(Array _0002)
	{
		int length = _0002.GetLength(0);
		if (uint.MaxValue != 0)
		{
			global::_000F_2003._0002(_0002, 0, length);
		}
	}
}
internal static class _000F_2003_2005
{
}
internal static class _000F_2004
{
	private static uint _0002(uint _0002, uint _0008, uint _0006, int _000F, uint _0005, uint[] _0003)
	{
		_ = 3;
		if (5 == 0)
		{
		}
		uint num = _0006 >> 5;
		_ = 7;
		if (-1 == 0)
		{
		}
		uint num2 = num ^ (_0008 << 2);
		_ = 3;
		if (false)
		{
		}
		return (num2 + ((_0008 >> 3) ^ (_0006 << 4))) ^ ((_0002 ^ _0008) + (_0003[(_000F & 3) ^ _0005] ^ _0006));
	}

	public static void _0002(byte[] _0002, int _0008, int _0006, byte[] _000F)
	{
		if (_0002.Length != 0 && _0002.Length != 0)
		{
			if (_0008 + _0006 > _0002.Length || _0006 % 4 != 0 || _0006 < 8)
			{
				throw new ArgumentException(global::_0008_0010._0002(-1463125378));
			}
			if (_000F == null || _000F.Length > 16)
			{
				throw new ArgumentNullException(global::_0008_0010._0002(-1463125397));
			}
			uint[] array = new uint[_0006 / 4];
			uint[] array2;
			if (5u != 0)
			{
				array2 = array;
			}
			global::_000F_2004._0002(_0002, _0008, _0006, array2, 0);
			uint[] array3 = new uint[4];
			uint[] array4;
			if (7u != 0)
			{
				array4 = array3;
			}
			global::_000F_2004._0002(_000F, 0, _000F.Length, array4, 0);
			if (true)
			{
				global::_000F_2004._0002(array2, array4);
			}
			global::_000F_2004._0002(array2, 0, array2.Length, _0002, _0008);
		}
	}

	private static void _0002(uint[] _0002, uint[] _0008)
	{
		int num = _0002.Length - 1;
		int num2;
		if (6u != 0)
		{
			num2 = num;
		}
		if (num2 < 1)
		{
			return;
		}
		uint num3 = _0002[num2];
		uint num4;
		if (2u != 0)
		{
			num4 = num3;
		}
		uint num5;
		if (6u != 0)
		{
			num5 = 0u;
		}
		int num6 = 6 + 52 / (num2 + 1);
		while (0 < num6--)
		{
			num5 += 2654435769u;
			uint num7 = (num5 >> 2) & 3;
			int i;
			uint num8;
			for (i = 0; i < num2; i++)
			{
				num8 = _0002[i + 1];
				num4 = (_0002[i] += global::_000F_2004._0002(num5, num8, num4, i, num7, _0008));
			}
			num8 = _0002[0];
			num4 = (_0002[num2] += global::_000F_2004._0002(num5, num8, num4, i, num7, _0008));
		}
	}

	private static uint[] _0002(byte[] _0002, int _0008, int _0006, uint[] _000F, int _0005)
	{
		if (_0008 + _0006 > _0002.Length)
		{
			throw new ArgumentException();
		}
		int num = _0006 / 4;
		int num2;
		if (8u != 0)
		{
			num2 = num;
		}
		if (_0005 + num2 > _000F.Length)
		{
			throw new ArgumentException();
		}
		int num3 = _0008 + _0006;
		int num4;
		if (8u != 0)
		{
			num4 = num3;
		}
		int i;
		if (2u != 0)
		{
			i = _0008;
		}
		for (; i < num4; i += 4)
		{
			_000F[_0005 + (i - _0008) / 4] = (uint)(_0002[i] | (_0002[i + 1] << 8) | (_0002[i + 2] << 16) | (_0002[i + 3] << 24));
		}
		return _000F;
	}

	private static void _0002(uint[] _0002, int _0008, int _0006, byte[] _000F, int _0005)
	{
		if (_0008 + _0006 > _0002.Length)
		{
			throw new ArgumentException();
		}
		int num = _0006 * 4;
		int num2;
		if (5u != 0)
		{
			num2 = num;
		}
		if (_0005 + num2 > _000F.Length)
		{
			throw new ArgumentException();
		}
		int num3 = _0005 + num2;
		int num4;
		if (2u != 0)
		{
			num4 = num3;
		}
		int i;
		if (8u != 0)
		{
			i = _0005;
		}
		for (; i < num4; i += 4)
		{
			uint num5 = _0002[(i - _0005) / 4 + _0008];
			_000F[i] = (byte)num5;
			_000F[i + 1] = (byte)(num5 >> 8);
			_000F[i + 2] = (byte)(num5 >> 16);
			_000F[i + 3] = (byte)(num5 >> 24);
		}
	}
}
internal sealed class _000F_2004_2005 : global::_0006
{
	private new MethodBase m__0002;

	public _000F_2004_2005()
	{
		_ = 5;
		if (false)
		{
		}
		base._002Ector(21);
	}

	public new MethodBase _0002()
	{
		_ = 2;
		if (6 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(MethodBase _0002)
	{
		if (7u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public new IntPtr _0002()
	{
		RuntimeMethodHandle methodHandle = this._0002().MethodHandle;
		RuntimeMethodHandle runtimeMethodHandle;
		if (uint.MaxValue != 0)
		{
			runtimeMethodHandle = methodHandle;
		}
		return runtimeMethodHandle.GetFunctionPointer();
	}

	[SpecialName]
	public override object _0006_2008_2009_0002()
	{
		_ = 1;
		if (4 == 0)
		{
		}
		return this._0002();
	}

	[SpecialName]
	public override void _0006_2008_2009_0002(object _0002)
	{
		MethodBase obj = (MethodBase)_0002;
		if (3u != 0)
		{
			this._0002(obj);
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (7u != 0)
		{
			base._0002(type);
		}
		if (_0002._0002() == 21)
		{
			MethodBase methodBase = ((global::_000F_2004_2005)_0002)._0002();
			if (6u != 0)
			{
				this._0002(methodBase);
			}
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000F_2004_2005 obj = new global::_000F_2004_2005();
		_ = 4;
		if (false)
		{
		}
		obj._0002(this.m__0002);
		_ = 8;
		if (4 == 0)
		{
		}
		obj._0002(base._0002());
		return obj;
	}
}
internal static class _000F_2005
{
	public static bool _0002(int[] _0002, int[] _0008)
	{
		if (_0002 == _0008)
		{
			return true;
		}
		if (_0002 == null || _0008 == null)
		{
			return false;
		}
		if (_0002.Length != _0008.Length)
		{
			return false;
		}
		int num;
		if (uint.MaxValue != 0)
		{
			num = 0;
		}
		while (num < _0002.Length)
		{
			if (_0002[num] != _0008[num])
			{
				return false;
			}
			int num2 = num + 1;
			if (0 == 0)
			{
				num = num2;
			}
		}
		return true;
	}
}
internal sealed class _000F_2006 : global::_0002_2004
{
	private new global::_0006 m__0002;

	public _000F_2006()
	{
		_ = 5;
		if (4 == 0)
		{
		}
		base._002Ector(2);
	}

	public new global::_0006 _0002()
	{
		_ = 4;
		if (8 == 0)
		{
		}
		return this.m__0002;
	}

	public void _0002(global::_0006 _0002)
	{
		if (3u != 0)
		{
			this.m__0002 = _0002;
		}
	}

	public override global::_0006 _0006_2008_2009_0002(global::_0006 _0002)
	{
		Type type = _0002._0002();
		if (2u != 0)
		{
			base._0002(type);
		}
		if (_0002._0002() == 2)
		{
			global::_0006 obj = ((global::_000F_2006)_0002)._0002();
			if (4u != 0)
			{
				this._0002(obj);
			}
			return this;
		}
		throw new ArgumentOutOfRangeException();
	}

	public override global::_0006 _0006_2008_2009_0002()
	{
		global::_000F_2006 obj = new global::_000F_2006();
		_ = 0;
		if (false)
		{
		}
		obj._0002(_0002());
		_ = 7;
		if (2 == 0)
		{
		}
		obj._0002(((global::_0006)this)._0002());
		return obj;
	}
}
[global::_0008_2000]
internal struct _000F_2007
{
	public readonly int _0002;

	public _000F_2007(int _0002)
	{
		if (4u != 0)
		{
			this._0002 = _0002;
		}
	}
}
internal static class _000F_2008
{
	[SecurityCritical]
	public sealed class _0002 : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid
		{
			get
			{
				_ = 5;
				if (8 == 0)
				{
				}
				return handle == IntPtr.Zero;
			}
		}

		public _0002()
		{
			_ = 3;
			if (-1 == 0)
			{
			}
			base._002Ector(ownsHandle: true);
		}

		protected override bool ReleaseHandle()
		{
			_ = 2;
			if (7 == 0)
			{
			}
			return _0002(handle) == 0;
		}
	}

	[SecurityCritical]
	public sealed class _0006 : SafeHandleZeroOrMinusOneIsInvalid
	{
		public override bool IsInvalid
		{
			get
			{
				_ = 3;
				if (2 == 0)
				{
				}
				return handle == IntPtr.Zero;
			}
		}

		public _0006()
		{
			_ = -1;
			if (4 == 0)
			{
			}
			base._002Ector(ownsHandle: true);
		}

		protected override bool ReleaseHandle()
		{
			_ = 7;
			if (3 == 0)
			{
			}
			return _0002(handle) == 0;
		}
	}

	public struct _0008
	{
		public uint _0002;

		public int _0008;

		public int _0006;

		public int _000F;

		public int _0005;

		public int _0003;
	}

	public static void _0002(uint _0002)
	{
		if (_0002 != 0)
		{
			uint num = default(uint);
			if (0 == 0)
			{
				num = _0002;
			}
			throw new InvalidOperationException(num.ToString());
		}
	}

	[DllImport("ncrypt.dll", EntryPoint = "NCryptFreeObject")]
	public static extern uint _0002(IntPtr _0002);

	[DllImport("ncrypt.dll", EntryPoint = "NCryptEncrypt")]
	public static extern uint _0002(_0006 _0002, [MarshalAs(UnmanagedType.LPArray)] byte[] _0008, int _0006, IntPtr _000F, [MarshalAs(UnmanagedType.LPArray)] byte[] _0005, int _0003, out int _000E, int _0002_2004);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptImportKey")]
	public static extern uint _0002(_0002 _0002, IntPtr _0008, string _0006, IntPtr _000F, out _0006 _0005, [MarshalAs(UnmanagedType.LPArray)] byte[] _0003, int _000E, uint _0002_2004);

	[DllImport("ncrypt.dll", CharSet = CharSet.Unicode, EntryPoint = "NCryptOpenStorageProvider")]
	public static extern uint _0002(out _0002 _0002, string _0008, uint _0006);
}
internal static class _000F_2009
{
	public static int _0002(int _0002)
	{
		_ = 0;
		if (3 == 0)
		{
		}
		return _0002 & -16777216;
	}
}
internal sealed class _000F_2009_2005 : IRemote
{
	private Channel _0002;

	private string _0008;

	public _000F_2009_2005()
	{
		string empty = string.Empty;
		if (3u != 0)
		{
			_0008 = empty;
		}
		base._002Ector();
	}

	public string Name()
	{
		return ObjectManager.Me.Name;
	}

	public int Level()
	{
		return (int)ObjectManager.Me.Level;
	}

	public int HealthPercent()
	{
		return (int)ObjectManager.Me.HealthPercent;
	}

	public Vector3 Position()
	{
		return ObjectManager.Me.Position;
	}

	public string TargetName()
	{
		return ObjectManager.Target.Name;
	}

	public int TargetLevel()
	{
		return (int)ObjectManager.Target.Level;
	}

	public int TargetHealthPercent()
	{
		return (int)ObjectManager.Target.HealthPercent;
	}

	public bool InGame()
	{
		return Conditions.InGameAndConnected;
	}

	public void CloseBot()
	{
		if (0 == 0)
		{
			wManager.Pulsator.Dispose(closePocess: true);
		}
	}

	public void CloseGame()
	{
		if (Memory.WowMemory.Memory.IsValidAndOpenProcess())
		{
			Process.GetProcessById(Memory.WowMemory.Memory.ProcessId).Kill();
		}
	}

	public string SubMapName()
	{
		return Usefuls.SubMapZoneName;
	}

	public string Extra()
	{
		string[] array = new string[35];
		array[0] = global::_0008_0010._0002(-1463133284);
		array[1] = Logging.Status;
		array[2] = global::_0008_0010._0002(-1463133258);
		uint kills = Statistics.Kills;
		uint num;
		if (7u != 0)
		{
			num = kills;
		}
		array[3] = num.ToString();
		array[4] = global::_0008_0010._0002(-1463125751);
		int num2 = Statistics.KillsByHr();
		int num3;
		if (true)
		{
			num3 = num2;
		}
		array[5] = num3.ToString();
		array[6] = global::_0008_0010._0002(-1463133268);
		uint deaths = Statistics.Deaths;
		if (uint.MaxValue != 0)
		{
			num = deaths;
		}
		array[7] = num.ToString();
		array[8] = global::_0008_0010._0002(-1463125751);
		int num4 = Statistics.DeathsByHr();
		if (7u != 0)
		{
			num3 = num4;
		}
		array[9] = num3.ToString();
		array[10] = global::_0008_0010._0002(-1463134135);
		uint stucks = Statistics.Stucks;
		if (8u != 0)
		{
			num = stucks;
		}
		array[11] = num.ToString();
		array[12] = global::_0008_0010._0002(-1463125751);
		int num5 = Statistics.StucksByHr();
		if (5u != 0)
		{
			num3 = num5;
		}
		array[13] = num3.ToString();
		array[14] = global::_0008_0010._0002(-1463134110);
		uint farms = Statistics.Farms;
		if (4u != 0)
		{
			num = farms;
		}
		array[15] = num.ToString();
		array[16] = global::_0008_0010._0002(-1463125751);
		array[17] = Statistics.FarmsByHr().ToString();
		array[18] = global::_0008_0010._0002(-1463134180);
		array[19] = Statistics.Loots.ToString();
		array[20] = global::_0008_0010._0002(-1463125751);
		array[21] = Statistics.LootsByHr().ToString();
		array[22] = global::_0008_0010._0002(-1463134154);
		array[23] = ObjectManager.Me.MoneyStringFormat(Statistics.MoneyByHr());
		array[24] = global::_0008_0010._0002(-1463133995);
		array[25] = ObjectManager.Me.MoneyStringFormat(Statistics.Money());
		array[26] = global::_0008_0010._0002(-1463133988);
		array[27] = Statistics.HonorByHr().ToString();
		array[28] = global::_0008_0010._0002(-1463133995);
		array[29] = Statistics.Honor().ToString();
		array[30] = global::_0008_0010._0002(-1463133962);
		array[31] = Statistics.ExperienceByHr().ToString();
		array[32] = global::_0008_0010._0002(-1463133969);
		array[33] = Statistics.NextLevelMin().ToString();
		array[34] = global::_0008_0010._0002(-1463134075);
		string text = string.Concat(array);
		try
		{
			if (Memory.WowMemory.Memory.IsValidAndOpenProcess())
			{
				text = text + global::_0008_0010._0002(-1463134031) + Convert.ToBase64String(Display.ScreenshotWindowToBytes((IntPtr)Memory.WowMemory.Memory.WindowHandleInt32, 300, 300)) + global::_0008_0010._0002(-1463134035);
			}
		}
		catch
		{
		}
		return text;
	}

	public int BagSpace()
	{
		return Bag.GetContainerNumFreeSlots;
	}

	public string ClassPlayer()
	{
		WoWClass wowClass = ObjectManager.Me.WowClass;
		WoWClass woWClass;
		if (8u != 0)
		{
			woWClass = wowClass;
		}
		return woWClass.ToString();
	}

	public string LastWhisper()
	{
		try
		{
			if (_0002 == null)
			{
				Channel channel = new Channel();
				if (0 == 0)
				{
					_0002 = channel;
				}
			}
			int i;
			if (3u != 0)
			{
				i = 0;
			}
			for (; i < 30; i++)
			{
				string text = _0002.ReadWhisperChannel();
				string text2;
				if (2u != 0)
				{
					text2 = text;
				}
				if (text2 != string.Empty)
				{
					_0008 = text2.Replace(global::_0008_0010._0002(-1463133861), string.Empty);
				}
			}
			return _0008;
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}
}
internal sealed class _000F_200A
{
	private sealed class _0002
	{
		public byte[] _0002;

		public bool _0008;

		public _0002()
		{
			_ = 6;
			if (false)
			{
			}
			base._002Ector();
		}

		public _0002(byte[] _0002, int _0008, int _0006, bool _000F)
		{
			if (4u != 0)
			{
				this._0002(_0002, _0008, _0006, _000F);
			}
		}

		public void _0002(byte[] _0002, int _0008, int _0006, bool _000F)
		{
			byte[] array = new byte[_0006];
			if (6u != 0)
			{
				this._0002 = array;
			}
			byte[] dst = this._0002;
			if (8u != 0)
			{
				Buffer.BlockCopy(_0002, _0008, dst, 0, _0006);
			}
			if (4u != 0)
			{
				this._0008 = _000F;
			}
		}
	}

	private readonly object m__0002;

	private global::_0002_2001[] m__0008;

	private Dictionary<int, global::_0002_2001> m__0006;

	private volatile bool _000F;

	private global::_0006_2004_2005 _0005;

	private Dictionary<int, WeakReference> _0003;

	private object _000E;

	private int _0002_2004;

	private object[] _0008_2004;

	private int _0006_2004;

	public _000F_200A(global::_0006_2004_2005 _0002)
	{
		object obj = new object();
		if (uint.MaxValue != 0)
		{
			this.m__0002 = obj;
		}
		base._002Ector();
		if (true)
		{
			_0005 = _0002;
		}
	}

	private void _0002()
	{
		if (_000F)
		{
			return;
		}
		object obj = this.m__0002;
		object obj2;
		if (6u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (4u != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (5u != 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			if (!_000F)
			{
				this.m__0008 = new global::_0002_2001[_0005._0006()];
				for (int i = 0; i < _0005._0006(); i++)
				{
					this.m__0008[i] = new global::_0002_2001();
				}
				this.m__0006 = new Dictionary<int, global::_0002_2001>();
				_0003 = new Dictionary<int, WeakReference>();
				_000E = new object();
				_0002_2004 = _0005._000F();
				_0008_2004 = new object[_0005._0005()];
				_000F = true;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	public void _0002(global::_0002_2001 _0002)
	{
		if (5u != 0)
		{
			this._0002();
		}
		object obj = this.m__0002;
		object obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (uint.MaxValue != 0)
		{
			lockTaken = false;
		}
		try
		{
			Monitor.Enter(obj2, ref lockTaken);
			if (this.m__0006.TryGetValue(_0002._0008, out var value) && value != null)
			{
				value._000F = _0002._000F;
				return;
			}
			int num = 0;
			DateTime dateTime = this.m__0008[0]._000F;
			for (int i = 1; i < _0005._0006(); i++)
			{
				if (this.m__0008[i]._000F < dateTime)
				{
					num = i;
				}
			}
			value = this.m__0008[num];
			if (value._0002 == null)
			{
				value._0002 = new byte[_0005._0002()];
			}
			else
			{
				this.m__0006[value._0008] = null;
			}
			this._0002(_0002, value);
			this.m__0006[value._0008] = value;
			if (this.m__0006.Count > _0005._0006() * 2)
			{
				_0008();
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	private void _0008()
	{
		Dictionary<int, global::_0002_2001> dictionary = this.m__0006;
		Dictionary<int, global::_0002_2001> dictionary2;
		if (6u != 0)
		{
			dictionary2 = dictionary;
		}
		List<int> list = new List<int>();
		List<int> list2;
		if (7u != 0)
		{
			list2 = list;
		}
		Dictionary<int, global::_0002_2001>.Enumerator enumerator = dictionary2.GetEnumerator();
		Dictionary<int, global::_0002_2001>.Enumerator enumerator2 = default(Dictionary<int, global::_0002_2001>.Enumerator);
		if (0 == 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				KeyValuePair<int, global::_0002_2001> current = enumerator2.Current;
				if (current.Value == null)
				{
					list2.Add(current.Key);
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
		foreach (int item in list2)
		{
			dictionary2.Remove(item);
		}
	}

	public bool _0002(int _0002, ref global::_0002_2001 _0008)
	{
		if (!_000F)
		{
			return false;
		}
		object obj = this.m__0002;
		object obj2;
		if (5u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (uint.MaxValue != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (uint.MaxValue != 0)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			if (this.m__0006.TryGetValue(_0002, out var value) && value != null)
			{
				this._0002(value, _0008);
				return true;
			}
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
		return false;
	}

	private void _0002(global::_0002_2001 _0002, global::_0002_2001 _0008)
	{
		DateTime utcNow = DateTime.UtcNow;
		if (3u != 0)
		{
			_0002._000F = utcNow;
		}
		int num = _0002._0008;
		if (0 == 0)
		{
			_0008._0008 = num;
		}
		int num2 = _0002._0006;
		if (5u != 0)
		{
			_0008._0006 = num2;
		}
		_0008._000F = _0002._000F;
		Buffer.BlockCopy(_0002._0002, 0, _0008._0002, 0, _0005._0002());
	}

	private void _0002(object _0002)
	{
		int num;
		if (7u != 0)
		{
			num = 0;
		}
		while (num < _0008_2004.Length)
		{
			if (_0008_2004[num] == _0002)
			{
				return;
			}
			int num2 = num + 1;
			if (6u != 0)
			{
				num = num2;
			}
		}
		_0008_2004[_0006_2004] = _0002;
		int num3 = _0006_2004 + 1;
		if (true)
		{
			_0006_2004 = num3;
		}
		if (_0006_2004 == _0008_2004.Length)
		{
			_0006_2004 = 0;
		}
	}

	private void _0006()
	{
		if (_0003.Count < _0002_2004)
		{
			return;
		}
		Dictionary<int, WeakReference> dictionary = new Dictionary<int, WeakReference>();
		Dictionary<int, WeakReference> dictionary2;
		if (4u != 0)
		{
			dictionary2 = dictionary;
		}
		Dictionary<int, WeakReference>.Enumerator enumerator = _0003.GetEnumerator();
		Dictionary<int, WeakReference>.Enumerator enumerator2;
		if (3u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				KeyValuePair<int, WeakReference> current = enumerator2.Current;
				KeyValuePair<int, WeakReference> keyValuePair;
				if (true)
				{
					keyValuePair = current;
				}
				if (keyValuePair.Value.IsAlive)
				{
					dictionary2.Add(keyValuePair.Key, keyValuePair.Value);
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2/*cast due to constrained. prefix*/).Dispose();
		}
		_0003 = dictionary2;
		_0002_2004 = System.Math.Max(dictionary2.Count * 2, 10);
	}

	public void _0002(int _0002, byte[] _0008, int _0006, int _000F, bool _0005)
	{
		if (true)
		{
			this._0002();
		}
		object obj = _000E;
		object obj2;
		if (2u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (8u != 0)
		{
			lockTaken = false;
		}
		try
		{
			Monitor.Enter(obj2, ref lockTaken);
			_0002 obj3;
			if (_0003.TryGetValue(_0002, out var value))
			{
				obj3 = value.Target as _0002;
				if (obj3 != null)
				{
					if (obj3._0002.Length < _000F)
					{
						obj3._0002(_0008, _0006, _000F, _0005);
					}
					goto IL_0088;
				}
			}
			this._0006();
			obj3 = new _0002(_0008, _0006, _000F, _0005);
			_0003[_0002] = new WeakReference(obj3);
			goto IL_0088;
			IL_0088:
			this._0002(obj3);
		}
		finally
		{
			if (lockTaken)
			{
				Monitor.Exit(obj2);
			}
		}
	}

	public bool _0002(int _0002, byte[] _0008, int _0006, int _000F, out int _0005)
	{
		_0005 = 0;
		if (!this._000F)
		{
			return false;
		}
		object obj = _000E;
		object obj2;
		if (3u != 0)
		{
			obj2 = obj;
		}
		bool lockTaken;
		if (7u != 0)
		{
			lockTaken = false;
		}
		try
		{
			if (true)
			{
				Monitor.Enter(obj2, ref lockTaken);
			}
			if (!_0003.TryGetValue(_0002, out var value))
			{
				return false;
			}
			if (!(value.Target is _0002 obj3))
			{
				return false;
			}
			int num = obj3._0002.Length;
			_0005 = _000F;
			if (num < _000F)
			{
				if (!obj3._0008)
				{
					return false;
				}
				_0005 = num;
			}
			Buffer.BlockCopy(obj3._0002, 0, _0008, _0006, _0005);
			this._0002(obj3);
			return true;
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
