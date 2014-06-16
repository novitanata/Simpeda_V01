using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01.Controllers
{
    public class HomeController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult webcam()
        {
            return View();
        }

        public ActionResult ChartArray()
        {
            return View();
        }

        public ActionResult ChartQuery()
        {

            var hasil = (from t in db.Transaksis
                         group t by new {t.waktuPinjam} into g
                         select g.Count() );


            ViewBag.hasil = hasil.ToString();

            //int[] hasil1 = hasil.ToArray();
            //ViewData["hasil"] = hasil1;
            
            //int[] jumlah = new int[100];
            //for (int i = 0; i < hasil1.Count(); i++)
            //{
            //    jumlah[i] = hasil1[i];
            //}

            
            var hari = from t in db.Transaksis
                       group t by new { t.waktuPinjam } into g
                       select  g.Key.waktuPinjam;
            
            ViewBag.hari = hari; 

            return View();
        }

        
        public void Capture()
        {
            var stream = Request.InputStream;
                    string dump;
 
            using (var reader = new StreamReader(stream))
            dump = reader.ReadToEnd();
 
            var path = Server.MapPath("~/test.jpg");
            System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));
        }
 
        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];
 
            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }
 
            return bytes;
        }
	}
}