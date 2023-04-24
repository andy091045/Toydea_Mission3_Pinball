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
using LifeManagerNamespace;
using UnityEngine.SceneManagement;

namespace GameManagerNamespace
{
    public class GameManager : TSingletonMonoBehavior<GameManager>
    {
        public BounceManager BounceManager { get; private set; }
        public MissionManager MissionManager { get; private set; }
        public ScoreManager ScoreManager { get; private set; }
        public LifeManager LifeManager { get; private set; }
        public StateManager StateManager { get; private set; }

        /// <summary>
        /// ｭｫ､O
        /// </summary>
        public float Gravity = -75.0f;

        public GameObject TaskPrefab;

        public GameObject HeartPrefab;

        public MissionData MissionData;

        [Label("バウンススコア")]
        public int BounceScore = 100;

        public int MissionScore = 1000;

        public GameObject PositionData;

        private GameObject BounceManagerGameObject;

        private GameObject MissionManagerGameObject;        

        private GameObject ScoreManagerGameObject;                   

        private GameObject LifeManagerGameObject;        

        private GameObject StateManagerGameObject;


        protected override void init()
        {
            BounceManagerGameObject = new GameObject("BounceManager");
            BounceManager = BounceManagerGameObject.AddComponent<BounceManager>();

            MissionManagerGameObject = new GameObject("MissionManager");
            MissionManager = MissionManagerGameObject.AddComponent<MissionManager>();
            MissionManager.MissionData = MissionData;
            MissionManager.TaskPrefab = TaskPrefab;
            MissionManager.HeartPrefab = HeartPrefab;

            ScoreManagerGameObject = new GameObject("ScoreManager");
            ScoreManager = ScoreManagerGameObject.AddComponent<ScoreManager>();

            StateManagerGameObject = new GameObject("StateManager");
            StateManager = StateManagerGameObject.AddComponent<StateManager>();

            LifeManagerGameObject = new GameObject("AccelerateManager");
            LifeManager = LifeManagerGameObject.AddComponent<LifeManager>();
        }

        public List<Vector3> GetPositionVector3()
        {
            return PositionData.GetComponent<SaveLocationList>().PositionsVector3;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                //print H return to the Scene "Home" 
                SceneManager.LoadScene(0);
            }
        }
    }
}
