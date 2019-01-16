using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarDamageScript : MonoBehaviour {

    public float degat;
    public bool isFriendly;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Ennemis" && isFriendly) || (collision.gameObject.tag == "Player" && !isFriendly) || collision.gameObject.tag == "Shield")
        {
            if(collision.gameObject.tag != "Shield" && collision.gameObject.GetComponent<HealthScript>() != null)
            {
                collision.gameObject.GetComponent<HealthScript>().getHurt(degat);
            }
            Destroy(gameObject);
        }
        
    }
}
