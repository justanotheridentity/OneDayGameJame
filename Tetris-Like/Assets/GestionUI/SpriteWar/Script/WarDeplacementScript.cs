using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarDeplacementScript : MonoBehaviour {

    public float maxSpeed = 5;
    public float speed = 5;

    Rigidbody2D rigiBoy;
    Vector2 velocity;

    public bool canWalk = true;
    public bool canAttack = true;

    public Animator animPlayer;

    public bool doesSneak = false;
    public bool doesProtect = false;

    public GameObject shield;
    
    // Use this for initialization
    void Start () {
        rigiBoy = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(canWalk)
        {
            speed = maxSpeed;
        }
        else if (!canWalk)
        {
            speed = 0;
        }

        if((Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0) && canWalk)
        {
            animPlayer.SetBool("walk", true);
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            animPlayer.SetBool("walk", false);
        }

        if(GetComponent<WarFireScript>().shootRate!=0 || doesProtect || doesSneak)
        {
            canWalk = false;
        }
        else
        {
            canWalk = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            doesSneak = !doesSneak;
            animPlayer.SetBool("sneak", doesSneak);
            canWalk = !doesSneak;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            doesProtect = !doesProtect;
            animPlayer.SetBool("doesProtect", doesProtect);
            canWalk = !doesProtect;
            canAttack = !doesProtect;
            shield.SetActive(doesProtect);
        }

        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
	}

    private void FixedUpdate()
    {
        rigiBoy.MovePosition(rigiBoy.position + velocity * Time.fixedDeltaTime);
    }
}
