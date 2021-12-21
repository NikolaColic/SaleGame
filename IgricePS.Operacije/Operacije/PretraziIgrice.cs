using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;

namespace IgricePS.Operacije.Operacije
{
    public class PretraziIgrice : OpstaSistemskaOperacija
    {
        public List<StranicaIgrice> Lista { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            KriterijumPretrage kp = (KriterijumPretrage)objekat;
            string tekst = kp.Tekst.ToLower();
            Lista = db.Vrati(new StranicaIgrice()).OfType<StranicaIgrice>()
                .Where((igrica) => igrica.NazivIgrice.ToLower().Contains(tekst) || igrica.OpisIgrice.ToLower().Contains(tekst) ||
                igrica.PlatformaIgrice.ToLower().Contains(tekst) || igrica.TipIgrice.ToLower().Contains(tekst) ||
                igrica.Zanr.NazivZanra.ToLower().Contains(tekst) || igrica.StranicaKompanije.NazivKompanije.ToLower().Contains(tekst) )
                .ToList();
        }
    }
}
