using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int maxHealth = 30;
    public int secondsInvicibility;
    public AudioSource deathSound;
    public GameObject deathEffect;

    private int currentHealth;
    private bool gotHit = false;
    private float timeLeft = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            print("dead");
            Destroy(this.gameObject, 0.552f);
            if (deathSound != null)
            {
                deathSound.Play();
            }
            if (deathEffect != null)
            {
                GameObject explosion = Instantiate(deathEffect, transform.position, transform.rotation);
                Destroy(explosion, 2f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            print(currentHealth);
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
}
