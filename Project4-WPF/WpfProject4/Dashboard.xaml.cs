using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WpfProject4.Models;

namespace WpfProject4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        #region properties
        private User authenticatedUser;

        public User AuthenticatedUser
        {
            get { return authenticatedUser; }
            set { authenticatedUser = value; }
        }

        private ObservableCollection<UserRole> userRoles;

        public ObservableCollection<UserRole> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; }
        }
        #endregion

        public Dashboard(User user, ObservableCollection<UserRole> userRoles)
        {
            InitializeComponent();
            //Zet datacontext voor binding
            DataContext = this;
            //Ken meegegeven parameters toe aan properties
            this.AuthenticatedUser = user;
            this.UserRoles = userRoles;
            ShowButtons();
        }

        private void ShowButtons()
        {
            //Bepaal op basis van de rollen van de gebruiker welke buttons hij te zien krijgt
            //Als rol = balie
            if (UserRoles.Any(Role => Role.RoleId == 2))
            {
                btnBestelOverzicht.Visibility = Visibility.Visible;
            }
            //Als rol = bereiding
            if (UserRoles.Any(Role => Role.RoleId == 3))
            {
                btnBestelOverzicht.Visibility = Visibility.Visible;
                btnVoorraadbeheer.Visibility = Visibility.Visible;
            }
            //Als rol = bezorging
            if (UserRoles.Any(Role => Role.RoleId == 4))
            {
                btnBezorgOverzicht.Visibility = Visibility.Visible;
            }
            //Als rol = management
            if (UserRoles.Any(Role => Role.RoleId == 5))
            {
                btnUnitbeheer.Visibility = Visibility.Visible;
                btnIngredientenbeheer.Visibility = Visibility.Visible;
                btnPizzabeheer.Visibility = Visibility.Visible;
                btnMedewerkerbeheer.Visibility = Visibility.Visible;
                btnKlantbeheer.Visibility = Visibility.Visible;
                btnTransactieoverzicht.Visibility = Visibility.Visible;
                btnVoertuigbeheer.Visibility = Visibility.Visible;
            }
            //Als rol = admin
            if (UserRoles.Any(Role => Role.RoleId == 999))
            {
                btnBestelOverzicht.Visibility = Visibility.Visible;
                btnBezorgOverzicht.Visibility = Visibility.Visible;
                btnVoorraadbeheer.Visibility = Visibility.Visible;
                btnUnitbeheer.Visibility = Visibility.Visible;
                btnIngredientenbeheer.Visibility = Visibility.Visible;
                btnPizzabeheer.Visibility = Visibility.Visible;
                btnMedewerkerbeheer.Visibility = Visibility.Visible;
                btnKlantbeheer.Visibility = Visibility.Visible;
                btnTransactieoverzicht.Visibility = Visibility.Visible;
                btnVoertuigbeheer.Visibility = Visibility.Visible;
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Show();
            this.Close();
        }

        private void BtnMedewerkerbeheer_Click(object sender, RoutedEventArgs e)
        {
            Medewerkerbeheer medewerkerbeheer = new Medewerkerbeheer();
            this.Hide();
            medewerkerbeheer.ShowDialog();
            this.Show();
        }

        private void BtnKlantbeheer_Click(object sender, RoutedEventArgs e)
        {
            Klantbeheer klantbeheer = new Klantbeheer();
            this.Hide();
            klantbeheer.ShowDialog();
            this.Show();
        }

        private void BtnUnitbeheer_Click(object sender, RoutedEventArgs e)
        {
            Unitbeheer unitbeheer = new Unitbeheer();
            this.Hide();
            unitbeheer.ShowDialog();
            this.Show();
        }

        private void BtnIngredientenbeheer_Click(object sender, RoutedEventArgs e)
        {
            Ingredientbeheer ingredientbeheer = new Ingredientbeheer();
            this.Hide();
            ingredientbeheer.ShowDialog();
            this.Show();
        }

        private void BtnVoertuigbeheer_Click(object sender, RoutedEventArgs e)
        {
            VoertuigDashboard voertuig = new VoertuigDashboard();
            this.Hide();
            voertuig.ShowDialog();
            this.Show();
        }

        private void BtnPizzabeheer_Click(object sender, RoutedEventArgs e)
        {
            Pizzabeheer pizza = new Pizzabeheer();
            this.Hide();
            pizza.ShowDialog();
            this.Show();
        }

        private void BtnBestelOverzicht_Click(object sender, RoutedEventArgs e)
        {
            Besteloverzicht besteloverzicht = new Besteloverzicht(AuthenticatedUser);
            this.Hide();
            besteloverzicht.ShowDialog();
            this.Show();
        }

        private void BtnBezorgOverzicht_Click(object sender, RoutedEventArgs e)
        {
            Bezorgoverzicht bezorgoverzicht = new Bezorgoverzicht(AuthenticatedUser);
            this.Hide();
            bezorgoverzicht.ShowDialog();
            this.Show();
        }

        private void BtnTransactieoverzicht_Click(object sender, RoutedEventArgs e)
        {
            Transactieoverzicht transactieoverzicht = new Transactieoverzicht();
            this.Hide();
            transactieoverzicht.ShowDialog();
            this.Show();
        }

        private void BtnVoorraadbeheer_Click(object sender, RoutedEventArgs e)
        {
            Voorraadbeheer voorraadbeheer = new Voorraadbeheer();
            this.Hide();
            voorraadbeheer.ShowDialog();
            this.Show();
        }
    }
}