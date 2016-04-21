using System;

namespace Wumpus.Model
{
    public class Player
    {
        public Int32 Arrows { get; set; }
        public Position Position { get; set; }

        public Player(Position position, Int32 arrows = 6)
        {
            Position = position;
            Arrows = arrows;
        }
    }
}