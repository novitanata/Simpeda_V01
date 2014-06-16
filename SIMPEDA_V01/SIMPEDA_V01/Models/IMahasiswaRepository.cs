using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace SIMPEDA_V01.Models
{
    public interface IMahasiswaRepository
    {
        List<Mahasiswa> GetAllMahasiswa();

        Mahasiswa GetMahasiswaById(string id);
        void AddMahasiswa(Mahasiswa mahasiswa);
        void UpdateMahasiswa(Mahasiswa mahasiswa);
        void DeleteMahasiswa(Mahasiswa mahasiswa);
        void Save();
    }
}
