using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class HeartObject : TriggerObject
{

    protected override void onTriggerEnterTag(Collider other)
    {
        GameEvent.OccurTriggerHeart(this.gameObject);
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
