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
using PlantRWPF.PlantRRef;


namespace PlantRWPF.Views
{
    /// <summary>
    /// Interaction logic for PlantCreate.xaml
    /// </summary>
    public partial class PlantCreate : UserControl
    {
        public PlantRRef.Service1Client service = null;

        public PlantCreate()
        {
            InitializeComponent();
            service = new Service1Client();
            service.Open();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePPlant();
        }
        private Plant PlantSearchReturn()
        {


            return null;
        }
        private void CreatePPlant()
        {
            service.AddPersonalPlant(int.Parse(planttxt.Text), 99, int.Parse(watertxt.Text), nNametxt.Text);
        }
    }
}
