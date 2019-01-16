using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFiredScript : MonoBehaviour {

    public float speed;

    Rigidbody2D rigiBoy;
    Vector2 velocity;

    public bool goRight;

	// Use this for initialization
	void Start () {
        rigiBoy = GetComponent<Rigidbody2D>();
        if (goRight)
        {
            velocity = new Vector2(1, 0) * speed;
        }
        else
        {
            velocity = new Vector2(-1, 0) * speed;
        }
	}
	
	void FixedUpdate () {
        rigiBoy.MovePosition(rigiBoy.position + velocity * Time.fixedDeltaTime);
	}
}
