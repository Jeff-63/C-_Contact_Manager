using System.Collections.Generic;

namespace TP_Feugere_Adipietro_Garrach
{
    public static class BLL
    {
        public static DG update;

        //listeCriteres est de ce format : <key : attribut, value : valeur de l'attribut>
        //exemple : Key = nom, Value = "Toto"
        public static List<Contact> SelectContactWhere(Dictionary<string,string> listeCriteres)
        {
            return DAL.SelectContactWhere(listeCriteres);
        }

        public static bool InsertContact(Contact contactAjout)
        {
            return DAL.InsertContact(contactAjout);
        }

        public static bool UpdateContact(Contact contactModifie)
        {
            return DAL.UpdateContact(contactModifie);
            update();
        }

        public static bool DeleteContact(Contact contactADelete)
        {
            return DAL.DeleteContact(contactADelete);
            update();
        }

        public static User LogIn(User user)
        {
            return DAL.LogIn(user);
        }
    }
}
