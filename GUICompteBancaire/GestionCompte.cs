﻿using CompteBancaireLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                RemplirLaListe();
            }
        }

        private void RemplirLaListe()
        {
            foreach (Transaction t in _compte.Transactions)
            {
                ListViewItem unElement = new ListViewItem();
                unElement.Text = t.Date.ToString("dd/MM/yyyy");
                unElement.SubItems.Add(t.Montant.ToString("N2"));
                unElement.SubItems.Add(t.Notes);
                //
                listeTransactions.Items.Add(unElement);
            }
            if (listeTransactions.Items.Count > 0)
            {
                listeTransactions.Items[0].Selected = true;
            }
        }

        public String Fichier { get; set; }



        public GestionCompte()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
