using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for Klantbeheer.xaml
    /// </summary>
    public partial class Klantbeheer : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private ObservableCollection<Customer> customers;
        private ObservableCollection<User> users;

        private Customer selectedCustomer;
        private User associatedUser;

        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                NotifyPropertyChanged("Customers");
            }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                LoadAssociatedUser();
                SwitchElements();
                NotifyPropertyChanged("SelectedCustomer");
            }
        }
        public User AssociatedUser
        {
            get { return associatedUser; }
            set
            {
                associatedUser = value;
                NotifyPropertyChanged("AssociatedUser");
            }
        }
        #endregion

        public Klantbeheer()
        {
            InitializeComponent();
            LoadCustomers();
            LoadUsers();
            DataContext = this;
            SelectedCustomer = new Customer() { PizzaPoints = 10 };
            AssociatedUser = new User();
        }

        private void LoadCustomers()
        {
            Customers = _stonkspizzaDatabase.GetAllCustomers();
        }

        private void LoadUsers()
        {
            Users = _stonkspizzaDatabase.GetAllUsers();
        }

        private void LoadAssociatedUser()
        {
            if (SelectedCustomer != null)
            {
                if (SelectedCustomer.Id != null)
                {
                    AssociatedUser = _stonkspizzaDatabase.GetUserById((ulong) SelectedCustomer.Id);
                }
            }
        }

        private void SwitchElements()
        {
            if (SelectedCustomer != null)
            {
                if(SelectedCustomer.Id == null)
                { 
                    tbPassword.Visibility = Visibility.Visible;
                    pwbPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    tbPassword.Visibility = Visibility.Hidden;
                    pwbPassword.Visibility = Visibility.Hidden;
                }
            }
        }

        private void ResetBindingsAndInput()
        {
            cmbCustomers.SelectedIndex = -1;

            SelectedCustomer = new Customer() { PizzaPoints = 10 };
            AssociatedUser = new User();
            if (!String.IsNullOrEmpty(pwbPassword.Password))
            {
                pwbPassword.Password = "";
            }
        }

        private void BtnSaveCustomers_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer.Id == null)
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pwbPassword.Password, salt);
                AssociatedUser.Password = hashedPassword;

                if (!string.IsNullOrWhiteSpace(txbFirstName.Text) &&
                    !string.IsNullOrWhiteSpace(txbLastName.Text) &&
                    !string.IsNullOrWhiteSpace(txbAddress.Text) &&
                    !string.IsNullOrWhiteSpace(txbZipcode.Text) &&
                    !string.IsNullOrWhiteSpace(txbCity.Text) &&
                    !string.IsNullOrWhiteSpace(txbEmail.Text) &&
                    !string.IsNullOrWhiteSpace(txbPhone.Text) &&
                    !string.IsNullOrWhiteSpace(txbPizzapoints.Text) &&
                    !string.IsNullOrWhiteSpace(txbUsername.Text) &&
                    !string.IsNullOrWhiteSpace(pwbPassword.Password))
                {
                    BindingExpression beFirstname = this.txbFirstName.GetBindingExpression(TextBox.TextProperty);
                    BindingExpression beLastname = this.txbLastName.GetBindingExpression(TextBox.TextProperty);
                    beFirstname.UpdateSource();
                    beLastname.UpdateSource();

                    ulong insertedUserId = _stonkspizzaDatabase.AddUser(AssociatedUser);
                    SelectedCustomer.Id = insertedUserId;
                    _stonkspizzaDatabase.AddCustomer(SelectedCustomer);
                    LoadCustomers();
                    LoadUsers();
                    cmbCustomers.SelectedIndex = cmbCustomers.Items.Count - 1;
                }
                if (string.IsNullOrWhiteSpace(txbFirstName.Text))
                {
                    MessageBox.Show("Voornaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbLastName.Text))
                {
                    MessageBox.Show("Achternaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbAddress.Text))
                {
                    MessageBox.Show("Adres niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbZipcode.Text))
                {
                    MessageBox.Show("Postcode niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbCity.Text))
                {
                    MessageBox.Show("Woonplaats niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbEmail.Text))
                {
                    MessageBox.Show("E-mailadres werk niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPhone.Text))
                {
                    MessageBox.Show("Telefoonnummer niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPizzapoints.Text))
                {
                    MessageBox.Show("Pizzapunten niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbUsername.Text))
                {
                    MessageBox.Show("Gebruikersnaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(pwbPassword.Password))
                {
                    MessageBox.Show("Wachtwoord niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txbFirstName.Text) &&
                    !string.IsNullOrWhiteSpace(txbLastName.Text) &&
                    !string.IsNullOrWhiteSpace(txbAddress.Text) &&
                    !string.IsNullOrWhiteSpace(txbZipcode.Text) &&
                    !string.IsNullOrWhiteSpace(txbCity.Text) &&
                    !string.IsNullOrWhiteSpace(txbEmail.Text) &&
                    !string.IsNullOrWhiteSpace(txbPhone.Text) &&
                    !string.IsNullOrWhiteSpace(txbPizzapoints.Text) &&
                    !string.IsNullOrWhiteSpace(txbUsername.Text))
                {
                    BindingExpression beFirstname = this.txbFirstName.GetBindingExpression(TextBox.TextProperty);
                    BindingExpression beLastname = this.txbLastName.GetBindingExpression(TextBox.TextProperty);
                    beFirstname.UpdateSource();
                    beLastname.UpdateSource();
                    _stonkspizzaDatabase.UpdateUser(AssociatedUser);
                    _stonkspizzaDatabase.UpdateCustomer(SelectedCustomer);
                }
                if (string.IsNullOrWhiteSpace(txbFirstName.Text))
                {
                    MessageBox.Show("Voornaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbLastName.Text))
                {
                    MessageBox.Show("Achternaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbAddress.Text))
                {
                    MessageBox.Show("Adres niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbZipcode.Text))
                {
                    MessageBox.Show("Postcode niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbCity.Text))
                {
                    MessageBox.Show("Woonplaats niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbEmail.Text))
                {
                    MessageBox.Show("E-mailadres werk niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPhone.Text))
                {
                    MessageBox.Show("Telefoonnummer niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPizzapoints.Text))
                {
                    MessageBox.Show("Pizzapunten niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbUsername.Text))
                {
                    MessageBox.Show("Gebruikersnaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            ResetBindingsAndInput();
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer.Id != null)
            {
                _stonkspizzaDatabase.DeleteUser(AssociatedUser);
                _stonkspizzaDatabase.DeleteCustomer(SelectedCustomer);
                LoadUsers();
                LoadCustomers();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen klant geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void TxbPizzapoints_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!IsValid(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsValid(string str)
        {
            int i;
            return int.TryParse(str, out i);
        }
    }
}
