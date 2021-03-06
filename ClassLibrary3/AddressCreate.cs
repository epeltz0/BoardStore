using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBrowser.Models
{
    public class AddressCreate
    {
      
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public int CustomerId { get; set; }
    }
}
