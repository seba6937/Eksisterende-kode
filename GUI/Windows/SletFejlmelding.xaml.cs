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
            OBBC_Vedligeholdelse.Controller controller = new OBBC_Vedligeholdelse.Controller();

            int id = Convert.ToInt32(idDeleteReport);

            controller.DeleteReport(id);
        }
    }
}
