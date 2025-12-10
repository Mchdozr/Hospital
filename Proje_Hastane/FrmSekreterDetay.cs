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
    public partial class FrmSekreterDetay : Form
    {
        string tc,adSoyad;
        sqlBaglantisi conn = new sqlBaglantisi();
        public FrmSekreterDetay()
        {
            InitializeComponent();
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

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {                                                                   // BURADA KALDIN
            lblTc.Text = tc;
            SqlCommand kmt = new SqlCommand("Select SekreterAdSoyad and SekreterSifre From Tbl_Sekreter Where SekreterTC=@p1", conn.baglanti());
        }

        private void lblSifre_Click(object sender, EventArgs e)
        {

        }

        private void lblTc_Click(object sender, EventArgs e)
        {

        }
    }
}
