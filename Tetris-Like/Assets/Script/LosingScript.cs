using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosingScript : MonoBehaviour {

    public Scene newtScene;

    private void OnDestroy()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
