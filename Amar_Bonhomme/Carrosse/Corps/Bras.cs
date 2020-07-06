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
    class Bras : Rectangle_movable
    {
        #region donnée membre

        private bool remplir = true;
        private Color Pot = Color.Red;
        private int hauteur, longueur, x, y;
        private double angle;
        private double angler;
        private double limite_angle;
        private double limite_angle_epaule;
        private double limite_angle_bras;

        private Rectangle_movable AvantBras, Main;

        #endregion

        #region accesseur
        public double Limite_angle { get => limite_angle; set => limite_angle = value; }
        public double Angle_ { get => angle; set => angle = value; }
        public int Hauteur1 { get => hauteur; set => hauteur = value; }
        public int Longueur1 { get => longueur; set => longueur = value; }
        public int X1 { get => x; set => x = value; }
        public int Y1 { get => y; set => y = value; }
        public Color Pot_ { get => Pot; set => Pot = value; }
        public bool Remplir1 { get => remplir; set => remplir = value; }
        public double Limite_angle_bras { get => limite_angle_bras; set => limite_angle_bras = value; }
        public double Limite_angle_epaule { get => limite_angle_epaule; set => limite_angle_epaule = value; }
        internal Rectangle_movable Main1 { get => Main; set => Main = value; }
        internal Rectangle_movable AvantBras1 { get => AvantBras; set => AvantBras = value; }
        public double Angler { get => angler; set => angler = value; }
        #endregion

        public Bras(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y,longueur,hauteur, Angle,crayon,pot)
        {
         
            this.AvantBras = new Rectangle_movable(hebergeur,base.CIG.X, base.CIG.Y, this.Longueur*3/5, this.Hauteur, this.Angle, this.Crayon, Color.Brown);
            this.Main = new Rectangle_movable(hebergeur, AvantBras.CIG.X, AvantBras.CIG.Y, this.Longueur*9/10,this.Hauteur*4/5, this.Angle, this.Crayon, Color.Brown);
            
            limite_angle = Radian(90);
            limite_angle_bras = Radian(160);
            limite_angle_epaule = limite_angle;
           
        }

        public override void Bouger(int deplX, int deplY, double diffAngle)
        {
            angler = Radian(diffAngle);

            if (base.Angle <= Limite_angle_epaule)
            {
                //Tout le bras monte

                this.AvantBras.X = base.CIG.X;
                this.AvantBras.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - AvantBras.MS.X, base.MI.Y - AvantBras.MS.Y };
                this.AvantBras.X = base.CIG.X + vecteur[0];
                this.AvantBras.Y = base.CIG.Y + vecteur[1];

                this.Main.X = AvantBras.CIG.X;
                this.Main.Y = AvantBras.CIG.Y;

                base.Bouger(deplX, deplY, diffAngle);
                this.AvantBras.Bouger(deplX, deplY,diffAngle);
                this.Main.Bouger(deplX, deplY,diffAngle);
            }

          else if (base.Angle >= Limite_angle_epaule && this.AvantBras.Angle < Limite_angle_bras && Limite_angle_epaule == Radian(90))
            {
                //Le bras s'arrête, le reste monte

                this.AvantBras.X = base.CIG.X;
                this.AvantBras.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - AvantBras.MS.X, base.MI.Y - AvantBras.MS.Y };
                this.AvantBras.X = base.CIG.X + vecteur[0];
                this.AvantBras.Y = base.CIG.Y + vecteur[1];

                this.Main.X = AvantBras.CIG.X;
                this.Main.Y = AvantBras.CIG.Y;

                base.Bouger(deplX, deplY);
                this.AvantBras.Bouger(deplX, deplY, diffAngle);
                this.Main.Bouger(deplX, deplY, diffAngle);
            }

           else if(base.Angle >= Limite_angle_epaule && this.AvantBras.Angle >= Limite_angle_bras && this.AvantBras.Angle >= Limite_angle_epaule && Limite_angle_epaule == Radian(90))
            {
                //L'avant bras et la main redescendent mais le bras ne bouge pas

                this.AvantBras.X = base.CIG.X;
                this.AvantBras.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - AvantBras.MS.X, base.MI.Y - AvantBras.MS.Y };
                this.AvantBras.X = base.CIG.X + vecteur[0];
                this.AvantBras.Y = base.CIG.Y + vecteur[1];

                this.Main.X = AvantBras.CIG.X;
                this.Main.Y = AvantBras.CIG.Y;

                this.AvantBras.Angle -= angler;
                this.Main.Angle -= angler;

                Limite_angle_bras -= angler;

                base.Bouger(deplX, deplY);
                this.AvantBras.Bouger(deplX, deplY);
                this.Main.Bouger(deplX, deplY);

            }

           else if(base.Angle >= Limite_angle_epaule && Limite_angle_epaule <= Radian(90))
            {
                //Tout redescend

                this.AvantBras.X = base.CIG.X;
                this.AvantBras.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - AvantBras.MS.X, base.MI.Y - AvantBras.MS.Y };
                this.AvantBras.X = base.CIG.X + vecteur[0];
                this.AvantBras.Y = base.CIG.Y + vecteur[1];

                this.Main.X = AvantBras.CIG.X;
                this.Main.Y = AvantBras.CIG.Y;

                base.Angle -= angler;
                this.AvantBras.Angle -= angler;
                this.Main.Angle -= angler;

                Limite_angle_epaule -= angler;

                base.Bouger(deplX, deplY);
                this.AvantBras.Bouger(deplX, deplY);
                this.Main.Bouger(deplX, deplY);

                if (Limite_angle_epaule <= 0)
                {
                    Limite_angle_epaule = Radian(90);
                    Limite_angle_bras = Radian(160);
                }
            }
            
        }

        public override void Afficher(Graphics gr)
        {
            this.Main.Afficher(gr);
            this.AvantBras.Afficher(gr);
            base.Afficher(gr);

        }

        public override void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this.AvantBras.Cacher(handle);
            this.Main.Cacher(handle);
        }


    }
}

