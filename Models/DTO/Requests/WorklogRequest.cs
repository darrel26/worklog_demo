using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Requests
{
    public class WorklogRequest
    {
        [Required]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):[0-5][0-9]:[0-5][0-9]$")]
        public string LogStart { get; set; }

        [Required]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):[0-5][0-9]:[0-5][0-9]$")]
        public string LogEnd { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        [StringLength(255)]
        public string LogDetails { get; set; }

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        [StringLength(50)]
        public string LogTitle { get; set; }
    }
}
