using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using gei1076_tools;

namespace labo_03_emulateur
{
    public partial class frmEmulateur : Form
    {
        public frmEmulateur()
        {
            InitializeComponent();
        }

        private PortSerie ps = new PortSerie();
        private UnsafeBitmap uBmp = new UnsafeBitmap(512, 512);
        private int niveauCarburant = 20000;


        private void btnEffacer_Click(object sender, EventArgs e)
        {
            uBmp.AcquiertGraphique(true);
            uBmp.LibereGraphique();
            pcbImage.Image = uBmp.BitMap;
            xDernier = -1;

        }

        private int xDernier = -1, yDernier = -1;
        private Random alea = new Random();
        private bool actif = false;

        private void pcbImage_MouseDown(object sender, MouseEventArgs e)
        {
            actif = true;
        }

        private void pcbImage_MouseUp(object sender, MouseEventArgs e)
        {
            actif = false;
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
