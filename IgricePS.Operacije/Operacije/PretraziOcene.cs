using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;

namespace IgricePS.Operacije.Operacije
{
    public class PretraziOcene : OpstaSistemskaOperacija
    {
        public List<OcenaIgrice> Lista { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            KriterijumPretrage kp = (KriterijumPretrage)objekat;
            string tekst = kp.Tekst.ToLower();
            Lista = db.Vrati(new OcenaIgrice())
                .OfType<OcenaIgrice>()
                .Where((ocena) => ocena.NazivOcene.ToLower().Contains(tekst) || ocena.OpisOcene.ToLower().Contains(tekst)
                || ocena.Korisnik.KorisnickoIme.ToLower().Contains(tekst) || ocena.Igrica.NazivIgrice.ToLower().Contains(tekst))
                .ToList();
        }
    }
}
