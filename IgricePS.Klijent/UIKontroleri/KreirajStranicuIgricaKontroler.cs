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
    public class KreirajStranicuIgricaKontroler
    {
        private static KreirajStranicuIgricaKontroler instance;
        private KreirajStranicuIgricaKontroler()
        {

        }
        public static KreirajStranicuIgricaKontroler Instance
        {
            get
            {
                if (instance is null) instance = new KreirajStranicuIgricaKontroler();
                return instance;
            }
        }

        internal void PripremiFormu(ComboBox cmbZanr, ComboBox cmbKompanija, ComboBox cmbTip)
        {
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajZanrove, null);
            cmbZanr.DataSource = (List<Zanr>)o.Podaci;
            o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajKompanije, null);
            cmbKompanija.DataSource = (List<StranicaKompanije>)o.Podaci;
            cmbTip.DataSource = new List<string>() { "arkanda", "sportska", "zenska", "opustena" };
        }

        internal void Sacuvaj(TextBox txtNaziv, TextBox txtOpis, ComboBox cmbTip,
            TextBox txtPlatforma, TextBox txtGodina, ComboBox cmbKompanija, ComboBox cmbZanr, StranicaIgrice igricaIzmena)
        {
            StranicaIgrice si = Pokupi(false,txtNaziv,txtOpis,cmbTip,
                                        txtPlatforma, txtGodina,cmbKompanija,cmbZanr,igricaIzmena);
            if (si == null) return;
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ZapamtiStranicuIgrice, si);
            if (o.Signal)
            {
                MessageBox.Show("Sistem je zapamtio stranicu za igricu");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti stranicu za igricu");
            }
        }

        internal void Izmeni(TextBox txtNaziv, TextBox txtOpis, ComboBox cmbTip,
            TextBox txtPlatforma, TextBox txtGodina, ComboBox cmbKompanija, ComboBox cmbZanr, StranicaIgrice igricaIzmena)
        {
            StranicaIgrice si = Pokupi(true, txtNaziv, txtOpis, cmbTip,
                                        txtPlatforma, txtGodina, cmbKompanija, cmbZanr, igricaIzmena);
            if (si == null) return;
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ZapamtiStranicuIgrice, si);
            if (o.Signal)
            {
                MessageBox.Show("Sistem je zapamtio stranicu igrice!");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti stranicu igrice!");
            }
        }

        private StranicaIgrice Pokupi(bool isUpdate, TextBox txtNaziv, TextBox txtOpis, ComboBox cmbTip,
            TextBox txtPlatforma, TextBox txtGodina, ComboBox cmbKompanija, ComboBox cmbZanr, StranicaIgrice igricaIzmena)
        {
            try
            {
                string naziv = txtNaziv.Text;
                string opis = txtOpis.Text;
                string tip = cmbTip.SelectedItem.ToString();
                string platforma = txtPlatforma.Text;
                if (naziv == "" || opis == "" || platforma == "" || txtGodina.Text == "")
                {
                    MessageBox.Show("Morate popuniti sva polja. Prazan unos");
                    return null;
                }
                int godina = Convert.ToInt32(txtGodina.Text);
                if (godina < 1950 || godina > 2021)
                {
                    MessageBox.Show("Godina mora biti u razmaku od 1950 do 2021");
                    return null;
                }
                StranicaKompanije komp = (StranicaKompanije)cmbKompanija.SelectedItem;
                Zanr zanr = (Zanr)cmbZanr.SelectedItem;
                int id = isUpdate ? igricaIzmena.IdIgrice : 0;
                return new StranicaIgrice(id, naziv, opis, tip, godina, platforma, zanr, komp);
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }
    }
}
