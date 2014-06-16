using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMPEDA_V01.Models
{
    public interface ISepedasRepository
    {
        List<Sepeda> GetAllSepedas();
        Sepeda GetSepedaById(int? idSepeda);
        void AddSepeda(Sepeda sepeda);
        void UpdateSepeda(Sepeda sepeda);
        void DeleteSepeda(Sepeda sepeda);
        void Save();
    }
}
