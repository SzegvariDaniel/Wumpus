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

        public WumpusViewModel(WumpusModel model)
        {
            _model = model;
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
                        Y  = j
                    });
                }
            }
            OnPropertyChanged("TableSize");

        }
    }
}
