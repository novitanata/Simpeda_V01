using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SIMPEDA_V01.Models;

<<<<<<< HEAD

=======
>>>>>>> 3ec78cc176648fd33130980b6c01ab043d878107
namespace SIMPEDA_V01.Controllers
{
    public class HomeController : Controller
    {
        private SimpedaEntities db = new SimpedaEntities();
<<<<<<< HEAD

=======
>>>>>>> 3ec78cc176648fd33130980b6c01ab043d878107
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
            int numBytes = (strInput.Length)/2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x*2, 2), 16);
            }

            return bytes;
        }

        public ActionResult Login()
        {
            return View();
        }

        //Login Dosen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Dosen d)
        {
            if (ModelState.IsValid) //utk validasi
            {
                using(SimpedaEntities lecture = new SimpedaEntities())
                {
                    var v = lecture.Dosens.Where(a => a.NIP.Equals(d.NIP) && a.password_Dosen.Equals(d.password_Dosen)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.NIP.ToString();
                        Session["LogedUserPassword"] = v.password_Dosen.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View(d);
        }
        
        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //Login Mahasiswa
        public ActionResult Loginmhs(Mahasiswa m)
        {
            if (ModelState.IsValid) //utk validasi
            {
                using (SimpedaEntities mhs = new SimpedaEntities())
                {
                    var vi = mhs.Mahasiswas.Where(b=> b.NRP.Equals(m.NRP) && b.password_Mhs.Equals(m.password_Mhs)).FirstOrDefault();
                    if (vi != null)
                    {
                        Session["LogedUserID"] = vi.NRP.ToString();
                        Session["LogedUserPassword"] = vi.password_Mhs.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View("Loginmhs",m);
        }

        //Login Pegawai
        public ActionResult Logipeg(Pegawai p)
        {
            if (ModelState.IsValid) //utk validasi
            {
                using (SimpedaEntities peg = new SimpedaEntities())
                {
                    var vii = peg.Pegawais.Where(c => c.idPegawai.Equals(p.idPegawai) && c.idPegawai.Equals(p.password_Pegawai)).FirstOrDefault();
                    if (vii != null)
                    {
                        Session["LogedUserID"] = vii.idPegawai.ToString();
                        Session["LogedUserPassword"] = vii.password_Pegawai.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View("Logipeg",p);
        }
        //protected void Page_Load(object sender, EventArgs e)
            //{ 

            //}

            //protected void btnMasuk_Click(object sender, EventArgs e)
            //{ 

            //}
            //protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
            //{
            //    //Check to see if the current user exists
            //    if (Membership.GetUser() != null)
            //    {
            //        //Check to see if the user is currently locked out
            //        if (Membership.GetUser(Login1.UserName).IsLockedOut)
            //        {
            //            //Get the last lockout  date from the user
            //            DateTime lastLockout = Membership.GetUser(Login1.UserName).LastLockoutDate;
            //            //Calculate the time the user should be unlocked
            //            DateTime unlockDate = lastLockout.AddMinutes(Membership.PasswordAttemptWindow);

            //            //Check to see if it is time to unlock the user
            //            //if (DateTime.Now > unlockDate)
            //            //    Membership.GetUser(Login1.UserName).UnlockUser();
            //        }
            //    }
            //}
            // public virtual bool IsLockedOut { get; }

            /*  public bool ValidateUser(string idUser, string passwordUser)
=======
       
        /*
        protected void Login1_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            //Check to see if the current user exists
            if (Membership.GetUser() != null)
                
            {
                //Check to see if the user is currently locked out
                if (Membership.GetUser(Login1.UserName).IsLockedOut)
                {
                    //Get the last lockout  date from the user
                    DateTime lastLockout = Membership.GetUser(Login1.UserName).LastLockoutDate;
                    //Calculate the time the user should be unlocked
                    DateTime unlockDate = lastLockout.AddMinutes(Membership.PasswordAttemptWindow);

                    //Check to see if it is time to unlock the user
                    //if (DateTime.Now > unlockDate)
                    //    Membership.GetUser(Login1.UserName).UnlockUser();
                }
            }
        }
        public virtual bool IsLockedOut { get; }
        public bool ValidateUser(string idUser, string passwordUser)
>>>>>>> d8a4c637197c3a321eaf845767b825745435af91
        {
            bool ret = false;
            try
            {
                using (db)
                {
                    if (passwordUser != null)
                    {
                        //Mahasiswa mhs = (from mahasiswa in db.Mahasiswas
                        //                 wfhere mahasiswa.NRP == idUser
                        //                 select mahasiswa).SingleOrDefault();
                        Dosen dos = (from dosen in db.Dosens
                                     where dosen.NIP == idUser
                                     select dosen).SingleOrDefault();
                        if (dos != null)
                        {
                            //if (dos.IsLockedOut)
                            //{ 
                            
                            //}
                        }
                        
                    }
                    
                }
            }
            catch
            {
                throw;
            }

            return ret;
<<<<<<< HEAD
        }*/
=======
            */
=======

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
>>>>>>> 3ec78cc176648fd33130980b6c01ab043d878107

            return View();
        }

        

    }
=======

        
 
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

