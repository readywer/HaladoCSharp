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

namespace Person_Database.Pages
{
    /// <summary>
    /// Interaction logic for DataSearchPage.xaml
    /// </summary>
    public partial class DataSearchPage : Page
    {
        public DataSearchPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = DataManager.FindRows(tbKeres.Text);
            CollectionViewSource.GetDefaultView(myDataGrid3.ItemsSource).Refresh();
        }
    }
}
