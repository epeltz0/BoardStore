using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardBrowser.Models
{
    public class OrderListItem
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BoardId { get; set; }
        public string BoardName { get; set; }
        public int Price { get; set; }
        public DateTime DateOfTransaction { get; set; }
    }
}
