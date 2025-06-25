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
    public partial class hastaAlinanOneriler : Form
    {
        private int id;

        public hastaAlinanOneriler(int id)
        {
            InitializeComponent();
            this.id = id;
            this.Load += new EventHandler(hastaAlinanOneriler_Load);
        }

        private void hastaAlinanOneriler_Load(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT OneriMetni, TarihSaat FROM oneri WHERE hastaid = @did";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@did", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        { 
                                dataGridView1.Rows.Add(
                                    reader["OneriMetni"].ToString(),
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
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT OneriMetni, TarihSaat FROM oneri WHERE hastaid = @did 
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

    

