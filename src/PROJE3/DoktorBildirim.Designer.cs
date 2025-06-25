namespace PROJE3
{
    partial class DoktorBildirim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBildirimler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBildirimler)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBildirimler
            // 
            this.dgvBildirimler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBildirimler.Location = new System.Drawing.Point(0, 0);
            this.dgvBildirimler.Name = "dgvBildirimler";
            this.dgvBildirimler.Size = new System.Drawing.Size(800, 450);
            this.dgvBildirimler.TabIndex = 0;
            this.dgvBildirimler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DoktorBildirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBildirimler);
            this.Name = "DoktorBildirim";
            this.Text = "DoktorBildirim";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBildirimler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBildirimler;
    }
}