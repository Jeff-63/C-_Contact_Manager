using System.Windows;

namespace TP_Feugere_Adipietro_Garrach
{

    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void SeConnecter(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                UserName = textBoxLogin.Text,
                Password = textBoxMdp.Password
            };

            //logins valides : 
            //                      1) toto - 123456 Non Admin
            //                      2) tata - abcd Admin

            if (BLL.LogIn(user).Id != 0)
            {
                AcceuilWindow accueil = new AcceuilWindow(user);
                accueil.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("erreur de login");
            }
        }
    }
}
