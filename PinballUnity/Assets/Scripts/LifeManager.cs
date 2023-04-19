using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LifeManagerNamespace
{
    public class LifeManager : MonoBehaviour
    {
        public int Lifetimes = 5;

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
            Debug.Log(Lifetimes);
        }
    }
}

