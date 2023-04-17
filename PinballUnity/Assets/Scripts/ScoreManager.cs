using BounceManagerNamespace;
using HD.Singleton;
using System;
using UnityEngine;


namespace ScoreManagerNamespace
{
    public class ScoreManager : TSingletonMonoBehavior<ScoreManager>
    {
        public int TotalScore = 0;
        private void Start()
        {
            MissionManager.Instance.MissionCompleted += TotalScoreAdd;
            BounceManager.Instance.OccurBounce += TotalScoreAdd;
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
            Debug.Log(TotalScore);
        }

        public void TotalScoreAdd(int score)
        {
            TotalScore = Add(TotalScore, score);
            Debug.Log(TotalScore);
        }

    }
}
