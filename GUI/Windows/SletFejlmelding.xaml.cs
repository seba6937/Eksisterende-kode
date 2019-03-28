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
    /// Interaction logic for SletFejlmelding.xaml
    /// </summary>
    public partial class SletFejlmelding : Window
    {
        public SletFejlmelding()
        {
            InitializeComponent();
        }

        private void SletFejl_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Application.Controller controller = new OBBC_Vedligeholdelse.Application.Controller();

            int id = int.Parse(idDeleteReport.Text);

            controller.DeleteReport(id);
        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
