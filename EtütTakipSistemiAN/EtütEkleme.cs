using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EtütTakipSistemiAN
{
    public partial class EtütEkleme : Form
    {
        public EtütEkleme()
        {
            InitializeComponent();
        }

        private void picClose1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void picMinimize1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogOutOgr_Click(object sender, EventArgs e)
        {
            Login anasayfa = new Login();
            anasayfa.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DersTakvmi takvim = new DersTakvmi();
            takvim.Show();
            this.Hide();
        }

    }
}
    
