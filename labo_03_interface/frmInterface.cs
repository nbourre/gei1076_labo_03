using System;
using System.Drawing;
using System.Windows.Forms;

using gei1076_tools;
using System.Drawing.Imaging;

namespace labo_03_interface
{
    public partial class frmInterface : Form
    {

        private PortSerie ps = new PortSerie();
        private UnsafeBitmap uBmp = new UnsafeBitmap(512, 512);
        private int niveauCarburant = 20000;

        private int xDernier = -1, yDernier = -1;
        private Random alea = new Random();
        private bool actif = false;
        private const int tailleTrame = 6;
        private byte[] trame = new byte[tailleTrame];

        public frmInterface()
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
        }

        private void pcbImage_MouseUp(object sender, MouseEventArgs e)
        {
            actif = false;
        }

        bool fin = false;

        private void btnRapide_Click(object sender, EventArgs e)
        {
            fin = false;

            uBmp.AcquiertGraphique(true);

            while (fin == false)
            {
                pcbImage.Image = uBmp.CreerNouvelleImage();
                Application.DoEvents();
            }

            uBmp.LibereGraphique();

        }

        private void btnRapideArret_Click(object sender, EventArgs e)
        {
            fin = true;
        }

        private Bitmap bitmap = new Bitmap(512, 512, PixelFormat.Format32bppArgb);

        private void btnDessine_Click(object sender, EventArgs e)
        {
            Graphics lg = Graphics.FromImage(bitmap);

            lg.DrawLine(Pens.Black, 0, 0, 100, 100);

            lg.Dispose();

            pcbImage.Image = bitmap;


        }

        private void frmEmulateur_Load(object sender, EventArgs e)
        {
            trame[0] = 0x5A;
            trame[1] = 0xA5;
        }

        private byte[] tableau = new byte[tailleTrame];
        private byte octet;
        private int xActuel, yActuel;


        private void clkReception_Tick(object sender, EventArgs e)
        {
            clkReception.Enabled = false;

            while (ps.DonneesALire() >= tailleTrame + 2)
            {
                ps.LireOctet(ref octet);
                if (octet == 0x5A)
                {
                    ps.LireOctet(ref octet);
                    if (octet == 0xA5)
                    {
                        uBmp.AcquiertGraphique(false);
                        ps.LireOctets(tableau, 0, tailleTrame);
                        xActuel = ((int)tableau[0] << 8) + tableau[1];
                        yActuel = ((int)tableau[2] << 8) + tableau[3];

                        if (xDernier != -1)
                        {
                            uBmp.DessineLigne(Pens.Black, xDernier, yDernier, xActuel, yActuel);
                            if (serieVitesse.Points.Count > 99)
                                serieVitesse.Points.RemoveAt(0);
                            int dx = xActuel - xDernier;
                            int dy = yActuel - yDernier;
                            serieVitesse.Points.Add(Math.Sqrt((dx * dx) + (dy * dy)) * 5.0);
                        }

                        niveauCarburant = ((int)tableau[4] << 8) + tableau[5];
                        if (serieNiveau.Points.Count > 99)
                            serieNiveau.Points.RemoveAt(0);

                        serieNiveau.Points.Add(niveauCarburant);

                        xDernier = xActuel;
                        yDernier = yActuel;
                        uBmp.LibereGraphique();
                        pcbImage.Image = uBmp.BitMap;

                    }
                }
            }

            clkReception.Enabled = true;
        }

        private void btnFairePlein_Click(object sender, EventArgs e)
        {
            niveauCarburant = 20000;
        }

        private void pcbImage_MouseMove(object sender, MouseEventArgs e)
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
        }
    }
}
