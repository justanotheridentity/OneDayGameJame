using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int health;

    public void TakeDamages(int damage)
    {
        health -= damage;

    }

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
