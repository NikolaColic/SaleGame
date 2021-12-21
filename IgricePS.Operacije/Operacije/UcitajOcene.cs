using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;

namespace IgricePS.Operacije.Operacije
{
    public class UcitajOcene : OpstaSistemskaOperacija
    {
        public List<OcenaIgrice> Lista { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            Lista = db.Vrati(objekat).OfType<OcenaIgrice>().ToList();
        }
    }
}
