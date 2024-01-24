using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Flattening
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public static implicit operator List<object>(ProjectDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
