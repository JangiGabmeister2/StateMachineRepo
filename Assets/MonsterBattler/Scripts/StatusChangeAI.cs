using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusChangeAI : MonoBehaviour
{
    public Text healthText;
    public int health;
    public int maxHealth;

    public void Start()
    {
        healthText.text = $"Health: {health} / {maxHealth}";
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
        healthText.text = $"Health: {health} / {maxHealth}";
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
        healthText.text = $"Health: {health} / {maxHealth}";
    }
}
