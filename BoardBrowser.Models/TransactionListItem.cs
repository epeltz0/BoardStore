using System;
using System.Collections.Generic;
using System.Text;

namespace BoardBrowser.Models
{
    public class TransactionListItem
    {
        public int CustomerID { get; set; }
        public string BoardId { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
