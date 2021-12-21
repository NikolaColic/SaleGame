using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Entiteti
{
    [Serializable]
    public class StranicaKompanije : IDomObjekat
    {
        public int IdKompanije { get; set; }
        public string NazivKompanije { get; set; }
        public string LokacijaKompanije { get; set; }
        public string TipKompanije { get; set; }

        public StranicaKompanije(int idKompanije, string nazivKompanije, string lokacijaKompanije, string tipKompanije)
        {
            IdKompanije = idKompanije;
            NazivKompanije = nazivKompanije;
            LokacijaKompanije = lokacijaKompanije;
            TipKompanije = tipKompanije;
        }

        public override bool Equals(object obj)
        {
            return obj is StranicaKompanije kompanije &&
                   IdKompanije == kompanije.IdKompanije &&
                   NazivKompanije == kompanije.NazivKompanije &&
                   LokacijaKompanije == kompanije.LokacijaKompanije &&
                   TipKompanije == kompanije.TipKompanije;
        }

        public override string ToString()
        {
            return NazivKompanije;
        }

        public StranicaKompanije()
        {
        }

        public string VratiNazivTabele()
        {
            return "StranicaKompanije";
        }

        public string VratiNazivTabeleAnotacija()
        {
            return "StranicaKompanije sk";
        }

        public string Dodaj()
        {
            return $"'{NazivKompanije}','{LokacijaKompanije}','{TipKompanije}'";
        }

        public string Izmeni()
        {
            return $"nazivKompanije = '{NazivKompanije}', lokacijaKompanije = '{LokacijaKompanije}',tipKompanije  = '{TipKompanije}'";
        }

        public string Join()
        {
            return "";
        }

        public string Where()
        {
            return $"izKompanije  = {IdKompanije}";
        }

        public List<IDomObjekat> VratiObjekte(SqlDataReader reader)
        {
            List<IDomObjekat> lista = new List<IDomObjekat>();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                string naziv = reader[1].ToString();
                string lokacija = reader[2].ToString();
                string tip = reader[3].ToString();
                StranicaKompanije sk = new StranicaKompanije(id, naziv, lokacija, tip);
                lista.Add(sk);
            }
            reader.Close();
            return lista;
        }

    }
}
