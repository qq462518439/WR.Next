using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using robotManager;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalLanguageOption
    {
        public OriginalLanguageOption(string fileName, string displayName, bool isDefault)
        {
            FileName = fileName;
            DisplayName = displayName;
            IsDefault = isDefault;
        }

        public string FileName { get; }
        public string DisplayName { get; }
        public bool IsDefault { get; }
    }

    internal static class OriginalLanguageManager
    {
        private const string DefaultLanguageFileName = "中文-默认.xml";
        private const string SourceLanguageFileName = "汉化（新板）v3.xml";
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private static readonly string AppBaseDirectory = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

        public static string CurrentLanguageFileName { get; private set; } = DefaultLanguageFileName;
        public static event EventHandler LanguageChanged;

        public static IReadOnlyList<OriginalLanguageOption> GetAvailableLanguages()
        {
            EnsureLanguageAssets();

            var directory = GetLanguageDirectory();
            var files = Directory.Exists(directory)
                ? Directory.GetFiles(directory, "*.xml").Select(Path.GetFileName).Where(name => !string.IsNullOrWhiteSpace(name)).ToList()
                : new List<string>();

            if (!files.Any(static name => string.Equals(name, DefaultLanguageFileName, StringComparison.OrdinalIgnoreCase)))
            {
                files.Insert(0, DefaultLanguageFileName);
            }

            return files
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderByDescending(static name => string.Equals(name, DefaultLanguageFileName, StringComparison.OrdinalIgnoreCase))
                .ThenBy(static name => name, StringComparer.OrdinalIgnoreCase)
                .Select(static name => new OriginalLanguageOption(name, GetDisplayName(name), string.Equals(name, DefaultLanguageFileName, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public static string GetCurrentLanguageFileName()
        {
            EnsureLanguageAssets();
            var settingsFile = Path.Combine(Paths.SettingsRoot, "lang.txt");
            if (File.Exists(settingsFile))
            {
                var value = File.ReadAllText(settingsFile, Encoding.UTF8).Trim();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    CurrentLanguageFileName = value;
                }
            }

            return CurrentLanguageFileName;
        }

        public static bool ApplyLanguage(string fileName)
        {
            EnsureLanguageAssets();

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }

            var languageFilePath = Path.Combine(GetLanguageDirectory(), fileName);
            if (!File.Exists(languageFilePath))
            {
                return false;
            }

            if (!Translate.Load(fileName))
            {
                return false;
            }

            var changed = !string.Equals(CurrentLanguageFileName, fileName, StringComparison.OrdinalIgnoreCase);
            WriteLanguageSetting(Paths.SettingsRoot, fileName);
            WriteLanguageSetting(GetAppSettingsDirectory(), fileName);
            CurrentLanguageFileName = fileName;
            if (changed)
            {
                LanguageChanged?.Invoke(null, EventArgs.Empty);
            }
            return true;
        }

        public static void EnsureLanguageAssets()
        {
            var languageDirectory = GetLanguageDirectory();
            var appLanguageDirectory = GetAppLanguageDirectory();
            Directory.CreateDirectory(languageDirectory);
            Directory.CreateDirectory(appLanguageDirectory);
            Directory.CreateDirectory(Paths.SettingsRoot);
            Directory.CreateDirectory(GetAppSettingsDirectory());

            var sourcePath = Path.Combine(languageDirectory, SourceLanguageFileName);
            var defaultPath = Path.Combine(languageDirectory, DefaultLanguageFileName);
            var appDefaultPath = Path.Combine(appLanguageDirectory, DefaultLanguageFileName);

            if (File.Exists(sourcePath) && !File.Exists(defaultPath))
            {
                File.Copy(sourcePath, defaultPath, overwrite: false);
            }

            MirrorLanguageFiles(languageDirectory, appLanguageDirectory);

            if (File.Exists(defaultPath) && !File.Exists(appDefaultPath))
            {
                File.Copy(defaultPath, appDefaultPath, overwrite: false);
            }

            var settingsPath = Path.Combine(Paths.SettingsRoot, "lang.txt");
            if (!File.Exists(settingsPath) || string.IsNullOrWhiteSpace(File.ReadAllText(settingsPath)))
            {
                WriteLanguageSetting(Paths.SettingsRoot, DefaultLanguageFileName);
            }

            var appSettingsPath = Path.Combine(GetAppSettingsDirectory(), "lang.txt");
            if (!File.Exists(appSettingsPath) || string.IsNullOrWhiteSpace(File.ReadAllText(appSettingsPath)))
            {
                WriteLanguageSetting(GetAppSettingsDirectory(), DefaultLanguageFileName);
            }
        }

        private static string GetLanguageDirectory()
        {
            return Path.Combine(Paths.DataRoot, "Lang");
        }

        private static string GetAppLanguageDirectory()
        {
            return Path.Combine(AppBaseDirectory, "Data", "Lang");
        }

        private static string GetAppSettingsDirectory()
        {
            return Path.Combine(AppBaseDirectory, "Settings");
        }

        private static string GetDisplayName(string fileName)
        {
            if (string.Equals(fileName, DefaultLanguageFileName, StringComparison.OrdinalIgnoreCase))
            {
                return "中文（默认）";
            }

            return Path.GetFileNameWithoutExtension(fileName);
        }

        private static void MirrorLanguageFiles(string sourceDirectory, string destinationDirectory)
        {
            var sourceFull = Path.GetFullPath(sourceDirectory).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var destinationFull = Path.GetFullPath(destinationDirectory).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            if (string.Equals(sourceFull, destinationFull, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            foreach (var file in Directory.GetFiles(sourceDirectory, "*.xml"))
            {
                var destinationPath = Path.Combine(destinationDirectory, Path.GetFileName(file));
                var fileFull = Path.GetFullPath(file).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                var destinationFileFull = Path.GetFullPath(destinationPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                if (string.Equals(fileFull, destinationFileFull, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                File.Copy(file, destinationPath, overwrite: true);
            }
        }

        private static void WriteLanguageSetting(string directory, string fileName)
        {
            Directory.CreateDirectory(directory);
            File.WriteAllText(Path.Combine(directory, "lang.txt"), fileName, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
        }
    }
}
