using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Flattening
{
    public class CollaborationDTO : ProjectDTO
    {
        public List<string> Collaboration { get; set; }
    }
}
