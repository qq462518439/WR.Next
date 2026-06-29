using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace _002D;

public sealed class lliii1liI1i1 : IMultiValueConverter
{
	[Serializable]
	private sealed class _0002
	{
		public static readonly _0002 _0002;

		public static Func<Type, object> _0008;

		static _0002()
		{
			_0002 obj = new _0002();
			if (4u != 0)
			{
				lliii1liI1i1._0002._0002 = obj;
			}
		}

		public _0002()
		{
			_ = 8;
			if (4 == 0)
			{
			}
			base._002Ector();
		}

		internal object _0002(Type _0002)
		{
			return Binding.DoNothing;
		}
	}

	public lliii1liI1i1()
	{
		_ = 3;
		if (1 == 0)
		{
		}
		base._002Ector();
	}

	public object Convert(object[] _0002, Type _0008, object _0006, CultureInfo _000F)
	{
		_ = 8;
		if (1 == 0)
		{
		}
		if (_0002 != null)
		{
			_ = 2;
			if (false)
			{
			}
			if (_0002.Length > 1)
			{
				_ = 0;
				if (-1 == 0)
				{
				}
				return _0002[0] ?? _0002[1];
			}
		}
		return null;
	}

	public object[] ConvertBack(object _0002, Type[] _0008, object _0006, CultureInfo _000F)
	{
		Func<Type, object> func = lliii1liI1i1._0002._0008;
		if (func == null)
		{
			func = lliii1liI1i1._0002._0002._0002;
			Func<Type, object> obj = func;
			if (2u != 0)
			{
				lliii1liI1i1._0002._0008 = obj;
			}
		}
		return _0008.Select(func).ToArray();
	}
}
