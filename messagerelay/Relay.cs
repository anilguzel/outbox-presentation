using Microsoft.Extensions.Hosting;

public class Relay : IHostedService
{
    private int _executionCount = 0;
    private Timer? _timer = null;

    public Task StartAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromSeconds(5));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref _executionCount);
        Console.WriteLine("Count : " + count);
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
