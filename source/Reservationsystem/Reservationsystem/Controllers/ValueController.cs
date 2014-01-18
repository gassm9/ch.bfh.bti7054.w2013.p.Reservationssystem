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
    [Authorize]
    public class ValueController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /Value/
        public ActionResult Index()
        {
            return View(db.ValueModels.ToList());
        }

        // GET: /Value/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueModel valuemodel = db.ValueModels.Find(id);
            if (valuemodel == null)
            {
                return HttpNotFound();
            }
            return View(valuemodel);
        }

        // GET: /Value/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Value/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Data")] ValueModel valuemodel)
        {
            if (ModelState.IsValid)
            {
                db.ValueModels.Add(valuemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valuemodel);
        }

        // GET: /Value/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueModel valuemodel = db.ValueModels.Find(id);
            if (valuemodel == null)
            {
                return HttpNotFound();
            }
            return View(valuemodel);
        }

        // POST: /Value/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Data")] ValueModel valuemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valuemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valuemodel);
        }

        // GET: /Value/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueModel valuemodel = db.ValueModels.Find(id);
            if (valuemodel == null)
            {
                return HttpNotFound();
            }
            return View(valuemodel);
        }

        // POST: /Value/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValueModel valuemodel = db.ValueModels.Find(id);
            db.ValueModels.Remove(valuemodel);
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
