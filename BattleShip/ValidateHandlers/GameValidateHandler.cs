
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    public class GameValidateHandler : IGameValidateHandler
    {
        public GameValidateHandler()
        {
            GamesBoardsList = GameBoardsList.GameBoards;
        }
        private List<GameBoard> GamesBoardsList { get; set; }

        public bool AddShip(int gameId, int startX, int endX, int startY, int endY)
        {
            if (gameId < 0 ||
                GamesBoardsList.Count > 0 && GamesBoardsList.Find(g => g.Id == gameId) == null)
                throw new Exception("Game doesn't exist.");

            if (startX < 0 || startX > GameBoardsList.size - 1 ||
                endX < 0 || endX > GameBoardsList.size - 1 ||
                startY < 0 || startY > GameBoardsList.size - 1 ||
                endY < 0 || endY > GameBoardsList.size - 1)
                throw new Exception("Ship location out of game board.");

            if (startX != endX && startY != endY) throw new Exception("Ship location must be in line.");

            if (startX > endX && startY > endY) throw new Exception("Ship location start position must be less or equal then end postion.");

            var game = GamesBoardsList.Where(g => g.Id == gameId).First();

            for (int x = 0; x < GameBoardsList.size; x++)
            {
                for (int y = 0; y < GameBoardsList.size; y++)
                {
                    if (game.BoardContent[x, y] == Cell.Missed)
                    {
                        throw new Exception($"The game id {gameId} was started.");
                    }
                }
            }

            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    if (game.BoardContent[x, y] == Cell.Ship)
                    {
                        throw new Exception("Ship location is busy by other ship.");
                    }
                }
            }
            return true;
        }

        public bool AttackShip(int gameId, int X, int Y)
        {
            if (gameId < 0 ||
                GamesBoardsList.Count > 0 && GamesBoardsList.Find(g => g.Id == gameId) == null)
                throw new Exception("Game doesn't exist.");

            if (X < 0 && X > GameBoardsList.size - 1 ||
                Y < 0 && Y > GameBoardsList.size - 1)
                throw new Exception("Ship location out of game board.");

            var game = GamesBoardsList.Where(g => g.Id == gameId).First();
            
            for (int x = 0; x < GameBoardsList.size; x++)
            {
                for (int y = 0; y < GameBoardsList.size; y++)
                {
                    if (game.BoardContent[x, y] == Cell.Ship)
                    {
                        return true;
                    }
                }
            }
            throw new Exception("There are no ships on the game board.");
        }
    }
}
