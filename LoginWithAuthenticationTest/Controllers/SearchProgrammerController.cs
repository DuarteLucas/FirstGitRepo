using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginWithAuthenticationTest.Controllers
{
    public class SearchProgrammerController : Controller
    {
        // GET: SearchProgrammer
        [Authorize(Roles="Admin,Company,Programmer")]
        public ActionResult SearchProgrammer()
        {
            return View();
        }
    }
}