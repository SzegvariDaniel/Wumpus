using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wumpus.Model
{
    class WumpusModel
    {
        private Node[,] _table;
        private Player _player;
        private Int32 _tableSize;
        private List<Position> _safeNodes;

        public Node[,] Table { get { return _table; } }
        public Int32 TableSize { get { return _tableSize; } set { _tableSize = value; } }
        public Player Player { get { return _player; } }
        public Position WumpusPosition { get; set; }
        public Position TreasurePosition { get; set; }
        public List<Position> BatPositions { get; set; }
        public List<Position> PitPositions { get; set; }


        public event EventHandler<EventArgs> OnStep;
        public event EventHandler<EventArgs> OnGameWon;

        public WumpusModel() { }

        public void NewGame(GameSettings settings)
        {
            InitTable(settings);
            InitPlayer(settings);
            InitTreasure(settings);
            InitBats(settings);
            InitPits(settings);
            InitWumpus(settings);
        }

        public void StepUp()
        {
            if (Player.Position.X <= 0)
                return;

            _table[Player.Position.X - 1, Player.Position.Y].Player = _table[Player.Position.X, Player.Position.Y].Player;
            _table[Player.Position.X, Player.Position.Y].Player = null;

            --Player.Position.X;

            if (OnStep != null)
                OnStep(this, EventArgs.Empty);
        }

        public void StepDown()
        {
            if (Player.Position.X >= TableSize - 1)
                return;

            _table[Player.Position.X + 1, Player.Position.Y].Player = _table[Player.Position.X, Player.Position.Y].Player;
            _table[Player.Position.X, Player.Position.Y].Player = null;

            ++Player.Position.X;

            if (OnStep != null)
                OnStep(this, EventArgs.Empty);
        }

        public void StepLeft()
        {
            if (Player.Position.Y <= 0)
                return;

            _table[Player.Position.X, Player.Position.Y - 1].Player = _table[Player.Position.X, Player.Position.Y].Player;
            _table[Player.Position.X, Player.Position.Y].Player = null;

            --Player.Position.Y;

            if (OnStep != null)
                OnStep(this, EventArgs.Empty);
        }

        public void StepRight()
        {
            if (Player.Position.Y >= TableSize - 1)
                return;

            _table[Player.Position.X, Player.Position.Y + 1].Player = _table[Player.Position.X, Player.Position.Y].Player;
            _table[Player.Position.X, Player.Position.Y].Player = null;

            ++Player.Position.Y;

            if (OnStep != null)
                OnStep(this, EventArgs.Empty);
        }

        public void Step(String direction)
        {
            Node target = new Node();

            switch (direction)
            {
                case "Up":
                    target = _table[Player.Position.X - 1, Player.Position.Y];
                    break;
                case "Down":
                    target = _table[Player.Position.X + 1, Player.Position.Y];
                    break;
                case "Left":
                    target = _table[Player.Position.X, Player.Position.Y - 1];
                    break;
                case "Right":
                    target = _table[Player.Position.X, Player.Position.Y + 1];
                    break;
            }
  
            if (OnStep != null)
                OnStep(this, EventArgs.Empty);
        }

        public void Shoot(String direction)
        {
            if (Player.Arrows <= 0)
            {
                MessageBox.Show("Elfogytak a nyilak!", "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            Node target = new Node();
            switch(direction)
            {
                case "Up":
                    target = _table[Player.Position.X - 1, Player.Position.Y];
                    break;
                case "Down":
                    target = _table[Player.Position.X + 1, Player.Position.Y];
                    break;
                case "Left":
                    target = _table[Player.Position.X, Player.Position.Y - 1];
                    break;
                case "Right":
                    target = _table[Player.Position.X, Player.Position.Y + 1];
                    break; 
            }

            if (target.Wumpus)
            {
                

                MessageBox.Show("Wumpus lelőve", "Gratulálok!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            --Player.Arrows;
            
        }

        private void InitTreasure(GameSettings settings)
        {
            Random random = new Random();
            Position p;

            do
            {
                p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
            } while ( !IsValidDangerPosition(p));

            _table[p.X, p.Y].Treasure = true;
            TreasurePosition = p;
            _safeNodes.Add(p);
        }

        private void InitWumpus(GameSettings settings)
        {
            Random random = new Random();
            Position p;

            do
            {
                p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
            } while (!IsValidDangerPosition(p));

            _table[p.X, p.Y].Wumpus = true;
            WumpusPosition = p;
        }

        private void InitPits(GameSettings settings)
        {
            PitPositions = new List<Position>();
            Random random = new Random();
            for(int i = 0; i < settings.NumberOfPits; ++i)
            {
                Position p;

                do
                {
                    p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
                } while (!IsValidDangerPosition(p));

                _table[p.X, p.Y].Pit = true;
                PitPositions.Add(p);
            }
        }

        private void InitBats(GameSettings settings)
        {
            BatPositions = new List<Position>();
            Random random = new Random();
            for(int i = 0; i < settings.NumberOfBats; ++i)
            {
                Position p;

                do
                {
                    p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
                } while (!IsValidDangerPosition(p));

                _table[p.X, p.Y].Bats = true;
                BatPositions.Add(p);
            }
        }

        private bool IsValidDangerPosition(Position p)
        {
            Node selectedNode = _table[p.X, p.Y];
            return !selectedNode.Bats && !selectedNode.Pit && !selectedNode.Wumpus && 
                        !selectedNode.Treasure && !_safeNodes.Contains(p);
        }

        private void InitPlayer(GameSettings settings)
        {
            _player = new Player(new Position(settings.TableSize - 1, 0), settings.NumberOfArrows);
            _table[settings.TableSize - 1, 0].Player = Player;
        }

        private void InitTable(GameSettings settings)
        {
            _tableSize = settings.TableSize;
            _table = new Node[settings.TableSize, settings.TableSize];
            for (int i = 0; i < settings.TableSize; ++i)
            {
                for (int j = 0; j < settings.TableSize; ++j)
                {
                    _table[i, j] = new Node
                    {
                        Bats = false,
                        Pit = false,
                        Wumpus = false,
                        Treasure = false
                    };
                }
            }

            _safeNodes = new List<Position>();
            _safeNodes.Add(new Position(_tableSize - 1, 0));
            _safeNodes.Add(new Position(_tableSize - 2, 0));
            _safeNodes.Add(new Position(_tableSize - 1, 1));
        }

    }
}
