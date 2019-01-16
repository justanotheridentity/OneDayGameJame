using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject enemyPrefab;

	// Use this for initialization
	void Start () {
        StartCoroutine(DoSpawn());
	}
	
	IEnumerator DoSpawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(Random.Range(1f,3.5f));
        StartCoroutine(DoSpawn());
    }
}
