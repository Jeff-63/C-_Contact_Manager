using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TP_Feugere_Adipietro_Garrach
{
    public static class DAL
    {
        public static List<Contact> SelectAllContact()
        {
            List<Contact> contacts = new List<Contact>();

            // Date Source = le même que le server Name dans la fenêtre de connection de Sql Server Management
            string connStr = @"Data Source=VIEWW7-EN-19\SQLEXPRESS; Initial Catalog=BdTest; Integrated security=True;Connect Timeout=30";

            //string connStr = ConfigurationManager.ConnectionStrings["ConnexionMaBdTest"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                /*
                 * Mode déconnecté
                 */
                DataSet dataSet = new DataSet();
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select *
                                    from Contact";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact contact = new Contact();

                            contact.Id = reader.GetInt32(0);
                            contact.Nom = reader.GetString(1);
                            contact.Prenom = reader.GetString(1);
                            contact.Adresse = reader.GetString(1);
                            contact.Ville = reader.GetString(1);
                            contact.Pays = reader.GetString(1);
                            contact.Telephone = reader.GetString(1);

                            if (!reader.IsDBNull(4))
                            {
                                contact.Etat = reader.GetString(4);
                            }


                            contacts.Add(contact);
                        }
                    }
                }

            }

            return contacts;
        }

        public static Contact SelectContactWhere(Dictionary<string, string> listeCriteres)
        {
            //Code a implémenter





            //retourner le contact
            return new Contact();
        }

        public static List<Contact> SelectContactsByName(string nom)
        {
            //Code a implémenter
            string connStr = @"Data Source=DESKTOP-68THNVP\SQLEXPRESS; Initial Catalog=MyTest; Integrated security=True;Connect Timeout=30";
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from Contact where Nom='"  + nom + "';";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Contact contact = new Contact();

                            contact.Id = reader.GetInt32(0);
                            contact.Nom = reader.GetString(1);
                            contact.Prenom = reader.GetString(1);
                            contact.Adresse = reader.GetString(1);
                            contact.Ville = reader.GetString(1);
                            contact.Pays = reader.GetString(1);
                            contact.Telephone = reader.GetString(1);
                            if (!reader.IsDBNull(4))
                            {
                                contact.Etat = reader.GetString(4);
                            }


                            contacts.Add(contact);
                        }
                    }
                }
            }

            //retourner le contact
            return contacts;
        }

        public static string UpdateContact(Contact contactModifie)
        {
            //Code a implémenter





            //retourner ok ou erreur
            return "";
        }

        public static string DeleteContact(Contact contactADelete)
        {
            //Code a implémenter




            //retourner ok ou erreur
            return "";
        }
    }
}
