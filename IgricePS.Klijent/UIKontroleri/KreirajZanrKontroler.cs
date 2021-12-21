using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;
using IgricePS.Klijent.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgricePS.Klijent.UIKontroleri
{
    public class KreirajZanrKontroler
    {
        private static KreirajZanrKontroler instance;
        private KreirajZanrKontroler()
        {

        }
        public static KreirajZanrKontroler Instance
        {
            get
            {
                if (instance is null) instance = new KreirajZanrKontroler();
                return instance;
            }
        }

        internal void Sacuvaj(TextBox txtNaziv, TextBox txtOpis)
        {
            Zanr zanr = Pokupi(txtNaziv,txtOpis);
            if (zanr == null) return;
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ZapamtiZanr, zanr);
            if (o.Signal)
            {
                MessageBox.Show("Sistem je zapamtio zanr");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti zanr");
            }
        }

        private Zanr Pokupi(TextBox txtNaziv, TextBox txtOpis)
        {
            try
            {
                string naziv = txtNaziv.Text;
                string opis = txtOpis.Text;
                if (naziv == "" || opis == "")
                {
                    MessageBox.Show("Morate popuniti sva polja. Prazan unos");
                    return null;
                }
                return new Zanr(0, naziv, opis);
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }
    }
}
