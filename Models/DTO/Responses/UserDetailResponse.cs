using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo.Models.DTO.Responses
{
    public class UserDetailResponse : UsersResponse
    {
        public UserDetailResponse()
        {
            Worklogs = new HashSet<TbWorklog>();
        }

        public virtual ICollection<TbWorklog> Worklogs { get; set; }
    }
}
