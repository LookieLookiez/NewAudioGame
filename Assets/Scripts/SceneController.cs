using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public string SoundCloudURL;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Z))
        {
            if (Application.loadedLevelName == "Menu")
            {
                Application.Quit();
            }

            if (Application.loadedLevelName == "Space")
            {
                Application.LoadLevel("Menu");
            }

            if (Application.loadedLevelName == "Nature")
            {
                Application.LoadLevel("Menu");
            }
        }
	}

    public void Space()
    {
        Application.LoadLevel("Space");
    }

    public void Nature()
    {
        Application.LoadLevel("Nature");
    }

    public void URL()
    {
        Application.OpenURL(SoundCloudURL);
    }

}
