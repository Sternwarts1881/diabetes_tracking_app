using System.Windows.Forms;

namespace PROJE3
{
    partial class DoktorForm : Form
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
            this.mainbutton = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.lblDogumTarihi = new System.Windows.Forms.Label();
            this.profilepictureBox = new System.Windows.Forms.PictureBox();
            this.btnHastaekle = new System.Windows.Forms.Button();
            this.hastabilgibtn = new System.Windows.Forms.Button();
            this.bildirimbtn = new System.Windows.Forms.Button();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.gonderilenOnerilerButton = new System.Windows.Forms.Button();
            this.oneriGonderButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainbutton
            // 
            this.mainbutton.Location = new System.Drawing.Point(1602, 932);
            this.mainbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainbutton.Name = "mainbutton";
            this.mainbutton.Size = new System.Drawing.Size(156, 38);
            this.mainbutton.TabIndex = 1;
            this.mainbutton.Text = "Giriş Ekranına Dön";
            this.mainbutton.UseVisualStyleBackColor = true;
            this.mainbutton.Click += new System.EventHandler(this.mainbutton_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(18, 14);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(88, 20);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Doktor Adı:";
            this.lbl1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(18, 46);
            this.lbl2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(117, 20);
            this.lbl2.TabIndex = 3;
            this.lbl2.Text = "Doktor Soyadı :";
            this.lbl2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(24, 160);
            this.lbl5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(103, 20);
            this.lbl5.TabIndex = 4;
            this.lbl5.Text = "Doğum Tarihi";
            this.lbl5.Click += new System.EventHandler(this.lbl5_Click);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(24, 125);
            this.lbl4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(64, 20);
            this.lbl4.TabIndex = 5;
            this.lbl4.Text = "Cinsiyet";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(24, 85);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 20);
            this.lbl3.TabIndex = 6;
            this.lbl3.Text = "E-mail";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(117, 14);
            this.lblAd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 20);
            this.lblAd.TabIndex = 7;
            this.lblAd.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Location = new System.Drawing.Point(143, 43);
            this.lblSoyad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(0, 20);
            this.lblSoyad.TabIndex = 8;
            this.lblSoyad.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(86, 85);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 20);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Location = new System.Drawing.Point(100, 125);
            this.lblCinsiyet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(0, 20);
            this.lblCinsiyet.TabIndex = 10;
            // 
            // lblDogumTarihi
            // 
            this.lblDogumTarihi.AutoSize = true;
            this.lblDogumTarihi.Location = new System.Drawing.Point(138, 160);
            this.lblDogumTarihi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDogumTarihi.Name = "lblDogumTarihi";
            this.lblDogumTarihi.Size = new System.Drawing.Size(0, 20);
            this.lblDogumTarihi.TabIndex = 11;
            this.lblDogumTarihi.Click += new System.EventHandler(this.label5_Click);
            // 
            // profilepictureBox
            // 
            this.profilepictureBox.Location = new System.Drawing.Point(1602, 68);
            this.profilepictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.profilepictureBox.Name = "profilepictureBox";
            this.profilepictureBox.Size = new System.Drawing.Size(162, 174);
            this.profilepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilepictureBox.TabIndex = 12;
            this.profilepictureBox.TabStop = false;
            // 
            // btnHastaekle
            // 
            this.btnHastaekle.Location = new System.Drawing.Point(22, 205);
            this.btnHastaekle.Name = "btnHastaekle";
            this.btnHastaekle.Size = new System.Drawing.Size(207, 45);
            this.btnHastaekle.TabIndex = 14;
            this.btnHastaekle.Text = "Hasta Ekle";
            this.btnHastaekle.UseVisualStyleBackColor = true;
            this.btnHastaekle.Click += new System.EventHandler(this.button1_Click);
            // 
            // hastabilgibtn
            // 
            this.hastabilgibtn.Location = new System.Drawing.Point(22, 265);
            this.hastabilgibtn.Name = "hastabilgibtn";
            this.hastabilgibtn.Size = new System.Drawing.Size(207, 48);
            this.hastabilgibtn.TabIndex = 18;
            this.hastabilgibtn.Text = "Hasta Bilgileri";
            this.hastabilgibtn.UseVisualStyleBackColor = true;
            this.hastabilgibtn.Click += new System.EventHandler(this.hastabilgibtn_Click_1);
            // 
            // bildirimbtn
            // 
            this.bildirimbtn.Location = new System.Drawing.Point(1269, 28);
            this.bildirimbtn.Name = "bildirimbtn";
            this.bildirimbtn.Size = new System.Drawing.Size(156, 38);
            this.bildirimbtn.TabIndex = 20;
            this.bildirimbtn.Text = "Bildirimler / Uyarılar";
            this.bildirimbtn.UseVisualStyleBackColor = true;
            this.bildirimbtn.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(1432, 28);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(130, 35);
            this.btnrefresh.TabIndex = 21;
            this.btnrefresh.Text = "Sayfayı Yenile";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // gonderilenOnerilerButton
            // 
            this.gonderilenOnerilerButton.Location = new System.Drawing.Point(928, 28);
            this.gonderilenOnerilerButton.Name = "gonderilenOnerilerButton";
            this.gonderilenOnerilerButton.Size = new System.Drawing.Size(189, 38);
            this.gonderilenOnerilerButton.TabIndex = 22;
            this.gonderilenOnerilerButton.Text = "Gönderdiğim Öneriler";
            this.gonderilenOnerilerButton.UseVisualStyleBackColor = true;
            this.gonderilenOnerilerButton.Click += new System.EventHandler(this.gonderilenOnerilerButton_Click);
            // 
            // oneriGonderButton
            // 
            this.oneriGonderButton.Location = new System.Drawing.Point(1124, 28);
            this.oneriGonderButton.Name = "oneriGonderButton";
            this.oneriGonderButton.Size = new System.Drawing.Size(140, 38);
            this.oneriGonderButton.TabIndex = 23;
            this.oneriGonderButton.Text = "Öneri Gönder";
            this.oneriGonderButton.UseVisualStyleBackColor = true;
            this.oneriGonderButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1624, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Profil Fotoğrafı";
            // 
            // DoktorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1776, 989);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oneriGonderButton);
            this.Controls.Add(this.gonderilenOnerilerButton);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.bildirimbtn);
            this.Controls.Add(this.hastabilgibtn);
            this.Controls.Add(this.btnHastaekle);
            this.Controls.Add(this.profilepictureBox);
            this.Controls.Add(this.lblDogumTarihi);
            this.Controls.Add(this.lblCinsiyet);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.mainbutton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "DoktorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoktorForm";
            this.Load += new System.EventHandler(this.DoktorForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button mainbutton;
        private Label lbl1;
        private Label lbl2;
        private Label lbl5;
        private Label lbl4;
        private Label lbl3;
        private Label lblAd;
        private Label lblSoyad;
        private Label lblEmail;
        private Label lblCinsiyet;
        private Label lblDogumTarihi;
        private PictureBox profilepictureBox;
        private Button btnHastaekle;
        private Button hastabilgibtn;
        private Button bildirimbtn;
        private Button btnrefresh;
        private Button gonderilenOnerilerButton;
        private Button oneriGonderButton;
        private Label label1;
    }
}