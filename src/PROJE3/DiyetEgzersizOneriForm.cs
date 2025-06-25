using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE3
{


    public partial class DiyetEgzersizOneriForm : Form
    {
        private string tc, sifre, ad, soyad, email, cinsiyet, kansekeriStr;
        private DateTime dogumTarihi;
        private List<string> belirtiler;
        private int doktorID, hastaID;
        public DiyetEgzersizOneriForm(string tc, string sifre, string ad, string soyad, string email,
                              DateTime dogumTarihi, string cinsiyet, string kansekeri,
                              List<string> belirtiler, int doktorID, int hastaID)
        {
            this.tc = tc;
            this.sifre = sifre;
            this.ad = ad;
            this.soyad = soyad;
            this.email = email;
            this.dogumTarihi = dogumTarihi;
            this.cinsiyet = cinsiyet;
            this.kansekeriStr = kansekeri;
            this.belirtiler = belirtiler;
            this.doktorID = doktorID;
            this.hastaID = hastaID;
            InitializeComponent();
            OneriHesapla(Convert.ToDecimal(kansekeriStr), belirtiler);

        }
        private void OneriHesapla(decimal kansekeri, List<string> belirtiler)
        {
            string diyet = "";
            string egzersiz = "";

            if (kansekeri < 70)
            {
                diyet = "Dengeli Beslenme";
                egzersiz = "Yok";
            }
            else if (kansekeri <= 110)
            {
                if (belirtiler.Contains("Yorgunluk") || belirtiler.Contains("Kilo kaybı"))
                    diyet = "Az Şekerli Diyet";
                else if (belirtiler.Contains("Polifaji") || belirtiler.Contains("Polidipsi"))
                    diyet = "Dengeli Beslenme";

                egzersiz = "Yürüyüş";
            }
            else if (kansekeri <= 180)
            {
                if (belirtiler.Contains("Bulanık görme") || belirtiler.Contains("Nöropati"))
                    diyet = "Az Şekerli Diyet";
                else if (belirtiler.Contains("Poliüri") || belirtiler.Contains("Polidipsi"))
                    diyet = "Şekersiz Diyet";

                if (belirtiler.Contains("Yorgunluk"))
                    egzersiz = "Yürüyüş";
                else
                    egzersiz = "Klinik Egzersiz";
            }
            else
            {
                diyet = "Şekersiz Diyet";
                if (belirtiler.Contains("Polidipsi") || belirtiler.Contains("Polifaji"))
                    egzersiz = "Klinik Egzersiz";
                else
                    egzersiz = "Yürüyüş";
            }

            lblOneri.Text = $"Önerilen Diyet: {diyet}\nÖnerilen Egzersiz: {egzersiz}";


            cmbDiyet.SelectedItem = diyet;
            cmbEgzersiz.SelectedItem = egzersiz;

        }
        private void DiyetEgzersizOneriForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string secilenDiyet = cmbDiyet.SelectedItem?.ToString();
            string secilenEgzersiz = cmbEgzersiz.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilenDiyet))
            {
                MessageBox.Show("Lütfen diyet seçimi yapınız.");
                return;
            }

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();


                string insertDiyet = "INSERT INTO diyet (hastaid, diyettipi, uygulandimi,tarih) VALUES (@hid, @diyet, 0,@tarih)";
                MySqlCommand cmdDiyet = new MySqlCommand(insertDiyet, conn);
                cmdDiyet.Parameters.AddWithValue("@hid", hastaID);
                cmdDiyet.Parameters.AddWithValue("@diyet", secilenDiyet);
                cmdDiyet.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmdDiyet.ExecuteNonQuery();


                string insertEgz = "INSERT INTO egzersiz (hastaid, egzersiztipi, yapildimi,Tarih) VALUES (@hid, @egz, 0,@tarih)";
                MySqlCommand cmdEgz = new MySqlCommand(insertEgz, conn);
                cmdEgz.Parameters.AddWithValue("@hid", hastaID);
                cmdEgz.Parameters.AddWithValue("@egz", secilenEgzersiz);
                cmdEgz.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmdEgz.ExecuteNonQuery();

                cmbDiyet.Items.AddRange(new string[] { "Az Şekerli Diyet", "Şekersiz Diyet", "Dengeli Beslenme" });
                cmbEgzersiz.Items.AddRange(new string[] { "Yürüyüş", "Bisiklet", "Klinik Egzersiz", "Yok" });

            }

            MessageBox.Show("Diyet ve egzersiz atamaları yapıldı. Hasta başarıyla kaydedildi \n Hastanın Şifresi Mail Hesabına Gönderilmiştir.");
            this.Close();
        }
    }
}
