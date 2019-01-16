using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringEnemyScript : MonoBehaviour {

    public GameObject bulletPrefab;
    Animator anim;

    private bool isFiring = false;
    private float cooldown = 0;

    private void Start()
    {
        StartCoroutine(doesShot());
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("isFiring", isFiring);

        if(cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }

        if(isFiring && cooldown<=0)
        {
            StartCoroutine(shotFired());
            cooldown = 0.5f;
        }
    }

    IEnumerator shotFired()
    {
        yield return new WaitForSeconds(0.1f);
        Instantiate(bulletPrefab, transform.position + new Vector3(1, 1.2f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = true;
        yield return new WaitForSeconds(0.1f);
        Instantiate(bulletPrefab, transform.position + new Vector3(1, 1.2f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = true;
        yield return new WaitForSeconds(0.1f);
        Instantiate(bulletPrefab, transform.position + new Vector3(1, 1.2f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = true;
    }


    IEnumerator doesShot()
    {
        yield return new WaitForSeconds(Random.Range(1f,4f));
        if(isFiring)
        {
            isFiring = false;
        }

        if(Random.Range(0f,1f) < 0.7f)
        {
            isFiring = true;
        }

        StartCoroutine(doesShot());
    }
}
