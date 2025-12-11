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

        public string tc,sifre;

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
        }

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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
