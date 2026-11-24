namespace BreakOut;

public class GameDrawable : IDrawable
{
    private readonly GameEngine _engine;

    public GameDrawable(GameEngine engine)
    {
        _engine = engine;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var balls = _engine.Balls;

        canvas.FillColor = Colors.DeepSkyBlue;
        canvas.FillRectangle(0, 0, dirtyRect.Width, dirtyRect.Height);

        canvas.FillColor = Colors.Red;
        canvas.StrokeColor = Colors.Black;
        foreach (var ball in balls)
        {
            canvas.FillCircle(ball.PosX, ball.PosY, ball.Radius);
            canvas.DrawCircle(ball.PosX, ball.PosY, ball.Radius);
        }
    }
}