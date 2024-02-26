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

namespace Person_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //mainFrame.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
        }
        private void DataAddButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("DataAddPage.xaml", UriKind.Relative));
        }

        private void DataChangeButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("DataChangePage.xaml", UriKind.Relative));
        }

        private void DataDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("DataDeletePage.xaml", UriKind.Relative));
        }

        private void DataSearchButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("DataSearchPage.xaml", UriKind.Relative));
        }
    }
}