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
        public int CustomerId { get; set; }
        [Required]
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int BoardId { get; set; }
        [Required]
        [ForeignKey("BoardId")]
        public Board Board { get; set; }
        public DateTime DateOfTransaction { get; set; }

    }
}
