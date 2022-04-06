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
    /// Interaction logic for Besteloverzicht.xaml
    /// </summary>
    public partial class Besteloverzicht : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();
        #region properties
        private Order selectedOrder;
        private Customer associatedCustomer;
        public User authenticatedUser;
        public Status associatedStatus;

        private ObservableCollection<Order> orders;
        private ObservableCollection<Customer> customers;
        private ObservableCollection<Status> statuses;


        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                NotifyPropertyChanged("SelectedOrder");
                LoadAssociatedCustomer();
                LoadAssociatedStatus();
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

        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                NotifyPropertyChanged("Customers");
            }
        }

        public ObservableCollection<Status> Statuses
        {
            get { return statuses; }
            set
            {
                statuses = value;
                NotifyPropertyChanged("Statuses");
            }
        }

        public User AuthenticatedUser
        {
            get { return authenticatedUser; }
            set { authenticatedUser = value; }
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

        public Status AssociatedStatus
        {
            get { return associatedStatus;  }
            set
            {
                associatedStatus = value;
                NotifyPropertyChanged("AssociatedStatus");
            }
        }
        #endregion
        public Besteloverzicht(User authenticatedUser)
        {
            InitializeComponent();
            DataContext = this;
            LoadOrders();
            LoadStatuses();
            LoadCustomers();
            this.AuthenticatedUser = authenticatedUser;
        }
        private void LoadOrders()
        {
            Orders = _stonkspizzaDatabase.GetAllOrders();
        }
        private void LoadStatuses()
        {
            Statuses = _stonkspizzaDatabase.GetAllStatuses();
        }
        private void LoadCustomers()
        {
            Customers = _stonkspizzaDatabase.GetAllCustomers();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }

        private void BtnCancelOrder_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOrder == null)
            {
                MessageBox.Show("Geen bestelling geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SelectedOrder.Cancel();
                AssociatedCustomer.RevokePizzaPoints();
                AddOrdertransaction(6);
                LoadOrders();
                MessageBox.Show("Succesvol geannuleerd!", "Melding", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void LoadAssociatedCustomer()
        {
            if (SelectedOrder != null)
            {
                AssociatedCustomer = _stonkspizzaDatabase.GetCustomerByOrder(SelectedOrder);
            }
        }

        private void LoadAssociatedStatus()
        {
            if(SelectedOrder != null)
            {
                AssociatedStatus = _stonkspizzaDatabase.GetStatusByOrder(SelectedOrder);
            }
        }

        private void BtnShowOrder_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedOrder != null)
            {
                PrepareOrder prepareOrder = new PrepareOrder(SelectedOrder, AuthenticatedUser);
                prepareOrder.ShowDialog();
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Geen bestelling geselecteerd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddOrdertransaction(ulong statusId)
        {
            Ordertransaction ordertransaction = new Ordertransaction()
            {
                OrderId = (ulong)SelectedOrder.Id,
                UserId = AuthenticatedUser.Id,
                StatusId = statusId,
            };
            _stonkspizzaDatabase.AddOrdertransaction(ordertransaction);
        }
    }

}
