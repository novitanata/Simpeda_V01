using System.Collections.Generic;
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
    public class SepedaTest
    {

        Sepeda sepeda1 = null;
        Sepeda sepeda2 = null;
        Sepeda sepeda3 = null;

        private List<Sepeda> sepedas = null;
        private DummySepedasRepository sepedasRepository = null;
        private SepedaController controller = new SepedaController();
        private ServiceSepeda serviceSepeda = null;

        public SepedaTest()
        {
            sepeda1 = new Sepeda {idSepeda = 20, idShelter = 111, keterangan = "Bagus",warnaSepeda = "merah",ketersediaan = 1,merkSepeda = "Gunung Abadi"};
            sepeda2 = new Sepeda { idSepeda = 21, idShelter = 222, keterangan = "Bagus Sekali",warnaSepeda = "merah",ketersediaan = 1, merkSepeda = "Gunung Abadi" };
            sepeda3 = new Sepeda { idSepeda = 22, idShelter = 333, keterangan = "Rusak jok nya",warnaSepeda = "merah", ketersediaan = 1, merkSepeda = "Keong Emas" };
            sepedas = new List<Sepeda>
            {
             sepeda1,sepeda2,sepeda3   
            };
            sepedasRepository = new DummySepedasRepository(sepedas);
            serviceSepeda = new ServiceSepeda(sepedasRepository);
            controller = new SepedaController(serviceSepeda);
        }
        
        [TestMethod]
        public void Index()
        {
            //Arrange
            ViewResult result = controller.Index() as ViewResult;
            //Act
            Debug.Assert(result != null, "result != null");
            var model = (List<Sepeda>)result.ViewData.Model;
            //Assert
            CollectionAssert.Contains(model,sepeda1);
            CollectionAssert.Contains(model,sepeda2);
            CollectionAssert.Contains(model,sepeda3);
        }

        [TestMethod]
        public void Create()
        {
            //Arrange
            Sepeda newSepeda = new Sepeda()
            {
                idSepeda = 23,
                idShelter = 111,
                keterangan = "Bagus",
                ketersediaan = 1,
                merkSepeda = "Gunung Abadi"
            };
            controller.Create(newSepeda);
            //Act
            List<Sepeda> sepedas = sepedasRepository.GetAllSepedas();
            //Assert
            CollectionAssert.Contains(sepedas, newSepeda);
        }

        [TestMethod]
        public void Details()
        {
            //Act
            ViewResult result = controller.Details(20) as ViewResult;
            //Assert
            Debug.Assert(result != null, "result != null");
            Assert.AreEqual(result.Model, sepeda1);
        }





    }
}
