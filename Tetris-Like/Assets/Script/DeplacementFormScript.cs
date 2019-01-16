using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementFormScript : MonoBehaviour {

    public List<GameObject> blockChild;
    public GrilleScript grille;

    bool blockDetected = false;
    public bool isPlayerOne = true;

    private int direction;
    public TestSpawnScript spawn;


    // Use this for initialization
    void Start () {
        if(isPlayerOne)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        foreach(Transform child in transform)
        {
            blockChild.Add(child.gameObject);
            child.gameObject.GetComponent<BlockScript>().direction = direction;
        }
        StartCoroutine(DeplacementForme(0.75f));
	}

    private void Update()
    {
        bool blockedArea = false;
        if(((Input.GetKeyDown(KeyCode.Z)&&isPlayerOne) || (Input.GetKeyDown(KeyCode.UpArrow) && !isPlayerOne)) && !blockDetected)
        {
            foreach (GameObject child in blockChild)
            {
                if (child.GetComponent<BlockScript>().DetectionDeCote(1))
                {
                    blockedArea = true;
                }
            }
            if (!blockedArea)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                foreach (GameObject child in blockChild)
                {
                    child.GetComponent<BlockScript>().position = new Vector2(child.GetComponent<BlockScript>().position.x, child.GetComponent<BlockScript>().position.y + 1);
                }
            }
        }
        if (((Input.GetKeyDown(KeyCode.S) && isPlayerOne) || (Input.GetKeyDown(KeyCode.DownArrow) && !isPlayerOne)) && !blockDetected)
        {
            foreach (GameObject child in blockChild)
            {
                if (child.GetComponent<BlockScript>().DetectionDeCote(-1))
                {
                    blockedArea = true;
                }
            }
            if (!blockedArea)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                foreach (GameObject child in blockChild)
                {
                    child.GetComponent<BlockScript>().position = new Vector2(child.GetComponent<BlockScript>().position.x, child.GetComponent<BlockScript>().position.y - 1);
                }
            }
        }

        if(((Input.GetKeyDown(KeyCode.E) && isPlayerOne) || (Input.GetKeyDown(KeyCode.Keypad1) && !isPlayerOne)) && !blockDetected)
        {
            bool canRotate = true;
            foreach (GameObject child in blockChild)
            {
                if (child.GetComponent<BlockScript>().DetectionBlock() && child.GetComponent<BlockScript>().DetectionDeCote(1) && child.GetComponent<BlockScript>().DetectionDeCote(-1))
                {
                    canRotate = false;
                }
            }
            Debug.Log(canRotate);
            if(canRotate)
            {
                foreach (GameObject child in blockChild)
                {
                    child.GetComponent<BlockScript>().Rotate(child.transform.localPosition, transform.position);
                }
            }
        }
    }

    IEnumerator DeplacementForme(float tempsDeplacement)
    {
        
        yield return new WaitForSeconds(tempsDeplacement);
        foreach(GameObject child in blockChild)
        {
            if(child.GetComponent<BlockScript>().DetectionBlock())
            {
                foreach (GameObject block in blockChild)
                {
                    grille.UpdateGrille(block.GetComponent<BlockScript>().position, block);
                }
                blockDetected = true;
            }
        }
        if (!blockDetected)
        {
            transform.position = new Vector2(Mathf.RoundToInt(transform.position.x + direction), Mathf.RoundToInt(transform.position.y));
            foreach (GameObject child in blockChild)
            {
                child.GetComponent<BlockScript>().position.x = child.GetComponent<BlockScript>().position.x + direction;
            }
            StartCoroutine(DeplacementForme(tempsDeplacement));
        }
        if(blockDetected)
        {
            spawn.spawning();
        }
    }
}
