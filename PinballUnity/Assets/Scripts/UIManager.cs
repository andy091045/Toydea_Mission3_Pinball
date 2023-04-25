using GameManagerNamespace;
using HD.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MissionManagerNamespace;
using ScoreManagerNamespace;
using LifeManagerNamespace;
using DG.Tweening;
using UnityEditor.SceneManagement;

public class UIManager : TSingletonMonoBehavior<UIManager>
{
    [Header("Stage1 Start Bar")]
    public Image[] Stage1Bar;
    public Image[] Stage2Bar;
    public Image[] Stage3Bar;

    public Text Score;
    public Text Des;
    public Text Life;
    private bool isAllComplete_ = false;

    private void Awake()
    {
        ScoreManager.OccurAddScore += ChangeScoreText;        
        LifeManager.OccurLifeChange += ChangeLifeText;
        MissionManager.OccurMissionExecute += ChangeMissionText;
        Stage1.OccurStage1 += Stage1State;
    }

    private void Start()
    {
        MissionManager.AllMissionCompleted += AllMissionCompleted;
        //DoTweenStageImageMoveIn(Stage1Bar);       
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

    private void Stage1State(string state)
    {
        if (state == "OnEnter")
        {
            DoTweenStageImageMoveIn(Stage1Bar);
        }
    }

    private void DoTweenStageImageMoveIn(Image[] stage)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(stage[0].rectTransform.DOMove(new Vector3(1000, 200, 0), 1f));
        sequence.AppendInterval(1);
        sequence.Append(stage[0].rectTransform.DOMove(new Vector3(-1000, 200, 0), 1f));

        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(stage[1].rectTransform.DOMove(new Vector3(1300, 500, 0), 1f).SetEase(Ease.OutBounce));
        sequence2.AppendInterval(1);
        sequence2.Append(stage[1].rectTransform.DOMove(new Vector3(-1000, 200, 0), 1f));
    }

    private void OnDestroy()
    {
        ScoreManager.OccurAddScore -= ChangeScoreText;
        LifeManager.OccurLifeChange -= ChangeLifeText;
        MissionManager.OccurMissionExecute -= ChangeMissionText;
        MissionManager.AllMissionCompleted -= AllMissionCompleted;
        Stage1.OccurStage1 -= Stage1State;
    }


}
