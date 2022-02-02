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
    public class PostController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        

        
        public int currThreadID { get; set; }

        public List<Post> posts { get; set; }

        public string threadName { get; set; }



        // GET: Post
        [Authorize]
        public ActionResult Index(int id, string name)
        {

                currThreadID = id;
                threadName = name;

                posts = db.Posts.Where(t => t.ThreadID == id).ToList();


   
            return View(this);
        }

        // GET: Post/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        [Authorize]
        public ActionResult Create()
        {


            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Post model, int currThreadIDInCreate)
        {

            try
            {
                // TODO: Add insert logic here
                var um = LocalUserManager;
                string userID = um.FindByName(User.Identity.Name).Id;
                model.AuthorID = userID;
                model.Author = db.Users.Find(userID);

                model.ThreadID = currThreadIDInCreate;
                model.Thread = db.Thread.Find(currThreadIDInCreate);

                db.Posts.Add(model);
                db.SaveChanges();

                string theadListAction = "index/" + currThreadIDInCreate;
                return RedirectToAction(theadListAction, "Thread");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        [Authorize]
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

        // GET: Post/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
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

        public UserManager<ApplicationUser> LocalUserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            }
        }
    }
}
