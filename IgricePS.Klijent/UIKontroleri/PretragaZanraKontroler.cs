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
    public class PretragaZanraKontroler
    {
        BindingList<Zanr> list;
        private static PretragaZanraKontroler instance;
        private PretragaZanraKontroler()
        {

        }
        public static PretragaZanraKontroler Instance
        {
            get
            {
                if (instance is null) instance = new PretragaZanraKontroler();
                return instance;
            }
        }

        internal void PripremiFormu(DataGridView dgvTabela)
        {
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.UcitajZanrove, null);
            List<Zanr> lista = (List<Zanr>)o.Podaci;
            list = new BindingList<Zanr>(lista);
            PripremiTabelu(dgvTabela);
        }

        internal void Pretrazi(TextBox txtPretraga, DataGridView dgvTabela)
        {
            if (txtPretraga.Text == "")
            {
                MessageBox.Show("Morate uneti neki tekst");
                return;
            }
            Odgovor o = Komunikacija.Instance.GenerickiZahtevOdgovor(Operacija.PretraziZanrove, new KriterijumPretrage(txtPretraga.Text));
            if (o.Signal)
            {
                List<Zanr> lista = (List<Zanr>)o.Podaci;
                if (lista == null || !lista.Any())
                {
                    MessageBox.Show("Sistem ne moze da nadje zanrove po zadatoj vrednosti!");
                }
                else
                {
                    MessageBox.Show("Sistem je nasao zanrove po zadatoj vrednosti!");

                    list = new BindingList<Zanr>(lista);
                    PripremiTabelu(dgvTabela);
                }
            }
            else
            {
                MessageBox.Show("Sistem ne moze da nadje zanrove po zadatoj vrednosti!");
            }
        }

        private void PripremiTabelu(DataGridView dgvTabela)
        {
            dgvTabela.DataSource = list;
        }
    }
}
