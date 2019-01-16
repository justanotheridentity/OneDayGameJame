using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldierscript : MonoBehaviour {

    //Paramètres soldat
    [SerializeField]
    private float soldierSpeed = 1f;
    [SerializeField] 
    private int soldierHP = 1;
    [SerializeField]
    private int soldierDamages = 1;

    /*[SerializeField]
    private float elitesoldierSpeed = 1f;
    [SerializeField]
    private int elitesoldierHP = 2;
    [SerializeField]
    private int elitesoldierDamages = 2;*/

    public int damages;

    [SerializeField]
    private float shootingtime = 1f; //délai entre 2 tirs
    private float time;

    //States soldat
    private bool Walking = true;
    private bool Shooting = false;
    //private bool Waiting = false;

    RaycastHit2D detection; //y a-t-il un soldat devant moi? 
    RaycastHit2D shoot; //gestion du tir

    [SerializeField]
    private float detectionRange = 1f;
    [SerializeField]
    private float shootingRange = 1f;

    public Transform SightSpot;
    //public LayerMask Soldier;

    Rigidbody2D rb;

    [SerializeField]
    private string currentTag;
    

	void Start () {
        currentTag = gameObject.tag;
        health = soldierHP;
        damages = soldierDamages;
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	

	void Update () {

        if (Walking)
        {
            rb.velocity = new Vector2(1 * soldierSpeed, 0); //le soldat est un soldat de base qui va vers la droite
        }

        SearchAndDestroy();

        if (Shooting)
        {
            Shoot();
        }

        Death();
	}

    private void SearchAndDestroy()
    {
        detection = Physics2D.Raycast(SightSpot.position, new Vector2 (detectionRange, 0));

        if (detection.collider != null)
        {
            if (detection.collider.tag == currentTag)
            {
                Walking = false;
                //Waiting = true; 
            }
            else if (detection.collider.tag != currentTag)
            {
                Walking = false;
                Shooting = true;
            }
        }
        else
        {
            Walking = true;
        }
    }

    private void Shoot()
    {
        if (time <= 0)
        {
            Fire();
            time = shootingtime;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        shoot = Physics2D.Raycast(SightSpot.position, new Vector2(shootingRange, 0));
        
        if (shoot.collider != null)
        {
            GetComponent<Soldierscript>().TakeDamages(damages);
        }
    }


}
