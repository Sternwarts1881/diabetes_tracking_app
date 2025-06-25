using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PROJE3
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connStr = "server=localhost;user=root;database=diyabet_sistemi;port=3306;password=1e2g3e;";
            MySqlConnection conn = DbConnectionFactory.CreateConnection();

            try
            {
                conn.Open();
                MessageBox.Show("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            Application.Run(new GirişForm());
        }

    }
}

