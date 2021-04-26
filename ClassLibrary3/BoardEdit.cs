using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardBrowser.Data.Board;

namespace BoardBrowser.Models
{
    public class BoardEdit
    {
        public int BoardId { get; set; }
        public Category BoardCategory { get; set; }
        public string BoardName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Quality BoardQuality { get; set; }
    }
}
