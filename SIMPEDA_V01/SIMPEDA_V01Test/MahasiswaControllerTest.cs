﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIMPEDA_V01.Models;
using SIMPEDA_V01Test.Repositories;
using SIMPEDA_V01.Controllers;
using System.Web.Mvc;


namespace SIMPEDA_V01Test.Controllers.Test
{
    [TestClass]
    public class MahasiswaControllerTest
    {
        Mahasiswa mahasiswa1 = null;
        Mahasiswa mahasiswa2 = null;
        Mahasiswa mahasiswa3 = null;
        
        List<Mahasiswa> mahasiswa = null;
        DummyMahasiswaRepository mahasiswasRepo = null;
        ServiceMahasiswa sm = null;
        MahasiswaController controller = null;

        public MahasiswaControllerTest()
        {
            mahasiswa1 = new Mahasiswa { NRP = "5111100150", namaMhs = "Aisha Yuliandari", emailMhs = "aishayuliandari@gmail.com" };
            mahasiswa2 = new Mahasiswa { NRP = "5111100189", namaMhs = "Deasy Maharani", emailMhs = "Deasy@gmail.com" };
            mahasiswa3 = new Mahasiswa { NRP = "511110001", namaMhs = "Novita Nata", emailMhs = "Novita@gmail.com" };

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
        public void Details()
        {
            ViewResult result = controller.Details("5111100150") as ViewResult;

            Assert.AreEqual(result.Model, mahasiswa1);
        }

        [TestMethod]
        public void Delete()
        {
            controller.Delete("511110001");

            List<Mahasiswa> mahasiswa = mahasiswasRepo.GetAllMahasiswa();

            CollectionAssert.DoesNotContain(mahasiswa, mahasiswa1);
        }
    }
}
