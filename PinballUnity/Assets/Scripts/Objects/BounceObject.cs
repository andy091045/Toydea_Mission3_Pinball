using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObject : CollisionObject
{    
    [SerializeField] private int OneBounceScore_ => GameInput.Instance.BounceScore;
    [SerializeField] private AudioClip soundEffect_;
    private AudioSource audioSource;
    private float bounceMinForce_ => GameInput.Instance.BounceMinForce;
    private float bounceMaxForce_ => GameInput.Instance.BounceMinForce;

    [Header("Flashing")]
    public Color OriginColor;
    [SerializeField] private float DesiredIntensity = 10.0f;
    [SerializeField] private float NowIntensity = 1.0f;
    [SerializeField] private float Increase = 0.3f;
    [SerializeField] private bool IsFlashing = false;
    [SerializeField] private int FlashingTimes = 2;
    private float originIntensity_;
    private int times = 0;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OriginColor = this.transform.GetComponent<MeshRenderer>().material.color;
        originIntensity_ = NowIntensity;
    }

    void Update()
    {
        TryFlashing();
    }

    private void TryFlashing()
    {
        if (IsFlashing)
        {
            this.transform.GetComponent<MeshRenderer>().material.SetVector("_EmissionColor", OriginColor * NowIntensity);
            NowIntensity = NowIntensity + Increase;
            if (NowIntensity > DesiredIntensity)
            {
                NowIntensity = originIntensity_;
                this.transform.GetComponent<MeshRenderer>().material.SetVector("_EmissionColor", OriginColor * NowIntensity);
                times++;
                if (times > FlashingTimes)
                {
                    IsFlashing = false;
                    times = 0;
                }
            }
        }
    }

    protected override void onCollisionEnterTag(Collision collision)
    {
        audioSource.PlayOneShot(soundEffect_);
        GameEvent.OccurBounceAddScore(OneBounceScore_ );
        GameEvent.OccurBouncePhysic(ComputeForce(collision));
        IsFlashing = true;
    }

    private Vector3 ComputeForce(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        Vector3 bounceDirection = Vector3.Reflect(collision.relativeVelocity.normalized, normal);
        float bounceSpeed = Mathf.Clamp(collision.relativeVelocity.magnitude, bounceMinForce_, bounceMaxForce_);
        return bounceDirection * bounceSpeed;
    }
}
