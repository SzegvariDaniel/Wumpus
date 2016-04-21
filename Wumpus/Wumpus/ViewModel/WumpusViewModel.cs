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

        public ObservableCollection<WumpusField> Fields { get; set; }
        public int TableSize { get { return _model.TableSize; } set { _model.TableSize = value; OnPropertyChanged(); } }
        public DelegateCommand UncoverCommand { get; set; }
        public DelegateCommand UpCommand { get; set; }
        public DelegateCommand DownCommand { get; set; }
        public DelegateCommand LeftCommand { get; set; }
        public DelegateCommand RightCommand { get; set; }

        public WumpusViewModel(WumpusModel model)
        {
            _model = model;

            UncoverCommand = new DelegateCommand(p => asda());
            UpCommand = new DelegateCommand(p => _model.StepUp());
            DownCommand = new DelegateCommand(p => _model.StepDown());
            LeftCommand = new DelegateCommand(p => _model.StepLeft());
            RightCommand = new DelegateCommand(p => _model.StepRight());
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
                        ButtonClickCommand = new DelegateCommand(p => asda()),
                        Content = ""
                });
                }
            }
        }

        private void asda()
        {
            for (int i = 0; i < TableSize; ++i)
            {
                for (int j = 0; j < TableSize; ++j)
                {
                    if(_model.Table[i, j].Bats)
                        Fields[i * TableSize + j].Content += " Denevér";

                    if (_model.Table[i, j].Pit)
                        Fields[i * TableSize + j].Content += " Csapda";

                    if (_model.Table[i, j].Wumpus)
                        Fields[i * TableSize + j].Content += " Wumpus";

                    if (_model.Table[i, j].Treasure)
                        Fields[i * TableSize + j].Content += " Kincs";

                    if (_model.Table[i, j].Player != null)
                        Fields[i * TableSize + j].Content += " Játékos";
                }
            }
        }
    }
}
