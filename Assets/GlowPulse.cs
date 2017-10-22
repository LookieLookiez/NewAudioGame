using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowPulse : MonoBehaviour {
    public Material blueMat;
    public Material PinkMat;
    public Material LeavesMat;

    public int band;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(AudioData.Instance.amplitudeBuffer > 0.5f)
        {
            var EmisColour = new Color(blueMat.color.r, blueMat.color.g, blueMat.color.b) * AudioData.Instance.amplitudeBuffer;
            blueMat.SetColor("_EmissionColor", EmisColour);
        }

        if (AudioData.Instance.amplitudeBuffer > 0.5f)
        {
            var EmisColour = new Color(LeavesMat.color.r, LeavesMat.color.g, LeavesMat.color.b) * AudioData.Instance.amplitudeBuffer;
            LeavesMat.SetColor("_EmissionColor", EmisColour);
        }
        if (AudioData.Instance.audioBandBuffer[band] > 0.5f)
        {
            var EmisColour = new Color(PinkMat.color.r, PinkMat.color.g, PinkMat.color.b) * AudioData.Instance.audioBandBuffer[band];
            PinkMat.SetColor("_EmissionColor", EmisColour);
        }

    }
}
