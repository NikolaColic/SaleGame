using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;

namespace IgricePS.Operacije.Operacije
{
    public class ZapamtiStranicuIgrice : OpstaSistemskaOperacija
    {

        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            StranicaIgrice si = (StranicaIgrice)objekat;
            if (db.Vrati(objekat).OfType<StranicaIgrice>().Any((el) => el.NazivIgrice.ToLower() == si.NazivIgrice.ToLower() && el.IdIgrice != si.IdIgrice))
            {
                throw new Exception("Vec postoji dati naziv igrice");
            }
            if (si.IdIgrice >0)
            {
                db.Izmeni(si);
            }
            else
            {
                db.Dodaj(si);
            }
        }
    }
}
