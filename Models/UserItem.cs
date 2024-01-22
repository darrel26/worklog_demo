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
        [StringLength(15)]
        public string username { get; set; }
        [Required]
        [StringLength(50)]
        public string fullName { get; set; }
        [Required]
        [StringLength(15)]
        public string password { get; set; }
    }
}
