using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Author
    {

        public int AuthorID { get; set; }
        [DisplayName("Username")]
        public string Username { get; set; }
        
    }
}