using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardBrowser.Models
{
    public class OrderCreate
    {
        
        public int CustomerId { get; set; }
        
        public int BoardId { get; set; }
      
        public DateTime DateOfTransaction { get; set; }
       
    }
}
