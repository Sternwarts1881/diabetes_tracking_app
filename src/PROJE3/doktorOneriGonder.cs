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
using MySql.Data.MySqlClient;

namespace PROJE3
{
    public partial class doktorOneriGonder : Form
    {
        private int doktorid;

        public doktorOneriGonder(int doktorid)
        {
            InitializeComponent();
            this.doktorid = doktorid;
        }

        private void gonderButton_Click(object sender, EventArgs e)
        {
            int hastaid = -1;
            hastaid = Hastabul();
            if (hastaid == -1)
            {
                MessageBox.Show("Hasta bulunamadı.");
                return;
            }

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";

            string oneri = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(oneri))
            {
                MessageBox.Show("Lütfen öneri metnini giriniz.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO oneri (doktorid, hastaid, OneriMetni,TarihSaat) VALUES (@doktorId, @hastaId, @oneri,@tarih)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@doktorId", doktorid);
                    cmd.Parameters.AddWithValue("@hastaId", hastaid);
                    cmd.Parameters.AddWithValue("@oneri", oneri);
                    cmd.Parameters.AddWithValue("@tarih", DateTime.Now);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Öneri başarıyla gönderildi.");
                        textBox2.Clear();
                        this.Close(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Öneri gönderilirken bir hata oluştu: " + ex.Message);
                        this.Close();
                    }
                }
            }


        }

        private int hastaKontrol(int hastaid)
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn2 = new MySqlConnection(connStr))
            {
                conn2.Open();
                string query = "SELECT COUNT(*) FROM hastavedoktorlar WHERE hastaid=@hid AND doktorid=@did";
                using (MySqlCommand cmd = new MySqlCommand(query, conn2))
                {
                    cmd.Parameters.AddWithValue("@hid", hastaid);
                    cmd.Parameters.AddWithValue("@did", doktorid);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());



                    if (count > 0)
                        return 1;
                    else {
                        MessageBox.Show("Hasta size ait değil.");
                        return -1; 
                    }
                }
            }

        }

        private int Hastabul()
        {
            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";

            string hastaTc = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(hastaTc))
            {
                MessageBox.Show("Lütfen hasta TC kimlik numarasını giriniz.");
                return -1;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            { 
            
                conn.Open();
                string query = "SELECT id FROM kullanicilar WHERE tcno = @tc";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tc", hastaTc);
                    object result = cmd.ExecuteScalar();

                    int resultInt;
                    
                    if (result != null)
                    {
                     resultInt =  Convert.ToInt32(result);



                        int r1 = hastaKontrol(resultInt);



                     if (r1 == 1) return resultInt;

                        else
                        {
                            return -1;
                        }

                    }
                    else
                    {
                        return -1; 
                    }
                }
                conn.Close();


            }
        }
    }
}
