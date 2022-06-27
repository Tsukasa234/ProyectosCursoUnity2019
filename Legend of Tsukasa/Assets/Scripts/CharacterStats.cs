using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LifeManager))]
public class CharacterStats : MonoBehaviour
{
    public int level;
    public int exp;
    public int[] expToLevel;

    public int[] hpLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int[] energyLevels;

    private LifeManager lifeManager;
    private EnergyManager energyManager;

    private void Start()
    {
        lifeManager = GetComponent<LifeManager>();
    }

    public void AddExp(int exp)
    {
        this.exp += exp;
        if (level >= expToLevel.Length)
        {
            return;
        }

        if (exp >= expToLevel[level])
        {
            level++;
            lifeManager.UpdateMaxHealth(hpLevels[level]);
            energyManager.UpdateMaxEnergy(energyLevels[level]);
        }
    }

}
