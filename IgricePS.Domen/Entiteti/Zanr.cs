using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Entiteti
{
    [Serializable]
    public class Zanr : IDomObjekat
    {
        public int IdZanra { get; set; }
        public string NazivZanra { get; set; }
        public string OpisZanra { get; set; }

        public Zanr()
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Zanr(int idZanra, string nazivZanra, string opisZanra)
        {
            IdZanra = idZanra;
            NazivZanra = nazivZanra;
            OpisZanra = opisZanra;
        }

        public override string ToString()
        {
            return NazivZanra;
        }

        public override bool Equals(object obj)
        {
            return obj is Zanr zanr &&
                   IdZanra == zanr.IdZanra &&
                   NazivZanra == zanr.NazivZanra &&
                   OpisZanra == zanr.OpisZanra;
        }

        public string VratiNazivTabele()
        {
            return "Zanr";
        }

        public string VratiNazivTabeleAnotacija()
        {
            return "Zanr z";
        }

        public string Dodaj()
        {
            return $"'{NazivZanra}','{OpisZanra}'";
        }

        public string Izmeni()
        {
            return $"nazivZanra = '{NazivZanra}', opisZanra = '{OpisZanra}'";
        }

        public string Join()
        {
            return "";
        }

        public string Where()
        {
            return $"idZanra = {IdZanra}";
        }

        public List<IDomObjekat> VratiObjekte(SqlDataReader reader)
        {
            List<IDomObjekat> lista = new List<IDomObjekat>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                string naziv = reader[1].ToString();
                string opis = reader[2].ToString();
                Zanr zanr = new Zanr(id, naziv, opis);
                lista.Add(zanr);
            }
            reader.Close();
            return lista;
        }

    }
}
