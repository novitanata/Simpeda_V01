using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPEDA_V01.Models
{
    interface ITransaksisRepository
    {
        public interface ITransaksisRepository
        {
            List<Transaksi> GetAllTransaksis();
            Transaksi GetTransaksiById(int id);
            void AddTransaksi(Transaksi transaksi);
            void UpdateTransaksi(Transaksi transaksi);
            void DeleteTransaksi(Transaksi transaksi);
            void Save();
        }
    }
}
