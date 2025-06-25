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
    public partial class DoktorBildirim : Form
    {
        
      private int doktorID;

        public DoktorBildirim(int doktorId)
        {
            InitializeComponent();
            doktorID = doktorId;
            this.Load += DoktorBildirim_Load;
        }

        private void DoktorBildirim_Load(object sender, EventArgs e)
        {

            string connStr = "server=localhost;user=root;password=1e2g3e;database=diyabet_sistemi;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"
            SELECT 
                u.tarihsaat,
                k.ad AS HastaAd,
                k.soyad AS HastaSoyad,
                CASE
                    WHEN u.KansekeriSeviyesi < 70 THEN 'Hipoglisemi'
                    WHEN u.KansekeriSeviyesi >= 70 AND u.KansekeriSeviyesi < 110 THEN 'Normal - Alt Düzey'
                    WHEN u.KansekeriSeviyesi >= 110 AND u.KansekeriSeviyesi < 180 THEN 'Normal - Üst Düzey'
                    WHEN u.KansekeriSeviyesi >= 180 THEN 'Hiperglisemi'
                    ELSE 'Bilinmeyen'
                END AS KanSekeriDurumu,
                u.uyaritipi,
                u.uyarimesaji
            FROM uyari u
            JOIN kullanicilar k ON u.hastaid = k.id
            WHERE u.doktorid = @doktorid
            ORDER BY u.tarihsaat DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@doktorid", doktorID);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvBildirimler.DataSource = dt;
                dgvBildirimler.ReadOnly = true;
                dgvBildirimler.AllowUserToAddRows = false;
                dgvBildirimler.AllowUserToDeleteRows = false;
                dgvBildirimler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
