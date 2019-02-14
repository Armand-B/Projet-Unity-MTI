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
    public Text timeOfDay;
    public int secondsInvicibility;
    public int energyGivenPerTick;
    public int timeBetweenEnergy;

    private int currentHealth;
    private int currentEnergy;
    private bool gotHit = false;
    private float timeLeft = 0;
    private float whenEnergy = 0;
    private int nbSolarPanels;

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
        whenEnergy = 0;
        nbSolarPanels = GameObject.FindGameObjectsWithTag("SolarPanel").Length;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
        energyBar.value = currentEnergy;
        healthText.text = "Health : " + healthBar.value;
        energyText.text = "Energy : " + energyBar.value;
        timeLeft -= Time.deltaTime;
        nbSolarPanels = GameObject.FindGameObjectsWithTag("SolarPanel").Length;
        UpdateEnergy();
    }

    void UpdateEnergy()
    {
        if (isDay())
        {
            
            if (whenEnergy <= 0)
            {
                for (int i = 0; i < nbSolarPanels; ++i)
                {
                    currentEnergy += energyGivenPerTick;
                }
                whenEnergy = timeBetweenEnergy;
            }
            else
            {
                whenEnergy -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!gotHit)
            {
                gotHit = true;
                timeLeft = secondsInvicibility;
                currentHealth -= collision.gameObject.GetComponent<EnemyMovment>().damage;
                if (currentHealth < 0)
                    currentHealth = 0;
            }
            else
            {
                if (timeLeft <= 0)
                {
                    gotHit = false;
                }
            }
        }
    }

    private bool isDay()
    {
        if (timeOfDay.text == "Morning" ||
            timeOfDay.text == "Mid Noon" ||
            timeOfDay.text == "Evening")
            return true;
        return false;
    }
}
