using System;
using System.Drawing;
using System.Windows.Forms;

using gei1076_tools;
using System.Drawing.Imaging;

namespace labo_03_interface
{
    public partial class frmEmulateur : Form
    {

        private PortSerie ps;
        private UnsafeBitmap uBmp = new UnsafeBitmap(512, 512);
        private int niveauCarburant = 20000;

        private int xDernier = -1, yDernier = -1;
        private Random alea = new Random();
        private bool actif = false;
        private const int tailleTrame = 8;
        private byte[] trame = new byte[tailleTrame];

        public frmEmulateur()
        {
            InitializeComponent();
        }
        

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            uBmp.AcquiertGraphique(true);
            uBmp.LibereGraphique();
            pcbImage.Image = uBmp.BitMap;
            xDernier = -1;

        }
        

        private void pcbImage_MouseDown(object sender, MouseEventArgs e)
        {
            actif = true;
            clkMinuterie.Enabled = true;

        }

        private void pcbImage_MouseUp(object sender, MouseEventArgs e)
        {
            actif = false;
            clkMinuterie.Enabled = false;
        }


        private Bitmap bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);


        private void frmEmulateur_Load(object sender, EventArgs e)
        {
            ps = spcSerialPortConfig.getPS();
            clkMinuterie.Enabled = true;

            trame[0] = 0x5A;
            trame[1] = 0xA5;
        }

        private void clkMinuterie_Tick(object sender, EventArgs e)
        {
            if (niveauCarburant > 0) niveauCarburant -= 50;
        }

        private void btnFairePlein_Click(object sender, EventArgs e)
        {
            niveauCarburant = 20000;
        }

        private void pcbImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.Y < 0) return;

            try
            {
                if (actif && ps.Ouvert)
                {

                    trame[2] = (byte)(e.X >> 8);
                    trame[3] = (byte)(e.X & 0xFF);
                    trame[4] = (byte)(e.Y >> 8);
                    trame[5] = (byte)(e.Y & 0xFF);

                    int niveauBruite = niveauCarburant + (alea.Next(500) - 250);
                    if (niveauBruite < 0) niveauBruite = 0;

                    trame[6] = (byte)(niveauBruite >> 8);
                    trame[7] = (byte)(niveauBruite & 0xFF);

                    ps.EcrireOctets(trame, 8);


                }

                if (actif)
                {
                    if (xDernier != -1)
                    {
                        uBmp.AcquiertGraphique(false);
                        uBmp.DessineLigne(Pens.Black, xDernier, yDernier, e.X, e.Y);
                        uBmp.LibereGraphique();
                        pcbImage.Image = uBmp.BitMap;
                    }
                    xDernier = e.X;
                    yDernier = e.Y;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Erreur \n" + ex.Message);

            }
        }
    }
}
