using Final_Project.DataContexts;
using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Final_Project.Controllers
{
    public class VideoLibraryController : Controller
    {
        VideoDb videoDb = new VideoDb();

        //
        // GET: /VideoLibrary/
        public ActionResult Index()
        {
            //Video Library Controller Index Page (Category)
            //var cats = new List<Category>
            //{
            //    new Category { Name = "Gaming"},
            //    new Category { Name = "Comedy"},
            //    new Category { Name = "Music"},
            //    new Category { Name = "Autos and Vehicle"},
            //    new Category { Name = "Education"},
            //    new Category { Name = "Film and Animation"},
            //    new Category { Name = "News and Politics"},
            //    new Category { Name = "People and Blogs"},
            //    new Category { Name = "Sports"},
            //    new Category { Name = "Science and Technology"},
            //    new Category { Name = "Pets and Animals"}
            //};
            var cats = videoDb.Categories.ToList();

            return View(cats);
        }

        // GET: /VideoLibrary/Browse?category=gaming
        public ActionResult Browse(String category)
        {
            //Video Library Controller Browse Page
            //string cat = HttpUtility.HtmlEncode("VideoLibrary.Browse, Category = " + category);
            //cat Model for searching by category
            var catModel = videoDb.Categories.Include("Videos").Single(g => g.Name == category);

            return View(catModel);
        }

        public ActionResult v(int id)
        {

            int width = 750;
            int height = width * 9 / 16; // 16 : 9 ratio  

            //Video Library Controller Details Page
            //string details = "VideoLibrary.Details, ID = " + id;
            //var video = new Video { Title = "Video " + id };
            ViewBag.Width = width;
            ViewBag.Height = height;
            var video = videoDb.Videos.Find(id);
            return View(video);
        }
	}
}