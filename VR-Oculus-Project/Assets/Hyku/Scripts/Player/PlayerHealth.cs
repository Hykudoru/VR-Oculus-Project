using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public bool IsAlive { get; private set; }
    public bool HealthEmpty { get; private set; }
    public bool HealthFull { get; private set; }

    [SerializeField, Range(1, 1000)]
    private int maxHealth;
    public int MaxHealth
    {
        get { return maxHealth; }
        set
        {
            if (value <= 0 || value < health)
            {
                maxHealth = health;
            }
        }
    }

    [SerializeField]
    private int health = 100;
    public int Health
    {
        get { return health; }
        set
        {
            if (value <= 0)
            {
                health = 0;
                PlayerDown();
            }
            else if (value >= maxHealth)
            {
                health = maxHealth;
                HealthFull = true;
            }
            else
            {
                health = value;
            }
        }
    }

    void Start()
    {
        IsAlive = true;
        //fail safe if inspector level values wacked.
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    private void PlayerDown()
    {
        //Destroy(gameObject);
        IsAlive = false;
        //gameObject.SetActive(false);
    }
}