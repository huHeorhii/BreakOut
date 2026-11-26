namespace BreakOut;

public class Ball
{
    // Responsible for the centre x and y coordinates of the circle
    private float _posX;
    private float _posY;
    
    public const float DefaultXVel = 100;
    public const float DefaultYVel = -100;
    
    public const float DefaultRadius = 20;
    
    public Ball(float posX, float posY)
    {
        PosX = posX;
        PosY = posY;
    }
    
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

    public float VelX { get; set; } = DefaultXVel;

    public float VelY { get; set; } = DefaultYVel;

    public float Radius { get; set; } = DefaultRadius;
    
    public void Move(float dt)
    {
        PosX += VelX * dt;
        PosY += VelY * dt;
    }
}