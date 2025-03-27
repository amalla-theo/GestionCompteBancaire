using CompteBancaireLib;
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
            }
        }

        public String Fichier { get; set; }
   


        public GestionCompte()
        {
            InitializeComponent();
        }
    }
}
