using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementFormScript : MonoBehaviour {

    public List<GameObject> blockChild;

	// Use this for initialization
	void Start () {
        foreach(Transform child in transform)
        {
            blockChild.Add(child.gameObject);
        }
        StartCoroutine(DeplacementForme(1));
	}

    IEnumerator DeplacementForme(float tempsDeplacement)
    {

        yield return new WaitForSeconds(tempsDeplacement);
        foreach(GameObject child in blockChild)
        {
            if(child.GetComponent<BlockScript>().DetectionBlock())
            {
                foreach (GameObject block in blockChild)
                {
                    AjoutGrille(block.GetComponent<BlockScript>().position);
                }
                yield return new WaitForSeconds(tempsDeplacement);
            }
        }
        transform.position = new Vector2(Mathf.RoundToInt(transform.position.x + 1), Mathf.RoundToInt(transform.position.y));
        foreach (GameObject child in blockChild)
        {
            child.GetComponent<BlockScript>().position.x = child.GetComponent<BlockScript>().position.x + 1;
        }
        StartCoroutine(DeplacementForme(tempsDeplacement));
    }

    void AjoutGrille(Vector2 position)
    {
        /* Récupère la grille
         * Ajoute la position à la bonne place de la grille
         * 
         * 
         * */
    }
}
