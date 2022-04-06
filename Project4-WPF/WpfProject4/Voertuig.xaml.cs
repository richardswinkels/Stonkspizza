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
    /// Interaction logic for Voertuig.xaml
    /// </summary>
    public partial class Voertuig : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();
        #region properties
        private Bike selectedBike;

        private ObservableCollection<Bike> bikes;
        private ObservableCollection<Bikebrand> brands;
        private ObservableCollection<Bikemodel> models;
        private ObservableCollection<Employee> employees;


        public Bike SelectedBike
        {
            get { return selectedBike; }
            set
            {
                selectedBike = value;
                NotifyPropertyChanged("SelectedBike");
            }
        }
  
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                NotifyPropertyChanged("SelectedBike");
            }
        }

        public ObservableCollection<Bike> Bikes
        {
            get { return bikes; }
            set
            {
                bikes = value;
                NotifyPropertyChanged("Ingredients");
            }
        }

        public ObservableCollection<Bikebrand> Brands
        {
            get { return brands; }
            set
            {
                brands = value;
                NotifyPropertyChanged("Brands");
            }
        }

        public ObservableCollection<Bikemodel> Models
        {
            get { return models; }
            set
            {
                models = value;
                NotifyPropertyChanged("Brands");
            }
        }
        #endregion
        public Voertuig()
        {
            InitializeComponent();
            DataContext = this;
            LoadBikes();
            LoadBrands();
            LoadModels();
            LoadEmployees();
            SelectedBike = new Bike();
        }
        private void LoadBikes()
        {
            Bikes = _stonkspizzaDatabase.GetAllBikes();
        }
        private void LoadEmployees()
        {
            Employees = _stonkspizzaDatabase.GetAllEmployees();
        }
        private void LoadBrands()
        {
            Brands = _stonkspizzaDatabase.GetAllBrands();
        }
        private void LoadModels()
        {
            Models = _stonkspizzaDatabase.GetAllModels();
        }

        private void BtnAddBike_Click(object sender, RoutedEventArgs e)
        {
            cmbBikes.SelectedIndex = -1;
            ResetBindingsAndInput();
        }

        private void BtnDeleteBike_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBike.Id != null)
            {
                _stonkspizzaDatabase.DeleteBike(SelectedBike);
                LoadBikes();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen unit geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSaveBike_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBike.Id == null)
            {

                if (cmbBrands.SelectedItem != null &&
                    cmbEmployees.SelectedItem != null &&
                    cmbModels.SelectedItem != null)
                {
                    //Insert
                    _stonkspizzaDatabase.AddBike(SelectedBike);
                    LoadBikes();
                    cmbBikes.GetBindingExpression(ComboBox.ItemsSourceProperty).UpdateTarget();

                    cmbBikes.SelectedIndex = cmbBikes.Items.Count - 1;
                }
                if (cmbBrands.SelectedItem == null)
                {
                    MessageBox.Show("Merk niet geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (cmbModels.SelectedItem == null)
                {
                    MessageBox.Show("Geen model geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (cmbEmployees.SelectedItem == null)
                {
                    MessageBox.Show("Geen werknemer geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (cmbBrands.SelectedItem != null &&
                   cmbEmployees.SelectedItem != null &&
                   cmbModels.SelectedItem != null)
                {
                    //Update
                    _stonkspizzaDatabase.UpdateBike(SelectedBike);
                    MessageBox.Show("Wijzigingen opgeslagen!");
                }
                if (cmbBrands.SelectedItem == null)
                {
                    MessageBox.Show("Merk niet geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (cmbModels.SelectedItem == null)
                {
                    MessageBox.Show("Geen model geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (cmbEmployees.SelectedItem == null)
                {
                    MessageBox.Show("Geen werknemer geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ResetBindingsAndInput()
        {
            cmbBikes.SelectedIndex = -1;
            SelectedBike = new Bike();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
