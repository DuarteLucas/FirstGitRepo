using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginWithAuthenticationTest.Models;

namespace LoginWithAuthenticationTest.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        [HttpPost]
        public ActionResult ResultProgrammer(string SelectedLanguage, string SelectedLocation)
        { 
            jobEntities1 db = new jobEntities1();

            //Console.WriteLine("---------- TESTE ---------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine(SelectedLanguage);
            //Console.WriteLine(SelectedLocation);
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("--------------------------");
            //Console.WriteLine("---------- TESTE ---------");

            //IEnumerable <Programador> queryResults =
            //    from prog in db.Programador
            //    where prog.Language.FirstOrDefault(c => c.Name == "Javascript")
            //    select prog;

            // RADIO_BUTTON IMPLEMENTATION TEMPLATE
            //    if (RadioButton1.Checked)
            //    {
            //        Label1.Text = "You selected " + RadioButton1.Text;
            //    }
            //    else if (RadioButton2.Checked)
            //    {
            //        Label1.Text = "You selected " + RadioButton2.Text;
            //    }
            //    else if (RadioButton3.Checked)
            //    {
            //        Label1.Text = "You selected " + RadioButton3.Text;
            //    }
            //}

            var result = db.Programador.Where( p => p.Language.Any(l => l.Name == SelectedLanguage) && p.Location.Contains(SelectedLocation) ) ;

            return View(result.ToList());
        }
    }
}