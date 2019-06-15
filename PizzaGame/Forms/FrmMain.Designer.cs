namespace PizzaGame.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panMain = new System.Windows.Forms.Panel();
            this.lblPizzasNr = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ucPlayerA = new PizzaGame.UserControls.UcPlayer();
            this.ucPlayerB = new PizzaGame.UserControls.UcPlayer();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.panMain.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMain.Controls.Add(this.lblPizzasNr);
            this.panMain.Controls.Add(this.tableLayoutPanel);
            this.panMain.Controls.Add(this.btnStartGame);
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(585, 461);
            this.panMain.TabIndex = 0;
            // 
            // lblPizzasNr
            // 
            this.lblPizzasNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPizzasNr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblPizzasNr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPizzasNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPizzasNr.ForeColor = System.Drawing.Color.Maroon;
            this.lblPizzasNr.Location = new System.Drawing.Point(12, 54);
            this.lblPizzasNr.Name = "lblPizzasNr";
            this.lblPizzasNr.Size = new System.Drawing.Size(560, 41);
            this.lblPizzasNr.TabIndex = 1;
            this.lblPizzasNr.Text = "Numero pizze: 12";
            this.lblPizzasNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.ucPlayerA, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ucPlayerB, 0, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 98);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(560, 351);
            this.tableLayoutPanel.TabIndex = 2;
            // 
            // ucPlayerA
            // 
            this.ucPlayerA.BackColor = System.Drawing.Color.Silver;
            this.ucPlayerA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayerA.Location = new System.Drawing.Point(3, 3);
            this.ucPlayerA.Name = "ucPlayerA";
            this.ucPlayerA.PlayerName = "GIOCATORE A";
            this.ucPlayerA.PlayerNumber = ((byte)(1));
            this.ucPlayerA.Size = new System.Drawing.Size(554, 169);
            this.ucPlayerA.TabIndex = 4;
            this.ucPlayerA.PizzasEaten += new System.EventHandler<PizzaGame.UserControls.UcPlayer.PizzasEatenEventArgs>(this.ucPlayer_PizzasEaten);
            // 
            // ucPlayerB
            // 
            this.ucPlayerB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ucPlayerB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlayerB.Location = new System.Drawing.Point(3, 178);
            this.ucPlayerB.Name = "ucPlayerB";
            this.ucPlayerB.PlayerName = "GIOCATORE B";
            this.ucPlayerB.PlayerNumber = ((byte)(2));
            this.ucPlayerB.Size = new System.Drawing.Size(554, 170);
            this.ucPlayerB.TabIndex = 5;
            this.ucPlayerB.PizzasEaten += new System.EventHandler<PizzaGame.UserControls.UcPlayer.PizzasEatenEventArgs>(this.ucPlayer_PizzasEaten);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(12, 3);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(560, 39);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "INIZIA GIOCO";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.panMain);
            this.MinimumSize = new System.Drawing.Size(412, 462);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PizzaGame";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panMain.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblPizzasNr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private UserControls.UcPlayer ucPlayerA;
        private UserControls.UcPlayer ucPlayerB;
    }
}

