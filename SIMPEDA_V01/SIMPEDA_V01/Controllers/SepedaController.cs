using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01.Controllers
{
    public class SepedaController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();

        // GET: /Sepeda/
        public ActionResult Index()
        {
            var sepedas = db.Sepedas.Include(s => s.Shelter);
            return View(sepedas.ToList());
        }

        public ActionResult SepedaShelter(int idShelter)
        {
            var sepedas = from s in db.Sepedas
                          where s.idShelter.Equals(idShelter) 
                          select s;
            ViewBag.idShelter = idShelter;
            ViewBag.idSepeda = from s in db.Sepedas
                               where s.idShelter.Equals(idShelter)
                               select s.idSepeda;
            return View(sepedas.ToList());
        }

        // GET: /Sepeda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepeda sepeda = db.Sepedas.Find(id);
            if (sepeda == null)
            {
                return HttpNotFound();
            }
            return View(sepeda);
        }

        // GET: /Sepeda/Create
        public ActionResult Create()
        {
            ViewBag.idShelter = new SelectList(db.Shelters, "idShelter", "lokasiShelter");
            return View();
        }

        // POST: /Sepeda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idSepeda,idShelter,merkSepeda,warnaSepeda,ketersediaan,keterangan")] Sepeda sepeda)
        {
            if (ModelState.IsValid)
            {
                db.Sepedas.Add(sepeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idShelter = new SelectList(db.Shelters, "idShelter", "lokasiShelter", sepeda.idShelter);
            return View(sepeda);
        }

        // GET: /Sepeda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepeda sepeda = db.Sepedas.Find(id);
            if (sepeda == null)
            {
                return HttpNotFound();
            }
            ViewBag.idShelter = new SelectList(db.Shelters, "idShelter", "lokasiShelter", sepeda.idShelter);
            return View(sepeda);
        }

        // POST: /Sepeda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idSepeda,idShelter,merkSepeda,warnaSepeda,ketersediaan,keterangan")] Sepeda sepeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sepeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idShelter = new SelectList(db.Shelters, "idShelter", "lokasiShelter", sepeda.idShelter);
            return View(sepeda);
        }

        // GET: /Sepeda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepeda sepeda = db.Sepedas.Find(id);
            if (sepeda == null)
            {
                return HttpNotFound();
            }
            return View(sepeda);
        }

        // POST: /Sepeda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sepeda sepeda = db.Sepedas.Find(id);
            db.Sepedas.Remove(sepeda);
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
