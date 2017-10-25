using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[Serializable]
public class DataManager
{
    /// <summary>
    /// Returns yes if a save file at the designated path exists within the streaming assets
    /// </summary>
    public bool SaveDataFound (string _dataPath)
    {
        if (File.Exists(Application.streamingAssetsPath + _dataPath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Saves movement data to an external file
    /// </summary>
    public void SaveMovementDataList(AudioExportData _audioExportData, string _dataPath)
    {
        //Create the serializer
        XmlSerializer serializer = new XmlSerializer(typeof(AudioExportData));
        //Create the stream
        FileStream stream = new FileStream(Application.dataPath + _dataPath, FileMode.Create);
        Debug.Log("Saved data to: " + Application.dataPath + _dataPath);
        Debug.Log(_audioExportData.audioData.Count);
        //Saves the data
        serializer.Serialize(stream, _audioExportData);
        //Closes the stream
        stream.Close();

        
    }

    /// <summary>
    /// Loads movement data from an external file
    /// </summary>
    public AudioExportData LoadedMovementDataList(string _dataPath)
    {
        //Create the serializer
        XmlSerializer serializer = new XmlSerializer(typeof(AudioExportData));
        //Create the stream
        //FileStream stream = new FileStream(Application.streamingAssetsPath + _dataPath, FileMode.Open);

        FileStream stream = new FileStream(Application.dataPath + _dataPath, FileMode.Open);

        //Loads the data and applies it to the given leveldata
        AudioExportData movementDataList = serializer.Deserialize(stream) as AudioExportData;
        //Cloase the stream
        stream.Close();
        //Returns the new level data
        return movementDataList;
    }

    static DataManager instance = null;
    public static DataManager Instance {
        get { return (instance == null) ? (instance = new DataManager()) : instance; }
    }
}
