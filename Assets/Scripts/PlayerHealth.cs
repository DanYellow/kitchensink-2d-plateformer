using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public bool isInvicible = false;
    public SpriteRenderer graphics;
    public Animator animator;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple PlayerHealth on the scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !PauseMenu.isGameInPause)
        {
            TakeDamage(90);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth = currentHealth - damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();

                return;
            }

            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public void Die()
    {
        // Bloquer les mvts du perosnnage
        // Jouer animation
        // Supprimer interactions physiques

        PlayerMvt.instance.enabled = false;
        PlayerMvt.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMvt.instance.playerCollider.enabled = false;
        animator.SetTrigger("death");

        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMvt.instance.enabled = true;
        PlayerMvt.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMvt.instance.playerCollider.enabled = true;
        animator.SetTrigger("respawn");

        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public void HealPlayer(int amount)
    {
        currentHealth = currentHealth + amount;
        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.3f);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(3f);
        isInvicible = false;
    }
}
