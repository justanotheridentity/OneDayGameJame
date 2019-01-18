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
            SceneManager.LoadScene("TestLeaderboard");
        }
        else if (currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }

        if (currentHealth <= maxHealth / 2 && gameObject.tag == "Baracks")
        {
            gameObject.GetComponentInParent<Animator>().SetTrigger("damagedTower");
        }

        if (currentHealth <= maxHealth / 4 && gameObject.tag == "Baracks")
        {
            gameObject.GetComponentInParent<Animator>().SetTrigger("deadTower");
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
