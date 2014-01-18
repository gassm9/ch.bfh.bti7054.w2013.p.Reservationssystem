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
    public class BlockController : Controller
    {
        private ReservationsystemDb db = new ReservationsystemDb();

        // GET: /Block/
        public ActionResult Index()
        {
            return View(db.BlockModels.ToList());
        }

        // GET: /Block/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockModel blockmodel = db.BlockModels.Find(id);
            if (blockmodel == null)
            {
                return HttpNotFound();
            }
            return View(blockmodel);
        }

        // GET: /Block/Create
        public ActionResult Create()
        {
            var model = new BlockCreateViewModel
            {
                Templates = db.Templates.ToList<TemplateModel>()
            };
            
            return View(model);
        }

        // POST: /Block/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlockCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var block = new BlockModel
                {
                    NameD = model.NameD,
                    NameF = model.NameF,
                    NameI = model.NameI,
                    NameE = model.NameE,
                    SortOrder = model.SortOrder,
                    Template = db.Templates.Find(model.TemplateId)
                };
                
                db.BlockModels.Add(block);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Templates = db.Templates.ToList<TemplateModel>();

            return View(model);
        }

        // GET: /Block/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlockModel blockmodel = db.BlockModels.Find(id);
            if (blockmodel == null)
            {
                return HttpNotFound();
            }

            var model = new BlockCreateViewModel
            {
                NameD = blockmodel.NameD,
                NameF = blockmodel.NameF,
                NameI = blockmodel.NameI,
                NameE = blockmodel.NameE,
                SortOrder = blockmodel.SortOrder,
                Templates = db.Templates.ToList<TemplateModel>()
            };

            return View(model);
        }

        // POST: /Block/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BlockCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var block = new BlockModel
                {
                    Id = id,
                    NameD = model.NameD,
                    NameF = model.NameF,
                    NameI = model.NameI,
                    NameE = model.NameE,
                    SortOrder = model.SortOrder,
                    Template = db.Templates.Find(model.TemplateId)
                };
                
                db.Entry(block).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            model.Templates = db.Templates.ToList<TemplateModel>();

            return View(model);
        }

        // GET: /Block/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockModel blockmodel = db.BlockModels.Find(id);
            if (blockmodel == null)
            {
                return HttpNotFound();
            }
            return View(blockmodel);
        }

        // POST: /Block/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlockModel blockmodel = db.BlockModels.Find(id);
            db.BlockModels.Remove(blockmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public static List<SelectListItem> GetBlocksAsList()
        {
            ReservationsystemDb db = new ReservationsystemDb();
            List<SelectListItem> list = new List<SelectListItem>();
            var blocks = db.BlockModels.ToList();
            foreach (var block in blocks)
            {
                list.Add(new SelectListItem() { Text = block.NameD, Value = block.Id.ToString() });
            }
            return list;
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
