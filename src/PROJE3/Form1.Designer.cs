namespace PROJE3
{
    partial class GirişForm
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

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTC = new System.Windows.Forms.Label();
            this.TCbox = new System.Windows.Forms.TextBox();
            this.Sifrebox = new System.Windows.Forms.TextBox();
            this.Sifrelbl = new System.Windows.Forms.Label();
            this.girisbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.durumlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTC
            // 
            this.lblTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTC.AutoSize = true;
            this.lblTC.Location = new System.Drawing.Point(482, 223);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(68, 13);
            this.lblTC.TabIndex = 0;
            this.lblTC.Text = "TC Kimlik No";
            this.lblTC.Click += new System.EventHandler(this.label1_Click);
            // 
            // TCbox
            // 
            this.TCbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCbox.Location = new System.Drawing.Point(569, 223);
            this.TCbox.Name = "TCbox";
            this.TCbox.Size = new System.Drawing.Size(100, 20);
            this.TCbox.TabIndex = 1;
            this.TCbox.TextChanged += new System.EventHandler(this.TCbox_TextChanged);
            // 
            // Sifrebox
            // 
            this.Sifrebox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sifrebox.Location = new System.Drawing.Point(569, 249);
            this.Sifrebox.Name = "Sifrebox";
            this.Sifrebox.Size = new System.Drawing.Size(100, 20);
            this.Sifrebox.TabIndex = 2;
            // 
            // Sifrelbl
            // 
            this.Sifrelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Sifrelbl.AutoSize = true;
            this.Sifrelbl.Location = new System.Drawing.Point(482, 249);
            this.Sifrelbl.Name = "Sifrelbl";
            this.Sifrelbl.Size = new System.Drawing.Size(28, 13);
            this.Sifrelbl.TabIndex = 3;
            this.Sifrelbl.Text = "Şifre";
            this.Sifrelbl.Click += new System.EventHandler(this.Sifrelbl_Click);
            // 
            // girisbtn
            // 
            this.girisbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.girisbtn.Location = new System.Drawing.Point(569, 289);
            this.girisbtn.Name = "girisbtn";
            this.girisbtn.Size = new System.Drawing.Size(75, 23);
            this.girisbtn.TabIndex = 4;
            this.girisbtn.Text = "Giriş";
            this.girisbtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.girisbtn.UseVisualStyleBackColor = true;
            this.girisbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DİYABET SİSTEMİ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // durumlbl
            // 
            this.durumlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.durumlbl.AutoSize = true;
            this.durumlbl.Location = new System.Drawing.Point(606, 346);
            this.durumlbl.Name = "durumlbl";
            this.durumlbl.Size = new System.Drawing.Size(0, 13);
            this.durumlbl.TabIndex = 6;
            this.durumlbl.Click += new System.EventHandler(this.label4_Click);
            // 
            // GirişForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1184, 643);
            this.Controls.Add(this.durumlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.girisbtn);
            this.Controls.Add(this.Sifrelbl);
            this.Controls.Add(this.Sifrebox);
            this.Controls.Add(this.TCbox);
            this.Controls.Add(this.lblTC);
            this.MaximizeBox = false;
            this.Name = "GirişForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.TextBox TCbox;
        private System.Windows.Forms.TextBox Sifrebox;
        private System.Windows.Forms.Label Sifrelbl;
        private System.Windows.Forms.Button girisbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label durumlbl;
    }
}

