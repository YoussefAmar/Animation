using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Math;

namespace Carrosse
{
    class Rectangle_movable : MonPoint
    {
        #region donnée membre

        private bool remplir = true;
        public Color Pot = Color.DarkViolet;
        private int hauteur, longueur, x, y;
        private double angle;

        #endregion

        #region Constructeur

        public Rectangle_movable(PictureBox hebergeur, int x, int y, int longueur, int hauteur, Color crayon, Color pot) : base(hebergeur, x, y)
        {
            this.Angle = 0f;
            this.hauteur = hauteur;
            this.longueur = longueur;
            this.x = x;
            this.y = y;
            this.Pot = pot;
            this.Crayon = crayon;
        }

        public Rectangle_movable(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y)
        {
            this.angle = Radian(Angle);
            this.hauteur = hauteur;
            this.longueur = longueur;
            this.x = x;
            this.y = y;
            this.Pot = pot;
            this.Crayon = crayon;
        }

        #region Point

        public Point CSG
        {
            get { return new Point(X,Y); }
        }

        public Point CSD
        {
            get { return new Point((int)(X + longueur * Math.Cos(angle)), (int)(Y - longueur * Math.Sin(angle))); }
        }

        public Point CIG
        {
            get { return new Point((int)(X + hauteur * Math.Cos(3 * PI / 2 + angle)), (int)(Y - hauteur * Math.Sin(3 * PI / 2 + angle))); }
        }

        public Point CID
        {
            get { return new Point((int)(X + longueur * Math.Cos(angle) + hauteur * Math.Cos(3 * PI / 2 + angle)), (int)(Y - longueur * Math.Sin(angle) - hauteur * Math.Sin(3 * PI / 2 + angle))); }
        }

        public Point MI
        {
            get { return new Point((int)(CIG.X + CID.X) /2, (int)((CIG.Y + CID.Y) / 2)); }
        }

        public Point MS
        {
            get { return new Point((int)(CSG.X + CSD.X) / 2, (int)((CSG.Y + CSD.Y) / 2)); }
        }

        #endregion

        #endregion

        #region Accesseur

        public bool Remplir { get => remplir; set => remplir = value; }
        public int Hauteur { get => hauteur; set => hauteur = value; }
        public int Longueur { get => longueur; set => longueur = value; }
        public double Angle { get => angle; set => angle = value; }

        #endregion

        #region Méthode

        public double Radian(double angle)
        {
            angle = (angle *Math.PI/180);
            return angle;
        }

        public virtual void Afficher(Graphics gr)
        {
            Point[] p = new Point[4];

            p[0] = CSG;
            p[1] = CSD;
            p[2] = CID;
            p[3] = CIG;

            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillClosedCurve(new SolidBrush(this.Pot),p);
                }
                gr.DrawClosedCurve(new Pen(this.Crayon), p);
            }
        }

        public virtual void Cacher(IntPtr handle)
        {
            Point[] p = new Point[4];

            p[0] = CSG;
            p[1] = CSD;
            p[2] = CID;
            p[3] = CIG;

            Graphics gr = Graphics.FromHwnd(handle);

            if (this.Remplir)
            {
                gr.FillClosedCurve(new SolidBrush(this.Pot), p);
            }

            gr.DrawClosedCurve(new Pen(this.Crayon),p);
        }

        public virtual void Bouger(int deplX, int deplY, double diffAngle)
        {
            base.Bouger(deplX, deplY);
            diffAngle = Radian(diffAngle);
            this.angle += diffAngle;
        }

        #endregion

    }
}
