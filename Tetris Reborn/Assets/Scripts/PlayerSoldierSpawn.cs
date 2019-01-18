using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoldierSpawn : MonoBehaviour {

    public GameObject[] listeSpawn = new GameObject[10];
    public HealthManager[] listeBunker = new HealthManager[10];
    public static int[,] listeAttente = new int[10, 50];

    public GameObject soldier;
    public GameObject tank;

    private int hasard;

    void Summon()
    {
        for (int i = 0; i < listeSpawn.Length; i++)
        {
            /*hasard = Random.Range(0, 10);
            if (hasard <= 8 && listeSpawn[i].GetComponent<FreeSpawn>().isFree == true)
            {
                GameObject ennemy = Instantiate(soldier, listeSpawn[i].transform.position, new Quaternion(0, 180, 0, 0));
            }
            else if (hasard == 9 && listeSpawn[i].GetComponent<FreeSpawn>().isFree == true)
            {
                GameObject ennemy = Instantiate(tank, listeSpawn[i].transform.position, new Quaternion(0, 180, 0, 0));
            }*/
                
            if(listeAttente[i,0] >= 4)
            {
                switch (listeAttente[i, 0])
                {
                    case 0 :
                        listeBunker[i].
                        break;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                }
            }
            
        }
    }


    IEnumerator spawnSoldier()
    {
        yield return new WaitForSeconds(1f);
        Summon();
    }

}
