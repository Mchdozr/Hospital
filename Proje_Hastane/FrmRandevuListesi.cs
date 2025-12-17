using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{

    public partial class FrmRandevuListesi : Form
    {
        sqlBaglantisi conn = new sqlBaglantisi();
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }
        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Tbl_Randevular", conn.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            conn.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaRandevuDurumText.Text = "True";

            SqlCommand cmd = new SqlCommand("Update Tbl_Randevular set RandevuDurum=@p1,HastaAdSoyad=@p3 Where HastaTC=@p2", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", HastaRandevuDurumText.Text);
            cmd.Parameters.AddWithValue("@p3", hastaAdSoyadText.Text);
            cmd.Parameters.AddWithValue("@p2", hastaTctext.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Randevu Onaylandı!");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            hastaAdSoyadText.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            hastaTctext.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            HastaRandevuDurumText.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            HastaRandevuDurumText.Text = "False";
            SqlCommand cmd = new SqlCommand("Update Tbl_Randevular set RandevuDurum=@p1 Where HastaTC=@p2", conn.baglanti());
            cmd.Parameters.AddWithValue("@p1", HastaRandevuDurumText.Text);
            cmd.Parameters.AddWithValue("@p2", hastaTctext.Text);
            cmd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Randevu Reddedildi!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmSekreterDetay frm = new FrmSekreterDetay();
            frm.Show();
            this.Hide();
        }
    }
}
