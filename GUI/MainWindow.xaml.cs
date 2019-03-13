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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AktuelleFejlRapporter_Click(object sender, RoutedEventArgs e)
        {
            Windows.AktuelleFejlRapporter window = new Windows.AktuelleFejlRapporter();
            window.Show();
            this.Close();
        }

        private void OpretFejl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ÆndreFejl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VisGamleRapporter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RapporterEkstraInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
