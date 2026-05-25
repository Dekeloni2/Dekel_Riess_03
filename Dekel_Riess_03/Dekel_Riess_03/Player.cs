namespace Dekel_Riess_03;

public class Player
{
    private float _health;
    private bool _isDead;

    private float Health
    {
        get => _health;
        set => _health = Math.Clamp(value, 0, 100);
    }
    public Player(float health = 100)
    {
        this._health = health;
    }

    public event Action<float, string>? OnHealthChanged;
    public event Action? OnPlayerDied;
    
    public void Heal(float amount)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        if (_isDead)
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

    public void TakeDamage(float amount)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        if (_isDead == true)
        {
            Console.WriteLine("Player is already dead");
            return;
        }
        Health -= amount;
        OnHealthChanged?.Invoke(Health, $"Took {amount} damage");

        if (Health <= 0 && !_isDead)
        {
            _isDead = true;
            OnPlayerDied?.Invoke();
        }
        Console.ResetColor();
    }
}

