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
using HD.FindObject;

public class UIManager : TSingletonMonoBehavior<UIManager>
{
    [Header("Stage1 Start Bar")]
    public Image[] Stage1Bar;
    public Image[] Stage2Bar;
    public Image[] Stage3Bar;

    public GameObject[] MickeyIcon;
    public Transform EndUI;
    

    public Text Score;
    public Text Des;
    public Text Life;
    private bool isAllComplete_ = false;

    [Header("EndのUI設定")]
    public GameObject[] EndingImage;
    Text EndScore;

    private void Awake()
    {
        Find find = new Find();
        //Find "EndScore GameObject"
        find.FindObject("EndScore", out EndScore);

        ScoreManager.OccurAddScore += ChangeScoreText;        
        LifeManager.OccurLifeChange += ChangeLifeText;
        MissionManager.OccurMissionExecute += ChangeMissionText;
        Stage1.OccurStage1 += Stage1State;
        Stage2.OccurStage2 += Stage2State;
        Stage3.OccurStage3 += Stage3State;
        Finish.OccurFinish += FinishState;
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
        EndScore.text = "ついに積分: " + score ;
        if(score >= GameInput.Instance.HiddenEndingScore)
        {
            EndingImage[0].SetActive(false);
            EndingImage[1].SetActive(true);
        }
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
            MickeyIcon[0].SetActive(true);
        }else if(state == "OnExit")
        {
            MickeyIcon[0].SetActive(false);
        }
    }
    private void Stage2State(string state)
    {
        if (state == "OnEnter")
        {
            DoTweenStageImageMoveIn(Stage2Bar);
            MickeyIcon[1].SetActive(true);
        }
        else if (state == "OnExit")
        {
            MickeyIcon[1].SetActive(false);
        }
    }
    private void Stage3State(string state)
    {
        if (state == "OnEnter")
        {
            DoTweenStageImageMoveIn(Stage3Bar);
            MickeyIcon[2].SetActive(true);
        }
        else if (state == "OnExit")
        {
            MickeyIcon[2].SetActive(false);
        }
    }

    private void FinishState(string state)
    {
        if(state == "OnEnter")
        {
            EndUI.DOMove(new Vector3(950, 530, 0), 1f).SetEase(Ease.OutBounce);
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
        sequence2.OnComplete(BallCanMove);
    }

    private void BallCanMove()
    {
        GameInput.Instance.BallCanMove = true;
    }

    private void OnDestroy()
    {
        ScoreManager.OccurAddScore -= ChangeScoreText;
        LifeManager.OccurLifeChange -= ChangeLifeText;
        MissionManager.OccurMissionExecute -= ChangeMissionText;
        MissionManager.AllMissionCompleted -= AllMissionCompleted;
        Stage1.OccurStage1 -= Stage1State;
        Stage2.OccurStage2 -= Stage2State;
        Stage3.OccurStage3 -= Stage3State;
        Finish.OccurFinish -= FinishState;
    }


}
