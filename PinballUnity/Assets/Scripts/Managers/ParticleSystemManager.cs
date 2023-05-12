using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public ParticleSystem effect;

    // Start is called before the first frame update
    void Start()
    {
        GameEvent.OccurTriggerMissionObject += PlayExplosionEffect;
        GameEvent.OccurTriggerHeart += GameObjectPlayExplosionEffect;
    }

    private void PlayExplosionEffect(MissionObject missionObject)
    {
        ParticleSystem newEffect = Instantiate(effect, missionObject.transform.position, Quaternion.identity);
        newEffect.Play();
    }

    private void GameObjectPlayExplosionEffect(GameObject gameObject)
    {
        ParticleSystem newEffect = Instantiate(effect, gameObject.transform.position, Quaternion.identity);
        newEffect.Play();
    }

    private void OnDestroy()
    {
        GameEvent.OccurTriggerMissionObject -= PlayExplosionEffect;
        GameEvent.OccurTriggerHeart -= GameObjectPlayExplosionEffect;
    }

}
