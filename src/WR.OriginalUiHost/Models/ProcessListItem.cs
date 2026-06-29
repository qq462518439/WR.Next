namespace WR.OriginalUiHost
{
    internal sealed class ProcessListItem
    {
        public ProcessListItem(int processId, string windowTitle, string path)
        {
            ProcessId = processId;
            WindowTitle = windowTitle;
            Path = path;
        }

        public int ProcessId { get; private set; }

        public string WindowTitle { get; private set; }

        public string Path { get; private set; }

        public string DisplayName
        {
            get { return ProcessId + "  " + (string.IsNullOrWhiteSpace(WindowTitle) ? "Wow.exe" : WindowTitle); }
        }
    }
}
