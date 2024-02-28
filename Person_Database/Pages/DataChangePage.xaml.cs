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
        private int? selectedIndex = null;
        public DataChangePage()
        {
            InitializeComponent();
            DataContext = DataManager.Data;

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                if (dataGrid != null)
                {
                    selectedIndex = dataGrid.SelectedIndex;
                    if (selectedIndex != -1)
                    {
                        tbNev.Text = DataManager.Data[(int)selectedIndex][0];
                        tbSzuletesiHely.Text = DataManager.Data[(int)selectedIndex][1];
                        tbSzuletesiIdo.Text = DataManager.Data[(int)selectedIndex][2];
                        cbNem.Text = DataManager.Data[(int)selectedIndex][3];
                        tbDiakigazolvany.Text = DataManager.Data[(int)selectedIndex][4];
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Adatok tárolása egy string tömbben
            string[] adatok =
            {
                tbNev.Text,
                tbSzuletesiHely.Text,
                tbSzuletesiIdo.Text,
                cbNem.Text,
                tbDiakigazolvany.Text,
            };

            if (DataManager.CheckData(adatok))
            {
                if (selectedIndex != null)
                {
                    DataManager.ReplaceData((int)selectedIndex, adatok);
                    DataManager.WriteToFile();
                    MessageBox.Show($"Adatok megváltoztatva.", "Change", MessageBoxButton.OK, MessageBoxImage.Information);

                    tbNev.Text = "";
                    tbSzuletesiHely.Text = "";
                    tbSzuletesiIdo.Text = "";
                    cbNem.Text = "";
                    tbDiakigazolvany.Text = "";
                    selectedIndex = null;
                    myDataGrid.SelectedItem = null;
                    CollectionViewSource.GetDefaultView(myDataGrid.ItemsSource).Refresh();
                }
                else
                {
                    MessageBox.Show($"Válassza ki a változtatandó elemet.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
