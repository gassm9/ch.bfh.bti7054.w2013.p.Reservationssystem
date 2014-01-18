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
    public class InputTypeController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /InputType/
        public ActionResult Index()
        {
            return View(db.InputTypeModels.ToList());
        }

        // GET: /InputType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputTypeModel inputtypemodel = db.InputTypeModels.Find(id);
            if (inputtypemodel == null)
            {
                return HttpNotFound();
            }
            return View(inputtypemodel);
        }

        // GET: /InputType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /InputType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name")] InputTypeModel inputtypemodel)
        {
            if (ModelState.IsValid)
            {
                db.InputTypeModels.Add(inputtypemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inputtypemodel);
        }

        // GET: /InputType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputTypeModel inputtypemodel = db.InputTypeModels.Find(id);
            if (inputtypemodel == null)
            {
                return HttpNotFound();
            }
            return View(inputtypemodel);
        }

        // POST: /InputType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name")] InputTypeModel inputtypemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inputtypemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inputtypemodel);
        }

        // GET: /InputType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InputTypeModel inputtypemodel = db.InputTypeModels.Find(id);
            if (inputtypemodel == null)
            {
                return HttpNotFound();
            }
            return View(inputtypemodel);
        }

        // POST: /InputType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InputTypeModel inputtypemodel = db.InputTypeModels.Find(id);
            db.InputTypeModels.Remove(inputtypemodel);
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
