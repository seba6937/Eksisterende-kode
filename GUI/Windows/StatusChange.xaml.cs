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
    /// Interaction logic for StatusChange.xaml
    /// </summary>
    public partial class StatusChange : Window
    {
        OBBC_Vedligeholdelse.Application.Controller con = new OBBC_Vedligeholdelse.Application.Controller();
        public StatusChange()
        {
            InitializeComponent();
        }

        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            bool checkParse = true;
            try
            {
                if (!int.TryParse(IDBox.Text, out int id))
                {
                    MessageBox.Show("Hov hov, ID skal være et heltal!");
                    checkParse = false;
                }
                while(checkParse == true)
                {
                    if (GreenCheck.IsChecked == true)
                    {
                        con.ChangeStatus(1, id);
                    }
                    else if (YellowCheck.IsChecked == true)
                    {
                        con.ChangeStatus(2, id);
                    }
                    else if (RedCheck.IsChecked == true)
                    {
                        con.ChangeStatus(3, id);
                    }
                    MessageBox.Show(string.Format("Status er blevet ændret for rapporten med ID: {0}", id));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der skete en fejl " + ex.Message);
            }
        }

        private void Tilbage_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
    }
}
