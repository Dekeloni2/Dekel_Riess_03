namespace Dekel_Riess_03;

public class UI
{
    public void DisplayHealthChanges(float newHealth, string reason)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"[UI] Player health is now {newHealth} ({reason})");
        Console.ResetColor();
    }
}