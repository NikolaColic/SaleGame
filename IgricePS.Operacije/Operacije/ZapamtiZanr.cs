using IgricePS.Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Operacije.Operacije
{
    public class ZapamtiZanr : OpstaSistemskaOperacija
    {
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            Zanr z = (Zanr)objekat;
            if(db.Vrati(objekat).OfType<Zanr>().Any((el)=> el.NazivZanra.ToLower() ==z.NazivZanra.ToLower() ))
            {
                throw new Exception("Vec postoji dati zanr");
            }
            db.Dodaj((Zanr)objekat);
        }
    }
}
