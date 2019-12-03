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
using PlantRProxy;

namespace PlantRWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PlantRClient service = null;
        public MainWindow()
        {
            InitializeComponent();
            service = new PlantRClient();
            //service.Open();
            var mpm = new PlantsModel();
            mpm.Mm = (MainModel)DataContext;
            ((MainModel)DataContext).CurrentView = mpm;

        }


        private void PlantBut_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PlantsModel();
           
        }

        public void PlantCreateSwitch()
        {
            DataContext = new PlantCreateModel();
        }


    }
}
