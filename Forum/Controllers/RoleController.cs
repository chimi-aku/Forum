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

        private readonly ApplicationDbContext db = new ApplicationDbContext();
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

            im.AddUserToRoleByUsername("ad@op.pl", "Admin");

            return "OK";
        }
        public List<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>  AllRoles()
        {
            IdentityManager im = new IdentityManager();
            
            var list = db.Roles.Select(x => x).ToList();
            
 

            return list;
        }




        }
}