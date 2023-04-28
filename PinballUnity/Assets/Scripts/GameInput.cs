using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
using NaughtyAttributes;
using UnityEngine.Events;

public class GameInput : TSingletonMonoBehavior<GameInput>
{
    public float Gravity = -150.0f;

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

    public int HiddenEndingScore = 20000;

    public float AccelerateForce = 500.0f;

    public bool BallCanMove = true;

    public bool IsHeartMissionStart = false;

    

    //public class CustomEvent: UnityEvent<char>{}

    public UnityEvent onReStartEvent = new UnityEvent();
    public UnityEvent onShootPinballEvent = new UnityEvent();
    public UnityEvent onResetPlungerForceEvent = new UnityEvent();
    public UnityEvent onControlLeftArmEvent = new UnityEvent();
    public UnityEvent onControlRightArmEvent = new UnityEvent();

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            onReStartEvent.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onResetPlungerForceEvent.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            onShootPinballEvent.Invoke();
        }

        if (Input.GetKey(KeyCode.A))
        {
            onControlLeftArmEvent.Invoke();
        }

        if (Input.GetKey(KeyCode.D))
        {
            onControlRightArmEvent.Invoke();
        }
    }

    private void OnDestroy()
    {
        onReStartEvent.RemoveAllListeners();
        onShootPinballEvent.RemoveAllListeners();
        onResetPlungerForceEvent.RemoveAllListeners();
        onControlLeftArmEvent.RemoveAllListeners();
        onControlRightArmEvent.RemoveAllListeners();
    }
}
