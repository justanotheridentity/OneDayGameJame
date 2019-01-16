using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldierscript : MonoBehaviour {

    [Header("Paramètres soldat")]
    Rigidbody2D rb;
    [SerializeField] float soldierSpeed = 1f;
    [SerializeField] int soldierHP = 1;
    [SerializeField] int soldierDamages = 1;
    [SerializeField] int elitesoldierHP = 2;
    [SerializeField] int elitesoldierDamages = 2;

    [SerializeField] bool elite;
    [SerializeField] bool Player1;

    public int direction = 1; //utilisé pour déterminer la direction du personnage et de la balle

    private bool walking;
    private bool shooting;

    [SerializeField] float detectionRange = 1f;
    [SerializeField] float shootingRange = 1f;

    [Header("Tir & Detections")]
    public int damage;
    [SerializeField] float shootingtime = 1f;
    private float time;
    public GameObject Bullet;
    
    RaycastHit2D detection;
    RaycastHit2D shoot;    

    public Transform sightSpot;

    [SerializeField] string currentTag;

    HealthManager healthManager;
    private GameObject gameManager;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();

        currentTag = gameObject.tag;

        walking = true;

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        healthManager = gameManager.GetComponent<HealthManager>();

        if (elite)
        {
            healthManager.health = elitesoldierHP;
        }
        else
        {
            healthManager.health = soldierHP;
        }

        if (Player1)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }


    void Update () {

        Deplacement();
        
        SearchAndDestroy();

        if (shooting)
        {
            Fire();
        }

	}

    void Deplacement()
    {
        if (walking)
        {
            rb.velocity = new Vector2(direction * soldierSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Detection()
    {
        detection = Physics2D.Raycast(sightSpot.position, new Vector2(detectionRange, 0));
    }

    private void SearchAndDestroy()
    {
        Detection();

        if (detection.collider)
        {
            if (detection.collider.tag == currentTag) //détecte si il y a qqun devant et identifie si c'est un ennemi ou un allié
            {
                walking = false;                 
            }
            else if (detection.collider.tag != currentTag)
            {
                walking = false;
                shooting = true;
            }
            else if (detection.collider == null)
            {
                walking = true;
            }
        }        
    }

    private void Fire()
    { 

        if (time <= 0)
        {            
            time = shootingtime;
            Instantiate(Bullet, sightSpot.position, sightSpot.rotation);
        }
        else 
        {
            time -= Time.deltaTime;
        }


       if (shoot.collider != null)
        {
            healthManager.TakeDamages(damage);
        }
    }

    /*private void Death()
    {
        if (healthManager.health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Die!");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Elite")
        {
            damage = elitesoldierDamages;
        }
        else
        {
            damage = soldierDamages;
        }

        healthManager.TakeDamages(damage);
        Destroy(collision.gameObject);
    }


}
