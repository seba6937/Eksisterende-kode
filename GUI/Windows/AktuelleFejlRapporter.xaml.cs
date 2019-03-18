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

namespace GUI.Windows
{
    /// <summary>
    /// Interaction logic for AktuelleFejlRapporter.xaml
    /// </summary>
    public partial class AktuelleFejlRapporter : Window
    {
        public AktuelleFejlRapporter()
        {
            InitializeComponent();
        }

        private void VisAlle_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(1);

            // ...\seba6937\Eksisterende-kode\GUI\DatabaseAccess.txt - could not find file.
            // Gælder for alle metoder.
        }

        private void VisBryst_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(2);
        }

        private void VisRyg_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(3);
        }

        private void VisMave_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(4);
        }

        private void VisSpinning_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(5);
        }

        private void VisBen_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(6);
        }

        private void VisArme_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            control.ShowCurrentReports(7);
        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
