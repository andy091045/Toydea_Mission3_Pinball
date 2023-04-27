using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class HeartObject : TriggerObject
{
    public delegate void OccurTriggerHeartEventHandler(GameObject obj);
    public static OccurTriggerHeartEventHandler OccurTriggerHeart;

    protected override void onTriggerEnterTag(Collider other)
    {
        OccurTriggerHeart(this.gameObject);
        Destroy(gameObject);
    }

    private void Update()
    {
        

        if (!GameInput.Instance.IsHeartMissionStart)
        {
            Destroy(gameObject);
        }
        
    }
}
