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
    /// Interaction logic for Ingredientbeheer.xaml
    /// </summary>
    public partial class Voorraadbeheer : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private Ingredient selectedIngredient;

        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Unit> units;


        public Ingredient SelectedIngredient
        {
            get { return selectedIngredient; }
            set
            {
                selectedIngredient = value;
                NotifyPropertyChanged("SelectedIngredient");
                if (selectedIngredient.Id != null)
                {
                    spBtns.Visibility = Visibility.Visible;
                }
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                NotifyPropertyChanged("Ingredients");
            }
        }

        public ObservableCollection<Unit> Units
        {
            get { return units; }
            set
            {
                units = value;
                NotifyPropertyChanged("Units");
            }
        }
        #endregion

        public Voorraadbeheer()
        {
            InitializeComponent();
            DataContext = this;
            LoadIngredients();
            LoadUnits();
            SelectedIngredient = new Ingredient();
        }

        private void LoadIngredients()
        {
            Ingredients = _stonkspizzaDatabase.GetAllIngredients();
        }
        private void LoadUnits()
        {
            Units = _stonkspizzaDatabase.GetAllUnits();
        }

        private void BtnSaveIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient.Id == null)
            {
                MessageBox.Show("Selecteer eerst een ingrediënt");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txbQuantity.Text))
                {
                    //Update
                    BindingExpression beName = this.txbQuantity.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.UpdateIngredient(SelectedIngredient);
                }
                if (string.IsNullOrWhiteSpace(txbQuantity.Text))
                {
                    MessageBox.Show("Geen voorraad opgegeven!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void btnAdd1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedIngredient.Add1();
                txbQuantity.Text = selectedIngredient.Quantity.ToString();

            }
            catch
            {
                MessageBox.Show("Alleen nummers aub, danke");
            }
        }

        private void btnAdd2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedIngredient.Add2();
                txbQuantity.Text = selectedIngredient.Quantity.ToString();

            }
            catch
            {
                MessageBox.Show("Alleen nummers aub, danke");
            }
        }

        private void btnAdd5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedIngredient.Add5();
                txbQuantity.Text = selectedIngredient.Quantity.ToString();

            }
            catch
            {
                MessageBox.Show("Alleen nummers aub, danke");
            }
        }

        private void btnAdd10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedIngredient.Add10();
                txbQuantity.Text = selectedIngredient.Quantity.ToString();
            }
            catch
            {
                MessageBox.Show("Alleen nummers aub, danke");
            }
        }
    }
}