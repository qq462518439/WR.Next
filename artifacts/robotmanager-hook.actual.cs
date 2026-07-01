using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MemoryRobot;
using robotManager.Helpful;

namespace robotManager.MemoryClass;

public class Hook : IDisposable
{
	private enum \u0002
	{

	}

	private struct \u0006
	{
		public ProcessorArchitecture \u0002;

		public uint \u0008;

		public IntPtr \u0006;

		public IntPtr \u000f;

		public IntPtr \u0005;

		public uint \u0003;

		public uint \u000e;

		public uint \u0002\u2004;

		public ushort \u0008\u2004;

		public ushort \u0006\u2004;
	}

	private struct \u0008
	{
		public IntPtr \u0002;

		public IntPtr \u0008;

		public MemoryProtection \u0006;

		public IntPtr \u000f;

		public \u0002 \u0005;

		public MemoryProtection \u0003;

		public \u000f \u000e;
	}

	private enum \u000f : uint
	{

	}

	public static readonly object Locker = new object();

	public AllocManager AllocText;

	public AllocManager AllocData;

	private StealthProtection m_\u0002;

	private uint m_\u0008;

	private uint m_\u0006;

	private uint m_\u000f;

	private readonly Memory \u0005 = new Memory();

	private readonly uint \u0003;

	private uint \u000e;

	private uint \u0002\u2004;

	private readonly bool \u0008\u2004;

	private readonly int \u0006\u2004;

	private byte[] \u000f\u2004 = new byte[0];

	private readonly int \u0005\u2004 = Others.Random(30, 50);

	private string \u0003\u2004 = \u0008\u0010.\u0002(-1548816369);

	private string \u000e\u2004 = \u0008\u0010.\u0002(-1548816342);

	private uint \u0002\u2007;

	private uint \u0008\u2007;

	private uint \u0006\u2007;

	private uint \u000f\u2007;

	private uint \u0005\u2007;

	private bool \u0003\u2007;

	private uint \u000e\u2007;

	private uint \u0002\u2003;

	private uint \u0008\u2003;

	private uint \u0006\u2003;

	private uint \u000f\u2003;

	private uint \u0005\u2003;

	public object LockFrameLocker = new object();

	internal uint \u0003\u2003;

	internal uint \u000e\u2003;

	private uint \u0002\u2009;

	public string RetnToHookCode = \u0008\u0010.\u0002(-1548842734);

	public static bool AllowFrameLock = true;

	public static int SleepTimeWaitCalled = 1;

	public static bool Obfuscate = true;

	public static bool ObfuscateHard = true;

	public bool ThreadHooked;

	private static Memory \u0008\u2009 = null;

	private int \u0006\u2009;

	private static Tuple<string, string>[] \u000f\u2009 = new Tuple<string, string>[10]
	{
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548816076), \u0008\u0010.\u0002(-1548816051)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548816061), \u0008\u0010.\u0002(-1548816040)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548816018), \u0008\u0010.\u0002(-1548816025)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548816003), \u0008\u0010.\u0002(-1548816014)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548815992), \u0008\u0010.\u0002(-1548815999)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548815977), \u0008\u0010.\u0002(-1548815956)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548815966), \u0008\u0010.\u0002(-1548815941)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548815951), \u0008\u0010.\u0002(-1548815929)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548815908), \u0008\u0010.\u0002(-1548815918)),
		new Tuple<string, string>(\u0008\u0010.\u0002(-1548815893), string.Empty)
	};

	private readonly Dictionary<int, int> \u0005\u2009 = new Dictionary<int, int>();

	private robotManager.Helpful.Timer \u0003\u2009 = new robotManager.Helpful.Timer(5000.0);

	private static long \u000e\u2009;

	private static int \u0002\u2001;

	private static int \u0008\u2001;

	private static readonly object \u0006\u2001 = new object();

	public uint AfterCall
	{
		get
		{
			object[] array = new object[1] { this };
			return (uint)\u0005\u2009\u2005.\u0006\u2001\u2005().\u0002(\u0005\u2009\u2005.\u0002\u2001\u2005(), "b'J>XIsufl", array);
		}
	}

	public Memory Memory => \u0005;

	public bool FrameIsLocked
	{
		get
		{
			try
			{
				return Memory.ReadByte(\u0005\u2007) == 1;
			}
			catch (Exception ex)
			{
				Logging.WriteError(\u0008\u0010.\u0002(-1548820218) + ex);
				return false;
			}
		}
		set
		{
			try
			{
				if (value)
				{
					LockFrame();
				}
				else
				{
					UnlockFrame();
				}
			}
			catch (Exception ex)
			{
				Logging.WriteError(\u0008\u0010.\u0002(-1548820180) + ex);
			}
		}
	}

	public Hook(int processId, uint detourAddress, byte[] originalBytes, uint jumpOrCallEsiWrapper = 0u, uint jumpOrCallEsiWrapperOffset = 0u, bool rebaseCallAndJmpAddress = true, bool hwbpHook = false, uint searchStackRequiredValue = 0u, uint searchStackMaxDistance = 592u, uint detourPointerDefaultValue = 0u, uint threadId = 0u)
	{
		try
		{
			if (!Others.IsUserAdministrator())
			{
				Logging.WriteDebug(\u0008\u0010.\u0002(-1548816302));
				if (!ArgsParser.GetArgs.AutoStart)
				{
					MessageBox.Show(Translate.Get(\u0008\u0010.\u0002(-1548816199)), \u0008\u0010.\u0002(-1548816121), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			\u0006\u2004 = processId;
			\u0003 = detourAddress;
			\u000f\u2004 = originalBytes;
			\u0002\u2007 = jumpOrCallEsiWrapper;
			\u0008\u2007 = jumpOrCallEsiWrapperOffset;
			\u0008\u2004 = rebaseCallAndJmpAddress;
			\u0003\u2007 = hwbpHook;
			\u000e\u2007 = searchStackRequiredValue;
			\u0002\u2003 = searchStackMaxDistance;
			\u0008\u2003 = detourPointerDefaultValue;
			\u0006\u2003 = threadId;
			\u0002();
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548816091) + ex);
		}
	}

	public bool DetourInUse()
	{
		try
		{
			if (\u000f\u2007 != 0)
			{
				return Memory.ReadByte(\u000f\u2007) == 1;
			}
		}
		catch
		{
		}
		return false;
	}

	[DllImport("kernel32.dll", EntryPoint = "VirtualProtectEx")]
	internal static extern bool \u0002(uint \u0002, uint \u0008, uint \u0006, uint \u000f, out uint \u0005);

	private void \u0002()
	{
		object[] array = new object[1] { this };
		\u0005\u2009\u2005.\u0006\u2001\u2005().\u0002(\u0005\u2009\u2005.\u0002\u2001\u2005(), "'7+qKIsufP", array);
	}

	internal void \u0008()
	{
		if (Display.WindowInTaskBarre(Memory.WindowHandle))
		{
			Display.ShowWindow(Memory.WindowHandle);
		}
		Thread thread = new Thread(\u0006);
		thread.Name = \u0008\u0010.\u0002(-1548817362);
		thread.Start();
		robotManager.Helpful.Timer timer = new robotManager.Helpful.Timer(3000.0);
		while (\u0006\u2009 == 0 && !timer.IsReady)
		{
			Thread.Sleep(1);
		}
		if (timer.IsReady)
		{
			if (!ArgsParser.GetArgs.AutoStart)
			{
				MessageBox.Show(Translate.Get(\u0008\u0010.\u0002(-1548817345)), \u0008\u0010.\u0002(-1548817244), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			Logging.WriteError(\u0008\u0010.\u0002(-1548817232));
		}
		else
		{
			Logging.WriteFileOnly(\u0008\u0010.\u0002(-1548817074));
		}
	}

	internal void \u0006()
	{
		InjectAndExecute(new string[2]
		{
			\u0008\u0010.\u0002(-1548818108),
			RetnToHookCode
		});
		\u0006\u2009 = 1;
	}

	public bool HookedProcessIsUserAnAdmin()
	{
		if (!ThreadHooked)
		{
			return false;
		}
		uint address = Memory.GetAddress(\u0008\u0010.\u0002(-1548817042), \u0008\u0010.\u0002(-1548817056));
		if (address == 0)
		{
			return false;
		}
		uint num = AllocData.Get(IntPtr.Size);
		if (num == 0)
		{
			return false;
		}
		try
		{
			InjectAndExecute(new string[4]
			{
				CallWrapperCode(address),
				\u0008\u0010.\u0002(-1548818021) + num,
				\u0008\u0010.\u0002(-1548816679),
				RetnToHookCode
			});
			return Memory.ReadPtr(num) != 0;
		}
		catch
		{
		}
		finally
		{
			AllocData.Free(num);
		}
		return false;
	}

	private string \u0002()
	{
		int num = Others.Random(1, 6);
		if (num >= 4 && Others.Random(1, 5) != 1)
		{
			num = Others.Random(1, 3);
		}
		string text = string.Empty;
		string text2 = string.Empty;
		if (num > 0)
		{
			string[] array = new string[6]
			{
				\u0008\u0010.\u0002(-1548817012),
				\u0008\u0010.\u0002(-1548814427),
				\u0008\u0010.\u0002(-1548817022),
				\u0008\u0010.\u0002(-1548817000),
				\u0008\u0010.\u0002(-1548816978),
				\u0008\u0010.\u0002(-1548814417)
			};
			string[] array2 = new string[18]
			{
				\u0008\u0010.\u0002(-1548816988),
				\u0008\u0010.\u0002(-1548816963),
				\u0008\u0010.\u0002(-1548816974),
				\u0008\u0010.\u0002(-1548816952),
				\u0008\u0010.\u0002(-1548816930),
				\u0008\u0010.\u0002(-1548816937),
				\u0008\u0010.\u0002(-1548816918),
				\u0008\u0010.\u0002(-1548816928),
				\u0008\u0010.\u0002(-1548816906),
				\u0008\u0010.\u0002(-1548819955),
				\u0008\u0010.\u0002(-1548819965),
				\u0008\u0010.\u0002(-1548819943),
				\u0008\u0010.\u0002(-1548819922),
				\u0008\u0010.\u0002(-1548819932),
				\u0008\u0010.\u0002(-1548819907),
				\u0008\u0010.\u0002(-1548819917),
				\u0008\u0010.\u0002(-1548819895),
				\u0008\u0010.\u0002(-1548819873)
			};
			string text3 = array[Others.Random(0, array.Length - 1)];
			string text4 = array[Others.Random(0, array.Length - 1)];
			string text5 = array[Others.Random(0, array.Length - 1)];
			string text6 = array[Others.Random(0, array.Length - 1)];
			switch (num)
			{
			case 1:
			{
				string text7 = array2[Others.Random(0, array2.Length - 1)];
				if (Others.Random(0, 1) == 1)
				{
					text = text + \u0008\u0010.\u0002(-1548819884) + text5 + \u0008\u0010.\u0002(-1548819864) + text6 + \u0008\u0010.\u0002(-1548819872);
					text2 = text2 + \u0008\u0010.\u0002(-1548819884) + text6 + \u0008\u0010.\u0002(-1548819864) + text5 + \u0008\u0010.\u0002(-1548819872);
				}
				else if (Others.Random(0, 2) == 1)
				{
					text += \u0008\u0010.\u0002(-1548819848);
				}
				text = text + text7 + \u0008\u0010.\u0002(-1548819825);
				int num3 = Others.Random(0, 3);
				bool flag = false;
				for (int j = 0; j < num3; j++)
				{
					if (!flag && Others.Random(0, 1) == 1)
					{
						text = text + \u0008\u0010.\u0002(-1548819884) + text3 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
						if (Others.Random(0, 1) == 1)
						{
							text += \u0008\u0010.\u0002(-1548819848);
						}
						text = text + \u0008\u0010.\u0002(-1548819884) + text4 + \u0008\u0010.\u0002(-1548819864) + text3 + \u0008\u0010.\u0002(-1548819872);
						flag = true;
					}
					else
					{
						text += \u0008\u0010.\u0002(-1548819848);
					}
				}
				break;
			}
			case 2:
				text = text + \u0008\u0010.\u0002(-1548819884) + text3 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text2 = text2 + \u0008\u0010.\u0002(-1548819884) + text4 + \u0008\u0010.\u0002(-1548819864) + text3 + \u0008\u0010.\u0002(-1548819872);
				break;
			case 3:
			{
				int num3 = Others.Random(1, 2);
				for (int i = 0; i < num3; i++)
				{
					text += \u0008\u0010.\u0002(-1548819848);
				}
				break;
			}
			case 4:
			{
				int num4 = Others.Random(1, text3.StartsWith(\u0008\u0010.\u0002(-1548819810)) ? 63 : 31);
				text += \u0008\u0010.\u0002(-1548819818);
				text = text + ((Others.Random(0, 1) == 0) ? \u0008\u0010.\u0002(-1548819778) : \u0008\u0010.\u0002(-1548819797)) + \u0008\u0010.\u0002(-1548830994) + text4 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text += string.Format(\u0008\u0010.\u0002(-1548819788), text3, num4);
				text2 += string.Format(\u0008\u0010.\u0002(-1548819773), text3, num4);
				text2 = text2 + ((Others.Random(0, 1) == 0) ? \u0008\u0010.\u0002(-1548819778) : \u0008\u0010.\u0002(-1548819797)) + \u0008\u0010.\u0002(-1548830994) + text4 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text2 += \u0008\u0010.\u0002(-1548819730);
				break;
			}
			case 5:
			{
				int num5 = Others.Random(1, 16777215);
				text += \u0008\u0010.\u0002(-1548819818);
				text = text + ((Others.Random(0, 1) == 0) ? \u0008\u0010.\u0002(-1548819778) : \u0008\u0010.\u0002(-1548819797)) + \u0008\u0010.\u0002(-1548830994) + text4 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text += string.Format(\u0008\u0010.\u0002(-1548819742), text3, num5);
				text2 += string.Format(\u0008\u0010.\u0002(-1548819742), text3, num5);
				text2 = text2 + ((Others.Random(0, 1) == 0) ? \u0008\u0010.\u0002(-1548819778) : \u0008\u0010.\u0002(-1548819797)) + \u0008\u0010.\u0002(-1548830994) + text4 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text2 += \u0008\u0010.\u0002(-1548819730);
				text2 = text2 ?? string.Empty;
				break;
			}
			case 6:
			{
				int num2 = Others.Random(1, text3.StartsWith(\u0008\u0010.\u0002(-1548819810)) ? 63 : 31);
				text += \u0008\u0010.\u0002(-1548819818);
				text = text + ((Others.Random(0, 1) == 0) ? \u0008\u0010.\u0002(-1548819778) : \u0008\u0010.\u0002(-1548819797)) + \u0008\u0010.\u0002(-1548830994) + text4 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text += string.Format(\u0008\u0010.\u0002(-1548819773), text3, num2);
				text2 += string.Format(\u0008\u0010.\u0002(-1548819788), text3, num2);
				text2 = text2 + ((Others.Random(0, 1) == 0) ? \u0008\u0010.\u0002(-1548819778) : \u0008\u0010.\u0002(-1548819797)) + \u0008\u0010.\u0002(-1548830994) + text4 + \u0008\u0010.\u0002(-1548819864) + text4 + \u0008\u0010.\u0002(-1548819872);
				text2 += \u0008\u0010.\u0002(-1548819730);
				break;
			}
			}
		}
		string text8 = string.Empty;
		if (!string.IsNullOrWhiteSpace(text))
		{
			text8 += text;
		}
		text8 = text8 + \u0002(\u0008\u0010.\u0002(-1548819727)) + \u0008\u0010.\u0002(-1548819872);
		text8 = (ThreadHooked ? (text8 + \u0002(2, 10)) : (text8 + \u0002(10, 50)));
		text8 += \u0008\u0010.\u0002(-1548819710);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			text8 += text2;
		}
		return text8;
	}

	private static string \u0002(int \u0002, int \u0008)
	{
		string text = string.Empty;
		int num = Others.Random(\u0002, \u0008);
		for (int i = 0; i < num; i++)
		{
			text = text + \u0008\u0010.\u0002(-1548819691) + Others.Random(1, 255).ToString(\u0008\u0010.\u0002(-1548840480)) + \u0008\u0010.\u0002(-1548819872);
		}
		return text;
	}

	private static string[] \u0002()
	{
		return new string[10]
		{
			\u0008\u0010.\u0002(-1548819671),
			\u0008\u0010.\u0002(-1548819659),
			\u0008\u0010.\u0002(-1548819648),
			\u0008\u0010.\u0002(-1548819602),
			\u0008\u0010.\u0002(-1548819587),
			\u0008\u0010.\u0002(-1548819576),
			\u0008\u0010.\u0002(-1548819562),
			\u0008\u0010.\u0002(-1548819550),
			\u0008\u0010.\u0002(-1548819506) + \u0002(1, 35) + \u0008\u0010.\u0002(-1548819492),
			\u0008\u0010.\u0002(-1548819474)
		};
	}

	public string CallWrapperCode(uint address, params object[] param)
	{
		string text = string.Empty;
		for (int num = param.Length - 1; num >= 0; num--)
		{
			object obj = param[num];
			text = text + \u0008\u0010.\u0002(-1548819484) + obj?.ToString() + \u0008\u0010.\u0002(-1548842781);
		}
		return \u0003\u2004.Replace(\u0008\u0010.\u0002(-1548819464), address.ToString(CultureInfo.InvariantCulture)).Replace(\u0008\u0010.\u0002(-1548820478), text);
	}

	public string CallWrapperCodeRebaseEsp(uint address, int espRebase, params object[] param)
	{
		string text = string.Empty;
		for (int num = param.Length - 1; num >= 0; num--)
		{
			object obj = param[num];
			text = text + \u0008\u0010.\u0002(-1548819484) + obj?.ToString() + \u0008\u0010.\u0002(-1548842781);
		}
		string newValue = address.ToString(CultureInfo.InvariantCulture);
		if (\u000e\u2004.Contains(\u0008\u0010.\u0002(-1548820459)))
		{
			newValue = string.Format(\u0008\u0010.\u0002(-1548820448), address);
		}
		return \u000e\u2004.Replace(\u0008\u0010.\u0002(-1548819464), newValue).Replace(\u0008\u0010.\u0002(-1548820478), text).Replace(\u0008\u0010.\u0002(-1548820428), espRebase.ToString(CultureInfo.InvariantCulture));
	}

	internal string[] \u0002()
	{
		try
		{
			string text = ((!ObfuscateHard) ? \u0002()[Others.Random(0, \u0002().Length - 1)] : \u0002());
			string[] array = text.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length >= 3 && text.Contains(\u0008\u0010.\u0002(-1548819727)))
			{
				string newValue = \u0008\u0010.\u0002(-1548820414) + Others.GetRandomString(15);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = array[i].Trim().Replace(\u0008\u0010.\u0002(-1548819727), newValue);
				}
			}
			return array;
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548820390) + ex);
		}
		return new string[0];
	}

	private List<string> \u0002(string[] \u0002, bool \u0008)
	{
		List<string> list = \u0002.ToList();
		if (\u0008)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Contains(\u0008\u0010.\u0002(-1548842781)))
				{
					string[] collection = list[i].Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					list.RemoveAt(i);
					list.InsertRange(i, collection);
				}
			}
		}
		if (!ThreadHooked && ObfuscateHard && \u0008)
		{
			list.RemoveAll(string.IsNullOrWhiteSpace);
			string randomString = Others.GetRandomString(20);
			for (int j = 0; j < list.Count; j++)
			{
				if (j < list.Count - 1)
				{
					list[j + 1] = \u0008\u0010.\u0002(-1548820414) + randomString + (j + 1) + \u0008\u0010.\u0002(-1548820380) + list[j + 1];
					List<string> list2 = list;
					int index = j;
					list2[index] = list2[index] + \u0008\u0010.\u0002(-1548842781) + Hook.\u0002(\u0008\u0010.\u0002(-1548820414) + randomString + (j + 1));
				}
				if (j == 0)
				{
					list[j] = \u0008\u0010.\u0002(-1548820414) + randomString + \u0008\u0010.\u0002(-1548820355) + list[j];
				}
				if (j == list.Count - 1)
				{
					List<string> list2 = list;
					int index = j;
					list2[index] = list2[index] + \u0008\u0010.\u0002(-1548842781) + Hook.\u0002(\u0008\u0010.\u0002(-1548820414) + randomString + \u0008\u0010.\u0002(-1548820337));
				}
			}
			list.Shuffle();
			list.Insert(0, Hook.\u0002(\u0008\u0010.\u0002(-1548820414) + randomString + \u0008\u0010.\u0002(-1548820347)));
			list.Add(\u0008\u0010.\u0002(-1548820414) + randomString + \u0008\u0010.\u0002(-1548820327));
			for (int k = 0; k < list.Count; k++)
			{
				if (list[k].Contains(\u0008\u0010.\u0002(-1548842781)))
				{
					string[] collection2 = list[k].Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
					list.RemoveAt(k);
					list.InsertRange(k, collection2);
				}
			}
		}
		int to = 5;
		if (ThreadHooked)
		{
			to = 2;
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			for (int num2 = Others.Random(1, to); num2 >= 1; num2--)
			{
				string[] array = this.\u0002();
				for (int num3 = array.Length - 1; num3 >= 0; num3--)
				{
					list.Insert(num, array[num3]);
				}
			}
		}
		for (int num4 = Others.Random(1, to); num4 >= 1; num4--)
		{
			list.AddRange(this.\u0002());
		}
		return list;
	}

	private static string \u0002(string \u0002)
	{
		Tuple<string, string> tuple = \u000f\u2009[Others.Random(0, \u000f\u2009.Length - 1)];
		if (string.IsNullOrWhiteSpace(tuple.Item2))
		{
			return tuple.Item1 + \u0008\u0010.\u0002(-1548830994) + \u0002;
		}
		int num = Others.Random(0, 1);
		string text = ((num == 0) ? tuple.Item1 : tuple.Item2);
		string text2 = ((num == 0) ? tuple.Item2 : tuple.Item1);
		return text + \u0008\u0010.\u0002(-1548830994) + \u0002 + \u0008\u0010.\u0002(-1548842781) + text2 + \u0008\u0010.\u0002(-1548830994) + \u0002;
	}

	public bool InstallStealthProtection()
	{
		try
		{
			if (this.m_\u0002 != null)
			{
				return true;
			}
			this.m_\u0002 = new StealthProtection(this);
			return this.m_\u0002.Install();
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548820308) + ex);
			return false;
		}
	}

	public void DisposeHooking(bool closeMemory = true)
	{
		try
		{
			lock (Locker)
			{
				lock (LockFrameLocker)
				{
					if (!Memory.IsValidAndOpenProcess())
					{
						return;
					}
					this.m_\u0002?.Dispose();
					this.m_\u0002 = null;
					if (\u0003\u2007)
					{
						Memory.HWBPStop(removeHWBPItems: true);
					}
					if (\u0008\u2003 != 0)
					{
						if (Memory.ReadPtr(\u0003) != \u0008\u2003)
						{
							try
							{
								Memory.WritePtr(\u0003, \u0008\u2003);
							}
							catch
							{
							}
							if (Memory.ReadPtr(\u0003) != \u0008\u2003)
							{
								\u0002(Memory.HProcessUInt32, \u0003, 4u, 64u, out var num);
								Memory.WritePtr(\u0003, \u0008\u2003);
								\u0002(Memory.HProcessUInt32, \u0003, 4u, num, out var _);
							}
						}
					}
					else
					{
						byte[] array = \u000f\u2004;
						if (array != null && array.Length != 0 && Memory.ReadByte(\u0003) == 233)
						{
							lock (Locker)
							{
								if (\u000f\u2004 != null)
								{
									Memory.WriteBytes(\u0003, \u000f\u2004);
								}
							}
						}
					}
					UnlockFrame(force: true);
					AllocText.Free(\u0003\u2003 - \u000e);
					AllocData.Free(this.m_\u0008);
					AllocData.Free(this.m_\u000f);
					AllocData.Free(\u0002\u2004);
					AllocData.Free(this.m_\u0006);
					AllocData.Free(\u0005\u2007);
					AllocText.Free(\u000e\u2003);
					AllocData.Free(\u0006\u2007);
					AllocData.Free(\u000f\u2007);
					AllocData.Free(\u000f\u2003);
					AllocData.Free(\u0005\u2003);
					AllocText?.Dispose();
					AllocData?.Dispose();
					if (closeMemory)
					{
						Memory.Close();
					}
				}
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548820277) + ex);
		}
	}

	[DllImport("Kernel32", ExactSpelling = true)]
	public static extern int GetCurrentThreadId();

	public void LockFrame()
	{
		if (!AllowFrameLock)
		{
			return;
		}
		lock (LockFrameLocker)
		{
			try
			{
				int currentThreadId = GetCurrentThreadId();
				if (\u0005\u2009.ContainsKey(currentThreadId))
				{
					\u0005\u2009[currentThreadId]++;
				}
				else
				{
					\u0005\u2009.Add(currentThreadId, 1);
				}
				Memory.WriteByte(\u0005\u2007, 1);
			}
			catch (Exception ex)
			{
				Logging.WriteError(\u0008\u0010.\u0002(-1548820272) + ex);
			}
		}
	}

	public void UnlockFrame(bool force = false)
	{
		if (!AllowFrameLock)
		{
			return;
		}
		lock (LockFrameLocker)
		{
			try
			{
				if (force)
				{
					\u0005\u2009.Clear();
				}
				else
				{
					int currentThreadId = GetCurrentThreadId();
					if (\u0005\u2009.ContainsKey(currentThreadId))
					{
						\u0005\u2009[currentThreadId]--;
					}
					List<int> list = new List<int>();
					bool flag = false;
					if (\u0003\u2009.IsReady)
					{
						foreach (ProcessThread thread in Process.GetCurrentProcess().Threads)
						{
							list.Add(thread.Id);
						}
						\u0003\u2009.Reset();
						flag = true;
					}
					List<int> list2 = new List<int>();
					foreach (KeyValuePair<int, int> item in \u0005\u2009)
					{
						if (item.Value <= 0 || (flag && !list.Contains(item.Key)))
						{
							list2.Add(item.Key);
						}
					}
					foreach (int item2 in list2)
					{
						\u0005\u2009.Remove(item2);
					}
				}
				if (\u0005\u2009.Count <= 0)
				{
					Memory.WriteByte(\u0005\u2007, 0);
				}
			}
			catch (Exception ex)
			{
				try
				{
					Memory.WriteByte(\u0005\u2007, 0);
					\u0005\u2009.Clear();
				}
				catch (Exception)
				{
				}
				Logging.WriteError(\u0008\u0010.\u0002(-1548820228) + ex);
			}
		}
	}

	public bool Inject(string[] asm, out uint baseCodecave, out uint injectionStart)
	{
		baseCodecave = 0u;
		injectionStart = (uint)Others.Random(0, 60);
		try
		{
			if (!Memory.IsValidAndOpenProcess() || !ThreadHooked)
			{
				\u0002();
				if (!Memory.IsValidAndOpenProcess() || !ThreadHooked)
				{
					return false;
				}
			}
			lock (Locker)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Clear();
				List<string> list = (Obfuscate ? \u0002(asm, \u0002\u2007 == 0) : asm.ToList());
				for (int i = 0; i < list.Count; i++)
				{
					stringBuilder.AppendLine(list[i]);
				}
				baseCodecave = AllocText.Get(Memory.Asm.Assemble(stringBuilder).Length + 150);
				if (baseCodecave <= injectionStart)
				{
					return false;
				}
				return Memory.Asm.Inject(stringBuilder, baseCodecave + injectionStart);
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548820174) + ex);
		}
		return false;
	}

	public byte[] Assemble(string[] asm)
	{
		lock (Locker)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Clear();
			List<string> list = (Obfuscate ? \u0002(asm, \u0002\u2007 == 0) : asm.ToList());
			for (int i = 0; i < list.Count; i++)
			{
				stringBuilder.AppendLine(list[i]);
			}
			return Memory.Asm.Assemble(stringBuilder);
		}
	}

	public bool Inject(byte[] asm, out uint baseCodecave, out uint injectionStart)
	{
		baseCodecave = 0u;
		injectionStart = (uint)Others.Random(0, 60);
		try
		{
			if (!Memory.IsValidAndOpenProcess() || !ThreadHooked)
			{
				\u0002();
				if (!Memory.IsValidAndOpenProcess() || !ThreadHooked)
				{
					return false;
				}
			}
			lock (Locker)
			{
				baseCodecave = AllocText.Get(asm.Length + 150);
				if (baseCodecave <= injectionStart)
				{
					return false;
				}
				return Memory.Asm.Inject(asm, baseCodecave + injectionStart);
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548820094) + ex);
		}
		return false;
	}

	public byte[] Execute(uint functionAddress, bool returnValue = false, int returnLength = 0)
	{
		try
		{
			uint num = 0u;
			try
			{
				if (!Memory.IsValidAndOpenProcess() || !ThreadHooked)
				{
					\u0002();
					if (!Memory.IsValidAndOpenProcess() || !ThreadHooked)
					{
						return new byte[0];
					}
				}
				lock (Locker)
				{
					while (Memory.ReadPtr(this.m_\u0008 + num) != 0 || Memory.ReadPtr(this.m_\u000f + num) != 0)
					{
						num += 4;
						if (num >= (uint)(4 * \u0005\u2004))
						{
							num = 0u;
							Thread.Sleep(1);
						}
						if (!\u0003\u2007 && Memory.IsDebuggerPresent())
						{
							DisposeHooking();
							\u0008\u2009.GetProcess().Kill();
						}
					}
					Memory.WritePtr(this.m_\u0008 + num, functionAddress);
					Memory.WritePtr(this.m_\u0006 + num, 1u);
					Memory.WritePtr(\u000f\u2003, 1u);
				}
				robotManager.Helpful.Timer timer = new robotManager.Helpful.Timer(15000.0);
				while (Memory.ReadPtr(this.m_\u0008 + num) != 0 && !timer.IsReady)
				{
					Thread.Sleep(SleepTimeWaitCalled);
				}
				byte[] result;
				if (timer.IsReady)
				{
					Memory.WritePtr(this.m_\u0006 + num, 0u);
					Memory.WritePtr(this.m_\u0008 + num, 0u);
					result = new byte[0];
					Logging.WriteError(\u0008\u0010.\u0002(-1548836761));
				}
				else if (!returnValue)
				{
					result = new byte[0];
				}
				else if (returnLength > 0)
				{
					result = Memory.ReadBytes(Memory.ReadPtr(this.m_\u000f + num), (uint)returnLength);
				}
				else
				{
					List<byte> list = new List<byte>();
					uint num2 = Memory.ReadPtr(this.m_\u000f + num);
					for (byte b = Memory.ReadByte(num2); b != 0; b = Memory.ReadByte(num2))
					{
						list.Add(b);
						num2++;
					}
					result = list.ToArray();
				}
				Memory.WritePtr(this.m_\u000f + num, 0u);
				return result;
			}
			catch (Exception ex)
			{
				Logging.WriteError(\u0008\u0010.\u0002(-1548820012) + ex);
				Memory.WritePtr(this.m_\u000f + num, 0u);
				return new byte[0];
			}
			finally
			{
				try
				{
					Memory.WritePtr(this.m_\u000f + num, 0u);
				}
				catch
				{
				}
			}
		}
		catch (Exception ex2)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548819972) + ex2);
		}
		return new byte[0];
	}

	public bool ExecuteNewThread(uint functionAddress)
	{
		try
		{
			if (functionAddress == 0 || !Memory.IsValidAndOpenProcess())
			{
				return false;
			}
			return Memory.Asm.Execute(functionAddress) == 1;
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548818871) + ex);
		}
		return false;
	}

	public bool InjectExecuteNewThread(string[] asm)
	{
		try
		{
			if (asm == null || asm.Length == 0 || !Memory.IsValidAndOpenProcess())
			{
				return false;
			}
			bool flag = false;
			uint num;
			lock (Locker)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Clear();
				foreach (string item in Obfuscate ? \u0002(asm, \u0002\u2007 == 0) : asm.ToList())
				{
					stringBuilder.AppendLine(item);
				}
				num = AllocText.Get(Memory.Asm.Assemble(stringBuilder).Length + 150);
				if (num != 0)
				{
					flag = Memory.Asm.Inject(stringBuilder, num);
				}
			}
			if (flag)
			{
				bool result = Memory.Asm.Execute(num) == 1;
				AllocText.Free(num);
				return result;
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548818821) + ex);
		}
		return false;
	}

	public byte[] InjectAndExecute(string[] asm, bool returnValue = false, int returnLength = 0, bool freeMemory = true)
	{
		try
		{
			if (Inject(asm, out var baseCodecave, out var injectionStart))
			{
				byte[] result = Execute(baseCodecave + injectionStart, returnValue, returnLength);
				if (freeMemory)
				{
					AllocText.Free(baseCodecave);
				}
				if (ArgsParser.GetArgs.LogInject)
				{
					try
					{
						string stackTrace = Environment.StackTrace;
						string[] array = stackTrace.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length >= 4)
						{
							Logging.WriteFileOnly(\u0008\u0010.\u0002(-1548818772) + array[3]);
						}
						else
						{
							Logging.WriteFileOnly(\u0008\u0010.\u0002(-1548818772) + stackTrace);
						}
					}
					catch
					{
					}
				}
				return result;
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548818754) + ex);
		}
		return new byte[0];
	}

	public byte[] InjectAndExecute(byte[] asm, bool returnValue = false, int returnLength = 0, bool freeMemory = true)
	{
		try
		{
			if (Inject(asm, out var baseCodecave, out var injectionStart))
			{
				byte[] result = Execute(baseCodecave + injectionStart, returnValue, returnLength);
				if (freeMemory)
				{
					AllocText.Free(baseCodecave);
				}
				if (ArgsParser.GetArgs.LogInject)
				{
					try
					{
						string stackTrace = Environment.StackTrace;
						string[] array = stackTrace.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
						if (array.Length >= 4)
						{
							Logging.WriteFileOnly(\u0008\u0010.\u0002(-1548818772) + array[3]);
						}
						else
						{
							Logging.WriteFileOnly(\u0008\u0010.\u0002(-1548818772) + stackTrace);
						}
					}
					catch
					{
					}
				}
				return result;
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548818679) + ex);
		}
		return new byte[0];
	}

	public static bool IsUsed(int processId, uint detourAddress, bool hwbpHook = false, uint isPointerHookDefaultValue = 0u)
	{
		Memory memory = new Memory(processId);
		try
		{
			if (hwbpHook)
			{
				return memory.IsDebuggerPresent();
			}
			if (isPointerHookDefaultValue != 0)
			{
				return memory.ReadPtr(detourAddress) != isPointerHookDefaultValue;
			}
			return memory.ReadByte(detourAddress) == 233;
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548818606) + ex);
		}
		finally
		{
			memory.Close();
		}
		return false;
	}

	public void CloseHookedProcess()
	{
		try
		{
			if (Memory.IsValidAndOpenProcess())
			{
				Process.GetProcessById(Memory.ProcessId).Kill();
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0008\u0010.\u0002(-1548818572) + ex);
		}
	}

	public static int CalculateFrameRate()
	{
		lock (\u0006\u2001)
		{
			long times = Others.Times;
			if (times - \u000e\u2009 >= 1000)
			{
				Logging.WriteDebug(\u0008\u0010.\u0002(-1548818535) + \u0008\u2001);
				\u0002\u2001 = \u0008\u2001;
				\u0008\u2001 = 0;
				\u000e\u2009 = times;
			}
			\u0008\u2001++;
		}
		return \u0002\u2001;
	}

	public void Dispose()
	{
		DisposeHooking();
	}

	private List<\u0008> \u0002()
	{
		List<\u0008> list = new List<\u0008>();
		\u0002(out var obj);
		long num = obj.\u0006.ToInt64();
		\u0008 obj2;
		for (long num2 = obj.\u000f.ToInt64(); num < num2; num += (long)obj2.\u000f)
		{
			obj2 = default(\u0008);
			\u0002((IntPtr)Memory.HProcessUInt32, new IntPtr(num), out obj2, (uint)Marshal.SizeOf((object)obj2));
			list.Add(obj2);
		}
		return list;
	}

	[DllImport("kernel32.dll", EntryPoint = "VirtualQueryEx", ExactSpelling = true, SetLastError = true)]
	private static extern int \u0002(IntPtr \u0002, IntPtr \u0008, out \u0008 \u0006, uint \u000f);

	[DllImport("kernel32.dll", EntryPoint = "GetSystemInfo")]
	private static extern void \u0002(out \u0006 \u0002);

	private void \u0002(ThreadContext \u0002)
	{
		\u0002.Eip = \u0003\u2003;
	}
}
