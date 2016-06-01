using ELTE.Windows.ColorGrid.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tank.Model;

namespace Tank.ViewModel
{
    class TankViewModel : ViewModelBase
    {
        private TankModel _model;

        public ObservableCollection<TankField> Fields { get; set; }
        public Int32 TableSize { get { return _model.TableSize; } }
        public DelegateCommand StepCommand { get; set; }
        public DelegateCommand ShootCommand { get; set; }


        public TankViewModel(TankModel model)
        {
            _model = model;

            StepCommand = new DelegateCommand(p => _model.Players[0].Health > 0, p => Step((string)p));
            ShootCommand = new DelegateCommand(p => _model.Players[0].Health > 0, p => Shoot((String)p));
        }

        private void Shoot(string p)
        {
            _model.Shoot((Direction)Enum.Parse(Type.GetType("Tank.Model.Direction"), p.ToUpper()));
        }

        private void Step(string p)
        {
            _model.Step((Direction)Enum.Parse(Type.GetType("Tank.Model.Direction"), p.ToUpper()));
        }

        public void NewGame() 
        {
            Fields = new ObservableCollection<TankField>();
            for(int i = 0; i < TableSize; ++i)
            {
                for(int j = 0; j < TableSize; ++j)
                {
                    Fields.Add(new TankField
                        {
                            Tank = _model.Table[i,j].Player == null ? "" : "tank",
                            Wall = _model.Table[i,j].Wall,
                            Direction = _model.Table[i, j].Player == null ? Direction.NONE : _model.Table[i, j].Player.Direction
                        });
                }
            }

        }

    }
}
