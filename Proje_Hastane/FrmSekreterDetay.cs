using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmSekreterDetay : Form
    {
        sqlBaglantisi conn = new sqlBaglantisi();
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string tc, sifre;

        #region Form Load ve Sekreter Bilgileri
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = tc;
            lblSifre.Text = sifre;

            //Ad Soyad Çekme
            SqlCommand cmd = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter Where SekreterTC=@p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString(); // yukarı sql sorgusundan tek sonuc gelecek o yüzden 0. index yazdık
            }
            conn.baglanti().Close();


            //Branşları Çekme(datagrid'e)
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd as Branşlar from Tbl_Branslar", conn.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;


            //Doktorları Listeye Aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd +' '+ DoktorSoyad) as Doktorlar ,DoktorBrans From Tbl_Doktorlar", conn.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşı Combobox'a aktarma

            SqlCommand cmd2 = new SqlCommand("select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            conn.baglanti().Close();
        }
        #endregion

        #region Randevu Oluşturma
        //Randevu Oluşturma
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)", conn.baglanti());
            cmd.Parameters.AddWithValue("@r1", mskdTarih.Text);
            cmd.Parameters.AddWithValue("@r2", mskdsaat.Text);
            cmd.Parameters.AddWithValue("@r3", cmbBrans.Text);
            cmd.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu!");
        }
        #endregion

        #region Seçilen Branşa Göre Doktor Getirme
        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            SqlCommand cmd = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            conn.baglanti().Close();
        }
        #endregion

        #region Duyuru Oluşturma
        private void button1_Click(object sender, EventArgs e)
        {
            //db'e duyuru gönderiliyor
            SqlCommand cmnd = new SqlCommand("Insert into Tbl_Duyurular (duyuru) values (@d1)", conn.baglanti());
            cmnd.Parameters.AddWithValue("@d1", rchDuyuru.Text);
            cmnd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu!");


        }
        #endregion


        private void lblSifre_Click(object sender, EventArgs e)
        {

        }
        private void lblTc_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            FrmDoktorPanel frm = new FrmDoktorPanel();
            frm.Show();
            this.Hide();

        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi frm = new FrmRandevuListesi();
            frm.Show();
            this.Hide();
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

