using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevoirCRUDLivre
{
    public partial class FormAjouterLivre : Form
    {
        private int _selectedLivreId = -1;
        public FormAjouterLivre()
        {
            InitializeComponent();
            DatabaseHelper.CreateTable();
            LoadLivres();
        }

        private void LoadLivres()
        {
            try
            {
                List<Livre> livres = DatabaseHelper.GetLivres();
                dgvLivres.DataSource = livres;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des livres : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouterLivre_Click(object sender, EventArgs e)
        {
            Livre nouveauLivre = new Livre();

            if (string.IsNullOrWhiteSpace(txtTitre.Text))
            {
                MessageBox.Show("Le titre du livre ne peut pas \u00EAtre vide.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitre.Focus();
                return;
            }

            nouveauLivre.Titre = txtTitre.Text.Trim();
            nouveauLivre.Auteur = string.IsNullOrWhiteSpace(txtAuteur.Text) ? null : txtAuteur.Text.Trim();
            nouveauLivre.ISBN = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text.Trim();
            nouveauLivre.DatePublication = dtpDatePublication.Value;
            nouveauLivre.Genre = string.IsNullOrWhiteSpace(txtGenre.Text) ? null : txtGenre.Text.Trim();
            nouveauLivre.Editeur = string.IsNullOrWhiteSpace(txtEditeur.Text) ? null : txtEditeur.Text.Trim();
            nouveauLivre.Resume = string.IsNullOrWhiteSpace(txtResume.Text) ? null : txtResume.Text.Trim();

            try
            {
                DatabaseHelper.InsertLivre(nouveauLivre);
                MessageBox.Show("Livre ajout\u00E9 avec succ\u00E8s !", "Succ\u00E8s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFormFields();
                LoadLivres();
                _selectedLivreId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du livre : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormFields()
        {
            txtTitre.Text = string.Empty;
            txtAuteur.Text = string.Empty;
            txtISBN.Text = string.Empty;
            dtpDatePublication.Value = DateTime.Now;
            txtGenre.Text = string.Empty;
            txtEditeur.Text = string.Empty;
            txtResume.Text = string.Empty;
        }

        private void dgvLivres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLivres.Rows[e.RowIndex];
                _selectedLivreId = Convert.ToInt32(row.Cells["Id"].Value);

                Livre? selectedLivre = DatabaseHelper.GetLivreById(_selectedLivreId);

                if (selectedLivre != null)
                {
                    txtTitre.Text = selectedLivre.Titre;
                    txtAuteur.Text = selectedLivre.Auteur;
                    txtISBN.Text = selectedLivre.ISBN;

                    if (selectedLivre.DatePublication.HasValue)
                    {
                        dtpDatePublication.Value = selectedLivre.DatePublication.Value;
                    }
                    else
                    {
                        dtpDatePublication.Value = DateTime.Today;
                    }

                    txtGenre.Text = selectedLivre.Genre;
                    txtEditeur.Text = selectedLivre.Editeur;
                    txtResume.Text = selectedLivre.Resume;
                }
            }
        }

        private void btnModifierLivre_Click(object sender, EventArgs e)
        {
            if (_selectedLivreId == -1)
            {
                MessageBox.Show("Veuillez s\u00E9lectionner un livre \u00E0 modifier.", "Aucune s\u00E9lection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Livre livreModifie = new Livre();
            livreModifie.Id = _selectedLivreId;

            if (string.IsNullOrWhiteSpace(txtTitre.Text))
            {
                MessageBox.Show("Le titre du livre ne peut pas \u00EAtre vide.", "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitre.Focus();
                return;
            }

            livreModifie.Titre = txtTitre.Text.Trim();
            livreModifie.Auteur = string.IsNullOrWhiteSpace(txtAuteur.Text) ? null : txtAuteur.Text.Trim();
            livreModifie.ISBN = string.IsNullOrWhiteSpace(txtISBN.Text) ? null : txtISBN.Text.Trim();
            livreModifie.DatePublication = dtpDatePublication.Value;
            livreModifie.Genre = string.IsNullOrWhiteSpace(txtGenre.Text) ? null : txtGenre.Text.Trim();
            livreModifie.Editeur = string.IsNullOrWhiteSpace(txtEditeur.Text) ? null : txtEditeur.Text.Trim();
            livreModifie.Resume = string.IsNullOrWhiteSpace(txtResume.Text) ? null : txtResume.Text.Trim();

            try
            {
                DatabaseHelper.UpdateLivre(livreModifie);
                MessageBox.Show("Livre modifi\u00E9 avec succ\u00E8s !", "Succ\u00E8s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFormFields();
                _selectedLivreId = -1;
                LoadLivres();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification du livre : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimerLivre_Click(object sender, EventArgs e)
        {
            if (_selectedLivreId == -1)
            {
                MessageBox.Show("Veuillez s\u00E9lectionner un livre \u00E0 supprimer.", "Aucune s\u00E9lection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmResult = MessageBox.Show(
                "Voulez-vous vraiment supprimer ce livre ?",
                "Confirmer suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteLivre(_selectedLivreId);
                    MessageBox.Show("Livre supprim\u00E9 avec succ\u00E8s !", "Succ\u00E8s", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFormFields();
                    _selectedLivreId = -1;
                    LoadLivres();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la suppression du livre : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetLivre_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }
    }
}
