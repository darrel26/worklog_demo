using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Responses
{
    public class LoginResponse
    {
        public UsersResponse messages { get; set; }

        public bool Success { get; set; }

        public List<string> Errors { get; set; }
    }
}
