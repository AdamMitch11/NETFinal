using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Final_Project.Models
{
    public class Video
    {
        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "A Video Title is required!")]
        [StringLength(160)]
        public string Title { get; set; }
        [DisplayName("Author")]
        public int AuthorID { get; set; }
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        public int VideoID { get; set; }
        [DisplayName("Video Embed URL")]
        [Required(ErrorMessage = "Video embed URL tag is required")]
        [StringLength(50)]
        public string VideoUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }

        public static String PATH = "https://www.youtube.com/embed/" ;
    }
}