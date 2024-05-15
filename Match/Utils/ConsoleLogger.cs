namespace Match.Utils;

public class ConsoleLogger : ILogger
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
    public void WriteLine()
    {
        Console.WriteLine();
    }
}