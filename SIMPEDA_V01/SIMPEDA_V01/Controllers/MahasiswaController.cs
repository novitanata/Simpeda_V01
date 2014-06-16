using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01.Controllers
{
    public class MahasiswaController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();

        // GET: /Mahasiswa/
        public ActionResult Index()
        {
            var mahasiswas = db.Mahasiswas.Include(m => m.JurusanInstansi);
            return View(mahasiswas.ToList());
        }

        // GET: /Mahasiswa/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        public ActionResult DetailsSms(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // GET: /Mahasiswa/Create
        public ActionResult Create()
        {
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan");
            return View();
        }

        // POST: /Mahasiswa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NRP,idJurusan,namaMhs,teleponMhs,alamatMhs,emailMhs,poinPunishmentMhs,barcodeImageMhs,barcodeMhs")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Mahasiswas.Add(mahasiswa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", mahasiswa.idJurusan);
            return View(mahasiswa);
        }

        // GET: /Mahasiswa/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", mahasiswa.idJurusan);
            return View(mahasiswa);
        }

        // POST: /Mahasiswa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NRP,idJurusan,namaMhs,teleponMhs,alamatMhs,emailMhs,poinPunishmentMhs,barcodeImageMhs,barcodeMhs")] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahasiswa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", mahasiswa.idJurusan);
            return View(mahasiswa);
        }

        // GET: /Mahasiswa/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: /Mahasiswa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mahasiswa mahasiswa = db.Mahasiswas.Find(id);
            db.Mahasiswas.Remove(mahasiswa);
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
