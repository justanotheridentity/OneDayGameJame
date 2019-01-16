using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleScript : MonoBehaviour {

    public GameObject[,] grilleTerrain = new GameObject[13,9];
    public static GrilleScript instance;
    public GameObject mur;
    public TestSpawnArmy spawnSoldier;
    public List<HealthManager> wallHealth;

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
        Debug.Log(i);
        for(int j = 1; j < 8; j++)
        {
            BlockScript script = grilleTerrain[i, j].GetComponent<BlockScript>();
            switch(script.type)
            {
                case 1:
                    wallHealth[j].health += Mathf.RoundToInt(0.1f*wallHealth[j].maxHealth);
                    break;
                case 2:
                    wallHealth[j].health += Mathf.RoundToInt(0.1f * wallHealth[j].maxHealth);
                    wallHealth[j].invulnerability = 2f;
                    break;
                case 3:
                    spawnSoldier.armyCount[j]++;
                    break;
                case 4:
                    spawnSoldier.greatArmyCount[j]++;
                    break;
            }

            script.DestroyBlock();
            grilleTerrain[i, j] = null;
        }
        for(int k = i-1; k>=0; k--)
        {
            for (int j = 1; j < 8; j++)
            {
                if(grilleTerrain[k, j] != null)
                {
                    grilleTerrain[k, j].transform.position = new Vector2(grilleTerrain[k, j].transform.position.x + 1, grilleTerrain[k, j].transform.position.y);
                    grilleTerrain[k + 1, j] = grilleTerrain[k, j];
                    grilleTerrain[k, j] = null;
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
    }
}
