namespace ProjetForm
{
    partial class ScoresForm
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
            this.m_LblHomeTitle = new System.Windows.Forms.Label();
            this.m_BtnGameModeBack = new System.Windows.Forms.Button();
            this.m_ScoresGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_ScoresGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHomeTitle
            // 
            this.m_LblHomeTitle.AutoSize = true;
            this.m_LblHomeTitle.Font = new System.Drawing.Font("Verdana", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_LblHomeTitle.Location = new System.Drawing.Point(368, 58);
            this.m_LblHomeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_LblHomeTitle.Name = "lblHomeTitle";
            this.m_LblHomeTitle.Size = new System.Drawing.Size(154, 48);
            this.m_LblHomeTitle.TabIndex = 1;
            this.m_LblHomeTitle.Text = "Scores";
            // 
            // btnGameModeBack
            // 
            this.m_BtnGameModeBack.AutoSize = true;
            this.m_BtnGameModeBack.BackColor = System.Drawing.Color.LightCoral;
            this.m_BtnGameModeBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_BtnGameModeBack.FlatAppearance.BorderSize = 0;
            this.m_BtnGameModeBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_BtnGameModeBack.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.m_BtnGameModeBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_BtnGameModeBack.Location = new System.Drawing.Point(752, 14);
            this.m_BtnGameModeBack.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.m_BtnGameModeBack.Name = "btnGameModeBack";
            this.m_BtnGameModeBack.Padding = new System.Windows.Forms.Padding(35, 0, 35, 0);
            this.m_BtnGameModeBack.Size = new System.Drawing.Size(148, 31);
            this.m_BtnGameModeBack.TabIndex = 6;
            this.m_BtnGameModeBack.Text = "Retour";
            this.m_BtnGameModeBack.UseVisualStyleBackColor = false;
            this.m_BtnGameModeBack.Click += new System.EventHandler(this.btnGameModeBack_Click);
            // 
            // scoresGridView
            // 
            this.m_ScoresGridView.AllowUserToAddRows = false;
            this.m_ScoresGridView.AllowUserToDeleteRows = false;
            this.m_ScoresGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_ScoresGridView.Location = new System.Drawing.Point(37, 138);
            this.m_ScoresGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.m_ScoresGridView.Name = "scoresGridView";
            this.m_ScoresGridView.ReadOnly = true;
            this.m_ScoresGridView.Size = new System.Drawing.Size(840, 354);
            this.m_ScoresGridView.TabIndex = 7;
            // 
            // ScoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 532);
            this.Controls.Add(this.m_ScoresGridView);
            this.Controls.Add(this.m_BtnGameModeBack);
            this.Controls.Add(this.m_LblHomeTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ScoresForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puissance 4";
            this.Load += new System.EventHandler(this.ScoresForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_ScoresGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LblHomeTitle;
        private System.Windows.Forms.Button m_BtnGameModeBack;
        private System.Windows.Forms.DataGridView m_ScoresGridView;
    }
}