using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlliesScript : MonoBehaviour {

    public GameObject alliePrefab;

    public float maxCooldown;
    private float cooldown, secondaryCooldown;

    private float maxUnitDispo = 5, unitDispo = 3;

    public bool isUsed;

    // Use this for initialization
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && unitDispo>0 && secondaryCooldown <= 0 && isUsed)
        {
            Instantiate(alliePrefab, transform.position, transform.rotation);
            cooldown = maxCooldown;
            secondaryCooldown = 0.1f;
            unitDispo--;
        }

        if(secondaryCooldown>0)
        {
            secondaryCooldown -= Time.deltaTime;
        }

        if(cooldown>0)
        {
            cooldown -= Time.deltaTime;
        }
        else if(unitDispo < maxUnitDispo)
        {
            cooldown = maxCooldown;
            unitDispo++;
        }

    }
}
