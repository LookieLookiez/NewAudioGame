using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTimer : MonoBehaviour {

    public float SceneTimer;
    
    // Use this for initialization
	void Start ()
    {
        if (Application.loadedLevelName == "Space")
        {
            SceneTimer = 242.4f;
        }
        if (Application.loadedLevelName == "Nature")
        {
            SceneTimer = 285.2f;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		if(Application.loadedLevelName == "Space")
        {
            Space();
        }

        if (Application.loadedLevelName == "Nature")
        {
            Nature();
        }
    }

    void Space()
    {
        SceneTimer -= Time.deltaTime;
        if (SceneTimer <= 0f)
        {
            Application.LoadLevel("Nature");
        }
    }

    void Nature()
    {
        SceneTimer -= Time.deltaTime;
        if (SceneTimer <= 0f)
        {
            Application.LoadLevel("Space");
        }
    }
}
