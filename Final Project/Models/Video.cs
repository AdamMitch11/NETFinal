using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Video
    {
        public string Title { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int VideoID { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}