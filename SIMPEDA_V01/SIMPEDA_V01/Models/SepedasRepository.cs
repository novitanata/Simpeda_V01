using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace SIMPEDA_V01.Models
{
    public class SepedasRepository : ISepedasRepository
    {
        private SimpedaEntities db = null;

        public SepedasRepository(SimpedaEntities dbEntities)
        {
            this.db = dbEntities;
        }
        public List<Sepeda> GetAllSepedas()
        {
            return db.Sepedas.ToList();
        }

        public Sepeda GetSepedaById(int? idSepeda)
        {
            return db.Sepedas.SingleOrDefault(sepeda => sepeda.idSepeda == idSepeda);
        }

        public void AddSepeda(Sepeda sepeda)
        {
            db.Sepedas.Add(sepeda);
        }

        public void UpdateSepeda(Sepeda sepeda)
        {
            db.Sepedas.Attach(sepeda);
            ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(sepeda, EntityState.Modified);
        }

        public void DeleteSepeda(Sepeda sepeda)
        {
            db.Sepedas.Remove(sepeda);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}