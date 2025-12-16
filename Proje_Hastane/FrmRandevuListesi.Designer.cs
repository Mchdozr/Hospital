namespace Proje_Hastane
{
    partial class FrmRandevuListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RandevuGroupBox = new System.Windows.Forms.GroupBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.hastaTctext = new System.Windows.Forms.TextBox();
            this.hastaAdSoyadText = new System.Windows.Forms.TextBox();
            this.HastaRandevuDurumText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.RandevuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1445, 181);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            // 
            // RandevuGroupBox
            // 
            this.RandevuGroupBox.Controls.Add(this.dataGridView1);
            this.RandevuGroupBox.Location = new System.Drawing.Point(12, 12);
            this.RandevuGroupBox.Name = "RandevuGroupBox";
            this.RandevuGroupBox.Size = new System.Drawing.Size(1451, 202);
            this.RandevuGroupBox.TabIndex = 1;
            this.RandevuGroupBox.TabStop = false;
            this.RandevuGroupBox.Text = "Randevular";
            // 
            // btnOnayla
            // 
            this.btnOnayla.Location = new System.Drawing.Point(649, 355);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(124, 58);
            this.btnOnayla.TabIndex = 2;
            this.btnOnayla.Text = "ONAYLA";
            this.btnOnayla.UseVisualStyleBackColor = true;
            this.btnOnayla.Click += new System.EventHandler(this.button1_Click);
            // 
            // hastaTctext
            // 
            this.hastaTctext.Location = new System.Drawing.Point(635, 262);
            this.hastaTctext.Name = "hastaTctext";
            this.hastaTctext.Size = new System.Drawing.Size(155, 22);
            this.hastaTctext.TabIndex = 3;
            // 
            // hastaAdSoyadText
            // 
            this.hastaAdSoyadText.Location = new System.Drawing.Point(635, 290);
            this.hastaAdSoyadText.Name = "hastaAdSoyadText";
            this.hastaAdSoyadText.Size = new System.Drawing.Size(155, 22);
            this.hastaAdSoyadText.TabIndex = 4;
            // 
            // HastaRandevuDurumText
            // 
            this.HastaRandevuDurumText.Location = new System.Drawing.Point(635, 318);
            this.HastaRandevuDurumText.Name = "HastaRandevuDurumText";
            this.HastaRandevuDurumText.Size = new System.Drawing.Size(155, 22);
            this.HastaRandevuDurumText.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "HastaTC :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hasta Ad Soyad:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Randevu Durumu:";
            // 
            // FrmRandevuListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 447);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HastaRandevuDurumText);
            this.Controls.Add(this.hastaAdSoyadText);
            this.Controls.Add(this.hastaTctext);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.RandevuGroupBox);
            this.Name = "FrmRandevuListesi";
            this.Text = "FrmRandevuListesi";
            this.Load += new System.EventHandler(this.FrmRandevuListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.RandevuGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox RandevuGroupBox;
        private System.Windows.Forms.Button btnOnayla;
        private System.Windows.Forms.TextBox hastaTctext;
        private System.Windows.Forms.TextBox hastaAdSoyadText;
        private System.Windows.Forms.TextBox HastaRandevuDurumText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}