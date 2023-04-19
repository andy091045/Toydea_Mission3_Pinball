using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using MissionNamespace;
using HD.Singleton;

namespace MissionManagerNamespace
{    public class MissionManager : MonoBehaviour
    {
        public GameObject TaskPrefab;
        public MissionData MissionData;

        //public List<Mission> completedMissions_ = new List<Mission>();
        public const int COMPLETE_NUMBER = 999999;

        List<Mission> mission_ = new List<Mission>();
        List<Mission> activeMissions_ = new List<Mission>();

        public delegate void MissionCompleteEventHandler(int number, string des, int nextNumber, int score, Vector3 pos);
        public event MissionCompleteEventHandler MissionCompleted;

        public delegate void MissionExecuteEventHandler(int number, string des, int nextNumber, int score);
        public event MissionExecuteEventHandler OccurMissionExecute;

        public bool isAllMissionComplete = false;

        public ExecutingMission MissionClass;
        void Start()
        {
            // ﾅｪｨ・MissionData ､､ｪｺ･ﾈｸ・ﾆ
            Mission[] missions = MissionData.Missions;

            // ｱN･ﾈｸ・ﾆ･[､J activeMissions List
            foreach (Mission mission in missions)
            {
                activeMissions_.Add(mission);
                mission_.Add(mission);
            }

            ExecuteMission(mission_[0].Number);
        }

        public void ExecuteMission(int number)
        {
            // ･ﾍｦｨ･ﾈｪｫ･・
            GameObject executingObject_ = Instantiate(TaskPrefab, mission_[number].Position, Quaternion.identity);
            MissionClass = executingObject_.GetComponent<ExecutingMission>();
            MissionClass.Number = mission_[number].Number;
            MissionClass.Description = mission_[number].Description;
            MissionClass.NextNumber = mission_[number].NextNumber;
            MissionClass.Score = mission_[number].Score;
            MissionClass.Position = mission_[number].Position;
        
            OccurMissionExecute(MissionClass.Number, MissionClass.Description, MissionClass.NextNumber, MissionClass.Score);
            
            // ｱN･ﾈ･[､J･ﾈｲMｳ・
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
                // ｩﾒｦｳ･ﾈｳ｣､wｧｹｦｨ
                isAllMissionComplete = true;
                Debug.Log("All missions completed!");
            }
        }

        public void TriggerBall(int number, string des, int nextNumber, int score, Vector3 pos)
        {
            if (MissionCompleted != null)
            {
                MissionCompleted(number, des, nextNumber, score, pos);
            }
            if (number != COMPLETE_NUMBER)
            {
                CompleteMission(number);
            }
        }
    }
}


