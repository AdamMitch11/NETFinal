using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [DisplayName("Category")]
        public string Name { get; set; }
        public List<Video> Videos { get; set; }
    }
}