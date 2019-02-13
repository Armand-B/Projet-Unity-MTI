using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnergyHandle : MonoBehaviour
{
    public int maxHealth;
    public int maxEnergy;
    public Slider healthBar;
    public Text healthText;
    public Slider energyBar;
    public Text energyText;

    private int currentHealth;
    private int currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        energyBar.maxValue = maxEnergy;
        healthBar.minValue = 0;
        energyBar.minValue = 0;
        healthBar.value = maxHealth;
        energyBar.value = 0;
        currentHealth = maxHealth;
        currentEnergy = 0;
        healthText.text = "Health : " + healthBar.value;
        energyText.text = "Energy : " + energyBar.value;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
        energyBar.value = currentEnergy;
        healthText.text = "Health : " + healthBar.value;
        energyText.text = "Energy : " + energyBar.value;
    }
}
