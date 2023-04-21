using GameManagerNamespace;
using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class PositionData
{
    public float x;
    public float y;
    public float z;

    public PositionData(Vector3 position)
    {
        x = position.x;
        y = position.y;
        z = position.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

public class SaveLocationList : TSingletonMonoBehavior<SaveLocationList>
{
    public GameObject Target;

    private List<PositionData> Positions = new List<PositionData>();

    public List<Vector3> PositionsVector3;

    private string savePath;

    private void Start()
    {
        savePath = Application.dataPath + "/StreamingAssets/positions.json";
        LoadPositions();
    }


    
    void Update()
    {
        AddPosition();
    }

    private void AddPosition()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PositionData target = new PositionData(Target.transform.position);

            if (!Positions.Contains(target))
            {
                Positions.Add(target);
                SaveRockPositions();
            }            
        }
    }
    private void SaveRockPositions()
    {
        string json = JsonUtility.ToJson(new SerializableList<PositionData>(Positions));
        File.WriteAllText(savePath, json);
    }

    private void LoadPositions()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SerializableList<PositionData> posList = JsonUtility.FromJson<SerializableList<PositionData>>(json);
            Positions = posList.ToList();
            ChangePositionDataToVector3();
        }
    } 

    private void ChangePositionDataToVector3()
    {
        foreach (PositionData item in Positions)
        {
            Vector3 v;
            v.x = item.x;
            v.y = item.y;
            v.z = item.z;
            PositionsVector3.Add(v);
        }
    }
    
}

[Serializable]
public class SerializableList<T>
{
    public List<T> list;

    public SerializableList(List<T> l)
    {
        list = l;
    }

    public List<T> ToList()
    {
        return list;
    }
}