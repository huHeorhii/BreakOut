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
        if (dirtyRect.Height <= 0 || dirtyRect.Width <= 0) return;
        
        var balls = _engine.Balls;
        _scale = Math.Min(dirtyRect.Height/GameEngine.GameHeight, dirtyRect.Width/GameEngine.GameWidth);

        _tX = (dirtyRect.Width - _scale * GameEngine.GameWidth) / 2;
        _tY = (dirtyRect.Height - _scale * GameEngine.GameHeight) / 2;
        
        canvas.FillColor = Colors.DarkSlateGray;
        canvas.FillRectangle(0, 0, dirtyRect.Width, dirtyRect.Height);
        
        canvas.SaveState();
        
        canvas.StrokeSize = 3;
        canvas.StrokeColor = Colors.Black;
        
        canvas.Translate(_tX, _tY);
        canvas.Scale(_scale, _scale);
        
        canvas.ClipRectangle(0, 0, GameEngine.GameWidth, GameEngine.GameHeight);
        canvas.FillColor = Colors.DeepSkyBlue;
        canvas.FillRectangle(0, 0, GameEngine.GameWidth, GameEngine.GameHeight);
        
        canvas.FillColor = Colors.Red;
        foreach (var ball in balls)
        {
            canvas.FillCircle(ball.PosX, ball.PosY, ball.Radius);
            canvas.DrawCircle(ball.PosX, ball.PosY, ball.Radius);
        }
        
        canvas.FillColor = Colors.Pink;
        canvas.FillRectangle(_engine.Paddle.Bounds);
        canvas.DrawRectangle(_engine.Paddle.Bounds);
        
        canvas.RestoreState();
    }

    public bool TryScreenToGame(PointF screenP, out PointF gameP)
    {
        if (_scale <= 0)
        {
            gameP = new PointF(0, 0);
            return false;
        }

        var gX = (screenP.X - _tX) / _scale;
        var gY = (screenP.Y - _tY) / _scale;
        
        gameP = new PointF(gX, gY);
        
        return true;
    }
}