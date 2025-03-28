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
        Trip trip;
        public ChangeTripWindow(Trip _trip)
        {
            InitializeComponent();
            trip = _trip;
            LoadData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            BusList.SelectedItem = trip.BusId;
            RouteList.SelectedItem = trip.Route;
            DriverList.SelectedItem = trip.Driver;
            StartDateList.SelectedItem = trip.DatetimeStart;
            EndDateList.SelectedItem = trip.DatetimeEnd;

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
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
