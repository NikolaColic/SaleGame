using IgricePS.Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Korisno
{
    [Serializable]
    public class KriterijumPretrage : IDomObjekat
    {
        public string Tekst { get; set; }

        public KriterijumPretrage(string tekst)
        {
            Tekst = tekst;
        }

        public string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabeleAnotacija()
        {
            throw new NotImplementedException();
        }

        public string Dodaj()
        {
            throw new NotImplementedException();
        }

        public string Izmeni()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            throw new NotImplementedException();
        }

        public string Where()
        {
            throw new NotImplementedException();
        }

        public List<IDomObjekat> VratiObjekte(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
