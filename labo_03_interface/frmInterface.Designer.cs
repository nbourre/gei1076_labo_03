namespace labo_03_interface
{
    partial class frmInterface
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pcbImage = new System.Windows.Forms.PictureBox();
            this.btnEffacer = new System.Windows.Forms.Button();
            this.spcSerialPortConfig = new gei1076_tools.SerialPortConfigurator();
            this.clkReception = new System.Windows.Forms.Timer(this.components);
            this.chartVitesse = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNiveau = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clkAlarmeNiveau = new System.Windows.Forms.Timer(this.components);
            this.lblNiveauCarburant = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVitesse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNiveau)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbImage
            // 
            this.pcbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbImage.Location = new System.Drawing.Point(12, 110);
            this.pcbImage.Name = "pcbImage";
            this.pcbImage.Size = new System.Drawing.Size(515, 512);
            this.pcbImage.TabIndex = 1;
            this.pcbImage.TabStop = false;
            // 
            // btnEffacer
            // 
            this.btnEffacer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEffacer.Location = new System.Drawing.Point(981, 81);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(75, 23);
            this.btnEffacer.TabIndex = 2;
            this.btnEffacer.Text = "Effacer";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // spcSerialPortConfig
            // 
            this.spcSerialPortConfig.Location = new System.Drawing.Point(13, 13);
            this.spcSerialPortConfig.Name = "spcSerialPortConfig";
            this.spcSerialPortConfig.Size = new System.Drawing.Size(514, 91);
            this.spcSerialPortConfig.TabIndex = 0;
            // 
            // clkReception
            // 
            this.clkReception.Interval = 10;
            this.clkReception.Tick += new System.EventHandler(this.clkReception_Tick);
            // 
            // chartVitesse
            // 
            chartArea1.Name = "ChartArea1";
            this.chartVitesse.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartVitesse.Legends.Add(legend1);
            this.chartVitesse.Location = new System.Drawing.Point(533, 110);
            this.chartVitesse.Name = "chartVitesse";
            this.chartVitesse.Size = new System.Drawing.Size(523, 251);
            this.chartVitesse.TabIndex = 4;
            title1.Name = "Vitesse";
            this.chartVitesse.Titles.Add(title1);
            // 
            // chartNiveau
            // 
            chartArea2.Name = "ChartArea1";
            this.chartNiveau.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartNiveau.Legends.Add(legend2);
            this.chartNiveau.Location = new System.Drawing.Point(533, 371);
            this.chartNiveau.Name = "chartNiveau";
            this.chartNiveau.Size = new System.Drawing.Size(523, 251);
            this.chartNiveau.TabIndex = 4;
            this.chartNiveau.Text = "chartNiveau";
            title2.Name = "Niveau de carburant";
            this.chartNiveau.Titles.Add(title2);
            // 
            // clkAlarmeNiveau
            // 
            this.clkAlarmeNiveau.Tick += new System.EventHandler(this.clkAlarmeNiveau_Tick);
            // 
            // lblNiveauCarburant
            // 
            this.lblNiveauCarburant.AutoSize = true;
            this.lblNiveauCarburant.Location = new System.Drawing.Point(765, 596);
            this.lblNiveauCarburant.Name = "lblNiveauCarburant";
            this.lblNiveauCarburant.Size = new System.Drawing.Size(0, 13);
            this.lblNiveauCarburant.TabIndex = 5;
            // 
            // frmInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 630);
            this.Controls.Add(this.lblNiveauCarburant);
            this.Controls.Add(this.chartNiveau);
            this.Controls.Add(this.chartVitesse);
            this.Controls.Add(this.btnEffacer);
            this.Controls.Add(this.pcbImage);
            this.Controls.Add(this.spcSerialPortConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInterface";
            this.Text = "Interface";
            this.Load += new System.EventHandler(this.frmInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVitesse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNiveau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private gei1076_tools.SerialPortConfigurator spcSerialPortConfig;
        private System.Windows.Forms.PictureBox pcbImage;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.Timer clkReception;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVitesse;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNiveau;
        private System.Windows.Forms.Timer clkAlarmeNiveau;
        private System.Windows.Forms.Label lblNiveauCarburant;
    }
}

