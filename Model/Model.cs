namespace TP_Feugere_Adipietro_Garrach
{
    public delegate void DG();

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
        public int IdUser { get; set; }

        public override string ToString()
        {
            return "Nom : " + Nom + "\n" + "Prenom : " + Prenom + "\n" + "Adresse : " + Adresse + "\n" + "Ville : " + Ville + "\n" + "Etat : " + Etat + "\n" + "Pays : " + Pays + "\n" + "Telephone : " + Telephone + "\n";
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
    }

}
