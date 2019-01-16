using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnScript : MonoBehaviour {

    public GrilleScript grille;
    private SpawnForm randomForm;

    public List<GameObject> prefabForm;

    public bool isPlayerOne = true;

    private void Start()
    {
        randomForm = GetComponent<SpawnForm>();
        spawning();
    }

    public void spawning()
    {
        GameObject gameObj;
        gameObj = Instantiate(prefabForm[Mathf.RoundToInt(Random.Range(0,4))], transform.position, Quaternion.identity);
        gameObj.GetComponent<DeplacementFormScript>().grille = grille;
        gameObj.GetComponent<DeplacementFormScript>().isPlayerOne = isPlayerOne;
        gameObj.GetComponent<DeplacementFormScript>().spawn=gameObject.GetComponent<TestSpawnScript>();
    }
}
