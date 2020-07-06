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
    class Jambe : Rectangle_movable
    {
        private bool remplir = true;
        private Color pot = Color.Brown;
        private int hauteur, longueur, x, y;
        private double angle;
        private double limite_angle;
        private double limite_angle_jambe;
        private double limite_angle_cuisser;
        private double limite_angle_cuissea;
        private double angler;
        private bool verif_null,verifd;

        private Rectangle_movable Cuisse, Pied;

        private MonCercle roller1, roller2, roller3;

        #region accesseur
        public double Limite_angle { get => limite_angle; set => limite_angle = value; }
        public double Angle_ { get => angle; set => angle = value; }
        public int Hauteur1 { get => hauteur; set => hauteur = value; }
        public int Longueur1 { get => longueur; set => longueur = value; }
        public int X1 { get => x; set => x = value; }
        public int Y1 { get => y; set => y = value; }
        public Color Pot { get => pot; set => pot = value; }
        public bool Remplir1 { get => remplir; set => remplir = value; }
        public double Limite_angle_jambe { get => limite_angle_jambe; set => limite_angle_jambe = value; }
        public double Limite_angle_cuisser { get => limite_angle_cuisser; set => limite_angle_cuisser = value; }
        internal Rectangle_movable Cuisse1 { get => Cuisse; set => Cuisse = value; }
        internal Rectangle_movable Pied1 { get => Pied; set => Pied = value; }
        public double Limite_angle_cuissea { get => limite_angle_cuissea; set => limite_angle_cuissea = value; }
        public double Angler { get => angler; set => angler = value; }
        public bool Verif_null { get => verif_null; set => verif_null = value; }
        public bool Verif_null1 { get => verif_null; set => verif_null = value; }
        public bool Verifd { get => verifd; set => verifd = value; }
        #endregion

        public Jambe(PictureBox hebergeur, int x, int y, int longueur, int hauteur, double Angle, Color crayon, Color pot) : base(hebergeur, x, y, longueur, hauteur, Angle, crayon, pot)
        {
            this.Cuisse = new Rectangle_movable(hebergeur, base.MS.X, base.MS.Y, this.Longueur*4/5, this.Hauteur *9/10, this.Angle, this.Crayon, Color.Brown);
            this.Pied = new Rectangle_movable(hebergeur, Cuisse.CIG.X, Cuisse.CIG.Y, this.Longueur*19/10, this.Hauteur * 15/40, this.Angle, this.Crayon, Color.Purple);

            this.roller1 = new MonCercle(hebergeur, Pied.CIG.X, Pied.CIG.Y + 5, longueur / 3, Color.Black, Color.Yellow);
            this.roller2 = new MonCercle(hebergeur, Pied.MI.X, Pied.MI.Y + 5, longueur / 3, Color.Black, Color.Yellow);
            this.roller3 = new MonCercle(hebergeur, Pied.CID.X, Pied.CID.Y + 5, longueur / 3, Color.Black, Color.Yellow);

            Limite_angle = Radian(60);
            Limite_angle_jambe = limite_angle;
            Limite_angle_cuisser = Radian(-45);
            Limite_angle_cuissea = Radian(105);
            verif_null = false;
            verifd = false;
        }

        public override void Bouger(int deplX, int deplY, double diffAngle)
        {

            if (base.Angle <= Limite_angle_jambe && Limite_angle_cuisser >= Radian(-45) && Limite_angle_cuisser < 0)
            {
                //La jambe avance et la cuisse recule

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y +5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y +5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y +5;

                base.Bouger(deplX, deplY, diffAngle);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                this.Cuisse.Angle -= angler;
                this.Pied.Angle -= angler;
                Limite_angle_cuisser += angler;

            }

            else if(Limite_angle_cuisser >= 0 && Limite_angle_cuissea <= Radian(120) && Limite_angle_cuissea > 0)
            {
                // La cuisse avance

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                this.Cuisse.Angle += angler;
                this.Pied.Angle += angler;
                Limite_angle_cuissea -= angler;

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

            }

            else if(Limite_angle_cuissea <= 0 && Limite_angle_jambe > 0)
            {
                //Tout redescend

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                base.Angle -= angler;
                this.Cuisse.Angle -= angler;
                this.Pied.Angle -= angler;

                Limite_angle_jambe -= angler;

               if(Limite_angle_jambe <= 0)
                {
                    Limite_angle_jambe = Radian(60);
                    Limite_angle_cuissea = Radian(105);
                    Limite_angle_cuisser = Radian(-45);

                    base.Angle = 0;
                    this.Cuisse.Angle = 0;
                    this.Pied.Angle = 0;
                }

            }
           
        }

        public void accroupis(int deplX, int deplY, double diffAngle)
        {

            if(this.Cuisse.Angle >= 0 && base.Angle >= 0 && this.Pied.Angle >= 0 && verif_null == false)
            {
                // Si la jambe n'est pas droite, on la remet droite

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                base.Angle -= angler;
                this.Cuisse.Angle -= angler;
                this.Pied.Angle -= angler;

                if(this.Cuisse.Angle <= 0)
                {
                    this.Cuisse.Angle = 0;
                }

                if (this.Pied.Angle <= 0)
                {
                    this.Pied.Angle = 0;
                }

                if (base.Angle <= 0)
                {
                    base.Angle = 0;
                }

                if(this.Cuisse.Angle == 0 && base.Angle == 0 && this.Pied.Angle == 0)
                {
                    verif_null = true;
                }

            }

            else if(verif_null == true && base.Angle <= Radian(30))
            {
                // On plie la jambe

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                base.Angle += angler;
                this.Cuisse.Angle -= angler;

            }

            else if(verif_null == true && base.Angle >= Radian(30))
            {
                // Jambe plié, on avance

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

            }


        }

        public void debout(int deplX, int deplY, double diffAngle)
        {
            if (this.Cuisse.Angle <= 0 && base.Angle >= 0 && this.Pied.Angle >= 0 && verifd == false)
            {
                // Si la jambe n'est pas droite, on la remet droite

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                if (this.Cuisse.Angle != 0)
                {
                    this.Cuisse.Angle = 0;
                }

                if (this.Pied.Angle != 0)
                {
                    this.Pied.Angle = 0;
                }

                if (base.Angle != 0)
                {
                    base.Angle = 0;
                }

                if (this.Cuisse.Angle == 0 && base.Angle == 0 && this.Pied.Angle == 0)
                {
                    verifd = true;
                }
            }

            else if (verifd == true && base.Angle < Radian(30))
            {
                // On plie la jambe

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);

                base.Angle += angler;
                this.Cuisse.Angle -= angler;

            }

            else if (verifd == true && base.Angle >= Radian(30))
            {
                // Jambe plié, on avance

                angler = Radian(diffAngle);

                this.Cuisse.X = base.CIG.X;
                this.Cuisse.Y = base.CIG.Y;
                int[] vecteur = { base.MI.X - Cuisse.MS.X, base.MI.Y - Cuisse.MS.Y };
                this.Cuisse.X = base.CIG.X + vecteur[0];
                this.Cuisse.Y = base.CIG.Y + vecteur[1];
                this.Pied.X = Cuisse.CIG.X;
                this.Pied.Y = Cuisse.CIG.Y;
                this.roller1.X = Pied.CIG.X;
                this.roller1.Y = Pied.CIG.Y + 5;
                this.roller2.X = Pied.MI.X;
                this.roller2.Y = Pied.MI.Y + 5;
                this.roller3.X = Pied.CID.X;
                this.roller3.Y = Pied.CID.Y + 5;

                base.Bouger(deplX, deplY);
                this.Cuisse.Bouger(deplX, deplY);
                this.Pied.Bouger(deplX, deplY);
                this.roller1.Bouger(deplX, deplY);
                this.roller2.Bouger(deplX, deplY);
                this.roller3.Bouger(deplX, deplY);
            }

        }

        public override void Afficher(Graphics gr)
        {
            this.Cuisse.Afficher(gr);
            this.Pied.Afficher(gr);
            this.roller1.Afficher(gr);
            this.roller2.Afficher(gr);
            this.roller3.Afficher(gr);
            base.Afficher(gr);

        }

        public override void Cacher(IntPtr handle)
        {
            base.Cacher(handle);
            this.Cuisse.Cacher(handle);
            this.Pied.Cacher(handle);
            this.roller1.Cacher(handle);
            this.roller2.Cacher(handle);
            this.roller3.Cacher(handle);
        }
    }
}
