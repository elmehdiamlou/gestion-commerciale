
namespace GestionCommercial
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panelbare = new System.Windows.Forms.Panel();
            this.lblnom = new System.Windows.Forms.Label();
            this.lblreduire = new System.Windows.Forms.Label();
            this.lblexit = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.btncommandes = new System.Windows.Forms.Button();
            this.btnarticles = new System.Windows.Forms.Button();
            this.btnclients = new System.Windows.Forms.Button();
            this.panelcontenu = new System.Windows.Forms.Panel();
            this.btnconsultations = new System.Windows.Forms.Button();
            this.panelbare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelbare
            // 
            this.panelbare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(138)))), ((int)(((byte)(211)))));
            this.panelbare.Controls.Add(this.lblnom);
            this.panelbare.Controls.Add(this.lblreduire);
            this.panelbare.Controls.Add(this.lblexit);
            this.panelbare.Controls.Add(this.pictureBox1);
            this.panelbare.Controls.Add(this.label1);
            this.panelbare.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbare.Location = new System.Drawing.Point(0, 0);
            this.panelbare.Name = "panelbare";
            this.panelbare.Size = new System.Drawing.Size(1260, 46);
            this.panelbare.TabIndex = 0;
            this.panelbare.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelbare_MouseDown);
            this.panelbare.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelbare_MouseMove);
            this.panelbare.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelbare_MouseUp);
            // 
            // lblnom
            // 
            this.lblnom.AutoSize = true;
            this.lblnom.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnom.ForeColor = System.Drawing.Color.White;
            this.lblnom.Location = new System.Drawing.Point(280, 8);
            this.lblnom.Name = "lblnom";
            this.lblnom.Size = new System.Drawing.Size(74, 29);
            this.lblnom.TabIndex = 15;
            this.lblnom.Text = "- Nom";
            // 
            // lblreduire
            // 
            this.lblreduire.AutoSize = true;
            this.lblreduire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblreduire.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblreduire.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.lblreduire.Location = new System.Drawing.Point(1168, -10);
            this.lblreduire.Name = "lblreduire";
            this.lblreduire.Size = new System.Drawing.Size(40, 59);
            this.lblreduire.TabIndex = 14;
            this.lblreduire.Text = "-";
            this.lblreduire.Click += new System.EventHandler(this.lblreduire_Click);
            this.lblreduire.MouseEnter += new System.EventHandler(this.lblreduire_MouseEnter);
            this.lblreduire.MouseLeave += new System.EventHandler(this.lblreduire_MouseLeave);
            // 
            // lblexit
            // 
            this.lblexit.AutoSize = true;
            this.lblexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblexit.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblexit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lblexit.Location = new System.Drawing.Point(1214, -10);
            this.lblexit.Name = "lblexit";
            this.lblexit.Size = new System.Drawing.Size(47, 59);
            this.lblexit.TabIndex = 13;
            this.lblexit.Text = "x";
            this.lblexit.Click += new System.EventHandler(this.lblexit_Click);
            this.lblexit.MouseEnter += new System.EventHandler(this.lblexit_MouseEnter);
            this.lblexit.MouseLeave += new System.EventHandler(this.lblexit_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestion Commerciale";
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(183)))));
            this.panelmenu.Controls.Add(this.btnconsultations);
            this.panelmenu.Controls.Add(this.btncommandes);
            this.panelmenu.Controls.Add(this.btnarticles);
            this.panelmenu.Controls.Add(this.btnclients);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenu.Location = new System.Drawing.Point(0, 46);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(228, 615);
            this.panelmenu.TabIndex = 1;
            // 
            // btncommandes
            // 
            this.btncommandes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(183)))));
            this.btncommandes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncommandes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncommandes.FlatAppearance.BorderSize = 0;
            this.btncommandes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncommandes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncommandes.ForeColor = System.Drawing.Color.White;
            this.btncommandes.Image = ((System.Drawing.Image)(resources.GetObject("btncommandes.Image")));
            this.btncommandes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncommandes.Location = new System.Drawing.Point(0, 80);
            this.btncommandes.Name = "btncommandes";
            this.btncommandes.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btncommandes.Size = new System.Drawing.Size(228, 40);
            this.btncommandes.TabIndex = 8;
            this.btncommandes.Text = "    Commandes";
            this.btncommandes.UseVisualStyleBackColor = false;
            this.btncommandes.Click += new System.EventHandler(this.btncommandes_Click);
            // 
            // btnarticles
            // 
            this.btnarticles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(183)))));
            this.btnarticles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnarticles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnarticles.FlatAppearance.BorderSize = 0;
            this.btnarticles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnarticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnarticles.ForeColor = System.Drawing.Color.White;
            this.btnarticles.Image = ((System.Drawing.Image)(resources.GetObject("btnarticles.Image")));
            this.btnarticles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnarticles.Location = new System.Drawing.Point(0, 40);
            this.btnarticles.Name = "btnarticles";
            this.btnarticles.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnarticles.Size = new System.Drawing.Size(228, 40);
            this.btnarticles.TabIndex = 7;
            this.btnarticles.Text = "Articles";
            this.btnarticles.UseVisualStyleBackColor = false;
            this.btnarticles.Click += new System.EventHandler(this.btnarticles_Click);
            // 
            // btnclients
            // 
            this.btnclients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(183)))));
            this.btnclients.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclients.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnclients.FlatAppearance.BorderSize = 0;
            this.btnclients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclients.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclients.ForeColor = System.Drawing.Color.White;
            this.btnclients.Image = ((System.Drawing.Image)(resources.GetObject("btnclients.Image")));
            this.btnclients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclients.Location = new System.Drawing.Point(0, 0);
            this.btnclients.Name = "btnclients";
            this.btnclients.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnclients.Size = new System.Drawing.Size(228, 40);
            this.btnclients.TabIndex = 6;
            this.btnclients.Text = "Clients";
            this.btnclients.UseVisualStyleBackColor = false;
            this.btnclients.Click += new System.EventHandler(this.btnclients_Click);
            // 
            // panelcontenu
            // 
            this.panelcontenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontenu.Location = new System.Drawing.Point(228, 46);
            this.panelcontenu.Name = "panelcontenu";
            this.panelcontenu.Size = new System.Drawing.Size(1032, 615);
            this.panelcontenu.TabIndex = 2;
            // 
            // btnconsultations
            // 
            this.btnconsultations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(183)))));
            this.btnconsultations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnconsultations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnconsultations.FlatAppearance.BorderSize = 0;
            this.btnconsultations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconsultations.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconsultations.ForeColor = System.Drawing.Color.White;
            this.btnconsultations.Image = ((System.Drawing.Image)(resources.GetObject("btnconsultations.Image")));
            this.btnconsultations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnconsultations.Location = new System.Drawing.Point(0, 120);
            this.btnconsultations.Name = "btnconsultations";
            this.btnconsultations.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnconsultations.Size = new System.Drawing.Size(228, 40);
            this.btnconsultations.TabIndex = 9;
            this.btnconsultations.Text = "    Consultations";
            this.btnconsultations.UseVisualStyleBackColor = false;
            this.btnconsultations.Click += new System.EventHandler(this.btnconsultations_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 661);
            this.Controls.Add(this.panelcontenu);
            this.Controls.Add(this.panelmenu);
            this.Controls.Add(this.panelbare);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panelbare.ResumeLayout(false);
            this.panelbare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblreduire;
        private System.Windows.Forms.Label lblexit;
        private System.Windows.Forms.Label lblnom;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Button btnclients;
        private System.Windows.Forms.Button btnarticles;
        private System.Windows.Forms.Button btncommandes;
        private System.Windows.Forms.Panel panelcontenu;
        private System.Windows.Forms.Button btnconsultations;
    }
}