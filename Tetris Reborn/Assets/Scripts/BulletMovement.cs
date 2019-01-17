using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public bool isRight;
    private Rigidbody2D rb;

    public float speed;
    public float destroyTime;

    public float damageAlly;
    public float damageEnemy;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (isRight == false)
        {
            rb.MovePosition(transform.position + new Vector3(0.02f, 0, 0) * speed);
        }
        else
        {
            rb.MovePosition(transform.position + new Vector3(-0.02f, 0, 0) * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "ProjectileGauche")
        {
            if (collision.gameObject.tag == "CibleDroite")
            {
                collision.gameObject.GetComponent<HealthManager>().currentHealth -= damageAlly; 
                Destroy(gameObject);
            }
        }

        if (gameObject.tag == "ProjectileDroite")
        {
            if (collision.gameObject.tag == "CibleGauche" || collision.gameObject.tag == "Baracks")
            {
                collision.gameObject.GetComponent<HealthManager>().currentHealth -= damageEnemy;
                Destroy(gameObject);
            }
        }
    }
}
