using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Entiteti
{
    [Serializable]
    public class Korisnik : IDomObjekat
    {
        public int IdKorisnika { get; set; }
        public string KorisnickoIme { get; set; }

        public Korisnik()
        {
        }

        public Korisnik(int idKorisnika, string korisnickoIme)
        {
            IdKorisnika = idKorisnika;
            KorisnickoIme = korisnickoIme;
        }

        public override string ToString()
        {
            return KorisnickoIme;
        }

       

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Korisnik korisnik &&
                   IdKorisnika == korisnik.IdKorisnika &&
                   KorisnickoIme == korisnik.KorisnickoIme;
        }

        public string VratiNazivTabele()
        {
            return "Korisnik";
        }

        public string VratiNazivTabeleAnotacija()
        {
            return "Korisnik k";
        }

        public string Dodaj()
        {
            return $"'{KorisnickoIme}'";
        }

        public string Izmeni()
        {
            return $"korisnickoIme = '{KorisnickoIme}'";
        }

        public string Join()
        {
            return "";
        }

        public string Where()
        {
            return $"idKorisnika = {IdKorisnika}";
        }

        public List<IDomObjekat> VratiObjekte(SqlDataReader reader)
        {
            List<IDomObjekat> lista = new List<IDomObjekat>();
            while (reader.Read())
            {
                int idKorisnika = Convert.ToInt32(reader[0]);
                string korisnickoIme = reader[1].ToString();
                Korisnik k = new Korisnik(idKorisnika, korisnickoIme);
                lista.Add(k);
            }
            reader.Close();
            return lista;
        }
    }
}
