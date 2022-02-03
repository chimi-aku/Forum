using Forum.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            ThreadSelectList();
            return View();
        }

        // POST: Thread/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Thread model)
        {
            try
            {
                var um = LocalUserManager;

                string userID = um.FindByName(User.Identity.Name).Id;
                model.AuthorID = userID;
                model.Author = db.Users.Find(userID);


                ThreadSelectList();

                db.Thread.Add(model);
                db.SaveChanges();


                string link = "index/" + model.ForumID.ToString();

                return RedirectToAction(link, "Thread");
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
        public ActionResult Edit(int id, FormCollection collectiomn, Thread model)
        {
            try
            {
                // TODO: Add update logic here

                string link = "index/" + model.ForumID.ToString();

                return RedirectToAction(link, "Thread");
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
                var threadToDelete = db.Thread.Where(t => t.ThreadID == id).ToList();
                db.Thread.Remove(threadToDelete.First());
                db.SaveChanges();

                string link = "index/" + id.ToString();

                return RedirectToAction(link, "Thread");
            }
            catch
            {
                return View();
            }
        }

        public UserManager<ApplicationUser> LocalUserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            }
        }

        private void ThreadSelectList()
        {
            List<SelectListItem> forumsIDs = new List<SelectListItem>();
            List<Models.Forum> forums = db.Set<Models.Forum>().ToList();

            foreach (var f in forums)
            {
                SelectListItem tmp = new SelectListItem() { Text = f.Name, Value = f.ForumID.ToString() };
                forumsIDs.Add(tmp);
            }

            forumsIDs.FirstOrDefault().Selected = true;

            ViewBag.ForumID = forumsIDs;
        }
    }
}
