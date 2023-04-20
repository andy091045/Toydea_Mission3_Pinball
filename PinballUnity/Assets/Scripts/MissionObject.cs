using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class MissionObject : TriggerObject
{
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
        GameManager.Instance.MissionManager.TriggerBall(Number, Description, NextNumber, Score, Position);
        Destroy(gameObject);
    }
}
