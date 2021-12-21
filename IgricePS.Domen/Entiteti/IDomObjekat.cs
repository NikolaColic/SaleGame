using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Entiteti
{
    public interface IDomObjekat
    {
        string VratiNazivTabele();
        string VratiNazivTabeleAnotacija();
        string Dodaj();
        string Izmeni();
        string Join();
        string Where();
        List<IDomObjekat> VratiObjekte(SqlDataReader reader);
    }
}
