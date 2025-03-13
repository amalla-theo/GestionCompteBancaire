using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompteBancaireLib
{
    public class CompteAvecSauvegarde : CompteBancaire
    {
        // Le seul moyen de construire un CompteBancaire est avec des paramètres
        // On doit donc fournir ce constructeur qui sert de relai.
        public CompteAvecSauvegarde(string nom, decimal initialSolde) : base(nom, initialSolde)
        {
        }

        // Ce constructeur n'est pas visible de l'extérieur
        // Mais utilisé par la méthode LireCSV
        protected CompteAvecSauvegarde(string nom, string numero)
        {
            Proprietaire = nom;
            Numero = numero;
        }

        // Cette étiquette fonctionne à partir de .NET 8. Dans les versions précédentes, il devrait être public
        [JsonConstructor] 
        protected CompteAvecSauvegarde()
        {
        }

        [JsonIgnore]
        public String NomDeFichier
        {
            get
            {
                return Proprietaire + "_" + Numero;
            }
        }


        public void EcrireCSV()
        {
            // On crée un fichier
            string fichier = NomDeFichier;
            if (!fichier.EndsWith(".csv", StringComparison.InvariantCultureIgnoreCase))
            {
                fichier += ".csv";
            }
            StreamWriter sw = new StreamWriter(fichier);
            //
            foreach (var transact in Transactions)
            {
                string ligne = String.Format("{0};{1,10};{2}",
                    transact.Date.ToString("dd:MM:yyyy"),
                    transact.Montant.ToString("N2"),
                    transact.Notes);
                sw.WriteLine(ligne);
            }
            sw.Close();
        }

        public void EcrireJSON()
        {
            String json = JsonSerializer.Serialize(this);
            string fichier = NomDeFichier;
            if (!fichier.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
            {
                fichier += ".json";
            }
            File.WriteAllText(fichier, json);
        }

        public static CompteAvecSauvegarde LireJSON(String nomDeFichier)
        {
            //
            if (!File.Exists(nomDeFichier))
            {
                throw new Exception(String.Format("Le Fichier {0} n'existe pas.", nomDeFichier));
            }
            string json = File.ReadAllText(nomDeFichier);
            //
            var compte = JsonSerializer.Deserialize<CompteAvecSauvegarde>(json);
            return compte;
        }


        public static CompteAvecSauvegarde LireCSV(String nomDeFichier)
        {
            //
            if (!File.Exists(nomDeFichier))
            {
                throw new Exception(String.Format("Le Fichier {0} n'existe pas.", nomDeFichier));
            }
            // IL faut enlever le CSV pour récupérer le Nom et le Numero
            string[] infos = Path.GetFileNameWithoutExtension(nomDeFichier).Split('_');
            if (infos.Length != 2)
            {
                throw new Exception($"Le Nom de fichier {nomDeFichier} est incorrect.");
            }
            // On lit un fichier
            StreamReader sr = new StreamReader(nomDeFichier);
            //
            CompteAvecSauvegarde nouveau = new CompteAvecSauvegarde(infos[0], infos[1]);
            string ligne;
            bool contenuOk = false;
            while ((ligne = sr.ReadLine()) != null)
            {
                contenuOk = true;
                string[] infosTransaction = ligne.Split(";");
                if (infosTransaction.Length != 3)
                {
                    throw new Exception($"Fichier : {nomDeFichier}" + Environment.NewLine +
                        $"Ligne : {ligne}" + Environment.NewLine +
                        "Contenu incorrect"
                        );
                }
                decimal valeur = Convert.ToDecimal(infosTransaction[1]);
                DateTime moment = DateTime.ParseExact(infosTransaction[0], "dd:MM:yyyy", CultureInfo.InvariantCulture);
                String commentaire = infosTransaction[2];
                if (valeur > 0)
                {
                    nouveau.FaireDepot(valeur, moment, commentaire);
                }
                else
                {
                    nouveau.FaireRetrait(-1 * valeur, moment, commentaire);
                }
            }
            sr.Close();
            if (!contenuOk)
            {
                throw new Exception($"Le fichier {nomDeFichier} ne contient pas d'informations.");
            }
            return nouveau;
        }
    }
}
