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
using MySql.Data.MySqlClient;

namespace PROJE3
{
    public partial class hastaDiyetTablosu : Form
    {
        private int id;

        public hastaDiyetTablosu(int id)
        {
            InitializeComponent();
            this.id = id;
            this.Load += new EventHandler(HastaForm_Load);
        }

        private void HastaForm_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Tarih, DiyetTipi, UygulandiMi FROM diyet WHERE hastaid = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                            int yapildimi = reader.GetInt32(reader.GetOrdinal("UygulandiMi"));
                            string yapildistring;
                            if (yapildimi == 1) yapildistring = "Evet";
                            else yapildistring = "Hayır";

                                dataGridView1.Rows.Add(
                                    reader["Tarih"].ToString(),
                                    reader["DiyetTipi"].ToString(),
                                    yapildistring
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            DateTime baslangic = dtpBaslangic.Value.Date;
            DateTime bitis = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1); 

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT Tarih, DiyetTipi, UygulandiMi 
                             FROM diyet 
                             WHERE hastaid = @id 
                             AND Tarih BETWEEN @baslangic AND @bitis
                             ORDER BY Tarih DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@baslangic", baslangic);
                    cmd.Parameters.AddWithValue("@bitis", bitis);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int yapildimi = Convert.ToInt32(reader["UygulandiMi"]);
                            string yapildistring = (yapildimi == 1) ? "Evet" : "Hayır";

                            dataGridView1.Rows.Add(
                                Convert.ToDateTime(reader["Tarih"]).ToString("dd.MM.yyyy"),
                                reader["DiyetTipi"].ToString(),
                                yapildistring
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

        }
    }
}

    

