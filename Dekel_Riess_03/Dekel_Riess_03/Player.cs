namespace Dekel_Riess_03;

public class Player
{
    public delegate void HealthChangedDelegate(float newHealth, string reason);
    public delegate void PlayerDiedDelegate();

    private float _health;
    private bool _isDead;
    

    // Property to manage health, clamped between 0 and 100
    public float Health
    {
        get => _health;
        set => _health = Math.Clamp(value, 0, 100);
    }
    
    // Constructor to initialize player with starting health
    public Player(float health = 100)
    {
        Health = health;
        _isDead = (health <= 0);
    }


    // Event triggered when player's health changes
    public event HealthChangedDelegate? OnHealthChanged;
    // Event triggered on player's death
    public event PlayerDiedDelegate? OnPlayerDied;

    
    // Heals the player by the specified amount, checks to see if the player is dead
    public void Heal(float amount)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        if (_isDead)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nexus is destroyed and cannot heal");
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
        if (_isDead == true)
        {
            Console.WriteLine("Nexus is already destroyed");
            Console.ResetColor();
            return;
        }
        
        Health -= amount;
        OnHealthChanged?.Invoke(Health, $"Took {amount} damage");

        // Check if player has died from this damage
        if (Health <= 0 && !_isDead)
        {
            _isDead = true;
            OnPlayerDied?.Invoke();
        }
        Console.ResetColor();
    }
}

