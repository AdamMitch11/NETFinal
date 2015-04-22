using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Final_Project.Models;

namespace Final_Project.DataContexts
{
    public class VideoDb : DbContext
    {
        public VideoDb() : base("DefaultConnection") { }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
    }
}