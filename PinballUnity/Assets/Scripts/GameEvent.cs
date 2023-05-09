using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    //AccelerateObject.cs
    public delegate void OccurAccelerateEventHandler(Vector3 addForce);
    public static OccurAccelerateEventHandler OccurAccelerate;

    //Ball.cs
    public delegate void BallFallOutEventHandler(int num, char pointer);
    public static BallFallOutEventHandler OccurBallFallOut;

    //BounceObject.cs
    public delegate void BounceAddScoreEventHandler(int score);
    public static BounceAddScoreEventHandler OccurBounceAddScore;

    public delegate void BouncePhysicEventHandler(Vector3 addForce);
    public static BouncePhysicEventHandler OccurBouncePhysic;

    //HeartObject.cs
    public delegate void OccurTriggerHeartEventHandler(GameObject obj);
    public static OccurTriggerHeartEventHandler OccurTriggerHeart;

    //LifeManager.cs
    public delegate void MissionLifeEventHandler(int life);
    public static MissionLifeEventHandler OccurLifeChange;

    //MissionManager.cs
    public delegate void MissionCompleteEventHandler(int score);
    public static MissionCompleteEventHandler OccurMissionCompleted;

    public delegate void HeartCompleteEventHandler(int number, char pointer);
    public static HeartCompleteEventHandler OccurHeartCompleted;

    public delegate void MissionExecuteEventHandler(int number, string des, int nextNumber, int score);
    public static MissionExecuteEventHandler OccurMissionExecute;

    public delegate void AllMissionCompletedEventHandler();
    public static AllMissionCompletedEventHandler AllMissionCompleted;

    //MissionObject.cs
    public delegate void OccurTriggerMissionObjectEventHandler(MissionObject obj);
    public static OccurTriggerMissionObjectEventHandler OccurTriggerMissionObject;

    //ScoreManager.cs
    public delegate void MissionScoreEventHandler(int score);
    public static MissionScoreEventHandler OccurAddScore;
}
