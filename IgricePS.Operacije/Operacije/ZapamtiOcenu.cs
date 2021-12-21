using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;

namespace IgricePS.Operacije.Operacije
{
    public class ZapamtiOcenu : OpstaSistemskaOperacija
    {
        public List<OcenaIgrice> Lista { get; set; }

        public ZapamtiOcenu(List<OcenaIgrice> lista)
        {
            Lista = lista;
        }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            foreach (var ocena in Lista)
            {
                if (db.Vrati(objekat).OfType<OcenaIgrice>().Any((el) => el.Igrica.IdIgrice == ocena.Igrica.IdIgrice && ocena.NazivOcene == el.NazivOcene && ocena.Korisnik.IdKorisnika == el.Korisnik.IdKorisnika))
                {
                    throw new Exception("Vec ste uneli ocenu za datog korisnika i igricu za dati naziv ocene");
                }
                if (ocena.idOcene == 0) db.Dodaj(ocena);
                else db.Izmeni(ocena);
            }
        }
    }
}
