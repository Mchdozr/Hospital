using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        private void FrmHastaKayit_Load(object sender, EventArgs e)
        {

        }
        sqlBaglantisi conn = new sqlBaglantisi();   

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var FrmHastaGiris = new FrmHastaGiris();
            FrmHastaGiris.Show();

        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar(HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) " +
                                                                 "values (@p1, @p2 ,@p3 ,@p4 ,@p5 ,@p6)", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskdtxtTc.Text);
            komut.Parameters.AddWithValue("@p4", mskdtxtTel.Text);
            komut.Parameters.AddWithValue("@p5",txtSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir! \nŞifreniz : " + txtSifre.Text);
        }

        private void mskdtxtTc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
