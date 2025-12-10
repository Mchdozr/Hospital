using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlBaglantisi conn = new sqlBaglantisi();

        public string TCno;
        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            SqlCommand cmnd = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTc=@p6",conn.baglanti());
            cmnd.Parameters.AddWithValue("@p1", adTxt.Text);
            cmnd.Parameters.AddWithValue("@p2",soyadtxt.Text);
            cmnd.Parameters.AddWithValue("@p3", mskTel.Text);
            cmnd.Parameters.AddWithValue("@p4", sifretxt.Text);
            cmnd.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            cmnd.Parameters.AddWithValue("@p6",mskTc.Text);

            cmnd.ExecuteNonQuery();
            conn.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }   

        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTc.Text = TCno;
            SqlCommand cmnd = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", conn.baglanti());
            cmnd.Parameters.AddWithValue("@p1", mskTc.Text);
            SqlDataReader dr = cmnd.ExecuteReader();
            while (dr.Read()) 
            {
                adTxt.Text = dr[1].ToString(); // dr[...] içindeki değer -> sql'de sütun sırasına işaret ediyor.
                soyadtxt.Text = dr[2].ToString();
                mskTel.Text = dr[4].ToString();
                sifretxt.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }
            conn.baglanti().Close();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
