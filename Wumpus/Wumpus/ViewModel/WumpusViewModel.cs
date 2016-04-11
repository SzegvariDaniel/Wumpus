using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumpus.Model;

namespace Wumpus.ViewModel
{
    class WumpusViewModel
    {
        private WumpusModel _model;

        public WumpusViewModel(WumpusModel model)
        {
            _model = model;
        }
    }
}
