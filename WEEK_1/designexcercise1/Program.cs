using System;
using System.IO;
using System.Threading.Tasks;


public sealed class Logger
{
    private static readonly Lazy<Logger> _instance =
        new Lazy<Logger>(() => new Logger());
    
    private Logger()
    {
        Console.WriteLine("Logger instance created");
    }
    
    public static Logger Instance => _instance.Value;
    
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {DateTime.Now:HH:mm:ss}: {message}");
    }
}


class Program
{
    static void Main()
    {
        Logger logger1 = Logger.Instance;
        logger1.Log("Application started");
        
        Logger logger2 = Logger.Instance;
        logger2.Log("User logged in");
        
        Console.WriteLine($"Same instance? {ReferenceEquals(logger1, logger2)}");
        
        Parallel.Invoke(
            () => Logger.Instance.Log("Thread 1 message"),
            () => Logger.Instance.Log("Thread 2 message")
        );
    }
}
