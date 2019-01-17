using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaager : MonoBehaviour {

    public GameObject[] listeSpawn = new GameObject[10];
    public List<float> listeAttente;
    private GameObject spawnChoisi;

    public float timeUntilSpawn;
    public float currentTimeUntilSpawn;
    public float timeUntilUp;
    public float currentTimeUntilUp;

    public GameObject soldier;
    public GameObject tank;

    private int localisation;
    public float chancePuissant = 10;
    private float puissance;

    public float coefficientTime;
    public float coefficientPuissance;

	// Use this for initialization
	void Start () {
        currentTimeUntilSpawn = timeUntilSpawn;
        currentTimeUntilUp = timeUntilUp;
	}
	
	// Update is called once per frame
	void Update () {

        currentTimeUntilSpawn -= Time.deltaTime;
        currentTimeUntilUp -= Time.deltaTime;
        if (currentTimeUntilSpawn < 0)
        {
           currentTimeUntilSpawn = timeUntilSpawn;
            Summon();
        }

        if (currentTimeUntilUp < 0)
        {
            currentTimeUntilUp = timeUntilUp;
            LevelUp();
        }
    }

    void Summon()
    {
        localisation = Random.Range(0, 9);
        puissance = Random.Range(1, 101);

        if (puissance <= chancePuissant)
        {
            if (listeSpawn[localisation].GetComponent<FreeSpawn>().isFree == true)
            {
                GameObject ennemy = Instantiate(tank, listeSpawn[localisation].transform.position, new Quaternion(0, 180, 0, 0));
            }
            else
            {
                Summon();
            }
        }
        else
        {
            if (listeSpawn[localisation].GetComponent<FreeSpawn>().isFree == true)
            {
                GameObject ennemy = Instantiate(soldier, listeSpawn[localisation].transform.position, Quaternion.identity);
            }
            else
            {
                Summon();
            }
        }
    }

    void LevelUp()
    {
        if (timeUntilSpawn > 1)
        {
            timeUntilSpawn -= coefficientTime;
        }
        chancePuissant += coefficientPuissance;
    }
}
