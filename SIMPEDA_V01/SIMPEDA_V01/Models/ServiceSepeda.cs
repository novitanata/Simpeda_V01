using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMPEDA_V01.Models
{
    public class ServiceSepeda : IDisposable
    {
        private SimpedaEntities db = null;
        public ServiceSepeda()
        {
            db = new SimpedaEntities();
            SepedasRepository = new SepedasRepository(db);
        }

        public ServiceSepeda(ISepedasRepository sepedaRepo)
        {
            SepedasRepository = sepedaRepo;
        }

        public ISepedasRepository SepedasRepository
        {
            get; private set; 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                db = null;
            }
        }

        ~ServiceSepeda()
        {
            Dispose(false);
        }
    }
}