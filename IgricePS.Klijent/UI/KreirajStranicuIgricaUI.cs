using IgricePS.Domen.Entiteti;
using IgricePS.Klijent.UIKontroleri;
using System;
using System.Windows.Forms;

namespace IgricePS.Klijent.UI
{
    public partial class KreirajStranicuIgricaUI : Form
    {
        StranicaIgrice igricaIzmena;
        public KreirajStranicuIgricaUI(StranicaIgrice igrica)
        {
            InitializeComponent();
            PripremiFormu();
            if(igrica == null)
            {
                btnSacuvaj.Visible = true;
                button1.Visible = false;
            }
            else
            {
                btnSacuvaj.Visible = false;
                button1.Visible = true;
                igricaIzmena = igrica;
                txtNaziv.Text = igrica.NazivIgrice;
                txtOpis.Text = igrica.OpisIgrice;
                txtGodina.Text = igrica.GodinaIzdavanja.ToString();
                txtPlatforma.Text = igrica.PlatformaIgrice;
                cmbZanr.SelectedItem = igrica.Zanr;
                cmbKompanija.SelectedItem = igrica.StranicaKompanije;
                cmbTip.SelectedItem = igrica.TipIgrice;
            }
        }

        private void PripremiFormu()
        {
            KreirajStranicuIgricaKontroler.Instance.PripremiFormu(cmbZanr,cmbKompanija,cmbTip);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            KreirajStranicuIgricaKontroler.Instance.Sacuvaj(txtNaziv,txtOpis,cmbTip,txtPlatforma,txtGodina,cmbKompanija,cmbZanr,null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KreirajStranicuIgricaKontroler.Instance.Izmeni(txtNaziv, txtOpis, cmbTip, txtPlatforma, txtGodina, cmbKompanija, cmbZanr, igricaIzmena);
            
        }
    }
}
