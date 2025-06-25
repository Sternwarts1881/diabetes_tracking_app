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
    public partial class GirişForm : Form
    {
        public GirişForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tc = TCbox.Text.Trim();
            string sifre = Sifrebox.Text.Trim();

            if (tc == "" || sifre == "")
            {
                durumlbl.Text = "TC ve şifre boş olamaz.";
                return;
            }

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT rol FROM kullanicilar WHERE tcno = @tc AND sifre_hash = SHA2(@sifre, 256)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    object rol = cmd.ExecuteScalar();

                    if (rol != null)
                    {
                        string kullaniciRol = rol.ToString();
                        durumlbl.Text = "Giriş başarılı. Rol: " + kullaniciRol;

                        if (kullaniciRol == "doktor")
                        {
                            
                            new DoktorForm(tc).Show();
                        }
                        else if (kullaniciRol == "hasta")
                        {
                            
                            new HastaForm(tc).Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        durumlbl.Text = "Hatalı TC veya şifre.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TCbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sifrelbl_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
