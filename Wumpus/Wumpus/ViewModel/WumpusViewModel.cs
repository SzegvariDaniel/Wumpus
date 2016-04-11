using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumpus.Model;

namespace Wumpus.ViewModel
{
    class WumpusViewModel
    {
        private WumpusModel _model;

        public ObservableCollection<WumpusField> Fields { get; set; }

        public WumpusViewModel(WumpusModel model)
        {
            _model = model;
        }

        public void NewGame(GameSettings settings)
        {

        }
    }
}
