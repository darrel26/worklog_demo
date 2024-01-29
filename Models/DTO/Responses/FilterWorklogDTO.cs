using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Models.DTO.Flattening;

namespace worklog_demo.Models.DTO.Responses
{
    public class FilterWorklogDTO
    {
        public object Messages { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
