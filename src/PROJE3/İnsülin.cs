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
    public partial class İnsülin : Form
    {
        private int hastaid;
        public İnsülin(int hastaid)
        {
            InitializeComponent();
            this.hastaid = hastaid;
            this.Load += InsulinForm_Load;
        }

        private void InsulinForm_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();

                DateTime baslangicTarih = DateTime.Today.AddDays(-13);
                DateTime bitisTarih = DateTime.Today;

                string sql = "SELECT DATE(tarih) AS gun, OlcumSaati, miktar FROM insulin " +
                             "WHERE hastaid = @hid AND DATE(tarih) BETWEEN @baslangic AND @bitis " +
                             "ORDER BY gun DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hid", hastaid);
                cmd.Parameters.AddWithValue("@baslangic", baslangicTarih.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@bitis", bitisTarih.ToString("yyyy-MM-dd"));

                var saatler = new List<string> { "Sabah", "Öğlen", "İkindi", "Akşam", "Gece" };


                var veri = new Dictionary<string, Dictionary<string, string>>();
                for (int i = 0; i <= (bitisTarih - baslangicTarih).Days; i++)
                {
                    string gun = baslangicTarih.AddDays(i).ToString("yyyy-MM-dd");
                    veri[gun] = new Dictionary<string, string>();
                    foreach (var saat in saatler)
                        veri[gun][saat] = "—";
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gun = Convert.ToDateTime(reader["gun"]).ToString("yyyy-MM-dd");
                        string saat = reader["OlcumSaati"].ToString();
                        string miktar = reader["miktar"].ToString() + " ml";

                        if (veri.ContainsKey(gun) && veri[gun].ContainsKey(saat))
                            veri[gun][saat] = miktar;
                    }
                }

                dgvInsulin.Columns.Clear();
                dgvInsulin.Rows.Clear();

                dgvInsulin.Columns.Add("Tarih", "Tarih");
                foreach (var saat in saatler)
                    dgvInsulin.Columns.Add(saat, saat);

                foreach (var gun in veri.OrderByDescending(x => x.Key))
                {
                    var row = new List<string> { DateTime.Parse(gun.Key).ToString("dd.MM.yyyy") };
                    foreach (var saat in saatler)
                        row.Add(veri[gun.Key][saat]);

                    dgvInsulin.Rows.Add(row.ToArray());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvInsulin.Columns.Clear();
            dgvInsulin.Rows.Clear();

            DateTime baslangic = dtpBaslangic.Value.Date;
            DateTime bitis = dtpBitis.Value.Date;

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                conn.Open();

                string sql = @"
            SELECT DATE(tarih) AS gun, OlcumSaati, miktar 
            FROM insulin 
            WHERE hastaid = @hid AND DATE(tarih) BETWEEN @baslangic AND @bitis
            ORDER BY gun DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@hid", hastaid);
                cmd.Parameters.AddWithValue("@baslangic", baslangic);
                cmd.Parameters.AddWithValue("@bitis", bitis);

                dgvInsulin.Columns.Add("Tarih", "Tarih");
                dgvInsulin.Columns.Add("Sabah", "Sabah");
                dgvInsulin.Columns.Add("Öğlen", "Öğlen");
                dgvInsulin.Columns.Add("İkindi", "İkindi");
                dgvInsulin.Columns.Add("Akşam", "Akşam");
                dgvInsulin.Columns.Add("Gece", "Gece");

             
                var veri = new Dictionary<string, Dictionary<string, string>>();
                var saatler = new[] { "Sabah", "Öğlen", "İkindi", "Akşam", "Gece" };

                for (DateTime tarih = baslangic; tarih <= bitis; tarih = tarih.AddDays(1))
                {
                    string gun = tarih.ToString("yyyy-MM-dd");
                    veri[gun] = new Dictionary<string, string>();
                    foreach (var saat in saatler)
                        veri[gun][saat] = "–";
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gun = Convert.ToDateTime(reader["gun"]).ToString("yyyy-MM-dd");
                        string saat = reader["OlcumSaati"].ToString();
                        string miktar = reader["miktar"].ToString() + " ml";

                        if (veri.ContainsKey(gun) && veri[gun].ContainsKey(saat))
                            veri[gun][saat] = miktar;
                    }
                }

               
                foreach (var gun in veri.OrderByDescending(x => x.Key))
                {
                    dgvInsulin.Rows.Add(
                        DateTime.Parse(gun.Key).ToString("dd.MM.yyyy"),
                        veri[gun.Key]["Sabah"],
                        veri[gun.Key]["Öğlen"],
                        veri[gun.Key]["İkindi"],
                        veri[gun.Key]["Akşam"],
                        veri[gun.Key]["Gece"]
                    );
                }
            }
        }
    }
}
