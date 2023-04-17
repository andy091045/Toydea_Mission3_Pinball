using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutingMission : MonoBehaviour
{
    public int Number = 0;
    public string Description = "no";
    public int NextNumber = 0;
    public int Score = 0;
    public Vector3 Position = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            MissionManager.Instance.TriggerBall(Number, Description, NextNumber, Score, Position);
        }
        Destroy(gameObject);
    }
}
