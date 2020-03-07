using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    public class GameDataHandler : IGameDataHandler
    {
        public GameDataHandler()
        {
            GamesBoardsList = GameBoardsList.GameBoards;
        }
        private List<GameBoard> GamesBoardsList { get; set; }

        public int Get()
        {
            return GamesBoardsList.Count;
        }
        public GameBoard Create()
        {
            var newGame = new GameBoard()
            {
                Id = GamesBoardsList.Count + 1
            };
            GamesBoardsList.Add(newGame);
            return newGame;
        }
        public int AddShip(int gameId, int startX, int endX, int startY, int endY)
        {
            var game = GamesBoardsList.Where(g => g.Id == gameId).First();

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    game.BoardContent[x, y] = Cell.Ship;
                }
            }
            return gameId;
        }
        public Cell AttackShip(int gameId, int x, int y)
        {
            var game = GamesBoardsList.Where(g => g.Id == gameId).First();
            Cell result = Cell.Empty;
            if (game.BoardContent[x, y] == Cell.Missed || game.BoardContent[x, y] == Cell.Sinked)
            {
                throw new Exception("Attacked same location");
            }
            else if (game.BoardContent[x, y] == Cell.Empty)
            {
                game.BoardContent[x, y] = Cell.Missed;
                result = Cell.Missed;
            }
            else if (game.BoardContent[x, y] == Cell.Ship)
            {
                game.BoardContent[x, y] = Cell.Sinked;
                result = CheckShip(game) ? Cell.Sinked : Cell.Ship;
            }
            return result;
        }

        private bool CheckShip(GameBoard game)
        {

            var isAllSinked = true;
            for (int x = 0; x < GameBoardsList.size; x++)
            {
                for (int y = 0; y < GameBoardsList.size; y++)
                {
                    if (game.BoardContent[x, y] == Cell.Ship)
                    {
                        isAllSinked = false;
                    }
                }
            }
            return isAllSinked;
            ;
        }
    }
}
