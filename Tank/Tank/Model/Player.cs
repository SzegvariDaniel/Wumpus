using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank.Model
{
    enum Direction { NONE, UP, RIGHT, DOWN, LEFT }

    class Player
    {
        public Int32 Health { get; set; }
        public Direction Direction { get; set; }
        public Int32 Ammo { get; set; }
    }
}
