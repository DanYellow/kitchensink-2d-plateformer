using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoints = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
        {
            PlayerHealth.instance.HealPlayer(healthPoints);
            Destroy(gameObject);
        }
    }
}
