using System;
using System.Collections.Generic;
using System.Text;

namespace BoardBrowser.Models
{
    public class TransactionCreate
    {
        public int CustomerID { get; set; }
        public string BoardId { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
