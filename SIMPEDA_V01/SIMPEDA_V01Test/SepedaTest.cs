using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIMPEDA_V01.Controllers;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01Test
{
    [TestClass]
    public class SepedaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new SepedaController();
            var result = controller.Details(1) as ViewResult;
            var sepeda = (Sepeda) result.ViewData.Model;
            Assert.AreEqual("Rem aus", sepeda.keterangan);


        }
    }
}
