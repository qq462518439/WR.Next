using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalThemeOption
    {
        public OriginalThemeOption(string key, string displayName)
        {
            Key = key;
            DisplayName = displayName;
        }

        public string Key { get; }
        public string DisplayName { get; }
    }

    internal static class OriginalThemeManager
    {
        private const string DefaultThemeKey = "dark";
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;
        private static ResourceDictionary _activeThemeDictionary;

        public static string CurrentThemeKey { get; private set; } = DefaultThemeKey;
        public static event EventHandler ThemeChanged;

        public static IReadOnlyList<OriginalThemeOption> GetAvailableThemes()
        {
            return new[]
            {
                new OriginalThemeOption("dark", "深色"),
                new OriginalThemeOption("light", "浅色")
            };
        }

        public static void Initialize(Application application)
        {
            if (application == null)
            {
                return;
            }

            CurrentThemeKey = LoadThemeKey();
            ApplyTheme(application, CurrentThemeKey, raiseChanged: false);
        }

        public static void ApplyTheme(Application application, string themeKey, bool raiseChanged = true)
        {
            if (application == null)
            {
                return;
            }

            var normalizedKey = NormalizeThemeKey(themeKey);
            var themeUri = GetThemeUri(normalizedKey);
            var dictionary = new ResourceDictionary
            {
                Source = themeUri
            };

            if (_activeThemeDictionary != null)
            {
                application.Resources.MergedDictionaries.Remove(_activeThemeDictionary);
            }

            application.Resources.MergedDictionaries.Insert(0, dictionary);
            _activeThemeDictionary = dictionary;

            var changed = !string.Equals(CurrentThemeKey, normalizedKey, StringComparison.OrdinalIgnoreCase);
            CurrentThemeKey = normalizedKey;
            SaveThemeKey(normalizedKey);

            if (raiseChanged && changed)
            {
                ThemeChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static string LoadThemeKey()
        {
            try
            {
                var file = Path.Combine(Paths.SettingsRoot, "ui-theme.txt");
                if (File.Exists(file))
                {
                    var value = File.ReadAllText(file).Trim();
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        return NormalizeThemeKey(value);
                    }
                }
            }
            catch
            {
            }

            return DefaultThemeKey;
        }

        private static void SaveThemeKey(string themeKey)
        {
            try
            {
                Directory.CreateDirectory(Paths.SettingsRoot);
                File.WriteAllText(Path.Combine(Paths.SettingsRoot, "ui-theme.txt"), themeKey);
            }
            catch
            {
            }
        }

        private static string NormalizeThemeKey(string themeKey)
        {
            return string.Equals(themeKey, "light", StringComparison.OrdinalIgnoreCase)
                ? "light"
                : "dark";
        }

        private static Uri GetThemeUri(string themeKey)
        {
            var fileName = string.Equals(themeKey, "light", StringComparison.OrdinalIgnoreCase)
                ? "Themes/Theme.Light.xaml"
                : "Themes/Theme.Dark.xaml";

            return new Uri("/WR.OriginalUiHost;component/" + fileName, UriKind.Relative);
        }
    }
}
