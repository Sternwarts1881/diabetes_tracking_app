using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace PROJE3
{
    public partial class HastaEkle : Form
    {
        private int doktorID;

        private string Sha256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public HastaEkle(int doktorID)
        {
            this.doktorID = doktorID;
            InitializeComponent();
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtSoyad_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void SifreyiMaileGonder(string hastaEmail, string hastaAd, string hastaSifre, string tcno)
        {
            string gonderenMail = "prolabornekhesap@gmail.com";
            string gonderenSifre = "vcrc mdno iqro dyxk";
            string konu = "Diyabet Takip Sistemi - Şifre Bilginiz";
            string icerik = $"Merhaba {hastaAd},\n\nSisteme giriş şifreniz: {hastaSifre}\n\nTC Kimlik Numaranız : {tcno} \n\n Diyabet Takip Sistemi";

            MailMessage mesaj = new MailMessage();
            mesaj.From = new MailAddress(gonderenMail);
            mesaj.To.Add(hastaEmail);
            mesaj.Subject = konu;
            mesaj.Body = icerik;

            SmtpClient istemci = new SmtpClient("smtp.gmail.com", 587);
            istemci.Credentials = new NetworkCredential(gonderenMail, gonderenSifre);
            istemci.EnableSsl = true;

            try
            {
                istemci.Send(mesaj);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilemedi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tc = txtTC.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string email = txtEmail.Text.Trim();
            string cinsiyet = cmbCinsiyet.SelectedItem?.ToString() ?? "";
            DateTime dogumTarihi = dtpDogumTarihi.Value;
            string kansekeriRead = txtBloodVal.Text.Trim();
           
            byte[] resimVerisi = null;
            if (pictureBoxProfil.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBoxProfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    resimVerisi = ms.ToArray();
                }
            }

            if (tc == "" || sifre == "" || ad == "" || soyad == "" || email == "" || cinsiyet == "" || kansekeriRead == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }
            string hashliSifre = Sha256Hash(sifre);
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO kullanicilar (tcno, sifre_hash, ad, soyad, email, dogum_tarihi, cinsiyet, rol,profil_resmi) " +
                                   "VALUES (@tc, @sifre, @ad, @soyad, @email, @dogum, @cinsiyet, 'hasta',@profil_resmi)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@sifre", hashliSifre);
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@dogum", dogumTarihi.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                    cmd.Parameters.AddWithValue("@profil_resmi", resimVerisi);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Kullanıcı eklenemedi.");
                        return;
                    }

                    
                    string hastaIDQuery = "SELECT id FROM kullanicilar WHERE tcno = @hastatc;";
                    MySqlCommand hastaIDCmd = new MySqlCommand(hastaIDQuery, conn);
                    hastaIDCmd.Parameters.AddWithValue("@hastatc", tc);
                    object hastaIDResult = hastaIDCmd.ExecuteScalar();
                    if (hastaIDResult == null)
                    {
                        MessageBox.Show("Hasta ID alınamadı.");
                        return;
                    }
                    int hastaID = Convert.ToInt32(hastaIDResult);
                    decimal kansekeri = Convert.ToDecimal(kansekeriRead);

                    
                    string hastaDoktorEsleme = "INSERT INTO hastavedoktorlar (doktorid, hastaid) VALUES (@did,@hid)";
                    MySqlCommand eslesmeCMD = new MySqlCommand(hastaDoktorEsleme, conn);
                    eslesmeCMD.Parameters.AddWithValue("@did", doktorID);
                    eslesmeCMD.Parameters.AddWithValue("@hid", hastaID);
                    int eslesmeResult = eslesmeCMD.ExecuteNonQuery();
                    if (eslesmeResult == 0)
                    {
                        MessageBox.Show("Hasta-Doktor eşleşmesi yapılamadı.");
                        return;
                    }

                    
                    string kanEkleme = "INSERT INTO kansekeri (hastaid, TarihSaat, Seviye, OlcumSaati) VALUES (@hastaid,@TarihSaat,@Seviye,@OlcumSaati)";
                    MySqlCommand kanEklemeCMD = new MySqlCommand(kanEkleme, conn);
                    kanEklemeCMD.Parameters.AddWithValue("@hastaid", hastaID);
                    kanEklemeCMD.Parameters.AddWithValue("@TarihSaat", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    kanEklemeCMD.Parameters.AddWithValue("@Seviye", kansekeri);
                    kanEklemeCMD.Parameters.AddWithValue("@OlcumSaati", "İlk Tahlil");



                    int result = kanEklemeCMD.ExecuteNonQuery();


                    List<string> secilenBelirtiler = new List<string>();
                    if (chkPoliuri.Checked) secilenBelirtiler.Add("Poliüri");
                    if (chkPolifaji.Checked) secilenBelirtiler.Add("Polifaji");
                    if (chkPolidipsi.Checked) secilenBelirtiler.Add("Polidipsi");
                    if (chkNöropati.Checked) secilenBelirtiler.Add("Nöropati");
                    if (chkKiloKaybi.Checked) secilenBelirtiler.Add("Kilo kaybı");
                    if (chkYorgunluk.Checked) secilenBelirtiler.Add("Yorgunluk");
                    if (chkYaralar.Checked) secilenBelirtiler.Add("Yaraların yavaş iyileşmesi");
                    if (chkBulanikGorme.Checked) secilenBelirtiler.Add("Bulanık görme");

                    foreach (string belirti in secilenBelirtiler)
                    {
                        string belirtiQuery = "INSERT INTO belirti (hastaid, belirtitipi, tarih) VALUES (@hid, @tip, @tarih)";
                        MySqlCommand belirtiCMD = new MySqlCommand(belirtiQuery, conn);
                        belirtiCMD.Parameters.AddWithValue("@hid", hastaID);
                        belirtiCMD.Parameters.AddWithValue("@tip", belirti);
                        belirtiCMD.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        belirtiCMD.ExecuteNonQuery();
                    }

                    if (result > 0)
                    {

                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Hasta eklenemedi.");

                    }

                    SifreyiMaileGonder(email, ad, sifre, tc);
                    DiyetEgzersizOneriForm form = new DiyetEgzersizOneriForm(tc, sifre, ad, soyad, email, dogumTarihi, cinsiyet, kansekeriRead, secilenBelirtiler, doktorID, hastaID);
                    form.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }

            }

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HastaEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnFotoSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Profil Fotoğrafı Seç";
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfil.Image = Image.FromFile(ofd.FileName);
                pictureBoxProfil.Tag = ofd.FileName;
            }
        }
    }
}
