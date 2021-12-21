using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;
using IgricePS.Klijent.Transfer;
using IgricePS.Klijent.UI;

namespace IgricePS.Klijent.UIKontroleri
{
    public class PretragaOcenaIgriceKontroler
    {
        BindingList<OcenaIgrice> list;
        private static PretragaOcenaIgriceKontroler instance;
        private PretragaOcenaIgriceKontroler()
        {

        }
        public static PretragaOcenaIgriceKontroler Instance
        {
            get
            {
                if (instance is null) instance = new PretragaOcenaIgriceKontroler();
                return instance;
            }
        }

        internal void PripremiFormu(DataGridView dgvTabela)
        {
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajOcene, null);
            List<OcenaIgrice> lista = (List<OcenaIgrice>)o.Podaci;
            list = new BindingList<OcenaIgrice>(lista);
            PripremiTabelu(dgvTabela);
        }

        internal void Pretrazi(TextBox txtPretraga, DataGridView dgvTabela)
        {
            if (txtPretraga.Text == "")
            {
                MessageBox.Show("Morate uneti neki tekst");
                return;
            }
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.PretraziOcene, new KriterijumPretrage(txtPretraga.Text));
            if (o.Signal)
            {
                List<OcenaIgrice> lista = (List<OcenaIgrice>)o.Podaci;
                if (lista == null || !lista.Any())
                {
                    MessageBox.Show("Sistem ne moze da nadje ocene po zadatoj vrednosti!");
                }
                else
                {
                    MessageBox.Show("Sistem je nasao ocene po zadatoj vrednosti!");
                    list = new BindingList<OcenaIgrice>(lista);
                    PripremiTabelu(dgvTabela);
                }
            }
            else
            {
                MessageBox.Show("Sistem ne moze da nadje ocene po zadatoj vrednosti!");

            }
        }

       

        internal void Izmeni(DataGridView dgvTabela)
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
            KreiranjeOcenaIgriceUI ui = new KreiranjeOcenaIgriceUI(ocena);
            ui.ShowDialog();
            PripremiFormu(dgvTabela);
        }

        private void PripremiTabelu(DataGridView dgvTabela)
        {
            dgvTabela.DataSource = list;
        }
    }
}
