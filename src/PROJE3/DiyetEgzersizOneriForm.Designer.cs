namespace PROJE3
{
    partial class DiyetEgzersizOneriForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDiyet = new System.Windows.Forms.ComboBox();
            this.cmbEgzersiz = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOneri = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HASTA İÇİN DİYET VE EGZERSİZ TANIMLAYIN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbDiyet
            // 
            this.cmbDiyet.FormattingEnabled = true;
            this.cmbDiyet.Items.AddRange(new object[] {
            "Az Şekerli Diyet",
            "Şekersiz Diyet",
            "Dengeli Beslenme",
            ""});
            this.cmbDiyet.Location = new System.Drawing.Point(76, 101);
            this.cmbDiyet.Name = "cmbDiyet";
            this.cmbDiyet.Size = new System.Drawing.Size(121, 21);
            this.cmbDiyet.TabIndex = 1;
            // 
            // cmbEgzersiz
            // 
            this.cmbEgzersiz.FormattingEnabled = true;
            this.cmbEgzersiz.Items.AddRange(new object[] {
            "Yürüyüş",
            "Bisiklet",
            "Klinik Egzersiz"});
            this.cmbEgzersiz.Location = new System.Drawing.Point(421, 101);
            this.cmbEgzersiz.Name = "cmbEgzersiz";
            this.cmbEgzersiz.Size = new System.Drawing.Size(121, 21);
            this.cmbEgzersiz.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Diyet Türü";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Egzersiz Türü";
            // 
            // lblOneri
            // 
            this.lblOneri.AutoSize = true;
            this.lblOneri.Location = new System.Drawing.Point(343, 234);
            this.lblOneri.Name = "lblOneri";
            this.lblOneri.Size = new System.Drawing.Size(0, 13);
            this.lblOneri.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sistemin hasta için önerdiği diyet ve egzersiz türü :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(221, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Hastayı Sisteme Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DiyetEgzersizOneriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblOneri);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEgzersiz);
            this.Controls.Add(this.cmbDiyet);
            this.Controls.Add(this.label1);
            this.Name = "DiyetEgzersizOneriForm";
            this.Text = "DiyetEgzersizOneriForm";
            this.Load += new System.EventHandler(this.DiyetEgzersizOneriForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDiyet;
        private System.Windows.Forms.ComboBox cmbEgzersiz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOneri;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}