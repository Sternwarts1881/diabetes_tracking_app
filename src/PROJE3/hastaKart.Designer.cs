namespace PROJE3
{
    partial class hastaKart
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.BackColor = System.Drawing.Color.Azure;
            this.lblAdSoyad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdSoyad.Location = new System.Drawing.Point(5, 5);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(316, 59);
            this.lblAdSoyad.TabIndex = 0;
            this.lblAdSoyad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdSoyad.Click += new System.EventHandler(this.label1_Click);
            // 
            // hastaKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblAdSoyad);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "hastaKart";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(326, 69);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAdSoyad;
    }
}
