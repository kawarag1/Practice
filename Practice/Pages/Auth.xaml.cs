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
using Practice.Models;
using Practice.Services;

namespace Practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pass = PassengerService.Authorization(loginbox.Text, pwdbox.Password);
                var staff = EmployeeService.Authorization(loginbox.Text, pwdbox.Password);
                if (pass == null && staff == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else if (pass != null)
                {
                    NavigationService.Navigate(new PassengerMain(pass));
                }
                else
                {
                    NavigationService.Navigate(new StaffMain());
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Reg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
