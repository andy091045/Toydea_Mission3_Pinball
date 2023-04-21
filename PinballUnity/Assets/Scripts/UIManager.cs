using GameManagerNamespace;
using HD.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : TSingletonMonoBehavior<UIManager>
{
    public Text Score;
    public Text Des;
    public Text Life;
    private bool isAllComplete_ => GameManager.Instance.MissionManager.isAllMissionComplete;
    private void Awake()
    {
        GameManager.Instance.ScoreManager.OccurAddScore += ChangeScoreText;
        GameManager.Instance.MissionManager.OccurMissionExecute += ChangeMissionText;
        GameManager.Instance.LifeManager.OccurLifeChange += ChangeLifeText;
    }

    private void Update()
    {
        if (isAllComplete_)
        {
            Des.text = "All missions completed!";
        }
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
}
