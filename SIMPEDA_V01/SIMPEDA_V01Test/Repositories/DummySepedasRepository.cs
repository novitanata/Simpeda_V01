using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMPEDA_V01.Models;

namespace SIMPEDA_V01Test.Repositories
{
    class DummySepedasRepository : ISepedasRepository
    {
        private List<Sepeda> dummySepedas;

        public DummySepedasRepository(List<Sepeda> sepedas)
        {
            dummySepedas = sepedas;
        }
 
        public List<Sepeda> GetAllSepedas()
        {
            return dummySepedas;
        }

        public Sepeda GetSepedaById(int? idSepeda)
        {
            return dummySepedas.SingleOrDefault(sepeda => sepeda.idSepeda == idSepeda);
        }

        public void AddSepeda(Sepeda sepeda)
        {
            dummySepedas.Add(sepeda);
        }

        public void UpdateSepeda(Sepeda sepeda)
        {
            int id = sepeda.idSepeda;
            Sepeda sepedaToUpdate = dummySepedas.SingleOrDefault(s => s.idSepeda == id);
            DeleteSepeda(sepedaToUpdate);
            dummySepedas.Add(sepeda);
        }

        public void DeleteSepeda(Sepeda sepeda)
        {
            dummySepedas.Remove(sepeda);
        }

        public void Save()
        {
            
        }
    }
}
