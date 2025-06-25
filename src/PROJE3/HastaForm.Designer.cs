using System.Windows.Forms;

namespace PROJE3
{
    partial class HastaForm : Form
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainbutton = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.kanBilgiButonu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblCinsiyet = new System.Windows.Forms.Label();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.profilepictureBox = new System.Windows.Forms.PictureBox();
            this.sekerEkleButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInsulinOneri = new System.Windows.Forms.Label();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.lblDiyet = new System.Windows.Forms.Label();
            this.lblEgzersiz = new System.Windows.Forms.Label();
            this.chartSeker = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pieChartDiyet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pieChartEgzersiz = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button3 = new System.Windows.Forms.Button();
            this.alinanOnerilerButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartDiyet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartEgzersiz)).BeginInit();
            this.SuspendLayout();
            // 
            // mainbutton
            // 
            this.mainbutton.Location = new System.Drawing.Point(1606, 937);
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
            this.lbl1.Location = new System.Drawing.Point(14, 9);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(83, 20);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Hasta Adı:";
            this.lbl1.Click += new System.EventHandler(this.lbl1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hasta Soyadı:";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(14, 72);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(53, 20);
            this.lbl3.TabIndex = 7;
            this.lbl3.Text = "E-mail";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(14, 108);
            this.lbl4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(64, 20);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "Cinsiyet";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(14, 137);
            this.lbl5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(103, 20);
            this.lbl5.TabIndex = 9;
            this.lbl5.Text = "Doğum Tarihi";
            // 
            // kanBilgiButonu
            // 
            this.kanBilgiButonu.Location = new System.Drawing.Point(16, 183);
            this.kanBilgiButonu.Name = "kanBilgiButonu";
            this.kanBilgiButonu.Size = new System.Drawing.Size(146, 45);
            this.kanBilgiButonu.TabIndex = 10;
            this.kanBilgiButonu.Text = "Kan Değerleri";
            this.kanBilgiButonu.UseVisualStyleBackColor = true;
            this.kanBilgiButonu.Click += new System.EventHandler(this.kanBilgiButonu_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 45);
            this.button1.TabIndex = 11;
            this.button1.Text = "Egzersiz Takibi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 45);
            this.button2.TabIndex = 12;
            this.button2.Text = "Diyet Takibi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1050, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "En Son Atanan Egzersizim:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "En Son Atanan Diyet Programım:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Günlük Kan Şekeri Tablosu";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Location = new System.Drawing.Point(132, 40);
            this.lblSoyad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(0, 20);
            this.lblSoyad.TabIndex = 16;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(132, 72);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 20);
            this.lblEmail.TabIndex = 17;
            this.lblEmail.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(130, 9);
            this.lblAd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(0, 20);
            this.lblAd.TabIndex = 18;
            // 
            // lblCinsiyet
            // 
            this.lblCinsiyet.AutoSize = true;
            this.lblCinsiyet.Location = new System.Drawing.Point(132, 108);
            this.lblCinsiyet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCinsiyet.Name = "lblCinsiyet";
            this.lblCinsiyet.Size = new System.Drawing.Size(0, 20);
            this.lblCinsiyet.TabIndex = 19;
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Location = new System.Drawing.Point(132, 137);
            this.lblBirthdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(0, 20);
            this.lblBirthdate.TabIndex = 20;
            // 
            // profilepictureBox
            // 
            this.profilepictureBox.Location = new System.Drawing.Point(1582, 42);
            this.profilepictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.profilepictureBox.Name = "profilepictureBox";
            this.profilepictureBox.Size = new System.Drawing.Size(162, 174);
            this.profilepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilepictureBox.TabIndex = 22;
            this.profilepictureBox.TabStop = false;
            // 
            // sekerEkleButton
            // 
            this.sekerEkleButton.Location = new System.Drawing.Point(18, 248);
            this.sekerEkleButton.Name = "sekerEkleButton";
            this.sekerEkleButton.Size = new System.Drawing.Size(146, 63);
            this.sekerEkleButton.TabIndex = 23;
            this.sekerEkleButton.Text = "Kan Şekeri Tahlili Ekle";
            this.sekerEkleButton.UseVisualStyleBackColor = true;
            this.sekerEkleButton.Click += new System.EventHandler(this.sekerEkleButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 40);
            this.label5.TabIndex = 24;
            this.label5.Text = "Hastanın Alması Gereken \r\nİnsülin Dozu Önerisi :\r\n";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // lblInsulinOneri
            // 
            this.lblInsulinOneri.AutoSize = true;
            this.lblInsulinOneri.Location = new System.Drawing.Point(637, 52);
            this.lblInsulinOneri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInsulinOneri.Name = "lblInsulinOneri";
            this.lblInsulinOneri.Size = new System.Drawing.Size(0, 20);
            this.lblInsulinOneri.TabIndex = 25;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(1432, 18);
            this.btnrefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(126, 35);
            this.btnrefresh.TabIndex = 26;
            this.btnrefresh.Text = "Sayfayı Yenile";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // lblDiyet
            // 
            this.lblDiyet.AutoSize = true;
            this.lblDiyet.Location = new System.Drawing.Point(526, 195);
            this.lblDiyet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiyet.Name = "lblDiyet";
            this.lblDiyet.Size = new System.Drawing.Size(0, 20);
            this.lblDiyet.TabIndex = 27;
            // 
            // lblEgzersiz
            // 
            this.lblEgzersiz.AutoSize = true;
            this.lblEgzersiz.Location = new System.Drawing.Point(1258, 195);
            this.lblEgzersiz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEgzersiz.Name = "lblEgzersiz";
            this.lblEgzersiz.Size = new System.Drawing.Size(0, 20);
            this.lblEgzersiz.TabIndex = 28;
            // 
            // chartSeker
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSeker.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSeker.Legends.Add(legend4);
            this.chartSeker.Location = new System.Drawing.Point(165, 577);
            this.chartSeker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chartSeker.Name = "chartSeker";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartSeker.Series.Add(series4);
            this.chartSeker.Size = new System.Drawing.Size(1329, 426);
            this.chartSeker.TabIndex = 29;
            this.chartSeker.Text = "chart1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 222);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Yüzdesel Olarak Diyet Programı Takibi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1050, 222);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Yüzdesel Olarak Diyet Egzersiz Takibi";
            // 
            // pieChartDiyet
            // 
            chartArea5.Name = "ChartArea1";
            this.pieChartDiyet.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.pieChartDiyet.Legends.Add(legend5);
            this.pieChartDiyet.Location = new System.Drawing.Point(264, 262);
            this.pieChartDiyet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pieChartDiyet.Name = "pieChartDiyet";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.pieChartDiyet.Series.Add(series5);
            this.pieChartDiyet.Size = new System.Drawing.Size(576, 257);
            this.pieChartDiyet.TabIndex = 32;
            this.pieChartDiyet.Text = "chart1";
            this.pieChartDiyet.Click += new System.EventHandler(this.chartDiyet_Click);
            // 
            // pieChartEgzersiz
            // 
            chartArea6.Name = "ChartArea1";
            this.pieChartEgzersiz.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.pieChartEgzersiz.Legends.Add(legend6);
            this.pieChartEgzersiz.Location = new System.Drawing.Point(1054, 262);
            this.pieChartEgzersiz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pieChartEgzersiz.Name = "pieChartEgzersiz";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.pieChartEgzersiz.Series.Add(series6);
            this.pieChartEgzersiz.Size = new System.Drawing.Size(576, 257);
            this.pieChartEgzersiz.TabIndex = 33;
            this.pieChartEgzersiz.Text = "chart2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(20, 478);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 45);
            this.button3.TabIndex = 34;
            this.button3.Text = "İnsülin Geçmişim";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // alinanOnerilerButton
            // 
            this.alinanOnerilerButton.Location = new System.Drawing.Point(1148, 18);
            this.alinanOnerilerButton.Name = "alinanOnerilerButton";
            this.alinanOnerilerButton.Size = new System.Drawing.Size(278, 35);
            this.alinanOnerilerButton.TabIndex = 35;
            this.alinanOnerilerButton.Text = "Doktorun Gönderdiği Öneriler";
            this.alinanOnerilerButton.UseVisualStyleBackColor = true;
            this.alinanOnerilerButton.Click += new System.EventHandler(this.alinanOnerilerButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1602, 14);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "Profil Fotoğrafı";
            // 
            // HastaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1776, 989);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.alinanOnerilerButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pieChartEgzersiz);
            this.Controls.Add(this.pieChartDiyet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chartSeker);
            this.Controls.Add(this.lblEgzersiz);
            this.Controls.Add(this.lblDiyet);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.lblInsulinOneri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sekerEkleButton);
            this.Controls.Add(this.profilepictureBox);
            this.Controls.Add(this.lblBirthdate);
            this.Controls.Add(this.lblCinsiyet);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSoyad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.kanBilgiButonu);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.mainbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "HastaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HastaForm";
            this.Load += new System.EventHandler(this.HastaForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartDiyet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartEgzersiz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button mainbutton;
        private Label lbl1;
        private Label label1;
        private Label lbl3;
        private Label lbl4;
        private Label lbl5;
        private Button kanBilgiButonu;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblSoyad;
        private Label lblEmail;
        private Label lblAd;
        private Label lblCinsiyet;
        private Label lblBirthdate;
        private PictureBox profilepictureBox;
        private Button sekerEkleButton;
        private Label label5;
        private Label lblInsulinOneri;
        private Button btnrefresh;
        private Label lblDiyet;
        private Label lblEgzersiz;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSeker;
        private Label label6;
        private Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChartDiyet;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChartEgzersiz;
        private Button button3;
        private Button alinanOnerilerButton;
        private Label label8;
    }
}