namespace Carrosse
{
    partial class EcranAccueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerImage = new System.Windows.Forms.Timer(this.components);
            this.btnEffacer = new System.Windows.Forms.Button();
            this.btnStopDeplacerCTick = new System.Windows.Forms.Button();
            this.btnCreationBonhomme = new System.Windows.Forms.Button();
            this.TV = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TV)).BeginInit();
            this.SuspendLayout();
            // 
            // timerImage
            // 
            this.timerImage.Interval = 40;
            this.timerImage.Tick += new System.EventHandler(this.timerImage_Tick);
            // 
            // btnEffacer
            // 
            this.btnEffacer.Location = new System.Drawing.Point(13, 950);
            this.btnEffacer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEffacer.Name = "btnEffacer";
            this.btnEffacer.Size = new System.Drawing.Size(584, 35);
            this.btnEffacer.TabIndex = 10;
            this.btnEffacer.Text = "Effacer Tout";
            this.btnEffacer.UseVisualStyleBackColor = true;
            this.btnEffacer.Click += new System.EventHandler(this.btnEffacer_Click);
            // 
            // btnStopDeplacerCTick
            // 
            this.btnStopDeplacerCTick.Enabled = false;
            this.btnStopDeplacerCTick.Location = new System.Drawing.Point(1331, 950);
            this.btnStopDeplacerCTick.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStopDeplacerCTick.Name = "btnStopDeplacerCTick";
            this.btnStopDeplacerCTick.Size = new System.Drawing.Size(580, 35);
            this.btnStopDeplacerCTick.TabIndex = 9;
            this.btnStopDeplacerCTick.Text = "Stop Tick";
            this.btnStopDeplacerCTick.UseVisualStyleBackColor = true;
            this.btnStopDeplacerCTick.Click += new System.EventHandler(this.btnStopDeplacerCTick_Click);
            // 
            // btnCreationBonhomme
            // 
            this.btnCreationBonhomme.Location = new System.Drawing.Point(419, 905);
            this.btnCreationBonhomme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreationBonhomme.Name = "btnCreationBonhomme";
            this.btnCreationBonhomme.Size = new System.Drawing.Size(1173, 35);
            this.btnCreationBonhomme.TabIndex = 12;
            this.btnCreationBonhomme.Text = "Creer Bonhomme";
            this.btnCreationBonhomme.UseVisualStyleBackColor = true;
            this.btnCreationBonhomme.Click += new System.EventHandler(this.btnCreationBonhomme_Click);
            // 
            // TV
            // 
            this.TV.BackColor = System.Drawing.SystemColors.Desktop;
            this.TV.BackgroundImage = global::Carrosse.Properties.Resources.logo_Roller_1024x6722;
            this.TV.Location = new System.Drawing.Point(2, -1);
            this.TV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(1920, 1051);
            this.TV.TabIndex = 0;
            this.TV.TabStop = false;
            // 
            // EcranAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.btnCreationBonhomme);
            this.Controls.Add(this.btnEffacer);
            this.Controls.Add(this.btnStopDeplacerCTick);
            this.Controls.Add(this.TV);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EcranAccueil";
            this.Text = "Dessins Animés";
            ((System.ComponentModel.ISupportInitialize)(this.TV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox TV;
        private System.Windows.Forms.Timer timerImage;
        private System.Windows.Forms.Button btnEffacer;
        private System.Windows.Forms.Button btnStopDeplacerCTick;
        private System.Windows.Forms.Button btnCreationBonhomme;
    }
}

