using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class HeartObject : TriggerObject
{
    public delegate void OccurTriggerHeartEventHandler(HeartObject obj);
    public static OccurTriggerHeartEventHandler OccurTriggerHeart;
    protected override void onTriggerEnterTag(Collider other)
    {        
        Destroy(gameObject);
    }

    private void Update()
    {
        /*
        if (!GameManager.Instance.MissionManager.IsHeartMissionStart)
        {
            Destroy(gameObject);
        }
        */
    }

    private void OnDestroy()
    {
        OccurTriggerHeart = null;
    }
}
