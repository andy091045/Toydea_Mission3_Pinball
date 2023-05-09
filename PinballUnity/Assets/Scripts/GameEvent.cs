using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public delegate void OccurAccelerateEventHandler(Vector3 addForce);
    public static OccurAccelerateEventHandler OccurAccelerate;

    public delegate void BallFallOutEventHandler(int num, char pointer);
    public static BallFallOutEventHandler OccurBallFallOut;
}
