using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentHealth <= 0 && gameObject.tag == "Baracks")
        {
            Debug.Log("Oui.");
            SceneManager.LoadScene("TestLeaderboard");
        }
        else if (currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
	}

    public void healUnit(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Test");
    }
}
