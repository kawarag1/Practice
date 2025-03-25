using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practice.Pages;

namespace Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<Uri> navigationHistory = new Stack<Uri>();
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigated += FrmMain_Navigated;
            FrmMain.Navigate(new Uri("Pages/Auth.xaml", UriKind.Relative));
        }

        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {
            if (FrmMain.Content is PassengerMain || FrmMain.Content is StaffMain)
            {
                btnBack.Visibility = Visibility.Hidden;
            }
            else if (FrmMain.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //if (FrmMain.NavigationService.CanGoBack)
            //{
            //    if (navigationHistory.Count > 1)
            //    {
            //        navigationHistory.Pop();
            //        UriKind.Relative
            //    }
            //}
            FrmMain.GoBack();
        }

        private void FrmMain_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Uri != null)
            {
                navigationHistory.Push(e.Uri);
            }
        }
    }
}