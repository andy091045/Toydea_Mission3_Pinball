using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateManagerNamespace
{
    public class StateManager : MonoBehaviour
    {
        public StateBase CurrentState;
        private Dictionary<State_Enum, StateBase> status_ = new Dictionary<State_Enum, StateBase>();
        [SerializeField] private int score_ => GameInput.Instance.TotalScore;
        [SerializeField] private int lifeTimes_ => GameInput.Instance.Lifetimes;

        [SerializeField] private int[] ChanegeStateScore;

        [Header("Stage Trigger")]
        [SerializeField] private bool isStage1Trigger_ = false;
        [SerializeField] private bool isStage2Trigger_ = false;
        [SerializeField] private bool isStage3Trigger_ = false;
        [SerializeField] private bool isFinishTrigger_ = false;
        [SerializeField] private bool isWeddingTrigger_ = false;

        private void Start()
        {
            status_.Add(State_Enum.stage1, new Stage1(this));
            status_.Add(State_Enum.stage2, new Stage2(this));
            status_.Add(State_Enum.stage3, new Stage3(this));
            status_.Add(State_Enum.finish, new Finish(this));
            status_.Add(State_Enum.wedding, new Wedding(this));
            //start from stage1
            TransitionState(State_Enum.stage1);
        }

        void Update()
        {
            CurrentState.OnUpdate();

            StageDecide(score_);
        }

        public void StageDecide(int score)
        {
            if (score >= ChanegeStateScore[0] && score < ChanegeStateScore[1] && lifeTimes_ != 0)
            {
                TryTransitionState(State_Enum.stage2);
            }
            else if (score >= ChanegeStateScore[1] && score < ChanegeStateScore[2] && lifeTimes_ != 0)
            {
                //Debug.Log("â¡è„ìÔìxånìù");
                TryTransitionState(State_Enum.stage3);
            }else if (score >= ChanegeStateScore[2] && lifeTimes_ != 0)
            {
                TryTransitionState(State_Enum.wedding);
            }
            else if (lifeTimes_ == 0)
            {
                //Debug.Log("óVùEé∏îs");
                TryTransitionState(State_Enum.finish);
            }
        }

        public void TryTransitionState(State_Enum type)
        {
            switch (type)
            {
                case State_Enum.stage1:
                    if (isStage1Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage1Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.stage2:
                    if (isStage2Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage2Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.stage3:
                    if (isStage3Trigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isStage3Trigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.wedding:
                    if (isWeddingTrigger_)
                    {
                        break;
                    }
                    else
                    {
                        isWeddingTrigger_ = true;
                        TransitionState(type);
                    }
                    break;
                case State_Enum.finish:
                    if (isFinishTrigger_)
                    {
                        break;
                    }
                    else
                    {
                        //Debug.Log("Start " + type);
                        isFinishTrigger_ = true;
                        TransitionState(type);
                    }
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
        public void ReStart()
        {
            GameInput.Instance.TotalScore = 0;
            GameInput.Instance.Lifetimes = 5;
            SceneManager.LoadScene(0);
        }

        public enum State_Enum
        {
            stage1, stage2, stage3, finish, wedding
        }
    }
}

