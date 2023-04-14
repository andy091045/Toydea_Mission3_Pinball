using UnityEngine;
namespace MissionNamespace
{
    [CreateAssetMenu(fileName = "NewMissionData", menuName = "Mission Data", order = 1)]
    public class MissionData : ScriptableObject
    {
        public Mission[] Missions;
    }

    [System.Serializable]
    public class Mission
    {
        public int Number;
        public string Description = "";
        public int NextNumber;
        public int Score;
        public Vector3 Position;

    }
}