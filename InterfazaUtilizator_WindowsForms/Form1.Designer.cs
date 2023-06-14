
namespace InterfazaUtilizator_WindowsForms
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlMeniu = new System.Windows.Forms.Panel();
            this.pnlSus = new System.Windows.Forms.Panel();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.pnlJos = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.pnlContinut = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pctIesire = new System.Windows.Forms.PictureBox();
            this.btnInchirieri = new System.Windows.Forms.Button();
            this.btnAngajati = new System.Windows.Forms.Button();
            this.btnAcasa = new System.Windows.Forms.Button();
            this.btnMasini = new System.Windows.Forms.Button();
            this.btnClienti = new System.Windows.Forms.Button();
            this.pctSigla = new System.Windows.Forms.PictureBox();
            this.pnlMeniu.SuspendLayout();
            this.pnlSus.SuspendLayout();
            this.pnlJos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIesire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSigla)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMeniu
            // 
            this.pnlMeniu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMeniu.Controls.Add(this.btnInchirieri);
            this.pnlMeniu.Controls.Add(this.btnAngajati);
            this.pnlMeniu.Controls.Add(this.btnAcasa);
            this.pnlMeniu.Controls.Add(this.btnMasini);
            this.pnlMeniu.Controls.Add(this.btnClienti);
            this.pnlMeniu.Controls.Add(this.pctSigla);
            this.pnlMeniu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMeniu.Location = new System.Drawing.Point(0, 0);
            this.pnlMeniu.Name = "pnlMeniu";
            this.pnlMeniu.Size = new System.Drawing.Size(68, 638);
            this.pnlMeniu.TabIndex = 4;
            // 
            // pnlSus
            // 
            this.pnlSus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.pnlSus.Controls.Add(this.lblTitlu);
            this.pnlSus.Controls.Add(this.pctIesire);
            this.pnlSus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSus.Location = new System.Drawing.Point(68, 0);
            this.pnlSus.Name = "pnlSus";
            this.pnlSus.Size = new System.Drawing.Size(1136, 61);
            this.pnlSus.TabIndex = 5;
            this.pnlSus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.pnlSus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.pnlSus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // lblTitlu
            // 
            this.lblTitlu.AutoSize = true;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(66, 14);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(424, 73);
            this.lblTitlu.TabIndex = 5;
            this.lblTitlu.Text = "Inchirieri Auto";
            // 
            // pnlJos
            // 
            this.pnlJos.Controls.Add(this.lblTime);
            this.pnlJos.Controls.Add(this.lblDate);
            this.pnlJos.Controls.Add(this.lblAutor);
            this.pnlJos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlJos.Location = new System.Drawing.Point(68, 612);
            this.pnlJos.Name = "pnlJos";
            this.pnlJos.Size = new System.Drawing.Size(1136, 26);
            this.pnlJos.TabIndex = 6;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(6, 3);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(81, 30);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "label1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(963, 3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(81, 30);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "label1";
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.ForeColor = System.Drawing.Color.White;
            this.lblAutor.Location = new System.Drawing.Point(496, 0);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(261, 30);
            this.lblAutor.TabIndex = 0;
            this.lblAutor.Text = "© 2023 Aydogan Mert";
            // 
            // pnlContinut
            // 
            this.pnlContinut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContinut.Location = new System.Drawing.Point(68, 61);
            this.pnlContinut.Name = "pnlContinut";
            this.pnlContinut.Size = new System.Drawing.Size(1136, 551);
            this.pnlContinut.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pctIesire
            // 
            this.pctIesire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctIesire.Image = ((System.Drawing.Image)(resources.GetObject("pctIesire.Image")));
            this.pctIesire.Location = new System.Drawing.Point(1102, 18);
            this.pctIesire.Name = "pctIesire";
            this.pctIesire.Size = new System.Drawing.Size(22, 22);
            this.pctIesire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctIesire.TabIndex = 4;
            this.pctIesire.TabStop = false;
            this.pctIesire.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnInchirieri
            // 
            this.btnInchirieri.BackColor = System.Drawing.Color.Transparent;
            this.btnInchirieri.BackgroundImage = global::InterfazaUtilizator_WindowsForms.Properties.Resources.receipt;
            this.btnInchirieri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInchirieri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInchirieri.FlatAppearance.BorderSize = 0;
            this.btnInchirieri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnInchirieri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInchirieri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchirieri.Location = new System.Drawing.Point(0, 510);
            this.btnInchirieri.Name = "btnInchirieri";
            this.btnInchirieri.Size = new System.Drawing.Size(65, 65);
            this.btnInchirieri.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnInchirieri, "Inchirieri");
            this.btnInchirieri.UseVisualStyleBackColor = false;
            this.btnInchirieri.Click += new System.EventHandler(this.btnInchirieri_Click);
            // 
            // btnAngajati
            // 
            this.btnAngajati.BackColor = System.Drawing.Color.Transparent;
            this.btnAngajati.BackgroundImage = global::InterfazaUtilizator_WindowsForms.Properties.Resources.worker;
            this.btnAngajati.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAngajati.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAngajati.FlatAppearance.BorderSize = 0;
            this.btnAngajati.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnAngajati.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAngajati.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAngajati.Location = new System.Drawing.Point(0, 317);
            this.btnAngajati.Name = "btnAngajati";
            this.btnAngajati.Size = new System.Drawing.Size(65, 65);
            this.btnAngajati.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnAngajati, "Angajati");
            this.btnAngajati.UseVisualStyleBackColor = false;
            this.btnAngajati.Click += new System.EventHandler(this.btnAngajati_Click);
            // 
            // btnAcasa
            // 
            this.btnAcasa.BackColor = System.Drawing.Color.Transparent;
            this.btnAcasa.BackgroundImage = global::InterfazaUtilizator_WindowsForms.Properties.Resources.main;
            this.btnAcasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAcasa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcasa.FlatAppearance.BorderSize = 0;
            this.btnAcasa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnAcasa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAcasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcasa.ForeColor = System.Drawing.Color.Transparent;
            this.btnAcasa.Location = new System.Drawing.Point(0, 90);
            this.btnAcasa.Name = "btnAcasa";
            this.btnAcasa.Size = new System.Drawing.Size(65, 65);
            this.btnAcasa.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btnAcasa, "Acasa");
            this.btnAcasa.UseVisualStyleBackColor = false;
            this.btnAcasa.Click += new System.EventHandler(this.btnAcasa_Click);
            // 
            // btnMasini
            // 
            this.btnMasini.BackColor = System.Drawing.Color.Transparent;
            this.btnMasini.BackgroundImage = global::InterfazaUtilizator_WindowsForms.Properties.Resources.car;
            this.btnMasini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMasini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasini.FlatAppearance.BorderSize = 0;
            this.btnMasini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnMasini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnMasini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasini.Location = new System.Drawing.Point(0, 418);
            this.btnMasini.Name = "btnMasini";
            this.btnMasini.Size = new System.Drawing.Size(65, 65);
            this.btnMasini.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnMasini, "Masini");
            this.btnMasini.UseVisualStyleBackColor = false;
            this.btnMasini.Click += new System.EventHandler(this.btnMasini_Click);
            // 
            // btnClienti
            // 
            this.btnClienti.BackColor = System.Drawing.Color.Transparent;
            this.btnClienti.BackgroundImage = global::InterfazaUtilizator_WindowsForms.Properties.Resources.group;
            this.btnClienti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClienti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClienti.FlatAppearance.BorderSize = 0;
            this.btnClienti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnClienti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClienti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClienti.ForeColor = System.Drawing.Color.Transparent;
            this.btnClienti.Location = new System.Drawing.Point(0, 223);
            this.btnClienti.Name = "btnClienti";
            this.btnClienti.Size = new System.Drawing.Size(65, 65);
            this.btnClienti.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnClienti, "Clienti");
            this.btnClienti.UseVisualStyleBackColor = false;
            this.btnClienti.Click += new System.EventHandler(this.btnClienti_Click);
            // 
            // pctSigla
            // 
            this.pctSigla.Image = global::InterfazaUtilizator_WindowsForms.Properties.Resources.car_rental;
            this.pctSigla.Location = new System.Drawing.Point(6, 3);
            this.pctSigla.Name = "pctSigla";
            this.pctSigla.Size = new System.Drawing.Size(59, 59);
            this.pctSigla.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctSigla.TabIndex = 6;
            this.pctSigla.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1204, 638);
            this.Controls.Add(this.pnlContinut);
            this.Controls.Add(this.pnlJos);
            this.Controls.Add(this.pnlSus);
            this.Controls.Add(this.pnlMeniu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMeniu.ResumeLayout(false);
            this.pnlSus.ResumeLayout(false);
            this.pnlSus.PerformLayout();
            this.pnlJos.ResumeLayout(false);
            this.pnlJos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctIesire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSigla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMeniu;
        private System.Windows.Forms.Panel pnlSus;
        private System.Windows.Forms.PictureBox pctSigla;
        private System.Windows.Forms.PictureBox pctIesire;
        private System.Windows.Forms.Panel pnlJos;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Button btnAcasa;
        private System.Windows.Forms.Button btnInchirieri;
        private System.Windows.Forms.Button btnAngajati;
        private System.Windows.Forms.Button btnMasini;
        private System.Windows.Forms.Button btnClienti;
        private System.Windows.Forms.Label lblTitlu;
        private System.Windows.Forms.Panel pnlContinut;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer timer1;
    }
}

