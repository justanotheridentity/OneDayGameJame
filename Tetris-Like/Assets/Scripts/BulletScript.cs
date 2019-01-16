using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [Header("BulletParameter")]
    Rigidbody2D rb;
    [SerializeField] float bulletSpeed;

    HealthManager healthManager;
    Soldierscript soldierscript;
    public GameObject assignedSoldier;

    private int bulletdirection;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        soldierscript = assignedSoldier.gameObject.GetComponent<Soldierscript>();
        bulletdirection = soldierscript.direction;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(bulletdirection * bulletSpeed, 0);
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        healthManager = collision.gameObject.GetComponent<HealthManager>();
        if (healthManager.health == 0)
        {
            Destroy(collision.gameObject);
        }
    }
}
