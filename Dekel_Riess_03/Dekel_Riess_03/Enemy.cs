namespace Dekel_Riess_03;

public class Enemy
{
    // Enemy's name for identification
    public string Name { get; set; }

    // Constructor to create an enemy with a name
    public Enemy(string name)
    {
        Name = name;
    }

    // Attacks the target player with specified damage
    public void Attack(Player target, float damage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Name} is attacking with {damage} damage!");
        target.TakeDamage(damage);
        Console.ResetColor();
    }
    
    // Plays a victory animation when player dies
    public void PlayVictoryAnimation()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{Name} is celebrating by doing a victory dance!");
    }
}