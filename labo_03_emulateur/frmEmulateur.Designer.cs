namespace labo_03_emulateur
{
    partial class frmEmulateur
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
            this.pcbImage = new System.Windows.Forms.PictureBox();
            this.spcSerialPortConfig = new gei1076_tools.SerialPortConfigurator();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.btnFairePlein = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbImage
            // 
            this.pcbImage.Location = new System.Drawing.Point(13, 110);
            this.pcbImage.Name = "pcbImage";
            this.pcbImage.Size = new System.Drawing.Size(515, 512);
            this.pcbImage.TabIndex = 1;
            this.pcbImage.TabStop = false;
            this.pcbImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbImage_MouseDown);
            this.pcbImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbImage_MouseMove);
            this.pcbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcbImage_MouseUp);
            // 
            // spcSerialPortConfig
            // 
            this.spcSerialPortConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcSerialPortConfig.Location = new System.Drawing.Point(13, 13);
            this.spcSerialPortConfig.Name = "spcSerialPortConfig";
            this.spcSerialPortConfig.Size = new System.Drawing.Size(515, 91);
            this.spcSerialPortConfig.TabIndex = 0;
            // 
            // btnEffacer
            // 
            this.btnEffacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEffacer.Location = new System.Drawing.Point(13, 625);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(75, 23);
            this.btnEffacer.TabIndex = 2;
            this.btnEffacer.Text = "Effacer";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // btnFairePlein
            // 
            this.btnFairePlein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFairePlein.Location = new System.Drawing.Point(453, 625);
            this.btnFairePlein.Name = "btnFairePlein";
            this.btnFairePlein.Size = new System.Drawing.Size(75, 23);
            this.btnFairePlein.TabIndex = 3;
            this.btnFairePlein.Text = "Faire le plein";
            this.btnFairePlein.UseVisualStyleBackColor = true;
            // 
            // frmEmulateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 660);
            this.Controls.Add(this.btnFairePlein);
            this.Controls.Add(this.btnEffacer);
            this.Controls.Add(this.pcbImage);
            this.Controls.Add(this.spcSerialPortConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmulateur";
            this.Text = "Émulateur";
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private gei1076_tools.SerialPortConfigurator spcSerialPortConfig;
        private System.Windows.Forms.PictureBox pcbImage;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.Button btnFairePlein;
    }
}

