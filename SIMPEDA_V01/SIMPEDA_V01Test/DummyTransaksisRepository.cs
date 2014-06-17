using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01Test.Repositories
{
    class DummyTransaksisRepository
    {
        List<Transaksi> m_transaksis = null;

        public DummyTransaksisRepository(List<Transaksi> transaksis)
        {
            m_transaksis = transaksis;
        }

        public List<Transaksi> GetAllTransaksis()
        {
            return m_transaksis;
        }

        public Transaksi GetTransaksiById(int id)
        {
            return m_transaksis.Single(trans => trans.idTransaksi == id);
        }

        public void Addtransaksi(Transaksi transaksi)
        {
            m_transaksis.Add(transaksi);
        }

        public void UpdateTransaksi(Transaksi transaksi)
        {
            int id = transaksi.idTransaksi;
            Transaksi transaksiToUpdate = m_transaksis.SingleOrDefault(trans=>trans.idTransaksi == id);
        }

        public void DeleteTransaksi(Transaksi transaksi)
        {
            m_transaksis.Remove(transaksi);
        }

        public void Save()
        { 
        
        }

    }
}
