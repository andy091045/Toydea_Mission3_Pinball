using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
using NaughtyAttributes;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameInput : TSingletonMonoBehavior<GameInput>
{
    public float Gravity = -150.0f;

    /// <summary>
    /// tag = "bounceObject_" MaxSpeed
    /// </summary>
    public float BounceMaxForce = 200.0f;

    /// <summary>
    /// tag = "bounceObject_" MinSpeed
    /// </summary>
    public float BounceMinForce = 150.0f;

    public float AccelerateForce = 300.0f;

    [Label("バウンススコア")]
    public int BounceScore = 10;

    public int TotalScore = 0;

    public int Lifetimes = 5;

    public int HiddenEndingScore = 20000;    

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

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
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
