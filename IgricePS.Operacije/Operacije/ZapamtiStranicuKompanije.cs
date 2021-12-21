using IgricePS.Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Operacije.Operacije
{
    public class ZapamtiStranicuKompanije : OpstaSistemskaOperacija
    {
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            StranicaKompanije komp = (StranicaKompanije)objekat;
            if (db.Vrati(objekat).OfType<StranicaKompanije>().Any((el) => el.NazivKompanije.ToLower() == komp.NazivKompanije.ToLower()))
            {
                throw new Exception("Vec postoji data kompanija");
            }
            db.Dodaj((StranicaKompanije)objekat);
        }
    }
}
