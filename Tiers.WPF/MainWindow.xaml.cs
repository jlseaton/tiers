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
using Tiers.Service;

namespace Tiers.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GetRandomUser();
        }

        private void GetRandomUser()
        {
            try
            {
                var user = new UserService().Get(new Random().Next(5) + 1);
                this.textboxOutput1.Text = "Random user w/sensitive data: " + 
                    String.Format(" ID: {0}, Name: {1}, Data: {2:0.##}", user.ID, user.Name, user.Data.ToString());
            }
            catch (Exception ex)
            {
                this.textboxOutput2.Text = ex.Message;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserWebApiClient client = new UserWebApiClient();
                this.textboxOutput2.Text = client.Get();
                
                GetRandomUser();
            }
            catch (Exception ex)
            {
                this.textboxOutput2.Text = ex.Message;
            }
        }
    }
}
