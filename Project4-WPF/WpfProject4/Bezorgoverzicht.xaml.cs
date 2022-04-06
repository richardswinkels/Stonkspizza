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
    /// Interaction logic for Bezorgoverzicht.xaml
    /// </summary>
    public partial class Bezorgoverzicht : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();
        #region properties
        private Order selectedOrder;
        private Customer associatedCustomer;
        private User authenticatedUser;

        private ObservableCollection<Order> orders;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                NotifyPropertyChanged("SelectedOrder");
                LoadAssociatedCustomer();
            }
        }

        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                NotifyPropertyChanged("Orders");
            }
        }

        public Customer AssociatedCustomer
        {
            get { return associatedCustomer; }
            set
            {
                associatedCustomer = value;
                NotifyPropertyChanged("AssociatedCustomer");
            }
        }

        public User AuthenticatedUser
        {
            get { return authenticatedUser; }
            set { authenticatedUser = value; }
        }
        #endregion

        public Bezorgoverzicht(User authenticatedUser)
        {
            InitializeComponent();
            DataContext = this;
            LoadOrders();
            this.AuthenticatedUser = authenticatedUser;
        }

        private void LoadOrders()
        {
            Orders = _stonkspizzaDatabase.GetOrdersToBeDelivered();
        }
        private void LoadAssociatedCustomer()
        {
            if (SelectedOrder != null)
            {
                AssociatedCustomer = _stonkspizzaDatabase.GetCustomerByOrder(SelectedOrder);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void BtnShowOrder_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedOrder != null)
            {
                DeliverOrder deliverOrder = new DeliverOrder(SelectedOrder, AssociatedCustomer, AuthenticatedUser);
                deliverOrder.ShowDialog();
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Geen bestelling geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
