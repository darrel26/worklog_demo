using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worklog_demo.Models
{
    public class UserItem
    {
        [Key]
        public int userID { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
