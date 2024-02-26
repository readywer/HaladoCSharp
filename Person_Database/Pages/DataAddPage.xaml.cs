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
    /// Interaction logic for DataAddPage.xaml
    /// </summary>
    public partial class DataAddPage : Page
    {
        public DataAddPage()
        {
            InitializeComponent();
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
