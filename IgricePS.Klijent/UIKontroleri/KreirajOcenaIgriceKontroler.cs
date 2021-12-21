using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;
using IgricePS.Klijent.Transfer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgricePS.Klijent.UIKontroleri
{
    public class KreirajOcenaIgriceKontroler
    {
        private static KreirajOcenaIgriceKontroler instance;
        BindingList<OcenaIgrice> list;
        
        private KreirajOcenaIgriceKontroler()
        {

        }
        public static KreirajOcenaIgriceKontroler Instance
        {
            get
            {
                if (instance is null) instance = new KreirajOcenaIgriceKontroler();
                return instance;
            }
        }

        internal void PripremiFormu(ComboBox cmbKorisnik, ComboBox cmbNazivOcene, ComboBox cmbIgrica, DataGridView dgvTabela)
        {
            list = new BindingList<OcenaIgrice>();
            PripremiTabelu(dgvTabela);
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajKorisnike, null);
            cmbKorisnik.DataSource = (List<Korisnik>)o.Podaci;

            cmbNazivOcene.DataSource = new List<string>() { "Grafika", "Zanimljivost", "Likovi", "Upgrade" };
            o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajIgrice, null);
            cmbIgrica.DataSource = (List<StranicaIgrice>)o.Podaci;
        }

        private void PripremiTabelu(DataGridView dgvTabela)
        {
            dgvTabela.DataSource = list;
        }

        internal void Sacuvaj()
        {
            if (list.Count == 0)
            {
                MessageBox.Show("Morate uneti neku ocenu");
                return;
            }
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ZapamtiOcenu, list.ToList());
            if (o.Signal)
            {
                MessageBox.Show("Sistem je zapamtio ocene!");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti ocene");
            }
        }

        internal void Izmeni(ComboBox cmbNazivOcene, TextBox txtOpis, ComboBox cmbKorisnik, ComboBox cmbIgrica, OcenaIgrice ocenaIgrice)
        {
            OcenaIgrice si = Pokupi(true, cmbNazivOcene, txtOpis, cmbKorisnik, cmbIgrica, ocenaIgrice);
            List<OcenaIgrice> izmena = new List<OcenaIgrice>() { si };
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ZapamtiOcenu, izmena);
            if (o.Signal)
            {
                MessageBox.Show("Sistem je zapamtio stranicu igrice!");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti stranicu igrice!");
            }
        }

        private OcenaIgrice Pokupi(bool isUpdate, ComboBox cmbNazivOcene, TextBox txtOpis, ComboBox cmbKorisnik, ComboBox cmbIgrica, OcenaIgrice ocenaIzmena)
        {
            try
            {
                string naziv = cmbNazivOcene.SelectedItem.ToString();
                string opis = txtOpis.Text;
                if (opis == "")
                {
                    MessageBox.Show("Niste uneli opis ocene");
                    return null;
                }
                int id = isUpdate ? ocenaIzmena.idOcene : 0;
                StranicaIgrice igrica = (StranicaIgrice)cmbIgrica.SelectedItem;
                Korisnik korisnik = (Korisnik)cmbKorisnik.SelectedItem;

                if (list.Any((el) => el.Igrica.IdIgrice == igrica.IdIgrice && naziv == el.NazivOcene && korisnik.IdKorisnika == el.Korisnik.IdKorisnika))
                {
                    MessageBox.Show("Vec ste uneli ocenu za datog korisnika i igricu za dati naziv ocene");
                    return null;
                }
                return new OcenaIgrice(id, igrica, naziv, opis, korisnik);
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresan unos");
                return null;
            }
        }

        internal void Dodaj(ComboBox cmbNazivOcene, TextBox txtOpis, ComboBox cmbKorisnik, ComboBox cmbIgrica, DataGridView dgvTabela)
        {
            OcenaIgrice si = Pokupi(true, cmbNazivOcene, txtOpis, cmbKorisnik, cmbIgrica, null);
            if (si == null) return;
            list.Add(si);
            PripremiTabelu(dgvTabela);
        }

        internal void Obrisi(DataGridView dgvTabela)
        {
            OcenaIgrice ocena;
            try
            {
                ocena = (OcenaIgrice)dgvTabela.SelectedRows[0].DataBoundItem;

            }
            catch (Exception)
            {
                MessageBox.Show("Morate selektovati red");
                return;
            }
            list.Remove(ocena);
            PripremiTabelu(dgvTabela);
        }
    }
}
