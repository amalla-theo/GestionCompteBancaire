﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompteBancaireLib
{
    public class CompteBancaire
    {
        // Proprietes
        public string Numero { get; set; }
        public string Proprietaire { get; set; }

        [JsonIgnore]
        public decimal Solde
        {
            get

            {
                decimal solde = 0;
                foreach (var item in allTransactions)
                {
                    solde += item.Montant;
                }

                return solde;
            }


        }
        private static int compteNumeroBase = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();


        public Transaction[] Transactions
        {
            get
            {
                // Cree une copie, sous forme de tableau.
                return allTransactions.ToArray();
            }

            // En mode internal, ce n'est pas visible de l'extérieur (comme private ou protected)
            // seul le code du même assembly peut accéder à ce membre.
            set
            {
                allTransactions = new List<Transaction>();
                allTransactions.AddRange(value);
            }
        }

        // Il est utilisé par la Classe fille
        protected CompteBancaire()
        {

        }

        // Constructeur
        public CompteBancaire(string nom, decimal initialSolde)
        {

            this.Proprietaire = nom;
            this.Numero = compteNumeroBase.ToString();
            compteNumeroBase++;
            FaireDepot(initialSolde, DateTime.Now, "Solde initial"); //(#4)
        }

        // Methodes
        public void FaireDepot(decimal montant, DateTime date, string note)
        {
            if (allTransactions.Count > 0)
            {
                allTransactions[0].Date = date;
            }
            //(#2)
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Le montant du depot doit être positif");
            }
            //(#1)
            var depot = new Transaction(montant, date, note);
            allTransactions.Add(depot);
        }

        public void FaireRetrait(decimal montant, DateTime date, string note)
        {
            //(#3)
            if (montant <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(montant), "Le montant du retrait doit être positif");
            }
            if (Solde - montant < 0)
            {
                throw new InvalidOperationException("Pas assez de fonds pour faire ce retrait");
            }
            var retrait = new Transaction(-montant, date, note);
            allTransactions.Add(retrait);
        }
    }
}
