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
    public class KreirajStranicuKontroler
    {
        private static KreirajStranicuKontroler instance;
        private KreirajStranicuKontroler()
        {

        }
        public static KreirajStranicuKontroler Instance
        {
            get
            {
                if (instance is null) instance = new KreirajStranicuKontroler();
                return instance;
            }
        }

        internal void PripremiFormu(ComboBox cmbTip)
        {
            cmbTip.DataSource = new List<string>() { "tip1", "tip2", "tip3" };
        }

        internal void Sacuvaj(TextBox txtNaziv, TextBox txtOpis, ComboBox cmbTip)
        {
            StranicaKompanije kompanija = Pokupi(txtNaziv,txtOpis,cmbTip);
            if (kompanija == null) return;
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ZapamtiStranicuKompanije, kompanija);
            if (o.Signal)
            {
                MessageBox.Show("Sistem je zapamtio stranicu kompanije");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti stranicu kompanije");
            }
        }

        private StranicaKompanije Pokupi(TextBox txtNaziv, TextBox txtOpis, ComboBox cmbTip)
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
                string tip = cmbTip.SelectedItem.ToString();
                return new StranicaKompanije(0, naziv, opis, tip);
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }
    }
}
