namespace BreakOut;

public class GameDrawable : IDrawable
{
    private readonly GameEngine _engine;
    private float _tX;
    private float _tY;
    private float _scale;
    
    public GameDrawable(GameEngine engine)
    {
        _engine = engine;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (dirtyRect.Height < 0 || dirtyRect.Width < 0) return;
        
        var balls = _engine.Balls;
        _scale = Math.Min(dirtyRect.Height/GameEngine.GameHeight, dirtyRect.Width/GameEngine.GameWidth);

        _tX = (dirtyRect.Width - _scale * GameEngine.GameWidth) / 2;
        _tY = (dirtyRect.Height - _scale * GameEngine.GameHeight) / 2;
        
        canvas.FillColor = Colors.DarkSlateGray;
        canvas.FillRectangle(0, 0, dirtyRect.Width, dirtyRect.Height);
        
        canvas.SaveState();
        
        canvas.Translate(_tX, _tY);
        canvas.Scale(_scale, _scale);
        
        canvas.ClipRectangle(0, 0, GameEngine.GameWidth, GameEngine.GameHeight);
        canvas.FillColor = Colors.DeepSkyBlue;
        canvas.FillRectangle(0, 0, GameEngine.GameWidth, GameEngine.GameHeight);

        canvas.FillColor = Colors.Red;
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 3;
        
        foreach (var ball in balls)
        {
            canvas.FillCircle(ball.PosX, ball.PosY, ball.Radius);
            canvas.DrawCircle(ball.PosX, ball.PosY, ball.Radius);
        }
        
        canvas.RestoreState();
    }
}