using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Services;
using Practice.Windows;

namespace Practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для StaffMain.xaml
    /// </summary>
    public partial class StaffMain : Page
    {
        Trip trip;
        public StaffMain()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            ViewTrips.ItemsSource = TripService.Trip();
        }

        private void ButBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ViewTrips.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали рейс!");
                }
                else
                {
                    Trip selectedtrip = (Trip)ViewTrips.SelectedItem;
                    TripService.DeleteTrip(selectedtrip);
                    MessageBox.Show("Успешно!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateTrip_Click(object sender, RoutedEventArgs e)
        {
            CreateTripWindow window = new CreateTripWindow();
            window.ShowDialog();
        }

        private void ChangeTrip_Click(object sender, RoutedEventArgs e)
        {
            if (ViewTrips.SelectedItem == null)
            {
                MessageBox.Show("Выберите рейс для изменения!");
            }
            else
            {
                Trip selected_trip = (Trip)ViewTrips.SelectedItem;
                ChangeTripWindow window = new ChangeTripWindow((Trip)ViewTrips.SelectedItem);
                window.ShowDialog();
            }
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            UserHelper.passenger = null;
            NavigationService.GoBack();
        }
    }
}
