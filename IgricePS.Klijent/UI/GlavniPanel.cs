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
    public partial class GlavniPanel : Form
    {
        public GlavniPanel()
        {
            InitializeComponent();
        }

        private void kreirajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KreirajStranicuIgricaUI ui = new KreirajStranicuIgricaUI(null);
            ui.ShowDialog();
        }

        private void pretraziIzmeniObrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PretragaIgricaUI ui = new PretragaIgricaUI();
            ui.ShowDialog();
        }

        private void kreirajToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            KreirajStranicuUI ui = new KreirajStranicuUI();
            ui.ShowDialog();
        }

        private void dodajOceneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KreiranjeOcenaIgriceUI ui = new KreiranjeOcenaIgriceUI(null);
            ui.ShowDialog();
        }

        private void pretragaIzmenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PretragaOcenaIgriceUI ui = new PretragaOcenaIgriceUI();
            ui.ShowDialog();
        }

        private void kreirajToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            KreirajZanrUI ui = new KreirajZanrUI();
            ui.ShowDialog();
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PretragaZanraUI ui = new PretragaZanraUI();
            ui.ShowDialog();
        }
    }
}
