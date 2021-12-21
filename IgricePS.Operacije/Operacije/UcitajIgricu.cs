using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgricePS.Domen.Entiteti;

namespace IgricePS.Operacije.Operacije
{
    public class UcitajIgricu : OpstaSistemskaOperacija
    {
        public StranicaIgrice Igrica { get; set; }
        protected override void OperacijaImplementacija(IDomObjekat objekat)
        {
            Igrica = db.Vrati(objekat).OfType<StranicaIgrice>()
                .SingleOrDefault((igrica) => ((StranicaIgrice)objekat).IdIgrice == igrica.IdIgrice);
        }
    }
}
