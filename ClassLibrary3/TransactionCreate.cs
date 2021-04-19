using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardBrowser.Models
{
    public class TransactionCreate
    {
        public Customer Customer { get; set; }
        public Board Board { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
