using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PlantRWPF;
using PlantRProxy;
using PlantRWPF.ViewModels;
using PlantRServ.Model;

namespace PlantRWPF.Views
{

    /// <summary>
    /// Interaction logic for MyPlants.xaml
    /// </summary>
    public partial class Plants : UserControl
    {
        public PlantRClient service = new PlantRClient();

        public Plants()
        {
            InitializeComponent();
            ListPlants();

        }

        public void ListPlants()
        {
            var plantList = service.GetAllPlants();
            plantListGrid.ItemsSource = plantList;
        }



        private void PlusBut_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddPlant addPlant = new Windows.AddPlant(this);
            addPlant.Show();
        }

        private void UpdatePlantBut_Click(object sender, RoutedEventArgs e)
        {
            Plant p = (Plant)plantListGrid.SelectedItem;
            service.UpdatePlant(p.ID, p.CName, p.LName, p.ImageURL, p.Description, p.SDays);
            //refresh
            var plantList = service.GetAllPlants();
            plantListGrid.ItemsSource = plantList;
        }

        private void DeletePlantBut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                Plant p = (Plant)plantListGrid.SelectedItem;
                bool check = service.DeletePlant(p.ID);
                if (check)
                {
                    MessageBox.Show("Plant Removed", "Delete Confirmed", MessageBoxButton.OK);
                }
                //Refresh list
                var plantList = service.GetAllPlants();
                plantListGrid.ItemsSource = plantList;
            }
        }

        

    }
}
