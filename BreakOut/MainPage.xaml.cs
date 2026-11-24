namespace BreakOut;

public partial class MainPage : ContentPage
{
    private IDispatcherTimer _timer = null!;
    private readonly GameEngine _engine = new GameEngine();

    public MainPage()
    {
        InitializeComponent();
        
        InitialiseTimer();
        GameView.Drawable = new GameDrawable(_engine);
    }

    private void InitialiseTimer()
    {
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(200);
        _timer.Tick += Tick;
    }


    private void Tick(object? sender, EventArgs e)
    {
        
    }

    public void ToggleTimer(object? sender, EventArgs e)
    {
        if (!(_timer.IsRunning)) _timer.Start();
        else
        {
            _timer.Stop();
        }
    }
}