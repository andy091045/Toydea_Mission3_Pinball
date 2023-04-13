using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerNamespace
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// ­«¤O
        /// </summary>
        public float gravity_ = -25.0f;

        public static GameManager Instance;        

        void Awake()
        {
            Instance = this;
        }
    }
}
