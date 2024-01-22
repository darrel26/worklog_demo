using System;
using System.Collections.Generic;

#nullable disable

namespace worklog_demo.Models
{
    public partial class TbUsersProject
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual TbProject Project { get; set; }
        public virtual TbUser User { get; set; }
    }
}
