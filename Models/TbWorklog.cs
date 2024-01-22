using System;
using System.Collections.Generic;

#nullable disable

namespace worklog_demo.Models
{
    public partial class TbWorklog
    {
        public int LogId { get; set; }
        public TimeSpan LogStart { get; set; }
        public TimeSpan LogEnd { get; set; }
        public DateTime LogDate { get; set; }
        public string LogDetails { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual TbProject Project { get; set; }
        public virtual TbUser User { get; set; }
    }
}
