using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WR.OriginalUiHost
{
    internal sealed class OriginalRuntimeHealthCheckResult
    {
        public OriginalRuntimeHealthCheckResult(bool ok, string summary, IReadOnlyList<string> details)
        {
            Ok = ok;
            Summary = summary ?? string.Empty;
            Details = details ?? Array.Empty<string>();
        }

        public bool Ok { get; }
        public string Summary { get; }
        public IReadOnlyList<string> Details { get; }
    }

    internal static class OriginalRuntimeHealthCheck
    {
        public static OriginalRuntimeHealthCheckResult Run(OriginalRuntimePaths paths)
        {
            var details = new List<string>();
            var ok = true;

            if (paths == null)
            {
                return new OriginalRuntimeHealthCheckResult(false, "运行路径为空", new[] { "OriginalRuntimePaths 为 null" });
            }

            ValidateDirectory(paths.Root, "RuntimeRoot", required: true, details, ref ok);
            ValidateDirectory(paths.RuntimeAssemblyRoot, "RuntimeAssemblyRoot", required: true, details, ref ok);
            ValidateDirectory(paths.LogsRoot, "LogsRoot", required: true, details, ref ok);

            ValidateFile(Path.Combine(paths.Root, "WRobot.exe"), "WRobot.exe", details, ref ok);
            ValidateFile(Path.Combine(paths.RuntimeAssemblyRoot, "RDManaged.dll"), "RDManaged.dll", details, ref ok);
            ValidateFile(Path.Combine(paths.RuntimeAssemblyRoot, "fasmdll_managed.dll"), "fasmdll_managed.dll", details, ref ok);
            ValidateFile(Path.Combine(paths.RuntimeAssemblyRoot, "authManager.dll"), "authManager.dll", details, ref ok);
            ValidateFile(Path.Combine(paths.RuntimeAssemblyRoot, "robotManager.dll"), "robotManager.dll", details, ref ok);
            ValidateFile(Path.Combine(paths.RuntimeAssemblyRoot, "wManager.dll"), "wManager.dll", details, ref ok);

            try
            {
                Directory.CreateDirectory(paths.LogsRoot);
                var probePath = Path.Combine(paths.LogsRoot, "healthcheck-write-probe.tmp");
                File.WriteAllText(probePath, DateTime.Now.ToString("s"));
                File.Delete(probePath);
                details.Add("LogsRoot writable=True");
            }
            catch (Exception ex)
            {
                ok = false;
                details.Add("LogsRoot writable=False reason=" + ex.GetType().Name + ": " + ex.Message);
            }

            try
            {
                var currentProcessId = System.Diagnostics.Process.GetCurrentProcess().Id;
                var sameNameCount = System.Diagnostics.Process.GetProcessesByName("WR.OriginalUiHost")
                    .Count(process => process.Id != currentProcessId);
                details.Add("HostPeerInstances=" + sameNameCount);
                if (sameNameCount > 0)
                {
                    ok = false;
                    details.Add("HostPeerInstances blocking=True");
                }
            }
            catch (Exception ex)
            {
                details.Add("HostPeerInstances=unknown reason=" + ex.GetType().Name + ": " + ex.Message);
            }

            return new OriginalRuntimeHealthCheckResult(
                ok,
                ok ? "启动健康检查通过" : "启动健康检查失败",
                details);
        }

        private static void ValidateDirectory(string path, string label, bool required, List<string> details, ref bool ok)
        {
            var exists = !string.IsNullOrWhiteSpace(path) && Directory.Exists(path);
            details.Add(label + "=" + (path ?? string.Empty) + " exists=" + exists);
            if (required && !exists)
            {
                ok = false;
            }
        }

        private static void ValidateFile(string path, string label, List<string> details, ref bool ok)
        {
            var exists = File.Exists(path);
            details.Add(label + "=" + path + " exists=" + exists);
            if (!exists)
            {
                ok = false;
            }
        }
    }
}
