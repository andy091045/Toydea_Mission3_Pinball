using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : CollisionObject
{
    public delegate void BounceAddScoreEventHandler(int score);
    public static BounceAddScoreEventHandler OccurBounceAddScore;

    public delegate void BouncePhysicEventHandler(Collision collision);
    public static BouncePhysicEventHandler OccurBouncePhysic;
    [SerializeField] private int OneBounceScore_ => GameInput.Instance.BounceScore;

    protected override void onCollisionEnterTag(Collision collision)
    {
        OccurBounceAddScore(OneBounceScore_ );
        OccurBouncePhysic(collision);
    }
}
