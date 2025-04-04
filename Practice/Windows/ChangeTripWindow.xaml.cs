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
    /// Логика взаимодействия для ChangeTripWindow.xaml
    /// </summary>
    public partial class ChangeTripWindow : Window
    {
        Trip? trip_;
        public ChangeTripWindow(Trip _trip)
        {
            InitializeComponent();
            trip_ = _trip;
            LoadAllData();
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            Trip? trip = TripService.TripWhere(trip_);
            BusList.SelectedItem = BusList.Items.Cast<Trip>().FirstOrDefault(x => x.BusId == trip.BusId);
            RouteList.SelectedItem = RouteList.Items.Cast<Trip>().FirstOrDefault(x => x.Route == trip.Route);
            DriverList.SelectedItem = DriverList.Items.Cast<Trip>().FirstOrDefault(x => x.DriverId == trip.DriverId);
            StartDateList.SelectedItem = StartDateList.Items.Cast<Trip>().FirstOrDefault(x => x.DatetimeStart == trip.DatetimeStart);
            EndDateList.SelectedItem = EndDateList.Items.Cast<Trip>().FirstOrDefault(x => x.DatetimeEnd == trip.DatetimeEnd);

        }
        private void LoadAllData()
        {
            DriverList.ItemsSource = TripService.Trip();
            RouteList.ItemsSource = TripService.Trip();
            StartDateList.ItemsSource = TripService.Trip();
            EndDateList.ItemsSource = TripService.Trip();
            BusList.ItemsSource = TripService.Trip();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
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
                TripService.UpdateTrip(trip);
                MessageBox.Show("Успешно!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
