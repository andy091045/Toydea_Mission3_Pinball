using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    public ParticleSystem effect;

    // Start is called before the first frame update
    void Start()
    {
        MissionObject.OccurTriggerMissionObject += PlayExplosionEffect;
    }

    private void PlayExplosionEffect(MissionObject missionObject)
    {
        ParticleSystem newEffect = Instantiate(effect, missionObject.transform.position, Quaternion.identity);
        newEffect.Play();
    }

    private void OnDestroy()
    {
        MissionObject.OccurTriggerMissionObject -= PlayExplosionEffect;
    }

}
