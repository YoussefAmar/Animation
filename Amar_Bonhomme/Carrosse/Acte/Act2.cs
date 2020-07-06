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
    class Act2 : Rectangle_movable
    {
        private MonRectangle Escalier,barre1,barre2,barre3,barre4,Barre,Mur;
        private Rectangle_movable vider;
        private MonCercle vide;

        public Act2(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y, longueur, hauteur, Angle, crayon, pot)
        {

            Escalier = new MonRectangle(hebergeur, -10, 400, 460, 100, Color.Black, Color.IndianRed);
            Barre = new MonRectangle(hebergeur, 600, 420, 450, 10, Color.Black, Color.DarkGray);
            barre1 = new MonRectangle(hebergeur, 650, 420, 20, 80, Color.Black, Color.DarkGray);
            barre2 = new MonRectangle(hebergeur, 750, 420, 20, 80, Color.Black, Color.DarkGray);
            barre3 = new MonRectangle(hebergeur, 850, 420, 20, 80, Color.Black, Color.DarkGray);
            barre4 = new MonRectangle(hebergeur, 950 , 420, 20, 80, Color.Black, Color.DarkGray);
            Mur = new MonRectangle(hebergeur,1130, 355, 170, 145, Color.Black, Color.SandyBrown);
            vide = new MonCercle(hebergeur, 1130, 420, 78, Color.LightBlue, Color.LightBlue);
            vider = new Rectangle_movable(hebergeur, 1165, 355, 40, 55,0, Color.LightBlue, Color.LightBlue);
        }

        public override void Afficher(Graphics gr)
        {
            Escalier.Afficher(gr);
            barre1.Afficher(gr);
            barre2.Afficher(gr);
            barre3.Afficher(gr);
            barre4.Afficher(gr);
            Barre.Afficher(gr);
            Mur.Afficher(gr);
            vide.Afficher(gr);
            vider.Afficher(gr);
        }

        public override void Cacher(IntPtr handle)
        {
            Escalier.Cacher(handle);
            Barre.Cacher(handle);
            barre1.Cacher(handle);
            barre2.Cacher(handle);
            barre3.Cacher(handle);
            barre4.Cacher(handle);
            Mur.Cacher(handle);
            vide.Cacher(handle);
            vider.Cacher(handle);
        }

    }

}

