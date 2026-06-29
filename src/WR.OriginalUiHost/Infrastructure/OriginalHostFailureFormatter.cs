using System;
using System.IO;
using System.Text;

namespace WR.OriginalUiHost
{
    internal static class OriginalHostFailureFormatter
    {
        public static string Format(string pageTitle, Exception ex, string runtimeRoot)
        {
            var builder = new StringBuilder();
            builder.AppendLine(pageTitle + " 初始化失败");
            builder.AppendLine();
            builder.AppendLine("异常类型: " + ex.GetType().FullName);
            builder.AppendLine("异常消息: " + ex.Message);

            AppendHint(builder, ex, runtimeRoot);

            builder.AppendLine();
            builder.AppendLine("运行根目录: " + runtimeRoot);
            builder.AppendLine();
            builder.AppendLine("堆栈:");
            builder.AppendLine(ex.ToString());
            return builder.ToString();
        }

        public static string FormatTimeout(string pageTitle, string runtimeRoot, TimeSpan timeout)
        {
            var builder = new StringBuilder();
            builder.AppendLine(pageTitle + " 加载超时");
            builder.AppendLine();
            builder.AppendLine("超时时间: " + timeout.TotalSeconds + " 秒");
            builder.AppendLine("现象: 原版控件在 UI 线程内未及时返回，当前已中止继续等待。");
            builder.AppendLine();
            builder.AppendLine("建议先检查:");
            builder.AppendLine("1. Data/Lang 与 Settings/lang.txt 是否存在于运行根目录");
            builder.AppendLine("2. 依赖 DLL 是否齐全，例如 RDManaged.dll、wManager.dll、robotManager.dll");
            builder.AppendLine("3. 原版控件是否在等待游戏上下文或阻塞式初始化");
            builder.AppendLine();
            builder.AppendLine("运行根目录: " + runtimeRoot);
            return builder.ToString();
        }

        public static string FormatProbeTimeout(string pageTitle, string runtimeRoot, TimeSpan timeout)
        {
            var builder = new StringBuilder();
            builder.AppendLine(pageTitle + " 预探测超时");
            builder.AppendLine();
            builder.AppendLine("超时时间: " + timeout.TotalSeconds + " 秒");
            builder.AppendLine("结论: 原版控件构造阶段已经阻塞，若继续进入该页面，主窗体也会一起失去响应。");
            builder.AppendLine();
            builder.AppendLine("这不是普通提示面板能兜住的问题，因为阻塞发生在原版控件自身初始化内部。");
            builder.AppendLine();
            builder.AppendLine("建议先检查:");
            builder.AppendLine("1. 原版工具页是否依赖当前游戏上下文或某个阻塞式弹窗");
            builder.AppendLine("2. 运行目录下 Data/Lang、Settings、相关 DLL 是否完整");
            builder.AppendLine("3. 是否有被隐藏的授权/订阅/输入对话框卡住流程");
            builder.AppendLine();
            builder.AppendLine("运行根目录: " + runtimeRoot);
            return builder.ToString();
        }

        private static void AppendHint(StringBuilder builder, Exception ex, string runtimeRoot)
        {
            var message = ex.ToString();
            builder.AppendLine();
            builder.AppendLine("可能原因:");

            if (message.IndexOf("FileNotFoundException", StringComparison.OrdinalIgnoreCase) >= 0 ||
                message.IndexOf("Could not load file or assembly", StringComparison.OrdinalIgnoreCase) >= 0 ||
                message.IndexOf("未能加载文件或程序集", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                builder.AppendLine("- 缺少依赖程序集或依赖路径不对");
                builder.AppendLine("- 请检查运行根目录下 DLL 是否齐全");
                return;
            }

            if (message.IndexOf("RDManaged", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                builder.AppendLine("- 缺少 RDManaged.dll 或其本机依赖");
                return;
            }

            if (message.IndexOf("lang", StringComparison.OrdinalIgnoreCase) >= 0 ||
                message.IndexOf(".xml", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                builder.AppendLine("- 语言资源未就绪，或语言文件正被占用");
                builder.AppendLine("- 请检查 " + Path.Combine(runtimeRoot, "Data", "Lang"));
                return;
            }

            builder.AppendLine("- 需要结合页面日志进一步定位");
        }
    }
}
