using CompteBancaireLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICompteBancaire
{
    public partial class GestionCompte : Form
    {
        private CompteAvecSauvegarde _compte;
        public CompteAvecSauvegarde Compte
        {
            set
            {
                _compte = value;
                Text = _compte.Proprietaire + " : " + _compte.Numero;
                RemplirLaListe(true);
            }
        }

        private void RemplirLaListe(bool debut)
        {
            listeTransactions.Items.Clear();
            foreach (Transaction t in _compte.Transactions)
            {
                ListViewItem unElement = new ListViewItem();
                unElement.Text = t.Date.ToString("dd/MM/yyyy");
                unElement.SubItems.Add(t.Montant.ToString("N2"));
                unElement.SubItems.Add(t.Notes);
                unElement.Tag = t;
                //
                listeTransactions.Items.Add(unElement);
            }
            if (listeTransactions.Items.Count > 0)
            {
                if(debut)
                {
                    listeTransactions.Items[0].Selected = true;
                }
                else
                {
                    listeTransactions.Items[listeTransactions.Items.Count -1].Selected = true;
                }
            }
        }

        public String Fichier { get; set; }



        public GestionCompte()
        {
            InitializeComponent();
            listeTransactions.ListViewItemSorter = new TrieurDeTransaction();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listeTransactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listeTransactions.SelectedItems.Count > 0)
            {
                ListViewItem unElement = listeTransactions.SelectedItems[0];
                Transaction t = (Transaction)unElement.Tag;
                textMontant.Text = t.Montant.ToString("N2");
                textBoxNotes.Text = t.Notes;
                pickerDate.Value = t.Date;
            }
            else
            {
                label3.Text = "";
                textBoxNotes.Text = "";
                pickerDate.Value = DateTime.Now;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listeTransactions.SelectedItems.Count > 0)
            {
                ListViewItem unElement = listeTransactions.SelectedItems[0];
                Transaction t = (Transaction)unElement.Tag;
                if (unElement.Index > 0)
                {

                    DialogResult dr = MessageBox.Show("Êtes-vous sur ?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        listeTransactions.Items.Remove(unElement);
                        if (listeTransactions.SelectedItems.Count > 0)
                        {
                            listeTransactions.Items[0].Selected = true;
                        }

                        textMontant.Text = t.Montant.ToString("N2");
                        textBoxNotes.Text = t.Notes;
                        pickerDate.Value = t.Date;
                    }
                }
            }
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            listeTransactions.Enabled = false;
            buttonSupprimer.Enabled = false;
            //
            pickerDate.Value = DateTime.Now;
            textMontant.Text = "";
            textBoxNotes.Text = "";
            //
            pickerDate.Focus();
            //
            panelZoom.Enabled = true;
            buttonValider.Visible = true;
            buttonAjouter.Visible = false;
            buttonAjouter.Enabled = false;
            buttonValider.Enabled = true;
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            //
            bool correct = true;
            labelErreur.Text = "";
            decimal montant;
            if(!decimal.TryParse(textMontant.Text, out montant))
            {
                //ERREUR
                labelErreur.Text = "Le montant n'est pas correct.";
                correct = false;
            }
            Transaction t = (Transaction)listeTransactions.Items[0].Tag;
            if (pickerDate.Value < t.Date)
            {
                // Erreur
                labelErreur.Text += " - La date est antérieure à celle du solde initial.";
                correct = false;
            }
            if(correct)
            {
                if (montant >= 0)
                {
                    _compte.FaireDepot(montant, pickerDate.Value, textBoxNotes.Text);
                }
                else
                {
                    _compte.FaireRetrait((-1)*montant, pickerDate.Value, textBoxNotes.Text);
                }
                RemplirLaListe(false);

            }
            else
            {
                return;
            }
            //
            labelErreur.Text = "";
            panelZoom.Enabled = false;
            buttonValider.Visible = false;
            buttonAjouter.Visible = true;
            buttonValider.Enabled = false;
            buttonAjouter.Enabled = true;
            
            listeTransactions.Enabled = true;
            buttonSupprimer.Enabled = true;
        }
    }

    internal class TrieurDeTransaction : IComparer
    {
        public int Compare(object? x, object? y)
        {
            ListViewItem elt1 = (ListViewItem)x;
            ListViewItem elt2 = (ListViewItem)y;
            //
            DateTime date1 = DateTime.ParseExact(elt1.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(elt2.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return DateTime.Compare(date1, date2);
        }
    }
}
