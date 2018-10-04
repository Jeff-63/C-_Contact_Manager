using System.Collections.Generic;
using System.Windows;

namespace TP_Feugere_Adipietro_Garrach
{
    /// <summary>
    /// Logique d'interaction pour ListeDesContacts.xaml
    /// </summary>
    public partial class ListeDesContacts : Window
    {
        AcceuilWindow acceuil;
        User user;
        public ListeDesContacts(AcceuilWindow acceuil, User user)
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
            BLL.update = SelectAllContact;
            SelectAllContact();

            if (!user.Admin)
            {
                buttonUpdate.IsEnabled = false;
                buttonDelete.IsEnabled = false;
            }
        }

        public void SelectAllContact()
        {
            listBoxContact.Items.Clear();
            string userId = user.Id.ToString();
            Dictionary<string, string> dico = new Dictionary<string, string>();
            dico.Add("IdUser", userId);
            List<Contact> listCt = BLL.SelectContactWhere(dico);

            if (listCt.Count > 0)
            {
                foreach (Contact contact in listCt)
                {
                    listBoxContact.Items.Add(contact);
                }
            }
            else
            {
                listBoxContact.Items.Add("Name Unknown");
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if ((NomSearch.Text != "Nom...") && (NomSearch.Text != ""))
            {
                dict.Add("Nom", NomSearch.Text);
            }
            if ((Prenom_Search.Text != "Prenom...") && (Prenom_Search.Text != ""))
            {
                dict.Add("Prenom", Prenom_Search.Text);
            }
            if ((VilleSearch.Text != "Ville...") && (VilleSearch.Text != ""))
            {
                dict.Add("Ville", VilleSearch.Text);
            }
            if ((PaysSearch.Text != "Pays...") && (PaysSearch.Text != ""))
            {
                dict.Add("Pays", PaysSearch.Text);
            }

            dict.Add("IdUser", user.Id.ToString());

            listBoxContact.Items.Clear();

            List<Contact> listCt = BLL.SelectContactWhere(dict);

            if (listCt.Count > 0)
            {
                foreach (Contact contact in listCt)
                {
                    listBoxContact.Items.Add(contact);
                }
            }
            else
            {
                listBoxContact.Items.Add("Name Unknown");
            }
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = listBoxContact.SelectedIndex;

            if (index != -1)
            {
                this.Hide();
                Update updateWindow = new Update((Contact)listBoxContact.Items[index], this);
                updateWindow.Show();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = listBoxContact.SelectedIndex;

            if (index != -1)
            {
                if (BLL.DeleteContact((Contact)listBoxContact.Items[index]))
                {
                    MessageBox.Show("Le contact a bien été supprimé");
                    SelectAllContact();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression");
                }
            }
        }

        private void Retour(object sender, RoutedEventArgs e)
        {
            this.Close();
            acceuil.Show();
        }

        private void NomSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            NomSearch.Text = "";
        }

        private void Prenom_Search_GotFocus(object sender, RoutedEventArgs e)
        {
            Prenom_Search.Text = "";
        }

        private void PaysSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            PaysSearch.Text = "";
        }

        private void VilleSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            VilleSearch.Text = "";
        }
    }
}
