using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionManagerNamespace;
using BallNamespace;

namespace LifeManagerNamespace
{
    public class LifeManager : MonoBehaviour
    {
        private int Lifetimes
        {
            get => GameInput.Instance.Lifetimes;
            set => GameInput.Instance.Lifetimes = value;
        }         

        private void Awake()
        {
            GameEvent.OccurHeartCompleted += LifeAdd;
            GameEvent.OccurBallFallOut += LifeDecrease;
        }


        public void LifeDecrease(int num, char pointer)
        {
            LifeCount(num, pointer);
        }

        public void LifeAdd(int num, char pointer)
        {
            LifeCount(num, pointer);
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
            GameEvent.OccurLifeChange(Lifetimes);
            Debug.Log("ê∂ñΩôîâ∫" + Lifetimes + "éü");
        }

        private void OnDestroy()
        {
            GameEvent.OccurHeartCompleted -= LifeAdd;
            GameEvent.OccurBallFallOut -= LifeDecrease;
        }
    }
}

