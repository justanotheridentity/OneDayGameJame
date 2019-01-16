using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationWar : MonoBehaviour {

    private Animator animPlayer;

    private float shootRate;

    private bool doesSneak = false;
    private bool doesProtect = false;

	// Use this for initialization
	void Start () {
        animPlayer = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A))
        {
            animPlayer.SetBool("walk", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animPlayer.SetBool("walk", false);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            doesSneak = !doesSneak;
            animPlayer.SetBool("sneak", doesSneak);
        }

        if (Input.GetKey(KeyCode.E))
        {
            shootRate += Time.deltaTime;
            if(shootRate>=1f)
            {
                shootRate = 0;
            }
            animPlayer.SetFloat("shootRate", shootRate);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            shootRate = 0;
            animPlayer.SetFloat("shootRate", shootRate);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            doesProtect = !doesProtect;
            animPlayer.SetBool("doesProtect", doesProtect);
        }
    }
}
