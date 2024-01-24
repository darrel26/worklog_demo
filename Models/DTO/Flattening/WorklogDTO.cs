using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Flattening
{
    public class WorklogDTO
    {
        public int LogId { get; set; }
        public TimeSpan LogStart { get; set; }
        public TimeSpan LogEnd { get; set; }
        public DateTime LogDate { get; set; }
        public string LogDetails { get; set; }
        public int UserId { get; set; }

        public virtual ProjectDTO Project { get; set; }
    }
}
