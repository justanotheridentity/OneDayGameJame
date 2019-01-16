using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour {

    public List<SpawnAlliesScript> cameraIdList;

    private int currentCameraWanted = 0;

    public RawImage retoursCamera;
    public List<Texture> filmingCamera;

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeCamera(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeCamera(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ChangeCamera(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ChangeCamera(4);
        }
    }

    void ChangeCamera(int cameraVisee)
    {
        foreach(SpawnAlliesScript script in cameraIdList)
        {
            script.isUsed = false;
        }
        cameraIdList[cameraVisee].isUsed = true;
        retoursCamera.texture = filmingCamera[cameraVisee];
    }
}
