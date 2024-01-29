using System;

namespace worklog_demo.Models.DTO.Flattening
{
    public class WorklogDTO
    {
        public int LogId { get; set; }
        public TimeSpan LogStart { get; set; }
        public TimeSpan LogEnd { get; set; }
        public DateTime LogDate { get; set; }
        public string LogDetails { get; set; }
        public string LogTitle { get; set; }
        public int UserId { get; set; }

        public virtual CollaborationDTO Project { get; set; }
    }
}
