using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int maxHealth;
    public int health;
    public float invulnerability;

    private void Update()
    {
        if(invulnerability>0)
        {
            invulnerability -= Time.deltaTime;
        }
    }

    public void TakeDamages(int damages)
    {
        if (invulnerability <= 0)
        {
            health -= damages;
        }
    }

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
