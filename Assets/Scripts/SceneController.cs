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
        if (Application.loadedLevelName == "Menu")
        {
            Screen.lockCursor = false;
            Cursor.visible = true;
        }

		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.loadedLevelName == "Menu")
            {
                Application.Quit();
            }

            if (Application.loadedLevelName == "Space")
            {
                Cursor.visible = true;
                Application.LoadLevel("Menu");
            }

            if (Application.loadedLevelName == "Nature")
            {
                Cursor.visible = true;
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
