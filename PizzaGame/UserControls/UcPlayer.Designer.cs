namespace PizzaGame.UserControls
{
    partial class UcPlayer
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panComponents = new System.Windows.Forms.Panel();
            this.nudNrOfPizzasToEat = new System.Windows.Forms.NumericUpDown();
            this.btnEatPizzas = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNrOfPizzasToEat)).BeginInit();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPlayerName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(550, 50);
            this.lblPlayerName.TabIndex = 2;
            this.lblPlayerName.Text = "<PlayerName>";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panComponents
            // 
            this.panComponents.Controls.Add(this.nudNrOfPizzasToEat);
            this.panComponents.Controls.Add(this.btnEatPizzas);
            this.panComponents.Controls.Add(this.label5);
            this.panComponents.Location = new System.Drawing.Point(3, 3);
            this.panComponents.Name = "panComponents";
            this.panComponents.Size = new System.Drawing.Size(544, 114);
            this.panComponents.TabIndex = 10;
            // 
            // nudNrOfPizzasToEat
            // 
            this.nudNrOfPizzasToEat.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNrOfPizzasToEat.Location = new System.Drawing.Point(347, 15);
            this.nudNrOfPizzasToEat.Name = "nudNrOfPizzasToEat";
            this.nudNrOfPizzasToEat.ReadOnly = true;
            this.nudNrOfPizzasToEat.Size = new System.Drawing.Size(100, 44);
            this.nudNrOfPizzasToEat.TabIndex = 12;
            this.nudNrOfPizzasToEat.ValueChanged += new System.EventHandler(this.nudNrOfPizzasToEat_ValueChanged);
            this.nudNrOfPizzasToEat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nudNrOfPizzasToEat_KeyDown);
            // 
            // btnEatPizzas
            // 
            this.btnEatPizzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEatPizzas.Location = new System.Drawing.Point(93, 65);
            this.btnEatPizzas.Name = "btnEatPizzas";
            this.btnEatPizzas.Size = new System.Drawing.Size(354, 38);
            this.btnEatPizzas.TabIndex = 11;
            this.btnEatPizzas.Text = "Mangia pizze";
            this.btnEatPizzas.UseVisualStyleBackColor = true;
            this.btnEatPizzas.Click += new System.EventHandler(this.btnEatPizzas_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nr. pizze da mangiare:";
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panComponents);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 50);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(550, 120);
            this.panMain.TabIndex = 13;
            // 
            // UcPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "UcPlayer";
            this.Size = new System.Drawing.Size(550, 170);
            this.Resize += new System.EventHandler(this.UcPlayer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panComponents.ResumeLayout(false);
            this.panComponents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNrOfPizzasToEat)).EndInit();
            this.panMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panComponents;
        private System.Windows.Forms.NumericUpDown nudNrOfPizzasToEat;
        private System.Windows.Forms.Button btnEatPizzas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panMain;
    }
}
