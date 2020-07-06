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
    class MonRectangle : MonPoint
    {
        #region Données membres

        private Color _Pot = Color.Red;
        private bool _Remplir = true;
        private int _Hauteur = 1;
        private int _Longueur = 1;

        #endregion

        #region Constructeurs

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
        }

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color pot) : base(hebergeur, xsg, ysg, pot)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }

        public MonRectangle(PictureBox hebergeur, int xsg, int ysg, int longueur, int hauteur, Color crayon, Color pot) : base(hebergeur, xsg, ysg)
        {
            Longueur = longueur;
            Hauteur = hauteur;
            Pot = pot;
        }

        #endregion

        #region Accesseurs

        public Color Pot
        {
            get { return _Pot; }
            set {
                try { _Pot = value;}
                catch (Exception){}
            }
        }

        public bool Remplir
        {
            get { return _Remplir; }
            set { _Remplir = value; }
        }

        public int Longueur
        {
            get { return _Longueur; }
            set 
            {
                if (value < 0)
                { _Longueur = 1; }
                else
                { _Longueur = value; }
            }
        }

        public int Hauteur
        {
            get
            { return _Hauteur; }
            set
            {
                if (value < 0)
                { _Hauteur = 1; }
                else
                { _Hauteur = value; }
            }
        }

        #endregion

        #region Méthodes

        public virtual void Afficher(Graphics gr)
        {
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillRectangle(new SolidBrush(this.Pot), this.X, this.Y, this.Longueur, this.Hauteur);
                }
                gr.DrawRectangle(new Pen(this.Crayon), this.X, this.Y, this.Longueur, this.Hauteur);
            }
        }

        public virtual void Cacher(IntPtr handle)
        {
            Graphics gr = Graphics.FromHwnd(handle);
            if (this.Remplir)
            {
                gr.FillRectangle(new SolidBrush(this.Fond), this.X, this.Y, this.Longueur, this.Hauteur);
            }
            gr.DrawRectangle(new Pen(this.Fond), this.X, this.Y, this.Longueur, this.Hauteur);
        }
        #endregion
    }
}
