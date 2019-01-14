using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace IdentityFromScratch.Models
{
    public class ApplicationIdentityDbContext: IdentityDbContext<CustomUser>
    {
        public ApplicationIdentityDbContext():base("Server=localhost\\SQLEXPRESS;Database=IdentityFromScratch;Trusted_Connection=True;")
        {

        }

        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }
    }

    public class CustomUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CustomUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public static class SecurityRoles
    {
        public const string Admin = "admin";
        public const string IT = "it";
        public const string Accounting = "accounting";
    }
}