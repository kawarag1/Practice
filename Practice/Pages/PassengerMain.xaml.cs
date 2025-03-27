using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice.Models;
using Practice.Services;
using Practice.Windows;

namespace Practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для PassengerMain.xaml
    /// </summary>
    public partial class PassengerMain : Page
    {
        public PassengerMain()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            ViewTrips.ItemsSource = TripService.Trip();
        }

        private void ButBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ViewTrips.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали билет!");
            }
            else
            {
                Trip selectedtrip = (Trip)ViewTrips.SelectedItem;
                Purchase purchase = new Purchase(selectedtrip);
                purchase.ShowDialog();
            }
        }

        private void ViewTrips_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PassengerProfile());
        }
    }
}
