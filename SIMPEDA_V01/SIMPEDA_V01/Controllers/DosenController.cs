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
    public class DosenController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();

        // GET: /Dosen/
        public ActionResult Index()
        {
            var dosens = db.Dosens.Include(d => d.JurusanInstansi);
            return View(dosens.ToList());
        }

        // GET: /Dosen/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosen dosen = db.Dosens.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        // GET: /Dosen/Create
        public ActionResult Create()
        {
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan");
            return View();
        }

        // POST: /Dosen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NIP,idJurusan,namaDosen,teleponDosen,alamatDosen,emailDosen,poinPunishmentDosen")] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                db.Dosens.Add(dosen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", dosen.idJurusan);
            return View(dosen);
        }

        // GET: /Dosen/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosen dosen = db.Dosens.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", dosen.idJurusan);
            return View(dosen);
        }

        // POST: /Dosen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NIP,idJurusan,namaDosen,teleponDosen,alamatDosen,emailDosen,poinPunishmentDosen")] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dosen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", dosen.idJurusan);
            return View(dosen);
        }

        // GET: /Dosen/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dosen dosen = db.Dosens.Find(id);
            if (dosen == null)
            {
                return HttpNotFound();
            }
            return View(dosen);
        }

        // POST: /Dosen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dosen dosen = db.Dosens.Find(id);
            db.Dosens.Remove(dosen);
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
