using System;
using System.Collections.Generic;

namespace worklog_demo.Models.DTO.Flattening
{
    public class UserDetailsDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public List<WorklogDTO> Worklogs { get; set; }
        public List<ProjectDTO> Projects { get; set; }
    }
}
