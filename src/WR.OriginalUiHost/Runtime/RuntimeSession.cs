using System;

namespace WR.OriginalUiHost
{
    public enum SessionHealthState
    {
        NotSelected,
        Selected,
        Attaching,
        Attached,
        HookPending,
        Ready,
        Faulted,
        Lost,
        Closed
    }

    public sealed class RuntimeSession
    {
        public RuntimeSession(int processId)
        {
            ProcessId = processId;
            HealthState = SessionHealthState.Selected;
            LastHeartbeatUtc = DateTime.UtcNow;
        }

        public int ProcessId { get; }
        public bool IsAttached { get; set; }
        public bool SessionInitialized { get; set; }
        public bool MemoryOpen { get; set; }
        public bool HookReady { get; set; }
        public bool InGame { get; set; }
        public string CharacterName { get; set; }
        public string Level { get; set; }
        public string HealthPercent { get; set; }
        public string Position { get; set; }
        public string RuntimeState { get; set; }
        public string LastError { get; set; }
        public SessionHealthState HealthState { get; set; }
        public DateTime LastHeartbeatUtc { get; set; }
    }
}
