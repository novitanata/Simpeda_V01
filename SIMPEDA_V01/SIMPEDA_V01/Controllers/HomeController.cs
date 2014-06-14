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
	}
}