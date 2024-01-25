using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Requests
{
    public class FilterWorklogByProjectDTO
    {
        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
