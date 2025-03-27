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
    /// Логика взаимодействия для Purchase.xaml
    /// </summary>
    public partial class Purchase : Window
    {
        Trip selectedTrip;
        public Purchase(Trip trip)
        {
            InitializeComponent();
            selectedTrip = trip;
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                string route = $"{selectedTrip.RouteNavigation.StartCity} - {selectedTrip.RouteNavigation.EndCity}";
                RouteBox.Text = route;
                var passenger = UserHelper.passenger;

                NameBox.Text = passenger.Name;
                SurnameBox.Text = passenger.Surname;
                PatronymicBox.Text = passenger.Patronymic;
                PassportBox.Text = passenger.PassportId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void PurchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var passenger = UserHelper.passenger;
                Ticket newTicket = new Ticket();
                newTicket.PassengerId = passenger.Id;
                newTicket.TripId = selectedTrip.Id;
                newTicket.SeatNumber = SeatNumber.Text;
                newTicket.Cost = 300;
                if (Baggage.IsChecked == false)
                {
                    newTicket.Baggage = false;
                }
                else
                {
                    newTicket.Baggage = true;
                }
                TicketService.CreateTicket(newTicket);
                MessageBox.Show("Успешно!");
                Close();
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
