using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for PrepareOrder.xaml
    /// </summary>
    public partial class PrepareOrder : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        #region properties
        private Order order;
        private User user;
        private Orderitem selectedOrderitem;
        private User authenticatedUser;

        private ObservableCollection<Orderitem> orderitems;
        private ObservableCollection<IngredientOrderitem> ingredientOrderitems;

        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                ShowPrepareButton();
            }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }


        public Orderitem SelectedOrderitem
        {
            get { return selectedOrderitem; }
            set
            {
                selectedOrderitem = value;
                LoadOrderitemIngredients(this.SelectedOrderitem);
                NotifyPropertyChanged("SelectedOrderitem");
            }
        }

        public User AuthenticatedUser
        {
            get { return authenticatedUser; }
            set { authenticatedUser = value; }
        }

        public ObservableCollection<Orderitem> Orderitems
        {
            get { return orderitems; }
            set
            {
                orderitems = value;
                SelectedOrderitem = Orderitems[0];
                NotifyPropertyChanged("Orderitems");
            }
        }

        public ObservableCollection<IngredientOrderitem> IngredientOrderitems
        {
            get { return ingredientOrderitems; }
            set
            {
                ingredientOrderitems = value;
                NotifyPropertyChanged("IngredientOrderitems");
            }
        }
        #endregion

        public PrepareOrder(Order order, User authenticatedUser)
        {
            InitializeComponent();
            DataContext = this;
            this.Order = order;
            this.AuthenticatedUser = authenticatedUser;
            LoadOrderitems();
            LoadUserByOrder();
        }

        private void LoadOrderitems()
        {
            Orderitems = _stonkspizzaDatabase.GetOrderitemsByOrder(Order);
        }

        private void LoadUserByOrder()
        {
            User = _stonkspizzaDatabase.GetUserByOrder(Order);

        }

        private void LoadOrderitemIngredients(Orderitem orderitem)
        {
            IngredientOrderitems = _stonkspizzaDatabase.GetOrderitemIngredientsByOrderitem(orderitem);
        }

        private void ShowPrepareButton()
        {
            if (Order.StatusId == 1)
            {
                btnPrepareOrderStart.Visibility = Visibility.Visible;
            }
            else if (Order.StatusId == 2)
            {
                btnBakeOrder.Visibility = Visibility.Visible;
            }
        }

        private void UpdateQuantity()
        {
            _stonkspizzaDatabase.SubtractQuantityFromIngredients(IngredientOrderitems);
            LoadOrderitemIngredients(this.SelectedOrderitem);
        }

        private void BtnPrepareOrderStart_Click(object sender, RoutedEventArgs e)
        {
            Order.StartPreparation();
            AddOrdertransaction(2);
            btnPrepareOrderStart.Visibility = Visibility.Hidden;
            btnBakeOrder.Visibility = Visibility.Visible;

            MessageBox.Show("Bereiding is gestart! Klant is op de hoogte gebracht middels een e-mail.", "Melding", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void BtnBakeOrder_Click(object sender, RoutedEventArgs e)
        {
            order.Bake();
            AddOrdertransaction(3);
            btnBakeOrder.Visibility = Visibility.Hidden;
            UpdateQuantity();
            MessageBox.Show("Bestelling wordt gebakken!", "Melding", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void AddOrdertransaction(ulong statusId)
        {
            Ordertransaction ordertransaction = new Ordertransaction()
            {
                OrderId = (ulong)Order.Id,
                UserId = AuthenticatedUser.Id,
                StatusId = statusId,
            };
            _stonkspizzaDatabase.AddOrdertransaction(ordertransaction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
