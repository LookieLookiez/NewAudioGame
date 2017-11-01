using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioData2 : MonoBehaviour {

    public static AudioData2 Instance;
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

   // public bool recording = true;
   // public bool saved = false;
    [HideInInspector] public List<AudioSampleSnapshot> recordedAudioData = new List<AudioSampleSnapshot>();
    AudioExportData audioExportData = new AudioExportData();

    void Start ()
    {
        Instance = this; 

    }

	void Update ()
    {
        if(audioSource != null)
        {
            
            FrequencyBands();
            BandBuffer();
            CreateAudioBands();
            GetAmplitude();
        }
    }

    private void FixedUpdate()
    {
        //if (recording)
      //  {
            if (audioSource != null)
            {
                GetSpectrumData();
               // RecordAudioData(samples);
            }
     //   }

        if(Input.GetKeyDown(KeyCode.Space))
        {
           // ExportAudioData();
        }

        //if (!audioSource.isPlaying && recordedAudioData.Count > 0)
        //{
        //    if(saved == false)
        //    {
        //        saved = true;
        //        ExportAudioData();
        //    }
        //}
        
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

    void RecordAudioData(float[] _sample)
    {
        AudioSampleSnapshot newSnapshot = new AudioSampleSnapshot();
        newSnapshot.sampleArray = _sample;
        recordedAudioData.Add(newSnapshot);
    }

    void ExportAudioData()
    {
        //recording = false;
        audioExportData.audioData = recordedAudioData;
        DataManager.Instance.SaveMovementDataList(audioExportData, "\\audioData.xml");
    }
}
