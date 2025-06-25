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
    public partial class hastaKart : UserControl
    {
        public int HastaID { get; set; }

        public string AdSoyad
        {
            get => lblAdSoyad.Text;
            set => lblAdSoyad.Text = value;
        }


        public hastaKart()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            hastaDetaylariForm detayForm = new hastaDetaylariForm(HastaID);
            detayForm.ShowDialog();
        }
    }
}
