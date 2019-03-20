using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
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
        OBBC_Vedligeholdelse.Controller control = new OBBC_Vedligeholdelse.Controller();
        public AktuelleFejlRapporter()
        {
            InitializeComponent();
            //BreakListDownAndAddToListview(1);
        }

        private void VisAlle_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(1);
        }

        private void VisBryst_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(2);
        }

        private void VisRyg_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(3);
        }

        private void VisMave_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(4);
        }

        private void VisSpinning_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(5);
        }

        private void VisBen_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(6);
        }

        private void VisArme_Click(object sender, RoutedEventArgs e)
        {
            BreakListDownAndAddToListview(7);
        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        public void BreakListDownAndAddToListview(int reportarea)
        {
            List<string> list = control.ShowCurrentReports(reportarea);
            foreach (string item in list)
            {
                string[] arr = item.Split('/');
                ReportView.Items.Add(new Items
                {
                    RapId = arr[0],
                    Location = arr[1],
                    ProblemDesc = arr[2],
                    Time = arr[3],
                    ExtraInf = arr[4],
                    Status = arr[5]
                });
            }
        }
        public class Items
        {
            public string RapId { get; set; }
            public string Location { get; set; }
            public string ProblemDesc { get; set; }
            public string Time { get; set; }
            public string ExtraInf { get; set; }
            public string Status { get; set; }
        }
    }
}
