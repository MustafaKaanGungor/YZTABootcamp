using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Zombie hit! Remaining HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Zombie died!");
        GameManager.Instance.ZombieKilled();
        // Ölüm animasyonu, efekt vs buraya
        Destroy(gameObject); // şimdilik direkt sil
    }
}
