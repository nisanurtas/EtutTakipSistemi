﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtütTakipSistemiAN
{
    public partial class ÖğretmenEkle : Form
    {
        public ÖğretmenEkle()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand komut;
        SqlConnection baglanti = new SqlConnection(@"Data Source = AYLINMERCAN\USERS; Initial Catalog = etütsistemi; Integrated Security = True");
        private void btnKayıtOl_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSifre.Text == txtSifreTekrar.Text && txtPosta.Text != "" && txtName.Text != ""
                     && txtSoyad.Text != "" && txtSifre.Text != "" && txtTC.Text != "" &&
                     txtTelNo.Text != "")
                {


                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        string kayit = "insert into ögretmen(ögretmenAd,ögretmenSoyad,ögretmenEposta,ögretmentelNo, ögretmentcNo,brans,ögretmenSifre) values (@ad,@soyad,@eposta,@telefon,@tcno,@brans,@sifre)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@ad", txtName.Text);
                        komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                        komut.Parameters.AddWithValue("@eposta", txtPosta.Text);
                        komut.Parameters.AddWithValue("@telefon", txtTelNo.Text);
                        komut.Parameters.AddWithValue("@tcno", txtTC.Text);
                        komut.Parameters.AddWithValue("@brans", textBoxBrans.Text);
                        komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
                        kayitGetir();
                    }

                    else
                    {
                        MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz.");
                    }

                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
           
        }

        private void ÖğretmenEkle_Load(object sender, EventArgs e)
        {
            kayitGetir();
        }
        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from ögretmen";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            baglanti.Close();
        }

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
            YöneticiGiris yöneticidön = new YöneticiGiris();
            yöneticidön.Show();
            this.Hide();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.ForeColor = Color.Black;
        }

        private void txtSoyad_Enter(object sender, EventArgs e)
        {
            txtSoyad.Text = "";
            txtSoyad.ForeColor = Color.Black;
        }

        private void txtPosta_Enter(object sender, EventArgs e)
        {
            txtPosta.Text = "";
            txtPosta.ForeColor = Color.Black;
        }

        private void txtTelNo_Enter(object sender, EventArgs e)
        {
            txtTelNo.Text = "";
            txtTelNo.ForeColor = Color.Black;
            txtTelNo.MaxLength = 11;
        }

        private void txtTC_Enter(object sender, EventArgs e)
        {
            txtTC.Text = "";
            txtTC.ForeColor = Color.Black;
            txtTC.MaxLength = 11;
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            txtSifre.Text = "";
            txtSifre.ForeColor = Color.Black;
        }

        private void txtSifreTekrar_Enter(object sender, EventArgs e)
        {
            txtSifreTekrar.Text = "";
            txtSifreTekrar.ForeColor = Color.Black;
        }

        private void picEye_Click(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = false;
            picEye.Visible = false;
            picGizle.Visible = true;
        }

        private void picGizle_Click(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
            picEye.Visible = true;
            picGizle.Visible = false;
        }

        private void picBoxSifreGöster_Click(object sender, EventArgs e)
        {
            txtSifreTekrar.UseSystemPasswordChar = false;
            picBoxSifreGöster.Visible = false;
            picBoxSifreGizle.Visible = true;
        }

        private void picBoxSifreGizle_Click(object sender, EventArgs e)
        {
            txtSifreTekrar.UseSystemPasswordChar = true;
            picBoxSifreGöster.Visible = true;
            picBoxSifreGizle.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(numara);
            }
            kayitGetir();
        }

        private void buttonAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "SELECT * from ögretmen where ögretmenAd=@ad and ögretmenSoyad=@soyad";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@ad", textBoxAraAd.Text);
            komut.Parameters.AddWithValue("@soyad", textBoxAraSoyad.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        void KayıtSil(int numara)
        {
            string sql = "DELETE FROM ögretmen WHERE ögretmenId=@ögr";
            komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@ögr", numara);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void textBoxAraAd_Enter(object sender, EventArgs e)
        {
            textBoxAraAd.Text = "";
            textBoxAraAd.ForeColor = Color.Black;
        }

        private void textBoxAraSoyad_Enter(object sender, EventArgs e)
        {
            textBoxAraSoyad.Text = "";
            textBoxAraSoyad.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ÖğretmenEkle öğretmenEkle = new ÖğretmenEkle();
            öğretmenEkle.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Öğrenciişlemleri ögris = new Öğrenciişlemleri();
            ögris.Show();
            this.Hide();
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            YöneticiMain main = new YöneticiMain();
            main.Show();
            this.Hide();
        }

        private void textBoxBrans_Enter(object sender, EventArgs e)
        {
            textBoxBrans.Text = "";
            textBoxBrans.ForeColor = Color.Black;
        }
    }
}
