using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reservationsystem.Models;

namespace Reservationsystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class StatusController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /Status/
        public ActionResult Index()
        {
            return View(db.StatusModels.ToList());
        }

        // GET: /Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModel statusmodel = db.StatusModels.Find(id);
            if (statusmodel == null)
            {
                return HttpNotFound();
            }
            return View(statusmodel);
        }

        // GET: /Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NameD,NameF,NameI,NameE")] StatusModel statusmodel)
        {
            if (ModelState.IsValid)
            {
                db.StatusModels.Add(statusmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusmodel);
        }

        // GET: /Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModel statusmodel = db.StatusModels.Find(id);
            if (statusmodel == null)
            {
                return HttpNotFound();
            }
            return View(statusmodel);
        }

        // POST: /Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NameD,NameF,NameI,NameE")] StatusModel statusmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusmodel);
        }

        // GET: /Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusModel statusmodel = db.StatusModels.Find(id);
            if (statusmodel == null)
            {
                return HttpNotFound();
            }
            return View(statusmodel);
        }

        // POST: /Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusModel statusmodel = db.StatusModels.Find(id);
            db.StatusModels.Remove(statusmodel);
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
