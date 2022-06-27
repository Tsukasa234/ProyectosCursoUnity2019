using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerLifeBar;
    public TMP_Text playerLifeText;
    
    public Slider playerEnergyBar;
    public TMP_Text playerEnergyText;

    public Slider PlayerExpBar;
    public TMP_Text playerLevel;

    public LifeManager playerLifeManager;
    public EnergyManager playerEnergyManager;
    public CharacterStats playerLevelStats;

    // Update is called once per frame
    void Update()
    {
        playerLifeBar.maxValue = playerLifeManager.maxHealth;
        playerLifeBar.value = playerLifeManager.CurrentHealt;

        playerEnergyBar.maxValue = playerEnergyManager.maxEnergy;
        playerEnergyBar.value = playerEnergyManager.CurrentEnergy;

        StringBuilder stringBuilder = new StringBuilder().Append("HP: ")
                                        .Append(playerLifeManager.CurrentHealt).Append("/").Append(playerLifeManager.maxHealth);

        StringBuilder stringBuilderEnergy = new StringBuilder().Append("EN: ")
                                        .Append(playerEnergyManager.CurrentEnergy).Append("/").Append(playerEnergyManager.maxEnergy);

        playerLifeText.text = stringBuilder.ToString();
        playerLevel.text = "Nivel: " + playerLevelStats.level;

        if (playerEnergyManager.CurrentEnergy >= 0)
        {
            playerEnergyText.text = stringBuilderEnergy.ToString();
        }

        if (playerLevelStats.level >= playerLevelStats.expToLevel.Length)
        {
            PlayerExpBar.enabled = false;
            return;
        }

        PlayerExpBar.maxValue = playerLevelStats.expToLevel[playerLevelStats.level];
        PlayerExpBar.minValue = playerLevelStats.expToLevel[playerLevelStats.level - 1];
        PlayerExpBar.value = playerLevelStats.exp;
    }

    public GameObject inventoryPanel;

    public void ToggleInventory() 
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }
}
