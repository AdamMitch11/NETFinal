using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Catagory
    {
        public int CatagoryId { get; set; }
        public string Name { get; set; }
        public List<Video> Videos { get; set; }

    }
}