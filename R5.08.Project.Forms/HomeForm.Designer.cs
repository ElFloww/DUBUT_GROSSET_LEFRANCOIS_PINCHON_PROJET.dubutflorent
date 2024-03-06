namespace ProjetForm
{
    partial class HomeForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="p_Disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool p_Disposing)
        {
            if (p_Disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(p_Disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_LblHomeTitle = new System.Windows.Forms.Label();
            this.m_BtnHomePlay = new System.Windows.Forms.Button();
            this.m_BtnHomeScores = new System.Windows.Forms.Button();
            this.m_BtnHomeQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHomeTitle
            // 
            this.m_LblHomeTitle.AutoSize = true;
            this.m_LblHomeTitle.Font = new System.Drawing.Font("Verdana", 30F);
            this.m_LblHomeTitle.Location = new System.Drawing.Point(264, 84);
            this.m_LblHomeTitle.Name = "lblHomeTitle";
            this.m_LblHomeTitle.Size = new System.Drawing.Size(256, 48);
            this.m_LblHomeTitle.TabIndex = 0;
            this.m_LblHomeTitle.Text = "Puissance 4";
            // 
            // btnHomePlay
            // 
            this.m_BtnHomePlay.AutoSize = true;
            this.m_BtnHomePlay.BackColor = System.Drawing.Color.LightGreen;
            this.m_BtnHomePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_BtnHomePlay.FlatAppearance.BorderSize = 0;
            this.m_BtnHomePlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_BtnHomePlay.Font = new System.Drawing.Font("Verdana", 20F);
            this.m_BtnHomePlay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_BtnHomePlay.Location = new System.Drawing.Point(264, 214);
            this.m_BtnHomePlay.Name = "btnHomePlay";
            this.m_BtnHomePlay.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.m_BtnHomePlay.Size = new System.Drawing.Size(257, 42);
            this.m_BtnHomePlay.TabIndex = 1;
            this.m_BtnHomePlay.Text = "Jouer";
            this.m_BtnHomePlay.UseVisualStyleBackColor = false;
            this.m_BtnHomePlay.Click += new System.EventHandler(this.btnHomePlay_Click);
            // 
            // btnHomeScores
            // 
            this.m_BtnHomeScores.AutoSize = true;
            this.m_BtnHomeScores.BackColor = System.Drawing.Color.LightGray;
            this.m_BtnHomeScores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_BtnHomeScores.FlatAppearance.BorderSize = 0;
            this.m_BtnHomeScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_BtnHomeScores.Font = new System.Drawing.Font("Verdana", 15F);
            this.m_BtnHomeScores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_BtnHomeScores.Location = new System.Drawing.Point(285, 262);
            this.m_BtnHomeScores.Name = "btnHomeScores";
            this.m_BtnHomeScores.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.m_BtnHomeScores.Size = new System.Drawing.Size(214, 42);
            this.m_BtnHomeScores.TabIndex = 2;
            this.m_BtnHomeScores.Text = "Scores";
            this.m_BtnHomeScores.UseVisualStyleBackColor = false;
            this.m_BtnHomeScores.Click += new System.EventHandler(this.btnHomeScores_Click);
            // 
            // btnHomeQuit
            // 
            this.m_BtnHomeQuit.AutoSize = true;
            this.m_BtnHomeQuit.BackColor = System.Drawing.Color.LightCoral;
            this.m_BtnHomeQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_BtnHomeQuit.FlatAppearance.BorderSize = 0;
            this.m_BtnHomeQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_BtnHomeQuit.Font = new System.Drawing.Font("Verdana", 10F);
            this.m_BtnHomeQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_BtnHomeQuit.Location = new System.Drawing.Point(12, 422);
            this.m_BtnHomeQuit.Name = "btnHomeQuit";
            this.m_BtnHomeQuit.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.m_BtnHomeQuit.Size = new System.Drawing.Size(127, 27);
            this.m_BtnHomeQuit.TabIndex = 3;
            this.m_BtnHomeQuit.Text = "Quitter";
            this.m_BtnHomeQuit.UseVisualStyleBackColor = false;
            this.m_BtnHomeQuit.Click += new System.EventHandler(this.btnHomeQuit_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.m_BtnHomeQuit);
            this.Controls.Add(this.m_BtnHomeScores);
            this.Controls.Add(this.m_BtnHomePlay);
            this.Controls.Add(this.m_LblHomeTitle);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puissance 4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label m_LblHomeTitle;
        public System.Windows.Forms.Button m_BtnHomePlay;
        public System.Windows.Forms.Button m_BtnHomeScores;
        public System.Windows.Forms.Button m_BtnHomeQuit;
    }
}

