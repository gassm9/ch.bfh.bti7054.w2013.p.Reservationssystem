using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reservationsystem.Models;
using Reservationsystem.Models.ViewModels;

namespace Reservationsystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class KeyController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /Key/
        public ActionResult Index()
        {
            return View(db.KeyModels.ToList());
        }

        // GET: /Key/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyModel keymodel = db.KeyModels.Find(id);
            if (keymodel == null)
            {
                return HttpNotFound();
            }
            return View(keymodel);
        }

        // GET: /Key/Create
        public ActionResult Create()
        {
            var model = new KeyViewModel
            {
                Blocks = db.BlockModels.ToList<BlockModel>()
            };

            return View(model);
        }

        // POST: /Key/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KeyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var key = new KeyModel
                {
                    UniqueName = model.UniqueName,
                    NameD = model.NameD,
                    NameF = model.NameF,
                    NameI = model.NameI,
                    NameE = model.NameE,
                    DescriptionD = model.DescriptionD,
                    DescriptionF = model.DescriptionF,
                    DescriptionI = model.DescriptionI,
                    DescriptionE = model.DescriptionE,
                    Regex = model.Regex,
                    ValidationMessageD = model.ValidationMessageD,
                    ValidationMessageF = model.ValidationMessageF,
                    ValidationMessageI = model.ValidationMessageI,
                    ValidationMessageE = model.ValidationMessageE,
                    SortOrder = model.SortOrder,
                    Block = db.BlockModels.Find(model.BlockId),
                    // InputType is fixed to 1, because there is only implemented textbox type with id 1
                    // todo has to be changed, when more InputTypes are implemented
                    InputType = db.InputTypeModels.Find(1)
                };

                db.KeyModels.Add(key);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Blocks = db.BlockModels.ToList<BlockModel>();

            return View(model);
        }

        // GET: /Key/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyModel keymodel = db.KeyModels.Find(id);
            if (keymodel == null)
            {
                return HttpNotFound();
            }

            var model = new KeyViewModel
            {
                UniqueName = keymodel.UniqueName,
                NameD = keymodel.NameD,
                NameF = keymodel.NameF,
                NameI = keymodel.NameI,
                NameE = keymodel.NameE,
                DescriptionD = keymodel.DescriptionD,
                DescriptionF = keymodel.DescriptionF,
                DescriptionI = keymodel.DescriptionI,
                DescriptionE = keymodel.DescriptionE,
                Regex = keymodel.Regex,
                ValidationMessageD = keymodel.ValidationMessageD,
                ValidationMessageF = keymodel.ValidationMessageF,
                ValidationMessageI = keymodel.ValidationMessageI,
                ValidationMessageE = keymodel.ValidationMessageE,
                SortOrder = keymodel.SortOrder,
                Blocks = db.BlockModels.ToList(),
            };

            return View(model);
        }

        // POST: /Key/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KeyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var key = new KeyModel
                {
                    Id = id,
                    UniqueName = model.UniqueName,
                    NameD = model.NameD,
                    NameF = model.NameF,
                    NameI = model.NameI,
                    NameE = model.NameE,
                    DescriptionD = model.DescriptionD,
                    DescriptionF = model.DescriptionF,
                    DescriptionI = model.DescriptionI,
                    DescriptionE = model.DescriptionE,
                    Regex = model.Regex,
                    ValidationMessageD = model.ValidationMessageD,
                    ValidationMessageF = model.ValidationMessageF,
                    ValidationMessageI = model.ValidationMessageI,
                    ValidationMessageE = model.ValidationMessageE,
                    SortOrder = model.SortOrder,
                    Block = db.BlockModels.Find(model.BlockId),
                    // InputType is fixed to 1, because there is only implemented textbox type with id 1
                    // todo has to be changed, when more InputTypes are implemented
                    InputType = db.InputTypeModels.Find(1)
                };

                db.Entry(key).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Blocks = db.BlockModels.ToList<BlockModel>();

            return View(model);
        }

        // GET: /Key/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyModel keymodel = db.KeyModels.Find(id);
            if (keymodel == null)
            {
                return HttpNotFound();
            }
            return View(keymodel);
        }

        // POST: /Key/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeyModel keymodel = db.KeyModels.Find(id);
            db.KeyModels.Remove(keymodel);
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
