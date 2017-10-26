using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaColourFade : MonoBehaviour {

    public Image BlackFilter;
    public GameObject IntroSlide;

    public bool HideTitleCard;
    public bool HideBlackBackground;

    // Use this for initialization
    void Start () {

        HideTitleCard = false;
        HideBlackBackground = false;
        IntroSlide.SetActive(true);
        Invoke("BlackBackgroundBool", 2f);
        Invoke("TitleBool", 7.5f);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        HideTitle();
        BlackFadeIn();
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
            print(tempColor.a);
        }
       
    }

    void BlackFadeIn()
    {
        if (HideBlackBackground == true)
        {
            var tempColor = BlackFilter.color;

            tempColor.a -= .25f * Time.deltaTime;
            //  if (tempColor.a <= 0f)
            //   {
            //        tempColor.a = 0f;
            //    }

            BlackFilter.color = tempColor;
            print(tempColor.a);
        }
    }
}
