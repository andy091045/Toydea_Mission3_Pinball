using HD.Singleton;
using System;
using UnityEngine;
using MissionManagerNamespace;

namespace ScoreManagerNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        public int TotalScore
        {
            get => GameInput.Instance.TotalScore;
            set => GameInput.Instance.TotalScore = value;
        }

        private void Awake()
        {
            GameEvent.OccurMissionCompleted += TotalMissionScoreAdd;
            GameEvent.OccurBounceAddScore += TotalBounceScoreAdd;
        }

        public int Add(object a, object b)
        {
            if (a is int && b is int)
            {
                return (int)a + (int)b;
            }
            else if (a is float || b is float)
            {
                throw new ArgumentException("Both parameters must be integers, not float");
            }
            else
            {
                throw new ArgumentException("Both parameters must be integers");
            }
        }

        public void TotalMissionScoreAdd(int score)
        {
            TotalScore = Add(TotalScore, score);
            //Debug.Log("ã`•ª: " + TotalScore);
            GameEvent.OccurAddScore(TotalScore);
        }

        public void TotalBounceScoreAdd(int score)
        {
            TotalScore = Add(TotalScore, score);
            //Debug.Log("ã`•ª: " + TotalScore);
            GameEvent.OccurAddScore(TotalScore);
        }

        private void OnDestroy()
        {
            GameEvent.OccurMissionCompleted -= TotalMissionScoreAdd;
            GameEvent.OccurBounceAddScore -= TotalBounceScoreAdd;
        }
    }
}
