using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowPulse2 : MonoBehaviour {
    public Material myMat;


    public int band;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            var EmisColour = new Color(myMat.color.r, myMat.color.g, myMat.color.b) * AudioData2.Instance.amplitudeBuffer;
            myMat.SetColor("_EmissionColor", EmisColour);
    }
    
}
