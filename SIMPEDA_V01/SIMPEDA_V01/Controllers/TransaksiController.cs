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
    public class TransaksiController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();

        // GET: /Transaksi/
        public ActionResult Index()
        {
            var transaksis = db.Transaksis.Include(t => t.Dosen).Include(t => t.Mahasiswa).Include(t => t.Pegawai).Include(t => t.Sepeda);
            return View(transaksis.ToList());
        }

        // GET: /Transaksi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaksi transaksi = db.Transaksis.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            return View(transaksi);
        }

        // GET: /Transaksi/Create
        public ActionResult Create()
        {
            ViewBag.idPeminjamDosen = new SelectList(db.Dosens, "NIP", "namaDosen");
            ViewBag.idPeminjamMhs = new SelectList(db.Mahasiswas, "NRP", "namaMhs");
            ViewBag.idPeminjamPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai");
            ViewBag.idSepeda = new SelectList(db.Sepedas, "idSepeda", "merkSepeda");
            int newId = (int)db.GetNewIdTransaction().FirstOrDefault();

            ViewBag.idTransaksi = newId;
            ViewBag.tanggal = DateTime.Now;
            ViewBag.status = false;

            return View();
        }

        // POST: /Transaksi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idTransaksi,idPeminjamDosen,idPeminjamPegawai,idPeminjamMhs,idSepeda,waktuPinjam,waktuKembali,status,shelterKembali")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                db.Transaksis.Add(transaksi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPeminjamDosen = new SelectList(db.Dosens, "NIP", "namaDosen", transaksi.idPeminjamDosen);
            ViewBag.idPeminjamMhs = new SelectList(db.Mahasiswas, "NRP", "namaMhs", transaksi.idPeminjamMhs);
            ViewBag.idPeminjamPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai", transaksi.idPeminjamPegawai);
            ViewBag.idSepeda = new SelectList(db.Sepedas, "idSepeda", "merkSepeda", transaksi.idSepeda);


            return View(transaksi);
        }

        // GET: /Transaksi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaksi transaksi = db.Transaksis.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPeminjamDosen = new SelectList(db.Dosens, "NIP", "namaDosen", transaksi.idPeminjamDosen);
            ViewBag.idPeminjamMhs = new SelectList(db.Mahasiswas, "NRP", "namaMhs", transaksi.idPeminjamMhs);
            ViewBag.idPeminjamPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai", transaksi.idPeminjamPegawai);
            ViewBag.idSepeda = new SelectList(db.Sepedas, "idSepeda", "merkSepeda", transaksi.idSepeda);
            return View(transaksi);
        }

        // POST: /Transaksi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idTransaksi,idPeminjamDosen,idPeminjamPegawai,idPeminjamMhs,idSepeda,waktuPinjam,waktuKembali,status,shelterKembali")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaksi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPeminjamDosen = new SelectList(db.Dosens, "NIP", "namaDosen", transaksi.idPeminjamDosen);
            ViewBag.idPeminjamMhs = new SelectList(db.Mahasiswas, "NRP", "namaMhs", transaksi.idPeminjamMhs);
            ViewBag.idPeminjamPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai", transaksi.idPeminjamPegawai);
            ViewBag.idSepeda = new SelectList(db.Sepedas, "idSepeda", "merkSepeda", transaksi.idSepeda);
            return View(transaksi);
        }

        // GET: /Transaksi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaksi transaksi = db.Transaksis.Find(id);
            if (transaksi == null)
            {
                return HttpNotFound();
            }
            return View(transaksi);
        }

        // POST: /Transaksi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaksi transaksi = db.Transaksis.Find(id);
            db.Transaksis.Remove(transaksi);
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
