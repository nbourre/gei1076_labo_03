using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labo_03_interface
{
    public struct DonneesPixel
    {
        public byte bleu;
        public byte vert;
        public byte rouge;
        public byte alpha;
    }

    public unsafe class UnsafeBitmap
    {
        private Bitmap bitmap;
        private BitmapData donneesBitmap = null;
        private DonneesPixel* ptr = null;
        private bool verrou = false;
        private Graphics lg = null;

        private int largeur = 0;
        private int hauteur = 0;
        private Font police = null;

        private int bleu = 0;


        public UnsafeBitmap() : this(512, 512)
        {
        }

        public UnsafeBitmap(int largeur, int hauteur)
        {
            this.largeur = largeur;
            this.hauteur = hauteur;

            police = new Font("Tempus sans ITC", 12F, FontStyle.Bold);
            this.bitmap = new Bitmap(largeur, hauteur, PixelFormat.Format32bppArgb);
        }

        public void AcquiertGraphique(bool effacer)
        {
            if (effacer) Efface();

            lg = Graphics.FromImage(bitmap);
            verrou = true;
        }

        public void LibereGraphique()
        {
            lg.Dispose();
            verrou = false;
        }

        private void VerrouillerBitmap()
        {
            donneesBitmap = bitmap.LockBits(new Rectangle(0, 0, largeur, hauteur), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            ptr = (DonneesPixel*)donneesBitmap.Scan0.ToInt32();
        }

        private void DeverrouillerBitmap()
        {
            bitmap.UnlockBits(donneesBitmap);
        }

        private Bitmap Efface()
        {
            return Efface(0, 0, 0, 0);
        }

        private Bitmap Efface(int alpha, int rouge, int vert, int bleu)
        {
            VerrouillerBitmap();

            DonneesPixel pd = new DonneesPixel();

            pd.alpha = (byte)alpha;
            pd.rouge = (byte)rouge;
            pd.vert = (byte)vert;
            pd.bleu = (byte)bleu;

            for (int y = 0; y < hauteur; ++y)
                for (int x = 0; x < largeur; ++x)
                    *ptr++ = pd;

            DeverrouillerBitmap();

            return bitmap;
        }

        public void DessineLigne(Pen p, int xd, int yd, int xf, int yf)
        {
            if (verrou) lg.DrawLine(p, xd, yd, xf, yf);
        }

        public void DessineTexte(int x, int y, string texte, Brush b)
        {
            if (verrou) lg.DrawString(texte, police, b, x, y);
        }

        public void DessineRectangle(Pen p, int x, int y, int l, int h)
        {
            if (verrou) lg.DrawRectangle(p, x, y, l, h);
        }

        public void DessineEllipse(Pen p, int x, int y, int rx, int ry)
        {
            if (verrou) lg.DrawEllipse(p, x, y, rx, ry);
        }

        public int Largeur
        {
            get
            {
                return largeur;
            }
        }

        public int Hauteur
        {
            get
            {
                return hauteur;
            }
        }

        public Bitmap BitMap
        {
            get
            {
                return bitmap;
            }

        }

        public Bitmap CreerNouvelleImage()
        {
            VerrouillerBitmap();

            DonneesPixel pd = new DonneesPixel();

            pd.bleu = (byte)bleu;
            pd.alpha = 255;

            for (int y = 0; y < hauteur; ++y)
            {
                for (int x = 0; x < largeur; ++x)
                {
                    pd.rouge = (byte)x;
                    pd.vert = (byte)y;
                    *ptr++ = pd;
                }
            }

            DeverrouillerBitmap();

            ++bleu;
            if (bleu > 255) bleu = 0;

            return bitmap;
        }




    }
}
