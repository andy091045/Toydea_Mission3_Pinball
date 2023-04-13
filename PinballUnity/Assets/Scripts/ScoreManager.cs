using AccelerateManagerNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreManagerNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        public ScoreManagerExtra controller;
        public int totalScore_ = 0;

        private void Awake()
        {
            Instance = this;
        }

    }

    public class ScoreManagerExtra
    {
        public int Add(object a, object b)
        {
            if (a is int && b is int) 
            {
                return (int)a + (int)b; 
            }else if(a is float || b is float)
            {
                throw new ArgumentException("Both parameters must be integers, not float");
            }
            else
            {
                throw new ArgumentException("Both parameters must be integers");
            }
        }
    }
}
