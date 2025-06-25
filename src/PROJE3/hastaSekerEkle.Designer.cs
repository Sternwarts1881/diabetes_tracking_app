namespace PROJE3
{
    partial class hastaSekerEkle
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
            this.label1 = new System.Windows.Forms.Label();
            this.ekleButton = new System.Windows.Forms.Button();
            this.sekerTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kan Şekeri Seviyesi (mg/dL):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ekleButton
            // 
            this.ekleButton.Location = new System.Drawing.Point(564, 28);
            this.ekleButton.Name = "ekleButton";
            this.ekleButton.Size = new System.Drawing.Size(104, 32);
            this.ekleButton.TabIndex = 1;
            this.ekleButton.Text = "Ekle";
            this.ekleButton.UseVisualStyleBackColor = true;
            this.ekleButton.Click += new System.EventHandler(this.ekleButton_Click);
            // 
            // sekerTxtBox
            // 
            this.sekerTxtBox.Location = new System.Drawing.Point(224, 32);
            this.sekerTxtBox.Name = "sekerTxtBox";
            this.sekerTxtBox.Size = new System.Drawing.Size(336, 26);
            this.sekerTxtBox.TabIndex = 2;
            // 
            // hastaSekerEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 89);
            this.Controls.Add(this.sekerTxtBox);
            this.Controls.Add(this.ekleButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "hastaSekerEkle";
            this.Text = "Kan Şekeri Ekle";
            this.Load += new System.EventHandler(this.hastaSekerEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ekleButton;
        private System.Windows.Forms.TextBox sekerTxtBox;
    }
}