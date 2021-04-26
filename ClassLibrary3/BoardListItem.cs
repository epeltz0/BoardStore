using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static BoardBrowser.Data.Board;

namespace BoardBrowser.Models
{
    public class BoardListItem
    {
        [Key]
        public int BoardId { get; set; }
        public string BoardName { get; set; }
        public Category BoardCategory { get; set;  }
        public Quality BoardQuality { get; set; }
        
    }
}
