using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for Pizzabeheer.xaml
    /// </summary>
    public partial class Pizzabeheer : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private ObservableCollection<Pizza> pizzas;
        private ObservableCollection<Ingredient> ingredients;
        private ObservableCollection<PizzaIngredient> associatedPizzaIngredients;

        private Pizza selectedPizza;
        private Ingredient selectedIngredientToAdd;
        private PizzaIngredient selectedIngredientToDelete;


        public ObservableCollection<Pizza> Pizzas
        {
            get { return pizzas; }
            set
            {
                pizzas = value;
                NotifyPropertyChanged("Pizzas");
            }
        }
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        public ObservableCollection<PizzaIngredient> AssociatedPizzaIngredients
        {
            get { return associatedPizzaIngredients; }
            set
            {
                associatedPizzaIngredients = value;
                NotifyPropertyChanged("AssociatedPizzaIngredients");
            }
        }
        
        public Pizza SelectedPizza
        {
            get { return selectedPizza; }
            set
            {
                selectedPizza = value;
                if (selectedPizza.Id != null)
                {
                    string appPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\assets\";
                    try
                    {
                        Imagesource.Source = new BitmapImage(new Uri(appPath + "pizza" + selectedPizza.Id.ToString() + ".png"));
                    }
                    catch
                    {
                        Imagesource.Source = null;
                    }
                    Afbeelding.Visibility = Visibility.Visible;
                }
                LoadPizzaIngredients();
                SwitchElements();
                NotifyPropertyChanged("SelectedPizza");
                
            }
        }
        public Ingredient SelectedIngredientToAdd
        {
            get { return selectedIngredientToAdd; }
            set { selectedIngredientToAdd = value; }
        }

        public PizzaIngredient SelectedIngredientToDelete
        {
            get { return selectedIngredientToDelete; }
            set { selectedIngredientToDelete = value; }
        }
        #endregion

        public Pizzabeheer()
        {
            InitializeComponent();
            LoadPizzas();
            LoadIngredients();
            DataContext = this;
            SelectedPizza = new Pizza();

        }

        private void LoadPizzas()
        {
            Pizzas = _stonkspizzaDatabase.GetAllPizzas();
        }
        private void LoadIngredients()
        {
            Ingredients = _stonkspizzaDatabase.GetAllIngredients();
            //Verwijder pizzabodem
            Ingredients.Remove(Ingredients[0]);
        }
        private void LoadPizzaIngredients()
        {
            if (SelectedPizza != null)
            {
                AssociatedPizzaIngredients = _stonkspizzaDatabase.GetPizzaIngredientsByPizza(SelectedPizza);
            }
        }

        private void SwitchElements()
        {
            if (selectedPizza != null)
            {
                if (selectedPizza.Id == null)
                {
                    lvIngredients.Visibility = Visibility.Hidden;
                    tbAddIngredient.Visibility = Visibility.Hidden;
                    btnAddIngredient.Visibility = Visibility.Hidden;
                    cmbIngredients.Visibility = Visibility.Hidden;
                }
                else
                {
                    lvIngredients.Visibility = Visibility.Visible;
                    tbAddIngredient.Visibility = Visibility.Visible;
                    btnAddIngredient.Visibility = Visibility.Visible;
                    cmbIngredients.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnAddPizza_Click(object sender, RoutedEventArgs e)
        {
            ResetBindingsAndInput();
        }

        private void ResetBindingsAndInput()
        {
            cmbIngredients.SelectedIndex = -1;
            cmbPizzas.SelectedIndex = -1;
            SelectedPizza = new Pizza();
            if(associatedPizzaIngredients != null)
            {
                associatedPizzaIngredients.Clear();
            }
        }

        private void btnDeletePizza_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPizza.Id != null)
            {
                _stonkspizzaDatabase.DeletePizza(SelectedPizza);
                _stonkspizzaDatabase.DeleteIngedientsByPizza(selectedPizza);
                LoadPizzas();
                LoadIngredients();
                ResetBindingsAndInput();
            }
            else
            {
                MessageBox.Show("Geen pizza geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSavePizza_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPizza.Id == null)
            {
                if (
                    !string.IsNullOrWhiteSpace(txbName.Text))
                {
                    BindingExpression beName = this.txbName.GetBindingExpression(TextBox.TextProperty);
                    beName.UpdateSource();
                    _stonkspizzaDatabase.AddPizza(selectedPizza);
                    LoadPizzas();
                    cmbPizzas.SelectedIndex = cmbPizzas.Items.Count - 1;

                    PizzaIngredient pizzaIngredient = new PizzaIngredient()
                    {
                        IngredientId = 1,
                        PizzaId = selectedPizza.Id
                    };
                    _stonkspizzaDatabase.AddPizzaIngredient(pizzaIngredient);
                    LoadPizzaIngredients();
                    
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
                    _stonkspizzaDatabase.UpdatePizza(selectedPizza);
                }
                if (string.IsNullOrWhiteSpace(txbName.Text))
                {
                    MessageBox.Show("Naam niet ingevoerd", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedIngredientToAdd != null && SelectedPizza != null)
            {
                if (!AssociatedPizzaIngredients.Any(Ingredient => Ingredient.IngredientId == SelectedIngredientToAdd.Id))
                {
                    PizzaIngredient pizzaIngredient = new PizzaIngredient()
                    {
                        IngredientId = SelectedIngredientToAdd.Id,
                        PizzaId = SelectedPizza.Id
                    };
                    _stonkspizzaDatabase.AddPizzaIngredient(pizzaIngredient);
                    LoadPizzaIngredients();
                }
                else
                {
                    MessageBox.Show("Pizza heeft het ingrediënt " + SelectedIngredientToAdd.Name + " al!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void LbAssociatedIngredients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (selectedIngredientToDelete != null)
            {
                if (selectedIngredientToDelete.IngredientId == 1)
                {
                    MessageBox.Show("Bodemdeeg mag niet verwijderd worden als ingrediënt!");
                }
                else
                {
                    _stonkspizzaDatabase.DeletePizzaIngredient(SelectedIngredientToDelete);
                    LoadPizzaIngredients();
                }
            }
        }

        
        private void btnUploadPizzaImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            op.Title = "Selecteer een pizza";
            op.Filter = "All supported graphics|.png|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string appPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + @"\assets\";
                string appPathLaravel = @"C:\wamp64\www\Project4-Laravel\public\images\";
                var fileNameToSave = "pizza" + selectedPizza.Id.ToString() + System.IO.Path.GetExtension(op.SafeFileName);
                var imagePath = System.IO.Path.Combine(appPath + fileNameToSave);
                var imagePathLaravel = System.IO.Path.Combine(appPathLaravel + fileNameToSave);


                if (!Directory.Exists(appPath))
                {
                    Directory.CreateDirectory(appPath);
                }
                try
                {
                    File.Copy(op.FileName, imagePath, true);
                    File.Copy(op.FileName, imagePathLaravel, true);
                }
                catch
                {
                    //Voor in de toekomst: Een afbeelding kan via deze catch ook gewijzigd worden.
                    MessageBox.Show("Deze pizza heeft al een afbeelding.");
                }
                Imagesource.Source = new BitmapImage(new Uri(imagePath));

            }
        }
    }
}
