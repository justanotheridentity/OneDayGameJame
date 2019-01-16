using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    public Vector2 position;
    public int type = 0;
    public bool isEnemy;
    GrilleScript grille;
    public int direction;
    private Vector2 decalage;

    bool blockDetected = false;

    void Start()
    {
        position = transform.position;
        grille = transform.parent.gameObject.GetComponent<DeplacementFormScript>().grille;
    }

    public void DestroyBlock()
    {
        Destroy(gameObject);
    }

    public bool DetectionBlock()
    {
        if(grille.grilleTerrain[Mathf.RoundToInt(position.x + direction), Mathf.RoundToInt(position.y)] != null)
        {
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

    public void Rotate(Vector2 localPosition, Vector2 parentPosition)
    {
        Vector2 newLocalPosition = new Vector2(localPosition.y, -localPosition.x);
        position = parentPosition + newLocalPosition;
        transform.position = position;
    }
}
