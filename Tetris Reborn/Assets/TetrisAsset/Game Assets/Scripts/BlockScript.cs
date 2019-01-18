using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockScript : MonoBehaviour {

    public List<Sprite> spriteList;
    public int type;

    private void Awake()
    {
        type = Random.Range(0, 4);
        if (spriteList[type] != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[type];
        }
        else
        {
            type = 1;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[type];
        }
    }

    public void estDetruit()
    {
        PlayerSoldierSpawn.addSoldier((int)transform.position.y, type);
    }

}
