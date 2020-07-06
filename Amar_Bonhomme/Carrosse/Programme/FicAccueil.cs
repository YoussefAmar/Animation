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
    public partial class EcranAccueil : Form
    {
        private Super_Bonhomme sbo;
        private Decors scene;
        private Act1 Part1;
        private Act2 Part2;
        private BufferedGraphics bufferG = null;
        private Graphics g;
        private int v = 5,i = 0;

        public EcranAccueil()
        {
            InitializeComponent();
            // Modification contre le scintillement - Creation d'une mémoire tampon graphique

            bufferG = BufferedGraphicsManager.Current.Allocate(TV.CreateGraphics(), TV.DisplayRectangle);
            g = bufferG.Graphics;
        }

        private void timerImage_Tick(object sender, EventArgs e)
        {
                g.Clear(Color.LightBlue);
                scene.Afficher(g);

                if (i == 0)
                {
                    Part1.Afficher(g);
                }

                else
                {
                    Part2.Afficher(g);
                }

                if (sbo.X <= this.TV.Bounds.Width * 1 / 3)
                {
                    this.sbo.Bouger(v, 0);
                    this.sbo.Afficher(g);
                    bufferG.Render();

                    v++;

                    sbo.J++;

                    if (sbo.J >= 20)
                    {
                        sbo.J = 15;
                    }

                    if (v > 23)
                    {
                        v -= 1;
                    }

                }

                else if (sbo.X >= this.TV.Bounds.Width * 1 / 3 && sbo.X < this.TV.Bounds.Width * 3 / 4)
                {

                     v = 11;

                    this.sbo.accroupis(v, 0, 0);
                    this.sbo.Afficher(g);
                    bufferG.Render();

                    if (sbo.J > 20)
                    {
                        sbo.J--;
                    }

                    if (v > 15)
                    {
                        v -= 2;
                    }

                    else if (sbo.J <= 0)
                    {
                        sbo.J = 16;
                    }
                }

                else if (sbo.X >= this.TV.Bounds.Width * 3 / 4)
                {
                    this.sbo.debout(v, 0, 0);
                    v++;
                    this.sbo.Afficher(g);
                    bufferG.Render();

                    if (sbo.J > 20)
                    {
                        sbo.J--;
                    }

                    if (v > 6)
                    {
                        v -= 1;
                    }

                    else if (sbo.J <= 0)
                    {
                        sbo.J = 16;
                    }

                }

                if (sbo.X >= this.TV.Bounds.Width - 60)
                {
                    i++;
                    this.sbo = new Super_Bonhomme(this.TV, 0, 230, 40, 80);
                    v = 6;
                    this.sbo.accroupis(v, 0, 0);
                    this.sbo.Afficher(g);
                    bufferG.Render();
                }
        }


        private void btnStopDeplacerCTick_Click(object sender, EventArgs e)
        {
            this.timerImage.Stop();
            this.btnStopDeplacerCTick.Enabled = false;
        }

        private void btnEffacer_Click(object sender, EventArgs e)
        {
            Graphics gr = Graphics.FromHwnd(this.TV.Handle);
            gr.FillRectangle(new SolidBrush(this.TV.BackColor), 0, 0, this.TV.Bounds.Width, this.TV.Bounds.Height);
        }

        private void btnCreationBonhomme_Click(object sender, EventArgs e)
        {
            this.sbo = new Super_Bonhomme(this.TV, 0, 300, 40, 80);
            this.scene = new Decors(this.TV, 0, 0, 0, 0, 0, this.BackColor, this.BackColor);
            this.Part1 = new Act1(this.TV, 0, 0, 0, 0, 0, this.BackColor, this.BackColor);
            this.Part2 = new Act2(this.TV, 0, 0, 0, 0, 0, this.BackColor, this.BackColor);
            this.btnStopDeplacerCTick.Enabled = true;
            this.timerImage.Start();
            v = 6;
            i = 0;
        }
    }
}
