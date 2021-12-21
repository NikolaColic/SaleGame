using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;

namespace IgricePS.Operacije.Operacije
{
    public class UcitajIgrice : OpstaSistemskaOperacija
    {
        public List<StranicaIgrice> Lista { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            Lista = db.Vrati(objekat).OfType<StranicaIgrice>().ToList();

        }
    }
}
