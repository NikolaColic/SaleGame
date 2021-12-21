using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;
using IgricePS.Operacije;
using IgricePS.Operacije.Operacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgricePS.Server.KontrolerAplikacioneLogike
{
    public class Kontroler
    {
        private static Kontroler instance;
        private Kontroler()
        {

        }
        public static Kontroler Instance
        {
            get
            {
                if (instance is null) instance = new Kontroler();
                return instance;
            }
        }

        internal Odgovor GetResponse(Zahtev zahtev)
        {
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.ObrisiStranicu: return ObrisiStranicu((StranicaIgrice)zahtev.Podaci);
                    case Operacija.PretraziIgrice: return PretraziIgrice((KriterijumPretrage)zahtev.Podaci);
                    case Operacija.PretraziOcene: return PretraziOcene((KriterijumPretrage)zahtev.Podaci);
                    case Operacija.PretraziZanrove: return PretraziZanrove((KriterijumPretrage)zahtev.Podaci);
                    case Operacija.UcitajIgrice: return UcitajIgrice();
                    case Operacija.UcitajIgricu: return UcitajIgricu((StranicaIgrice)zahtev.Podaci);
                    case Operacija.UcitajKorisnike: return UcitajKorisnike((Korisnik)zahtev.Podaci);
                    case Operacija.UcitajOcene: return UcitajOcene();
                    case Operacija.UcitajZanrove: return UcitajZanrove();
                    case Operacija.UcitajKompanije: return UcitajKompanije();
                    case Operacija.ZapamtiOcenu: return ZapamtiOcenu((List<OcenaIgrice>)zahtev.Podaci);
                    case Operacija.ZapamtiStranicuIgrice: return ZapamtiStranicuIgrice((StranicaIgrice)zahtev.Podaci);
                    case Operacija.ZapamtiStranicuKompanije: return ZapamtiStranicuKompanije((StranicaKompanije)zahtev.Podaci);
                    case Operacija.ZapamtiZanr: return ZapamtiZanr((Zanr)zahtev.Podaci);
         
                    default: return new Odgovor(false, null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Odgovor(false, null);
            }
        }

        private Odgovor ZapamtiZanr(Zanr podaci)
        {
            OpstaSistemskaOperacija operacija = new ZapamtiZanr();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, "");
        }

        private Odgovor ZapamtiStranicuKompanije(StranicaKompanije podaci)
        {
            OpstaSistemskaOperacija operacija = new ZapamtiStranicuKompanije();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, "");
        }

        private Odgovor ZapamtiStranicuIgrice(StranicaIgrice podaci)
        {
            OpstaSistemskaOperacija operacija = new ZapamtiStranicuIgrice();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, "");
        }

        private Odgovor ZapamtiOcenu(List<OcenaIgrice> podaci)
        {
            OpstaSistemskaOperacija operacija = new ZapamtiOcenu(podaci);
            operacija.IzvrsiSO(new OcenaIgrice());
            return new Odgovor(true, "");
        }

        private Odgovor UcitajKompanije()
        {
            OpstaSistemskaOperacija operacija = new UcitajKompanije();
            operacija.IzvrsiSO(new StranicaKompanije());
            return new Odgovor(true, ((UcitajKompanije)operacija).Lista);
        }

        private Odgovor UcitajZanrove()
        {
            OpstaSistemskaOperacija operacija = new UcitajZanrove();
            operacija.IzvrsiSO(new Zanr());
            return new Odgovor(true, ((UcitajZanrove)operacija).Lista);
        }

        private Odgovor UcitajOcene()
        {
            OpstaSistemskaOperacija operacija = new UcitajOcene();
            operacija.IzvrsiSO(new OcenaIgrice());
            return new Odgovor(true, ((UcitajOcene)operacija).Lista);
        }

        private Odgovor UcitajKorisnike(Korisnik podaci)
        {
            OpstaSistemskaOperacija operacija = new UcitajKorisnike();
            operacija.IzvrsiSO(new Korisnik());
            return new Odgovor(true, ((UcitajKorisnike)operacija).Lista);
        }

        private Odgovor UcitajIgrice()
        {
            OpstaSistemskaOperacija operacija = new UcitajIgrice();
            operacija.IzvrsiSO(new StranicaIgrice());
            return new Odgovor(true, ((UcitajIgrice)operacija).Lista);
        }

        private Odgovor UcitajIgricu(StranicaIgrice podaci)
        {
            OpstaSistemskaOperacija operacija = new UcitajIgricu();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, ((UcitajIgricu)operacija).Igrica);
        }

        private Odgovor PretraziZanrove(KriterijumPretrage podaci)
        {
            OpstaSistemskaOperacija operacija = new PretraziZanrove();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, ((PretraziZanrove)operacija).Lista);
        }

        private Odgovor PretraziOcene(KriterijumPretrage podaci)
        {
            OpstaSistemskaOperacija operacija = new PretraziOcene();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, ((PretraziOcene)operacija).Lista);
        }

        private Odgovor PretraziIgrice(KriterijumPretrage podaci)
        {
            OpstaSistemskaOperacija operacija = new PretraziIgrice();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, ((PretraziIgrice)operacija).Lista);
        }

        private Odgovor ObrisiStranicu(StranicaIgrice podaci)
        {
            OpstaSistemskaOperacija operacija = new ObrisiStranicu();
            operacija.IzvrsiSO(podaci);
            return new Odgovor(true, "");
        }
    }
}
