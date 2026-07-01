using System;
using System.Diagnostics;
using MemoryRobot;
using robotManager;
using robotManager.Helpful;
using robotManager.MemoryClass;

namespace wManager.Wow;

public static class Memory
{
	public static Hook WowMemory;

	private static bool \u0002;

	private static bool \u0008;

	static Memory()
	{
		Hook wowMemory = new Hook(0, 0u, new byte[0]);
		if (7u != 0)
		{
			WowMemory = wowMemory;
		}
		if (true)
		{
			\u0002 = true;
		}
		if (3u != 0)
		{
			\u0008 = true;
		}
	}

	public static bool IsD3D9(int processId)
	{
		try
		{
			MemoryRobot.Memory memory = new MemoryRobot.Memory(processId);
			MemoryRobot.Memory memory2 = default(MemoryRobot.Memory);
			if (0 == 0)
			{
				memory2 = memory;
			}
			try
			{
				uint num = memory2.ReadUInt32(9092000u, rebaseAddress: true);
				uint num2;
				if (5u != 0)
				{
					num2 = num;
				}
				uint num3 = memory2.ReadUInt32(num2 + 40);
				uint address;
				if (3u != 0)
				{
					address = num3;
				}
				bool flag = memory2.ReadStringUTF8(address, 80).ToLower().Trim() == \u0006\u0010.\u0002(-1389977186);
				if (\u0002)
				{
					if (flag && (D3D.D3D9Adresse() > 1 || D3D9AdresseByMemoryRead(memory2) > 1))
					{
						if (D3D9AdresseByMemoryRead(memory2) > 1 && D3D.D3D9Adresse() != D3D9AdresseByMemoryRead(memory2))
						{
							uint num4 = D3D9AdresseByMemoryRead(memory2);
							byte[] opCode = ((memory2.ReadByte(num4) != 106) ? memory2.ReadBytes(num4, 5u) : memory2.ReadBytes(num4, 7u));
							D3D.ForceD3D9(num4, opCode);
						}
						Logging.WriteFileOnly(\u0006\u0010.\u0002(-1389977213));
					}
					else
					{
						Logging.WriteFileOnly(\u0006\u0010.\u0002(-1389977158));
					}
					\u0002 = false;
				}
				return flag;
			}
			finally
			{
				((IDisposable)memory2).Dispose();
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0006\u0010.\u0002(-1389976996) + ex);
			return false;
		}
	}

	public static string PlayerName(int processId)
	{
		try
		{
			if (!IsInGame(processId))
			{
				string result = Translate.Get(\u0006\u0010.\u0002(-1389976974));
				if (uint.MaxValue != 0)
				{
					return result;
				}
			}
			else
			{
				MemoryRobot.Memory memory = new MemoryRobot.Memory(processId);
				MemoryRobot.Memory memory2;
				if (3u != 0)
				{
					memory2 = memory;
				}
				try
				{
					string result2 = memory2.ReadStringUTF8(memory2.RebaseAddress(8887576u), 80);
					if (4u != 0)
					{
						return result2;
					}
				}
				finally
				{
					((IDisposable)memory2).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0006\u0010.\u0002(-1389977059) + ex);
			goto IL_0077;
		}
		string result3;
		return result3;
		IL_0077:
		return \u0006\u0010.\u0002(-1389977025);
	}

	public static bool IsInGame(int processId)
	{
		bool result = default(bool);
		try
		{
			MemoryRobot.Memory memory = new MemoryRobot.Memory(processId);
			MemoryRobot.Memory memory2;
			if (4u != 0)
			{
				memory2 = memory;
			}
			try
			{
				bool num = memory2.ReadInt32(7776824u, rebaseAddress: true) == 0 && memory2.ReadByte(memory2.RebaseAddress(8193938u)) > 0;
				if (0 == 0)
				{
					result = num;
					return result;
				}
			}
			finally
			{
				((IDisposable)memory2).Dispose();
			}
		}
		catch (Exception ex)
		{
			Exception ex2;
			if (6u != 0)
			{
				ex2 = ex;
			}
			Logging.WriteError(\u0006\u0010.\u0002(-1389977043) + ex2);
			goto IL_0071;
		}
		return result;
		IL_0071:
		return false;
	}

	public static bool IsGoodVersion(int processId)
	{
		object[] array = new object[1];
		object[] array2;
		if (uint.MaxValue != 0)
		{
			array2 = array;
		}
		array2[0] = processId;
		return (bool)\u0006\u2001\u2005.\u0002\u2002\u2005().\u0002(\u0006\u2001\u2005.\u0003\u2001\u2005(), "N-]boIsufe", array2);
	}

	public static uint DetourAddress(int processId)
	{
		try
		{
			try
			{
				int num;
				if (4u != 0)
				{
					num = 0;
				}
				if (2u != 0)
				{
					int num2 = 0;
				}
				if (3u != 0)
				{
					string text = null;
				}
				if (2u != 0)
				{
					string[] array = null;
				}
				string[] array2 = null;
				bool flag = false;
				string text2 = null;
				array2 = new string[4]
				{
					\u0006\u0010.\u0002(-1389976816),
					\u0006\u0010.\u0002(-1389976826),
					\u0006\u0010.\u0002(-1389976778),
					\u0006\u0010.\u0002(-1389976623)
				};
				flag = false;
				num = 2;
				while (true)
				{
					if (!flag && num <= 3)
					{
						string text = new StackTrace().GetFrame(num).GetMethod().DeclaringType.FullName;
						string[] array = array2;
						for (int num2 = 0; num2 < array.Length; num2++)
						{
							text2 = array[num2];
							if (text != null && text.StartsWith(text2))
							{
								goto end_IL_00b9;
							}
						}
						num++;
						continue;
					}
					if (false)
					{
						break;
					}
					return 0u;
					continue;
					end_IL_00b9:
					break;
				}
				if (ArgsParser.GetArgs.NoLockFrame)
				{
					if (\u0008)
					{
						Logging.WriteDebug(\u0006\u0010.\u0002(-1389976856));
					}
					Hook.AllowFrameLock = false;
				}
			}
			catch
			{
			}
			try
			{
				if (ArgsParser.GetArgs.NoDx)
				{
					if (\u0008)
					{
						Logging.WriteDebug(\u0006\u0010.\u0002(-1389976950));
					}
					\u0008 = false;
					return global::\u0008\u0010.\u0008\u2004.\u0002();
				}
			}
			catch
			{
			}
			\u0008 = false;
			D3D.D3D9Adresse();
			D3D.D3D11Adresse();
			if (IsD3D9(processId))
			{
				return D3D.D3D9Adresse();
			}
			return D3D.D3D11Adresse();
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0006\u0010.\u0002(-1389976913) + ex);
		}
		return 0u;
	}

	public static uint D3D9AdresseByMemoryRead(MemoryRobot.Memory memory)
	{
		uint num = memory.ReadUInt32(8773512u, rebaseAddress: true);
		uint num2;
		if (5u != 0)
		{
			num2 = num;
		}
		uint num3 = memory.ReadUInt32(num2 + 14716);
		uint address;
		if (6u != 0)
		{
			address = num3;
		}
		uint num4 = memory.ReadUInt32(address);
		uint num5;
		if (7u != 0)
		{
			num5 = num4;
		}
		return memory.ReadUInt32(num5 + 168);
	}

	public static byte[] OriginalOpCode(int processId)
	{
		try
		{
			try
			{
				if (!ArgsParser.GetArgs.NoDx)
				{
					goto end_IL_0000;
				}
				MemoryRobot.Memory memory = new MemoryRobot.Memory(Process.GetCurrentProcess().Id);
				MemoryRobot.Memory memory2;
				if (uint.MaxValue != 0)
				{
					memory2 = memory;
				}
				try
				{
					byte[] result = memory2.ReadBytes(DetourAddress(processId), 4u);
					if (true)
					{
						return result;
					}
				}
				finally
				{
					((IDisposable)memory2).Dispose();
				}
				goto end_IL_0000_2;
				end_IL_0000:;
			}
			catch
			{
			}
			if (!IsD3D9(processId))
			{
				return D3D.D3D11OpCode();
			}
			byte[] result2 = D3D.D3D9OpCode();
			if (uint.MaxValue != 0)
			{
				return result2;
			}
			end_IL_0000_2:;
		}
		catch (Exception ex)
		{
			Logging.WriteError(\u0006\u0010.\u0002(-1389976758) + ex);
			goto IL_008c;
		}
		byte[] result3;
		return result3;
		IL_008c:
		return new byte[0];
	}

	public static uint GetOffset(string pattern, int position, bool isFunction = false, bool rebase = true, MemoryRobot.Memory memory = null)
	{
		if (memory == null)
		{
			Process[] processesByName = Process.GetProcessesByName(\u0006\u0010.\u0002(-1389976581));
			Process[] array;
			if (5u != 0)
			{
				array = processesByName;
			}
			if (array.Length != 0)
			{
				MemoryRobot.Memory memory2 = new MemoryRobot.Memory(array[0].Id);
				if (0 == 0)
				{
					memory = memory2;
				}
			}
		}
		if (memory != null)
		{
			uint num = memory.FindPattern(pattern);
			uint num2;
			if (4u != 0)
			{
				num2 = num;
			}
			if (num2 == 0)
			{
				return 0u;
			}
			uint num3 = (uint)((!isFunction) ? memory.ReadUInt32((uint)(num2 + position)) : (num2 + position));
			if (rebase)
			{
				num3 -= memory.MainModuleAddress;
			}
			return num3;
		}
		return 0u;
	}
}
