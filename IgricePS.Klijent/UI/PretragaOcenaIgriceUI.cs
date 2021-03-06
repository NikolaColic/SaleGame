using IgricePS.Domen.Entiteti;
using IgricePS.Domen.Korisno;
using IgricePS.Klijent.Transfer;
using IgricePS.Klijent.UIKontroleri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgricePS.Klijent.UI
{
    
    public partial class PretragaOcenaIgriceUI : Form
    {
        public PretragaOcenaIgriceUI()
        {
            InitializeComponent();
            PripremiFormu();
        }

        private void PripremiFormu()
        {
            PretragaOcenaIgriceKontroler.Instance.PripremiFormu(dgvTabela);

        }
        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            PretragaOcenaIgriceKontroler.Instance.Pretrazi(txtPretraga, dgvTabela);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            PripremiFormu();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            PretragaOcenaIgriceKontroler.Instance.Izmeni(dgvTabela);
        }
    }
}
