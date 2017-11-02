using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaColourFade : MonoBehaviour {

    public Image BlackFilter;
    public GameObject IntroSlide;

    public bool HideTitleCard;
    public bool HideBlackBackground;

    public float SceneTimer;
    public bool FadeAway;

    // Use this for initialization
    void Start () {

        HideTitleCard = false;
        HideBlackBackground = false;
        IntroSlide.SetActive(true);
        Invoke("BlackBackgroundBool", 2f);
        Invoke("TitleBool", 7.5f);

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
        HideTitle();

        BlackFadeIn();

        SceneTimer -= Time.deltaTime;
    }

    void BlackBackgroundBool()
    {
        HideBlackBackground = true;
    }

    void TitleBool()
    {
        HideTitleCard = true;
    }

    void HideTitle()
    {
        if (HideTitleCard == true)
        {
            var tempColor = IntroSlide.gameObject.GetComponent<Text>().color;

            tempColor.a -= .6f * Time.deltaTime;
            //if (tempColor.a <= 0f)
            //  {
            //     tempColor.a = 0f;
            //  }

            IntroSlide.gameObject.GetComponent<Text>().color = tempColor;

        }
       
    }

    void BlackFadeIn()
    {
        var tempColor = BlackFilter.color;

        if (HideBlackBackground == true)
        {
            tempColor.a -= .25f * Time.deltaTime;
            //  if (tempColor.a <= 0f)
            //   {
            //        tempColor.a = 0f;
            //    }

            BlackFilter.color = tempColor;

            if(SceneTimer <= 5)
            {
                HideBlackBackground = false;
            }
        }

        if(HideBlackBackground == false)
        {
            tempColor.a += .25f * Time.deltaTime;
            //  if (tempColor.a <= 0f)
            //   {
            //        tempColor.a = 0f;
            //    }

            BlackFilter.color = tempColor;
        }
    }
    /*
    void ExitSceneBool()
    {
        HideBlackBackground = false;
        FadeAway = true;
        
    }

    void ExitScene()
    {
        if (FadeAway == true)
        {
            var tempColor = BlackFilter.color;

            tempColor.a += .25f * Time.deltaTime;
            //  if (tempColor.a <= 0f)
            //   {
            //        tempColor.a = 0f;
            //    }

            BlackFilter.color = tempColor;
        }
    }
    */
}
