using Dekel_Riess_03;

public class Program
{
    public static void Main(string[] args)
    {
        // Create player and UI
        Player player = new Player(100);
        UI ui = new UI();
        
        // Create 3 enemies
        Enemy goblin = new Enemy("Goblin");
        Enemy orc = new Enemy("Orc");
        Enemy dragon = new Enemy("Dragon");
        
        // Subscribe UI to health changed event
        player.OnHealthChanged += ui.DisplayHealthChanges;
        
        // Subscribe all enemies to player died event
        player.OnPlayerDied += goblin.PlayVictoryAnimation;
        player.OnPlayerDied += orc.PlayVictoryAnimation;
        player.OnPlayerDied += dragon.PlayVictoryAnimation;
        
        // Simulate battle
        Console.WriteLine("=== Battle Begins! ===\n");
        
        goblin.Attack(player, 20);
        orc.Attack(player, 30);
        
        player.Heal(25);
        
        dragon.Attack(player, 50);
        dragon.Attack(player, 40);
        
        Console.WriteLine("\n=== Battle Ended ===");
    }
}