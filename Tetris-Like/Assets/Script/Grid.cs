using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    [Header ("Paramêtre des types")]
    [SerializeField]
    public int longueur = 14;
    public int hauteur = 6;
    GameObject[,] tableauGrille;

    void Start ()
    {
        tableauGrille = new GameObject[14, 6];
	}

    
    public GameObject GridFunction (int cordX, int cordY)
    {
        return tableauGrille[cordX,cordY];
    }

    public bool CheckLineComplete (int hauteurLigne)
    {
        bool check= false;
        for ( int  i = 0;  i < tableauGrille.GetLength(1); i++)
        {
            if (tableauGrille[i,hauteurLigne] != null)
            {
                check = true;
            }
            else
            {
                check = false;
                break;
            }
        }

        return check;
    }


    public void AddBlock (GameObject objet, int X, int Y)
    {
        if (tableauGrille == null)
        {
            tableauGrille[X, Y] = objet;
        }
    }

    private void ForceAddBlock (GameObject objet, int X, int Y)
    {
        tableauGrille[X, Y] = objet;
    }


    #region Destroy
    private void LineDestroy (int numLine)
    {
        GameObject tampon = null;

        for ( int i = 0; i < tableauGrille.GetLength(1); i ++)
        {
            tampon = tableauGrille[i, numLine];
            tableauGrille[i, numLine] = null;
            Destroy(tampon);
        }
    }

    public void blockDestroy (int cordX, int cordY)
    {
        GameObject tampon = null;

        tampon = tableauGrille[cordX, cordY];
        tableauGrille[cordX, cordY] = null;
        Destroy(tampon);
        
    }
    #endregion
}
