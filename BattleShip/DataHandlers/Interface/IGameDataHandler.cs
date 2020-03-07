using System.Collections.Generic;

namespace BattleShip
{
    public interface IGameDataHandler
    {
        int Get();
        GameBoard Create();
        public int AddShip(int gameId, int startX, int endX, int startY, int endY);
        Cell AttackShip(int gameId, int X, int Y);

    }
}
