using AccelerateManagerNamespace;
using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreManagerNamespace
{
    public class ScoreManager : TSingletonMonoBehavior<ScoreManager>
    {
        public int TotalScore = 0;

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

        public void TotalScoreAdd(int score)
        {
            TotalScore = Add(TotalScore, score);
        }

    }
}
