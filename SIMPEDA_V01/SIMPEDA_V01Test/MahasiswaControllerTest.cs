using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIMPEDA_V01.Models;
using SIMPEDA_V01Test.Repositories;
using System.Web.Mvc;


namespace SIMPEDA_V01Test.Controllers.Test
{
    [TestClass]
    public class MahasiswaControllerTest
    {
        Mahasiswa mahasiswa1 = null;
        Mahasiswa mahasiswa2 = null;
        Mahasiswa mahasiswa3 = null;
        Mahasiswa mahasiswa4 = null;
        Mahasiswa mahasiswa5 = null;

        List<Mahasiswa> mahasiswa = null;
        DummyMahasiswaRepository mahasiswasRepo = null;
        MahasiswaController controller = null;
    }
}
