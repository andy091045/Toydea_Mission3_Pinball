using GameManagerNamespace;
using HD.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissionManagerNamespace;
using ScoreManagerNamespace;
using LifeManagerNamespace;

public class UIManager : TSingletonMonoBehavior<UIManager>
{
    public Text Score;
    public Text Des;
    public Text Life;
    private bool isAllComplete_ = false;
    private void Awake()
    {
        ScoreManager.OccurAddScore += ChangeScoreText;        
        LifeManager.OccurLifeChange += ChangeLifeText;
        MissionManager.OccurMissionExecute += ChangeMissionText;
    }

    private void Start()
    {
        MissionManager.AllMissionCompleted += AllMissionCompleted;
    }

    private void AllMissionCompleted()
    {
        isAllComplete_ = true;
        Des.text = "All missions were completed !!!";
    }

    private void ChangeScoreText(int score)
    {
        Score.text = score + " ";
    }

    private void ChangeLifeText(int life)
    {
        Life.text = life + " ";
    }

    private void ChangeMissionText(int number, string des, int nextNumber, int score)
    {        
        if (!isAllComplete_)
        {            
            Des.text = "Mission" + number + ": " + des + " ";
        }        
    }
    private void OnDestroy()
    {
        ScoreManager.OccurAddScore -= ChangeScoreText;
        LifeManager.OccurLifeChange -= ChangeLifeText;
        MissionManager.OccurMissionExecute -= ChangeMissionText;
        MissionManager.AllMissionCompleted -= AllMissionCompleted;
    }
}
