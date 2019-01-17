using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleScript : MonoBehaviour {

    public GameObject[,] grilleTerrain = new GameObject[40,9];
    public static GrilleScript instance;
    public GameObject mur;
    public TestSpawnArmy spawnSoldier;
    public List<HealthManager> wallHealth;

    public TestSpawnArmy spawnSoldierJ2;
    public List<HealthManager> wallHealthJ2;

    // Use this for initialization
    void Start () {
        instance = this;
        InitialiseGrid();
	}
	
    public void UpdateGrille(Vector2 position, GameObject newBlock)
    {
        grilleTerrain[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y)] = newBlock;

        for (int i = 0; i < 12; i++)
        {
            if (CheckLigne(i))
            {
                if(i==0)
                {
                    //Ecran de fin
                }
                DestroyLigne(i);
            }
        }

        for (int i = 39; i > 27; i--)
        {
            if (CheckLigne(i))
            {
                if(i==39)
                {
                    //Ecran de fin
                }
                DestroyLigne(i);
            }
        }

    }

    bool CheckLigne(int i)
    {
        for(int j = 0; j < 7; j++)
        {
            if(grilleTerrain[i,j] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DestroyLigne(int i)
    {
        for(int j = 1; j < 8; j++)
        {
            if (grilleTerrain[i, j]!=null)
            {
                BlockScript script = grilleTerrain[i, j].GetComponent<BlockScript>();
                if (i < 20)
                {
                    switch (script.type)
                    {
                        /* Thomas
                         * case 1:
                            wallHealth[j].health += Mathf.RoundToInt(0.1f * wallHealth[j].maxHealth);
                            break;
                        case 2:
                            wallHealth[j].health += Mathf.RoundToInt(0.1f * wallHealth[j].maxHealth);
                            wallHealth[j].invulnerability = 2f;
                            break;
                            */
                        case 3:
                            spawnSoldier.armyCount[j]++;
                            break;
                        case 4:
                            spawnSoldier.greatArmyCount[j]++;
                            break;
                    }
                }
                else
                {
                    switch (script.type)
                    {
                        /*case 1:
                            wallHealthJ2[j].health += Mathf.RoundToInt(0.1f * wallHealth[j].maxHealth);
                            break;
                        case 2:
                            wallHealthJ2[j].health += Mathf.RoundToInt(0.1f * wallHealth[j].maxHealth);
                            wallHealthJ2[j].invulnerability = 2f;
                            break;*/
                        case 3:
                            spawnSoldierJ2.armyCount[j]++;
                            break;
                        case 4:
                            spawnSoldierJ2.greatArmyCount[j]++;
                            break;
                    }
                }
                script.DestroyBlock();
                Destroy(grilleTerrain[i, j]);
                grilleTerrain[i, j] = null;
            }
        }

        if (i < 20)
        {
            for (int k = i - 1; k >= 0; k--)
            {
                for (int j = 1; j < 8; j++)
                {
                    if (grilleTerrain[k, j] != null)
                    {
                        grilleTerrain[k, j].transform.position = new Vector2(grilleTerrain[k, j].transform.position.x + 1, grilleTerrain[k, j].transform.position.y);
                        grilleTerrain[k + 1, j] = grilleTerrain[k, j];
                        grilleTerrain[k, j] = null;
                    }
                }
            }
        }
        else
        {
            for (int q = i + 1; q < 40; q++)
            {
                for (int s = 1; s < 8; s++)
                {
                    if (grilleTerrain[q, s] != null)
                    {
                        grilleTerrain[q, s].transform.position = new Vector2(grilleTerrain[q, s].transform.position.x - 1, grilleTerrain[q, s].transform.position.y);
                        grilleTerrain[q - 1, s] = grilleTerrain[q, s];
                        grilleTerrain[q, s] = null;
                    }
                }
            }
        }
    }

    void InitialiseGrid()
    {
        for(int i = 0; i < 13; i++)
        {
            grilleTerrain[i, 0] = Instantiate(mur, new Vector3(i, 0, 0), Quaternion.identity);
            grilleTerrain[i, 8] = Instantiate(mur, new Vector3(i, 8, 0), Quaternion.identity);
        }
        for(int j = 0; j<8; j++)
        {
            grilleTerrain[12, j] = Instantiate(mur, new Vector3(12, j, 0), Quaternion.identity);
        }

        for(int i = 39; i > 26; i--)
        {
            grilleTerrain[i, 0] = Instantiate(mur, new Vector3(i, 0, 0), Quaternion.identity);
            grilleTerrain[i, 8] = Instantiate(mur, new Vector3(i, 8, 0), Quaternion.identity);
        }
        for (int j = 0; j < 8; j++)
        {
            grilleTerrain[27, j] = Instantiate(mur, new Vector3(27, j, 0), Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        for(int i = 0; i< 40; i++)
        {
            for(int j = 0; j<8; j++)
            {
                if (grilleTerrain[i, j] != null)
                {
                    Gizmos.DrawSphere(new Vector3(i, j, 0), 0.5f);
                }
            }
        }
    }
}
