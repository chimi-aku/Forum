using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<PinPost> PinPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PinThread> PinThreads { get; set; }
        public DbSet<Thread> Thread { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


	//Klasa dodana
	public class IdentityManager
	{
		public RoleManager<IdentityRole> LocalRoleManager
		{
			get
			{
				return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
			}
		}


		public UserManager<ApplicationUser> LocalUserManager
		{
			get
			{
				return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
			}
		}


		public ApplicationUser GetUserByID(string userID)
		{
			ApplicationUser user = null;
			UserManager<ApplicationUser> um = this.LocalUserManager;

			user = um.FindById(userID);

			return user;
		}


		public ApplicationUser GetUserByName(string email)
		{
			ApplicationUser user = null;
			UserManager<ApplicationUser> um = this.LocalUserManager;

			user = um.FindByEmail(email);

			return user;
		}


		public bool RoleExists(string name)
		{
			var rm = LocalRoleManager;

			return rm.RoleExists(name);
		}


		public bool CreateRole(string name)
		{
			var rm = LocalRoleManager;
			var idResult = rm.Create(new IdentityRole(name));

			return idResult.Succeeded;
		}


		public bool CreateUser(ApplicationUser user, string password)
		{
			var um = LocalUserManager;
			var idResult = um.Create(user, password);

			return idResult.Succeeded;
		}


		public bool AddUserToRole(string userId, string roleName)
		{
			var um = LocalUserManager;
			var idResult = um.AddToRole(userId, roleName);

			return idResult.Succeeded;
		}


		public bool AddUserToRoleByUsername(string username, string roleName)
		{
			var um = LocalUserManager;

			string userID = um.FindByName(username).Id;
			var idResult = um.AddToRole(userID, roleName);

			return idResult.Succeeded;
		}


		public void ClearUserRoles(string userId)
		{
			var um = LocalUserManager;
			var user = um.FindById(userId);
			var currentRoles = new List<IdentityUserRole>();

			currentRoles.AddRange(user.Roles);

			foreach (var role in currentRoles)
			{
				um.RemoveFromRole(userId, role.RoleId);
			}
		}
	}
}