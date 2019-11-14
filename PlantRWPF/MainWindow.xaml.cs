using PlantRWPF.ViewModels;
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

namespace PlantRWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlantRRef.Service1Client service = null;
        public MainWindow()
        {
            InitializeComponent();
            service = new Service1Client();
            service.Open();
            var mpm = new MyPlantsModel();
            mpm.Mm = (MainModel)DataContext;
            ((MainModel)DataContext).CurrentView = mpm;
            
            


        }


        private void MyPlantBut_Click(object sender, RoutedEventArgs e)
        {
            //DataContext = new MyPlantsModel();
           
        }

        public void PlantCreateSwitch()
        {
            DataContext = new PlantCreateModel();
        }


    }
}
