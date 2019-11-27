using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantRWPF.ViewModels
{
    
    public class PlantsModel : ViewModelBase
    {
        public MainModel Mm { get; set; }

        public ICommand CreateCommand { get; set; }

        public PlantsModel()
        {
        }

        public void PlantCreateSwitch()
        {
            Mm.CurrentView = new PlantCreateModel();
        }
    }
}