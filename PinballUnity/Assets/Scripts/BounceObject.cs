using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : CollisionObject
{
    private int oneBounceScore_ => GameManager.Instance.BounceScore;

    protected override void onCollisionEnterTag(Collision collision)
    {
        GameManager.Instance.BounceManager.CollideEnterBall(oneBounceScore_, collision);
    }
}
