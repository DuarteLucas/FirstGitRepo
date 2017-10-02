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
    public class CompanyOffersController : Controller
    {
        private jobEntities db = new jobEntities();

        // GET: CompanyOffers
        public ActionResult Index()
        {
            var companyOffer = db.CompanyOffer.Include(c => c.Company).Include(c => c.Language);
            return View(companyOffer.ToList());
        }

        // GET: CompanyOffers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOffer companyOffer = db.CompanyOffer.Find(id);
            if (companyOffer == null)
            {
                return HttpNotFound();
            }
            return View(companyOffer);
        }

        // GET: CompanyOffers/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyGUID");
            ViewBag.LanguageID = new SelectList(db.Language, "LanguageID", "Name");
            return View();
        }

        // POST: CompanyOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyOfferID,CompanyID,LanguageID,Price,Location,Experience,Description")] CompanyOffer companyOffer)
        {
            if (ModelState.IsValid)
            {
                db.CompanyOffer.Add(companyOffer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyGUID", companyOffer.CompanyID);
            ViewBag.LanguageID = new SelectList(db.Language, "LanguageID", "Name", companyOffer.LanguageID);
            return View(companyOffer);
        }

        // GET: CompanyOffers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOffer companyOffer = db.CompanyOffer.Find(id);
            if (companyOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyGUID", companyOffer.CompanyID);
            ViewBag.LanguageID = new SelectList(db.Language, "LanguageID", "Name", companyOffer.LanguageID);
            return View(companyOffer);
        }

        // POST: CompanyOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyOfferID,CompanyID,LanguageID,Price,Location,Experience,Description")] CompanyOffer companyOffer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyOffer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Company, "CompanyID", "CompanyGUID", companyOffer.CompanyID);
            ViewBag.LanguageID = new SelectList(db.Language, "LanguageID", "Name", companyOffer.LanguageID);
            return View(companyOffer);
        }

        // GET: CompanyOffers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOffer companyOffer = db.CompanyOffer.Find(id);
            if (companyOffer == null)
            {
                return HttpNotFound();
            }
            return View(companyOffer);
        }

        // POST: CompanyOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyOffer companyOffer = db.CompanyOffer.Find(id);
            db.CompanyOffer.Remove(companyOffer);
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
