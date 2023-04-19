using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : CollisionObject
{
    private int oneBounceScore_ => GameManager.Instance.BounceManager.oneBounceScore_;

    protected override void onCollisionEnterTag(Collision collision)
    {
        GameManager.Instance.BounceManager.CollideEnterBall(oneBounceScore_, collision);
    }
}
