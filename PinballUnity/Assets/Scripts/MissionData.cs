using UnityEngine;
namespace MissionNamespace
{
    [CreateAssetMenu(fileName = "NewMissionData", menuName = "Mission Data", order = 1)]
    public class MissionData : ScriptableObject
    {
        public Mission[] missions;
    }

    [System.Serializable]
    public class Mission
    {
        public int number_;
        public string description_ = "";
        public int nextNumber_;
        public int score_;
        public Vector3 position_;

    }
}