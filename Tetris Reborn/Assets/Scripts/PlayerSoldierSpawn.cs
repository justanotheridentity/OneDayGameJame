using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoldierSpawn : MonoBehaviour {

    public GameObject[] listeSpawn = new GameObject[10];

    public GameObject soldier;
    public GameObject tank;

    private int hasard;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Summon();
        }
    }

    void Summon()
    {
        for (int i = 0; i < listeSpawn.Length; i++)
        {
            hasard = Random.Range(0, 10);
            if (hasard <= 8 && listeSpawn[i].GetComponent<FreeSpawn>().isFree == true)
            {
                GameObject ennemy = Instantiate(soldier, listeSpawn[i].transform.position, new Quaternion(0, 180, 0, 0));
            }
            else if (hasard == 9 && listeSpawn[i].GetComponent<FreeSpawn>().isFree == true)
            {
                GameObject ennemy = Instantiate(tank, listeSpawn[i].transform.position, new Quaternion(0, 180, 0, 0));
            }
            
        }

    }


}
