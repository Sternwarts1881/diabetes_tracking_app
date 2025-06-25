using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PROJE3
{
    public partial class hastaDetaylariForm : Form
    {
        private int hastaid;

        public hastaDetaylariForm(int hastaid)
        {
            InitializeComponent();
            this.hastaid = hastaid;
            DiyetTakipGrafik();
            EgzersizTakipGrafik();
            KanSekeriGrafikCiz();
            GenelDurumGrafikCiz();
        }

        private void hastaDetaylariForm_Load(object sender, EventArgs e)
        {
            string connstr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Open();

                
                using (MySqlCommand cmd = new MySqlCommand("SELECT tcno, Ad, Soyad, email, Dogum_Tarihi, Cinsiyet FROM kullanicilar WHERE id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", hastaid);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblTC.Text = reader["tcno"].ToString();
                            lblAd.Text = reader["Ad"].ToString();
                            lblSoyad.Text = reader["Soyad"].ToString();
                            lblMail.Text = reader["email"].ToString();
                            lblDogum.Text = Convert.ToDateTime(reader["Dogum_Tarihi"]).ToShortDateString();
                            lblCinsiyet.Text = reader["Cinsiyet"].ToString();
                        }
                    }
                }

               
                using (MySqlCommand belirtiCmd = new MySqlCommand("SELECT BelirtiTipi FROM Belirti WHERE hastaid = @id", conn))
                {
                    belirtiCmd.Parameters.AddWithValue("@id", hastaid);
                    using (MySqlDataReader belirtiReader = belirtiCmd.ExecuteReader())
                    {
                        while (belirtiReader.Read())
                        {
                            listBoxBelirtiler.Items.Add(belirtiReader["BelirtiTipi"].ToString());
                        }
                    }
                }

                
                using (MySqlCommand diyetCmd = new MySqlCommand("SELECT DiyetTipi FROM diyet WHERE hastaid = @id", conn))
                {
                    diyetCmd.Parameters.AddWithValue("@id", hastaid);
                    using (MySqlDataReader diyetReader = diyetCmd.ExecuteReader())
                    {
                        if (diyetReader.Read())
                        {
                            lblDiyet.Text = diyetReader["DiyetTipi"].ToString();
                        }
                        else
                        {
                            lblDiyet.Text = "Tanımlı değil";
                        }
                    }
                }

                
                using (MySqlCommand egzersizCmd = new MySqlCommand("SELECT EgzersizTipi FROM Egzersiz WHERE hastaid = @id", conn))
                {
                    egzersizCmd.Parameters.AddWithValue("@id", hastaid);
                    using (MySqlDataReader egzersizReader = egzersizCmd.ExecuteReader())
                    {
                        if (egzersizReader.Read())
                        {
                            lblEgzersiz.Text = egzersizReader["EgzersizTipi"].ToString();
                        }
                        else
                        {
                            lblEgzersiz.Text = "Tanımlı değil";
                        }
                    }
                }

                conn.Close();
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void DiyetTakipGrafik()
        {
            int yapildi = 0, yapilmadi = 0;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Tarih, UygulandiMi FROM diyet WHERE hastaid = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", hastaid);

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
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT Tarih, YapildiMi FROM egzersiz WHERE hastaid = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", hastaid);

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
        private void KanSekeriGrafikCiz()
        {
            chartSeker.Series.Clear();
            chartSeker.Titles.Clear();
            chartSeker.Titles.Add("Geçmiş Kan Şekeri Değerleri");

            Series seri = new Series("Kan Sekeri Seviyesi mg/dL");
            seri.ChartType = SeriesChartType.Column;
            seri.XValueType = ChartValueType.DateTime;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT TarihSaat, Seviye FROM kansekeri WHERE hastaid = @hid ORDER BY TarihSaat ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hid", hastaid);

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

        private void kanButton_Click(object sender, EventArgs e)
        {
            hastaKanDegerleri form = new hastaKanDegerleri(hastaid);
            form.Show();
        }

        private void diyetButton_Click(object sender, EventArgs e)
        {
            hastaDiyetTablosu form = new hastaDiyetTablosu(hastaid);
            form.Show();
        }

        private void egzersizButton_Click(object sender, EventArgs e)
        {
            hastaEgzersizTablosu form = new hastaEgzersizTablosu(hastaid);
            form.Show();

        }

        private void hastaBildirimButton_Click(object sender, EventArgs e)
        {
            hastaBildirimTablosu form = new hastaBildirimTablosu(hastaid);
            form.Show();
        }

        private void chartDiyet_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void GenelDurumGrafikCiz()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Geçmiş Sağlık Verileri");

            Series kanSerisi = new Series("Kan Şekeri");
            kanSerisi.ChartType = SeriesChartType.Line;
            kanSerisi.Color = Color.Blue;
            kanSerisi.BorderWidth = 2;

            Series diyetSerisi = new Series("Diyet Takibi (%)");
            diyetSerisi.ChartType = SeriesChartType.Line;
            diyetSerisi.Color = Color.Green;
            diyetSerisi.BorderDashStyle = ChartDashStyle.Dash;
            diyetSerisi.BorderWidth = 2;

            Series egzersizSerisi = new Series("Egzersiz Takibi (%)");
            egzersizSerisi.ChartType = SeriesChartType.Line;
            egzersizSerisi.Color = Color.OrangeRed;
            egzersizSerisi.BorderDashStyle = ChartDashStyle.Dash;
            egzersizSerisi.BorderWidth = 2;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            Dictionary<string, double> kanDegerleri = new Dictionary<string, double>();
            Dictionary<string, int> diyetTakip = new Dictionary<string, int>();
            Dictionary<string, int> egzersizTakip = new Dictionary<string, int>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                
                string sql1 = "SELECT DATE(TarihSaat) as Tarih, AVG(Seviye) as Ortalama FROM kansekeri WHERE hastaid = @id GROUP BY DATE(TarihSaat)";
                MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@id", hastaid);
                using (var reader = cmd1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tarih = Convert.ToDateTime(reader["Tarih"]).ToString("yyyy-MM-dd");
                        double seviye = Convert.ToDouble(reader["Ortalama"]);
                        kanDegerleri[tarih] = seviye;
                    }
                }

             
                string sql2 = "SELECT DATE(Tarih) as Tarih, UygulandiMi FROM diyet WHERE hastaid = @id";
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", hastaid);
                using (var reader = cmd2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tarih = Convert.ToDateTime(reader["Tarih"]).ToString("yyyy-MM-dd");
                        int yapildi = Convert.ToInt32(reader["UygulandiMi"]);
                        diyetTakip[tarih] = yapildi == 1 ? 100 : 0;
                    }
                }

                
                string sql3 = "SELECT DATE(Tarih) as Tarih, YapildiMi FROM egzersiz WHERE hastaid = @id";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@id", hastaid);
                using (var reader = cmd3.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tarih = Convert.ToDateTime(reader["Tarih"]).ToString("yyyy-MM-dd");
                        int yapildi = Convert.ToInt32(reader["YapildiMi"]);
                        egzersizTakip[tarih] = yapildi == 1 ? 100 : 0;
                    }
                }
            }

     
            var tumTarihler = kanDegerleri.Keys
                                .Union(diyetTakip.Keys)
                                .Union(egzersizTakip.Keys)
                                .Distinct()
                                .OrderBy(x => x);

            foreach (string tarih in tumTarihler)
            {
                double kanDeger = kanDegerleri.ContainsKey(tarih) ? kanDegerleri[tarih] : 0;
                double diyet = diyetTakip.ContainsKey(tarih) ? diyetTakip[tarih] : 0;
                double egzersiz = egzersizTakip.ContainsKey(tarih) ? egzersizTakip[tarih] : 0;

                kanSerisi.Points.AddXY(tarih, kanDeger);
                diyetSerisi.Points.AddXY(tarih, diyet);
                egzersizSerisi.Points.AddXY(tarih, egzersiz);
            }

            chart1.Series.Add(kanSerisi);
            chart1.Series.Add(diyetSerisi);
            chart1.Series.Add(egzersizSerisi);

            chart1.ChartAreas[0].AxisX.Title = "Tarih";
            chart1.ChartAreas[0].AxisY.Title = "Değer";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 250;
            chart1.Legends[0].Docking = Docking.Top;
        }

    }
}
