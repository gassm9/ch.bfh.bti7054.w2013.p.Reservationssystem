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
    [Authorize(Roles="admin")]
    public class TemplateController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /Template/
        public ActionResult Index()
        {
            return View(db.Templates.ToList());
        }

        // GET: /Template/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateModel templatemodel = db.Templates.Find(id);
            if (templatemodel == null)
            {
                return HttpNotFound();
            }
            return View(templatemodel);
        }

        // GET: /Template/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Template/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,NameD,NameF,NameI,NameE,StartSatusId,ConfirmedStatusId,ApprovedSatusId,DeniedStatusId,ElaboratedStatusId")] TemplateModel templatemodel)
        {
            if (ModelState.IsValid)
            {
                db.Templates.Add(templatemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(templatemodel);
        }

        // GET: /Template/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateModel templatemodel = db.Templates.Find(id);
            if (templatemodel == null)
            {
                return HttpNotFound();
            }
            return View(templatemodel);
        }

        // POST: /Template/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,NameD,NameF,NameI,NameE,StartSatusId,ConfirmedStatusId,ApprovedSatusId,DeniedStatusId,ElaboratedStatusId")] TemplateModel templatemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(templatemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(templatemodel);
        }

        // GET: /Template/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemplateModel templatemodel = db.Templates.Find(id);
            if (templatemodel == null)
            {
                return HttpNotFound();
            }
            return View(templatemodel);
        }

        // POST: /Template/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemplateModel templatemodel = db.Templates.Find(id);
            db.Templates.Remove(templatemodel);
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
