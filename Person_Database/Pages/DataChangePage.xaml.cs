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

namespace Person_Database
{
    /// <summary>
    /// Interaction logic for DataChangePage.xaml
    /// </summary>
    public partial class DataChangePage : Page
    {
        public DataChangePage()
        {
            InitializeComponent();
            DataContext = DataManager.Data;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                int selectedIndex = dataGrid.SelectedIndex;
                // A selectedIndex változóban megtalálod a kiválasztott sor indexét
                Console.WriteLine($"Kiválasztott sor indexe: {selectedIndex}");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Adatok tárolása egy string tömbben
            string[] adatok =
            [
                tbNev.Text,
                tbSzuletesiHely.Text,
                tbSzuletesiIdo.Text,
                cbNem.Text,
                tbDiakigazolvany.Text,
            ];
            if ((DataManager.CheckData(adatok)))
            {
                DataManager.AddData(adatok);
                DataManager.WriteToFile();
                MessageBox.Show($"Adatok mentve.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);

                tbNev.Text = "";
                tbSzuletesiHely.Text = "";
                tbSzuletesiIdo.Text = "";
                cbNem.Text = "";
                tbDiakigazolvany.Text = "";
            }

        }
    }
}
