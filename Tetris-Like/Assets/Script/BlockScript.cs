using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public Vector2 position;
    public int type = 0;
    public bool isEnemy;
    GrilleScript grille;
    private int direction;
    private Vector2 decalage;

    void Start()
    {
        position = transform.position;
        grille = transform.parent.gameObject.GetComponent<DeplacementFormScript>().grille;
        if(isEnemy)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }

    public void DestroyBlock()
    {
        /* Avec un manager d'unité, accès à une liste des différentes unitées. Spawn en fonction du type actuel
         * */

        Destroy(gameObject);
    }

    public bool DetectionBlock()
    {
        bool blockDetected = false;
        /* Appel du script de la Grille, pour récupérer le tableau
         * Si position.x-/+ (En fonction de is enemy)1 != null
         * Fin déplacement.
         * */
        if(grille.grilleTerrain[Mathf.RoundToInt(position.x+1), Mathf.RoundToInt(position.y)] != null)
        {
            Debug.Log(grille.grilleTerrain[Mathf.RoundToInt(position.x + 1), Mathf.RoundToInt(position.y)].transform.position);
            Debug.Log(Mathf.RoundToInt(position.x));
            Debug.Log(Mathf.RoundToInt(position.y));
            blockDetected = true;
        }

        return blockDetected;
    }

    public bool DetectionDeCote(int direction)
    {
        bool blockDetected = false;

        if (grille.grilleTerrain[Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y + (1*direction))] != null)
        {
            blockDetected = true;
        }

        return blockDetected;
    }
}
