using IgricePS.Server.Niti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgricePS.Server
{
    public partial class GlavnaFormaServer : Form
    {
        public GlavnaFormaServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ServerNit.Instance.StartujServer())
            {
                MessageBox.Show("Sistem je uspesno pokrenuo server");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da pokrene server");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ServerNit.Instance.StopirajServer())
            {
                MessageBox.Show("Sistem je uspesno zaustavio server");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zaustavi server");
            }
        }
    }
}
