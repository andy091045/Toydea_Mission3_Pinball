using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class AccelerateObject : TriggerObject
{
    [SerializeField] private AudioClip soundEffect_;
    private AudioSource audioSource;

    public float AccelerateAddForce
    {
        get => GameInput.Instance.AccelerateForce;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void onTriggerEnterTag(Collider other)
    {
        audioSource.PlayOneShot(soundEffect_);
        Vector3 addForce = other.attachedRigidbody.velocity.normalized * AccelerateAddForce;
        GameManager.Instance.OccurAccelerateEvent.Invoke(addForce);
    }
}
