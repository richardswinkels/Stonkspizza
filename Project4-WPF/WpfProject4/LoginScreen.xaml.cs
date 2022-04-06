using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProject4.Models;
using BCrypt.Net;
using System.Collections.ObjectModel;

namespace WpfProject4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Haal de user op aan de hand van het e-mailadres
            User user = _stonkspizzaDatabase.GetUserByEmail(txbEmail.Text);
            //Als user niet null is
            if (user != null)
            {
                //Haal alle rollen van user op
                ObservableCollection<UserRole> userRolesList = _stonkspizzaDatabase.GetUserRolesByUser(user);
                //Controleer of klantrol aanwezig is
                bool isCustomer = userRolesList.Any(Role => Role.RoleId == 1);

                //Controleer of user geen klant is en verifieer login
                if (!isCustomer && user.VerifyLogin(pwbPassword.Password))
                {
                    Dashboard dashboard = new Dashboard(user, userRolesList);
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    //Laat foutmelding zien
                    MessageBox.Show("Inloggegevens onjuist", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                //Laat foutmelding zien
                MessageBox.Show("Inloggegevens onjuist", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnBypassLogin_Click(object sender, RoutedEventArgs e)
        {
            txbEmail.Text = "samira@pizzasumma.nl";
            pwbPassword.Password = "password";
            BtnLogin_Click(sender, e);
        }
    }
}
