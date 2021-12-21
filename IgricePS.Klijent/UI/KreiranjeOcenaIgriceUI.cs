using IgricePS.Domen.Entiteti;
using IgricePS.Klijent.UIKontroleri;
using System;
using System.Windows.Forms;

namespace IgricePS.Klijent.UI
{
    public partial class KreiranjeOcenaIgriceUI : Form
    {
        OcenaIgrice ocenaIzmena;
        public KreiranjeOcenaIgriceUI(OcenaIgrice ocena)
        {
            InitializeComponent();
            PripremiFormu();

            if (ocena == null)
            {
                btnSacuvaj.Visible = true;
                button1.Visible = false;
                btnDodaj.Visible = true;
                btnObrisi.Visible = true;
                dgvTabela.Enabled = true;
            }
            else
            {
                btnDodaj.Visible = false;
                btnObrisi.Visible = false;
                btnSacuvaj.Visible = false;
                dgvTabela.Enabled = false;
                button1.Visible = true;
                ocenaIzmena = ocena;
                txtOpis.Text = ocena.OpisOcene;
                cmbIgrica.SelectedItem = ocena.Igrica;
                cmbKorisnik.SelectedItem = ocena.Korisnik;
                cmbNazivOcene.SelectedItem = ocena.NazivOcene;
            }
        }

        private void PripremiFormu()
        {
            KreirajOcenaIgriceKontroler.Instance.PripremiFormu(cmbKorisnik,cmbNazivOcene,cmbIgrica,dgvTabela);
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            KreirajOcenaIgriceKontroler.Instance.Sacuvaj();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KreirajOcenaIgriceKontroler.Instance.Izmeni(cmbNazivOcene, txtOpis, cmbKorisnik, cmbIgrica, ocenaIzmena);
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            KreirajOcenaIgriceKontroler.Instance.Dodaj(cmbNazivOcene,txtOpis,cmbKorisnik,cmbIgrica,dgvTabela);
            
        }
       
        private void btnObrisi_Click(object sender, EventArgs e)
        {
            KreirajOcenaIgriceKontroler.Instance.Obrisi(dgvTabela);
        }
    }
}
