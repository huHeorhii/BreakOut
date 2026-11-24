using System.Diagnostics;

namespace BreakOut;

public partial class MainPage : ContentPage
{
    private const int TickIntervalMs = 16;
    private const float MaxDtS = 0.1f;
    private IDispatcherTimer _timer = null!;
    private readonly GameEngine _engine = new();
    private readonly Stopwatch _stopwatch = new();

    public MainPage()
    {
        InitializeComponent();
        
        InitialiseTimer();
        GameView.Drawable = new GameDrawable(_engine);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _stopwatch.Restart();
        _timer.Start();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _timer.Stop();
        _stopwatch.Stop();
    }

    private void InitialiseTimer()
    {
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(TickIntervalMs);
        _timer.Tick += Tick;
    }
    
    private void Tick(object? sender, EventArgs e)
    {
        var dt = (float)_stopwatch.Elapsed.TotalSeconds;
        if (dt > MaxDtS) dt = MaxDtS;
        _stopwatch.Restart();

        _engine.Update(dt);
        
        GameView.Invalidate();
    }
    
}