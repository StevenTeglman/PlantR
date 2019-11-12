using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantRWPF.ViewModels
{
    class MainModel : ViewModelBase
    {
        public ViewModelBase CurrentView
        {
            get { return CurrentView; }
            set { CurrentView = value; this.OnPropertyChanged(); }
        }
        
        public ICommand MyPlantsCommand { get; }
        public ICommand PlantCreateCommand { get; }
    }

}
