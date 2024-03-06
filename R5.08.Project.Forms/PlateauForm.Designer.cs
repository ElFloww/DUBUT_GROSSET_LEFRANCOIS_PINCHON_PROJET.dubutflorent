namespace ProjetForm
{
    partial class PlateauForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="p_Disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool p_Disposing)
        {
            if (p_Disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(p_Disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            m_PlateauJeu = new TableLayoutPanel();
            m_LblPlateauTimer = new Label();
            m_BtnPlateauAbandon = new Button();
            m_LblPlateauTour = new Label();
            m_LblToPlay = new Label();
            m_LblPlayerToPlay = new Label();
            m_BtnCol1 = new Button();
            m_BtnCol2 = new Button();
            m_BtnCol3 = new Button();
            m_BtnCol6 = new Button();
            m_BtnCol5 = new Button();
            m_BtnCol4 = new Button();
            m_BtnCol7 = new Button();
            m_GroupBoxWinner = new GroupBox();
            m_BtnWinnerHome = new Button();
            m_BtnWinnerQuitter = new Button();
            m_BtnWinnerPlay = new Button();
            m_LblWinner = new Label();
            m_LblCongrats = new Label();
            m_GroupBoxWinner.SuspendLayout();
            SuspendLayout();
            // 
            // plateauJeu
            // 
            m_PlateauJeu.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            m_PlateauJeu.ColumnCount = 7;
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28571F));
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28572F));
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28572F));
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28572F));
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.71951F));
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.63415F));
            m_PlateauJeu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.02439F));
            m_PlateauJeu.Location = new Point(507, 172);
            m_PlateauJeu.Margin = new Padding(5, 5, 5, 5);
            m_PlateauJeu.Name = "plateauJeu";
            m_PlateauJeu.RowCount = 6;
            m_PlateauJeu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            m_PlateauJeu.RowStyles.Add(new RowStyle(SizeType.Percent, 15.46392F));
            m_PlateauJeu.RowStyles.Add(new RowStyle(SizeType.Percent, 17.18213F));
            m_PlateauJeu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            m_PlateauJeu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            m_PlateauJeu.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            m_PlateauJeu.Size = new Size(440, 451);
            m_PlateauJeu.TabIndex = 3;
            // 
            // lblPlateauTimer
            // 
            m_LblPlateauTimer.AutoSize = true;
            m_LblPlateauTimer.Font = new Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point);
            m_LblPlateauTimer.Location = new Point(9, 13);
            m_LblPlateauTimer.Margin = new Padding(5, 0, 5, 0);
            m_LblPlateauTimer.Name = "lblPlateauTimer";
            m_LblPlateauTimer.Size = new Size(353, 31);
            m_LblPlateauTimer.TabIndex = 4;
            m_LblPlateauTimer.Text = "Temps écoulé : 0 secondes";
            // 
            // btnPlateauAbandon
            // 
            m_BtnPlateauAbandon.AutoSize = true;
            m_BtnPlateauAbandon.BackColor = Color.LightCoral;
            m_BtnPlateauAbandon.Cursor = Cursors.Hand;
            m_BtnPlateauAbandon.FlatAppearance.BorderSize = 0;
            m_BtnPlateauAbandon.FlatStyle = FlatStyle.Flat;
            m_BtnPlateauAbandon.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            m_BtnPlateauAbandon.ImageAlign = ContentAlignment.MiddleRight;
            m_BtnPlateauAbandon.Location = new Point(16, 649);
            m_BtnPlateauAbandon.Margin = new Padding(5, 5, 5, 5);
            m_BtnPlateauAbandon.Name = "btnPlateauAbandon";
            m_BtnPlateauAbandon.Padding = new Padding(21, 0, 21, 0);
            m_BtnPlateauAbandon.Size = new Size(155, 41);
            m_BtnPlateauAbandon.TabIndex = 6;
            m_BtnPlateauAbandon.Text = "Abandonner";
            m_BtnPlateauAbandon.UseVisualStyleBackColor = false;
            m_BtnPlateauAbandon.Click += btnPlateauAbandon_Click;
            // 
            // lblPlateauTour
            // 
            m_LblPlateauTour.AutoSize = true;
            m_LblPlateauTour.Font = new Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point);
            m_LblPlateauTour.Location = new Point(77, 228);
            m_LblPlateauTour.Margin = new Padding(5, 0, 5, 0);
            m_LblPlateauTour.Name = "lblPlateauTour";
            m_LblPlateauTour.Size = new Size(157, 31);
            m_LblPlateauTour.TabIndex = 7;
            m_LblPlateauTour.Text = "Au tour de ";
            // 
            // lblToPlay
            // 
            m_LblToPlay.AutoSize = true;
            m_LblToPlay.Font = new Font("Verdana", 15F, FontStyle.Regular, GraphicsUnit.Point);
            m_LblToPlay.Location = new Point(77, 372);
            m_LblToPlay.Margin = new Padding(5, 0, 5, 0);
            m_LblToPlay.Name = "lblToPlay";
            m_LblToPlay.Size = new Size(120, 31);
            m_LblToPlay.TabIndex = 8;
            m_LblToPlay.Text = "de jouer";
            // 
            // lblPlayerToPlay
            // 
            m_LblPlayerToPlay.AutoSize = true;
            m_LblPlayerToPlay.Font = new Font("Verdana", 20F, FontStyle.Regular, GraphicsUnit.Point);
            m_LblPlayerToPlay.Location = new Point(128, 293);
            m_LblPlayerToPlay.Margin = new Padding(5, 0, 5, 0);
            m_LblPlayerToPlay.Name = "lblPlayerToPlay";
            m_LblPlayerToPlay.Size = new Size(190, 41);
            m_LblPlayerToPlay.TabIndex = 9;
            m_LblPlayerToPlay.Text = "JOUEUR 1";
            // 
            // btnCol1
            // 
            m_BtnCol1.Location = new Point(511, 100);
            m_BtnCol1.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol1.Name = "btnCol1";
            m_BtnCol1.Size = new Size(61, 63);
            m_BtnCol1.TabIndex = 10;
            m_BtnCol1.Text = "v";
            m_BtnCol1.UseVisualStyleBackColor = true;
            m_BtnCol1.Click += buttonColonne_Click;
            // 
            // btnCol2
            // 
            m_BtnCol2.Location = new Point(573, 100);
            m_BtnCol2.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol2.Name = "btnCol2";
            m_BtnCol2.Size = new Size(61, 63);
            m_BtnCol2.TabIndex = 11;
            m_BtnCol2.Text = "v";
            m_BtnCol2.UseVisualStyleBackColor = true;
            m_BtnCol2.Click += buttonColonne_Click;
            // 
            // btnCol3
            // 
            m_BtnCol3.Location = new Point(635, 100);
            m_BtnCol3.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol3.Name = "btnCol3";
            m_BtnCol3.Size = new Size(61, 63);
            m_BtnCol3.TabIndex = 12;
            m_BtnCol3.Text = "v";
            m_BtnCol3.UseVisualStyleBackColor = true;
            m_BtnCol3.Click += buttonColonne_Click;
            // 
            // btnCol6
            // 
            m_BtnCol6.Location = new Point(821, 100);
            m_BtnCol6.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol6.Name = "btnCol6";
            m_BtnCol6.Size = new Size(61, 63);
            m_BtnCol6.TabIndex = 15;
            m_BtnCol6.Text = "v";
            m_BtnCol6.UseVisualStyleBackColor = true;
            m_BtnCol6.Click += buttonColonne_Click;
            // 
            // btnCol5
            // 
            m_BtnCol5.Location = new Point(759, 100);
            m_BtnCol5.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol5.Name = "btnCol5";
            m_BtnCol5.Size = new Size(61, 63);
            m_BtnCol5.TabIndex = 14;
            m_BtnCol5.Text = "v";
            m_BtnCol5.UseVisualStyleBackColor = true;
            m_BtnCol5.Click += buttonColonne_Click;
            // 
            // btnCol4
            // 
            m_BtnCol4.Location = new Point(696, 100);
            m_BtnCol4.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol4.Name = "btnCol4";
            m_BtnCol4.Size = new Size(61, 63);
            m_BtnCol4.TabIndex = 13;
            m_BtnCol4.Text = "v";
            m_BtnCol4.UseVisualStyleBackColor = true;
            m_BtnCol4.Click += buttonColonne_Click;
            // 
            // btnCol7
            // 
            m_BtnCol7.Location = new Point(885, 100);
            m_BtnCol7.Margin = new Padding(5, 5, 5, 5);
            m_BtnCol7.Name = "btnCol7";
            m_BtnCol7.Size = new Size(61, 63);
            m_BtnCol7.TabIndex = 16;
            m_BtnCol7.Text = "v";
            m_BtnCol7.UseVisualStyleBackColor = true;
            m_BtnCol7.Click += buttonColonne_Click;
            // 
            // groupBoxWinner
            // 
            m_GroupBoxWinner.BackColor = Color.Transparent;
            m_GroupBoxWinner.Controls.Add(m_BtnWinnerHome);
            m_GroupBoxWinner.Controls.Add(m_BtnWinnerQuitter);
            m_GroupBoxWinner.Controls.Add(m_BtnWinnerPlay);
            m_GroupBoxWinner.Controls.Add(m_LblWinner);
            m_GroupBoxWinner.Controls.Add(m_LblCongrats);
            m_GroupBoxWinner.Font = new Font("Verdana", 1F, FontStyle.Regular, GraphicsUnit.Point);
            m_GroupBoxWinner.Location = new Point(16, 205);
            m_GroupBoxWinner.Margin = new Padding(5, 5, 5, 5);
            m_GroupBoxWinner.Name = "groupBoxWinner";
            m_GroupBoxWinner.Padding = new Padding(5, 5, 5, 5);
            m_GroupBoxWinner.Size = new Size(481, 299);
            m_GroupBoxWinner.TabIndex = 17;
            m_GroupBoxWinner.TabStop = false;
            m_GroupBoxWinner.Visible = false;
            // 
            // btnWinnerHome
            // 
            m_BtnWinnerHome.AutoSize = true;
            m_BtnWinnerHome.BackColor = Color.LightGray;
            m_BtnWinnerHome.Cursor = Cursors.Hand;
            m_BtnWinnerHome.FlatAppearance.BorderSize = 0;
            m_BtnWinnerHome.FlatStyle = FlatStyle.Flat;
            m_BtnWinnerHome.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            m_BtnWinnerHome.ImageAlign = ContentAlignment.MiddleRight;
            m_BtnWinnerHome.Location = new Point(143, 145);
            m_BtnWinnerHome.Margin = new Padding(5, 5, 5, 5);
            m_BtnWinnerHome.Name = "btnWinnerHome";
            m_BtnWinnerHome.Padding = new Padding(21, 0, 21, 0);
            m_BtnWinnerHome.Size = new Size(158, 41);
            m_BtnWinnerHome.TabIndex = 19;
            m_BtnWinnerHome.Text = "Menu Principal";
            m_BtnWinnerHome.UseVisualStyleBackColor = false;
            m_BtnWinnerHome.Click += btnWinnerHome_Click;
            // 
            // btnWinnerQuitter
            // 
            m_BtnWinnerQuitter.AutoSize = true;
            m_BtnWinnerQuitter.BackColor = Color.LightCoral;
            m_BtnWinnerQuitter.Cursor = Cursors.Hand;
            m_BtnWinnerQuitter.FlatAppearance.BorderSize = 0;
            m_BtnWinnerQuitter.FlatStyle = FlatStyle.Flat;
            m_BtnWinnerQuitter.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            m_BtnWinnerQuitter.ImageAlign = ContentAlignment.MiddleRight;
            m_BtnWinnerQuitter.Location = new Point(311, 145);
            m_BtnWinnerQuitter.Margin = new Padding(5, 5, 5, 5);
            m_BtnWinnerQuitter.Name = "btnWinnerQuitter";
            m_BtnWinnerQuitter.Padding = new Padding(21, 0, 21, 0);
            m_BtnWinnerQuitter.Size = new Size(155, 41);
            m_BtnWinnerQuitter.TabIndex = 18;
            m_BtnWinnerQuitter.Text = "Quitter";
            m_BtnWinnerQuitter.UseVisualStyleBackColor = false;
            m_BtnWinnerQuitter.Click += btnWinnerQuitter_Click;
            // 
            // btnWinnerPlay
            // 
            m_BtnWinnerPlay.AutoSize = true;
            m_BtnWinnerPlay.BackColor = Color.LightGreen;
            m_BtnWinnerPlay.Cursor = Cursors.Hand;
            m_BtnWinnerPlay.FlatAppearance.BorderSize = 0;
            m_BtnWinnerPlay.FlatStyle = FlatStyle.Flat;
            m_BtnWinnerPlay.Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
            m_BtnWinnerPlay.ImageAlign = ContentAlignment.MiddleRight;
            m_BtnWinnerPlay.Location = new Point(10, 145);
            m_BtnWinnerPlay.Margin = new Padding(5, 5, 5, 5);
            m_BtnWinnerPlay.Name = "btnWinnerPlay";
            m_BtnWinnerPlay.Padding = new Padding(21, 0, 21, 0);
            m_BtnWinnerPlay.Size = new Size(124, 41);
            m_BtnWinnerPlay.TabIndex = 7;
            m_BtnWinnerPlay.Text = "Rejouer";
            m_BtnWinnerPlay.UseVisualStyleBackColor = false;
            m_BtnWinnerPlay.Click += btnWinnerPlay_Click;
            // 
            // lblWinner
            // 
            m_LblWinner.Font = new Font("Verdana", 20F, FontStyle.Regular, GraphicsUnit.Point);
            m_LblWinner.Location = new Point(2, 11);
            m_LblWinner.Margin = new Padding(5, 0, 5, 0);
            m_LblWinner.Name = "lblWinner";
            m_LblWinner.Size = new Size(476, 51);
            m_LblWinner.TabIndex = 1;
            m_LblWinner.Text = "Le JOUEUR 1 a gagné !";
            m_LblWinner.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCongrats
            // 
            m_LblCongrats.AutoSize = true;
            m_LblCongrats.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point);
            m_LblCongrats.Location = new Point(140, 68);
            m_LblCongrats.Margin = new Padding(5, 0, 5, 0);
            m_LblCongrats.Name = "lblCongrats";
            m_LblCongrats.Size = new Size(217, 20);
            m_LblCongrats.TabIndex = 0;
            m_LblCongrats.Text = "Bien jouer aux joueurs !";
            // 
            // PlateauForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 709);
            Controls.Add(m_GroupBoxWinner);
            Controls.Add(m_BtnCol7);
            Controls.Add(m_BtnCol6);
            Controls.Add(m_BtnCol5);
            Controls.Add(m_BtnCol4);
            Controls.Add(m_BtnCol3);
            Controls.Add(m_BtnCol2);
            Controls.Add(m_BtnCol1);
            Controls.Add(m_LblPlayerToPlay);
            Controls.Add(m_LblToPlay);
            Controls.Add(m_LblPlateauTour);
            Controls.Add(m_BtnPlateauAbandon);
            Controls.Add(m_LblPlateauTimer);
            Controls.Add(m_PlateauJeu);
            Margin = new Padding(5, 5, 5, 5);
            Name = "PlateauForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Puissance 4";
            Load += PlateauForm_Load;
            m_GroupBoxWinner.ResumeLayout(false);
            m_GroupBoxWinner.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel m_PlateauJeu;
        private Label m_LblPlateauTimer;
        private Button m_BtnPlateauAbandon;
        private Label m_LblPlateauTour;
        private Label m_LblToPlay;
        private Label m_LblPlayerToPlay;
        private Button m_BtnCol1;
        private Button m_BtnCol2;
        private Button m_BtnCol3;
        private Button m_BtnCol6;
        private Button m_BtnCol5;
        private Button m_BtnCol4;
        private Button m_BtnCol7;
        private GroupBox m_GroupBoxWinner;
        private Label m_LblWinner;
        private Label m_LblCongrats;
        private Button m_BtnWinnerPlay;
        private Button m_BtnWinnerQuitter;
        private Button m_BtnWinnerHome;
    }
}