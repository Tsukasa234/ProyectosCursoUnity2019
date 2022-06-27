using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public int CurrentHealt
    {
        get
        {
            return currentHealth;
        }
    }

    public int expWhenDefeated;


    // Start is called before the first frame update
    void Start()
    {
        UpdateMaxHealth(maxHealth);
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (gameObject.tag.Equals("Enemy"))
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExp(expWhenDefeated);
            }
            gameObject.SetActive(false);
        }
    }

    public void UpdateMaxHealth(int newMaxHealt)
    {
        maxHealth = newMaxHealt;
        currentHealth = maxHealth;
    }
}
