using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus.Model
{
    class WumpusModel
    {
        private WumpusTable _table;

        public WumpusTable Table { get; set; }

        public WumpusModel()
        {
            _table = new WumpusTable();
        }
    }
}
