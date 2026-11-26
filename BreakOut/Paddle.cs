namespace BreakOut;

public class Paddle
{
    // Responsible for the x and y centre of the paddle
    // The paddle can change its y, but should not be done if following BreakOut logic
    private float _posX;
    private float _posY;

    public const float DefaultWidth = 150;
    public const float DefaultHeight = 25;

    public Paddle(float posX, float posY)
    {
        PosX = posX;
        PosY = posY;
    }

    public float PosY
    {
        get => _posY;
        set => _posY = value;
    } 

    public float PosX
    {
        get => _posX;
        set => _posX = value;
    }

    public float Width { get; set; } = DefaultWidth;

    public float Height { get; set; } = DefaultHeight;
    
    public RectF Bounds => new(PosX - Width / 2, PosY - Height / 2, Width, Height);
}
