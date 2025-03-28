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
using Practice.Models;
using Practice.Services;

namespace Practice.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateTripWindow.xaml
    /// </summary>
    public partial class CreateTripWindow : Window
    {
        public CreateTripWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DriverList.ItemsSource = TripService.Trip();
            RouteList.ItemsSource = TripService.Trip();
            StartDateList.ItemsSource = TripService.Trip();
            EndDateList.ItemsSource = TripService.Trip();
            BusList.ItemsSource = TripService.Trip();
        }

        

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Trip trip = new Trip();
                var RouteID = (Trip)RouteList.SelectedItem;
                trip.Route = RouteID.RouteNavigation.Id;
                var Driver = (Trip)DriverList.SelectedItem;
                trip.DriverId = Driver.DriverId;
                trip.StatusId = 1;
                var Bus = (Trip)BusList.SelectedItem;
                trip.BusId = Bus.BusId;
                var DateTimeStart = (Trip)StartDateList.SelectedItem;
                trip.DatetimeStart = DateTimeStart.DatetimeStart;
                var DateTimeEnd = (Trip)EndDateList.SelectedItem;
                trip.DatetimeEnd = DateTimeEnd.DatetimeEnd;
                TripService.CreateTrip(trip);
                MessageBox.Show("Успешно!");
                Close();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
