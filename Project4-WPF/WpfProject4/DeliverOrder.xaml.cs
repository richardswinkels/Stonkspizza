using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DeliverOrder.xaml
    /// </summary>
    public partial class DeliverOrder : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        private Order order;
        private Customer customer;
        private User authenticatedUser;

        private ObservableCollection<Orderitem> orderitems;

        public Order Order
        {
            get { return order; }
            set { order = value;
                NotifyPropertyChanged("Order");
            }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public User AuthenticatedUser
        {
            get { return authenticatedUser;  }
            set { authenticatedUser = value; }
        }

        public ObservableCollection<Orderitem> Orderitems
        {
            get { return orderitems; }
            set
            {
                orderitems = value;
                NotifyPropertyChanged("Orderitems");
            }
        }

        public DeliverOrder(Order order, Customer customer, User authenticatedUser)
        {
            InitializeComponent();
            DataContext = this;
            this.Order = order;
            this.Customer = customer;
            this.AuthenticatedUser = authenticatedUser;
            LoadOrderitems();
        }

        private void LoadOrderitems()
        {
            Orderitems = _stonkspizzaDatabase.GetOrderitemsByOrder(Order);
        }

        private void BtnDeliverOrderStart_Click(object sender, RoutedEventArgs e)
        {
            Order.StartDelivery();
            AddOrdertransaction(4);
            //Voer automatisch uit op de achtergrond na 15 minuten wachten
            Task.Delay(TimeSpan.FromMinutes(15)).ContinueWith(t =>
            {
                Status status = Order.GetCurrentStatus();
                if (status.Id != 6)
                {
                    Order.ConfirmDelivery();
                    AddOrdertransaction(5);
                }
            });
            btnDeliverOrderStart.Visibility = Visibility.Hidden;
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
