using DG.Tweening;
using LifeManagerNamespace;
using MissionManagerNamespace;
using ScoreManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class MouthMove : MonoBehaviour
{

    [SerializeField] private Vector3[] targetPos_;

    void Start()
    {
        GameManager.Instance.onChangeStateStateEvent.AddListener(ListenStateChange);        
    }

    private void ListenStateChange(string name, string state)
    {
        if(state == "OnEnter")
        {
            switch (name)
            {
                case "Stage1":
                    gameObject.transform.DOMove(new Vector3(targetPos_[0].x, targetPos_[0].y, targetPos_[0].z), 0.1f);
                    break;
                case "Stage2":
                    gameObject.transform.DOMove(new Vector3(targetPos_[1].x, targetPos_[1].y, targetPos_[1].z), 5f);
                    break;
                case "Stage3":
                    gameObject.transform.DOMove(new Vector3(targetPos_[2].x, targetPos_[2].y, targetPos_[2].z), 5f);
                    break;
                default: 
                    break;

            }
        }
    }
}
