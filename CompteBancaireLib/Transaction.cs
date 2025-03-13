using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaireLib
{
    public class Transaction
    {
        // Proprietes
        public decimal Montant { get; }
        public DateTime Date { get; }
        public string Notes
        {
            get;

        }

        // Constructor
        // Les paramètres ont les mêmes noms que les propriétés, 
        // pour que le Deserializer s'y retrouve
        public Transaction(decimal montant, DateTime date, string notes)
        {
            this.Montant = montant;
            this.Date = date;
            this.Notes = notes;
        }
    }
}
