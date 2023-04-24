using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObject : TriggerObject
{
    public delegate void OccurTriggerMissionObjectEventHandler(MissionObject obj);
    public static OccurTriggerMissionObjectEventHandler OccurTriggerMissionObject;

    [Label("�^�X�N�R�[�h")]
    public int Number = 0;

    [Label("����")]
    public string Description = "no";

    [Label("���̃^�X�N�R�[�h")]
    public int NextNumber = 0;

    [Label("����")]
    public int Score = 0;

    [Label("�ʒu")]
    public Vector3 Position = new Vector3(0, 0, 0);

    protected override void onTriggerEnterTag(Collider other)
    {
        OccurTriggerMissionObject(this);       
        Destroy(gameObject);
    }    
}
