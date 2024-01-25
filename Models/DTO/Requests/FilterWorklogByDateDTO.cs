using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Requests
{
    public class FilterWorklogByDateDTO
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "yyyy-mm-dd")]
        public string DateStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "yyyy-mm-dd")]
        public string DateEnd { get; set; }

        [Required]
        public int UserId { get; set; } 
    }
}
