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
        public int MissionScore = 1000;

        public GameObject PositionData;              

        public List<Vector3> GetPositionVector3()
        {
            return PositionData.GetComponent<SaveLocationList>().PositionsVector3;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                ReStart();
            }
        }

        public void ReStart()
        {
            GameInput.Instance.TotalScore = 0;
            GameInput.Instance.Lifetimes = 5;
            SceneManager.LoadScene(0);
        }
    }
}
