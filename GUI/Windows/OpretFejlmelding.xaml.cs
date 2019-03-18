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
    /// Interaction logic for OpretFejlmelding.xaml
    /// </summary>
    public partial class OpretFejlmelding : Window
    {
        public OpretFejlmelding()
        {
            InitializeComponent();
        }

        private void TilføjFejl_Click(object sender, RoutedEventArgs e)
        {
            OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
            int areaId = Convert.ToInt32(this.AreaId);
            string errorMessage = ErrorMessageBox.Text;
            string date = DateBox.Text;
            string extraInfo = null; // ??


            control.CreateNewReport(areaId,errorMessage,date, extraInfo);
        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
