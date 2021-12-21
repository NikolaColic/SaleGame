using IgricePS.Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Operacije.Operacije
{
    public class ObrisiStranicu : OpstaSistemskaOperacija
    {
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            StranicaIgrice si = (StranicaIgrice)objekat;
            OcenaIgrice oi = new OcenaIgrice();
            oi.Igrica = si;
            db.Obrisi(oi);
            db.Obrisi(si);
        }
    }
}
