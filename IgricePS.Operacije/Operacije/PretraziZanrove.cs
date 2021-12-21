using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;

namespace IgricePS.Operacije.Operacije
{
    public class PretraziZanrove : OpstaSistemskaOperacija
    {
        public List<Zanr> Lista { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            KriterijumPretrage kp = (KriterijumPretrage)objekat;
            Lista = db.Vrati(new Zanr()).OfType<Zanr>()
                .Where((zanr) => zanr.NazivZanra.ToLower().Contains(kp.Tekst.ToLower()) || zanr.OpisZanra.ToLower().Contains(kp.Tekst.ToLower()))
                .ToList();
        }
    }
}
