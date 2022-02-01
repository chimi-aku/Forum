using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public string Create()
        {
            IdentityManager im = new IdentityManager();

            im.CreateRole("Admin");
            im.CreateRole("User");

            return "OK";
        }

        public string AddToRole()
        {
            IdentityManager im = new IdentityManager();

            im.AddUserToRoleByUsername("admin@pb.edu.pl", "Admin");

            return "OK";
        }



    }
}