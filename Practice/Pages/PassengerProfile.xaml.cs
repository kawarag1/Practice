﻿using System;
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
using Practice.Models;
using Practice.Services;

namespace Practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для PassengerProfile.xaml
    /// </summary>
    public partial class PassengerProfile : Page
    {
        public PassengerProfile()
        {
            InitializeComponent();
            LoadData();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckTickets_Click(object sender, RoutedEventArgs e)
        {
            PassengerTickets.Visibility = Visibility.Visible;
            PassengerTickets.ItemsSource = UserHelper.passenger.Tickets.ToList();
        }

        private void LoadData()
        {
            try
            {
                var passenger = UserHelper.passenger;
                NameBox.Text = passenger.Name;
                SurnameBox.Text = passenger.Surname;
                PatronymicBox.Text = passenger.Patronymic;
                PassportBox.Text = passenger.PassportId.ToString();
                LoginBox.Text = passenger.Login;
                PasswordUserBox.Password = passenger.Password;
                VisiblePassword.Text = passenger.Password;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UpdateProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PassengerService.UpdateProfile(UserHelper.passenger);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void CheckPassword_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordUserBox.Visibility == Visibility.Visible)
            {
                PasswordUserBox.Visibility = Visibility.Collapsed;
                VisiblePassword.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordUserBox.Visibility = Visibility.Visible;
                VisiblePassword.Visibility = Visibility.Collapsed;
            }
        }
    }
}
