using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBrowser.Data
{
    public class Roles
    {
        [Key]
        [Required]
        public int RoleId { get; set; }
        [Required]
        public string Name { get; set; } 
    }
}
