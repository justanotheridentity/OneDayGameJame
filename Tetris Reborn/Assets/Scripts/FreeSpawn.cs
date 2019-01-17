using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSpawn : MonoBehaviour {

    public bool isFree;

	// Use this for initialization
	void Start () {
        isFree = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SoldatDroite")
        {
            isFree = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isFree = true;
    }
}
