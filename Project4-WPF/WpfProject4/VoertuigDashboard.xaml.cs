using System;
using System.Collections.Generic;
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

namespace WpfProject4
{
    /// <summary>
    /// Interaction logic for Voergtuig.xaml
    /// </summary>
    public partial class VoertuigDashboard : Window
    {
        public VoertuigDashboard()
        {
            InitializeComponent();
        }

        private void btnFietsmerkenbeheer_Click(object sender, RoutedEventArgs e)
        {
            Voertuig_merk voertuig = new Voertuig_merk();
            voertuig.ShowDialog();
        }

        private void btnFietsmodellenbeheer_Click(object sender, RoutedEventArgs e)
        {
            Voertuig_model voertuig = new Voertuig_model();
            voertuig.ShowDialog();

        }

        private void btnFietsenbeheer_Click(object sender, RoutedEventArgs e)
        {
            Voertuig voertuig = new Voertuig();
            voertuig.ShowDialog();
        }
    }
}
