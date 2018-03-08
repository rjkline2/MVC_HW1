using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_HW1.Models;

namespace MVC_HW1.Controllers
{
    public class SuperHeroModelController : Controller
    {
        private MVC_HW1Context db = new MVC_HW1Context();

        // GET: SuperHeroModel
        public ActionResult Index()
        {
            return View(db.SuperHeroModels.ToList());
        }

        // GET: SuperHeroModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperHeroModel superHeroModel = db.SuperHeroModels.Find(id);
            if (superHeroModel == null)
            {
                return HttpNotFound();
            }
            return View(superHeroModel);
        }

        // GET: SuperHeroModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuperHeroID,SuperHeroName,SuperHeroFlightSpeed,SuperHeroStrenghtLevel,SuperHeroAlignment")] SuperHeroModel superHeroModel)
        {
            if (ModelState.IsValid)
            {
                db.SuperHeroModels.Add(superHeroModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(superHeroModel);
        }

        // GET: SuperHeroModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperHeroModel superHeroModel = db.SuperHeroModels.Find(id);
            if (superHeroModel == null)
            {
                return HttpNotFound();
            }
            return View(superHeroModel);
        }

        // POST: SuperHeroModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuperHeroID,SuperHeroName,SuperHeroFlightSpeed,SuperHeroStrenghtLevel,SuperHeroAlignment")] SuperHeroModel superHeroModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superHeroModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superHeroModel);
        }

        // GET: SuperHeroModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SuperHeroModel superHeroModel = db.SuperHeroModels.Find(id);
            if (superHeroModel == null)
            {
                return HttpNotFound();
            }
            return View(superHeroModel);
        }

        // POST: SuperHeroModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SuperHeroModel superHeroModel = db.SuperHeroModels.Find(id);
            db.SuperHeroModels.Remove(superHeroModel);
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
