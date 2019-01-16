using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnArmy : MonoBehaviour {

    public GameObject prefab;
    public List<int> armyCount;
    public List<int> greatArmyCount;

	// Use this for initialization
	void Start () {
        StartCoroutine(spawnArmy());
        for (int i = 0; i < 9; i++)
        {
            armyCount.Add(0);
        }
        for (int i = 0; i < 9; i++)
        {
            greatArmyCount.Add(0);
        }
    }
	
	IEnumerator spawnArmy()
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i<armyCount.Count-1; i++)
        {
            if(armyCount[i]>0)
            {
                armyCount[i]--;
                Instantiate(prefab, transform.position + 4 * Vector3.down + Vector3.up * i, Quaternion.identity);
            }
        }

        for (int i = 0; i < greatArmyCount.Count - 1; i++)
        {
            if (greatArmyCount[i] > 0)
            {
                greatArmyCount[i]--;
                Instantiate(prefab, transform.position + 4 * Vector3.down + Vector3.up * i, Quaternion.identity);
            }
        }

        StartCoroutine(spawnArmy());
    }
}
