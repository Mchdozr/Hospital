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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi conn = new sqlBaglantisi();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Form1 = new Form1();
            Form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Doktorlar Where DoktorTC=@p1 and DoktorSifre=@p2",conn.baglanti()); // Where 'den sonra virgül ile ayırma hata alırsın. AND kullan.
            cmd.Parameters.AddWithValue("@p1", mskdDoktorTc.Text);
            cmd.Parameters.AddWithValue("@p2", mskdDoktorSifre.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorPanel frdr = new FrmDoktorPanel();
                frdr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TC veya Şifre Yanlış!");
            }
            conn.baglanti().Close();
        }
    }
}
