using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    public abstract class BaseController : Controller
    {
        public ApplicationUserManager ApplicationUserManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
        }

        public ApplicationSignInManager ApplicationSignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
        }
    }
}