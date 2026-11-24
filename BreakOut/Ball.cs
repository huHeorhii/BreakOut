namespace BreakOut;

public class Ball
{
    private float _posX;
    private float _posY;
    
    private float _velX;
    private float _velY;
    
    public const float DefaulRadius = 20;
    
    public Ball(float posX, float posY)
    {
        PosX = posX;
        PosY = posY;
    }
    
    public float Radius { get; set; } = DefaulRadius;
    
    public float PosX
    {
        get => _posX;
        set => _posX = value;
    }

    public float PosY
    {
        get => _posY;
        set => _posY = value;
    }

    public float VelX
    {
        get => _velX;
        set => _velX = value;
    }

    public float VelY
    {
        get => _velY;
        set => _velY = value;
    }

    public void Move()
    {
        PosX += VelX;
        PosY += VelY;
    }
}