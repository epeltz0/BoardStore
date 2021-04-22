using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BoardBrowser.Data
{
    public class Board
    {
        [Key]
        [Required]
        public int BoardId { get; set; }
        [Required]
        public string BoardName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public Category BoardCategory { get; set; }
        public enum Category
        {
            Longboard,
            Pennyboard,
            Skateboard,
            Accessory
        }


    }
}
