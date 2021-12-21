using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;

namespace IgricePS.Operacije.Operacije
{
    public class UcitajZanrove : OpstaSistemskaOperacija
    {
        public List<Zanr> Lista { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            Lista = db.Vrati(objekat).OfType<Zanr>().ToList();
        }
    }
}
