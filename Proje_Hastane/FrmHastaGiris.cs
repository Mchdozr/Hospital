using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi conn = new sqlBaglantisi(); // sql sınıfındaki bağlantıyı kullanmak için
        private void button1_Click(object sender, EventArgs e) // Hasta giriş bilgileri kontrol
        {
            SqlCommand komut = new SqlCommand("Select * Form Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", mskSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay fr = new FrmHastaDetay();

                fr.tc = mskTC.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre");
            }
            conn.baglanti().Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e) // geri butonu
        {
            this.Hide();          // mevcut formu gizle
            var Form1 = new Form1();
            Form1.FormClosed += (_, __) => this.Close(); // form2 kapanınca uygulamayı kapat
            Form1.Show();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var FrmHastaKayit = new FrmHastaKayit();
            FrmHastaKayit.Show();
            this.Hide();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
