using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace PROJE3
{
    public partial class HastaForm : Form
    {
        private string kullaniciTC;
        private int id;

        public HastaForm(string tc)
        {
            InitializeComponent();
            kullaniciTC = tc;
            this.Text = "Hasta Paneli - " + kullaniciTC;
            this.Load += new EventHandler(HastaForm_Load);
            this.id = -1;

        }
        private void HastaForm_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, ad, soyad, email, cinsiyet, dogum_tarihi, profil_resmi FROM kullanicilar WHERE tcno = @tc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", kullaniciTC);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = Convert.ToInt32(reader["id"]);
                            lblAd.Text = reader["ad"].ToString();
                            lblSoyad.Text = reader["soyad"].ToString();
                            lblEmail.Text = reader["email"].ToString();
                            lblCinsiyet.Text = reader["cinsiyet"].ToString();
                            lblBirthdate.Text = Convert.ToDateTime(reader["dogum_tarihi"]).ToShortDateString();




                            string fotoPath = reader["profil_resmi"].ToString();

                            byte[] resimVerisi = (byte[])reader["profil_resmi"];
                            if (resimVerisi != null && resimVerisi.Length > 0)
                            {
                                using (MemoryStream ms = new MemoryStream(resimVerisi))
                                {
                                    profilepictureBox.Image = Image.FromStream(ms);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hasta bilgisi bulunamadı.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            InsulinOnerisiHesapla();
            DiyetBilgisiGetir();
            EgzersizBilgisiGetir();
            KanSekeriGrafikCiz();
            DiyetTakipGrafik();
            EgzersizTakipGrafik();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EgzersizBilgisiGetir()
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();
                string sql = "SELECT egzersiztipi FROM egzersiz WHERE hastaid = @hid ORDER BY egzersizid DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hid", id);

                object tip = cmd.ExecuteScalar();
                if (tip != null)
                    lblEgzersiz.Text = tip.ToString();
                else
                    lblEgzersiz.Text = "Egzersiz atanmadı.";
            }
        }
        private void mainbutton_Click(object sender, EventArgs e)
        {
            Form Form1 = new GirişForm();
            Form1.Show();

            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void DiyetBilgisiGetir()
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();
                string sql = "SELECT diyettipi FROM diyet WHERE hastaid = @hid ORDER BY diyetid DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hid", id);

                object tip = cmd.ExecuteScalar();
                if (tip != null)
                    lblDiyet.Text = tip.ToString();
                else
                    lblDiyet.Text = "Diyet atanmadı.";
            }
        }
        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bugun = DateTime.Now.ToString("yyyy-MM-dd");
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";

            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();


                string kontrol = "SELECT COUNT(*) FROM diyet WHERE hastaid = @hid AND DATE(tarih) = @bugun";
                MySqlCommand cmdKontrol = new MySqlCommand(kontrol, conn);
                cmdKontrol.Parameters.AddWithValue("@hid", id);
                cmdKontrol.Parameters.AddWithValue("@bugun", bugun);

                int sayi = Convert.ToInt32(cmdKontrol.ExecuteScalar());
                if (sayi > 0)
                {
                    MessageBox.Show("Bugün zaten diyet takibini sisteme girdiniz.");
                    return;
                }

                string diyetTuruBulQuery = "SELECT DiyetTipi FROM diyet WHERE hastaid=@hid ORDER BY DiyetTipi DESC LIMIT 1 ";
                MySqlCommand cmdDiyetTuru = new MySqlCommand(diyetTuruBulQuery, conn);
                cmdDiyetTuru.Parameters.AddWithValue("@hid", id);
                string diyetTuru = cmdDiyetTuru.ExecuteScalar()?.ToString();

                DialogResult sonuc = MessageBox.Show("Bugünkü diyetinizi yaptınız mı?", "Diyet Takibi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int yapildimi = (sonuc == DialogResult.Yes) ? 1 : 0;


                string guncelle = "INSERT INTO diyet (hastaid,DiyetTipi,UygulandiMi,Tarih) VALUES(@hid,@diyet,@yapildimi,@tarih)";
                MySqlCommand cmdGuncelle = new MySqlCommand(guncelle, conn);
                cmdGuncelle.Parameters.AddWithValue("@hid", id);
                cmdGuncelle.Parameters.AddWithValue("@yapildimi", yapildimi);
                cmdGuncelle.Parameters.AddWithValue("@diyet", diyetTuru);
                cmdGuncelle.Parameters.AddWithValue("@tarih", bugun);
                cmdGuncelle.ExecuteNonQuery();

                MessageBox.Show($"Diyet durumu \"{(yapildimi == 1 ? "Yaptım" : "Yapmadım")}\" olarak kaydedildi.");
            }
        }

        private void KanSekeriGrafikCiz()
        {
            chartSeker.Series.Clear();
            chartSeker.Titles.Clear();
            chartSeker.Titles.Add("Geçmiş Kan Şekeri Değerleri");

            Series seri = new Series("Kan Sekeri Seviyesi mg/dL");
            seri.ChartType = SeriesChartType.Column;
            seri.XValueType = ChartValueType.DateTime;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();
                string sql = "SELECT TarihSaat, Seviye FROM kansekeri WHERE hastaid = @hid ORDER BY TarihSaat ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hid", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime tarih = Convert.ToDateTime(reader["TarihSaat"]);
                        double seviye = Convert.ToDouble(reader["Seviye"]);
                        seri.Points.AddXY(tarih, seviye);
                    }
                }
            }

            chartSeker.Series.Add(seri);

            chartSeker.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM HH:mm";
            chartSeker.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void kanBilgiButonu_Click(object sender, EventArgs e)
        {
            Form Form1 = new hastaKanDegerleri(id);
            Form1.Show();


        }
        private void DiyetTakipGrafik()
        {
            int yapildi = 0, yapilmadi = 0;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();

                string query = "SELECT Tarih, UygulandiMi FROM diyet WHERE hastaid = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                HashSet<string> tarihSet = new HashSet<string>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tarih = Convert.ToDateTime(reader["Tarih"]).ToString("yyyy-MM-dd");
                        tarihSet.Add(tarih);

                        int durum = Convert.ToInt32(reader["UygulandiMi"]);
                        if (durum == 1) yapildi++;
                        else yapilmadi++;
                    }
                }

                int toplam = yapildi + yapilmadi;
                if (toplam == 0) toplam = 1; 

                double yuzdeYapildi = yapildi * 100.0 / toplam;
                double yuzdeYapilmadi = yapilmadi * 100.0 / toplam;

                pieChartDiyet.Series.Clear();
                pieChartDiyet.Series.Add("Durum");

                pieChartDiyet.Series["Durum"].Points.AddXY("Yaptı", yuzdeYapildi);
                pieChartDiyet.Series["Durum"].Points.AddXY("Yapmadı", yuzdeYapilmadi);

                pieChartDiyet.Series["Durum"].IsValueShownAsLabel = true;
                pieChartDiyet.Series["Durum"]["PieLabelStyle"] = "Outside";
                pieChartDiyet.Series["Durum"].Label = "#PERCENT";
                pieChartDiyet.Series["Durum"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            
        }
        }
        private void EgzersizTakipGrafik()
        {
            int yapildi = 0, yapilmadi = 0;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();

                string query = "SELECT Tarih, YapildiMi FROM egzersiz WHERE hastaid = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                HashSet<string> tarihSet = new HashSet<string>();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tarih = Convert.ToDateTime(reader["Tarih"]).ToString("yyyy-MM-dd");
                        tarihSet.Add(tarih);

                        int durum = Convert.ToInt32(reader["YapildiMi"]);
                        if (durum == 1) yapildi++;
                        else yapilmadi++;
                    }
                }

                int toplam = yapildi + yapilmadi;
                if (toplam == 0) toplam = 1; 

                double yuzdeYapildi = yapildi * 100.0 / toplam;
                double yuzdeYapilmadi = yapilmadi * 100.0 / toplam;

                pieChartEgzersiz.Series.Clear();
                pieChartEgzersiz.Series.Add("Durum");

                pieChartEgzersiz.Series["Durum"].Points.AddXY("Yaptı", yuzdeYapildi);
                pieChartEgzersiz.Series["Durum"].Points.AddXY("Yapmadı", yuzdeYapilmadi);

                pieChartEgzersiz.Series["Durum"].IsValueShownAsLabel = true;
                pieChartEgzersiz.Series["Durum"]["PieLabelStyle"] = "Outside";
                pieChartEgzersiz.Series["Durum"].Label = "#PERCENT"; 
                pieChartEgzersiz.Series["Durum"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void sekerEkleButton_Click(object sender, EventArgs e)
        {
            Form Form1 = new hastaSekerEkle(id);
            Form1.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void HastaForm_Load_1(object sender, EventArgs e)
        {

        }

        private void InsulinOnerisiHesapla()
        {
            if (id == -1) return;
            DateTime now = DateTime.Now;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();

                string sql = "SELECT AVG(Seviye) FROM kansekeri WHERE hastaid = @id AND DATE(TarihSaat) = @tarih AND OlcumSaati NOT LIKE 'Saat Dışı Ölçüm'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@tarih", now.ToString("yyyy-MM-dd"));
                object avgObj = cmd.ExecuteScalar();

                int actualBloodAmount;

                string bloodAmountQuery = "SELECT COUNT(DISTINCT OlcumSaati) FROM kansekeri WHERE hastaid = @hid AND DATE(TarihSaat) = @tarih AND OlcumSaati IN ('Sabah', 'Öğlen', 'İkindi', 'Akşam', 'Gece')";
                MySqlCommand cmdCount = new MySqlCommand(bloodAmountQuery, conn);
                cmdCount.Parameters.AddWithValue("@hid", id);
                cmdCount.Parameters.AddWithValue("@tarih", now.ToString("yyyy-MM-dd"));
                actualBloodAmount = Convert.ToInt32(cmdCount.ExecuteScalar());

                int expectedBloodAmount = 0;
                if (actualBloodAmount <= 0)
                {
                    if (now.Hour < 8) expectedBloodAmount = 0;
                    else if (now.Hour < 13) expectedBloodAmount = 1;
                    else if (now.Hour < 16) expectedBloodAmount = 2;
                    else if (now.Hour < 19) expectedBloodAmount = 3;
                    else if (now.Hour < 23) expectedBloodAmount = 4;
                    else expectedBloodAmount = 5;

                    if (actualBloodAmount > expectedBloodAmount) expectedBloodAmount = actualBloodAmount;
                }

                if (avgObj != null && avgObj != DBNull.Value)
                {
                    double ort = Convert.ToDouble(avgObj);
                    string oneri = "";

                    if (actualBloodAmount < expectedBloodAmount)
                    {
                        oneri += "Ölçüm eksik! Ortalama alınırken bu ölçüm hesaba katılmadı.\n";
                    }

                    if (actualBloodAmount <= 3)
                    {
                        oneri += "Yetersiz veri! Ortalama hesaplaması güvenli değildir.\n";
                    }

                    decimal miktar = 0;

                    if (ort < 70)
                    {
                        oneri += "İnsülin Önerisi: Yok (Hipoglisemi)";
                    }
                    else if (ort <= 110)
                    {
                        oneri += "İnsülin Önerisi: Yok (Normal)";
                    }
                    else if (ort <= 150)
                    {
                        miktar = 1;
                        oneri += "İnsülin Önerisi: 1 ml";
                    }
                    else if (ort <= 200)
                    {
                        miktar = 2;
                        oneri += "İnsülin Önerisi: 2 ml";
                    }
                    else
                    {
                        miktar = 3;
                        oneri += "İnsülin Önerisi: 3 ml";
                    }
                    string olcumSaati = "";
                    if (now.Hour >= 7 && now.Hour < 8) olcumSaati = "Sabah";
                    else if (now.Hour >= 12 && now.Hour < 13) olcumSaati = "Öğlen";
                    else if (now.Hour >= 15 && now.Hour < 16) olcumSaati = "İkindi";
                    else if (now.Hour >= 18 && now.Hour < 19) olcumSaati = "Akşam";
                    else if (now.Hour >= 22 && now.Hour < 23) olcumSaati = "Gece";
                    else olcumSaati = "Saat Dışı Ölçüm";

                    lblInsulinOneri.Text = oneri + $" (Ortalama: {ort:F1} mg/dL)";


                    if (miktar > 0)
                    {
                        string insert = "INSERT INTO insulin (hastaid, miktar, tarih,OlcumSaati) VALUES (@hid, @miktar, @tarih,@saat)";
                        MySqlCommand insertCmd = new MySqlCommand(insert, conn);
                        insertCmd.Parameters.AddWithValue("@hid", id);
                        insertCmd.Parameters.AddWithValue("@miktar", miktar);
                        insertCmd.Parameters.AddWithValue("@tarih", now.ToString("yyyy-MM-dd HH:mm:ss"));
                        insertCmd.Parameters.AddWithValue("@saat", olcumSaati);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    lblInsulinOneri.Text = "Hiç ölçüm verisi bulunamadı.";
                }
            }
        }


        private void btnrefresh_Click(object sender, EventArgs e)
        {
            HastaForm_Load(this, EventArgs.Empty);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string bugun = DateTime.Now.ToString("yyyy-MM-dd");
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";

            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();


                string kontrol = "SELECT COUNT(*) FROM egzersiz WHERE hastaid = @hid AND DATE(Tarih) = @bugun";
                MySqlCommand cmdKontrol = new MySqlCommand(kontrol, conn);
                cmdKontrol.Parameters.AddWithValue("@hid", id);
                cmdKontrol.Parameters.AddWithValue("@bugun", bugun);
                int sayi = Convert.ToInt32(cmdKontrol.ExecuteScalar());

                if (sayi > 0)
                {
                    MessageBox.Show("Bugün zaten egzersiz takibini sisteme girdiniz.");
                    return;
                }

                string egzersizBulQuery = "SELECT EgzersizTipi FROM egzersiz WHERE hastaid=@hid ORDER BY EgzersizTipi DESC LIMIT 1 ";
                MySqlCommand cmdDiyetTuru = new MySqlCommand(egzersizBulQuery, conn);
                cmdDiyetTuru.Parameters.AddWithValue("@hid", id);
                string egzersizTuru = cmdDiyetTuru.ExecuteScalar()?.ToString();

                if (string.IsNullOrEmpty(egzersizTuru))
                {
                    MessageBox.Show("Egzersiz türü bulunamadı. Atanmış egzersiziniz bulunmamaktadır.");
                    return;
                }

                DialogResult sonuc = MessageBox.Show("Bugünkü egzersizinizi yaptınız mı?", "Egzersiz Takibi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int yapildimi = (sonuc == DialogResult.Yes) ? 1 : 0;


                string guncelle = "INSERT INTO egzersiz(hastaid,EgzersizTipi,YapildiMi,Tarih) VALUES(@hid,@egzersiz,@yapildimi,@tarih)";
                MySqlCommand cmd = new MySqlCommand(guncelle, conn);
                cmd.Parameters.AddWithValue("@hid", id);
                cmd.Parameters.AddWithValue("@yapildimi", yapildimi);
                cmd.Parameters.AddWithValue("@egzersiz", egzersizTuru);
                cmd.Parameters.AddWithValue("@tarih", bugun);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Egzersiz durumu \"{(yapildimi == 1 ? "Yaptım" : "Yapmadım")}\" olarak kaydedildi.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            İnsülin Form = new İnsülin(id);
            Form.Show();
        }

        private void chartDiyet_Click(object sender, EventArgs e)
        {

        }

        private void alinanOnerilerButton_Click(object sender, EventArgs e)
        {
            hastaAlinanOneriler hastaAlinanOneriler = new hastaAlinanOneriler(id);
            hastaAlinanOneriler.Show();
        }
    }
}