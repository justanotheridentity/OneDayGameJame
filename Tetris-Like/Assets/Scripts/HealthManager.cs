using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int health;

    public void TakeDamages(int damages)
    {
        health -= damages;
        Debug.Log("Hit!");
    }

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
