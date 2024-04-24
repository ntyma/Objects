using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health 
{
    //private int maxHealth = 100;
    private int currentHealth;
    public UnityEvent<int> OnHealthChanged;

    public Health(int maxHealth)
    {
        currentHealth = maxHealth;
        OnHealthChanged = new UnityEvent<int>();
    }

    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    OnHealthChanged.Invoke(currentHealth);
    //}

    public void DecreaseLife()
    {
        currentHealth -= 1;
        //Debug.Log("Losing life:" + currentHealth.ToString());
        OnHealthChanged.Invoke(currentHealth);
    }

    public void DecreaseLife(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged.Invoke(currentHealth);
    }

    public void Heal()
    {

    }

    public int GetHealth()
    {
        return currentHealth; 
    }

}
