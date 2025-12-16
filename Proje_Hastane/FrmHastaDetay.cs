using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Proje_Hastane
{
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }
        public string tc, adsoyad;

        sqlBaglantisi conn = new sqlBaglantisi();

        #region Form Load ve Hasta Bilgileri
        private void frmHastaDetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad Çekme
            lblTc.Text = tc;
            //Tbl_Hastalar tablosundan HastaAd,HastaSoyad seçildi, HastaTc'si @p1 olan ile
            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar Where HastaTC=@p1", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())                           // her veriyi okuyor ve eşleşince içine giriyor
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];  // HastaAd ve HastaSoyad alınıyor. 2 sütun gelcek. dr[0] ile 1. sütun, dr[1] ile 2.sütun çekiliyor.
                                                        // C# kolaylığı ile tek string ifadeden dolayı diğerlerini de çevirmene gerek kalmıyor. string dönüyor.
            }
            conn.baglanti().Close();



            //Randevu Geçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTC =" + tc, conn.baglanti());
            da.Fill(dt);
            dataGridRandevuGecmisi.DataSource = dt;

            // Branşları Çekme
            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmboBrans.Items.Add(dr2[0]);
            }
            conn.baglanti().Close();


            //Doktorlar'ı çekme
            SqlCommand komut3 = new SqlCommand("Select DoktorAd From Tbl_Doktorlar", conn.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbodoktor.Items.Add(dr3[0]);
            }

            //Duyuruları DataGridView'e çekme
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Duyurular", conn.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

        }
        #endregion

        #region Branş ve Doktor Seçimi
        private void cmboBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbodoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", conn.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmboBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbodoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            conn.baglanti().Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbodoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataGrid'e veri çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans='" + cmboBrans.Text + "'", conn.baglanti());
            da.Fill(dt);
            dataGridAktifRandevular.DataSource = dt;
        }
        #endregion

        private void lblAdSoyad_Click(object sender, EventArgs e)
        {

        }

        private void dataGridAktifRandevular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region Hasta Randevu Alma İsteği
        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            //Hasta Randevu Alma İsteği
            SqlCommand cmd = new SqlCommand("insert into Tbl_Randevular (RandevuBrans,RandevuTarih,RandevuSaat,RandevuDoktor,HastaTC,HastaAdSoyad) values (@p1,@p2,@p3,@p4,@p5,@p6)", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmboBrans.Text);
            cmd.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("p3", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p4", cmbodoktor.Text);
            cmd.Parameters.AddWithValue("@p5", lblTc.Text);
            cmd.Parameters.AddWithValue("@p6", lblAdSoyad.Text);

            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Randevu İsteği Gönderildi!");
        }
        #endregion
        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDuzenle fr = new FrmBilgiDuzenle();
            fr.TCno = lblTc.Text;
            fr.Show();
        }
    }
}
