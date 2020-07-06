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
    class Super_Bonhomme : MonRectangle
    {
        #region Données membres

        private Rectangle_movable torse;
        private Bras brasg, brasd;
        private Jambe jambeg, jambed;
        private MonCercle tete,oeil,pupille;
        private int ba = 4, bb = 0, ja = 0, jb = 0, j = 15, i = 0,t = 0;
        private bool descendre = false, saute = false;

        #endregion


       public Super_Bonhomme(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur ) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this.torse = new Rectangle_movable(hebergeur, xsg, ysg, longueur*12/15, hauteur, Color.Black, Color.OrangeRed);
            this.tete = new MonCercle(hebergeur, xsg + longueur / 2 , ysg - longueur / 3 * 2, longueur*2 / 3, Color.Black, Color.Brown);
            this.oeil = new MonCercle(hebergeur, xsg + longueur - 5, ysg - longueur / 3 * 2, longueur * 2/11, Color.Black, Color.White);
            this.pupille = new MonCercle(hebergeur, xsg + longueur, ysg - longueur / 3 * 2, longueur * 2 / 18, Color.Black, Color.Black);
            this.brasg = new Bras(hebergeur, xsg + longueur / 4, ysg + hauteur/8, longueur / 2, hauteur * 6 / 15, 15 , Color.Black, Color.DarkOrange);
            this.brasd = new Bras(hebergeur, xsg + longueur / 4, ysg + hauteur/8, longueur / 2, hauteur * 5 / 15, 0f ,Color.Black, Color.DarkOrange);
            this.jambeg = new Jambe(hebergeur, xsg + longueur / 5, ysg + hauteur* 9/10, longueur/2, hauteur * 7/15, 10 ,Color.Black, Color.Blue);
            this.jambed = new Jambe(hebergeur, xsg + longueur / 5, ysg + hauteur* 9/10, longueur/2, hauteur * 7/15, 0f ,Color.Black, Color.Blue);

            ja = J;

        }

        #region Accesseurs

        public Rectangle_movable Torse { get => torse; set => torse = value; }
        public Bras Brasg { get => brasg; set => brasg = value; }
        public Bras Brasd { get => brasd; set => brasd = value; }
        public MonCercle Tete { get => tete; set => tete = value; }
        public Jambe Jambeg { get => jambeg; set => jambeg = value; }
        public Jambe Jambed { get => jambed; set => jambed = value; }
        public int BA { get => ba; set => ba = value; }
        public int BB { get => bb; set => bb = value; }
        public int Ja { get => ja; set => ja = value; }
        public int Jb { get => jb; set => jb = value; }
        internal MonCercle Oeil { get => oeil; set => oeil = value; }
        internal MonCercle Pupille { get => pupille; set => pupille = value; }
        public int J { get => j; set => j = value; }
        public bool Descendre { get => descendre; set => descendre = value; }
        public int I { get => i; set => i = value; }
        public bool Sauter { get => this.saute; set => this.saute = value; }
        public int T { get => t; set => t = value; }

        #endregion

        #region Méthodes

        public void Bouger(int deplX, int deplY)
        {
            base.Bouger(deplX, deplY);
            this.torse.Bouger(deplX, deplY);
            this.tete.Bouger(deplX, deplY);
            this.oeil.Bouger(deplX, deplY);
            this.pupille.Bouger(deplX, deplY);
            this.brasg.Bouger(deplX, deplY,ba);

            if(brasg.Angle >= brasg.Limite_angle)
            {
                bb = ba;
            }

            this.brasd.Bouger(deplX, deplY,bb);

            this.jambeg.Bouger(deplX, deplY,ja);

            if (jambeg.Angle == 0)
            {
                jb = J;
                ja = 0;
            }

            this.jambed.Bouger(deplX, deplY,jb);

            if (jambed.Angle == 0)
            {
                ja = J;
                jb = 0;
            }

        }

        public void accroupis(int deplX, int deplY, double diffAngle)
        {

            base.Bouger(deplX, deplY);
            this.torse.Bouger(deplX, deplY);
            this.tete.Bouger(deplX, deplY);
            this.oeil.Bouger(deplX, deplY);
            this.pupille.Bouger(deplX, deplY);
            this.brasg.Bouger(deplX, deplY, ba);

            if (brasg.Angle >= brasg.Limite_angle)
            {
                bb = ba;
            }

            this.brasd.Bouger(deplX, deplY, bb);

            jambed.accroupis(deplX,deplY, J);

            jambeg.accroupis(deplX,deplY, J);

            if(descendre == false)
            {
                base.Y += 5;
                this.torse.Y += 5;
                this.tete.Y += 5;
                this.oeil.Y += 5;
                this.pupille.Y += 5;
                this.brasg.Y += 5;
                this.brasd.Y += 5;
                this.jambed.Y += 5;
                this.jambeg.Y += 5;

                i++;

                if(i == 12)
                {
                    descendre = true;
                }
            }

        }

        public void debout(int deplX, int deplY, double diffAngle)
        {
            base.Bouger(deplX, deplY);
            this.torse.Bouger(deplX, deplY);
            this.tete.Bouger(deplX, deplY);
            this.oeil.Bouger(deplX, deplY);
            this.pupille.Bouger(deplX, deplY);
            this.brasg.Bouger(deplX, deplY, ba);

            if (brasg.Angle >= brasg.Limite_angle)
            {
                bb = ba;
            }

            this.brasd.Bouger(deplX, deplY, bb);

            jambed.debout(deplX, deplY, J);

            jambeg.debout(deplX, deplY, J);

            if (saute == false)
            {
                base.Y -= 10;
                this.torse.Y -= 10;
                this.tete.Y -= 10;
                this.oeil.Y -= 10;
                this.pupille.Y -= 10;
                this.brasg.Y -= 10;
                this.brasd.Y -= 10;
                this.jambed.Y -= 10;
                this.jambeg.Y -= 10;

                t++;

                if (t == 12)
                {
                    saute = true;
                }
            }

            else if (saute == true && t < 20)
            {
                base.Y += 5;
                this.torse.Y += 5;
                this.tete.Y += 5;
                this.oeil.Y += 5;
                this.pupille.Y += 5;
                this.brasg.Y += 5;
                this.brasd.Y += 5;
                this.jambed.Y += 5;
                this.jambeg.Y += 5;

                t++;

            }
        }

        public override void Afficher(Graphics gr)
        {
            this.brasd.Afficher(gr);
            this.jambed.Afficher(gr);
            this.torse.Afficher(gr);
            this.tete.Afficher(gr);
            this.oeil.Afficher(gr);
            this.pupille.Afficher(gr);
            this.jambeg.Afficher(gr);
            this.brasg.Afficher(gr);

        }

        #endregion

    }
}
