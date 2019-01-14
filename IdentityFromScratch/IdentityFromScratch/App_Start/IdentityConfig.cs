using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFromScratch
{

    public class ApplicationUserManager : UserManager<CustomUser>
    {
        public ApplicationUserManager(UserStore<CustomUser> userStore) : base(userStore)
        {

        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var userStore = new UserStore<CustomUser>(context.Get<ApplicationIdentityDbContext>());

            return new ApplicationUserManager(userStore);
        }
    }

    public class ApplicationSignInManager: SignInManager<CustomUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authManager):base(userManager, authManager)
        {

        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.Get<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationRoleManager: RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> store) : base(store)
        {

        }

        public static ApplicationRoleManager Create(IOwinContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context.Get<ApplicationIdentityDbContext>());

            return new ApplicationRoleManager(roleStore);
        }
    }

    public class IdentityConfig
    {}
}