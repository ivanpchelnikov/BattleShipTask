namespace BattleShip
{
    public interface IGameValidateHandler
    {
        bool AddShip(int gameId, int startX, int endX, int startY, int endY);
        bool AttackShip(int gameId, int X, int Y);
    }
}
