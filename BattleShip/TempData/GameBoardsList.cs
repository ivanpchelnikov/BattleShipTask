using System.Collections.Generic;

namespace BattleShip
{
    public static class GameBoardsList
    {
        public static readonly int size = 10;

        private static readonly object _lock = new object();
        private static List<GameBoard> _gameBoards;
        public static List<GameBoard> GameBoards
        {
            get
            {
                lock (_lock)
                {
                    if (_gameBoards == null)
                    {
                        _gameBoards = new List<GameBoard>();
                    }
                    return _gameBoards;
                }
            }
        }

    }
}
