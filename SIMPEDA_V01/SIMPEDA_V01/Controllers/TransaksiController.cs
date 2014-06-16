﻿using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIMPEDA_V01.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using ZXing;


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

        public ActionResult BarcodeImage(String barcodeText)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(barcodeText, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

            Stream memoryStream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, memoryStream);

            memoryStream.Position = 0;

            var resultStream = new FileStreamResult(memoryStream, "image/png");
            resultStream.FileDownloadName = String.Format("{0}.png", barcodeText);

            return resultStream;
        }

        public ActionResult ScanBarcode(string path)
        {
            string type, content;
            IBarcodeReader reader = new BarcodeReader();
            var barcodeBitmap = (Bitmap)Bitmap.FromFile("D:\\MyPic.jpeg");
            var result = reader.Decode(barcodeBitmap);
            if (result != null)
            {
                type = result.BarcodeFormat.ToString();
                content = result.Text;
                ViewBag.type = type;
                ViewBag.content = content;
                int idTrans = Convert.ToInt32(content);

                ViewBag.cek = idTrans;
                //Transaksi transaksi = db.Transaksi.Find(idTrans);

                var print = from t in db.Transaksis
                            from m in db.Mahasiswas
                            from d in db.Dosens
                            from p in db.Pegawais
                            where t.idTransaksi.Equals(idTrans) //&& t.NRP.Equals(m.NRP) && t.NIP.Equals(d.NIP) && t.idPegawai.Equals(p.idPegawai)
                            select t;
                ViewBag.idTransaksi = idTrans;

                foreach (var item in print)
                {
                    ViewBag.idTransaksi = item.idTransaksi;
                    if (item.idPeminjamDosen != null)
                        ViewBag.namaDosen = item.Dosen.namaDosen;
                    else
                        ViewBag.namaDosen = item.idPeminjamDosen;

                    if (item.idPeminjamMhs != null)
                        ViewBag.namaMahasiswa = item.Mahasiswa.namaMhs;
                    else
                        ViewBag.namaMahasiswa = item.idPeminjamMhs;

                    if (item.idPeminjamPegawai != null)
                        ViewBag.namaPegawai = item.Pegawai.namaPegawai;
                    else
                        ViewBag.namaPegawai = item.idPeminjamPegawai;
                    
                    //ViewBag.namaPegawai = item.idPeminjamPegawai;
                    //ViewBag.namaMahasiswa = item.idPeminjamMhs;
                    ViewBag.idShelterAsal = item.Sepeda.idShelter;
                    ViewBag.waktuPinjam = item.waktuPinjam;
                }
            }


            return View();
        }

        public ActionResult CekSepeda()
        {

            var cekSepeda = from t in db.Transaksis
                            where t.status == 0 //&& t.idPeminjamMhs.Equals(m.NRP) && t.idPeminjamDosen.Equals(d.NIP) && t.idPeminjamPegawai.Equals(p.idPegawai)
                            select t;

            ViewBag.sepeda = cekSepeda.ToList();

            return View();
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

            int? idTransaksi = id;
            BarcodeImage(idTransaksi.ToString());
            ViewBag.newId = idTransaksi;

            return View(transaksi);
        }

        // GET: /Transaksi/Create
        public ActionResult Create()
        {
            ViewBag.idPeminjamDosen = new SelectList(db.Dosens, "NIP", "namaDosen");
            ViewBag.idPeminjamMhs = new SelectList(db.Mahasiswas, "NRP", "namaMhs");
            ViewBag.idPeminjamPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai");
            ViewBag.idSepeda = new SelectList(db.Sepedas, "idSepeda", "merkSepeda");
            int idTransaksi = (from t in db.Transaksis
                               select t.idTransaksi).Max();
            int barcodeTrans = idTransaksi + 1;
            BarcodeImage(barcodeTrans.ToString());
            ViewBag.newId = barcodeTrans;

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
            ViewBag.NIP = new SelectList(db.Dosens, "NIP", "namaDosen", transaksi.idPeminjamDosen);
            ViewBag.NRP = new SelectList(db.Mahasiswas, "NRP", "namaMhs", transaksi.idPeminjamMhs);
            ViewBag.idPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai", transaksi.idPeminjamPegawai);
            //ViewBag.idSepeda = new SelectList(db.Sepedas, "idSepeda", "merkSepeda", transaksi.idSepeda);

            var idSepeda = (from t in db.Transaksis
                            from d in db.Sepedas
                            where t.idTransaksi == id && t.idSepeda == d.idSepeda
                            select t.idSepeda).FirstOrDefault();
            ViewBag.idSepeda = idSepeda;

            ViewBag.waktuKembali = DateTime.Now;

            return View(transaksi);
        }

        // POST: /Transaksi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransaksi,NRP,NIP,idPegawai,idSepeda,waktuPinjam,waktuKembali,status,shelterKembali")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaksi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NIP = new SelectList(db.Dosens, "NIP", "namaDosen", transaksi.idPeminjamDosen);
            ViewBag.NRP = new SelectList(db.Mahasiswas, "NRP", "namaMhs", transaksi.idPeminjamMhs);
            ViewBag.idPegawai = new SelectList(db.Pegawais, "idPegawai", "namaPegawai", transaksi.idPeminjamPegawai);
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
