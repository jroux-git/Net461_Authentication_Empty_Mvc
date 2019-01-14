using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityFromScratch.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return Content("index of company");
        }

        [AllowAnonymous]
        public ActionResult EmployeeList()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Content("private employee list");
            }
            else
            {
                return Content("public employee list");
            }
            
        }
    }
}