using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnScript : MonoBehaviour {

    public GameObject prefab;
    public GrilleScript grille;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawning());
	}
	
	IEnumerator spawning()
    {
        yield return new WaitForSeconds(5f);
        GameObject gameObj;
        gameObj = Instantiate(prefab, transform.position, Quaternion.identity);
        gameObj.GetComponent<DeplacementFormScript>().grille = grille;
        StartCoroutine(spawning());
    }
}
