using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class HeartObject : TriggerObject
{
    protected override void onTriggerEnterTag(Collider other)
    {
        GameManager.Instance.MissionManager.TriggerHeart(1, '+');
        GameManager.Instance.MissionManager.ReturnPosition(transform.position);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!GameManager.Instance.MissionManager.IsHeartMissionStart)
        {
            Destroy(gameObject);
        }
    }
}
