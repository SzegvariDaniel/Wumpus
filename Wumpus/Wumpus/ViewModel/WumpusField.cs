using ELTE.Windows.ColorGrid.ViewModel;
using System;

namespace Wumpus.ViewModel
{
    internal class WumpusField : ViewModelBase
    {
        private String _baseColor;

        private String _batsImage;
        private String _pitImage;
        private String _wumpusImage;
        private String _treasureImage;
        private String _playerImage;
        
        private String _smellImage;
        private String _windImage;
        private String _soundImage;

        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }


        public string BaseColor { get { return _baseColor; } set { _baseColor = value; OnPropertyChanged(); } }

        public string BatsImage { get { return _batsImage; } set { _batsImage = value; OnPropertyChanged(); } }

        public string PitImage { get { return _pitImage; } set { _pitImage = value; OnPropertyChanged(); } }

        public string WumpusImage { get { return _wumpusImage; } set { _wumpusImage = value; OnPropertyChanged(); } }

        public string TreasureImage { get { return _treasureImage; } set { _treasureImage = value; OnPropertyChanged(); } }

        public string PlayerImage { get { return _playerImage; } set { _playerImage = value; OnPropertyChanged(); } }

        public String SmellImage { get { return _smellImage; } set { _smellImage = value; OnPropertyChanged(); } }

        public String WindImage { get { return _windImage; } set { _windImage = value; OnPropertyChanged(); } }

        public String SoundImage { get { return _soundImage; } set { _soundImage = value; OnPropertyChanged(); } }

        public DelegateCommand ButtonClickCommand { get; set; }
    }
}