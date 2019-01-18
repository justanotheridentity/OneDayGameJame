using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTank : MonoBehaviour {
    public bool isRight;
    private Rigidbody2D rb;

    public float speedAlly;
    public float speedEnemy;
    private float maxSpeedAlly;
    private float maxSpeedEnemy;

    public GameObject bullet;

    public float shootCooldown;
    public float currentShootCooldown;

    public Animator anim;

    public GameObject Text;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentShootCooldown = shootCooldown;
        maxSpeedAlly = speedAlly;
        maxSpeedEnemy = speedEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        currentShootCooldown -= Time.deltaTime;
    }

    void Movement()
    {
        if (isRight == false)
        {
            rb.MovePosition(transform.position + new Vector3(0.02f, 0, 0) * speedAlly);
        }
        else
        {
            rb.MovePosition(transform.position + new Vector3(-0.02f, 0, 0) * speedEnemy);
        }
    }

    void Shoot()
    {
        if (isRight == false)
        {
            if (currentShootCooldown < 0)
            {
                anim.SetTrigger("fighting");
                GameObject projectile = Instantiate(bullet, transform.position + new Vector3(.5f, .05f, 0), Quaternion.identity);
                projectile.tag = "ProjectileGauche";
                currentShootCooldown = shootCooldown;
                Debug.Log("Ratatata");
                anim.SetTrigger("fighting");
            }
        }
        else
        {
            if (currentShootCooldown < 0)
            {
                anim.SetTrigger("fighting");
                GameObject projectile = Instantiate(bullet, transform.position + new Vector3(-.5f, -.05f, 0), Quaternion.identity);
                projectile.tag = "ProjectileDroite";
                projectile.GetComponent<BulletMovement>().isRight = true;
                currentShootCooldown = shootCooldown;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag == "SoldatGauche")
        {
            if (collision.gameObject.tag == "SoldatDroite")
            {
                speedAlly = 0;
                Shoot();
            }

            if (collision.gameObject.tag == "CibleGauche")
            {
                speedAlly = 0;
            }
        }

        if (gameObject.tag == "SoldatDroite")
        {
            if (collision.gameObject.tag == "SoldatGauche")
            {
                speedEnemy = 0;
                Shoot();
            }

            if (collision.gameObject.tag == "CibleDroite")
            {
                speedEnemy = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speedAlly = maxSpeedAlly;
        speedEnemy = maxSpeedEnemy;
    }

    private void OnDestroy()
    {
        Instantiate(Text, transform.position, Quaternion.identity);
    }
}
