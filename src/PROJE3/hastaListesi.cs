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
using MySql.Data.MySqlClient;

namespace PROJE3
{
    public partial class hastaListesi : Form
    {
        private int doktorid;

        public hastaListesi(int doktorid)
        {
            InitializeComponent();
            this.doktorid = doktorid;
            HastalariYukle();
        }
        private void HastalariYukle()
        {
            flowLayoutPanel1.Controls.Clear();

            string connstr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection con = new MySqlConnection(connstr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanicilar k JOIN hastavedoktorlar h on k.id = h.hastaid WHERE h.doktorid = @did", con);
                cmd.Parameters.AddWithValue("@did", doktorid);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    hastaKart kart = new hastaKart();
                    kart.HastaID = Convert.ToInt32(dr["id"]);
                    kart.AdSoyad = dr["ad"] + " " + dr["soyad"];

                    flowLayoutPanel1.Controls.Add(kart);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void belirtiFiltreButton_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            List<string> secilenBelirtiler = new List<string>();
            if (chkPoliuri.Checked) secilenBelirtiler.Add("Poliüri");
            if (chkPolifaji.Checked) secilenBelirtiler.Add("Polifaji");
            if (chkPolidipsi.Checked) secilenBelirtiler.Add("Polidipsi");
            if (chkNöropati.Checked) secilenBelirtiler.Add("Nöropati");
            if (chkKiloKaybi.Checked) secilenBelirtiler.Add("Kilo kaybı");
            if (chkYorgunluk.Checked) secilenBelirtiler.Add("Yorgunluk");
            if (chkYaralar.Checked) secilenBelirtiler.Add("Yaraların yavaş iyileşmesi");
            if (chkBulanikGorme.Checked) secilenBelirtiler.Add("Bulanık görme");

            string connstr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection con = new MySqlConnection(connstr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanicilar k JOIN hastavedoktorlar h on k.id = h.hastaid WHERE h.doktorid = @did", con);
                cmd.Parameters.AddWithValue("@did", doktorid);
                MySqlDataReader dr = cmd.ExecuteReader();
                using (MySqlConnection con2 = new MySqlConnection(connstr))
                {
                    con2.Open();

                    while (dr.Read())
                    {
                        bool belirtilerUygun = true;

                        foreach (string belirti in secilenBelirtiler)
                        {
                            string belirtiKontrolQuery = "SELECT * FROM belirti WHERE hastaid = @hid AND BelirtiTipi LIKE @belirti";
                            MySqlCommand belirtiCmd = new MySqlCommand(belirtiKontrolQuery, con2);
                            belirtiCmd.Parameters.AddWithValue("@hid", dr["id"]);
                            belirtiCmd.Parameters.AddWithValue("@belirti", "%" + belirti + "%");
                            object result = belirtiCmd.ExecuteScalar();
                            if (result == null)
                            {
                                belirtilerUygun = false;
                                break;
                            }
                        }
                        if (belirtilerUygun)
                        {
                            hastaKart kart = new hastaKart();
                            kart.HastaID = Convert.ToInt32(dr["id"]);
                            kart.AdSoyad = dr["ad"] + " " + dr["soyad"];

                            flowLayoutPanel1.Controls.Add(kart);
                        }
                    }
                }
                
            }

        }

        private void txtBloodVal_TextChanged(object sender, EventArgs e)
        {

        }

        private void ortalamaFiltreButton_Click(object sender, EventArgs e)
        {
            string kansekeriRead = txtBloodVal.Text.Trim();
            float istenenOrtalamaTavan = 1;

            if (string.IsNullOrEmpty(kansekeriRead))
            {
                MessageBox.Show("Lütfen bir kan şekeri değeri girin.");
                return;
            }
            else {istenenOrtalamaTavan = float.Parse(kansekeriRead);}

            flowLayoutPanel1.Controls.Clear();
            string connstr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection con = new MySqlConnection(connstr))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT ku.id, ku.ad, ku.soyad, AVG(k.Seviye) AS ortalama_seker FROM kullanicilar ku JOIN hastavedoktorlar h on ku.id = h.hastaid JOIN kansekeri k ON h.hastaid=k.hastaid WHERE h.doktorid = @did GROUP BY ku.id, ku.ad , ku.soyad HAVING AVG(k.Seviye)<@istenenDeger;", con);
                cmd.Parameters.AddWithValue("@did", doktorid);
                cmd.Parameters.AddWithValue("@istenenDeger", istenenOrtalamaTavan);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    hastaKart kart = new hastaKart();
                    kart.HastaID = Convert.ToInt32(dr["id"]);
                    kart.AdSoyad = dr["ad"] + " " + dr["soyad"];

                    flowLayoutPanel1.Controls.Add(kart);
                }

            }

        }
    }
}
