using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalPopupSuppressor
    {
        private const int WmClose = 0x0010;
        private readonly string _runtimeRoot;
        private readonly int _processId;
        private readonly DispatcherTimer _timer;

        public OriginalPopupSuppressor(string runtimeRoot)
        {
            _runtimeRoot = runtimeRoot;
            _processId = Process.GetCurrentProcess().Id;
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(250)
            };
            _timer.Tick += delegate { SuppressNow(); };
        }

        public void Start()
        {
            _timer.Start();
            SuppressNow();
        }

        private void SuppressNow()
        {
            EnumWindows(delegate(IntPtr handle, IntPtr parameter)
            {
                uint windowProcessId;
                GetWindowThreadProcessId(handle, out windowProcessId);
                if (windowProcessId != _processId || !IsWindowVisible(handle))
                {
                    return true;
                }

                var title = GetWindowText(handle);
                var className = GetClassName(handle);
                if (ShouldSuppress(handle, title, className))
                {
                    Log("suppress-popup title=\"" + title + "\" class=\"" + className + "\" handle=0x" + handle.ToInt64().ToString("X"));
                    SendMessage(handle, WmClose, IntPtr.Zero, IntPtr.Zero);
                }

                return true;
            }, IntPtr.Zero);
        }

        private static bool ShouldSuppress(IntPtr handle, string title, string className)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return false;
            }

            if (Application.Current != null && Application.Current.MainWindow != null)
            {
                var mainHandle = new System.Windows.Interop.WindowInteropHelper(Application.Current.MainWindow).Handle;
                if (handle == mainHandle)
                {
                    return false;
                }
            }

            if (title == "WR Original UI Host" || title == "WRobot")
            {
                return false;
            }

            var lower = title.ToLowerInvariant();
            return className == "#32770" ||
                   lower.Contains("login") ||
                   lower.Contains("auth") ||
                   lower.Contains("wrobot") ||
                   lower.Contains("originaluihost") ||
                   lower.Contains("install") ||
                   lower.Contains("subscription") ||
                   lower.Contains("verify") ||
                   lower.Contains("登录") ||
                   lower.Contains("验证") ||
                   lower.Contains("订阅");
        }

        private void Log(string message)
        {
            try
            {
                File.AppendAllText(
                    Path.Combine(_runtimeRoot, "Logs", "original-ui-host-popups.txt"),
                    DateTime.Now.ToString("s") + " " + message + Environment.NewLine);
            }
            catch
            {
            }
        }

        private static string GetWindowText(IntPtr handle)
        {
            var builder = new StringBuilder(512);
            GetWindowText(handle, builder, builder.Capacity);
            return builder.ToString();
        }

        private static string GetClassName(IntPtr handle)
        {
            var builder = new StringBuilder(256);
            GetClassName(handle, builder, builder.Capacity);
            return builder.ToString();
        }

        private delegate bool EnumWindowsProc(IntPtr handle, IntPtr parameter);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, IntPtr parameter);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr handle);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr handle, out uint processId);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowText(IntPtr handle, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetClassName(IntPtr handle, StringBuilder className, int count);

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr handle, int message, IntPtr wParam, IntPtr lParam);
    }
}
