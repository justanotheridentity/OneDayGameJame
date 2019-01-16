using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float health;

	// Update is called once per frame
	void Update () {
		if(health<=0)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(transform.gameObject);
            }
        }
	}

    public void getHurt (float degat)
    {
        health -= degat;
        StartCoroutine(getHit());
    }

    IEnumerator getHit()
    {
        GetComponentInParent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.4f);
        GetComponentInParent<SpriteRenderer>().color = Color.white;
    }
}
