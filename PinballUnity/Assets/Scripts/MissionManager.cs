using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using MissionNamespace;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;
    public GameObject taskPrefab_;
    public MissionData missionData;
    public List<Mission> mission_ = new List<Mission>();
    public List<Mission> activeMissions_ = new List<Mission>();
    //public List<Mission> completedMissions_ = new List<Mission>();
    public int completeNumber_ = 999999;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // 讀取 MissionData 中的任務資料
        Mission[] missions = missionData.missions;

        // 將任務資料加入 activeMissions List
        foreach (Mission mission in missions)
        {
            activeMissions_.Add(mission);
            mission_.Add(mission);
        }

        ExecuteMission(mission_[0].number_);
    }

    public void ExecuteMission(int number)
    {
        // 生成任務物件
        GameObject executingObject_ = Instantiate(taskPrefab_, mission_[number].position_, Quaternion.identity);
        executingObject_.GetComponent<ExecutingMission>().number_ = mission_[number].number_;
        executingObject_.GetComponent<ExecutingMission>().description_ = mission_[number].description_;
        executingObject_.GetComponent<ExecutingMission>().nextNumber_ = mission_[number].nextNumber_;
        executingObject_.GetComponent<ExecutingMission>().score_ = mission_[number].score_;
        executingObject_.GetComponent<ExecutingMission>().position_ = mission_[number].position_;

        // 將任務加入任務清單
        //missions.Add(mission);
    }

    public void CompleteMission(int number)
    {        
        if (mission_[number].nextNumber_ != completeNumber_) { 
            ExecuteMission(mission_[number].nextNumber_);
        }
        for (int i = 0; i < activeMissions_.Count; i++)
        {
            if (activeMissions_[i].number_ == number)
            {
                //completedMissions_.Add(mission_[number]);
                activeMissions_.Remove(mission_[number]);                
            }
        }
        if (activeMissions_.Count == 0)
        {
            // 所有任務都已完成
            Debug.Log("All missions completed!");
        }
    }
}
