using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginWithAuthenticationTest.Models;

namespace LoginWithAuthenticationTest.Controllers
{
    public class ProgramadorsController : Controller
    {
        private jobEntities1 db = new jobEntities1();

        // GET: Programadors
        public ActionResult Index()
        {
            return View(db.Programador.ToList());
        }

        // GET: Programadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programador programador = db.Programador.Find(id);
            if (programador == null)
            {
                return HttpNotFound();
            }
            return View(programador);
        }

        // GET: Programadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Programadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramadorGUID,ProgramadorID,FirstName,LastName,Email,Password,Age,PhoneNumber,Location,Category,Description,PriceHour,Foto,LinkGithub,LinkLinkedin,Certificates,Privacy")] Programador programador)
        {
            if (ModelState.IsValid)
            {
                db.Programador.Add(programador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(programador);
        }

        // GET: Programadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programador programador = db.Programador.Find(id);
            if (programador == null)
            {
                return HttpNotFound();
            }
            return View(programador);
        }

        // POST: Programadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramadorGUID,ProgramadorID,FirstName,LastName,Email,Password,Age,PhoneNumber,Location,Category,Description,PriceHour,Foto,LinkGithub,LinkLinkedin,Certificates,Privacy")] Programador programador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(programador);
        }

        // GET: Programadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programador programador = db.Programador.Find(id);
            if (programador == null)
            {
                return HttpNotFound();
            }
            return View(programador);
        }

        // POST: Programadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Programador programador = db.Programador.Find(id);
            db.Programador.Remove(programador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
