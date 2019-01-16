using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleScript : MonoBehaviour {

    public GameObject[,] grilleTerrain = new GameObject[13,9];
    public static GrilleScript instance;
    public GameObject mur;


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
        for(int j = 0; j < 7; j++)
        {
            grilleTerrain[i, j].GetComponent<BlockScript>().DestroyBlock();
            grilleTerrain[i, j] = null;
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
