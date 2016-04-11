using System;

namespace Wumpus.ViewModel
{
    internal class WumpusField
    {
        private String _baseImage;
        private String _batsImage;
        private String _pitImage;
        private String _wumpusImage;
        private String _playerImage;

        public string BaseImage { get { return _baseImage; } set { _baseImage = value; } }

        public string BatsImage { get { return _batsImage; } set { _batsImage = value; } }

        public string PitImage { get { return _pitImage; } set { _pitImage = value; } }

        public string WumpusImage { get { return _wumpusImage; } set { _wumpusImage = value; } }

        public string PlayerImage { get { return _playerImage; } set { _playerImage = value; } }
    }
}