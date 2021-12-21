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
    public partial class KreirajStranicuUI : Form
    {
        public KreirajStranicuUI()
        {
            InitializeComponent();
            KreirajStranicuKontroler.Instance.PripremiFormu(cmbTip);
            
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            KreirajStranicuKontroler.Instance.Sacuvaj(txtNaziv,txtOpis,cmbTip);
        }

        
    }
}
