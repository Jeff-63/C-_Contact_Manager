using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Feugere_Adipietro_Garrach
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Etat { get; set; }
        public string Pays { get; set; }
        public string Telephone { get; set; }

        public override string ToString()
        {
            if (Id == 0)
            {
                return "Unknown Student";
            }
            else
            {
                return "Nom : " + Nom + "\n"
                + "Prenom : " + Prenom + "\n"
                + "Adresse : " + Adresse + "\n"
                + "Ville : " + Ville + "\n"
                + "Etat : " + (Etat == null ? "Unknown" : Etat) + "\n"
                + "Pays : " + Pays + "\n"
                + "Telephone : " + Telephone
                + "\n\n********************************* \n";
            }
        }
    }

}
