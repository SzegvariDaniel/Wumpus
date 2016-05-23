using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wumpus.Model
{
    class WumpusEventArgs : EventArgs
    {
        public Position OldPosition { get; set; }
        public Position NewPosition { get; set; }
        public Position WindPosition { get; set; }
        public Position SmellPosition { get; set; }
        public Position SoundPosition { get; set; }
        public GameSettings NewGameSettings { get; set; }
    }
}
