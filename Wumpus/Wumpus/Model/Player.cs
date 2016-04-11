using System;

namespace Wumpus.Model
{
    public class Player
    {
        public Int32 Arrows { get; set; }

        public Player(Int32 arrows = 6)
        {
            Arrows = arrows;
        }
    }
}