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

    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 50; j++)
            {
                listeAttente[i, j] = 4;
            }
        }
        StartCoroutine(spawnSoldier());
    }

    void Summon()
    {
        for (int i = 0; i < listeSpawn.Length; i++)
        {
            if(listeAttente[i,0] < 4)
            {
                switch (listeAttente[i, 0])
                {
                    case 0 :
                        listeBunker[i].healUnit(50);
                        listeAttente[i, 0] = 4;
                        break;
                    case 1:
                        listeBunker[i].healUnit(200);
                        listeAttente[i, 0] = 4;
                        break;
                    case 2:
                        Instantiate(soldier, listeSpawn[i].transform.position, new Quaternion(0, 180, 0, 0));
                        listeAttente[i, 0] = 4;
                        break;
                    case 3:
                        Instantiate(tank, listeSpawn[i].transform.position, new Quaternion(0, 180, 0, 0));
                        listeAttente[i, 0] = 4;
                        break;
                }
            }

            for(int k = 0; k < 49; k++)
            {
                if(listeAttente[i,k+1] <= 4 && listeAttente[i, k + 1] == 4)
                {
                    listeAttente[i, k] = listeAttente[i, k + 1];
                    listeAttente[i, k + 1] = 4;
                    if (k == 0)
                    {
                        Debug.Log(listeAttente[i, k] + "     " + listeAttente[i, k + 1]);
                    }
                }
            }
        }
    }


    IEnumerator spawnSoldier()
    {
        yield return new WaitForSeconds(2.5f);
        Summon();
        StartCoroutine(spawnSoldier());
    }

    public static void addSoldier(int pos, int type)
    {
        for(int i = 0; i < 50; i++)
        {
            if(listeAttente[pos, i] >= 4)
            {
                listeAttente[pos, i] = type;
            }
        }
    }

}
