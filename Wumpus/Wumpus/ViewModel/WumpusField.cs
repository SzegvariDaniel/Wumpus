﻿using ELTE.Windows.ColorGrid.ViewModel;
using System;

namespace Wumpus.ViewModel
{
    internal class WumpusField : ViewModelBase
    {
        private String _baseImage;
        private String _batsImage;
        private String _pitImage;
        private String _wumpusImage;
        private String _treasureImage;
        private String _playerImage;
        private String _content;

        public int X { get; set; }
        public int Y { get; set; }
        public int Number { get; set; }

        public String Content { get { return _content; } set { _content = value; OnPropertyChanged(); } }

        public string BaseImage { get { return _baseImage; } set { _baseImage = value; OnPropertyChanged(); } }

        public string BatsImage { get { return _batsImage; } set { _batsImage = value; OnPropertyChanged(); } }

        public string PitImage { get { return _pitImage; } set { _pitImage = value; OnPropertyChanged(); } }

        public string WumpusImage { get { return _wumpusImage; } set { _wumpusImage = value; OnPropertyChanged(); } }

        public string TreasureImage { get { return _treasureImage; } set { _treasureImage = value; OnPropertyChanged(); } }

        public string PlayerImage { get { return _playerImage; } set { _playerImage = value; OnPropertyChanged(); } }

        public DelegateCommand ButtonClickCommand { get; set; }
    }
}