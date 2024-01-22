using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worklog_demo.Models
{
    public class ProjectItem
    {
        [Key]
        public int projectID { get; set; }
        [Required]
        public string projectName { get; set; }
    }
}
