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
    class Act1 : Rectangle_movable
    {
        private MonRectangle Pente,Escalier1,Escalier2,Escalier3; 

        public Act1(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y, longueur, hauteur, Angle, crayon, pot)
        {
            Pente = new MonRectangle(hebergeur, 0,465, 500, 35, Color.Black, Color.SandyBrown);
            Escalier1 = new MonRectangle(hebergeur, 1100, 475, 200, 25, Color.Black, Color.IndianRed);
            Escalier2 = new MonRectangle(hebergeur, 1150, 450, 500, 25, Color.Black, Color.IndianRed);
            Escalier3 = new MonRectangle(hebergeur, 1200, 425, 500, 25, Color.Black, Color.IndianRed);
        }

        public override void Afficher(Graphics gr)
        {
            Pente.Afficher(gr);
            Escalier1.Afficher(gr);
            Escalier2.Afficher(gr);
            Escalier3.Afficher(gr);
        }

        public override void Cacher(IntPtr handle)
        {
            Pente.Cacher(handle);
            Escalier1.Cacher(handle);
            Escalier2.Cacher(handle);
            Escalier3.Cacher(handle);
        }

    }

}
