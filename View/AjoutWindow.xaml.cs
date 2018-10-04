using System.Windows;

namespace TP_Feugere_Adipietro_Garrach
{
    /// <summary>
    /// Interaction logic for AjoutWindow.xaml
    /// </summary>
    public partial class AjoutWindow : Window
    {
        AcceuilWindow acceuil;
        User user;

        public AjoutWindow(AcceuilWindow acceuil, User user)
        {
            this.acceuil = acceuil;
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            this.user = user;
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

        private void TextBoxTelephone_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxTelephone.Text = "";
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

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            acceuil.Show();
            this.Close();
        }

        private void ButtonAjouter_Click(object sender, RoutedEventArgs e)
        {

            Contact contact = new Contact();


            contact.Id = 1;
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
            contact.IdUser = user.Id;

            if (BLL.InsertContact(contact))
                labelMessage.Content = ("Etudiant Ajouté à la BDD");
            else
                labelMessage.Content = (" Erreur de saisie");
        }
    }
}
