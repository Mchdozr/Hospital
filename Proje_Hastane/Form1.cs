using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlBaglantisi con = new sqlBaglantisi();
            
        }

        private void btnHastaGirisi_Click(object sender, EventArgs e)
        {
            //this.Hide();          // mevcut formu gizle
            //var FrmHastaGiris = new FrmHastaGiris();
            //FrmHastaGiris.FormClosed += (_, __) => this.Close(); // form2 kapanınca uygulamayı kapat
            //FrmHastaGiris.Show();
            FrmHastaGiris fr = new FrmHastaGiris();
            fr.Show();
            this.Hide();
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris fr = new FrmDoktorGiris();
            fr.Show();
            this.Hide();

        }

        private void btnSekreterGirisi_Click(object sender, EventArgs e)
        {
            this.Hide();
            var FrmSekreterGiris = new FrmSekreterGiris();
            FrmSekreterGiris.Show();
        }
    }
}
