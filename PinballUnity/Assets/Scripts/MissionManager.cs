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
        // Ū�� MissionData �������ȸ��
        Mission[] missions = missionData.missions;

        // �N���ȸ�ƥ[�J activeMissions List
        foreach (Mission mission in missions)
        {
            activeMissions_.Add(mission);
            mission_.Add(mission);
        }

        ExecuteMission(mission_[0].number_);
    }

    public void ExecuteMission(int number)
    {
        // �ͦ����Ȫ���
        GameObject executingObject_ = Instantiate(taskPrefab_, mission_[number].position_, Quaternion.identity);
        executingObject_.GetComponent<ExecutingMission>().number_ = mission_[number].number_;
        executingObject_.GetComponent<ExecutingMission>().description_ = mission_[number].description_;
        executingObject_.GetComponent<ExecutingMission>().nextNumber_ = mission_[number].nextNumber_;
        executingObject_.GetComponent<ExecutingMission>().score_ = mission_[number].score_;
        executingObject_.GetComponent<ExecutingMission>().position_ = mission_[number].position_;

        // �N���ȥ[�J���ȲM��
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
            // �Ҧ����ȳ��w����
            Debug.Log("All missions completed!");
        }
    }
}
