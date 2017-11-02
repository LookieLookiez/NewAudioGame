using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroduceColour : MonoBehaviour {
    public GameObject orbsScript;
    public bool done1;
    public bool done2;
    public bool done3;

    public Material mushMat;
    public Material tentMat;
    public Material plantMat;

    public Color mushroom = new Color(0, 202, 255);
    //Emiss values 
    public Color Tenticles = new Color(255, 133, 54);

    public Color Plants = new Color(168, 49, 231);

    public Color grey = new Color(144, 144, 144);
    // Use this for initialization
    void Start () {
        done1 = false;
        done2 = false;
        done3 = false;

        mushMat.color = grey;
        tentMat.color = grey;
        plantMat.color = grey;

    }
	
	// Update is called once per frame
	void Update () {
        if ((orbsScript.GetComponent<Orbs>().OrbsCollected >= 1) && !done1)
        {
            plantMat.color = Plants;
            done1 = true;
        }
        if ((orbsScript.GetComponent<Orbs>().OrbsCollected >= 2) && !done2)
        {
            tentMat.color = Tenticles;
            done2 = true;
        }
        if ((orbsScript.GetComponent<Orbs>().OrbsCollected >= 3) && !done3)
        {
            mushMat.color = mushroom;
            done3 = true;
        }

    }
}
