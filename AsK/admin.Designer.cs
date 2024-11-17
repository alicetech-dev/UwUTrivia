namespace AsK
{
    partial class admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnErase = new System.Windows.Forms.Button();
            this.comboBoxPlayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.textBoxImage = new System.Windows.Forms.TextBox();
            this.textBoxRolID = new System.Windows.Forms.TextBox();
            this.textBoxPuntaje = new System.Windows.Forms.TextBox();
            this.textBoxNivel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPanelAdd = new System.Windows.Forms.Button();
            this.btnPanelActualizar = new System.Windows.Forms.Button();
            this.btnPanelErase = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.panelAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Game Over", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(0, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Mode";
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.BackgroundColor = System.Drawing.Color.DarkMagenta;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(144, 12);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.RowHeadersWidth = 51;
            this.dgvPlayers.RowTemplate.Height = 24;
            this.dgvPlayers.Size = new System.Drawing.Size(644, 113);
            this.dgvPlayers.TabIndex = 1;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.DeepPink;
            this.btnShow.Font = new System.Drawing.Font("Game Over", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnShow.Location = new System.Drawing.Point(12, 725);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(136, 34);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show Players";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepPink;
            this.btnAdd.Font = new System.Drawing.Font("Game Over", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAdd.Location = new System.Drawing.Point(344, 725);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(136, 34);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Player";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DeepPink;
            this.btnUpdate.Font = new System.Drawing.Font("Game Over", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnUpdate.Location = new System.Drawing.Point(513, 725);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(136, 34);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update Player";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdatePlayer_Click);
            // 
            // btnErase
            // 
            this.btnErase.BackColor = System.Drawing.Color.DeepPink;
            this.btnErase.Font = new System.Drawing.Font("Game Over", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErase.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnErase.Location = new System.Drawing.Point(177, 725);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(136, 34);
            this.btnErase.TabIndex = 5;
            this.btnErase.Text = "Erase Player";
            this.btnErase.UseVisualStyleBackColor = false;
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // comboBoxPlayers
            // 
            this.comboBoxPlayers.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.comboBoxPlayers.Font = new System.Drawing.Font("FiraCode Nerd Font", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlayers.ForeColor = System.Drawing.Color.Cyan;
            this.comboBoxPlayers.FormattingEnabled = true;
            this.comboBoxPlayers.Location = new System.Drawing.Point(444, 482);
            this.comboBoxPlayers.Name = "comboBoxPlayers";
            this.comboBoxPlayers.Size = new System.Drawing.Size(344, 24);
            this.comboBoxPlayers.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Game Over", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(36, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Player";
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelAdmin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAdmin.BackgroundImage")));
            this.panelAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelAdmin.Controls.Add(this.textBoxImage);
            this.panelAdmin.Controls.Add(this.textBoxRolID);
            this.panelAdmin.Controls.Add(this.textBoxPuntaje);
            this.panelAdmin.Controls.Add(this.textBoxNivel);
            this.panelAdmin.Controls.Add(this.label9);
            this.panelAdmin.Controls.Add(this.label8);
            this.panelAdmin.Controls.Add(this.label7);
            this.panelAdmin.Controls.Add(this.label6);
            this.panelAdmin.Controls.Add(this.btnPanelAdd);
            this.panelAdmin.Controls.Add(this.btnPanelActualizar);
            this.panelAdmin.Controls.Add(this.btnPanelErase);
            this.panelAdmin.Controls.Add(this.textBoxPassword);
            this.panelAdmin.Controls.Add(this.textBoxEmail);
            this.panelAdmin.Controls.Add(this.textBoxNombre);
            this.panelAdmin.Controls.Add(this.label5);
            this.panelAdmin.Controls.Add(this.label4);
            this.panelAdmin.Controls.Add(this.label3);
            this.panelAdmin.Location = new System.Drawing.Point(12, 512);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(776, 207);
            this.panelAdmin.TabIndex = 8;
            this.panelAdmin.Visible = false;
            // 
            // textBoxImage
            // 
            this.textBoxImage.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxImage.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImage.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxImage.Location = new System.Drawing.Point(531, 108);
            this.textBoxImage.Name = "textBoxImage";
            this.textBoxImage.Size = new System.Drawing.Size(130, 26);
            this.textBoxImage.TabIndex = 17;
            // 
            // textBoxRolID
            // 
            this.textBoxRolID.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxRolID.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRolID.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxRolID.Location = new System.Drawing.Point(531, 74);
            this.textBoxRolID.Name = "textBoxRolID";
            this.textBoxRolID.Size = new System.Drawing.Size(130, 26);
            this.textBoxRolID.TabIndex = 16;
            // 
            // textBoxPuntaje
            // 
            this.textBoxPuntaje.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPuntaje.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPuntaje.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxPuntaje.Location = new System.Drawing.Point(531, 40);
            this.textBoxPuntaje.Name = "textBoxPuntaje";
            this.textBoxPuntaje.Size = new System.Drawing.Size(130, 26);
            this.textBoxPuntaje.TabIndex = 15;
            // 
            // textBoxNivel
            // 
            this.textBoxNivel.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxNivel.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNivel.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxNivel.Location = new System.Drawing.Point(137, 148);
            this.textBoxNivel.Name = "textBoxNivel";
            this.textBoxNivel.Size = new System.Drawing.Size(207, 26);
            this.textBoxNivel.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.WindowText;
            this.label9.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.GreenYellow;
            this.label9.Location = new System.Drawing.Point(405, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Imagen (id)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.WindowText;
            this.label8.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.GreenYellow;
            this.label8.Location = new System.Drawing.Point(405, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Puntaje";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.WindowText;
            this.label7.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.GreenYellow;
            this.label7.Location = new System.Drawing.Point(405, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Rol (id)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.WindowText;
            this.label6.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.GreenYellow;
            this.label6.Location = new System.Drawing.Point(24, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Nivel";
            // 
            // btnPanelAdd
            // 
            this.btnPanelAdd.BackColor = System.Drawing.Color.Violet;
            this.btnPanelAdd.Font = new System.Drawing.Font("Game Over", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanelAdd.ForeColor = System.Drawing.Color.Yellow;
            this.btnPanelAdd.Location = new System.Drawing.Point(521, 159);
            this.btnPanelAdd.Name = "btnPanelAdd";
            this.btnPanelAdd.Size = new System.Drawing.Size(106, 46);
            this.btnPanelAdd.TabIndex = 9;
            this.btnPanelAdd.Text = "Agregar";
            this.btnPanelAdd.UseVisualStyleBackColor = false;
            this.btnPanelAdd.Click += new System.EventHandler(this.btnPanelAdd_Click);
            // 
            // btnPanelActualizar
            // 
            this.btnPanelActualizar.BackColor = System.Drawing.Color.Violet;
            this.btnPanelActualizar.Font = new System.Drawing.Font("Game Over", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanelActualizar.ForeColor = System.Drawing.Color.Yellow;
            this.btnPanelActualizar.Location = new System.Drawing.Point(633, 159);
            this.btnPanelActualizar.Name = "btnPanelActualizar";
            this.btnPanelActualizar.Size = new System.Drawing.Size(106, 46);
            this.btnPanelActualizar.TabIndex = 7;
            this.btnPanelActualizar.Text = "Actualizar";
            this.btnPanelActualizar.UseVisualStyleBackColor = false;
            this.btnPanelActualizar.Click += new System.EventHandler(this.btnPanelActualizar_Click);
            // 
            // btnPanelErase
            // 
            this.btnPanelErase.BackColor = System.Drawing.Color.Violet;
            this.btnPanelErase.Font = new System.Drawing.Font("Game Over", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPanelErase.ForeColor = System.Drawing.Color.Yellow;
            this.btnPanelErase.Location = new System.Drawing.Point(409, 159);
            this.btnPanelErase.Name = "btnPanelErase";
            this.btnPanelErase.Size = new System.Drawing.Size(106, 46);
            this.btnPanelErase.TabIndex = 6;
            this.btnPanelErase.Text = "Borrar";
            this.btnPanelErase.UseVisualStyleBackColor = false;
            this.btnPanelErase.Click += new System.EventHandler(this.btnPanelErase_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPassword.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxPassword.Location = new System.Drawing.Point(137, 108);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(207, 26);
            this.textBoxPassword.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxEmail.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxEmail.Location = new System.Drawing.Point(137, 76);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(207, 26);
            this.textBoxEmail.TabIndex = 4;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BackColor = System.Drawing.SystemColors.WindowText;
            this.textBoxNombre.Font = new System.Drawing.Font("FiraCode Nerd Font", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxNombre.Location = new System.Drawing.Point(137, 41);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(207, 26);
            this.textBoxNombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.WindowText;
            this.label5.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.GreenYellow;
            this.label5.Location = new System.Drawing.Point(24, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.WindowText;
            this.label4.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.GreenYellow;
            this.label4.Location = new System.Drawing.Point(24, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.WindowText;
            this.label3.Font = new System.Drawing.Font("Game Over", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(24, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DeepPink;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 771);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(31, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 113);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBack.Font = new System.Drawing.Font("Game Over", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(674, 725);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(114, 32);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 771);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.comboBoxPlayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnErase;
        private System.Windows.Forms.ComboBox comboBoxPlayers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPanelAdd;
        private System.Windows.Forms.Button btnPanelActualizar;
        private System.Windows.Forms.Button btnPanelErase;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxImage;
        private System.Windows.Forms.TextBox textBoxRolID;
        private System.Windows.Forms.TextBox textBoxPuntaje;
        private System.Windows.Forms.TextBox textBoxNivel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnBack;
    }
}