namespace BreakOut;

public class GameEngine
{
    public const float GameWidth = 450;
    public const float GameHeight = 800;

    public List<Ball> Balls { get; } = new();

    public GameEngine()
    {
        Balls.Add(new Ball(GameWidth/2, GameHeight/2));
    }

    public void Update(float dt)
    {
        foreach (var ball in Balls)
            ball.Move(dt);
    }
}