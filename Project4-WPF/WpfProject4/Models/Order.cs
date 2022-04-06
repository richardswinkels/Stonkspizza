using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfProject4.Models
{
    public class Order
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        public ulong? Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        public ulong CustomerId { get; set; }
        public ulong StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public double Price
        {
            get
            {
                double calculatedprice = 0;
                ObservableCollection<Orderitem> orderitems = _stonkspizzaDatabase.GetOrderitemsByOrder(this);
                foreach (Orderitem orderitem in orderitems)
                {
                    calculatedprice += orderitem.Price;
                }

                return calculatedprice;
            }
        }
        public void StartPreparation()
        {
            Status status = new Status() { Id = 2 };
            _stonkspizzaDatabase.UpdateOrderStatus(this, status);
        }

        public void Bake()
        {
            Status status = new Status() { Id = 3 };
            _stonkspizzaDatabase.UpdateOrderStatus(this, status);
        }

        public void StartDelivery()
        {
            Status status = new Status() { Id = 4 };
            _stonkspizzaDatabase.UpdateOrderStatus(this, status);
        }

        public void ConfirmDelivery()
        {
            Status status = new Status() { Id = 5 };
            _stonkspizzaDatabase.UpdateOrderStatus(this, status);
        }

        public Status GetCurrentStatus()
        {
            return _stonkspizzaDatabase.GetStatusByOrder(this);
        }

        public void Cancel()
        {
            Status status = new Status() { Id = 6 };
            _stonkspizzaDatabase.UpdateOrderStatus(this, status);
        }
    }
}
