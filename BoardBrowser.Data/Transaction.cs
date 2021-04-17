using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoardBrowser.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        [Required]
        [ForeignKey(nameof(Board))]
        public string BoardId { get; set; }
        public DateTime DateOfTransaction { get; set; }

    }
}
