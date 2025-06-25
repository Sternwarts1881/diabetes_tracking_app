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
    public partial class doktorGonderilenOneriler : Form
    {
        private int id;

        public doktorGonderilenOneriler(int id)
        {
            InitializeComponent();
            this.id = id;
            this.Load += new EventHandler(doktorGonderilenOneriler_Load);
        }

        private void doktorGonderilenOneriler_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                try
                {
                    conn.Open();
                    string query = "SELECT OneriMetni, hastaid, TarihSaat FROM oneri WHERE doktorid = @did";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@did", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                                dataGridView1.Rows.Add(
                                    reader["OneriMetni"].ToString(),
                                    reader["hastaid"].ToString(),
                                    reader["TarihSaat"].ToString()

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
            MySqlConnection conn = DbConnectionFactory.CreateConnection();
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT OneriMetni, hastaid, TarihSaat FROM oneri WHERE doktorid = @did 
                             AND TarihSaat BETWEEN @baslangic AND @bitis
                             ORDER BY TarihSaat DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@did", id);
                    cmd.Parameters.AddWithValue("@baslangic", baslangic);
                    cmd.Parameters.AddWithValue("@bitis", bitis);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                reader["OneriMetni"].ToString(),
                                reader["hastaid"].ToString(),
                                reader["TarihSaat"].ToString()

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

    

