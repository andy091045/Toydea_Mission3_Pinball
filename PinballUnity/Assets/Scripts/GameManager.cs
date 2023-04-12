using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagerNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public GameManagerExtra controller;

        

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


    }

    [Serializable]
    public class GameManagerExtra{
        /// <summary>
        /// ­«¤O
        /// </summary>
        public float Gravity = -25.0f;
    }

}
