using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] groups;
    public int nextId;

	// Use this for initialization
	void Start () {
        nextId = Random.Range(0, groups.Length);
        spawnNext ();
	}

    public GameObject createGroup(Vector3 v) {
        GameObject group = Instantiate(groups[nextId], v, Quaternion.identity);
        return group;
    }

	// spawnNext group block
	public void spawnNext() {
		// Spawn Group at current Position
        createGroup(transform.position);
        //nextId = Random.Range(0, groups.Length);
        nextId = 3;
	}
}
