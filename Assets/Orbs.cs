using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {

    //Audio
    public AudioSource[] AudioTrackLayers;
    public int OrbsCollected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PickUp")
        {
            OrbsCollected += 1;
            if(OrbsCollected>=4)
            {
                OrbsCollected = 4;
            }
            Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        //Makes sure audio is muted
      //  AudioTrackLayers[0].volume = 0f;
      ///  AudioTrackLayers[1].volume = 0f;
      //  AudioTrackLayers[2].volume = 0f;
     //   AudioTrackLayers[3].volume = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        AudioLayerUpdate();
	}

     void AudioLayerUpdate()
    {
        //Sets Volume to 1
        AudioTrackLayers[0].volume = 1f;
        if (OrbsCollected >= 1)
        {
            AudioTrackLayers[1].volume = 1f;
            if (OrbsCollected >= 2)
            {
                AudioTrackLayers[2].volume = 1f;
                if (OrbsCollected >= 3)
                {
                    AudioTrackLayers[3].volume = 1f;
                }                
            }
        }
    }
}
