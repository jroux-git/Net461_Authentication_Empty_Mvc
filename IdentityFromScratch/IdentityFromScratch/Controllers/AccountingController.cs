using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    [Authorize(Roles="accounting, admin")]
    public class AccountingController : BaseController
    {
        // GET: Accounting
        public async Task<ActionResult> Index()
        {

            var roles = await ApplicationUserManager.GetRolesAsync(User.Identity.GetUserId());

            if (User.IsInRole("admin"))
            {
                return Content("Welcome to Accounting");
            }

            return Content("Get back to work");
        }
    }
}