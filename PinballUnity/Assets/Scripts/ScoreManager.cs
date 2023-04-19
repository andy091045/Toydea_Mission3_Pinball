using GameManagerNamespace;
using HD.Singleton;
using System;
using UnityEngine;

namespace ScoreManagerNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        public delegate void MissionScoreEventHandler(int score);
        public event MissionScoreEventHandler OccurAddScore;

        [SerializeField] private int TotalScore = 0;
        private void Start()
        {
            GameManager.Instance.MissionManager.MissionCompleted += TotalScoreAdd;
            GameManager.Instance.BounceManager.OccurBounceAddScore += TotalScoreAdd;
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

        public void TotalScoreAdd(int number, string des, int nextNumber, int score, Vector3 pos)
        {            
            TotalScore = Add(TotalScore, score);
            Debug.Log("ã`•ª: " + TotalScore);
            OccurAddScore(TotalScore);
        }

        public void TotalScoreAdd(int score)
        {
            TotalScore = Add(TotalScore, score);
            Debug.Log("ã`•ª: " + TotalScore);
            OccurAddScore(TotalScore);
        }

    }
}
