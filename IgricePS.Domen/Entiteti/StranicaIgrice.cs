using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Entiteti
{
    [Serializable]
    public class StranicaIgrice : IDomObjekat
    {
        public int IdIgrice { get; set; }
        public string NazivIgrice { get; set; }
        public string OpisIgrice { get; set; }
        public string TipIgrice { get; set; }
        public int GodinaIzdavanja { get; set; }
        public string PlatformaIgrice { get; set; }
        public Zanr Zanr { get; set; }
        public StranicaKompanije StranicaKompanije { get; set; }

        public StranicaIgrice()
        {
        }

        public override string ToString()
        {
            return NazivIgrice;
        }

        public StranicaIgrice(int idIgrice, string nazivIgrice, string opisIgrice, string tipIgrice, int godinaIzdavanja, string platformaIgrice, Zanr zanr, StranicaKompanije stranicaKompanije)
        {
            IdIgrice = idIgrice;
            NazivIgrice = nazivIgrice;
            OpisIgrice = opisIgrice;
            TipIgrice = tipIgrice;
            GodinaIzdavanja = godinaIzdavanja;
            PlatformaIgrice = platformaIgrice;
            Zanr = zanr;
            StranicaKompanije = stranicaKompanije;
        }

        public override bool Equals(object obj)
        {
            return obj is StranicaIgrice igrice &&
                   IdIgrice == igrice.IdIgrice &&
                   NazivIgrice == igrice.NazivIgrice &&
                   OpisIgrice == igrice.OpisIgrice &&
                   TipIgrice == igrice.TipIgrice &&
                   GodinaIzdavanja == igrice.GodinaIzdavanja &&
                   PlatformaIgrice == igrice.PlatformaIgrice &&
                   EqualityComparer<Zanr>.Default.Equals(Zanr, igrice.Zanr) &&
                   EqualityComparer<StranicaKompanije>.Default.Equals(StranicaKompanije, igrice.StranicaKompanije);
        }

        public override int GetHashCode()
        {
            int hashCode = -932375050;
            hashCode = hashCode * -1521134295 + IdIgrice.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NazivIgrice);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OpisIgrice);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TipIgrice);
            hashCode = hashCode * -1521134295 + GodinaIzdavanja.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PlatformaIgrice);
            hashCode = hashCode * -1521134295 + EqualityComparer<Zanr>.Default.GetHashCode(Zanr);
            hashCode = hashCode * -1521134295 + EqualityComparer<StranicaKompanije>.Default.GetHashCode(StranicaKompanije);
            return hashCode;
        }

        public string VratiNazivTabele()
        {
            return "StranicaIgrice";
        }

        public string VratiNazivTabeleAnotacija()
        {
            return "StranicaIgrice si";
        }

        public string Dodaj()
        {
            return $"'{NazivIgrice}','{OpisIgrice}','{TipIgrice}',{GodinaIzdavanja},'{PlatformaIgrice}',{Zanr.IdZanra},{StranicaKompanije.IdKompanije}";
        }

        public string Izmeni()
        {
            return $"nazivIgrice = '{NazivIgrice}',opisIgrice = '{OpisIgrice}',tipIgrice = '{TipIgrice}',godinaIzdavanja = {GodinaIzdavanja},platformaIgrice = '{PlatformaIgrice}',idZanra = {Zanr.IdZanra},idKompanije = {StranicaKompanije.IdKompanije}";

        }

        public string Join()
        {
            return "join Zanr z on (z.idZanra = si.idZanra) join StranicaKompanije sk on (sk.idKompanije = si.idKompanije)";
        }

        public string Where()
        {
            return $"idIgrice = {IdIgrice}";
        }

        public List<IDomObjekat> VratiObjekte(SqlDataReader reader)
        {
            List<IDomObjekat> lista = new List<IDomObjekat>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                string naziv = reader[1].ToString();
                string opis = reader[2].ToString();
                string tip = reader[3].ToString();
                int godina = Convert.ToInt32(reader[4]);
                string platforma = reader[5].ToString();

                int idKompanije = Convert.ToInt32(reader["idKompanije"]);
                string nazivKomp = reader["nazivKompanije"].ToString();
                StranicaKompanije sk = new StranicaKompanije(idKompanije, nazivKomp, "", "");

                int zanrId = Convert.ToInt32(reader["idZanra"]);
                string nazivZanra = reader["nazivZanra"].ToString();
                Zanr zanr = new Zanr(zanrId, nazivZanra, "");

                StranicaIgrice si = new StranicaIgrice(id, naziv, opis, tip, godina, platforma, zanr, sk);
                lista.Add(si);
            }
            reader.Close();
            return lista;
        }

    }
}
