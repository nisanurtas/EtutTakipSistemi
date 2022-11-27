using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Reflection.Emit;

namespace EtütTakipSistemiAN
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = AYLINMERCAN\USERS; Initial Catalog = etütsistemi; Integrated Security = True");

        private void picClose1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void picMinimize1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login anasayfa = new Login();
            anasayfa.Show();
            this.Hide();
        }

      
    }
}
