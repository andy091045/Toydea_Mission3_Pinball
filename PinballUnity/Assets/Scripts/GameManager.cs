using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using UnityEngine.SceneManagement;

namespace GameManagerNamespace
{
    public class GameManager : TSingletonMonoBehavior<GameManager>
    {        
        public StateManager StateManager { get; private set; }

        public int MissionScore = 1000;

        public GameObject PositionData;                

        private GameObject StateManagerGameObject;


        protected override void init()
        {
            StateManagerGameObject = new GameObject("StateManager");
            StateManager = StateManagerGameObject.AddComponent<StateManager>();
        }

        public List<Vector3> GetPositionVector3()
        {
            return PositionData.GetComponent<SaveLocationList>().PositionsVector3;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                GameInput.Instance.TotalScore = 0;
                //print H return to the Scene "Home" 
                SceneManager.LoadScene(0);
            }
        }
    }
}
