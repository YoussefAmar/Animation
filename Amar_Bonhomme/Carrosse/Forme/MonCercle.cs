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
    class MonCercle : MonPoint
    {
        #region Données membres
        private Color _Pot = Color.Red;
        private bool _Remplir = true;
        private int _Rayon = 1;
        #endregion

        #region Constructeurs
        public MonCercle(PictureBox hebergeur, int xc, int yc, int rayon) : base(hebergeur, xc, yc)
        {
            Rayon = rayon;
        }

        public MonCercle(PictureBox hebergeur, int xc, int yc, int rayon, Color pot) : base(hebergeur, xc, yc)
        {
            Rayon = rayon;
            Pot = pot;
        }

        public MonCercle(PictureBox hebergeur, int xc, int yc, int rayon, Color crayon, Color pot) : base(hebergeur, xc, yc, crayon)
        {
            Rayon = rayon;
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

        public int Rayon
        {
            get { return _Rayon; }
            set 
            {
                if (value < 0) { _Rayon = 1; }
                else { _Rayon = value; }
            }
        }
        #endregion

        #region Méthodes

        public void Afficher(Graphics gr)
        {
            if (this.Visible)
            {
                if (this.Remplir)
                {
                    gr.FillEllipse(new SolidBrush(this.Pot), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
                }
                gr.DrawEllipse(new Pen(this.Crayon), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
            }
        }

        public void Cacher(IntPtr handle)
        {
            Graphics gr = Graphics.FromHwnd(handle);
            if (this.Remplir)
            {
                gr.FillEllipse(new SolidBrush(this.Fond), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
            }
            gr.DrawEllipse(new Pen(this.Fond), this.X - this.Rayon, this.Y - this.Rayon, 2 * this.Rayon, 2 * this.Rayon);
        }
        #endregion
    }
}
