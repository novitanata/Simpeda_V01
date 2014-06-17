using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIMPEDA_V01.Controllers;
using SIMPEDA_V01.Models;
using SIMPEDA_V01Test.Repositories;

namespace SIMPEDA_V01Test
{
    [TestClass]
    public class TransaksiTest
    {
        Transaksi trans1 = null;
        Transaksi trans2 = null;
        Transaksi trans3 = null;
        Transaksi trans4 = null;
        

        List<Transaksi> transaksis = null;
        DummyTransaksisRepository transaksisRepo = null;
        ServiceTransaksi uow = null;
        TransaksiController controller = null;

        public TransaksisControllerTest()
        {
            trans1 = new Transaksi{idTransaksi = 101, idPeminjamDosen = "1200"};
            trans2 = new Transaksi{idTransaksi = 102, idPeminjamMhs= "5111100201"};
            trans3 = new Transaksi{idTransaksi = 104, idSepeda = 34};

            transaksis = new List<Transaksi>
            {
                trans1,
                trans2,
                trans3,
                trans4
            };

            transaksisRepo = new DummyTransaksisRepository(transaksis);

            uow = new ServiceTransaksi(transaksisRepo);

            controller = new TransaksiController(uow);

        }

        [TestMethod]
        public void Index()
        {
            ViewResult result = controller.Index() as ViewResult;
            var model = (List<Transaksi>result.ViewData.Model);
            CollectionAssert.Contains(model, trans1);
            CollectionAssert.Contains(model, trans2);
            CollectionAssert.Contains(model, trans3);
            CollectionAssert.Contains(model, trans4);

        }

        [TestMethod]
        public void Details()
        {
            // Lets call the action method now
            ViewResult result = controller.Details(1) as ViewResult;

            // Now lets evrify whether the result contains our book
            Assert.AreEqual(result.Model, trans1);
        }
        
        [TestMethod]
        public void Create()
        {   
            // Lets create a valid book objct to add into
            Transaksi newTransaksi = new Transaksi { idTransaksi = 107, idPeminjamDosen = "1201" };

            // Lets call the action method now
            controller.Create(newTransaksi);

            // get the list of books
            List<Transaksi> transaksi = transaksisRepo.GetAllTransaksis();

            CollectionAssert.Contains(transaksis, newTransaksi);
        }

        [TestMethod]
        public void Edit()
        {
            // Lets create a valid book objct to add into
            Transaksi editedTransaksi = new Transaksi {idTransaksi = 101, idPeminjamDosen = "1200" };

            // Lets call the action method now
            controller.Edit(editedTransaksi);

            // get the list of books
            List<Transaksi> transaksis = transaksisRepo.GetAllTransaksis();

            CollectionAssert.Contains(transaksis, editedTransaksi);
        }

        [TestMethod]
        public void Delete()
        {
            // Lets call the action method now
            controller.Delete(1);

            // get the list of books
            List<Transaksi> transaksis = transaksisRepo.GetAllTransaksis();

            CollectionAssert.DoesNotContain(transaksis, trans1);
        }
    }
}
