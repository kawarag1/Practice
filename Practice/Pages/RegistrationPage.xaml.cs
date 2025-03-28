using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Passenger newpass = new Passenger();
                newpass.Name = namebox.Text;
                newpass.Surname = surnamebox.Text;
                if (patronymicbox != null)
                {
                    newpass.Patronymic = patronymicbox.Text;
                }
                else newpass.Patronymic = null;
                newpass.Login = loginbox.Text;
                newpass.Password = pwdbox.Password;
                if (DateOnly.TryParseExact(birthdatebox.Text, "yyyy-MM-dd",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
                {
                    newpass.Birthdate = date;
                }
                newpass.PassportId = Convert.ToInt64(passportbox.Text);
                PassengerService.Registration(newpass);
                UserHelper.passenger = newpass;
                NavigationService.Navigate(new PassengerMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void passportbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (passportbox.Text.Length > 10)
            {
                MessageBox.Show("Неверный формат данных. Пожалуйста, попробуйте снова");
                passportbox.Clear();
            }
        }
    }
}
