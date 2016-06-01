using ELTE.Windows.ColorGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tank.Model;

namespace Tank.ViewModel
{
    class TankField : ViewModelBase
    {
        private String _tank;
        private Wall _wall;
        private Direction _direction;

        public String Tank { get { return _tank; } set { _tank = value; OnPropertyChanged(); } }
        public Wall Wall { get { return _wall; } set { _wall = value; OnPropertyChanged(); } }
        public Direction Direction { get { return _direction; } set { _direction = value; OnPropertyChanged(); } }
    }
}
