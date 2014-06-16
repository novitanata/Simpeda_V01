using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPEDA_V01.Models
{
    public class ServiceMahasiswa : IDisposable
    {
        private SimpedaEntities entities = null;

        public ServiceMahasiswa()
        {
            entities = new SimpedaEntities();
            MahasiswaRepository = new MahasiswaRepository(entities);
        }
        public ServiceMahasiswa(IMahasiswaRepository mahasiswasRepo)
        {
            MahasiswaRepository = mahasiswasRepo;
        }
        public IMahasiswaRepository MahasiswaRepository
        {
            get;
            private set;
        }
    }
}