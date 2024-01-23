using System;
using System.Collections.Generic;

#nullable disable

namespace worklog_demo.Models
{
    public partial class TbProject
    {
        public TbProject()
        {
            Worklogs = new HashSet<TbWorklog>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<TbWorklog> Worklogs { get; set; }
    }
}
