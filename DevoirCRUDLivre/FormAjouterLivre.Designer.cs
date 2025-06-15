namespace DevoirCRUDLivre
{
    partial class FormAjouterLivre
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
            label1 = new Label();
            label2 = new Label();
            txtTitre = new TextBox();
            label3 = new Label();
            txtAuteur = new TextBox();
            label4 = new Label();
            txtISBN = new TextBox();
            label5 = new Label();
            dtpDatePublication = new DateTimePicker();
            label6 = new Label();
            txtGenre = new TextBox();
            label7 = new Label();
            txtEditeur = new TextBox();
            label8 = new Label();
            txtResume = new TextBox();
            btnAjouterLivre = new Button();
            btnModifierLivre = new Button();
            btnSupprimerLivre = new Button();
            btnResetLivre = new Button();
            dgvLivres = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLivres).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Montserrat ExtraBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(329, 30);
            label1.Name = "label1";
            label1.Size = new Size(188, 29);
            label1.TabIndex = 0;
            label1.Text = "Ajouter un livre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 107);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Titre :";
            // 
            // txtTitre
            // 
            txtTitre.Location = new Point(9, 125);
            txtTitre.Multiline = true;
            txtTitre.Name = "txtTitre";
            txtTitre.Size = new Size(234, 32);
            txtTitre.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 176);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 3;
            label3.Text = "Auteur :";
            // 
            // txtAuteur
            // 
            txtAuteur.Location = new Point(9, 194);
            txtAuteur.Multiline = true;
            txtAuteur.Name = "txtAuteur";
            txtAuteur.Size = new Size(234, 32);
            txtAuteur.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 250);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 5;
            label4.Text = "ISBN :";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(9, 268);
            txtISBN.Multiline = true;
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(234, 32);
            txtISBN.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(312, 107);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 7;
            label5.Text = "Date de publication :";
            // 
            // dtpDatePublication
            // 
            dtpDatePublication.Location = new Point(312, 134);
            dtpDatePublication.Name = "dtpDatePublication";
            dtpDatePublication.Size = new Size(234, 23);
            dtpDatePublication.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(312, 176);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 9;
            label6.Text = "Genre :";
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(312, 194);
            txtGenre.Multiline = true;
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(234, 32);
            txtGenre.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(312, 250);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 11;
            label7.Text = "Éditeur :";
            // 
            // txtEditeur
            // 
            txtEditeur.Location = new Point(312, 268);
            txtEditeur.Multiline = true;
            txtEditeur.Name = "txtEditeur";
            txtEditeur.Size = new Size(234, 32);
            txtEditeur.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(619, 107);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 13;
            label8.Text = "Résumé :";
            // 
            // txtResume
            // 
            txtResume.Location = new Point(619, 125);
            txtResume.Multiline = true;
            txtResume.Name = "txtResume";
            txtResume.Size = new Size(234, 32);
            txtResume.TabIndex = 14;
            // 
            // btnAjouterLivre
            // 
            btnAjouterLivre.BackColor = Color.FromArgb(0, 192, 0);
            btnAjouterLivre.ForeColor = SystemColors.Control;
            btnAjouterLivre.Location = new Point(96, 342);
            btnAjouterLivre.Name = "btnAjouterLivre";
            btnAjouterLivre.Size = new Size(137, 33);
            btnAjouterLivre.TabIndex = 15;
            btnAjouterLivre.Text = "Ajouter Livre";
            btnAjouterLivre.UseVisualStyleBackColor = false;
            btnAjouterLivre.Click += btnAjouterLivre_Click;
            // 
            // btnModifierLivre
            // 
            btnModifierLivre.BackColor = Color.Blue;
            btnModifierLivre.ForeColor = SystemColors.Control;
            btnModifierLivre.Location = new Point(272, 342);
            btnModifierLivre.Name = "btnModifierLivre";
            btnModifierLivre.Size = new Size(137, 33);
            btnModifierLivre.TabIndex = 16;
            btnModifierLivre.Text = "Modifier";
            btnModifierLivre.UseVisualStyleBackColor = false;
            btnModifierLivre.Click += btnModifierLivre_Click;
            // 
            // btnSupprimerLivre
            // 
            btnSupprimerLivre.BackColor = Color.Red;
            btnSupprimerLivre.ForeColor = SystemColors.Control;
            btnSupprimerLivre.Location = new Point(448, 342);
            btnSupprimerLivre.Name = "btnSupprimerLivre";
            btnSupprimerLivre.Size = new Size(137, 33);
            btnSupprimerLivre.TabIndex = 17;
            btnSupprimerLivre.Text = "Supprimer";
            btnSupprimerLivre.UseVisualStyleBackColor = false;
            btnSupprimerLivre.Click += btnSupprimerLivre_Click;
            // 
            // btnResetLivre
            // 
            btnResetLivre.BackColor = SystemColors.ActiveBorder;
            btnResetLivre.Location = new Point(619, 342);
            btnResetLivre.Name = "btnResetLivre";
            btnResetLivre.Size = new Size(137, 33);
            btnResetLivre.TabIndex = 18;
            btnResetLivre.Text = "Réinitialiser";
            btnResetLivre.UseVisualStyleBackColor = false;
            btnResetLivre.Click += btnResetLivre_Click;
            // 
            // dgvLivres
            // 
            dgvLivres.BackgroundColor = SystemColors.Control;
            dgvLivres.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLivres.Location = new Point(10, 423);
            dgvLivres.Name = "dgvLivres";
            dgvLivres.Size = new Size(842, 226);
            dgvLivres.TabIndex = 19;
            dgvLivres.CellClick += dgvLivres_CellClick;
            // 
            // FormAjouterLivre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 716);
            Controls.Add(dgvLivres);
            Controls.Add(btnResetLivre);
            Controls.Add(btnSupprimerLivre);
            Controls.Add(btnModifierLivre);
            Controls.Add(btnAjouterLivre);
            Controls.Add(txtResume);
            Controls.Add(label8);
            Controls.Add(txtEditeur);
            Controls.Add(label7);
            Controls.Add(txtGenre);
            Controls.Add(label6);
            Controls.Add(dtpDatePublication);
            Controls.Add(label5);
            Controls.Add(txtISBN);
            Controls.Add(label4);
            Controls.Add(txtAuteur);
            Controls.Add(label3);
            Controls.Add(txtTitre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAjouterLivre";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLivres).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTitre;
        private Label label3;
        private TextBox txtAuteur;
        private Label label4;
        private TextBox txtISBN;
        private Label label5;
        private DateTimePicker dtpDatePublication;
        private Label label6;
        private TextBox txtGenre;
        private Label label7;
        private TextBox txtEditeur;
        private Label label8;
        private TextBox txtResume;
        private Button btnAjouterLivre;
        private Button btnModifierLivre;
        private Button btnSupprimerLivre;
        private Button btnResetLivre;
        private DataGridView dgvLivres;
    }
}