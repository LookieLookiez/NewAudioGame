using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour {

    public int FrameRate;

    void Awake()
    {
        Application.targetFrameRate = FrameRate;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
