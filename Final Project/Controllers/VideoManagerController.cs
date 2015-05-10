using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project.DataContexts;
using Final_Project.Models;

namespace Final_Project.Controllers
{
    public class VideoManagerController : Controller
    {
        private VideoDb db = new VideoDb();

        // GET: VideosManager
        public ActionResult Index()
        {
            var videos = db.Videos.Include(v => v.Author).Include(v => v.Category);
            return View(videos.ToList());
        }

        // GET: VideosManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: VideosManager/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Username");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            return View();
        }

        // POST: VideosManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoID,Title,AuthorID,CategoryID,VideoUrl")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Username", video.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", video.CategoryID);
            return View(video);
        }

        // GET: VideosManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Username", video.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", video.CategoryID);
            return View(video);
        }

        // POST: VideosManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoID,Title,AuthorID,CategoryID,VideoUrl")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "Username", video.AuthorID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name", video.CategoryID);
            return View(video);
        }

        // GET: VideosManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: VideosManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
