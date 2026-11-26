namespace BreakOut;

public class GameEngine
{
    public const float GameWidth = 450;
    public const float GameHeight = 800;
    
    public List<Ball> Balls { get; } = new();
    public Paddle Paddle { get; } = new(GameWidth / 2, GameHeight - 100);

    public GameEngine()
    {
        Balls.Add(new Ball(GameWidth / 2, GameHeight / 2));
    }

    public void Update(float dt)
    {
        foreach (var ball in Balls)
        {
            ball.Move(dt);
            WallBounce(ball);
        }
    }

    private void WallBounce(Ball ball)
    {
        // Left wall collision
        if (ball.PosX - ball.Radius <= 0)
        {
            ball.VelX = Math.Abs(ball.VelX);
            ball.PosX = ball.Radius;
        }
        // Right wall collision
        else if (ball.PosX + ball.Radius >= GameWidth)
        {
            ball.VelX = -Math.Abs(ball.VelX);
            ball.PosX = GameWidth - ball.Radius;
        }
        
        // Ceiling collision
        if (ball.PosY - ball.Radius <= 0)
        {
            ball.VelY = Math.Abs(ball.VelY);
            ball.PosY = ball.Radius;
        }
        // Floor collision
        else if (ball.PosY + ball.Radius >= GameHeight)
        {
            ball.VelY = -Math.Abs(ball.VelY);
            ball.PosY = GameHeight - ball.Radius;
        }
    }
    
    public void SpawnBalls(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Ball ball = new(
                Random.Shared.NextSingle() * GameWidth, 
                Random.Shared.NextSingle() * GameHeight
                );

            float dirX = Random.Shared.Next(-5, 5) >= 0 ? 1 : -1;
            float dirY = Random.Shared.Next(-5, 5) >= 0 ? 1 : -1;
            
            ball.VelX = (Random.Shared.NextSingle() + 1) * 100 * dirX;
            ball.VelY = (Random.Shared.NextSingle() + 1) * 100 * dirY;
            Balls.Add(ball);
        }
    }

    public void MovePaddleTo(float x)
    {
        x = Math.Clamp(x, Paddle.Width / 2, GameWidth - Paddle.Width / 2);
        
        Paddle.PosX = x;
    }
}