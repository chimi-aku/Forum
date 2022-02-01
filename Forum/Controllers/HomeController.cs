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
        ApplicationDbContext db;
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
            //new RoleController().Create();
            //new RoleController().AddToRole();
            
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
        
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
            model.AuthorID = userID; //Fixme int to string
            return View();
        }


    }
}