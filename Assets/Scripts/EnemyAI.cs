using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public Text healthText;
    public int health, maxHealth;
    private bool isDead;
    public Button healthButton, damageButton;

    public void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void Update()
    {
        if (isDead)
        {

        }
    }

    public void Damage(int damageAmount)
    {
        if (health - damageAmount < 0)
        {
            health = 0;
        }
        else
        {
            health -= damageAmount;
        }
        healthText.text = "Health: " + health.ToString();
    }

    public void Heal(int healAmount)
    {
        if (health + healAmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmount;
        }
        healthText.text = "Health: " + health.ToString();
    }
}
