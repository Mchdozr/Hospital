using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmDoktorPanel : Form
    {
        public FrmDoktorPanel()
        {
            InitializeComponent();
        }
        sqlBaglantisi conn = new sqlBaglantisi();

        #region Form Load ve Doktor Listesi
        private void FrmDoktorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Doktorlar",conn.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branşları Combobox'a Aktarma

            SqlCommand cmd = new SqlCommand("Select BransAd From Tbl_Branslar", conn.baglanti());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                txtBrans.Items.Add(dr[0]);    
            }
            conn.baglanti().Close();
        }   
        #endregion

        #region Doktor Ekleme / Silme / Güncelleme
        //Doktor Ekleme
        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmn = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)",conn.baglanti());
            cmn.Parameters.AddWithValue("@p1", txtAd.Text);
            cmn.Parameters.AddWithValue("@p2",txtSoyad.Text);
            cmn.Parameters.AddWithValue("@p3", txtBrans.Text);
            cmn.Parameters.AddWithValue("p4", txtTC.Text);
            cmn.Parameters.AddWithValue("@p5", txtSifre.Text);
            cmn.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //DataGridView'de seçilen bilgileri gösterme
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();


        }
        //kayıt silme işlemi
        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Doktorlar Where DoktorTC=@p1", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtTC.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
        }
        //Doktor bilgileri güncelleme
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmn = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 Where DoktorTC=@d4 ",conn.baglanti());
            cmn.Parameters.AddWithValue("@d1", txtAd.Text);
            cmn.Parameters.AddWithValue("@d2", txtSoyad.Text);
            cmn.Parameters.AddWithValue("@d3", txtBrans.Text);
            cmn.Parameters.AddWithValue("d4", txtTC.Text);
            cmn.Parameters.AddWithValue("@d5", txtSifre.Text);
            cmn.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Güncelleme Başarılı");
        }
        #endregion

        #region Navigasyon / Duyurular
        //frmduyurular 'a geçiş
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmDuyurular frm = new FrmDuyurular();
            frm.Show();
            this.Hide();
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmSekreterDetay frm = new FrmSekreterDetay();
            frm.Show();
            this.Hide();
        }
    }
}
