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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            new RoleController().Create();
            new RoleController().AddToRole();
            
            return View();
        }

        public UserManager<ApplicationUser> LocalUserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
            var RegCount = db.Users.Count();
            ViewBag.RegCount = RegCount;

            var ThCount = db.Thread.Count();
            ViewBag.ThCount = ThCount;

            int PoCount = db.Posts.Count();
            ViewBag.PoCount = PoCount;

            var PinPoCount = db.PinPosts.Count();
            ViewBag.PinPoCount = PinPoCount;

            var PinThCount = db.PinThreads.Count();
            ViewBag.PinThCount = PinThCount;

            return View();
        }

        // Announcement

        [Authorize(Roles = "Admin")]
        public ActionResult AdminAnnouncement()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AdminAnnouncement(Announcement model)
        {
            var um = LocalUserManager;

            string userID = um.FindByName(User.Identity.Name).Id;
            model.AuthorID = userID;

            model.User = db.Users.Find(userID);

            db.Announcements.Add(model);
            db.SaveChanges();
        
            return View();
        }

        public List<Announcement> Announcements()
        {
            var list = db.Announcements.ToList();
            return list;
        }

        // Forum

        [Authorize(Roles = "Admin")]
        public ActionResult AdminForum()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AdminForum(Models.Forum model)
        {
            var um = LocalUserManager;

            string userID = um.FindByName(User.Identity.Name).Id;
            model.AuthorID = userID;

            model.Author = db.Users.Find(userID);

            db.Forums.Add(model);
            db.SaveChanges();

            return View();
        }

        public List<Models.Forum> Forums()
        {
            var list = db.Forums.ToList();
            return list;
        }
    }
}