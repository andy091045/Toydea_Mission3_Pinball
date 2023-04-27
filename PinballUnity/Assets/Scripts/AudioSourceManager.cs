using ScoreManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffect_;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        HeartObject.OccurTriggerHeart += GetHeartSound;
        MissionObject.OccurTriggerMissionObject += GetMissionSound;
    }

    private void GetHeartSound(GameObject obj)
    {
        audioSource.PlayOneShot(soundEffect_);
    }

    private void GetMissionSound(MissionObject obj)
    {
        audioSource.PlayOneShot(soundEffect_);
    }

    private void OnDestroy()
    {
        HeartObject.OccurTriggerHeart -= GetHeartSound;
        MissionObject.OccurTriggerMissionObject -= GetMissionSound;
    }
}
