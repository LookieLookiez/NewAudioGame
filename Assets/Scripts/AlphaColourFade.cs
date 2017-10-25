using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaColourFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Color color = renderer.material.color;
        color.a -= 0.1f;
        renderer.material.color = color;
    }
}
