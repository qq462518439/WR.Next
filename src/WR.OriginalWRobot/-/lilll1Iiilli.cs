using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using robotManager.Helpful;
using robotManager.Products;
using wManager.Wow.ObjectManager;

namespace _002D;

public sealed class lilll1Iiilli : MetroWindow, IComponentConnector
{
	[Serializable]
	private sealed class _0002
	{
		public static readonly _0002 _0002;

		public static Func<string, string, string> _0008;

		public static Func<WoWItem, string> _0006;

		static _0002()
		{
			_0002 obj = new _0002();
			if (0 == 0)
			{
				lilll1Iiilli._0002._0002 = obj;
			}
		}

		public _0002()
		{
			_ = 7;
			if (3 == 0)
			{
			}
			base._002Ector();
		}

		internal string _0002(string _0002, string _0008)
		{
			_ = 2;
			if (false)
			{
			}
			string text = global::_0008_0010._0002(-1463125730);
			_ = 7;
			if (6 == 0)
			{
			}
			return _0002 + text + _0008;
		}

		internal string _0002(WoWItem _0002)
		{
			_ = 3;
			if (7 == 0)
			{
			}
			return _0002.Name;
		}
	}

	private NotifyIcon m__0002;

	private readonly KeyboardHook m__0008;

	private readonly KeyboardHook m__0006;

	private string m__000F;

	private bool m__0005;

	internal System.Windows.Controls.Label _0003;

	internal System.Windows.Controls.Button _000E;

	internal PackIconMaterial _0002_2004;

	internal System.Windows.Controls.Button _0008_2004;

	internal PackIconMaterial _0006_2004;

	internal System.Windows.Controls.Label _000F_2004;

	internal HamburgerMenu _0005_2004;

	private bool m__0003_2004;

	public lilll1Iiilli()
	{
		ref readonly KeyboardHook reference = ref this.m__0008;
		ref readonly KeyboardHook reference2 = ref this.m__0006;
		if (6u != 0)
		{
			_002Ector_1(ref reference, ref reference2);
		}
		base._002Ector();
		if (3u != 0)
		{
			_002Ector_2();
		}
	}

	private _0008_2009_2005 _0002()
	{
		_ = 6;
		if (4 == 0)
		{
		}
		return base.DataContext as _0008_2009_2005;
	}

	private void _0002(object _0002, RoutedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (true)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, "L3e,iIsugp", array2);
		}
	}

	private void _0002()
	{
		object[] array = new object[1];
		object[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (8u != 0)
		{
			obj._0002(stream, "D0gJPIsug8", array2);
		}
	}

	private void _0008()
	{
		object[] array = new object[1];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (2u != 0)
		{
			obj._0002(stream, "3-ojpIsufF", array2);
		}
	}

	private void _0006()
	{
		object[] array = new object[1];
		object[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (true)
		{
			obj._0002(stream, "qg*O4Isuh)", array2);
		}
	}

	private void _000F()
	{
		object[] array = new object[1];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (7u != 0)
		{
			obj._0002(stream, "ML'PmIsug.", array2);
		}
	}

	private void _0002(Products.ProductNeedSettingsEventArgs _0002)
	{
		object[] array = new object[2];
		object[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (true)
		{
			obj._0002(stream, "IsQBbIsugj", array2);
		}
	}

	private void _0002(object _0002, KeyPressedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (2u != 0)
		{
			obj._0002(stream, ".scJcIsuf2", array2);
		}
	}

	private void _0008(object _0002, KeyPressedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (true)
		{
			obj._0002(stream, "H?sj]Isugk", array2);
		}
	}

	private void _0002(object _0002, EventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (2u != 0)
		{
			obj._0002(stream, "pNh+0Isuf2", array2);
		}
	}

	private void _0005()
	{
		object[] array = new object[1];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (3u != 0)
		{
			obj._0002(stream, ".!g/`Isug0", array2);
		}
	}

	private void _0003()
	{
		object[] array = new object[1];
		object[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (2u != 0)
		{
			obj._0002(stream, ".XHAbIsufD", array2);
		}
	}

	private void _0002(object _0002, CancelEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (0 == 0)
		{
			obj._0002(stream, "`HlfSIsuf.", array2);
		}
	}

	private void _0008(object _0002, RoutedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (4u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, ":3q21Isuf<", array2);
		}
	}

	private void _0008(object _0002, EventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2 = default(object[]);
		if (0 == 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		object[] array3 = array2;
		if (2u != 0)
		{
			obj._0002(stream, "k'D;tIsugk", array3);
		}
	}

	private void _0002(object _0002, SizeChangedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (6u != 0)
		{
			obj._0002(stream, "KR.ogIsuf1", array2);
		}
	}

	private void _0006(object _0002, EventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2 = default(object[]);
		if (0 == 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		object[] array3 = array2;
		if (4u != 0)
		{
			obj._0002(stream, "_0UBOIsuf3", array3);
		}
	}

	private void _0006(object _0002, RoutedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (6u != 0)
		{
			obj._0002(stream, "h0O?kIsugi", array2);
		}
	}

	private void _000F(object _0002, EventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (true)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (8u != 0)
		{
			obj._0002(stream, "\\9`FFIsugf", array2);
		}
	}

	private void _000F(object _0002, RoutedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (true)
		{
			obj._0002(stream, "96tl.Isuf8", array2);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
	{
		object[] array = new object[1];
		object[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, "rH`a6Isugn", array2);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private void ksxhwr7tdptlvzwccjv6plhaz73sug7d_2008_2009_0002(int _0002, object _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (4u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, "<dK%9Isuf\"", array2);
		}
	}

	void IComponentConnector.Connect(int _0002, object _0008)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ksxhwr7tdptlvzwccjv6plhaz73sug7d  
		this.ksxhwr7tdptlvzwccjv6plhaz73sug7d_2008_2009_0002(_0002, _0008);
	}

	private void _0005(object _0002, EventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (7u != 0)
		{
			obj._0002(stream, "+aSEYIsuf5", array2);
		}
	}

	private void _000E()
	{
		object[] array = new object[1];
		object[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (8u != 0)
		{
			obj._0002(stream, "!.&p8Isuf?", array2);
		}
	}

	private void _0002_2004()
	{
		object[] array = new object[1];
		object[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (3u != 0)
		{
			obj._0002(stream, "8pYc-Isugo", array2);
		}
	}

	private void _0008_2004()
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
		if (2u != 0)
		{
			obj._0002(stream, "$@6uBIsuf@", array2);
		}
	}

	private void _0006_2004()
	{
		object[] array = new object[1];
		object[] array2;
		if (2u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (7u != 0)
		{
			obj._0002(stream, "\"aYH=Isugo", array2);
		}
	}

	private void _000F_2004()
	{
		object[] array = new object[1];
		object[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (4u != 0)
		{
			obj._0002(stream, "OEu1sIsuf@", array2);
		}
	}

	private void _0005_2004()
	{
		object[] array = new object[1];
		object[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (5u != 0)
		{
			obj._0002(stream, "%XNDFIsugp", array2);
		}
	}

	private void _0003_2004()
	{
		object[] array = new object[1];
		object[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (2u != 0)
		{
			obj._0002(stream, "EdE\"UIsuf:", array2);
		}
	}

	private static void _002Ector_1(ref KeyboardHook P_0, ref KeyboardHook P_1)
	{
		object[] array = new object[2] { P_0, P_1 };
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		try
		{
			obj._0002(stream, "\"+#6;IsugB", array);
		}
		finally
		{
			P_0 = (KeyboardHook)array[0];
			P_1 = (KeyboardHook)array[1];
		}
	}

	private void _002Ector_2()
	{
		object[] array = new object[1] { this };
		global::_0006_2001_2005._0002_2002_2005()._0002(global::_0006_2001_2005._0003_2001_2005(), "-@0r^Isug=", array);
	}
}
