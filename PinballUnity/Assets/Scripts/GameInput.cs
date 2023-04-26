using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
using NaughtyAttributes;

public class GameInput : TSingletonMonoBehavior<GameInput>
{
    public float Gravity = -75.0f;

    /// <summary>
    /// tag = "bounceObject_" MaxSpeed
    /// </summary>
    public float BounceMaxForce = 200;

    /// <summary>
    /// tag = "bounceObject_" MinSpeed
    /// </summary>
    public float BounceMinForce = 150;

    [Label("バウンススコア")]
    public int BounceScore = 10;

    public int TotalScore = 0;

    public int Lifetimes = 5;

    public bool BallCanMove = true;

    public bool IsHeartMissionStart = false;
}
