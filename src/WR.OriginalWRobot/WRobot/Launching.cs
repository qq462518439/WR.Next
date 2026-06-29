using robotManager.Helpful;

namespace WRobot;

public static class Launching
{
	public static int LaunchBot(string arg, Args argsEnvironmentVariables, bool minimiseOnStart = false)
	{
		object[] array = new object[3];
		object[] array2;
		if (5u != 0)
		{
			array2 = array;
		}
		array2[0] = arg;
		array2[1] = argsEnvironmentVariables;
		array2[2] = minimiseOnStart;
		return (int)global::_0006_2001_2005._0002_2002_2005()._0002(global::_0006_2001_2005._0003_2001_2005(), "b^+PZIsug]", array2);
	}
}
