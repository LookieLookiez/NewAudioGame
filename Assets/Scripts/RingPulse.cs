using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPulse : MonoBehaviour {
    public GameObject rings1;
    public GameObject rings2;
    public GameObject rings3;
    public GameObject rings4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var scale = new Vector3(AudioData.Instance.amplitudeBuffer, 1, AudioData.Instance.amplitudeBuffer);
        rings1.transform.localScale = scale;

        var scale2 = new Vector3(AudioData1.Instance.amplitudeBuffer, 1, AudioData1.Instance.amplitudeBuffer);
        rings2.transform.localScale = scale2;

        var scale3 = new Vector3(AudioData2.Instance.amplitudeBuffer, 1, AudioData2.Instance.amplitudeBuffer);
        rings3.transform.localScale = scale3;

        var scale4 = new Vector3(AudioData3.Instance.amplitudeBuffer, 1, AudioData3.Instance.amplitudeBuffer);
        rings4.transform.localScale = scale4;
    }
}
