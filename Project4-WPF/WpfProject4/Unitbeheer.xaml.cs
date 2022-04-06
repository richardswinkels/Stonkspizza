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
    /// Interaction logic for Unitbeheer.xaml
    /// </summary>
    public partial class Unitbeheer : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private ObservableCollection<Unit> units;

        private Unit selectedUnit;

        public ObservableCollection<Unit> Units
        {
            get { return units; }
            set
            {
                units = value;
                NotifyPropertyChanged("Units");
            }
        }
        public Unit SelectedUnit
        {
            get { return selectedUnit; }
            set
            {
                selectedUnit = value;
                NotifyPropertyChanged("SelectedUnit");
            }
        }
        #endregion
        public Unitbeheer()
        {
            InitializeComponent();
            LoadUnits();
            DataContext = this;
            SelectedUnit = new Unit();
        }

        private void LoadUnits()
        {
            Units = _stonkspizzaDatabase.GetAllUnits();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            ResetBindingsAndInput();
        }

        private void ResetBindingsAndInput()
        {
            cmbUnits.SelectedIndex = -1;
            SelectedUnit = new Unit();
        }

        private void btnDeleteUnit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUnit.Id != null)
            {
                _stonkspizzaDatabase.DeleteUnit(SelectedUnit);
                LoadUnits();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen unit geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSaveUnit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUnit.Id == null)
            {
                if (
                    !string.IsNullOrWhiteSpace(txbName.Text))
                {
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.AddUnit(selectedUnit);
                    LoadUnits();
                    cmbUnits.SelectedIndex = cmbUnits.Items.Count - 1;
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
                    _stonkspizzaDatabase.UpdateUnit(selectedUnit);
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Naam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
