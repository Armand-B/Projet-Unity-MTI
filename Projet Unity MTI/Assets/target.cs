
using UnityEngine;

public class target : MonoBehaviour
{
    public float health = 50f;
    public GameObject deathEffect;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject explosion =  Instantiate(deathEffect, transform.position ,transform.rotation);
        Destroy(explosion, 2f);
    }
}
