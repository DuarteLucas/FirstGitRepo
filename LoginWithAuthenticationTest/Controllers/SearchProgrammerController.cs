using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginWithAuthenticationTest.Models;

namespace LoginWithAuthenticationTest.Controllers
{
    public class SearchProgrammerController : Controller
    {
        private string results;
        
        // GET: SearchProgrammer
        [Authorize(Roles = "Admin,Company,Programmer")]
        public ActionResult SearchProgrammerForm()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult SearchProgrammerForm(string SelectedLanguage, string SelectedLocation)
        {
            jobEntities1 db = new jobEntities1();


           var results = db.Programador.Where(p => p.Language.Any(l => l.Name == SelectedLanguage) && p.Location.Contains(SelectedLocation));


            return RedirectToAction("ResultProgrammer", "Search", results);
        
        }
    }
}