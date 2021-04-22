using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBrowser.Models
{
    public class OrderEdit
    {
        public int OrderId { get; set; }
        
        public int CustomerId { get; set; }
        public int BoardId { get; set; }
    }
}
