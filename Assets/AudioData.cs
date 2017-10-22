using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioData : MonoBehaviour {

    public static AudioData Instance;
    public AudioSource audioSource;

    private float[] samples = new float[512];
    private float[] freqBands = new float[8];
    private float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];
    float[] freqBandMax = new float[8];

    public float[] audioBand = new float[8];
    public float[] audioBandBuffer = new float[8];

    public float amplitude;
    public float amplitudeBuffer;
    public float ampHighest;

    void Start ()
    {
        Instance = this; 

    }

	void Update ()
    {
        if(audioSource != null)
        {
            GetSpectrumData();
            FrequencyBands();
            BandBuffer();
            CreateAudioBands();
            GetAmplitude();
        }
        
    }


    ////////////////////////////////////////////////////////////////
    ////////////////////////////Functions///////////////////////////
    ////////////////////////////////////////////////////////////////

    //Get the spectrum data from all samples
    void GetSpectrumData()
    {
        //ASk
        //IAN
        //IF
        //THIS
        //IS 
        //TERRIBLE
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if(freqBands[i] > freqBandMax[i])
            {
                freqBandMax[i] = freqBands[i];
            }
            audioBand[i] = (freqBands[i] / freqBandMax[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandMax[i]);
        }
    }

    //Split samples into frequency bands
    void FrequencyBands()
    {
        var size = 0;
        var average = 0f;

        for (int i = 0; i < 8; i++)
        {
            int sampleSize = (int)Mathf.Pow(2, i) * 2;

            if(i == 7)
            {
                sampleSize += 2;
            }

            for (int j = 0; j < sampleSize; j++)
            {
                average += samples[size] * (size + 1);
                size++;
                freqBands[i] = average * 10;
            }
        }
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if(freqBands[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBands[i];
                bufferDecrease[i] = 0.005f;
            }
            if(freqBands[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    void GetAmplitude()
    {
        float curAmp = 0;
        float curAmpBuffer = 0;

        for (int i = 0; i < 8; i++)
        {
            curAmp += audioBand[i];
            curAmpBuffer += audioBandBuffer[i];
        }
        if(curAmp > ampHighest)
        {
            ampHighest = curAmp;
        }
        amplitude = curAmp / ampHighest;
        amplitudeBuffer = curAmpBuffer / ampHighest;

    }
}
