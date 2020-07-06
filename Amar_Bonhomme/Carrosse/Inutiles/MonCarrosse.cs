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
    class MonCarrosse : MonRectangle
    {
        #region Données membres
        private MonCercle _RoueG, _RoueD;
        private MonRectangle _Porte, _FenD, _FenG, _Poignee;
        #endregion

        #region Constructeurs
        public MonCarrosse(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg, longueur, hauteur)
        {
            this.RoueG = new MonCercle(hebergeur, xsg, ysg + hauteur, hauteur / 2, Color.Brown, Color.Brown);
            this.RoueD = new MonCercle(hebergeur, xsg + longueur, ysg + hauteur, hauteur / 2, Color.Brown, Color.Brown);
            this.FenG = new MonRectangle(hebergeur, longueur / 10 + xsg, hauteur / 6 +ysg, longueur / 5, hauteur / 3);
            this.FenD = new MonRectangle(hebergeur, xsg + longueur - 3 * longueur / 10, hauteur / 6 + ysg, longueur / 5, hauteur / 3);
            this.Porte = new MonRectangle(hebergeur, xsg + longueur / 2 - 2 * longueur / 15, ysg + hauteur - 3 * hauteur / 4 - 1, 4* longueur / 15, 3 * hauteur / 4);
            this.Poignee = new MonRectangle(hebergeur, xsg + longueur / 2 + longueur / 30, hauteur / 2 + ysg, longueur / 15, hauteur / 15);
            this.Crayon = Color.Red;
            this.Pot = Color.Gold;
            this.FenG.Pot = this.FenD.Pot = Color.Navy;
            this.Porte.Pot = Color.Red;
            this.Poignee.Pot = this.Poignee.Crayon = Color.Yellow;
        }
        #endregion

        #region Accesseurs
        public MonCercle RoueD
        {
            get { return _RoueD; }
            set { _RoueD = value; }
        }

        public MonCercle RoueG
        {
            get { return _RoueG; }
            set { _RoueG = value; }
        }

        public MonRectangle Poignee
        {
            get { return _Poignee; }
            set { _Poignee = value; }
        }

        public MonRectangle FenG
        {
            get { return _FenG; }
            set { _FenG = value; }
        }

        public MonRectangle FenD
        {
            get { return _FenD; }
            set { _FenD = value; }
        }

        public MonRectangle Porte
        {
            get { return _Porte; }
            set { _Porte = value; }
        }
        #endregion

        #region Méthodes
        public new void Bouger(int deplX, int deplY)
        {
            base.Bouger(deplX, deplY);
            this.RoueG.Bouger(deplX, deplY);
            this.RoueD.Bouger(deplX, deplY);
            this.FenG.Bouger(deplX, deplY);
            this.FenD.Bouger(deplX, deplY);
            this.Porte.Bouger(deplX, deplY);
            this.Poignee.Bouger(deplX, deplY);
        }

        public override void Afficher(Graphics gr)
        {
            base.Afficher(gr);
            this.RoueG.Afficher(gr);
            this.RoueD.Afficher(gr);
            this.FenG.Afficher(gr);
            this.FenD.Afficher(gr);
            this.Porte.Afficher(gr);
            this.Poignee.Afficher(gr);
        }
        #endregion
    }
}
