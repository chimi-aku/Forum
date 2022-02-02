using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Thread
        [Authorize]
        public ActionResult Index(int ID)
        {
            List<Thread> threads = db.Thread.Where(t => t.ForumID == ID).ToList();
            
            if(threads.Count > 0)
            {
                ViewBag.threadID = threads.First().ThreadID;
            }

            return View(threads);
        }

        // GET: Thread/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Thread/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thread/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Thread/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Thread/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
