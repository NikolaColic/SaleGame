using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Domen.Korisno
{
    [Serializable]
    public class Zahtev
    {
        public Operacija Operacija { get; set; }
        public object Podaci { get; set; }

        public Zahtev(Operacija operacija, object podaci)
        {
            Operacija = operacija;
            Podaci = podaci;
        }

        
    }
    public enum Operacija
    {
        ObrisiStranicu,
        PretraziIgrice,
        PretraziOcene,
        PretraziZanrove,
        UcitajIgrice,
        UcitajIgricu,
        UcitajKorisnike,
        UcitajOcene,
        UcitajZanrove,
        UcitajKompanije,
        ZapamtiOcenu,
        ZapamtiStranicuIgrice,
        ZapamtiStranicuKompanije,
        ZapamtiZanr
    }
}
