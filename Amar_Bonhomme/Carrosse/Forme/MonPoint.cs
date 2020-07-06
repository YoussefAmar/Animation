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
    class MonPoint
    {
        #region Données membres
        private int _X = 0;
        private int _Y = 0;
        private bool _Visible = true;
        private PictureBox _Hebergeur;
        private Color _Fond = Color.Silver;
        private Color _Crayon = Color.Black;
        #endregion

        #region Constructeurs
        public MonPoint() 
        {
            this._Hebergeur = null;
        }

        public MonPoint(PictureBox hebergeur)
        {
            this._Hebergeur = hebergeur;
            this._Fond = hebergeur.BackColor;
        }

        public MonPoint(PictureBox hebergeur, int xy) : this (hebergeur)
        {
            X = Y = xy;
        }

        public MonPoint(PictureBox hebergeur, int x, int y) : this(hebergeur)
        {
            X = x;
            Y = y;
        }

        public MonPoint(PictureBox hebergeur, int xy, Color crayon) : this(hebergeur, xy)
        {
            Crayon = crayon;
        }

        public MonPoint(PictureBox hebergeur, int x, int y, Color crayon) : this(hebergeur, x, y)
        {
            Crayon = crayon;
        }
        #endregion

        #region Accesseurs
        public int X
        {
            get
            { return _X; }
            set {
                if (value < 0)
                { this._X = 0; }
                else if (value > this._Hebergeur.Bounds.Size.Width)
                { this._X = 0; }
                else
                { this._X = value; }
            }
        }

        public int Y
        {
            get
            { return _Y; }
            set
            {
                if (value < 0)
                { this._Y = 0; }
                else if (value > this._Hebergeur.Bounds.Size.Height)
                { this._Y = 0; }
                else
                { this._Y = value; }
            }
        }

        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; }
        }

        public Color Fond
        {
            get { return _Fond; }
            set {
                try { _Fond = value;}
                catch (Exception){}
            }
        }

        public Color Crayon
        {
            get { return _Crayon; }
            set {
                try { _Crayon = value;}
                catch (Exception){}
            }
        }

        public PictureBox Hebergeur
        {
            get { return _Hebergeur; }
            set { _Hebergeur = value; }
        }

        #endregion

        #region Méthodes
        public void Bouger(int deplX, int deplY)
        {
            X += deplX;
            Y += deplY;
        }

        #endregion
    }
}
