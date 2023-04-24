using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObject : TriggerObject
{
    public delegate void OccurTriggerMissionObjectEventHandler(MissionObject obj);
    public static OccurTriggerMissionObjectEventHandler OccurTriggerMissionObject;

    [Label("タスクコード")]
    public int Number = 0;

    [Label("説明")]
    public string Description = "no";

    [Label("次のタスクコード")]
    public int NextNumber = 0;

    [Label("分数")]
    public int Score = 0;

    [Label("位置")]
    public Vector3 Position = new Vector3(0, 0, 0);

    protected override void onTriggerEnterTag(Collider other)
    {
        OccurTriggerMissionObject(this);       
        Destroy(gameObject);
    }    
}
