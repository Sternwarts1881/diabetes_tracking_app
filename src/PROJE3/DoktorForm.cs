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
using System.IO;

namespace PROJE3
{
    public partial class DoktorForm : Form
    {
        private int doktorID;
        private string kullaniciTC;

        public DoktorForm(string tc)
        {
            InitializeComponent();
            kullaniciTC = tc;

            this.Text = "Doktor Paneli - " + kullaniciTC;

            this.Load += new EventHandler(DoktorForm_Load); 


            bool kontrolYapildiMi = false;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT id FROM kullanicilar WHERE tcno = @tc AND rol = 'doktor'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", tc);

                object result = cmd.ExecuteScalar();
                if (result != null)
                    doktorID = Convert.ToInt32(result);
                else
                    MessageBox.Show("Doktor bilgisi alınamadı.");

                
                
                string kontrolQuery = "SELECT COUNT(UyariID) FROM uyari WHERE doktorid = @did AND DATE(TarihSaat) = @date";
                MySqlCommand kontrolCMD = new MySqlCommand(kontrolQuery, conn);
                kontrolCMD.Parameters.AddWithValue("@did", doktorID);
                kontrolCMD.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));

                int kontrolSonucu = Convert.ToInt32(kontrolCMD.ExecuteScalar());
                if (kontrolSonucu > 0) kontrolYapildiMi = true;

            }





            if (DateTime.Now.Hour >= 23 && !kontrolYapildiMi) hastalariKontrolEt();
        }



        private void mainbutton_Click(object sender, EventArgs e)
        {
            Form Form1 = new GirişForm();

            Form1.Show();

            this.Hide();
        }
        private void DoktorForm_Load(object sender, EventArgs e)
        {

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ad, soyad, email, dogum_tarihi, cinsiyet, profil_resmi FROM kullanicilar WHERE tcno = @tc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", kullaniciTC);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblAd.Text = reader["ad"].ToString();
                        lblSoyad.Text = reader["soyad"].ToString();
                        lblEmail.Text = reader["email"].ToString();
                        lblCinsiyet.Text = reader["cinsiyet"].ToString();
                        lblDogumTarihi.Text = Convert.ToDateTime(reader["dogum_tarihi"]).ToShortDateString();

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
                        MessageBox.Show("Doktor bilgileri bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaEkle form = new HastaEkle(doktorID);
            form.ShowDialog();
        }

        private void lbl5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form1 = new GirişForm();
            Form1.Show();

            this.Hide();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void DoktorForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnHastaekle_Click(object sender, EventArgs e)
        {


            HastaEkle form = new HastaEkle(doktorID);
            form.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void hastabilgibtn_Click(object sender, EventArgs e)
        {

        }

        private void hastabilgibtn_Click_1(object sender, EventArgs e)
        {
            hastaListesi form = new hastaListesi(doktorID);
            form.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            DoktorBildirim form = new DoktorBildirim(doktorID);
            form.Show();

        }

        private void hastalariKontrolEt()
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
                try
                {
                    conn.Open();
                    string doktorunHastalariQuery = @"SELECT hastaid
                                                FROM hastavedoktorlar
                                                WHERE doktorid=@did";
                    MySqlCommand doktorHastalariCMD = new MySqlCommand(doktorunHastalariQuery, conn);
                    doktorHastalariCMD.Parameters.AddWithValue("@did", doktorID);
                    List<int> doktorHastaIdleri = new List<int>();
                    using (MySqlDataReader reader = doktorHastalariCMD.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int hastaId = Convert.ToInt32(reader["hastaid"]);
                            doktorHastaIdleri.Add(hastaId);
                        }
                    }

                    if (doktorHastaIdleri.Count == 0)
                    {
                        MessageBox.Show("Henüz hasta eklenmemiş.");
                        return;
                    }

                    DateTime simdikiZaman = DateTime.Now;

                    for (int i = 0; i < doktorHastaIdleri.Count; i++)
                    {
                        int olcumSayisiCheck = 0;
                        string query = "SELECT COUNT(KanSekeriID) FROM kansekeri WHERE hastaid = @hid AND DATE(TarihSaat) = @tarih";
                        MySqlCommand olcumSayisiCMD = new MySqlCommand(query, conn);
                        olcumSayisiCMD.Parameters.AddWithValue("@hid", doktorHastaIdleri[i]);
                        olcumSayisiCMD.Parameters.AddWithValue("@tarih", simdikiZaman.ToString("yyyy-MM-dd"));

                        olcumSayisiCheck = Convert.ToInt32(olcumSayisiCMD.ExecuteScalar());

                        string uyariTipi;
                        string mesaj;


                        if (olcumSayisiCheck <= 0)
                        {
                            uyariTipi = "Ölçüm Eksik Uyarısı";
                            mesaj = "Hasta gün boyunca kan şekeri ölçümü yapmamıştır.Acil takip önerilir.";

                        }
                        else if (olcumSayisiCheck > 0 && olcumSayisiCheck < 3)
                        {
                            uyariTipi = "Ölçüm Yetersiz Uyarısı ";
                            mesaj = "Hastanın günlük kan şekeri ölçüm sayısı yetersiz (<3).Durum izlenmelidir.";
                        }
                        else continue;

                        string uyariQuery = "INSERT INTO uyari(hastaid,doktorid,UyariTipi,UyariMesaji,TarihSaat,KanSekeriSeviyesi) VALUES (@hid,@did,@uyariTipi,@UyariMesaji,@TarihSaat,NULL)";

                        MySqlCommand uyariCMD = new MySqlCommand(uyariQuery, conn);
                        uyariCMD.Parameters.AddWithValue("@hid", doktorHastaIdleri[i]);
                        uyariCMD.Parameters.AddWithValue("@did", doktorID);
                        uyariCMD.Parameters.AddWithValue("@uyariTipi", uyariTipi);
                        uyariCMD.Parameters.AddWithValue("@UyariMesaji", mesaj);
                        uyariCMD.Parameters.AddWithValue("@TarihSaat", simdikiZaman.ToString("yyyy-MM-dd HH:mm:ss"));
                        uyariCMD.ExecuteNonQuery();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DoktorForm_Load(this,EventArgs.Empty);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doktorOneriGonder form = new doktorOneriGonder(doktorID);
            form.ShowDialog();
        }

        private void gonderilenOnerilerButton_Click(object sender, EventArgs e)
        {
            doktorGonderilenOneriler form = new doktorGonderilenOneriler(doktorID);
            form.ShowDialog();
        }
    }


}