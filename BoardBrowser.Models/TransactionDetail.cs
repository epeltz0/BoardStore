using System;
using System.Collections.Generic;
using System.Text;

namespace BoardBrowser.Models
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public int CustomerID { get; set; }
        public string BoardId { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
