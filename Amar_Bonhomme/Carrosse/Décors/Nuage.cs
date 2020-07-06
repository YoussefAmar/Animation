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
    class Nuage : Rectangle_movable
    {
        private MonCercle Partie1, Partie2, Partie3;

        public Nuage(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y, longueur, hauteur, Angle, crayon, pot)
        {
            Partie1 = new MonCercle(hebergeur, x + 250, y + 90, 30, Color.White, Color.White);
            Partie2 = new MonCercle(hebergeur, x + 300, y + 90, 50, Color.White, Color.White);
            Partie3 = new MonCercle(hebergeur, x + 350, y + 90, 30, Color.White, Color.White);
        }

        public override void Afficher(Graphics gr)
        {
            this.Partie1.Afficher(gr);
            this.Partie2.Afficher(gr);
            this.Partie3.Afficher(gr);
        }

        public override void Cacher(IntPtr handle)
        {
            this.Partie1.Cacher(handle);
            this.Partie2.Cacher(handle);
            this.Partie3.Cacher(handle);
        }


    }
}