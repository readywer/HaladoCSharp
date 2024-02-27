using Person_Database.Pages;
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

            mainFrame.Content = new HomePage();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new HomePage();
        }

        private void DataAddButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new DataAddPage();
        }

        private void DataChangeButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new DataChangePage();
        }

        private void DataDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new DataDeletePage();

        }

        private void DataSearchButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = new DataSearchPage();
        }
    }
}