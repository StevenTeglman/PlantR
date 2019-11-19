using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantRWPF.ViewModels
{
    
    public class MyPlantsModel : ViewModelBase
    {
        public MainModel Mm { get; set; }

        public ICommand CreateCommand { get; set; }

        public MyPlantsModel()
        {
        }

        public void PlantCreateSwitch()
        {
            Mm.CurrentView = new PlantCreateModel();
        }
    }
}