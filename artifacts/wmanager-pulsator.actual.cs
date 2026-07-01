using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using robotManager.Helpful;
using wManager.Wow;
using wManager.Wow.ObjectManager;

namespace wManager;

public class Pulsator
{
	[Serializable]
	private sealed class \u0002
	{
		public static readonly \u0002 \u0002;

		public static ThreadStart \u0008;

		static \u0002()
		{
			\u0002 obj = new \u0002();
			if (7u != 0)
			{
				Pulsator.\u0002.\u0002 = obj;
			}
		}

		public \u0002()
		{
			_ = 4;
			if (6 == 0)
			{
			}
			base..ctor();
		}

		internal void \u0002()
		{
			try
			{
				_ = (bool)((MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)).Invoke(null, new object[1] { \u0006\u0010.\u0002(-1389943721) + Information.WRobotVersion + \u0006\u0010.\u0002(-1389943579) });
				if (true)
				{
				}
			}
			catch
			{
				if (7u != 0)
				{
				}
			}
		}
	}

	private static string m_\u0002;

	private static bool \u0008;

	private static readonly object \u0006;

	private static bool \u000f;

	public static string K
	{
		set
		{
			string text = Others.EncrypterMD5(value);
			if (true)
			{
				Pulsator.m_\u0002 = text;
			}
		}
	}

	public static bool IsActive
	{
		get
		{
			try
			{
				if (!Memory.WowMemory.ThreadHooked)
				{
					if (5u != 0)
					{
						return false;
					}
				}
				else if (!Memory.WowMemory.Memory.IsValidAndOpenProcess())
				{
					if (8u != 0)
					{
						return false;
					}
				}
				else
				{
					if (wManager.Wow.ObjectManager.Pulsator.IsActive)
					{
						return true;
					}
					if (8u != 0)
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				Logging.WriteError(\u0006\u0010.\u0002(-1389943041) + ex);
				goto IL_006b;
			}
			bool result;
			return result;
			IL_006b:
			return false;
		}
	}

	public static bool DontCloseWhenPlayerChanges
	{
		[CompilerGenerated]
		get
		{
			return \u000f;
		}
		[CompilerGenerated]
		set
		{
			if (true)
			{
				\u000f = value;
			}
		}
	}

	public Pulsator()
	{
		_ = 6;
		if (false)
		{
		}
		base..ctor();
	}

	static Pulsator()
	{
		global::\u0005\u2009 obj = \u0006\u2001\u2005.\u0002\u2002\u2005();
		Stream stream = \u0006\u2001\u2005.\u0003\u2001\u2005();
		if (5u != 0)
		{
			obj.\u0002(stream, "g3S$hIsufp", (object[])null);
		}
	}

	public static void Pulse(int processId)
	{
		object[] array = new object[1];
		object[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = array;
		}
		array2[0] = processId;
		global::\u0005\u2009 obj = \u0006\u2001\u2005.\u0002\u2002\u2005();
		Stream stream = \u0006\u2001\u2005.\u0003\u2001\u2005();
		if (7u != 0)
		{
			obj.\u0002(stream, "'7+qKIsufQ", array2);
		}
	}

	public static void Dispose(bool closePocess = false)
	{
		object[] array = new object[1];
		object[] array2 = default(object[]);
		if (0 == 0)
		{
			array2 = array;
		}
		array2[0] = closePocess;
		global::\u0005\u2009 obj = \u0006\u2001\u2005.\u0002\u2002\u2005();
		Stream stream = \u0006\u2001\u2005.\u0003\u2001\u2005();
		object[] array3 = array2;
		if (2u != 0)
		{
			obj.\u0002(stream, "0RA\"hIsufH", array3);
		}
	}

	private static void \u0002()
	{
		global::\u0005\u2009 obj = \u0006\u2001\u2005.\u0002\u2002\u2005();
		Stream stream = \u0006\u2001\u2005.\u0003\u2001\u2005();
		if (3u != 0)
		{
			obj.\u0002(stream, "UO%31Isuf\\", (object[])null);
		}
	}

	public static void Reset()
	{
		global::\u0005\u2009 obj = \u0006\u2001\u2005.\u0002\u2002\u2005();
		Stream stream = \u0006\u2001\u2005.\u0003\u2001\u2005();
		if (5u != 0)
		{
			obj.\u0002(stream, "]m=sKIsufl", (object[])null);
		}
	}
}
