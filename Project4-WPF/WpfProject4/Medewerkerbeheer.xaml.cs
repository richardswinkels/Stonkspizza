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
    /// Interaction logic for Medewerkerbeheer.xaml
    /// </summary>
    public partial class Medewerkerbeheer : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private ObservableCollection<Employee> employees;
        private ObservableCollection<User> users;
        private ObservableCollection<Role> roles;
        private ObservableCollection<UserRole> associatedUserRoles;

        private Employee selectedEmployee;
        private User associatedUser;
        private Role selectedRoledToAdd;
        private UserRole selectedRoleToDelete;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                NotifyPropertyChanged("Employees");
            }
        }
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }
        public ObservableCollection<Role> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
        public ObservableCollection<UserRole> AssociatedUserRoles
        {
            get { return associatedUserRoles; }
            set
            {
                associatedUserRoles = value;
                NotifyPropertyChanged("AssociatedUserRoles");
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                LoadAssociatedUser();
                SwitchElements();
                NotifyPropertyChanged("SelectedEmployee");
            }
        }

        public User AssociatedUser
        {
            get { return associatedUser; }
            set
            {
                associatedUser = value;
                LoadAssociatedUserRoles();
                NotifyPropertyChanged("AssociatedUser");
            }
        }

        public Role SelectedRoleToAdd
        {
            get { return selectedRoledToAdd; }
            set { selectedRoledToAdd = value; }
        }

        public UserRole SelectedRoleToDelete
        {
            get { return selectedRoleToDelete; }
            set { selectedRoleToDelete = value; }
        }
        #endregion
        
        public Medewerkerbeheer()
        {
            InitializeComponent();
            LoadEmployees();
            LoadUsers();
            LoadRoles();
            DataContext = this;
            SelectedEmployee = new Employee() { BirthDate = DateTime.Now };
            AssociatedUser = new User();
        }

        private void LoadEmployees()
        {
            Employees = _stonkspizzaDatabase.GetAllEmployees();
        }

        private void LoadUsers()
        {
            Users = _stonkspizzaDatabase.GetAllUsers();
        }

        private void LoadRoles()
        {
            Roles = _stonkspizzaDatabase.GetAllEmployeeRoles();
        }

        private void LoadAssociatedUser()
        {
            if (selectedEmployee != null)
            {
                if (selectedEmployee.Id != null)
                {

                    AssociatedUser = _stonkspizzaDatabase.GetUserById((ulong)SelectedEmployee.Id);
                }
            }
        }

        private void LoadAssociatedUserRoles()
        {
            if (AssociatedUser != null)
            {
                AssociatedUserRoles = _stonkspizzaDatabase.GetUserRolesByUser(AssociatedUser);
            }
        }

        private void SwitchElements()
        {
            if (selectedEmployee != null)
            {
                if (SelectedEmployee.Id == null)
                {
                    tbPassword.Visibility = Visibility.Visible;
                    pwbPassword.Visibility = Visibility.Visible;
                    tbAssociatedUserRoles.Visibility = Visibility.Hidden;
                    lvRoles.Visibility = Visibility.Hidden;
                    tbAddRole.Visibility = Visibility.Hidden;
                    btnAddRole.Visibility = Visibility.Hidden;
                    cmbRoles.Visibility = Visibility.Hidden;
                }
                else
                {
                    tbPassword.Visibility = Visibility.Hidden;
                    pwbPassword.Visibility = Visibility.Hidden;
                    tbAssociatedUserRoles.Visibility = Visibility.Visible;
                    lvRoles.Visibility = Visibility.Visible;
                    tbAddRole.Visibility = Visibility.Visible;
                    btnAddRole.Visibility = Visibility.Visible;
                    cmbRoles.Visibility = Visibility.Visible;
                }
            }
        }

        private void ResetBindingsAndInput()
        {
            cmbRoles.SelectedIndex = -1;
            cmbEmployees.SelectedIndex = -1;

            SelectedEmployee = new Employee() { BirthDate = DateTime.Now };
            AssociatedUser = new User();
            if (associatedUserRoles != null)
            {
                AssociatedUserRoles.Clear();
            }
            if (!String.IsNullOrEmpty(pwbPassword.Password))
            {
                pwbPassword.Password = "";
            }
        }

        private void BtnAddRole_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRoleToAdd != null && AssociatedUser != null)
            {
                if (!AssociatedUserRoles.Any(Role => Role.RoleId == SelectedRoleToAdd.Id))
                {
                    UserRole userRole = new UserRole()
                    {
                        RoleId = SelectedRoleToAdd.Id,
                        UserId = AssociatedUser.Id
                    };
                    _stonkspizzaDatabase.AddUserRole(userRole);
                    LoadAssociatedUserRoles();
                }
                else
                {
                    MessageBox.Show("Medewerker heeft de rol " + SelectedRoleToAdd.Name + " al!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LbAssociatedRoles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedRoleToDelete != null)
            {
                _stonkspizzaDatabase.DeleteUserRole(SelectedRoleToDelete);
                LoadAssociatedUserRoles();
            }
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            ResetBindingsAndInput();
        }

        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee.Id != null)
            {
                _stonkspizzaDatabase.DeleteUser(AssociatedUser);
                _stonkspizzaDatabase.DeleteEmployee(SelectedEmployee);
                _stonkspizzaDatabase.DeleteRolesByUser(associatedUser);
                LoadUsers();
                LoadEmployees();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen medewerker geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee.Id == null)
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(pwbPassword.Password, salt);
                AssociatedUser.Password = hashedPassword;

                if (!string.IsNullOrWhiteSpace(txbFirstName.Text) &&
                    !string.IsNullOrWhiteSpace(txbLastName.Text) &&
                    dpBirthDate.SelectedDate != null &&
                    !string.IsNullOrWhiteSpace(txbBsn.Text) &&
                    !string.IsNullOrWhiteSpace(txbPhone.Text) &&
                    !string.IsNullOrWhiteSpace(txbWorkEmail.Text) &&
                    !string.IsNullOrWhiteSpace(txbPersonalEmail.Text) &&
                    !string.IsNullOrWhiteSpace(txbAddress.Text) &&
                    !string.IsNullOrWhiteSpace(txbZipcode.Text) &&
                    !string.IsNullOrWhiteSpace(txbCity.Text) &&
                    !string.IsNullOrWhiteSpace(txbUsername.Text) &&
                    !string.IsNullOrWhiteSpace(pwbPassword.Password))
                {
                    BindingExpression beFirstname = this.txbFirstName.GetBindingExpression(TextBox.TextProperty);
                    BindingExpression beLastname = this.txbLastName.GetBindingExpression(TextBox.TextProperty);
                    beFirstname.UpdateSource();
                    beLastname.UpdateSource();
                    ulong insertedUserId = _stonkspizzaDatabase.AddUser(AssociatedUser);
                    SelectedEmployee.Id = insertedUserId;
                    _stonkspizzaDatabase.AddEmployee(SelectedEmployee);
                    LoadEmployees();
                    LoadUsers();
                    cmbEmployees.SelectedIndex = cmbEmployees.Items.Count - 1;
                }
                if (string.IsNullOrWhiteSpace(txbFirstName.Text))
                {
                    MessageBox.Show("Voornaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbLastName.Text))
                {
                    MessageBox.Show("Achternaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (dpBirthDate.SelectedDate == null)
                {
                    MessageBox.Show("Geboortedatum niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbBsn.Text))
                {
                    MessageBox.Show("BSN niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPhone.Text))
                {
                    MessageBox.Show("Telefoonnummer niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbWorkEmail.Text))
                {
                    MessageBox.Show("E-mailadres werk niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPersonalEmail.Text))
                {
                    MessageBox.Show("Persoonlijke e-mailadres niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    dpBirthDate.SelectedDate != null && 
                    !string.IsNullOrWhiteSpace(txbBsn.Text) && 
                    !string.IsNullOrWhiteSpace(txbPhone.Text) && 
                    !string.IsNullOrWhiteSpace(txbWorkEmail.Text) && 
                    !string.IsNullOrWhiteSpace(txbPersonalEmail.Text) &&
                    !string.IsNullOrWhiteSpace(txbAddress.Text) &&
                    !string.IsNullOrWhiteSpace(txbZipcode.Text) &&
                    !string.IsNullOrWhiteSpace(txbCity.Text) &&
                    !string.IsNullOrWhiteSpace(txbUsername.Text))
                {
                    BindingExpression beFirstname = this.txbFirstName.GetBindingExpression(TextBox.TextProperty);
                    BindingExpression beLastname = this.txbLastName.GetBindingExpression(TextBox.TextProperty);
                    beFirstname.UpdateSource();
                    beLastname.UpdateSource();
                    _stonkspizzaDatabase.UpdateEmployee(SelectedEmployee);
                    _stonkspizzaDatabase.UpdateUser(AssociatedUser);
                }
                if (string.IsNullOrWhiteSpace(txbFirstName.Text))
                {
                    MessageBox.Show("Voornaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbLastName.Text))
                {
                    MessageBox.Show("Achternaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (dpBirthDate.SelectedDate == null)
                {
                    MessageBox.Show("Geboortedatum niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbBsn.Text))
                {
                    MessageBox.Show("BSN niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPhone.Text))
                {
                    MessageBox.Show("Telefoonnummer niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbWorkEmail.Text))
                {
                    MessageBox.Show("E-mailadres werk niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPersonalEmail.Text))
                {
                    MessageBox.Show("Persoonlijke e-mailadres niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
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
                if (string.IsNullOrWhiteSpace(txbUsername.Text))
                {
                    MessageBox.Show("Gebruikersnaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
