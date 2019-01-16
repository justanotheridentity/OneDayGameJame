using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDeplacement : MonoBehaviour {

    public bool isEnemy;

    public float maxSpeed;
    private float speed;

    Rigidbody2D rigiBoy;
    Vector2 velocity;

    private bool enemySeen;
    private bool canMove = true;

    public LayerMask playerLayer, enemyLayer;
    private LayerMask currentLayer;
    private LayerMask otherLayer;

    public float maxShootRate = 0.6f;
    private float shootRate = 0;

    public GameObject bulletPrefab;

    public float distanceVue;

    private Vector2 walkDirection;

    public Animator animPlayer;

    // Use this for initialization
    void Start () {
        rigiBoy = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();

        if (isEnemy)
        {
            walkDirection = new Vector2(1, 0);
            currentLayer = playerLayer;
            otherLayer = enemyLayer;
        }
        else
        {
            walkDirection = new Vector2(-1, 0);
            currentLayer = enemyLayer;
            otherLayer = playerLayer;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Physics2D.Raycast(transform.position, walkDirection, distanceVue, currentLayer) || !canMove || Physics2D.Raycast(transform.position, walkDirection, 0.3f, otherLayer))
        {
            if(!Physics2D.Raycast(transform.position, walkDirection, distanceVue, currentLayer))
            {
                enemySeen = false;
            }
            else
            {
                enemySeen = true;
            }
            speed = 0;
            animPlayer.SetBool("walk", false);
        }
        else if(canMove)
        {
            speed = maxSpeed;
            animPlayer.SetBool("walk", true);
        }

        if(enemySeen)
        {
            if (shootRate <= 0)
            {
                Instantiate(bulletPrefab, transform.position + new Vector3(1, 1.2f, 0), transform.rotation).GetComponent<BulletFiredScript>().goRight = isEnemy;
            }

            shootRate += Time.deltaTime;
            if (shootRate >= maxShootRate)
            {
                shootRate = 0;
            }
            animPlayer.SetFloat("shootRate", shootRate);
            canMove = false;
        }
        else if (shootRate < maxShootRate && shootRate != 0)
        {
            shootRate += Time.deltaTime;
            if (shootRate < 0 || shootRate >= maxShootRate)
            {
                shootRate = 0;
                animPlayer.SetFloat("shootRate", 0);
                canMove = true;
            }
        }

        velocity = walkDirection * speed;

        Debug.DrawRay(transform.position, walkDirection * 0.3f, Color.red);
	}

    private void FixedUpdate()
    {
        rigiBoy.MovePosition(rigiBoy.position + velocity * Time.fixedDeltaTime);
    }
}
