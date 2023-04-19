using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateManagerNamespace
{
    public class StateManager : MonoBehaviour
    {
        public IState CurrentState;

        private Dictionary<State_Enum, IState> status_ = new Dictionary<State_Enum, IState>();
        private float Score = GameManager.Instance.ScoreManager.TotalScore;
        private void Awake()
        {
            status_.Add(State_Enum.stage1, new Stage1(this));
            status_.Add(State_Enum.stage2, new Stage2(this));
            status_.Add(State_Enum.stage3, new Stage3(this));
            status_.Add(State_Enum.stage4, new Stage4(this));

            //start from stage1
            TransitionState(State_Enum.stage1);
        }

        void Update()
        {
            CurrentState.OnUpdate();

            switch (Score)
            {
                case 5000:
                    Debug.Log("‰Áã‰ñ•œŒŒ—ÊŒn“");
                    TransitionState(State_Enum.stage2);
                    break;
                case 10000:
                    Debug.Log("‰Áã“ï“xŒn“");
                    TransitionState(State_Enum.stage3);
                    break;
                case 20000:
                    Debug.Log("‰Áã•ÄŠï‰õ•ñœEŒn“");
                    TransitionState(State_Enum.stage4);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// switch State
        /// </summary>
        public void TransitionState(State_Enum type)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }
            CurrentState = status_[type];
            CurrentState.OnEnter();
        }

        public enum State_Enum
        {
            stage1, stage2, stage3, stage4
        }
    }
}

