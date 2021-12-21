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
    public partial class KreirajZanrUI : Form
    {
        public KreirajZanrUI()
        {
            InitializeComponent();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            KreirajZanrKontroler.Instance.Sacuvaj(txtNaziv,txtOpis);
            
        }
    }
}
