using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class AccelerateObject : TriggerObject
{
    public delegate void OccurAccelerateEventHandler(Vector3 addforce);
    public static OccurAccelerateEventHandler OccurAccelerate;

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
        OccurAccelerate(addForce);
    }
}
