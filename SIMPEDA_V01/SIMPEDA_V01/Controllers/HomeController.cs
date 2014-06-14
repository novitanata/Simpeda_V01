using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
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
            ViewBag.shelter = "Shelter";
            ViewBag.Peminjaman = "Peminjaman";
            ViewBag.Pengembalian = "Pengembalian";
            return View();
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
        public bool ValidateUser(string idUser, string passwordUser)
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
        }
	}
}