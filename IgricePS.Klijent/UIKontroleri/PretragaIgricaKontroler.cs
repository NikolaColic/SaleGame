using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;
using IgricePS.Klijent.Transfer;
using IgricePS.Klijent.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgricePS.Klijent.UIKontroleri
{
    public class PretragaIgricaKontroler
    {
        BindingList<StranicaIgrice> list;

        private static PretragaIgricaKontroler instance;
        private PretragaIgricaKontroler()
        {

        }
        public static PretragaIgricaKontroler Instance
        {
            get
            {
                if (instance is null) instance = new PretragaIgricaKontroler();
                return instance;
            }
        }

        internal void PripremiFormu(DataGridView dgvTabela)
        {
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajIgrice, null);
            List<StranicaIgrice> lista = (List<StranicaIgrice>)o.Podaci;
            list = new BindingList<StranicaIgrice>(lista);
            PripremiTabelu(dgvTabela);
        }

        internal void Pretrazi(TextBox txtPretraga, DataGridView dgvTabela)
        {
            if (txtPretraga.Text == "")
            {
                MessageBox.Show("Morate uneti neki tekst");
                return;
            }
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.PretraziIgrice, new KriterijumPretrage(txtPretraga.Text));
            if (o.Signal)
            {
                List<StranicaIgrice> lista = (List<StranicaIgrice>)o.Podaci;
                if (lista == null || !lista.Any())
                {
                    MessageBox.Show("Sistem ne moze da nadje igrice po zadatoj vrednosti!");
                }
                else
                {
                    MessageBox.Show("Sistem je nasao igrice po zadatoj vrednosti!");
                    list = new BindingList<StranicaIgrice>(lista);
                    PripremiTabelu(dgvTabela);
                }
            }
            else
            {
                MessageBox.Show("Sistem ne moze da nadje igrice po zadatoj vrednosti!");

            }
        }

        internal void Obrisi(DataGridView dgvTabela)
        {
            StranicaIgrice igrica = null;
            try
            {
                igrica = (StranicaIgrice)dgvTabela.SelectedRows[0].DataBoundItem;

            }
            catch (Exception)
            {
                MessageBox.Show("Morate selektovati red");
                return;
            }
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.ObrisiStranicu, igrica);
            if (o.Signal)
            {
                MessageBox.Show("Sistem je obrisao stranicu igrice!");
                PripremiFormu(dgvTabela);
            }
            else
            {
                MessageBox.Show("Sistem ne moze da obrise stranicu igrice!");
            }
        }

        internal void Izmeni(DataGridView dgvTabela)
        {
            StranicaIgrice igrica;
            try
            {
                igrica = (StranicaIgrice)dgvTabela.SelectedRows[0].DataBoundItem;

            }
            catch (Exception)
            {
                MessageBox.Show("Morate selektovati red");
                return;
            }
            KreirajStranicuIgricaUI ui = new KreirajStranicuIgricaUI(igrica);
            ui.ShowDialog();
            PripremiFormu(dgvTabela);
        }

        private void PripremiTabelu(DataGridView dgvTabela)
        {
            dgvTabela.DataSource = list;
        }
    }
}
