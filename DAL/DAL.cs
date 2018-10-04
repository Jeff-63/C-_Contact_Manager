using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TP_Feugere_Adipietro_Garrach
{
    public static class DAL
    {
        // Modifier Le Data Source pour faire fonctionner l'appli
        private static string connStr = @"Data Source=DESKTOP-68THNVP\SQLEXPRESS; Initial Catalog=BdTpFeugere_Adipietro_Garrach; Integrated security=True;Connect Timeout=5";

        public static List<Contact> SelectContactWhere(Dictionary<string, string> listeCriteres)
        {

            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                DataSet dataSet = new DataSet();
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"select * 
                                        from Contact 
                                        where ";
                    string valueAtFirstPosition = "";

                    if (listeCriteres.Count > 0)
                        valueAtFirstPosition = listeCriteres.First().Value;
                    else
                        return liste;

                    foreach (string attribut in listeCriteres.Keys)
                    {

                        if (listeCriteres.Count > 1 && listeCriteres[attribut] != valueAtFirstPosition)
                            cmd.CommandText += " AND ";

                        cmd.CommandText += attribut.ToString() + " = '" + listeCriteres[attribut] + "'";

                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataSet);
                }
                conn.Close();

                DataTable table = dataSet.Tables[0];
                DataRowCollection rows = table.Rows;

                foreach (DataRow row in rows)
                {
                    Contact ctc = new Contact();

                    ctc.Id = Convert.ToInt32(row["Id"]);
                    ctc.Nom = Convert.ToString(row["Nom"]);
                    ctc.Prenom = Convert.ToString(row["Prenom"]);
                    ctc.Adresse = Convert.ToString(row["Adresse"]);
                    ctc.Ville = Convert.ToString(row["Ville"]);
                    ctc.Etat = Convert.ToString(row["Etat"]);
                    ctc.Pays = Convert.ToString(row["Pays"]);
                    ctc.Telephone = Convert.ToString(row["Telephone"]);
                    ctc.IdUser = Convert.ToInt32(row["IdUser"]);

                    liste.Add(ctc);
                }
            }

            return liste;
        }

        public static bool UpdateContact(Contact contactModifie)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "update Contact Set "
                                       + "Nom = @Nom, "
                                       + "Prenom = @Prenom, "
                                       + "Adresse = @Adresse, "
                                       + "Ville = @Ville, "
                                       + "Etat = @Etat, "
                                       + "Pays = @Pays, "
                                       + "Telephone = @Telephone "
                                       + "where Id = @Id";
                        cmd.Parameters.Add(new SqlParameter("@Id", contactModifie.Id));
                        cmd.Parameters.Add(new SqlParameter("@Nom", contactModifie.Nom));
                        cmd.Parameters.Add(new SqlParameter("@Prenom", contactModifie.Prenom));
                        cmd.Parameters.Add(new SqlParameter("@Adresse", contactModifie.Adresse));
                        cmd.Parameters.Add(new SqlParameter("@Ville", contactModifie.Ville));
                        cmd.Parameters.Add(new SqlParameter("@Etat", contactModifie.Etat));
                        cmd.Parameters.Add(new SqlParameter("@Pays", contactModifie.Pays));
                        if (contactModifie.Telephone == null || contactModifie.Telephone == "")
                            cmd.Parameters.Add(new SqlParameter("@Telephone", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@Telephone", contactModifie.Telephone));
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteContact(Contact contactADelete)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "delete from Contact"
                                   + " where Id = @Id";
                        cmd.Parameters.Add(new SqlParameter("@Id", contactADelete.Id));
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {

                return false;
            }

        }

        public static bool InsertContact(Contact contactAInserer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "insert into Contact"
                                   + " values( @Nom , @Prenom , @Adresse , @Ville , @Etat , @Pays, @Telephone, @IdUser)";
                        cmd.Parameters.Add(new SqlParameter("@Nom", contactAInserer.Nom));
                        cmd.Parameters.Add(new SqlParameter("@Prenom", contactAInserer.Prenom));
                        cmd.Parameters.Add(new SqlParameter("@Adresse", contactAInserer.Adresse));
                        cmd.Parameters.Add(new SqlParameter("@Ville", contactAInserer.Ville));
                        cmd.Parameters.Add(new SqlParameter("@Etat", contactAInserer.Etat));
                        cmd.Parameters.Add(new SqlParameter("@Pays", contactAInserer.Pays));
                        if (contactAInserer.Telephone == null)
                            cmd.Parameters.Add(new SqlParameter("@Telephone", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@Telephone", contactAInserer.Telephone));
                        cmd.Parameters.Add(new SqlParameter("@IdUser", contactAInserer.IdUser));
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static User LogIn(User user)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {

                DataSet dataSet = new DataSet();
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select Id, Admin from Users where Login = @UserName AND Password = @Password";
                    cmd.Parameters.Add(new SqlParameter("@UserName", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", user.Password));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataSet);
                }
                conn.Close();

                DataTable table = dataSet.Tables[0];
                DataRowCollection rows = table.Rows;

                foreach (DataRow row in rows)
                {
                    user.Id = Convert.ToInt32(row["Id"]);
                    user.Admin = Convert.ToBoolean(row["Admin"]);
                }
            }

            return user;
        }
    }
}
