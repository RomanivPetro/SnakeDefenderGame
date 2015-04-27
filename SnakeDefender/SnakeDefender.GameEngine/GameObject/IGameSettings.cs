
namespace SnakeDefender.GameEngine.GameObject
{
    public interface IGameSettings
    {
        int GameBoardWidth { get; set; }
        int GameBoardHeight { get; set; }
        int GameSpeed { get; set; }
        double GameScore { get; set; }
        int GamePoints { get; set; }
        Direction GameMoveDirection { get; set; }
    }
}
