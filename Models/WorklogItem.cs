using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models
{
    public class WorklogItem
    {
        [Key]
        public int LogID { get; set; }

        [Required]
        public TimeSpan LogStart { get; set; }

        [Required]
        public TimeSpan LogEnd { get; set; }

        [Required]
        public DateTime LogDate { get; set; }

        [Required]
        [StringLength(255)]
        public string LogDetails { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [ForeignKey("UserID")]
        public UserItem User { get; set; }

        [ForeignKey("ProjectID")]
        public ProjectItem Project { get; set; }
    }
}
