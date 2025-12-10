using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmSekreterGiris : Form
    {
        
        sqlBaglantisi conn = new sqlBaglantisi(); // sqlBaglantisi sınıfındaki sql bağlantı otomatik kullanılır.
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1();
            Form1.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter Where SekreterTC=@p1 and SekreterSifre=@p2", conn.baglanti());
            komut.Parameters.AddWithValue("@p1", tctxt.Text);
            komut.Parameters.AddWithValue("@p2", sifretxt.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frm = new FrmSekreterDetay();
                
                frm.Show();
                this.Hide();
                
            }
            else 
            {
                MessageBox.Show("Hatalı TC veya Şifre!");
            }
            conn.baglanti().Close();
        }
    }
}
