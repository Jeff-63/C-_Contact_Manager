using System.Collections.Generic;

namespace TP_Feugere_Adipietro_Garrach
{
    public static class BLL
    {
        public static List<Contact> SelectAllContact()
        {
            return DAL.SelectAllContact();
        }

        //listeCriteres est de ce format : <key : attribut, value : valeur de l'attribut>
        public static Contact SelectContactWhere(Dictionary<string,string> listeCriteres)
        {
            return DAL.SelectContactWhere(listeCriteres);
        }

        public static List<Contact> SelectContactsByName(string attribut)
        {
            return DAL.SelectContactsByName(attribut);
        }

        // Le paramètre sera le contact avec ses attributs modifiés
        public static string UpdateContact(Contact contactModifie)
        {
            return DAL.UpdateContact(contactModifie);
        }

        public static string DeleteContact(Contact contactADelete)
        {
            return DAL.DeleteContact(contactADelete);
        }
    }
}
