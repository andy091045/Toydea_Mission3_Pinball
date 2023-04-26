using DG.Tweening;
using LifeManagerNamespace;
using MissionManagerNamespace;
using ScoreManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthMove : MonoBehaviour
{

    [SerializeField] private Vector3[] targetPos_;

    void Start()
    {
        Stage1.OccurStage1 += Stage1State;
        Stage2.OccurStage2 += Stage2State;
        Stage3.OccurStage3 += Stage3State;
    }
    private void Stage1State(string state)
    {
        if (state == "OnEnter")
        {
            gameObject.transform.DOMove(new Vector3(targetPos_[0].x, targetPos_[0].y, targetPos_[0].z), 0.1f);
        }
    }
    private void Stage2State(string state)
    {
        if (state == "OnEnter")
        {
            gameObject.transform.DOMove(new Vector3(targetPos_[1].x, targetPos_[1].y, targetPos_[1].z), 5f);
        }
    }
    private void Stage3State(string state)
    {
        if (state == "OnEnter")
        {
            gameObject.transform.DOMove(new Vector3(targetPos_[2].x, targetPos_[2].y, targetPos_[2].z), 5f);
        }
    }

    private void OnDestroy()
    {
        Stage1.OccurStage1 -= Stage1State;
        Stage2.OccurStage2 -= Stage2State;
        Stage3.OccurStage3 -= Stage3State;
    }
}
