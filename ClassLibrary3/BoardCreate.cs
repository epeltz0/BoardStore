﻿using BoardBrowser.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static BoardBrowser.Data.Board;

namespace BoardBrowser.Models
{
    public class BoardCreate
    {
        [Required]
        public string BoardName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public Category BoardCategory { get; set; }
        public Quality BoardQuality { get; set; }
    }
}
