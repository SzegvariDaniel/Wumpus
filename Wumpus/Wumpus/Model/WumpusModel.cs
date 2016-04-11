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
        private List<Position> _freeNodes;

        public Node[,] Table { get; set; }
        public Int32 TableSize { get { return _tableSize; } }
        public Player Player { get { return _player; } }

        public WumpusModel() { }

        public void NewGame(GameSettings settings)
        {
            InitTable(settings);
            InitPlayer(settings);
            InitBats(settings);
            InitPits(settings);
            InitWumpus(settings);
        }

        private void InitWumpus(GameSettings settings)
        {
            throw new NotImplementedException();
        }

        private void InitPits(GameSettings settings)
        {
            throw new NotImplementedException();
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
                } while (IsValidBatPosition(p));

                _table[p.X, p.Y].Bats = true;
            }
        }

        private bool IsValidBatPosition(Position p)
        {
            return !IsCorner(p.X, p.Y) && !_table[p.X, p.Y].Bats && _freeNodes.Contains(p);
        }

        private bool IsCorner(int x, int y)
        {
            return x == 0 && (y == 0 || y == TableSize - 1) || x == TableSize - 1 && (y == 0 || y == TableSize - 1);
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
                    _table[i, j] = new Node();
                }
            }
        }
    }
}
