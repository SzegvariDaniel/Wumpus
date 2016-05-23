using ELTE.Windows.ColorGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wumpus.Model;

namespace Wumpus.ViewModel
{
    class WumpusViewModel : ViewModelBase
    {
        private WumpusModel _model;
        private WindowSize _windowSize;

        public ObservableCollection<WumpusField> Fields { get; set; }
        public int TableSize { get { return _model.TableSize; } set { _model.TableSize = value; OnPropertyChanged(); } }
        public int Arrows { get { return _model.Player.Arrows; } }
        public WindowSize WindowSize { get { return _windowSize; } set { _windowSize = value; OnPropertyChanged(); } }
        public List<Int32> TableSizeList { get; set; }
        public List<Int32> NumberOfBatsList { get; set; }
        public List<Int32> NumberOfPitsList { get; set; }
        public List<Int32> NumberOfArrowsList { get; set; }
        public DelegateCommand UncoverCommand { get; set; }
        public DelegateCommand UpCommand { get; set; }
        public DelegateCommand DownCommand { get; set; }
        public DelegateCommand LeftCommand { get; set; }
        public DelegateCommand RightCommand { get; set; }
        public DelegateCommand ShootCommand { get; set; }
        public DelegateCommand StepCommand { get; set; }
        public DelegateCommand NewGameOptionsCommand { get; set; }
        public DelegateCommand StartNewGameCommand { get; set; }
        public GameSettings NewGameSettings { get; set; }

        public event EventHandler<EventArgs> NewGameOptions;
        public event EventHandler<WumpusEventArgs> OnStartNewGame;

        public WumpusViewModel(WumpusModel model)
        {
            _model = model;
            _model.OnStep += new EventHandler<WumpusEventArgs>(RefreshTable);
            _model.OnGameWon += new EventHandler<EventArgs>(Uncover);

            UncoverCommand = new DelegateCommand(p => Uncover());

            UpCommand = new DelegateCommand(p => _model.IsGameOn, p => _model.StepUp());
            DownCommand = new DelegateCommand(p => _model.IsGameOn, p => _model.StepDown());
            LeftCommand = new DelegateCommand(p => _model.IsGameOn, p => _model.StepLeft());
            RightCommand = new DelegateCommand(p => _model.IsGameOn, p => _model.StepRight());

            StepCommand = new DelegateCommand(p => _model.IsGameOn, p => _model.Step((String)p));
            ShootCommand = new DelegateCommand(p => _model.IsGameOn, p => { _model.Shoot((String)p); OnPropertyChanged("arrows"); });
            NewGameOptionsCommand = new DelegateCommand(p => ShowNewGameOptions());
            StartNewGameCommand = new DelegateCommand(p => StartNewGame());

            TableSizeList = new List<int> { 4, 5, 6, 7, 8 };
            NumberOfArrowsList = new List<int> { 1, 2, 3, 4, 5, 6 };
            NumberOfBatsList = new List<int> { 3, 4, 5, 6 };
            NumberOfPitsList = new List<int> { 3, 4, 5, 6 };

            NewGameSettings = new GameSettings
            {
                NumberOfArrows = 6,
                NumberOfBats = 3,
                NumberOfPits = 3,
                TableSize = 8
            };
        }

        private void StartNewGame()
        {
            if(OnStartNewGame != null)
                OnStartNewGame(this, new WumpusEventArgs { NewGameSettings = this.NewGameSettings });
        }

        private void ShowNewGameOptions()
        {
            if (NewGameOptions != null)
                NewGameOptions(this, EventArgs.Empty);
        }

        private void GameStop(object sender, EventArgs e)
        {
            /*StepCommand.CanExecute(false);
            StepCommand.CanExecuteChanged()
            ShootCommand.CanExecute(false);*/
        }

        private void RefreshTable(object sender, WumpusEventArgs e)
        {
            if (e.OldPosition != null)
            {
                Fields[e.OldPosition.X * TableSize + e.OldPosition.Y].PlayerImage = "";
                Fields[e.NewPosition.X * TableSize + e.NewPosition.Y].PlayerImage = "player";
                Fields[e.NewPosition.X * TableSize + e.NewPosition.Y].BaseColor = "BurlyWood";
            }

            if (e.WindPosition != null)
                Fields[e.WindPosition.X * TableSize + e.WindPosition.Y].WindImage = "wind";

            if (e.SmellPosition != null)
                Fields[e.SmellPosition.X * TableSize + e.SmellPosition.Y].SmellImage = "smell";

            if (e.SoundPosition != null)
                Fields[e.SoundPosition.X * TableSize + e.SoundPosition.Y].SoundImage = "sound";

            return;

            foreach(WumpusField f in Fields)
            {
                f.BatsImage = "";
                f.PitImage = "";
                f.PlayerImage = "";
                f.WumpusImage = "";
                f.TreasureImage = "";
            }

            Fields[_model.WumpusPosition.X * TableSize + _model.WumpusPosition.Y].WumpusImage = "wumpus";
            Fields[_model.TreasurePosition.X * TableSize + _model.TreasurePosition.Y].TreasureImage = "treasure";
            Fields[_model.Player.Position.X * TableSize + _model.Player.Position.Y].PlayerImage = "player";
            foreach (Position p in _model.BatPositions)
                Fields[p.X * TableSize + p.Y].BatsImage = "bats";
            foreach (Position p in _model.PitPositions)
                Fields[p.X * +TableSize + p.Y].PitImage = "pit";
            foreach(Position p in _model.SmellPositions)
                Fields[p.X * +TableSize + p.Y].SmellImage = "smell";
            foreach (Position p in _model.WindPositions)
                Fields[p.X * +TableSize + p.Y].WindImage = "wind";
        }

        public void NewGame(GameSettings settings)
        {
            Fields = new ObservableCollection<WumpusField>();
            for (int i = 0; i < TableSize; ++i)
            {
                for (int j = 0; j < TableSize; ++j)
                {
                    Fields.Add(new WumpusField
                    {
                        X = i,
                        Y  = j,
                        Number = i * TableSize + j,
                        BaseColor = "Brown"
                    });
                }
            }

            WindowSize = new WindowSize
                {
                    Height = settings.TableSize * 70 + 120, // 475
                    Width = settings.TableSize * 70 + 60   // 515
                };

            Fields[_model.Player.Position.X * TableSize + _model.Player.Position.Y].PlayerImage = "player";
            Fields[_model.Player.Position.X * TableSize + _model.Player.Position.Y].BaseColor = "BurlyWood";
            /*Fields[_model.WumpusPosition.X * TableSize + _model.WumpusPosition.Y].WumpusImage = "wumpus";
            Fields[_model.TreasurePosition.X * TableSize + _model.TreasurePosition.Y].TreasureImage = "treasure";
            foreach(Position p in _model.BatPositions)
                Fields[p.X * TableSize + p.Y].BatsImage = "bats";
            foreach (Position p in _model.PitPositions)
                Fields[p.X * + TableSize + p.Y].PitImage = "pit";/**/
        }

        private void Uncover()
        {
            Fields[_model.WumpusPosition.X * TableSize + _model.WumpusPosition.Y].WumpusImage = "wumpus";
            Fields[_model.TreasurePosition.X * TableSize + _model.TreasurePosition.Y].TreasureImage = "treasure";
            Fields[_model.Player.Position.X * TableSize + _model.Player.Position.Y].PlayerImage = "player";
            foreach (Position p in _model.BatPositions)
                Fields[p.X * TableSize + p.Y].BatsImage = "bats";
            foreach (Position p in _model.PitPositions)
                Fields[p.X * +TableSize + p.Y].PitImage = "pit";
        }
        private void Uncover(object sender, EventArgs e)
        {
            Uncover();
        }
    }
}
