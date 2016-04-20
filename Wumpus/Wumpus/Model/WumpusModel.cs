using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void InitTreasure(GameSettings settings)
        {
            Random random = new Random();
            Position p;

            do
            {
                p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
            } while ( !IsValidDangerPosition(p));

            _table[p.X, p.Y].Treasure = true;
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
        }

        private void InitPits(GameSettings settings)
        {
            Random random = new Random();
            for(int i = 0; i < settings.NumberOfPits; ++i)
            {
                Position p;

                do
                {
                    p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
                } while (!IsValidDangerPosition(p));

                _table[p.X, p.Y].Pit = true;
            }
        }

        private void InitBats(GameSettings settings)
        {
            Random random = new Random();
            for(int i = 0; i < settings.NumberOfBats; ++i)
            {
                Position p;

                do
                {
                    p = new Position(random.Next() % settings.TableSize, random.Next() % settings.TableSize);
                } while (!IsValidDangerPosition(p));

                _table[p.X, p.Y].Bats = true;
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
            _player = new Player(settings.NumberOfArrows);
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
