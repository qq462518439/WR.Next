using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows;

namespace WR.OriginalUiHost
{
    public partial class App : Application
    {
        private static readonly OriginalRuntimePaths Paths = OriginalRuntimePaths.Current;

        protected override void OnStartup(StartupEventArgs e)
        {
            WriteStartupLog("OnStartup begin");
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            OriginalThemeManager.Initialize(this);
            AppDomain.CurrentDomain.AssemblyResolve += ResolveOriginalRuntimeAssembly;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            DispatcherUnhandledException += delegate(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs args)
            {
                WriteStartupLog("DispatcherUnhandledException " + args.Exception);
                args.Handled = true;
            };
            Directory.SetCurrentDirectory(Paths.Root);
            WriteStartupLog("CurrentDirectory=" + Directory.GetCurrentDirectory());
            WriteStartupLog("RuntimeRoot=" + Paths.Root);
            var healthCheck = OriginalRuntimeHealthCheck.Run(Paths);
            WriteStartupLog("HealthCheck " + healthCheck.Summary);
            foreach (var detail in healthCheck.Details)
            {
                WriteStartupLog("HealthCheckDetail " + detail);
            }

            if (!healthCheck.Ok)
            {
                MessageBox.Show(
                    healthCheck.Summary + Environment.NewLine + string.Join(Environment.NewLine, healthCheck.Details),
                    "WR.Next",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Shutdown(-1);
                return;
            }

            PreloadNativeBridgeAssemblies();
            WriteOriginalEntrySelfCheck();
            WriteLoadedAssemblySnapshot("post-preload");
            TryLoadStyleResources();
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Show();
            WriteStartupLog("OnStartup end");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            WriteStartupLog("OnExit code=" + e.ApplicationExitCode);
            base.OnExit(e);
        }

        private static void PreloadNativeBridgeAssemblies()
        {
            TryPreloadOriginalHostAssembly();
            TryPreloadAssembly("MemoryRobot.dll");
            TryPreloadAssembly("RDManaged.dll");
            TryPreloadAssembly("fasmdll_managed.dll");
        }

        private static void TryPreloadOriginalHostAssembly()
        {
            try
            {
                var candidates = new[]
                {
                    Path.Combine(Paths.Root, "WRobot.exe"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WRobot.exe")
                };

                foreach (var candidate in candidates)
                {
                    if (!File.Exists(candidate))
                    {
                        continue;
                    }

                    var loadedAssembly = Assembly.LoadFrom(candidate);
                    var hasLaunchingType = loadedAssembly.GetType("WRobot.Launching", throwOnError: false) != null;
                    WriteStartupLog(
                        "Preload original-host => " + loadedAssembly.FullName +
                        " from " + candidate +
                        " launching=" + hasLaunchingType);
                    return;
                }

                WriteStartupLog("Preload original-host missing WRobot.exe");
            }
            catch (Exception ex)
            {
                WriteStartupLog("Preload original-host failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void TryPreloadAssembly(string fileName)
        {
            try
            {
                var candidates = new[]
                {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName),
                    Path.Combine(Paths.RuntimeAssemblyRoot, fileName),
                    Path.Combine(Paths.Root, fileName)
                };

                foreach (var candidate in candidates)
                {
                    if (!File.Exists(candidate))
                    {
                        continue;
                    }

                    var loadedAssembly = Assembly.LoadFrom(candidate);
                    WriteStartupLog("Preload " + fileName + " => " + loadedAssembly.FullName + " from " + candidate);
                    return;
                }

                WriteStartupLog("Preload missing " + fileName);
            }
            catch (Exception ex)
            {
                WriteStartupLog("Preload failed " + fileName + " " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private void TryLoadStyleResources()
        {
            try
            {
                var dictionary = new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/rStyle;component/themes/generic.xaml", UriKind.Absolute)
                };
                Resources.MergedDictionaries.Add(dictionary);
                WriteStartupLog("rStyle generic.xaml loaded");
            }
            catch (Exception ex)
            {
                WriteStartupLog("rStyle generic.xaml load failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void WriteOriginalEntrySelfCheck()
        {
            try
            {
                var launchingType = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assembly =>
                    {
                        try
                        {
                            return assembly.GetType("WRobot.Launching", throwOnError: false);
                        }
                        catch
                        {
                            return null;
                        }
                    })
                    .FirstOrDefault(type => type != null);

                var launchBotMethod = typeof(wManager.Information).GetMethod(
                    "LaunchBot",
                    BindingFlags.Public | BindingFlags.Static);

                WriteStartupLog(
                    "OriginalEntrySelfCheck launching=" + (launchingType != null) +
                    " launchingAsm=" + (launchingType?.Assembly.FullName ?? "null") +
                    " launchBotMethod=" + (launchBotMethod != null));
            }
            catch (Exception ex)
            {
                WriteStartupLog("OriginalEntrySelfCheck failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static void WriteLoadedAssemblySnapshot(string label)
        {
            try
            {
                var interestingAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(assembly =>
                    {
                        try
                        {
                            var name = assembly.GetName();
                            return new
                            {
                                SimpleName = name.Name,
                                FullName = name.FullName,
                                assembly.Location
                            };
                        }
                        catch
                        {
                            return null;
                        }
                    })
                    .Where(entry => entry != null)
                    .Where(entry =>
                        string.Equals(entry.SimpleName, "MemoryRobot", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "wManager", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "robotManager", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "RDManaged", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "fasmdll_managed", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(entry.SimpleName, "WRobot", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(entry => entry.SimpleName, StringComparer.OrdinalIgnoreCase)
                    .Select(entry => entry.SimpleName + "=" + entry.FullName + " @ " + entry.Location)
                    .ToArray();

                WriteStartupLog(
                    "LoadedAssemblySnapshot " + label +
                    " count=" + interestingAssemblies.Length +
                    " entries=" + string.Join(" | ", interestingAssemblies));
            }
            catch (Exception ex)
            {
                WriteStartupLog("LoadedAssemblySnapshot " + label + " failed " + ex.GetType().Name + ": " + ex.Message);
            }
        }

        private static Assembly ResolveOriginalRuntimeAssembly(object sender, ResolveEventArgs args)
        {
            var requestedName = new AssemblyName(args.Name);
            var assemblyName = requestedName.Name + ".dll";
            WriteStartupLog("Resolve requested " + args.Name);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var loadedName = assembly.GetName();
                    if (string.Equals(loadedName.Name, requestedName.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        WriteStartupLog("Resolve reuse " + args.Name + " => " + loadedName.FullName);
                        return assembly;
                    }
                }
                catch
                {
                }
            }

            var candidates = new[]
            {
                Path.Combine(Paths.RuntimeAssemblyRoot, assemblyName),
                Path.Combine(Paths.Root, assemblyName),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, assemblyName)
            };

            foreach (var candidate in candidates)
            {
                if (File.Exists(candidate))
                {
                    WriteStartupLog("Resolve " + args.Name + " => " + candidate);
                    return Assembly.LoadFrom(candidate);
                }
            }

            WriteStartupLog("Resolve failed " + args.Name);
            return null;
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            WriteStartupLog("UnhandledException " + args.ExceptionObject);
        }

        private static void WriteStartupLog(string message)
        {
            try
            {
                var logDir = Paths.LogsRoot;
                Directory.CreateDirectory(logDir);
                File.AppendAllText(
                    Path.Combine(logDir, "original-ui-host-startup.txt"),
                    DateTime.Now.ToString("s") + " " + message + Environment.NewLine);
            }
            catch
            {
            }
        }
    }
}
