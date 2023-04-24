using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionManagerNamespace;

namespace LifeManagerNamespace
{
    public class LifeManager : MonoBehaviour
    {
        public int Lifetimes = 5;

        public delegate void MissionLifeEventHandler(int life);
        public event MissionLifeEventHandler OccurLifeChange;

        private void Start()
        {
            MissionManager.OccurHeartCompleted += LifeCount;
        }

        public void LifeCount(int num, char pointer)
        {
            switch (pointer)
            {
                case '+':
                    Lifetimes = Lifetimes + num;
                    break;
                case '-':
                    Lifetimes = Lifetimes - num;
                    break;
                default:
                    break;
            }
            OccurLifeChange(Lifetimes);
            Debug.Log("ê∂ñΩôîâ∫" + Lifetimes + "éü");
        }
    }
}

