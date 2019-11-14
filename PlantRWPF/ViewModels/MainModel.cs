using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantRWPF.ViewModels
{
    public class MainModel : ViewModelBase
    {
        
        public ICommand MyPlantsCommand { get; }


        public ICommand PlantCreateCommand { get; }
    }

}
