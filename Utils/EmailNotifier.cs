namespace InventorySystem.Utils;

public class EmailNotifier : INotifier
{
    public EmailNotifier()
    {
    }

    public void SendNotification(string recipient, string message)
    {
        Console.WriteLine($"發送email至{recipient}: {message}");
    }
}