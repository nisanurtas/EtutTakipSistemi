using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtütTakipSistemiAN
{
    public partial class DersTakvmi : Form
    {
        public DersTakvmi()
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

        private void button2_Click(object sender, EventArgs e)
        {
            EtütEkleme etütEkleme = new EtütEkleme();
            etütEkleme.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login anasayfa = new Login();
            anasayfa.Show();
            this.Hide();
        }
    }
}
