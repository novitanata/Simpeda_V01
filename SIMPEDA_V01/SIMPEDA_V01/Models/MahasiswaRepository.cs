using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SIMPEDA_V01.Models
{
    public class MahasiswaRepository : IMahasiswaRepository
    {
        SimpedaEntities entities = null;

        public MahasiswaRepository(SimpedaEntities entities)
        {
            this.entities = entities;
        }
        public List<Mahasiswa> GetAllMahasiswa()
        {
            return entities.Mahasiswas.ToList();
        }
        public Mahasiswa GetMahasiswaById(int id)
        {
 
        }
    }
}