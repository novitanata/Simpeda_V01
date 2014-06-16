using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01Test.Repositories
{
    class DummyMahasiswaRepository : IMahasiswaRepository
    {
        List<Mahasiswa> m_mahasiswa = null;
        public DummyMahasiswaRepository(List<Mahasiswa> mahasiswas)
        {
            m_mahasiswa = mahasiswas;
        }
        public List<Mahasiswa> GetAllMahasiswa()
        {
            return m_mahasiswa;
        }
        public Mahasiswa GetMahasiswaById(string id)
        {
            return m_mahasiswa.SingleOrDefault(mahasiswa => mahasiswa.NRP == id);
        }
        public void AddMahasiswa(Mahasiswa mahasiswa)
        {
            m_mahasiswa.Add(mahasiswa);
        }
        public void UpdateMahasiswa(Mahasiswa mahasiswa)
        {
            string id = mahasiswa.NRP;
            Mahasiswa mahasiswaToUpdate = m_mahasiswa.SingleOrDefault(m => m.NRP == id);
            DeleteMahasiswa(mahasiswaToUpdate);
            m_mahasiswa.Add(mahasiswa);
        }
        public void DeleteMahasiswa(Mahasiswa mahasiswa)
        {
            m_mahasiswa.Remove(mahasiswa);
        }
        public void Save()
        {

        }
    }
}
