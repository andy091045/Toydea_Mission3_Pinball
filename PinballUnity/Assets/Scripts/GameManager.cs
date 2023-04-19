using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BounceManagerNamespace;
using MissionManagerNamespace;
using MissionNamespace;
using ScoreManagerNamespace;
using AccelerateManagerNamespace;
using NaughtyAttributes;
using StateManagerNamespace;

namespace GameManagerNamespace
{
    public class GameManager : TSingletonMonoBehavior<GameManager>
    {
        private GameObject BounceManagerGameObject;
        public BounceManager BounceManager { get; private set; }


        private GameObject MissionManagerGameObject;
        public MissionManager MissionManager { get; private set; }

        private GameObject ScoreManagerGameObject;
        public ScoreManager ScoreManager { get; private set; }

        private GameObject AccelerateManagerGameObject;
        public AccelerateManager AccelerateManager { get; private set; }

        private GameObject StateManagerGameObject;
        public StateManager StateManager { get; private set; }
        /// <summary>
        /// ｭｫ､O
        /// </summary>
        public float Gravity = -50.0f;        

        public GameObject TaskPrefab;

        public MissionData MissionData;

        [Label("バウンススコア")]
        public int BounceScore = 100;

        public int MissionScore = 1000;

        protected override void init()
        {
            StateManagerGameObject = new GameObject("StateManager");
            StateManager = StateManagerGameObject.AddComponent<StateManager>();

            BounceManagerGameObject = new GameObject("BounceManager");
            BounceManager = BounceManagerGameObject.AddComponent<BounceManager>();

            MissionManagerGameObject = new GameObject("MissionManager");
            MissionManager = MissionManagerGameObject.AddComponent<MissionManager>();
            MissionManager.MissionData = MissionData;
            MissionManager.TaskPrefab = TaskPrefab;

            ScoreManagerGameObject = new GameObject("ScoreManager");
            ScoreManager = ScoreManagerGameObject.AddComponent<ScoreManager>();

            AccelerateManagerGameObject = new GameObject("AccelerateManager");
            AccelerateManager = AccelerateManagerGameObject.AddComponent<AccelerateManager>();
        }
    }
}
