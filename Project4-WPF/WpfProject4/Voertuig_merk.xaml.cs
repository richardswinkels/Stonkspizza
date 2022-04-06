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
    /// Interaction logic for Voertuig_merk.xaml
    /// </summary>
    public partial class Voertuig_merk : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private ObservableCollection<Bikebrand> brands;

        private Bikebrand selectedBrand;

        public ObservableCollection<Bikebrand> Brands
        {
            get { return brands; }
            set
            {
                brands = value;
                NotifyPropertyChanged("Brands");
            }
        }
        public Bikebrand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;
                NotifyPropertyChanged("SelectedBrand");
            }
        }
        #endregion
        public Voertuig_merk()
        {
            InitializeComponent();
            LoadBrands();
            DataContext = this;
            SelectedBrand = new Bikebrand();
        }
        private void LoadBrands()
        {
            Brands = _stonkspizzaDatabase.GetAllBrands();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void btnAddBrand_Click(object sender, RoutedEventArgs e)
        {
            ResetBindingsAndInput();
        }

        private void ResetBindingsAndInput()
        {
            cmbBrands.SelectedIndex = -1;
            SelectedBrand = new Bikebrand();
        }

        private void btnDeleteBrand_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBrand.Id != null)
            {
                _stonkspizzaDatabase.DeleteBrand(SelectedBrand);
                LoadBrands();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen merk geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSaveBrand_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBrand.Id == null)
            {
                if (
                    !string.IsNullOrWhiteSpace(txbName.Text))
                {
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.AddBrand(selectedBrand);
                    LoadBrands();
                    cmbBrands.SelectedIndex = cmbBrands.Items.Count - 1;
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Naam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txbName.Text))
                {
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.UpdateBrand(selectedBrand);
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Naam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
