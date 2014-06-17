using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Data;

namespace SIMPEDA_V01.Models
{
    public class TransaksisRepository : ITransaksisRepository
    {
        SimpedaEntities entities = null;

        public TransaksisRepository(SimpedaEntities entities)
        {
            this.entities = entities;
        }

        public List<Transaksi> GetAllTransaksis()
        {
            return entities.Transaksis.ToList();
        }

        public Transaksi GetTransaksiById(int id)
        {
            return entities.Transaksis.SingleOrDefault(trans=>trans.idTransaksi == id);
        }

        public void AddTransaksi(Transaksi transaksi)
        {
            entities.Transaksis.Add(transaksi);
        }

        public void UpdateTransaksi(Transaksi transaksi)
        {
            entities.Transaksis.Attach(transaksi);
            ((ITransaksisRepository)entities).ObjectContext.ObjectStatemanager(transaksi, EntityState.Modified);
        }

        public void DeleteTransaksi(Transaksi transaksi)
        {
            entities.Transaksis.Remove(transaksi);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}