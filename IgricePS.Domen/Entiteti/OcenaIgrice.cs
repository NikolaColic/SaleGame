using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Entiteti
{
    [Serializable]
    public class OcenaIgrice : IDomObjekat
    {
        public int idOcene { get; set; }
        public StranicaIgrice Igrica { get; set; }
        public string NazivOcene { get; set; }
        public string OpisOcene { get; set; }
        public Korisnik Korisnik { get; set; }

        public OcenaIgrice()
        {
        }

        public OcenaIgrice(int idOcene, StranicaIgrice igrica, string nazivOcene, string opisOcene, Korisnik korisnik)
        {
            this.idOcene = idOcene;
            Igrica = igrica;
            NazivOcene = nazivOcene;
            OpisOcene = opisOcene;
            Korisnik = korisnik;
        }

        public override bool Equals(object obj)
        {
            return obj is OcenaIgrice igrice &&
                   idOcene == igrice.idOcene &&
                   EqualityComparer<StranicaIgrice>.Default.Equals(Igrica, igrice.Igrica) &&
                   NazivOcene == igrice.NazivOcene &&
                   OpisOcene == igrice.OpisOcene &&
                   Korisnik == igrice.Korisnik;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string VratiNazivTabele()
        {
            return "OcenaIgrice";
        }

        public string VratiNazivTabeleAnotacija()
        {
            return "OcenaIgrice oi";
        }

        public string Dodaj()
        {
            return $"{Igrica.IdIgrice},'{NazivOcene}','{OpisOcene}',{Korisnik.IdKorisnika}";
        }

        public string Izmeni()
        {
            return $"idIgrice = {Igrica.IdIgrice},nazivOcene = '{NazivOcene}',opisOcene = '{OpisOcene}',idKorisnika = {Korisnik.IdKorisnika}";

        }

        public string Join()
        {
            return "join StranicaIgrice i on (i.idIgrice = oi.idIgrice) join Korisnik k on (k.idKorisnika = oi.idKorisnika)";
        }

        public string Where()
        {
            return $"idIgrice = {Igrica.IdIgrice}";
        }

        public List<IDomObjekat> VratiObjekte(SqlDataReader reader)
        {
            List<IDomObjekat> lista = new List<IDomObjekat>();
            while (reader.Read())
            {
                int idIgrice = Convert.ToInt32(reader["idIgrice"]);
                string naziv = reader["nazivIgrice"].ToString();
                string nazivOcene = reader[2].ToString();
                string opisOcene = reader[3].ToString();

                int idOcene = Convert.ToInt32(reader[0]);

                int idKorisnika = Convert.ToInt32(reader["idKorisnika"]);
                string korisnickoIme = reader["korisnickoIme"].ToString();
                Korisnik k = new Korisnik(idKorisnika, korisnickoIme);
                StranicaIgrice si = new StranicaIgrice(idIgrice, naziv, "", "", 0, "", null, null);

                OcenaIgrice oi = new OcenaIgrice(idOcene, si, nazivOcene, opisOcene, k);
                lista.Add(oi);
            }
            reader.Close();
            return lista;
        }
    }
}
