using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIMPEDA_V01.Controllers;
using SIMPEDA_V01.Models;
using SIMPEDA_V01Test.Repositories;

namespace SIMPEDA_V01Test
{
    [TestClass]
    public class MahasiswaTest
    {
        Mahasiswa mahasiswa1 = null;
        Mahasiswa mahasiswa2 = null;
        Mahasiswa mahasiswa3 = null;

        List<Mahasiswa> mahasiswa = null;
        DummyMahasiswaRepository mahasiswasRepo = null;
        MahasiswaController controller = null;
        ServiceMahasiswa sm = null;
        public MahasiswaTest()
        {
            mahasiswa1 = new Mahasiswa { NRP = "5111100150", namaMhs = "Aisha Yuliandari", emailMhs = "aishayuliandari@gmail.com" };
            mahasiswa2 = new Mahasiswa { NRP = "5111100189", namaMhs = "Deasy Maharani", emailMhs = "Deasy@gmail.com" };
            mahasiswa3 = new Mahasiswa { NRP = "5111100001", namaMhs = "Novita Nata", emailMhs = "Novita@gmail.com" };

            mahasiswa = new List<Mahasiswa>
            {
                mahasiswa1,
                mahasiswa2,
                mahasiswa3
            };

            mahasiswasRepo = new DummyMahasiswaRepository(mahasiswa);

            sm = new ServiceMahasiswa(mahasiswasRepo);

            controller = new MahasiswaController(sm);
        }
        [TestMethod]
        public void Index()
        {
            ViewResult result = controller.Index() as ViewResult;

            var model = (List<Mahasiswa>)result.ViewData.Model;

            CollectionAssert.Contains(model, mahasiswa1);
            CollectionAssert.Contains(model, mahasiswa2);
            CollectionAssert.Contains(model, mahasiswa3);
        }

        [TestMethod]
        public void Create()
        {
            Mahasiswa newMahasiswa = new Mahasiswa { NRP = "511110023", namaMhs = "Ika Ayu", emailMhs = "ikayu@gmail.com" };
            controller.Create(newMahasiswa);

            CollectionAssert.Contains(mahasiswa, newMahasiswa);
        }

        [TestMethod]
        public void Details()
        {
            ViewResult result = controller.Details("5111100150") as ViewResult;

            Assert.AreEqual(result.Model, mahasiswa1);
        }

        [TestMethod]
        public void Delete()
        {
            controller.Delete("5111100001");
            List<Mahasiswa> mahasiswa = mahasiswasRepo.GetAllMahasiswa();
            CollectionAssert.DoesNotContain(mahasiswa, mahasiswa3);
        }


    }
}
