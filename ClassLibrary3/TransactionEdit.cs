using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardBrowser.Models
{
    public class TransactionEdit
    {
        public int TransactionId { get; set; }
        public Customer Customer { get; set; }
        public Board Board { get; set; }
    }
}
