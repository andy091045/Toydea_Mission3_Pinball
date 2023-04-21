using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using MissionNamespace;
using HD.Singleton;
using GameManagerNamespace;
using NaughtyAttributes;
using Codice.Client.BaseCommands;
using UnityEngine.UIElements;

namespace MissionManagerNamespace
{    public class MissionManager : MonoBehaviour
    {
        public GameObject HeartPrefab;
        public GameObject TaskPrefab;
        public MissionData MissionData;
        public bool IsHeartMissionStart = false;
        public bool IsStage3MissionStart = false;
        public bool IsStage4MissionStart = false;

        //public List<Mission> completedMissions_ = new List<Mission>();
        public const int COMPLETE_NUMBER = 999999;

        List<Mission> mission_ = new List<Mission>();
        List<Mission> activeMissions_ = new List<Mission>();

        public delegate void MissionCompleteEventHandler(int number, string des, int nextNumber, int score, Vector3 pos);
        public event MissionCompleteEventHandler OccurMissionCompleted;

        public delegate void HeartCompleteEventHandler(int number, char pointer);
        public event HeartCompleteEventHandler OccurHeartCompleted;

        public delegate void MissionExecuteEventHandler(int number, string des, int nextNumber, int score);
        public event MissionExecuteEventHandler OccurMissionExecute;

        public bool isAllMissionComplete = false;

        public MissionObject MissionClass;

        [Label("最小ビルド時間")]
        [SerializeField] private const float CREATE_TIME_MIN = 1.0f;

        [Label("最大ビルド時間")]
        [SerializeField] private const float CREATE_TIME_MAX = 2.0f;

        private List<Vector3> positions_ => GameManager.Instance.GetPositionVector3();

        private List<Vector3> positionsIsNotCreated_ = new List<Vector3>();

        private List<Vector3> positionsIsCreated_ = new List<Vector3>();

        private bool isCreatingHeart = false;

        private Vector3 pos;

        void Start()
        {
            positionsIsNotCreated_ = positions_;

            // ﾅｪｨ・MissionData ､､ｪｺ･�ｰﾈｸ・ﾆ
            Mission[] missions = MissionData.Missions;

            // ｱN･�ｰﾈｸ・ﾆ･[､J activeMissions List
            foreach (Mission mission in missions)
            {
                activeMissions_.Add(mission);
                mission_.Add(mission);
            }

            ExecuteMission(mission_[0].Number);
        }

        private void Update()
        {
            HeartMission();
        }

        public void ExecuteMission(int number)
        {
            // ･ﾍｦｨ･�ｰﾈｪｫ･・
            GameObject executingObject_ = Instantiate(TaskPrefab, mission_[number].Position, Quaternion.identity);
            MissionClass = executingObject_.GetComponent<MissionObject>();
            MissionClass.Number = mission_[number].Number;
            MissionClass.Description = mission_[number].Description;
            MissionClass.NextNumber = mission_[number].NextNumber;
            MissionClass.Score = mission_[number].Score;
            MissionClass.Position = mission_[number].Position;
        
            OccurMissionExecute(MissionClass.Number, MissionClass.Description, MissionClass.NextNumber, MissionClass.Score);
            
            // ｱN･�ｰﾈ･[､J･�ｰﾈｲMｳ・
            //missions.Add(mission);
        }


        public void CompleteMission(int number)
        {
            if (mission_[number].NextNumber != COMPLETE_NUMBER)
            {
                ExecuteMission(mission_[number].NextNumber);
            }

            for (int i = 0; i < activeMissions_.Count; i++)
            {
                if (activeMissions_[i].Number == number)
                {
                    //completedMissions_.Add(mission_[number]);
                    activeMissions_.Remove(mission_[number]);
                }
            }

            if (activeMissions_.Count == 0)
            {
                // ｩﾒｦｳ･�ｰﾈｳ｣､wｧｹｦｨ
                isAllMissionComplete = true;
                Debug.Log("All missions completed!");
            }
        }

        public void TriggerBall(int number, string des, int nextNumber, int score, Vector3 pos)
        {
            if (OccurMissionCompleted != null)
            {
                OccurMissionCompleted(number, des, nextNumber, score, pos);
            }
            if (number != COMPLETE_NUMBER)
            {
                CompleteMission(number);
            }
        }

        public void TriggerHeart(int num, char pointer)
        {
            if(OccurHeartCompleted != null)
            {
                OccurHeartCompleted(num, pointer);
            }
        }

        
        private void HeartMission()
        {
            if (IsHeartMissionStart && !isCreatingHeart && positionsIsNotCreated_.Count !=0 )
            {
                isCreatingHeart = true;
                Debug.Log("開始禮物系統");
                float createTime = Random.Range(CREATE_TIME_MIN, CREATE_TIME_MAX) ;
                int i = Random.Range(0, positionsIsNotCreated_.Count);
                pos = positionsIsNotCreated_[i];
                positionsIsNotCreated_.Remove(positionsIsNotCreated_[i]);                
                Debug.Log("positionsIsNotCreated_.Count: " + positionsIsNotCreated_.Count);
                foreach (Vector3 position in positionsIsNotCreated_)
                {
                    Debug.Log(position);
                }
                Debug.Log("------------------------------");
                positionsIsCreated_.Add(pos);
                Invoke("WaitAndCreate", createTime);
            }
        }
        
        public void ReturnPosition(Vector3 pos)
        {
            positionsIsCreated_.Remove(pos);
            positionsIsNotCreated_.Add(pos);
        }

        private void WaitAndCreate()
        {
            Instantiate(HeartPrefab, pos, Quaternion.identity);
            isCreatingHeart = false;
         }

    }
}


