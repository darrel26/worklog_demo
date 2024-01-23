using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Responses
{
    public class UsersResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }
}
