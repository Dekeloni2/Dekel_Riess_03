namespace Dekel_Riess_03;

public class Player
{
    private float health;
    private bool isDead;

    // Property to manage health, clamped between 0 and 100
    public float Health
    {
        get => health;
        set
        {
            health = Math.Clamp(value, 0, 100);
        }
    }
    
    // Constructor to initialize player with starting health
    public Player(float health = 100)
    {
        this.health = health;
    }

    // Event triggered when player's health changes
    public event Action<float, string>? OnHealthChanged;
    
    // Event triggered when player dies
    public event Action? OnPlayerDied;
    
    // Heals the player by the specified amount, checks to see if the player is dead
    public void Heal(float amount)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        if (isDead)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player is dead and cannot heal");
            Console.ResetColor();
            return;
        }
    
        Health += amount;
        OnHealthChanged?.Invoke(Health, $"Healed by {amount}");
        Console.ResetColor();
    }

    // Applies damage to the player
    public void TakeDamage(float amount)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        
        // Check if player is already dead
        if (isDead == true)
        {
            Console.WriteLine("Player is already dead");
            Console.ResetColor();
            return;
        }
        
        Health -= amount;
        OnHealthChanged?.Invoke(Health, $"Took {amount} damage");

        // Check if player has died from this damage
        if (Health <= 0 && !isDead)
        {
            isDead = true;
            OnPlayerDied?.Invoke();
        }
        Console.ResetColor();
    }
}

