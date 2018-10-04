using System.Windows;

namespace TP_Feugere_Adipietro_Garrach
{
    public partial class AcceuilWindow : Window
    {
        private User user;

        public AcceuilWindow(User user)
        {
            InitializeComponent();
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            labelBienvenue.Content += user.UserName
                + "\n"
                + " sur votre plateforme de contact";
            this.user = user;
            if (!this.user.Admin)
                ButtonAjouterContact.IsEnabled = false;
        }

        private void ButtonAjouterContact_Click(object sender, RoutedEventArgs e)
        {
            AjoutWindow ajout = new AjoutWindow(this, user);
            ajout.Show();
            this.Hide();
        }

        private void ButtonListContact_Click(object sender, RoutedEventArgs e)
        {
            ListeDesContacts list = new ListeDesContacts(this, user);
            list.Show();
            this.Hide();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Deconnecter(object sender, RoutedEventArgs e)
        {
            LogIn loginWindow = new LogIn();
            loginWindow.Show();
            this.Close();
        }
    }
}
