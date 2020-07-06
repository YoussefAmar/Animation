using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carrosse
{
    class Decors : Rectangle_movable
    {
        private MonRectangle Mur, Pave1, Pave2, Pave3,Pave4,Pave5,Terre;
        private MonCercle Soleil1;
        private Nuage Nuage1, Nuage2, Nuage3;

        public Decors(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y, longueur, hauteur, Angle, crayon, pot)
        {
            Pave1 = new MonRectangle(hebergeur, 0, 500, 380, 1051, Color.Black, Color.LightGray);
            Pave2 = new MonRectangle(hebergeur, 381, 500, 380, 1051, Color.Black, Color.LightGray);
            Pave3 = new MonRectangle(hebergeur, 381*2, 500, 380, 1051, Color.Black, Color.LightGray);
            Pave4 = new MonRectangle(hebergeur, 381*3, 500, 380, 1051, Color.Black, Color.LightGray);
            Pave5 = new MonRectangle(hebergeur, 381*4, 500, 380, 1051, Color.Black, Color.LightGray);
            Terre = new MonRectangle(hebergeur,0,550, 1920, 200, Color.Black, Color.SaddleBrown);
            Soleil1 = new MonCercle(hebergeur, 700, 100, 60, Color.LightYellow, Color.Yellow);
            Nuage1 = new Nuage(hebergeur, 0, 0, 0, 0, 0, Color.LightYellow, Color.Yellow);
            Nuage2 = new Nuage(hebergeur, 500, 50, 0, 0, 0, Color.LightYellow, Color.Yellow);
            Nuage3 = new Nuage(hebergeur, 850, -20, 0, 0, 0, Color.LightYellow, Color.Yellow);
        }

        public override void Afficher(Graphics gr)
        {
            this.Pave1.Afficher(gr);
            this.Pave2.Afficher(gr);
            this.Pave3.Afficher(gr);
            this.Pave4.Afficher(gr);
            this.Pave5.Afficher(gr);
            this.Soleil1.Afficher(gr);
            this.Nuage1.Afficher(gr);
            this.Nuage2.Afficher(gr);
            this.Nuage3.Afficher(gr);
            this.Terre.Afficher(gr);
        }

        public override void Cacher(IntPtr handle)
        {
            this.Pave1.Cacher(handle);
            this.Pave2.Cacher(handle);
            this.Pave3.Cacher(handle);
            this.Pave4.Cacher(handle);
            this.Pave5.Cacher(handle);
            this.Soleil1.Cacher(handle);
            this.Nuage1.Cacher(handle);
            this.Nuage2.Cacher(handle);
            this.Nuage3.Cacher(handle);
            this.Terre.Cacher(handle);
        }
    }
}
