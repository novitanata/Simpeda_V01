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
    public class PegawaiController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();

        // GET: /Pegawai/
        public ActionResult Index()
        {
            var pegawais = db.Pegawais.Include(p => p.JurusanInstansi);
            return View(pegawais.ToList());
        }

        // GET: /Pegawai/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pegawai pegawai = db.Pegawais.Find(id);
            if (pegawai == null)
            {
                return HttpNotFound();
            }
            return View(pegawai);
        }

        public ActionResult DetailsSms(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pegawai pegawai = db.Pegawais.Find(id);
            if (pegawai == null)
            {
                return HttpNotFound();
            }
            return View(pegawai);
        }

        // GET: /Pegawai/Create
        public ActionResult Create()
        {
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan");
            return View();
        }

        // POST: /Pegawai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idPegawai,idJurusan,namaPegawai,jabatan,teleponPegawai,alamatPegawai,emailPegawai,poinPunishmetPegawai,barcodeImagePegawai,barcodePegawai")] Pegawai pegawai)
        {
            if (ModelState.IsValid)
            {
                db.Pegawais.Add(pegawai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", pegawai.idJurusan);
            return View(pegawai);
        }

        // GET: /Pegawai/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pegawai pegawai = db.Pegawais.Find(id);
            if (pegawai == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", pegawai.idJurusan);
            return View(pegawai);
        }

        // POST: /Pegawai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idPegawai,idJurusan,namaPegawai,jabatan,teleponPegawai,alamatPegawai,emailPegawai,poinPunishmetPegawai,barcodeImagePegawai,barcodePegawai")] Pegawai pegawai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pegawai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJurusan = new SelectList(db.JurusanInstansis, "idJurusan", "namaJurusan", pegawai.idJurusan);
            return View(pegawai);
        }

        // GET: /Pegawai/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pegawai pegawai = db.Pegawais.Find(id);
            if (pegawai == null)
            {
                return HttpNotFound();
            }
            return View(pegawai);
        }

        // POST: /Pegawai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pegawai pegawai = db.Pegawais.Find(id);
            db.Pegawais.Remove(pegawai);
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
