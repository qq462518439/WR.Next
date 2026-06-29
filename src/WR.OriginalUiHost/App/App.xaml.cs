using System;
using System.IO;
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
            PreloadNativeBridgeAssemblies();
            TryLoadStyleResources();
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Show();
            WriteStartupLog("OnStartup end");
        }

        private static void PreloadNativeBridgeAssemblies()
        {
            TryPreloadAssembly("RDManaged.dll");
            TryPreloadAssembly("fasmdll_managed.dll");
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
