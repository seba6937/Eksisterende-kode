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
            Close();
        }

        private void OpretFejl_Click(object sender, RoutedEventArgs e)
        {
            Windows.OpretFejlmelding opretFejlmelding = new Windows.OpretFejlmelding();
            opretFejlmelding.Show();
            Close();
        }

        private void ÆndreFejl_Click(object sender, RoutedEventArgs e)
        {
            Windows.StatusChange SC = new Windows.StatusChange();
            SC.Show();
            Close();
        }

        private void VisGamleRapporter_Click(object sender, RoutedEventArgs e)
        {
            Windows.Gamle_Rapporter gamle = new Windows.Gamle_Rapporter();
            gamle.Show();
            Close();
        }

        private void RapporterEkstraInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SletFejl_Click(object sender, RoutedEventArgs e)
        {
            Windows.SletFejlmelding sletFejlmelding = new Windows.SletFejlmelding();
            sletFejlmelding.Show();
            Close();
        }
    }
}
