namespace AsK
{
    partial class ranking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ranking));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btncargardgv = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.JUGADOR_NIVEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JUGADOR_PUNTAJE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JUGADOR_NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Game Over", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepPink;
            this.label1.Location = new System.Drawing.Point(285, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "RANKING";
            // 
            // dgvRanking
            // 
            this.dgvRanking.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JUGADOR_NOMBRE,
            this.JUGADOR_PUNTAJE,
            this.JUGADOR_NIVEL});
            this.dgvRanking.GridColor = System.Drawing.Color.DarkMagenta;
            this.dgvRanking.Location = new System.Drawing.Point(120, 351);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.RowHeadersWidth = 51;
            this.dgvRanking.RowTemplate.Height = 24;
            this.dgvRanking.Size = new System.Drawing.Size(599, 280);
            this.dgvRanking.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnBack.Font = new System.Drawing.Font("Game Over", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Violet;
            this.btnBack.Location = new System.Drawing.Point(467, 667);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(172, 72);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btncargardgv
            // 
            this.btncargardgv.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btncargardgv.Font = new System.Drawing.Font("Game Over", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncargardgv.ForeColor = System.Drawing.Color.Violet;
            this.btncargardgv.Location = new System.Drawing.Point(197, 667);
            this.btncargardgv.Name = "btncargardgv";
            this.btncargardgv.Size = new System.Drawing.Size(172, 72);
            this.btncargardgv.TabIndex = 3;
            this.btncargardgv.Text = "LOAD";
            this.btncargardgv.UseVisualStyleBackColor = false;
            this.btncargardgv.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 771);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // JUGADOR_NIVEL
            // 
            this.JUGADOR_NIVEL.DataPropertyName = "JUGADOR_NIVEL";
            this.JUGADOR_NIVEL.HeaderText = "NIVEL";
            this.JUGADOR_NIVEL.MinimumWidth = 6;
            this.JUGADOR_NIVEL.Name = "JUGADOR_NIVEL";
            this.JUGADOR_NIVEL.Width = 125;
            // 
            // JUGADOR_PUNTAJE
            // 
            this.JUGADOR_PUNTAJE.DataPropertyName = "JUGADOR_PUNTAJE";
            this.JUGADOR_PUNTAJE.HeaderText = "PUNTAJE";
            this.JUGADOR_PUNTAJE.MinimumWidth = 6;
            this.JUGADOR_PUNTAJE.Name = "JUGADOR_PUNTAJE";
            this.JUGADOR_PUNTAJE.Width = 125;
            // 
            // JUGADOR_NOMBRE
            // 
            this.JUGADOR_NOMBRE.DataPropertyName = "JUGADOR_NOMBRE";
            this.JUGADOR_NOMBRE.HeaderText = "NOMBRE";
            this.JUGADOR_NOMBRE.MinimumWidth = 6;
            this.JUGADOR_NOMBRE.Name = "JUGADOR_NOMBRE";
            this.JUGADOR_NOMBRE.Width = 200;
            // 
            // ranking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 771);
            this.Controls.Add(this.btncargardgv);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvRanking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ranking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ranking";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btncargardgv;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUGADOR_NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUGADOR_PUNTAJE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JUGADOR_NIVEL;
    }
}