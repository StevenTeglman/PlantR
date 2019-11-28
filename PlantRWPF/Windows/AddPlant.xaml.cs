using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlantRProxy;
using PlantRWPF.Views;

namespace PlantRWPF.Windows
{
    /// <summary>
    /// Interaction logic for AddPlant.xaml
    /// </summary>
    public partial class AddPlant : Window
    {
        public PlantRClient service = new PlantRClient();
        private Plants p;
        public AddPlant(Plants p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void buttAddPlant_Click(object sender, RoutedEventArgs e)
        {
            if (tbcname.Text != "" && tblname.Text != "" && tbimgurl.Text != "" && tbdesc.Text != "" && tbsdays.Text != "")
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Addition Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    int check = service.AddPlant(tbcname.Text, tblname.Text, tbimgurl.Text, tbdesc.Text, int.Parse(tbsdays.Text));
                    if (check != 0)
                    {
                        MessageBox.Show("Plant Added", "Addition Confirmed", MessageBoxButton.OK);
                    }
                    //Refresh list
                    var plantList = service.GetAllPlants();
                }
                this.Close();
                p.ListPlants();
            }
            else
            {
                MessageBoxResult msgBox = MessageBox.Show("Please fill out every information", "Missing information", MessageBoxButton.OK);
            }
            
        }

        private void buttCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
