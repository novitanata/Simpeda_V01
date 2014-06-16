using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace SIMPEDA_V01.Models
{
    public class IMahasiswaRepository
    {
        List<Mahasiswa> GetAllMahasiswa();

        Mahasiswa GetMahasiswaById(int id);
        void AddMahasiswa(Mahasiswa mahasiswa);
        void UpdateMahasiswa(Mahasiswa mahasiswa);
        void DeleteMahasiswa(Mahasiswa mahasiswa);
        void Save();
    }
}