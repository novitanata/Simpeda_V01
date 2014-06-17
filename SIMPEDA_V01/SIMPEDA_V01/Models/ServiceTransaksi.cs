using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPEDA_V01.Models
{
    public class ServiceTransaksi : IDisposable
    {
        private SimpedaEntities entities = null;

        public ServiceTransaksi()
        {
            entities = new SimpedaEntities();
            TransaksisRepository = new TransaksisRepository(entities);
        }

        public ServiceTransaksi(ITransaksisRepository transaksisRepo)
        {
            TransaksisRepository = transaksisRepo;
        }

        public ITransaksisRepository TransaksisRepository
        {
            get;
            private set;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                entities = null;
            }
        }

        ~ServiceTransaksi()
        {
            Dispose(false);
        }

        #endregion
    }
}