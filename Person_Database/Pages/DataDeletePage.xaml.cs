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
    /// Interaction logic for DataDeletePage.xaml
    /// </summary>
    public partial class DataDeletePage : Page
    {
        private int? selectedIndex = null;

        public DataDeletePage()
        {
            InitializeComponent();
            DataContext = DataManager.Data;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                selectedIndex = dataGrid.SelectedIndex;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedIndex != null)
            {
                DataManager.RemoveData((int)selectedIndex);
                DataManager.WriteToFile();
                MessageBox.Show($"Adatok megváltoztatva.", "Change", MessageBoxButton.OK, MessageBoxImage.Information);

                selectedIndex = null;
                CollectionViewSource.GetDefaultView(myDataGrid2.ItemsSource).Refresh();
            }
            else
            {
                MessageBox.Show($"Válassza ki a változtatandó elemet.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
