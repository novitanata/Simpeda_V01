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
<<<<<<< HEAD
            int numBytes = (strInput.Length)/2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x*2, 2), 16);
            }

            return bytes;
        }
<<<<<<< HEAD

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

        
<<<<<<< HEAD
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
>>>>>>> d8a4c637197c3a321eaf845767b825745435af91
        }
<<<<<<< HEAD
    }
=======

        //Login Mahasiswa
        public ActionResult Loginmhs(Mahasiswa m)
=======
        public void Capture()
>>>>>>> 3ec78cc176648fd33130980b6c01ab043d878107
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
>>>>>>> f643e476d8fa832a27279a4b2a2be56f6c21e95b
