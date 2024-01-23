using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Flattening
{
    public class UserDetailsDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public List<TbWorklog> Worklogs { get; set; }
        public List<TbUsersProject> Projects { get; set; }
    }
}
