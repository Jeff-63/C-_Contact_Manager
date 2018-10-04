using System.Windows;

namespace TP_Feugere_Adipietro_Garrach
{

    public partial class Update : Window
    {
        private Contact contact;
        private ListeDesContacts acceuil;

        public Update(Contact ctc, ListeDesContacts acceuil)
        {
            this.contact = ctc;
            InitializeComponent();
            TextBoxNom.Text = contact.Nom;
            TextBoxPrenom.Text = contact.Prenom;
            TextBoxTelephone.Text = contact.Telephone;
            TextBoxAdresse.Text = contact.Adresse;
            TextBoxVille.Text = contact.Ville;
            TextBoxEtat.Text = contact.Etat;
            TextBoxPays.Text = contact.Pays;

            this.acceuil = acceuil;
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            contact.Nom = TextBoxNom.Text;
            contact.Prenom = TextBoxPrenom.Text;
            contact.Adresse = TextBoxAdresse.Text;
            contact.Ville = TextBoxVille.Text;
            contact.Etat = TextBoxEtat.Text;
            contact.Pays = TextBoxPays.Text;
            if (TextBoxTelephone.Text != "")
                contact.Telephone = TextBoxTelephone.Text;
            else
                contact.Telephone = null;

            if (BLL.UpdateContact(contact))
            {
                labelMessage.Content = ("Etudiant modifié dans la BDD");
                acceuil.SelectAllContact();
            }
            else
                labelMessage.Content = (" Erreur de saisie");
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            acceuil.Show();
            this.Close();
        }

        private void TextBoxNom_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNom.Text = "";
        }

        private void TextBoxPrenom_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPrenom.Text = "";
        }

        private void TextBoxAdresse_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxAdresse.Text = "";
        }

        private void TextBoxVille_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxVille.Text = "";
        }

        private void TextBoxEtat_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxEtat.Text = "";
        }

        private void TextBoxPays_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPays.Text = "";
        }

        private void TextBoxTelephone_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxTelephone.Text = "";
        }
    }
}
