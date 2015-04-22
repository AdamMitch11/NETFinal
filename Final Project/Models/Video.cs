using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Video
    {

        public int VideoId { get; set; }
        public int CatagoryId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Views { get; set; }
        public int AuthorId { get; set; }
        public string VideoSrc { get; set; }
        public string Description { get; set; }
        public Author author { get; set; }
        public Catagory catagory { get; set; }

    }
}