using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarFireScript : MonoBehaviour {

    public float shootRate;

    private WarDeplacementScript playerScript;

    public GameObject bulletPrefab;

	void Start () {
        playerScript = GetComponent<WarDeplacementScript>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && playerScript.canAttack)
        {
            if (shootRate == 0)
            {
                if (GetComponent<SpriteRenderer>().flipX)
                {
                    if (playerScript.doesSneak)
                    {
                        Instantiate(bulletPrefab, transform.position + new Vector3(1, 0.8f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = true;
                    }
                    else
                    {
                        Instantiate(bulletPrefab, transform.position + new Vector3(1, 1.2f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = true;
                    }
                }
                else
                {
                    if (playerScript.doesSneak)
                    {
                        Instantiate(bulletPrefab, transform.position + new Vector3(1, 0.8f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = false;
                    }
                    else
                    {
                        Instantiate(bulletPrefab, transform.position + new Vector3(1, 1.2f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = false;
                    }
                }
            }
            shootRate += Time.deltaTime;
            if (shootRate >= 0.6f)
            {
                shootRate = 0;
            }
            playerScript.canWalk = false;
            playerScript.animPlayer.SetFloat("shootRate", shootRate);
            
        }
        else if (shootRate<0.6f && shootRate != 0)
        {
            shootRate += Time.deltaTime;
            if (shootRate < 0 || shootRate>=0.6f)
            {
                shootRate = 0;
                playerScript.animPlayer.SetFloat("shootRate", 0);
            }
        }
    }
}
