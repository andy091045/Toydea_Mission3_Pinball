using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class MissionObject : TriggerObject
{
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
        GameManager.Instance.MissionManager.TriggerBall(Number, Description, NextNumber, Score, Position);
        Destroy(gameObject);
    }
}
