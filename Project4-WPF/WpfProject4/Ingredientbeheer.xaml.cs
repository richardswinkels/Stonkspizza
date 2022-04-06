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
    public partial class Ingredientbeheer : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private Ingredient selectedIngredient;

        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<Unit> units;

        public Ingredient SelectedIngredient
        {
            get { return selectedIngredient; }
            set { selectedIngredient = value;
                NotifyPropertyChanged("SelectedIngredient");
                
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value;
                NotifyPropertyChanged("Ingredients");
            }
        }

        public ObservableCollection<Unit> Units
        {
            get { return units; }
            set { units = value;
                NotifyPropertyChanged("Units");
            }
        }
        #endregion

        public Ingredientbeheer()
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
                
                if (!string.IsNullOrWhiteSpace(txbName.Text) &&
                    !string.IsNullOrWhiteSpace(txbPrice.Text) &&
                    cmbUnits.SelectedItem != null)
                {
                    //Insert
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.AddIngredient(SelectedIngredient);
                    LoadIngredients();
                    cmbIngredients.SelectedIndex = cmbIngredients.Items.Count - 1;
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Ingredientnaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (cmbUnits.SelectedItem == null)
                {
                    MessageBox.Show("Geen unit geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPrice.Text))
                {
                    MessageBox.Show("Prijs niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txbName.Text) &&
                    !string.IsNullOrWhiteSpace(txbPrice.Text) &&
                    cmbUnits.SelectedItem != null)
                {
                    //Update
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.UpdateIngredient(SelectedIngredient);
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Ingredientnaam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (cmbUnits.SelectedItem == null)
                {
                    MessageBox.Show("Geen unit geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (string.IsNullOrWhiteSpace(txbPrice.Text))
                {
                    MessageBox.Show("Prijs niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            cmbIngredients.SelectedIndex = -1;
            ResetBindingsAndInput();
        }

        private void BtnDeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredient.Id != null)
            {
                if (SelectedIngredient.Id != 1)
                {
                    _stonkspizzaDatabase.DeleteIngredient(SelectedIngredient);
                    LoadIngredients();
                    ResetBindingsAndInput();
                }
                else
                {
                    MessageBox.Show(SelectedIngredient.Name + " is niet verwijderbaar!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Geen unit geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ResetBindingsAndInput()
        {
            cmbIngredients.SelectedIndex = -1;
            SelectedIngredient = new Ingredient();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
