using IgricePS.BazaPodataka;
using IgricePS.Domen.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Operacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected BrokerBaze db = new BrokerBaze();

        protected abstract void OperacijaImplementacija(IDomObjekat objekat);
        public void IzvrsiSO(IDomObjekat objekat)
        {
            try
            {
                db.Konekcija();
                db.PokretanjeTranskacije();
                OperacijaImplementacija(objekat);
                db.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                db.RollBack();
                throw;
            }
            finally
            {
                db.KonkecijaZatvaranje();
            }
        }
    }
}
