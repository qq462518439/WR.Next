using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Navigation;
using authManager;
using robotManager.Helpful;
using wManager;
using wManager.Wow.Helpers;

namespace _002D;

public sealed class l1I11i1111Ii : Window, IComponentConnector
{
	[Serializable]
	private sealed class _0002
	{
		public static readonly _0002 _0002;

		public static ThreadStart _0008;

		public static Action _0006;

		static _0002()
		{
			_0002 obj = new _0002();
			if (uint.MaxValue != 0)
			{
				l1I11i1111Ii._0002._0002 = obj;
			}
		}

		public _0002()
		{
			_ = 1;
			if (-1 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0002()
		{
			bool flag;
			if (3u != 0)
			{
				flag = false;
			}
			try
			{
				MethodInfo method = typeof(RunCodeExtension).GetMethod(global::_0008_0010._0002(-1463126033));
				string[] obj = new string[1] { global::_0008_0010._0002(-1463126139) + Information.WRobotVersion + global::_0008_0010._0002(-1463126828) };
				object[] parameters;
				if (uint.MaxValue != 0)
				{
					parameters = obj;
				}
				bool num = (bool)method.Invoke(null, parameters);
				if (true)
				{
					flag = num;
				}
			}
			catch
			{
			}
			finally
			{
				if (!flag && ArgsParser.GetArgs.AutoStart)
				{
					Thread.Sleep(500);
					Process.GetCurrentProcess().Kill();
				}
			}
		}

		internal void _0008()
		{
			string scripServerIsOnline = global::_0008_0010._0002(-1463126705) + Information.WRobotVersion + global::_0008_0010._0002(-1463126767);
			if (uint.MaxValue != 0)
			{
				LoginServer.CheckServerIsOnline(scripServerIsOnline);
			}
			while (!LoginServer.IsOnlineServers)
			{
				if (3u != 0)
				{
					Thread.Sleep(10);
				}
				if (uint.MaxValue != 0)
				{
					Others.DoEvents();
				}
				Thread.Sleep(50);
			}
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0003 : IAsyncStateMachine
	{
		public int _0002;

		public AsyncVoidMethodBuilder _0008;

		public l1I11i1111Ii _0006;

		private TaskAwaiter _000F;

		private void MoveNext()
		{
			object[] array = new object[1];
			object[] array2;
			if (3u != 0)
			{
				array2 = array;
			}
			array2[0] = this;
			global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
			global::_0006_2009 obj2;
			if (6u != 0)
			{
				obj2 = obj;
			}
			Stream stream = global::_0006_2001_2005._0003_2001_2005();
			Stream stream2;
			if (uint.MaxValue != 0)
			{
				stream2 = stream;
			}
			try
			{
				obj2._0002(stream2, "%!m2DIsufr", array2);
			}
			finally
			{
				this = (_0003)array2[0];
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0002)
		{
			ref AsyncVoidMethodBuilder reference = ref _0008;
			if (5u != 0)
			{
				reference.SetStateMachine(_0002);
			}
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0002)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0002);
		}

		private static void MoveNext(ref TaskAwaiter P_0, ref _0003 P_1)
		{
			P_1._0008.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0005 : IAsyncStateMachine
	{
		public int _0002;

		public AsyncVoidMethodBuilder _0008;

		public l1I11i1111Ii _0006;

		private void MoveNext()
		{
			object[] array = new object[1];
			object[] array2;
			if (4u != 0)
			{
				array2 = array;
			}
			array2[0] = this;
			global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
			global::_0006_2009 obj2;
			if (4u != 0)
			{
				obj2 = obj;
			}
			Stream stream = global::_0006_2001_2005._0003_2001_2005();
			Stream stream2;
			if (uint.MaxValue != 0)
			{
				stream2 = stream;
			}
			try
			{
				obj2._0002(stream2, "6[F$&Isufk", array2);
			}
			finally
			{
				this = (_0005)array2[0];
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0002)
		{
			ref AsyncVoidMethodBuilder reference = ref _0008;
			if (6u != 0)
			{
				reference.SetStateMachine(_0002);
			}
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0002)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0002);
		}
	}

	private sealed class _0006
	{
		public string _0002;

		public l1I11i1111Ii _0008;

		public _0006()
		{
			_ = 8;
			if (6 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0002()
		{
			_ = -1;
			if (false)
			{
			}
			WebBrowser webBrowser = _0008._0006_2004;
			_ = 1;
			if (1 == 0)
			{
			}
			webBrowser.NavigateToString(this._0002);
		}
	}

	private sealed class _0008
	{
		public l1I11i1111Ii _0002;

		public WebBrowser _0008;

		public bool _0006;

		public _0008()
		{
			_ = 1;
			if (4 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0002(object _0002, RoutedEventArgs _0008)
		{
			l1I11i1111Ii obj = this._0002;
			WebBrowser webBrowser = this._0008;
			bool num = _0006;
			if (3u != 0)
			{
				obj._0002(webBrowser, num);
			}
		}
	}

	private sealed class _000F
	{
		public int _0002;

		public _000F()
		{
			_ = 0;
			if (false)
			{
			}
			base._002Ector();
		}

		internal bool _0002(Process _0002)
		{
			_ = 7;
			if (7 == 0)
			{
			}
			int id = _0002.Id;
			_ = 2;
			if (3 == 0)
			{
			}
			return id != this._0002;
		}
	}

	private bool m__0002;

	private bool m__0008;

	internal l1I11i1111Ii _0006;

	internal LoginUserControl _000F;

	internal ComboBox _0005;

	internal Button _0003;

	internal Button _000E;

	internal Button _0002_2004;

	internal TextBlock _0008_2004;

	internal WebBrowser _0006_2004;

	private bool _000F_2004;

	public l1I11i1111Ii()
	{
		ref bool reference = ref this.m__0002;
		ref bool reference2 = ref this.m__0008;
		if (5u != 0)
		{
			_002Ector_1(ref reference, ref reference2);
		}
		base._002Ector();
		if (uint.MaxValue != 0)
		{
			_002Ector_2();
		}
	}

	private void _0002(WebBrowser _0002, bool _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (5u != 0)
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
			obj._0002(stream, "d!Bt^IsugG", array2);
		}
	}

	private void _0002()
	{
		object[] array = new object[1];
		object[] array2 = default(object[]);
		if (0 == 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		object[] array3 = array2;
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, "[sNCFIsuf^", array3);
		}
	}

	private void _0008()
	{
		object[] array = new object[1];
		object[] array2 = default(object[]);
		if (0 == 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		object[] array3 = array2;
		if (8u != 0)
		{
			obj._0002(stream, "%XNDFIsuer", array3);
		}
	}

	private void _0002(object _0002, RoutedEventArgs _0008)
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
		if (2u != 0)
		{
			obj._0002(stream, "%siMGIsuec", array2);
		}
	}

	private void _0008(object _0002, RoutedEventArgs _0008)
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
		if (true)
		{
			obj._0002(stream, ".XHAbIsugA", array2);
		}
	}

	private void _0006(object _0002, RoutedEventArgs _0008)
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
		if (8u != 0)
		{
			obj._0002(stream, "W-W`6Isue_", array2);
		}
	}

	private bool _0002()
	{
		object[] array = new object[1];
		object[] array2;
		if (8u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		return (bool)global::_0006_2001_2005._0002_2002_2005()._0002(global::_0006_2001_2005._0003_2001_2005(), "o6P\\,IsueR", array2);
	}

	[AsyncStateMachine(typeof(_0003))]
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
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, ";gN_6Isug'", array2);
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
		if (8u != 0)
		{
			obj._0002(stream, "Q$R_#IsugV", array2);
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
		if (true)
		{
			obj._0002(stream, "jEc)rIsufm", array2);
		}
	}

	private void _000F(object _0002, RoutedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (3u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (4u != 0)
		{
			obj._0002(stream, "ds?:aIsugA", array2);
		}
	}

	private void _0005(object _0002, RoutedEventArgs _0008)
	{
		object[] array = new object[3];
		object[] array2;
		if (5u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		array2[1] = _0002;
		array2[2] = _0008;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (5u != 0)
		{
			obj._0002(stream, ".!p5aIsuf`", array2);
		}
	}

	[AsyncStateMachine(typeof(_0005))]
	private void _0003(object _0002, RoutedEventArgs _0008)
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
		if (true)
		{
			obj._0002(stream, "B7\"oKIsufa", array3);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	public void InitializeComponent()
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
		if (5u != 0)
		{
			obj._0002(stream, ";L3V5Isuel", array2);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	private void _9wkt5qwgjz7ygxt5763pny26p8c67qhr_2008_2009_0002(int _0002, object _0008)
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
		if (true)
		{
			obj._0002(stream, "*I<!UIsuh=", array3);
		}
	}

	void IComponentConnector.Connect(int _0002, object _0008)
	{
		//ILSpy generated this explicit interface implementation from .override directive in 9wkt5qwgjz7ygxt5763pny26p8c67qhr  
		this._9wkt5qwgjz7ygxt5763pny26p8c67qhr_2008_2009_0002(_0002, _0008);
	}

	private void _0002(object _0002, NavigationEventArgs _0008)
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
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, "i-KZnIsug.", array2);
		}
	}

	private void _000F()
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
		if (uint.MaxValue != 0)
		{
			obj._0002(stream, "CO18NIsugK", array2);
		}
	}

	private void _0005()
	{
		object[] array = new object[1];
		object[] array2;
		if (4u != 0)
		{
			array2 = array;
		}
		array2[0] = this;
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		if (6u != 0)
		{
			obj._0002(stream, "-@0r^Isuem", array2);
		}
	}

	private static void _002Ector_1(ref bool P_0, ref bool P_1)
	{
		object[] array = new object[2] { P_0, P_1 };
		global::_0006_2009 obj = global::_0006_2001_2005._0002_2002_2005();
		Stream stream = global::_0006_2001_2005._0003_2001_2005();
		try
		{
			obj._0002(stream, "BR4rKIsug(", array);
		}
		finally
		{
			P_0 = (bool)array[0];
			P_1 = (bool)array[1];
		}
	}

	private static void _0003(ref _0005 P_0)
	{
		P_0._0008.Start(ref P_0);
	}

	private static void _0002(ref _0003 P_0)
	{
		P_0._0008.Start(ref P_0);
	}

	private void _002Ector_2()
	{
		object[] array = new object[1] { this };
		global::_0006_2001_2005._0002_2002_2005()._0002(global::_0006_2001_2005._0003_2001_2005(), "%srSHIsufm", array);
	}
}
