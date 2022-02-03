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

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [Authorize]
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

 
            public RoleManager<IdentityRole> LocalRoleManager
            {
                get
                {
                    return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
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

        [Authorize(Roles = "Admin")]
        public ActionResult RolePage()
        {

            ViewBag.list = new RoleController().AllRoles();

            return View();
        }

        [Authorize]
        public ActionResult AddToUser()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddToUser(String name, String nameR)
        {
            if (name != null && nameR != null) {
                var um = LocalUserManager;
                string user = um.FindByName(name).Id;
                var idResult = um.AddToRole(user, nameR);
            }
            return View();
        }

        [Authorize]
        public ActionResult AddR()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddR( String name)
        {
            if (name != null)
            {
                var rm = LocalRoleManager;
                var idResult = rm.Create(new IdentityRole(name));
            }
            return View();
        }



        // Thread 
        [Authorize]
        public ActionResult ThreadCreate()
        {
            ThreadSelectList();
            return View();
        }

      
        [HttpPost]
        public ActionResult ThreadCreate(Thread model)
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
            //return View();
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