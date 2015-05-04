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
        //
        // GET: /VideoLibrary/
        public ActionResult Index()
        {
            //Video Library Controller Index Page (Category)
            var cats = new List<Category>
            {
                new Category { Name = "Gaming"},
                new Category { Name = "Comedy"},
                new Category { Name = "Music"},
                new Category { Name = "Autos and Vehicle"},
                new Category { Name = "Education"},
                new Category { Name = "Film and Animation"},
                new Category { Name = "News and Politics"},
                new Category { Name = "People and Blogs"},
                new Category { Name = "Sports"},
                new Category { Name = "Science and Technology"},
                new Category { Name = "Pets and Animals"},
            };
            return View(cats);
        }

        // GET: /VideoLibrary/Browse?category=gaming
        public ActionResult Browse(String category)
        {
            //Video Library Controller Browse Page
            string cat = HttpUtility.HtmlEncode("VideoLibrary.Browse, Category = " + category);
            //cat Model for searching by category
            var catModel = new Category { Name = category };
            return View(catModel);
        }

        public ActionResult Details(int id)
        {
            //Video Library Controller Details Page
            string details = "VideoLibrary.Details, ID = " + id;
            var video = new Video { Title = "Video " + id };
            return View(video);
        }
	}
}