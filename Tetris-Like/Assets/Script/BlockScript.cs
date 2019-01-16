using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public Vector2 position;
    public int type = 0;
    public bool isEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyBlock()
    {
        // Avec un manager d'unité, accès à une liste des différentes unitées. Spawn en fonction du type actuel
    }

    public bool DetectionBlock()
    {
        bool blockDetected = false;
        /* Appel du script de la Grille, pour récupérer le tableau
         * Si position.x-/+ (En fonction de is enemy)1 != null
         * Fin déplacement.
         * */

        return blockDetected;
    }
}
