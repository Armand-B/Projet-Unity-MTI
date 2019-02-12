
using UnityEngine;

public class target : MonoBehaviour
{
    public AudioSource cri;
    public float health = 50f;
    public GameObject deathEffect;
    int die = 0;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f && die == 0)
        {
            cri.Play();
            Die();
        }
    }

    void Die()
    {
        die = 1;
        
        Destroy(gameObject,0.552f);
        GameObject explosion =  Instantiate(deathEffect, transform.position ,transform.rotation);
        Destroy(explosion, 2f);
    }
}
