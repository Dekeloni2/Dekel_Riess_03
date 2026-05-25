namespace Dekel_Riess_03;

public class Enemy(string name)
{
    private string Name { get; set; } = name;

    public void Attack(Player target, float damage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Name} is attacking with {damage} damage!");
        target.TakeDamage(damage);
        Console.ResetColor();
    }
    
    public void PlayVictoryAnimation()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"{Name} is celebrating by doing a victory dance!");
    }
}