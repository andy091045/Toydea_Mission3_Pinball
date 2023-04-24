using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MissionManagerNamespace;
using MissionNamespace;
using ScoreManagerNamespace;
using StateManagerNamespace;
using LifeManagerNamespace;
using UnityEngine.SceneManagement;

namespace GameManagerNamespace
{
    public class GameManager : TSingletonMonoBehavior<GameManager>
    {        
        public MissionManager MissionManager { get; private set; }
        public ScoreManager ScoreManager { get; private set; }
        public LifeManager LifeManager { get; private set; }
        public StateManager StateManager { get; private set; }

        public GameObject TaskPrefab;

        public GameObject HeartPrefab;

        public MissionData MissionData;        

        public int MissionScore = 1000;

        public GameObject PositionData;

        private GameObject MissionManagerGameObject;        

        private GameObject ScoreManagerGameObject;                   

        private GameObject LifeManagerGameObject;        

        private GameObject StateManagerGameObject;


        protected override void init()
        {
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
