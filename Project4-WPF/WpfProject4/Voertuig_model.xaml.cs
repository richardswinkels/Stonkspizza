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
    /// Interaction logic for Voertuig_model.xaml
    /// </summary>
    public partial class Voertuig_model : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private ObservableCollection<Bikemodel> models;

        private Bikemodel selectedModel;

        public ObservableCollection<Bikemodel> Models
        {
            get { return models; }
            set
            {
                models = value;
                NotifyPropertyChanged("Models");
            }
        }
        public Bikemodel SelectedModel
        {
            get { return selectedModel; }
            set
            {
                selectedModel = value;
                NotifyPropertyChanged("SelectedModel");
            }
        }
        #endregion

        public Voertuig_model()
        {
            InitializeComponent();
            LoadModels();
            DataContext = this;
            selectedModel = new Bikemodel();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
        private void LoadModels()
        {
            Models = _stonkspizzaDatabase.GetAllModels();
        }

        private void btnAddModel_Click(object sender, RoutedEventArgs e)
        {
            ResetBindingsAndInput();
        }

        private void ResetBindingsAndInput()
        {
            cmbModels.SelectedIndex = -1;
            SelectedModel = new Bikemodel();
        }
        
        private void btnDeleteModel_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModel.Id != null)
            {
                _stonkspizzaDatabase.DeleteModel(SelectedModel);
                LoadModels();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen model geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnSaveModel_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedModel.Id == null)
            {
                if (
                    !string.IsNullOrWhiteSpace(txbName.Text))
                {
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.AddModel(selectedModel);
                    LoadModels();
                    cmbModels.SelectedIndex = cmbModels.Items.Count - 1;
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
                    _stonkspizzaDatabase.UpdateModel(selectedModel);
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Naam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}