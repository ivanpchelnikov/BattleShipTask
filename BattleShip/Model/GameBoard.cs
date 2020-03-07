using System;

namespace BattleShip
{
    public class GameBoard
    {
        public GameBoard()
        {
            BoardContent =  new Cell[GameBoardsList.size, GameBoardsList.size];
        }
        public Cell[,] BoardContent { get; set; }

        public int Id { get; set; }
    }

}
