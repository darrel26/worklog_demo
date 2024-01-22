using System;
using System.Collections.Generic;

#nullable disable

namespace worklog_demo.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            Worklogs = new HashSet<TbWorklog>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TbWorklog> Worklogs { get; set; }
    }
}
