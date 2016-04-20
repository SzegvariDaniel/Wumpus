using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus.Model
{
    class Node
    {
        public Boolean Pit { get; set; }
        public Boolean Bats { get; set; }
        public Boolean Wumpus { get; set; }
        public Boolean Treasure { get; set; }
        public Player Player { get; set; }

        public Node()
        {
            Pit = Bats = Wumpus = false;
            Player = null;
        }
    }
}
