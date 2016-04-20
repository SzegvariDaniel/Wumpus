namespace Wumpus.Model
{
    internal class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Position))
                return false;

            Position other = (Position)obj;

            return X.Equals(other.X) && Y.Equals(other.Y);
        }
    }
}