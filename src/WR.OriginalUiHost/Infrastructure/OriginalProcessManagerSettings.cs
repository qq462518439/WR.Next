using System;
using System.IO;
using System.Text;

namespace WR.OriginalUiHost
{
    internal static class OriginalProcessManagerSettings
    {
        private const string AutoAttachFileName = "process-auto-attach.txt";
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;

        public static bool GetAutoAttachEnabled()
        {
            try
            {
                var path = GetAutoAttachPath();
                if (!File.Exists(path))
                {
                    return true;
                }

                var value = File.ReadAllText(path, Encoding.UTF8).Trim();
                return string.Equals(value, "1", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return true;
            }
        }

        public static void SetAutoAttachEnabled(bool enabled)
        {
            Directory.CreateDirectory(Paths.SettingsRoot);
            File.WriteAllText(
                GetAutoAttachPath(),
                enabled ? "1" : "0",
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        }

        private static string GetAutoAttachPath()
        {
            return Path.Combine(Paths.SettingsRoot, AutoAttachFileName);
        }
    }
}
