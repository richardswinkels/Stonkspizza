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
    /// Interaction logic for Transactieoverzicht.xaml
    /// </summary>
    public partial class Transactieoverzicht : Window, INotifyPropertyChanged
    {
        StonkspizzaDatabase _stonkspizzaDatabase = new StonkspizzaDatabase();

        private ObservableCollection<Ordertransaction> ordertransactions;

        public ObservableCollection<Ordertransaction> Ordertransactions
        {
            get { return ordertransactions; }
            set { ordertransactions = value;
                NotifyPropertyChanged();
            }
        }
        public Transactieoverzicht()
        {
            InitializeComponent();
            DataContext = this;
            LoadOrdertransactions();

        }

        private void LoadOrdertransactions()
        {
            Ordertransactions = _stonkspizzaDatabase.GetAllOrdertransactions();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string Property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Property));
        }
    }
}
