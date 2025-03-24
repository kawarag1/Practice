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
            using (PracticeContext context = new PracticeContext()) 
            {
                string login = loginbox.Text;
                string password = pwdbox.Password.ToString();
                var user = context.Passengers.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                var staff = context.Employees.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                if (user == null && staff == null)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else if (user != null)
                {
                    NavigationService.Navigate(new PassengerMain());
                }
                else
                {
                    NavigationService.Navigate(new StaffMain());
                }
            }
        }

        private void Reg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
