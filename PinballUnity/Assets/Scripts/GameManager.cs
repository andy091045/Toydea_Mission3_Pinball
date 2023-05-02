using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace GameManagerNamespace
{
    public class GameManager : TSingletonMonoBehavior<GameManager>
    {        
        public GameObject PositionData;              

        public List<Vector3> GetPositionVector3()
        {
            return PositionData.GetComponent<SaveLocationList>().PositionsVector3;
        }

        public UnityEvent<string, string> onChangeStateStateEvent = new UnityEvent<string, string>();

        private void Start()
        {
            GameInput.Instance.onReStartEvent.AddListener(ReStart);
        }

        public void ReStart()
        {
            GameInput.Instance.TotalScore = 0;
            GameInput.Instance.Lifetimes = 5;
            SceneManager.LoadScene(1);
        }

        public void AnnounceState(string name, string state)
        {
            onChangeStateStateEvent.Invoke(name, state);
        }

        private void OnDestroy()
        {
            onChangeStateStateEvent.RemoveAllListeners();
        }

    }
}
