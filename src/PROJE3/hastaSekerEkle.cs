using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PROJE3
{
   
    public partial class hastaSekerEkle : Form
    {
      
        private int hastaid;

        public hastaSekerEkle(int hastaid)
        {
            this.hastaid = hastaid;
            InitializeComponent();
        }
        private void UyariOlustur(int hastaid)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                
                string sql = @"SELECT Seviye, TarihSaat FROM kansekeri
                        WHERE hastaid = @hastaid
                        ORDER BY TarihSaat DESC LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@hastaid", hastaid);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int seviye = Convert.ToInt32(reader["Seviye"]);
                            DateTime zaman = Convert.ToDateTime(reader["TarihSaat"]);

                            string uyaritipi = null;
                            string mesaj = null;

                            if (seviye < 40)
                            {
                                uyaritipi = "Acil Uyarı";
                                mesaj = "Hipoglisemi (çok düşük kan şekeri)";
                            }
                            else if (seviye >= 180)
                            {
                                uyaritipi = "Acil Uyarı";
                                mesaj = "Hiperglisemi (çok yüksek kan şekeri)";
                            }
                            else if (seviye < 70)
                            {
                                uyaritipi = "Uyarı";
                                mesaj = "Kan şekeri düşük sınırın altında";
                            }
                            else if (seviye > 180)
                            {
                                uyaritipi = "Uyarı";
                                mesaj = "Kan şekeri yüksek sınırın üstünde";
                            }
                            reader.Close();
                            if (uyaritipi != null)
                            {
                                
                                string drQuery = "SELECT doktorid FROM hastavedoktorlar WHERE hastaid = @hastaid";
                                using (MySqlCommand cmdDoktor = new MySqlCommand(drQuery, conn))
                                {
                                    cmdDoktor.Parameters.AddWithValue("@hastaid", hastaid);
                                    object drID = cmdDoktor.ExecuteScalar();

                                    if (drID != null)
                                    {
                                        int doktorID = Convert.ToInt32(drID);

                                        
                                        string insert = @"INSERT INTO uyari
                                    (hastaid, doktorid, uyaritipi, uyarimesaji, tarihsaat, KanSekeriSeviyesi)
                                    VALUES (@hastaid, @doktorid, @tip, @mesaj, @tarih, @ks)";
                                        using (MySqlCommand cmdInsert = new MySqlCommand(insert, conn))
                                        {
                                            cmdInsert.Parameters.AddWithValue("@hastaid", hastaid);
                                            cmdInsert.Parameters.AddWithValue("@doktorid", doktorID);
                                            cmdInsert.Parameters.AddWithValue("@tip", uyaritipi);
                                            cmdInsert.Parameters.AddWithValue("@mesaj", mesaj);
                                            cmdInsert.Parameters.AddWithValue("@tarih", zaman);
                                            cmdInsert.Parameters.AddWithValue("@ks", seviye);
                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ekleButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sekerTxtBox.Text))
            {
                MessageBox.Show("Lütfen ölçülen değeri girin.");
                return;
            }

            decimal kansekeri;
            if (!decimal.TryParse(sekerTxtBox.Text.Trim(), out kansekeri))
            {
                MessageBox.Show("Geçerli bir sayı giriniz.");
                return;
            }

             DateTime simdikiZaman = DateTime.Now;
            TimeSpan sabahBas = new TimeSpan(7, 0, 0);
            TimeSpan sabahBit = new TimeSpan(8, 0, 0);
            TimeSpan ogleBas = new TimeSpan(12, 0, 0);
            TimeSpan ogleBit = new TimeSpan(13, 0, 0);
            TimeSpan ikindiBas = new TimeSpan(15, 0, 0);
            TimeSpan ikindiBit = new TimeSpan(16, 0, 0);
            TimeSpan aksamBas = new TimeSpan(18, 0, 0);
            TimeSpan aksamBit = new TimeSpan(19, 0, 0);
            TimeSpan geceBas = new TimeSpan(22, 0, 0);
            TimeSpan geceBit = new TimeSpan(23, 0, 0);

            string olcumSaati;

            if (simdikiZaman.TimeOfDay >= sabahBas && simdikiZaman.TimeOfDay <= sabahBit)
            {
                olcumSaati = "Sabah";
            }
            else if (simdikiZaman.TimeOfDay >= ogleBas && simdikiZaman.TimeOfDay <= ogleBit)
            {
                olcumSaati = "Öğlen";
            }
            else if (simdikiZaman.TimeOfDay >= ikindiBas && simdikiZaman.TimeOfDay <= ikindiBit)
            {
                olcumSaati = "İkindi";
            }
            else if (simdikiZaman.TimeOfDay >= aksamBas && simdikiZaman.TimeOfDay <= aksamBit)
            {
                olcumSaati = "Akşam";
            }
            else if (simdikiZaman.TimeOfDay >= geceBas && simdikiZaman.TimeOfDay <= geceBit)
            {
                olcumSaati = "Gece";
            }
            else
            {
                MessageBox.Show("Ölçümünüz saat aralıkları dışında yapılmış olup ortalamaya katılmayacaktır.");
                olcumSaati = "Saat Dışı Ölçüm"; 
            }

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
                try {
                    conn.Open();
                    string query = "INSERT INTO kansekeri (hastaid,TarihSaat,Seviye,OlcumSaati) " +
                                   "VALUES (@hastaid, @TarihSaat, @Seviye, @OlcumSaati)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@hastaid", this.hastaid);
                    cmd.Parameters.AddWithValue("@TarihSaat", simdikiZaman.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@Seviye", kansekeri);
                    cmd.Parameters.AddWithValue("@OlcumSaati", olcumSaati);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Kanşekeri başarıyla eklendi.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kanşekeri eklenemedi.");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            UyariOlustur(hastaid);
        }

        private void hastaSekerEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
