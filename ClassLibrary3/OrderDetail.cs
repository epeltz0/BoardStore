using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.Text;
using static BoardBrowser.Data.Board;

namespace BoardBrowser.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BoardId { get; set; }
        public Board Board { get; set; }
        public Category BoardCategory { get; set; }
        public string BoardName { get; set; }
        public int Price { get; set; }

        public DateTime DateOfTransaction { get; set; }
    }
}
