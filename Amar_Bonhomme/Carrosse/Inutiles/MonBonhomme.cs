using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Carrosse
{
    class MonBonhomme : MonRectangle
    {
        #region Données membres

        private MonRectangle torse;
        private Rectangle_movable brasg, brasd, piedg, piedd, jambeg, jambed;
        private MonCercle tete;

        #endregion

        #region Constructeurs

        public MonBonhomme(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur ) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {

            this.torse = new MonRectangle(hebergeur, xsg, ysg, longueur, hauteur, Color.Black, Color.Blue);
            this.tete = new MonCercle(hebergeur, xsg + longueur/2, ysg - longueur/3*2, longueur/3*2, Color.Black, Color.Brown);
            this.brasg = new Rectangle_movable(hebergeur, xsg + longueur/ 4, ysg, longueur / 2, hauteur * 4/5,Color.Black,Color.Red);
            this.brasd = new Rectangle_movable(hebergeur, xsg + longueur/4 , ysg, longueur / 2, hauteur * 4/5, Color.Black, Color.Red);
            this.piedg = new Rectangle_movable(hebergeur, xsg + longueur / 4, longueur * 5, 50, 15, Color.Green, Color.Black);
            this.piedd = new Rectangle_movable(hebergeur, xsg + longueur / 4, longueur * 5, 50, 15, Color.Green, Color.Black);
            this.jambeg = new Rectangle_movable(hebergeur, xsg + longueur/ 4, longueur*2 + hauteur*3/4, longueur*3/5, hauteur*4/5, Color.Black, Color.Green);
            this.jambed = new Rectangle_movable(hebergeur, xsg + longueur/4, longueur*2 + hauteur*3/4, longueur*3/5, hauteur*4/5, Color.Black, Color.Green);
        }

        #endregion

        #region Accesseurs

        public MonRectangle Torse { get => torse; set => torse = value; }
        public Rectangle_movable Brasg { get => brasg; set => brasg = value; }
        public Rectangle_movable Brasd { get => brasd; set => brasd = value; }
        public Rectangle_movable Piedg { get => piedg; set => piedg = value; }
        public Rectangle_movable Piedd { get => piedd; set => piedd = value; }
        public MonCercle Tete { get => tete; set => tete = value; }
        public Rectangle_movable Jambeg { get => jambeg; set => jambeg = value; }
        public Rectangle_movable Jambed { get => jambed; set => jambed = value; }

        #endregion

        #region Méthodes

        public void Bouger(int deplX, int deplY)
        {
            base.Bouger(deplX, deplY);
            this.torse.Bouger(deplX, deplY);
            this.tete.Bouger(deplX, deplY);
            this.brasg.Bouger(deplX, deplY);
            this.brasd.Bouger(deplX, deplY, 2);
            this.jambeg.Bouger(deplX, deplY, 2);
            this.jambed.Bouger(deplX, deplY);
            this.piedd.Bouger(deplX, deplY, 2);
            this.piedg.Bouger(deplX, deplY, 2);
        }

        public override void Afficher(Graphics gr)
        {
            base.Afficher(gr);
            this.torse.Afficher(gr);
            this.tete.Afficher(gr);
            this.brasg.Afficher(gr);
            this.brasd.Afficher(gr);
            this.jambeg.Afficher(gr);
            this.jambed.Afficher(gr);
            this.piedd.Afficher(gr);
            this.piedg.Afficher(gr);
        }

        #endregion
    }
}
