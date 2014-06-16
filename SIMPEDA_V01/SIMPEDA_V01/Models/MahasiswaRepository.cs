using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace SIMPEDA_V01.Models
{
    public class MahasiswaRepository : IMahasiswaRepository
    {
        private SimpedaEntities db = null;

        public MahasiswaRepository(SimpedaEntities dbEntities)
        {
            this.db = dbEntities;
        }
        public List<Mahasiswa> GetAllMahasiswa()
        {
            return db.Mahasiswas.ToList();
        }

        public Mahasiswa GetMahasiswaById(string id)
        {
            return db.Mahasiswas.SingleOrDefault(mahasiswa => mahasiswa.NRP == id);
        }

        public void AddMahasiswa(Mahasiswa mahasiswa)
        {
            db.Mahasiswas.Add(mahasiswa);
        }

        public void UpdateMahasiswa(Mahasiswa mahasiswa)
        {
            db.Mahasiswas.Attach(mahasiswa);
            ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager.ChangeObjectState(mahasiswa, EntityState.Modified);
        }

        public void DeleteMahasiswa(Mahasiswa mahasiswa)
        {
            db.Mahasiswas.Remove(mahasiswa);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}